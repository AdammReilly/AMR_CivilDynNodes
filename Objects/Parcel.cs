using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DynamoNodes;
using Autodesk.DesignScript.Runtime;
using System.Collections.Generic;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Objects
{

    public partial class Parcel : CivilObject
    {
        #region variables
        internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;
        //private string _name;
        //private string _description;
        internal IList<Autodesk.DesignScript.Geometry.PolyCurve> _polyCurves;
        internal Autodesk.DesignScript.Geometry.PolyCurve _outerPolyCurve;
        internal Autodesk.AutoCAD.DatabaseServices.Polyline _outerPolyline;
        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        internal Parcel(Autodesk.Civil.DatabaseServices.Entity curCivilEntity, bool isDynamoOwned) : base( curCivilEntity, isDynamoOwned)
        {
            _curCivilObject = curCivilEntity;
            _polyCurves = PolyCurves();
            //_outerPolyline = (Autodesk.AutoCAD.DatabaseServices.Polyline)curCivilEntity.BaseCurve;
            //_outerPolyCurve = PolyCurveByParcel(this);
            //_outerPolyCurve = _polyCurves[0];
        }

        /// <summary>
        /// Select a parcel by name.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="siteObject">Site to search.</param>
        /// <param name="parcelName">The name of the parcel.</param>
        /// <returns>A parcel.</returns>
        [NodeCategory("Create")]
        [IsVisibleInDynamoLibrary(true)]
        public static Parcel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, Profile siteObject, string parcelName)
        {
            Parcel retParcel = null;
            //get the current document and database
            AcadApp.Document doc = document.AcDocument;
            Database db = doc.Database;
            Autodesk.Civil.DatabaseServices.Site site = (Autodesk.Civil.DatabaseServices.Site)siteObject._curCivilObject;
            Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection parcelIds = site.GetParcelIds();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId objectId in parcelIds)
                {
                    retParcel = new Parcel((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead), true);
                    if (retParcel.Name != parcelName)
                    { retParcel = null; }
                    else { return retParcel; }
                }
            }
            return retParcel;
        }

        /// <summary>
        /// Select a parcel by number.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="siteObject">Site to search.</param>
        /// <param name="parcelNumber">The number of the parcel.</param>
        /// <returns>A parcel.</returns>
        [NodeCategory("Create")]
        [IsVisibleInDynamoLibrary(true)]
        public static Parcel ByNumber(Autodesk.AutoCAD.DynamoNodes.Document document, Profile siteObject, int parcelNumber)
        {
            Autodesk.Civil.DatabaseServices.Parcel retParcel = null;
            //get the current document and database
            AcadApp.Document doc = document.AcDocument;
            Database db = doc.Database;
            Autodesk.Civil.DatabaseServices.Site site = (Autodesk.Civil.DatabaseServices.Site)siteObject._curCivilObject;
            Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection parcelIds = site.GetParcelIds();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId objectId in parcelIds)
                {
                    retParcel = (Autodesk.Civil.DatabaseServices.Parcel)trans.GetObject(objectId, OpenMode.ForRead);
                    if (retParcel.Number != parcelNumber)
                    { retParcel = null; }
                    else { return new Parcel(retParcel, true); }
                }
            }
            return null;
        }

        /// <summary>
        /// Select a parcel by index number.
        /// </summary>
        /// <param name="document">The document.</param>
        /// <param name="siteObject">The site to search.</param>
        /// <param name="index">The index number of the parcel.</param>
        /// <returns>A parcel</returns>
        [NodeCategory("Create")]
        [IsVisibleInDynamoLibrary(true)]
        public static Parcel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, Profile siteObject, int index)
        {
            Parcel retParcel = null;
            //get the current document and database
            AcadApp.Document doc = document.AcDocument;
            Database db = doc.Database;
            Autodesk.Civil.DatabaseServices.Site site = (Autodesk.Civil.DatabaseServices.Site)siteObject._curCivilObject;
            Autodesk.AutoCAD.DatabaseServices.ObjectIdCollection parcelIds = site.GetParcelIds();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retParcel = new Parcel((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(parcelIds[index], OpenMode.ForRead), true);
            }
            return retParcel;
        }

        #endregion

        #region public methods

        #endregion

        #region properties
        /// <summary>
        /// Returns the area of the parcel.
        /// </summary>
        [IsVisibleInDynamoLibrary(true)]
        public double Area => _curCivilObject.Area;

        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return "Parcel (" + _curCivilObject.Name + ")";
        }

        /// <summary>
        /// Returns a PolyCurve representing the outside parcel segments of the given parcel.
        /// </summary>
        [IsVisibleInDynamoLibrary(false)]
        public Autodesk.DesignScript.Geometry.PolyCurve OutsidePoly => _outerPolyCurve;

        /// <summary>
        /// Returns a list of Dynamo Points representing the endpoints of each parcel segment.
        /// </summary>
        [IsVisibleInDynamoLibrary(false)]
        public IList<Autodesk.DesignScript.Geometry.Point> OutsideVertices => PointsFromPolyCurve(_outerPolyCurve);

        [IsVisibleInDynamoLibrary(true)]
        public IList<Autodesk.DesignScript.Geometry.PolyCurve> PolyCurves()
        {
            IList<Autodesk.DesignScript.Geometry.PolyCurve> retPolys = new List<Autodesk.DesignScript.Geometry.PolyCurve>();
            dynamic oParcel = _curCivilObject.AcadObject;
            dynamic loops = oParcel.ParcelLoops;
            foreach (dynamic loop in loops)
            {
                Autodesk.AutoCAD.DatabaseServices.Polyline poly = new Autodesk.AutoCAD.DatabaseServices.Polyline();
                int count = loop.Count;
                for (int i = 0; i < count; i++)
                {
                    dynamic segElement = loop.Item(i);
                    double x = segElement.StartX;
                    double y = segElement.StartY;
                    double bulge = 0;
                    try
                    {
                        bulge = (double)segElement.Bulge;
                    }
                    catch { }
                    poly.AddVertexAt(i, new Autodesk.AutoCAD.Geometry.Point2d(x, y), bulge, 0, 0);
                }
                poly.Closed = true;
                retPolys.Add(ConvertPolylineToPolyCurve(poly));
            }
            return retPolys;
        }

        #endregion

        #region Private
        [IsVisibleInDynamoLibrary(false)]
        private object AcadObject
        { get => _curCivilObject.AcadObject; }

        [IsVisibleInDynamoLibrary(false)]
        private Curve BaseCurve
        { get => _curCivilObject.BaseCurve; }

        #endregion
    }
}

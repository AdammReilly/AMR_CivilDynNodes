using Autodesk.Aec.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DynamoNodes;
using Autodesk.DesignScript.Runtime;
using System.Collections.Generic;

namespace CivilDynamoTools
{

    public partial class Parcel : CivilObject
    {
        #region variables
        //private Autodesk.Civil.DatabaseServices.Entity _curCivilObject;
        //private string _name;
        //private string _description;
        internal Autodesk.DesignScript.Geometry.PolyCurve _outerPolyCurve;
        internal Autodesk.AutoCAD.DatabaseServices.Polyline _outerPolyline;
        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(true)]
        public Parcel(Autodesk.Civil.DatabaseServices.Entity curCivilEntity) : base( curCivilEntity )
        {
            _outerPolyline = (Autodesk.AutoCAD.DatabaseServices.Polyline)_curCivilObject.BaseCurve;
            _outerPolyCurve = PolyCurveByParcel(this);
        }

        #endregion

        #region public methods

        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(true)]
        public double GetArea
        { get => _curCivilObject.Area; }
        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return "Parcel { " + this._name + " }";
        }
        [IsVisibleInDynamoLibrary(true)]
        public Autodesk.DesignScript.Geometry.PolyCurve GetOutsidePoly
        {
            get=> PolyCurveByParcel(this);
        }
        [IsVisibleInDynamoLibrary(true)]
        public IList<Autodesk.DesignScript.Geometry.Point> GetOutsideVertices
        { get => PointsFromPolyCurve(_outerPolyCurve); }


        #endregion

        #region PrivateMethods
        [IsVisibleInDynamoLibrary(false)]
        private object AcadObject
        { get => _curCivilObject.AcadObject; }

        [IsVisibleInDynamoLibrary(false)]
        private Curve BaseCurve
        { get => _curCivilObject.BaseCurve; }

        #endregion
    }
}

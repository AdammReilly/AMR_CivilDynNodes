using Autodesk.Aec.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DynamoNodes;
using Autodesk.DesignScript.Runtime;
using System.Collections.Generic;

namespace CivilDynamoTools
{

    public partial class Parcel
    {
        #region variables
        private Autodesk.Civil.DatabaseServices.Entity _curCivilObject;
        private string _name;
        private string _description;
        internal Autodesk.DesignScript.Geometry.PolyCurve _outerPolyCurve;
        internal Autodesk.AutoCAD.DatabaseServices.Polyline _outerPolyline;
        #endregion

        #region constructor
        //[IsVisibleInDynamoLibrary(false)]
        public Parcel(Autodesk.Civil.DatabaseServices.Entity curCivilEntity)
        {
            _curCivilObject = curCivilEntity;
            _name = curCivilEntity.Name;
            _description = curCivilEntity.Description;
            _outerPolyline = (Autodesk.AutoCAD.DatabaseServices.Polyline)_curCivilObject.BaseCurve;
            _outerPolyCurve = PolyCurveByParcel(this);
        }
        #endregion

        #region public methods
        [IsVisibleInDynamoLibrary(true)]
        public Parcel SetName(string name)
        {
            this._name = name;
            return this;
        }
        [IsVisibleInDynamoLibrary(true)]
        public Parcel SetDescription(string description)
        {
            this._description = description;
            return this;
        }
        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(true)]
        public double GetArea
        { get => _curCivilObject.Area; }
        [IsVisibleInDynamoLibrary(true)]
        public string GetName
        { get => this._name; }
        [IsVisibleInDynamoLibrary(true)]
        public string GetDescription
        { get => this._description; }
        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return this._name;
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

using Autodesk.Aec.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DynamoNodes;
using Autodesk.DesignScript.Runtime;
using System.Collections.Generic;

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(true)]
    public class CivilObject
    {
        #region variables
        internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;
        internal string _name;
        internal string _description;
        #endregion

        #region constructor
        //[IsVisibleInDynamoLibrary(false)]
        public CivilObject(Autodesk.Civil.DatabaseServices.Entity curCivilEntity)
        {
            _curCivilObject = curCivilEntity;
            _name = curCivilEntity.Name;
            _description = curCivilEntity.Description;
        }
        #endregion
        #region public methods
        [IsVisibleInDynamoLibrary(true)]
        public CivilObject SetName(string name)
        {
            this._name = name;
            return this;
        }
        [IsVisibleInDynamoLibrary(true)]
        public CivilObject SetDescription(string description)
        {
            this._description = description;
            return this;
        }
        #endregion
        #region properties
        [IsVisibleInDynamoLibrary(true)]
        public string GetName
        { get => this._name; }
        [IsVisibleInDynamoLibrary(true)]
        public string GetDescription
        { get => this._description; }
        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return "Civil Entity { " + this._name + "}";
        }
        #endregion
    }
}

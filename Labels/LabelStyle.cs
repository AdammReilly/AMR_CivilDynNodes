using Autodesk.Aec.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DynamoNodes;
using Autodesk.DesignScript.Runtime;
using NUnit.Framework;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;

namespace CivilDynamoTools.LabelStyles
{
    [IsVisibleInDynamoLibrary(false)]
    public class LabelStyle : Autodesk.AutoCAD.DynamoNodes.ObjectBase
    {
        #region variables
        //internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;
        internal Autodesk.AutoCAD.DatabaseServices.DBObject _curDBObject;
        internal Autodesk.Civil.DatabaseServices.Styles.StyleBase _curStyleBase;
        internal string _name;
        internal string _description;
        internal string _labelStyleType = "Label";
        #endregion

        #region constructor

        [IsVisibleInDynamoLibrary(false)]
        protected LabelStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            _curDBObject = obj;
            // Autodesk.Civil.DatabaseServices.Styles.StyleBase is the base of all individual styles
            _curStyleBase = (Autodesk.Civil.DatabaseServices.Styles.StyleBase)obj;
            _name = _curStyleBase.Name;
            _description = _curStyleBase.Description;
        }
        #endregion

        #region public methods

        #endregion

        #region internalMethods
        internal static Autodesk.AutoCAD.DatabaseServices.DBObject DBObjectByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, LabelStyleCollection labelStyleRoot, int index)
        {
            Autodesk.AutoCAD.DatabaseServices.DBObject retLabels;
            Database db = document.AcDocument.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabels = trans.GetObject(labelStyleRoot[index], OpenMode.ForRead);
                trans.Commit();
            }
            return retLabels;
        }

        internal static Autodesk.AutoCAD.DatabaseServices.DBObject DBObjectByName(Autodesk.AutoCAD.DynamoNodes.Document document, LabelStyleCollection labelStyleRoot, string labelStyleName)
        {
            Autodesk.AutoCAD.DatabaseServices.DBObject retLabels;
            Database db = document.AcDocument.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabels = trans.GetObject(labelStyleRoot[labelStyleName], OpenMode.ForRead);
                trans.Commit();
            }
            return retLabels;
        }

        internal static List<Autodesk.AutoCAD.DatabaseServices.DBObject> GetLabelStylesAsDBObjects(Autodesk.AutoCAD.DynamoNodes.Document document, LabelStyleCollection labelStyleCollection)
        {
            List<Autodesk.AutoCAD.DatabaseServices.DBObject> dbObjectsList = new List<Autodesk.AutoCAD.DatabaseServices.DBObject>();
            Database db = document.AcDocument.Database;
            foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId labelStyle in labelStyleCollection)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    Autodesk.AutoCAD.DatabaseServices.DBObject dbObject = trans.GetObject(labelStyle, OpenMode.ForRead);
                    dbObjectsList.Add(dbObject);
                    trans.Commit();
                }
            }
            return dbObjectsList;
        }

        #endregion


        #region properties
        [IsVisibleInDynamoLibrary(true)]
        [Dynamo.Graph.Nodes.NodeCategory("Query")]
        public string Name
        { get => this._name; }
        [IsVisibleInDynamoLibrary(true)]
        [Dynamo.Graph.Nodes.NodeCategory("Query")]
        public string Description
        { get => this._description; }
        [IsVisibleInDynamoLibrary(false)]
        public override string ToString()
        {
            return _labelStyleType + " Style { " + this._name + "}";
        }
        #endregion
    }
}

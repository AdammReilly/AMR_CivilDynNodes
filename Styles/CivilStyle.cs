using Autodesk.Aec.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DatabaseServices;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.DynamoNodes;
using Autodesk.DesignScript.Runtime;
using NUnit.Framework;
using System.Collections.Generic;
using System.Windows;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class CivilStyle : Autodesk.AutoCAD.DynamoNodes.ObjectBase
    {
        #region variables
        //internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;
        internal Autodesk.AutoCAD.DatabaseServices.DBObject _curDBObject;
        internal Autodesk.Civil.DatabaseServices.Styles.StyleBase _curStyleBase;
        internal string _name;
        internal string _description;
        internal string _objectStyleType = "Object";
        #endregion

        #region constructor

        [IsVisibleInDynamoLibrary(false)]
        internal CivilStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            _curDBObject = obj;
            // Autodesk.Civil.DatabaseServices.Styles.StyleBase is the base of all individual styles
            _curStyleBase = (Autodesk.Civil.DatabaseServices.Styles.StyleBase)obj;
            _name = _curStyleBase.Name;
            _description = _curStyleBase.Description;
        }


        #endregion


        #region public methods
        [IsVisibleInDynamoLibrary(true)]
        public static CivilStyle ByCivilObject(Autodesk.AutoCAD.DynamoNodes.Document document, CivilObject civilObject)
        {
            Autodesk.AutoCAD.DatabaseServices.DBObject style = null;
            Database db = document.AcDocument.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                Autodesk.Civil.DatabaseServices.Entity civilEntity =(Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(civilObject.InternalDBObject.ObjectId, OpenMode.ForRead);
                style = trans.GetObject(civilEntity.StyleId, OpenMode.ForRead);
                trans.Commit();
            }
            return new CivilStyle(style, false);

        }


        #endregion

        #region internalMethods
        internal static Autodesk.AutoCAD.DatabaseServices.DBObject DBObjectByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, StyleCollectionBase stylesCollection, int index)
        {
            Autodesk.AutoCAD.DatabaseServices.DBObject retStyle;
            Database db = document.AcDocument.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retStyle = trans.GetObject(stylesCollection[index], OpenMode.ForRead);
                trans.Commit();
            }
            return retStyle;
        }
        internal static Autodesk.AutoCAD.DatabaseServices.DBObject DBObjectByName(Autodesk.AutoCAD.DynamoNodes.Document document, StyleCollectionBase stylesCollection, string styleName)
        {
            Autodesk.AutoCAD.DatabaseServices.DBObject retStyle;
            Database db = document.AcDocument.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retStyle = trans.GetObject(stylesCollection[styleName], OpenMode.ForRead);
                trans.Commit();
            }
            return retStyle;
        }
        internal static List<Autodesk.AutoCAD.DatabaseServices.DBObject> GetStylesAsDBObjects(Autodesk.AutoCAD.DynamoNodes.Document document, StyleCollectionBase styleCollection)
        {
            List<Autodesk.AutoCAD.DatabaseServices.DBObject> retList = new List<Autodesk.AutoCAD.DatabaseServices.DBObject>();
            Database db = document.AcDocument.Database;
            foreach (Autodesk.AutoCAD.DatabaseServices.ObjectId oId in styleCollection)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    Autodesk.AutoCAD.DatabaseServices.DBObject style = trans.GetObject(oId, OpenMode.ForRead);
                    retList.Add(style);
                    trans.Commit();
                }
            }
            return retList;
        }

        internal static Autodesk.AutoCAD.DatabaseServices.DBObject GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document document, Autodesk.AutoCAD.DatabaseServices.DBObject dbObject)
        {
            Autodesk.Civil.DatabaseServices.Styles.StyleBase civilEntity = (Autodesk.Civil.DatabaseServices.Styles.StyleBase)dbObject;
            Autodesk.AutoCAD.DatabaseServices.DBObject style = null;
            Database db = document.AcDocument.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                style = trans.GetObject(civilEntity.ObjectId, OpenMode.ForRead);
                trans.Commit();
            }
            return style;
            
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

        [IsVisibleInDynamoLibrary(true)]
        public virtual CivilStyle Style
        {
            get => new CivilStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }

        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return this._objectStyleType + " Style { " + this._name + "}";
        }
        #endregion
    }
}

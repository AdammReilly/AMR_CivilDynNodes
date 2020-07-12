using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.Styles.General
{
    [IsVisibleInDynamoLibrary(true)]
    public class ShapeStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ShapeStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Shape";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new ShapeStyle Style
        {
            get => new ShapeStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<ShapeStyle> GetShapeStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ShapeStyle> retList = new List<ShapeStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ShapeStyles))
            {
                ShapeStyle style = new ShapeStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static ShapeStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ShapeStyle retStyle = new ShapeStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ShapeStyles, index), false);
            return retStyle;
        }

        public static ShapeStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ShapeStyle retStyle = new ShapeStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ShapeStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class CantViewStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected CantViewStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Cant View";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]

        public new CantViewStyle Style
        {
            get => new CantViewStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }

        #endregion

        #region staticMethods
        public static List<CantViewStyle> GetCantViewStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CantViewStyle> retList = new List<CantViewStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CantViewStyles))
            {
                CantViewStyle style = new CantViewStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static CantViewStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CantViewStyle retStyle = new CantViewStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CantViewStyles, index), false);
            return retStyle;
        }

        public static CantViewStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            CantViewStyle retStyle = new CantViewStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CantViewStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

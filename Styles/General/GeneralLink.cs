using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.Styles.General

{
    [IsVisibleInDynamoLibrary(true)]
    public class LinkStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected LinkStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Link";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new LinkStyle Style
        {
            get => new LinkStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<LinkStyle> GetLinkStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<LinkStyle> retList = new List<LinkStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LinkStyles))
            {
                LinkStyle style = new LinkStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static LinkStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            LinkStyle retStyle = new LinkStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LinkStyles, index), false);
            return retStyle;
        }

        public static LinkStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            LinkStyle retStyle = new LinkStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LinkStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

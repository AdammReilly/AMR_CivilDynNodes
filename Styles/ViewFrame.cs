using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ViewFrameStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ViewFrameStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "View Frame";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new ViewFrameStyle Style
        {
            get => new ViewFrameStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<ViewFrameStyle> GetViewFrameStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ViewFrameStyle> retList = new List<ViewFrameStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ViewFrameStyles))
            {
                ViewFrameStyle style = new ViewFrameStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static ViewFrameStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ViewFrameStyle retStyle = new ViewFrameStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ViewFrameStyles, index), false);
            return retStyle;
        }

        public static ViewFrameStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ViewFrameStyle retStyle = new ViewFrameStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ViewFrameStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

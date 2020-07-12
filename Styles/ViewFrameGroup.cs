using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ViewFrameGroupStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ViewFrameGroupStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "View Frame Group";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new ViewFrameGroupStyle Style
        {
            get => new ViewFrameGroupStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<ViewFrameGroupStyle> GetViewFrameGroupStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ViewFrameGroupStyle> retList = new List<ViewFrameGroupStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.GroupPlotStyles))
            {
                ViewFrameGroupStyle style = new ViewFrameGroupStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static ViewFrameGroupStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ViewFrameGroupStyle retStyle = new ViewFrameGroupStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.GroupPlotStyles, index), false);
            return retStyle;
        }

        public static ViewFrameGroupStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ViewFrameGroupStyle retStyle = new ViewFrameGroupStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.GroupPlotStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class GradingStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected GradingStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Grading";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new GradingStyle Style
        {
            get => new GradingStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<GradingStyle> GetGradingStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<GradingStyle> retList = new List<GradingStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.GradingStyles))
            {
                GradingStyle style = new GradingStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static GradingStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            GradingStyle retStyle = new GradingStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.GradingStyles, index), false);
            return retStyle;
        }

        public static GradingStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            GradingStyle retStyle = new GradingStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.GradingStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

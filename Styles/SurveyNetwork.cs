using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurveyNetworkStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurveyNetworkStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Survey Network";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new SurveyNetworkStyle Style
        {
            get => new SurveyNetworkStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<SurveyNetworkStyle> GetSurveyNetworkStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurveyNetworkStyle> retList = new List<SurveyNetworkStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurveyNetworkStyles))
            {
                SurveyNetworkStyle style = new SurveyNetworkStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static SurveyNetworkStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurveyNetworkStyle retStyle = new SurveyNetworkStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurveyNetworkStyles, index), false);
            return retStyle;
        }

        public static SurveyNetworkStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurveyNetworkStyle retStyle = new SurveyNetworkStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurveyNetworkStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

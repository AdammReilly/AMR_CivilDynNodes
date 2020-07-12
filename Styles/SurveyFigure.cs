using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurveyFigureStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurveyFigureStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Survey Figure";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new SurveyFigureStyle Style
        {
            get => new SurveyFigureStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<SurveyFigureStyle> GetSurveyFigureStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurveyFigureStyle> retList = new List<SurveyFigureStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurveyFigureStyles))
            {
                SurveyFigureStyle style = new SurveyFigureStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static SurveyFigureStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurveyFigureStyle retStyle = new SurveyFigureStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurveyFigureStyles, index), false);
            return retStyle;
        }

        public static SurveyFigureStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurveyFigureStyle retStyle = new SurveyFigureStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurveyFigureStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

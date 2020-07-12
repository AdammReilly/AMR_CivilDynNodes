using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.SurveyFigures
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurveyFigureCurveLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SurveyFigureCurveLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Survey Curve";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SurveyFigureCurveLabel> GetSurveyFigureCurveLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurveyFigureCurveLabel> retLabels = new List<SurveyFigureCurveLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().CurveLabelStyles))
            {
                SurveyFigureCurveLabel labelObject = new SurveyFigureCurveLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurveyFigureCurveLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurveyFigureCurveLabel retLabel = new SurveyFigureCurveLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().CurveLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurveyFigureCurveLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SurveyFigureCurveLabel retLabel = new SurveyFigureCurveLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().CurveLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

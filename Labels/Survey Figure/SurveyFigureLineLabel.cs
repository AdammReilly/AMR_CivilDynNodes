using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.SurveyFigures
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurveyFigureLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SurveyFigureLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Survey Line";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SurveyFigureLineLabel> GetSurveyFigureLineLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurveyFigureLineLabel> retLabels = new List<SurveyFigureLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().LineLabelStyles))
            {
                SurveyFigureLineLabel labelObject = new SurveyFigureLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurveyFigureLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurveyFigureLineLabel retLabel = new SurveyFigureLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().LineLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurveyFigureLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SurveyFigureLineLabel retLabel = new SurveyFigureLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().LineLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

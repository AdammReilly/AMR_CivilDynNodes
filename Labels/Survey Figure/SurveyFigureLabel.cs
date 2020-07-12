using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.SurveyFigures
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurveyFigureLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SurveyFigureLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Survey Figure";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SurveyFigureLabel> GetSurveyFigureLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurveyFigureLabel> retLabels = new List<SurveyFigureLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().FigureLabelStyles))
            {
                SurveyFigureLabel labelObject = new SurveyFigureLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurveyFigureLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurveyFigureLabel retLabel = new SurveyFigureLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().FigureLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurveyFigureLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SurveyFigureLabel retLabel = new SurveyFigureLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GetSurveyLabelStyles().FigureLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

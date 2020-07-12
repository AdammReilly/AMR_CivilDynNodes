using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.General
{
    [IsVisibleInDynamoLibrary(true)]
    public class GeneralCurveLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected GeneralCurveLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "General Curve";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<GeneralCurveLabel> GetGeneralCurveLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<GeneralCurveLabel> retLabels = new List<GeneralCurveLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralCurveLabelStyles))
            {
                GeneralCurveLabel labelObject = new GeneralCurveLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralCurveLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            GeneralCurveLabel retLabel = new GeneralCurveLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralCurveLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralCurveLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            GeneralCurveLabel retLabel = new GeneralCurveLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralCurveLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Pipes
{
    [IsVisibleInDynamoLibrary(true)]
    public class PipePlanProfileLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected PipePlanProfileLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Plan and Profile";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<PipePlanProfileLabel> GetPipePlanProfileLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<PipePlanProfileLabel> retLabels = new List<PipePlanProfileLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.PlanProfileLabelStyles))
            {
                PipePlanProfileLabel labelObject = new PipePlanProfileLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PipePlanProfileLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            PipePlanProfileLabel retLabel = new PipePlanProfileLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.PlanProfileLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PipePlanProfileLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            PipePlanProfileLabel retLabel = new PipePlanProfileLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.PlanProfileLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

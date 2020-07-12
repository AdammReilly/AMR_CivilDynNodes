using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Catchments
{
    [IsVisibleInDynamoLibrary(true)]
    public class CatchmentFlowSegmentLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected CatchmentFlowSegmentLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Catchment Flow Segment";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CatchmentFlowSegmentLabel> GetCatchmentLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CatchmentFlowSegmentLabel> retLabels = new List<CatchmentFlowSegmentLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.CatchmentLabelStyles.FlowSegmentLabelStyles))
            {
                CatchmentFlowSegmentLabel labelObject = new CatchmentFlowSegmentLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CatchmentFlowSegmentLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CatchmentFlowSegmentLabel retLabel = new CatchmentFlowSegmentLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.CatchmentLabelStyles.FlowSegmentLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CatchmentFlowSegmentLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            CatchmentFlowSegmentLabel retLabel = new CatchmentFlowSegmentLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.CatchmentLabelStyles.FlowSegmentLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

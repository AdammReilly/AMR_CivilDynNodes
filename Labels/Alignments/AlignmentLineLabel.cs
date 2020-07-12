using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Alignments
{
    [IsVisibleInDynamoLibrary(true)]
    public class AlignmentLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Alignment Line Segment";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Alignments.AlignmentLineLabel> GetAlignmentLineLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Alignments.AlignmentLineLabel> retLabels = new List<CivilDynamoTools.LabelStyles.Alignments.AlignmentLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.LineLabelStyles))
            {
                AlignmentLineLabel labelObject = new AlignmentLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static AlignmentLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AlignmentLineLabel retLabel = new AlignmentLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.LineLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static AlignmentLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            AlignmentLineLabel retLabel = new AlignmentLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.LineLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

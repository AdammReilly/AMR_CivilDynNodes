using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Alignments
{
    [IsVisibleInDynamoLibrary(true)]
    public class AlignmentLabelSet : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentLabelSet(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Alignment Label Set";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Alignments.AlignmentLabelSet> GetAlignmentLabelSets(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Alignments.AlignmentLabelSet> alignmentLabels = new List<CivilDynamoTools.LabelStyles.Alignments.AlignmentLabelSet>();
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            AlignmentLabelSetStyleCollection alignRoot = root.AlignmentLabelSetStyles;
            
            foreach (ObjectId setStyle in alignRoot)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    AlignmentLabelSet labelSet = new AlignmentLabelSet(trans.GetObject(setStyle, OpenMode.ForRead), false);
                    alignmentLabels.Add(labelSet);
                    trans.Commit();
                }
            }
            return alignmentLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static AlignmentLabelSet ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AlignmentLabelSet retLabel;
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            AlignmentLabelSetStyleCollection alignRoot = root.AlignmentLabelSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new AlignmentLabelSet(trans.GetObject(alignRoot[index], OpenMode.ForRead), false);
                trans.Commit();
            }
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static AlignmentLabelSet ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            AlignmentLabelSet retLabel;
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            AlignmentLabelSetStyleCollection alignRoot = root.AlignmentLabelSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new AlignmentLabelSet(trans.GetObject(alignRoot[labelStyleName], OpenMode.ForRead), false);
                trans.Commit();
            }
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

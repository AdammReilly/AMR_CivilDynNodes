using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Sections
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionLabelSet : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SectionLabelSet(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Section Label Set";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Sections.SectionLabelSet> GetSectionLabelSets(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Sections.SectionLabelSet> alignmentLabels = new List<CivilDynamoTools.LabelStyles.Sections.SectionLabelSet>();
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            SectionLabelSetStyleCollection alignRoot = root.SectionLabelSetStyles;

            foreach (ObjectId setStyle in alignRoot)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    SectionLabelSet labelSet = new SectionLabelSet(trans.GetObject(setStyle, OpenMode.ForRead), false);
                    alignmentLabels.Add(labelSet);
                    trans.Commit();
                }
            }
            return alignmentLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionLabelSet ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionLabelSet retLabel;
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            SectionLabelSetStyleCollection alignRoot = root.SectionLabelSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new SectionLabelSet(trans.GetObject(alignRoot[index], OpenMode.ForRead), false);
                trans.Commit();
            }
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionLabelSet ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SectionLabelSet retLabel;
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            SectionLabelSetStyleCollection alignRoot = root.SectionLabelSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new SectionLabelSet(trans.GetObject(alignRoot[labelStyleName], OpenMode.ForRead), false);
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

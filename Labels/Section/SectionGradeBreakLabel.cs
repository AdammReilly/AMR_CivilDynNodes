using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Sections
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionGradeBreakLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SectionGradeBreakLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Grade Break";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SectionGradeBreakLabel> GetSectionGradeBreakLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionGradeBreakLabel> retLabels = new List<SectionGradeBreakLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.GradeBreakLabelStyles))
            {
                SectionGradeBreakLabel labelObject = new SectionGradeBreakLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionGradeBreakLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionGradeBreakLabel retLabel = new SectionGradeBreakLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.GradeBreakLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionGradeBreakLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SectionGradeBreakLabel retLabel = new SectionGradeBreakLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.GradeBreakLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Sections
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionMinorOffsetLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SectionMinorOffsetLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Minor Offset";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SectionMinorOffsetLabel> GetSectionMinorOffsetLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionMinorOffsetLabel> retLabels = new List<SectionMinorOffsetLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.MinorOffsetLabelStyles))
            {
                SectionMinorOffsetLabel labelObject = new SectionMinorOffsetLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionMinorOffsetLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionMinorOffsetLabel retLabel = new SectionMinorOffsetLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.MinorOffsetLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionMinorOffsetLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SectionMinorOffsetLabel retLabel = new SectionMinorOffsetLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.MinorOffsetLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

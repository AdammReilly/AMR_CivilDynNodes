using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Sections
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionMajorOffsetLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SectionMajorOffsetLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Major Offset";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SectionMajorOffsetLabel> GetSectionMajorOffsetLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionMajorOffsetLabel> retLabels = new List<SectionMajorOffsetLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.MajorOffsetLabelStyles))
            {
                SectionMajorOffsetLabel labelObject = new SectionMajorOffsetLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionMajorOffsetLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionMajorOffsetLabel retLabel = new SectionMajorOffsetLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.MajorOffsetLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionMajorOffsetLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SectionMajorOffsetLabel retLabel = new SectionMajorOffsetLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.MajorOffsetLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

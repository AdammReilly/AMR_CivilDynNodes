using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Sections
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionSegmentLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SectionSegmentLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Section Segment";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SectionSegmentLabel> GetSectionSegmentLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionSegmentLabel> retLabels = new List<SectionSegmentLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.SegmentLabelStyles))
            {
                SectionSegmentLabel labelObject = new SectionSegmentLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionSegmentLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionSegmentLabel retLabel = new SectionSegmentLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.SegmentLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SectionSegmentLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SectionSegmentLabel retLabel = new SectionSegmentLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionLabelStyles.SegmentLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

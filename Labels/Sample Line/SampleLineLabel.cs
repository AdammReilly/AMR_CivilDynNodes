using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.SampleLines
{
    [IsVisibleInDynamoLibrary(true)]
    public class SampleLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SampleLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Sample Line";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SampleLineLabel> GetSampleLineLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SampleLineLabel> retLabels = new List<SampleLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SampleLineLabelStyles.LabelStyles))
            {
                SampleLineLabel labelObject = new SampleLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SampleLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SampleLineLabel retLabel = new SampleLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SampleLineLabelStyles.LabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SampleLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SampleLineLabel retLabel = new SampleLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SampleLineLabelStyles.LabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

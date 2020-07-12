using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Alignments.Station
{
    [IsVisibleInDynamoLibrary(true)]
    public class MajorStationLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected MajorStationLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Major Station";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Alignments.Station.MajorStationLabel> GetMajorStationLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Alignments.Station.MajorStationLabel> retLabels = new List<CivilDynamoTools.LabelStyles.Alignments.Station.MajorStationLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.MajorStationLabelStyles))
            {
                MajorStationLabel labelObject = new MajorStationLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static MajorStationLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            MajorStationLabel retLabel = new MajorStationLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.MajorStationLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static MajorStationLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            MajorStationLabel retLabel = new MajorStationLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.MajorStationLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

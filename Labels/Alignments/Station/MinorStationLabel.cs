using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Alignments.Station
{
    [IsVisibleInDynamoLibrary(true)]
    public class MinorStationLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected MinorStationLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Minor Station";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Alignments.Station.MinorStationLabel> GetMinorStationLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Alignments.Station.MinorStationLabel> retLabels = new List<CivilDynamoTools.LabelStyles.Alignments.Station.MinorStationLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.MinorStationLabelStyles))
            {
                MinorStationLabel labelObject = new MinorStationLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static MinorStationLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            MinorStationLabel retLabel = new MinorStationLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.MinorStationLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static MinorStationLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            MinorStationLabel retLabel = new MinorStationLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.MinorStationLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

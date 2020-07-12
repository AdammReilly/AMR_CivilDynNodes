using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.ProfileViews
{
    [IsVisibleInDynamoLibrary(true)]
    public class PVStationElevationLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected PVStationElevationLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Station Elevation";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<PVStationElevationLabel> GetProfileViewElevationLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<PVStationElevationLabel> retLabels = new List<PVStationElevationLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileViewLabelStyles.StationElevationLabelStyles))
            {
                PVStationElevationLabel labelObject = new PVStationElevationLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PVStationElevationLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            PVStationElevationLabel retLabel = new PVStationElevationLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileViewLabelStyles.StationElevationLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PVStationElevationLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            PVStationElevationLabel retLabel = new PVStationElevationLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileViewLabelStyles.StationElevationLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

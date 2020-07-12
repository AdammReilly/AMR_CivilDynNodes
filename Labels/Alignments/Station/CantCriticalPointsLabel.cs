using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Alignments.Station
{
    [IsVisibleInDynamoLibrary(true)]
    public class CantCriticalElevationLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected CantCriticalElevationLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Cant Critical Point";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Alignments.Station.CantCriticalElevationLabel> GetCantCriticalElevationLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Alignments.Station.CantCriticalElevationLabel> retLabels = new List<CivilDynamoTools.LabelStyles.Alignments.Station.CantCriticalElevationLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.CantCriticalPointsLabelStyles))
            {
                CantCriticalElevationLabel labelObject = new CantCriticalElevationLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CantCriticalElevationLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CantCriticalElevationLabel retLabel = new CantCriticalElevationLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.CantCriticalPointsLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CantCriticalElevationLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            CantCriticalElevationLabel retLabel = new CantCriticalElevationLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.CantCriticalPointsLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

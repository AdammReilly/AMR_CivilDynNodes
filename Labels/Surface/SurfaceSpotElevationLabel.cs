using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceSpotElevationLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceSpotElevationLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Surface Spot Elevation";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SurfaceSpotElevationLabel> GetSurfaceSpotElevationLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceSpotElevationLabel> retLabels = new List<SurfaceSpotElevationLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.SpotElevationLabelStyles))
            {
                SurfaceSpotElevationLabel labelObject = new SurfaceSpotElevationLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceSpotElevationLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceSpotElevationLabel retLabel = new SurfaceSpotElevationLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.SpotElevationLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceSpotElevationLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SurfaceSpotElevationLabel retLabel = new SurfaceSpotElevationLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.SpotElevationLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

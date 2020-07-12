using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceWatershedLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceWatershedLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Surface Watershed";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SurfaceWatershedLabel> GetSurfaceWatershedLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceWatershedLabel> retLabels = new List<SurfaceWatershedLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.WatershedLabelStyles))
            {
                SurfaceWatershedLabel labelObject = new SurfaceWatershedLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceWatershedLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceWatershedLabel retLabel = new SurfaceWatershedLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.WatershedLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceWatershedLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SurfaceWatershedLabel retLabel = new SurfaceWatershedLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.WatershedLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

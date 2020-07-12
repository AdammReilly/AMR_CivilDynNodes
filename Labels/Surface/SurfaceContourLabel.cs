using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceContourLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceContourLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Surface Contour";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SurfaceContourLabel> GetSurfaceContourLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceContourLabel> retLabels = new List<SurfaceContourLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.ContourLabelStyles))
            {
                SurfaceContourLabel labelObject = new SurfaceContourLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceContourLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceContourLabel retLabel = new SurfaceContourLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.ContourLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceContourLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SurfaceContourLabel retLabel = new SurfaceContourLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.ContourLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

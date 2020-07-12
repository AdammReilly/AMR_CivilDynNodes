using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceSlopeLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceSlopeLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Surface Slope";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SurfaceSlopeLabel> GetSurfaceSlopeLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceSlopeLabel> retLabels = new List<SurfaceSlopeLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.SlopeLabelStyles))
            {
                SurfaceSlopeLabel labelObject = new SurfaceSlopeLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceSlopeLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceSlopeLabel retLabel = new SurfaceSlopeLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.SlopeLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SurfaceSlopeLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SurfaceSlopeLabel retLabel = new SurfaceSlopeLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SurfaceLabelStyles.SlopeLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

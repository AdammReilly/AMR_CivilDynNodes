using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.ProfileViews
{
    [IsVisibleInDynamoLibrary(true)]
    public class PVDepthLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected PVDepthLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Depth";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<PVDepthLabel> GetProfileViewElevationLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<PVDepthLabel> retLabels = new List<PVDepthLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileViewLabelStyles.DepthLabelStyles))
            {
                PVDepthLabel labelObject = new PVDepthLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PVDepthLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            PVDepthLabel retLabel = new PVDepthLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileViewLabelStyles.DepthLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PVDepthLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            PVDepthLabel retLabel = new PVDepthLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileViewLabelStyles.DepthLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Profiles
{
    [IsVisibleInDynamoLibrary(true)]
    public class HorizontalGeometryPointLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected HorizontalGeometryPointLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Horizontal Geometry Point";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<HorizontalGeometryPointLabel> GetProfileLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<HorizontalGeometryPointLabel> retLabels = new List<HorizontalGeometryPointLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.HorizontalGeometryPointLabelStyles))
            {
                HorizontalGeometryPointLabel labelObject = new HorizontalGeometryPointLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static HorizontalGeometryPointLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            HorizontalGeometryPointLabel retLabel = new HorizontalGeometryPointLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.HorizontalGeometryPointLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static HorizontalGeometryPointLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            HorizontalGeometryPointLabel retLabel = new HorizontalGeometryPointLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.HorizontalGeometryPointLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.SectionViews
{
    [IsVisibleInDynamoLibrary(true)]
    public class SVOffsetElevationLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SVOffsetElevationLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Offset Elevation";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SVOffsetElevationLabel> GetSVOffsetElevationLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SVOffsetElevationLabel> retLabels = new List<SVOffsetElevationLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionViewLabelStyles.OffsetElevationLabelStyles))
            {
                SVOffsetElevationLabel labelObject = new SVOffsetElevationLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SVOffsetElevationLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SVOffsetElevationLabel retLabel = new SVOffsetElevationLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionViewLabelStyles.OffsetElevationLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SVOffsetElevationLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SVOffsetElevationLabel retLabel = new SVOffsetElevationLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionViewLabelStyles.OffsetElevationLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Alignments.Station
{
    [IsVisibleInDynamoLibrary(true)]
    public class DesignSpeedLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected DesignSpeedLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Design Speed";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Alignments.Station.DesignSpeedLabel> GetDesignSpeedLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Alignments.Station.DesignSpeedLabel> retLabels = new List<CivilDynamoTools.LabelStyles.Alignments.Station.DesignSpeedLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.DesignSpeedLabelStyles))
            {
                DesignSpeedLabel labelObject = new DesignSpeedLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static DesignSpeedLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            DesignSpeedLabel retLabel = new DesignSpeedLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.DesignSpeedLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static DesignSpeedLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            DesignSpeedLabel retLabel = new DesignSpeedLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.AlignmentLabelStyles.DesignSpeedLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

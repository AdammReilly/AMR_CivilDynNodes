using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.MatchLines
{
    [IsVisibleInDynamoLibrary(true)]
    public class RightMatchLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected RightMatchLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Right Match Line";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<RightMatchLineLabel> GetRightMatchLineLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<RightMatchLineLabel> retLabels = new List<RightMatchLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.MatchLineLabelStyles.RightLabelStyles))
            {
                RightMatchLineLabel labelObject = new RightMatchLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static RightMatchLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            RightMatchLineLabel retLabel = new RightMatchLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.MatchLineLabelStyles.RightLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static RightMatchLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            RightMatchLineLabel retLabel = new RightMatchLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.MatchLineLabelStyles.RightLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

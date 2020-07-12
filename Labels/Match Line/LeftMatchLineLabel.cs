using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.MatchLines
{
    [IsVisibleInDynamoLibrary(true)]
    public class LeftMatchLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected LeftMatchLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Left Match Line";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<LeftMatchLineLabel> GetLeftMatchLineLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<LeftMatchLineLabel> retLabels = new List<LeftMatchLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.MatchLineLabelStyles.LeftLabelStyles))
            {
                LeftMatchLineLabel labelObject = new LeftMatchLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static LeftMatchLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            LeftMatchLineLabel retLabel = new LeftMatchLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.MatchLineLabelStyles.LeftLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static LeftMatchLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            LeftMatchLineLabel retLabel = new LeftMatchLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.MatchLineLabelStyles.LeftLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

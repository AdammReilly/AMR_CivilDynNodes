using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.General
{
    [IsVisibleInDynamoLibrary(true)]
    public class GeneralMarkerLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected GeneralMarkerLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "General Marker";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<GeneralMarkerLabel> GetGeneralMarkerLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<GeneralMarkerLabel> retLabels = new List<GeneralMarkerLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralMarkerLabelStyles))
            {
                GeneralMarkerLabel labelObject = new GeneralMarkerLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralMarkerLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            GeneralMarkerLabel retLabel = new GeneralMarkerLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralMarkerLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralMarkerLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            GeneralMarkerLabel retLabel = new GeneralMarkerLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralMarkerLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

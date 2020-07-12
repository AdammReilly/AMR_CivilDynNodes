using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.General
{
    [IsVisibleInDynamoLibrary(true)]
    public class GeneralNoteLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected GeneralNoteLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "General Note";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<GeneralNoteLabel> GetGeneralNoteLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<GeneralNoteLabel> retLabels = new List<GeneralNoteLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralNoteLabelStyles))
            {
                GeneralNoteLabel labelObject = new GeneralNoteLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralNoteLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            GeneralNoteLabel retLabel = new GeneralNoteLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralNoteLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralNoteLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            GeneralNoteLabel retLabel = new GeneralNoteLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralNoteLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

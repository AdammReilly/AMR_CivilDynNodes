using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Structures
{
    [IsVisibleInDynamoLibrary(true)]
    public class StructureLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected StructureLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Structure";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<StructureLabel> GetStructureLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<StructureLabel> retLabels = new List<StructureLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.StructureLabelStyles.LabelStyles))
            {
                StructureLabel labelObject = new StructureLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static StructureLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            StructureLabel retLabel = new StructureLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.StructureLabelStyles.LabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static StructureLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            StructureLabel retLabel = new StructureLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.StructureLabelStyles.LabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Pipes
{
    [IsVisibleInDynamoLibrary(true)]
    public class PipeCrossProfileLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected PipeCrossProfileLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Pipe Profile";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<PipeCrossProfileLabel> GetPipeCrossProfileLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<PipeCrossProfileLabel> retLabels = new List<PipeCrossProfileLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.CrossProfileLabelStyles))
            {
                PipeCrossProfileLabel labelObject = new PipeCrossProfileLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PipeCrossProfileLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            PipeCrossProfileLabel retLabel = new PipeCrossProfileLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.CrossProfileLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PipeCrossProfileLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            PipeCrossProfileLabel retLabel = new PipeCrossProfileLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.CrossProfileLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

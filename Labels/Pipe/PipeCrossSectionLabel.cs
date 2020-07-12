using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Pipes
{
    [IsVisibleInDynamoLibrary(true)]
    public class PipeCrossSectionLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected PipeCrossSectionLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Pipe Section";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<PipeCrossSectionLabel> GetPipeCrossSectionLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<PipeCrossSectionLabel> retLabels = new List<PipeCrossSectionLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.CrossSectionLabelStyles))
            {
                PipeCrossSectionLabel labelObject = new PipeCrossSectionLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PipeCrossSectionLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            PipeCrossSectionLabel retLabel = new PipeCrossSectionLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.CrossSectionLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static PipeCrossSectionLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            PipeCrossSectionLabel retLabel = new PipeCrossSectionLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PipeLabelStyles.CrossSectionLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

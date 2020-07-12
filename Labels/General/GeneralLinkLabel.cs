using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.General
{
    [IsVisibleInDynamoLibrary(true)]
    public class GeneralLinkLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected GeneralLinkLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "General Link";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<GeneralLinkLabel> GetGeneralLinkLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<GeneralLinkLabel> retLabels = new List<GeneralLinkLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralLinkLabelStyles))
            {
                GeneralLinkLabel labelObject = new GeneralLinkLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralLinkLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            GeneralLinkLabel retLabel = new GeneralLinkLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralLinkLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralLinkLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            GeneralLinkLabel retLabel = new GeneralLinkLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralLinkLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

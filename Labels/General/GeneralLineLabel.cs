using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.General
{
    [IsVisibleInDynamoLibrary(true)]
    public class GeneralLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected GeneralLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "General Line";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<GeneralLineLabel> GetGeneralLineLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<GeneralLineLabel> retLabels = new List<GeneralLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralLineLabelStyles))
            {
                GeneralLineLabel labelObject = new GeneralLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            GeneralLineLabel retLabel = new GeneralLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralLineLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GeneralLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            GeneralLineLabel retLabel = new GeneralLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.GeneralLineLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

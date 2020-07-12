using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Catchments
{
    [IsVisibleInDynamoLibrary(true)]
    public class CatchmentAreaLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected CatchmentAreaLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Catchment Area";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CatchmentAreaLabel> GetCatchmentLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CatchmentAreaLabel> retLabels = new List<CatchmentAreaLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.CatchmentLabelStyles.AreaLabelStyles))
            {
                CatchmentAreaLabel labelObject = new CatchmentAreaLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CatchmentAreaLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CatchmentAreaLabel retLabel = new CatchmentAreaLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.CatchmentLabelStyles.AreaLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CatchmentAreaLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            CatchmentAreaLabel retLabel = new CatchmentAreaLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.CatchmentLabelStyles.AreaLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

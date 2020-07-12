using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.CogoPoints
{
    [IsVisibleInDynamoLibrary(true)]
    public class CogoPointLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected CogoPointLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Cogo Point";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CogoPointLabel> GetCogoPointLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CogoPointLabel> retLabels = new List<CogoPointLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PointLabelStyles.LabelStyles))
            {
                CogoPointLabel labelObject = new CogoPointLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CogoPointLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CogoPointLabel retLabel = new CogoPointLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PointLabelStyles.LabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static CogoPointLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            CogoPointLabel retLabel = new CogoPointLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.PointLabelStyles.LabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

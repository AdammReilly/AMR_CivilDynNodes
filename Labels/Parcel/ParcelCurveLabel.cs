using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Parcels
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelCurveLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelCurveLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Parcel Curve";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<ParcelCurveLabel> GetParcelCurveLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelCurveLabel> retLabels = new List<ParcelCurveLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.CurveLabelStyles))
            {
                ParcelCurveLabel labelObject = new ParcelCurveLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ParcelCurveLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelCurveLabel retLabel = new ParcelCurveLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.CurveLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ParcelCurveLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ParcelCurveLabel retLabel = new ParcelCurveLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.CurveLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

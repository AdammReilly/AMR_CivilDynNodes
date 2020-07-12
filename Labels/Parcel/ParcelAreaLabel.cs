using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Parcels
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Parcel Line";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<ParcelLineLabel> GetParcelLineLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelLineLabel> retLabels = new List<ParcelLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.LineLabelStyles))
            {
                ParcelLineLabel labelObject = new ParcelLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ParcelLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelLineLabel retLabel = new ParcelLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.LineLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ParcelLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ParcelLineLabel retLabel = new ParcelLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.LineLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Parcels
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelAreaLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelAreaLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Parcel Area";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<ParcelAreaLabel> GetParcelAreaLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelAreaLabel> retLabels = new List<ParcelAreaLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.AreaLabelStyles))
            {
                ParcelAreaLabel labelObject = new ParcelAreaLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ParcelAreaLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelAreaLabel retLabel = new ParcelAreaLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.AreaLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ParcelAreaLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ParcelAreaLabel retLabel = new ParcelAreaLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ParcelLabelStyles.AreaLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

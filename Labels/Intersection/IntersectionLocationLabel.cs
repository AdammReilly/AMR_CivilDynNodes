using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Intersections
{
    [IsVisibleInDynamoLibrary(true)]
    public class IntersectionLocationLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected IntersectionLocationLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Intersection Location";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<IntersectionLocationLabel> GetIntersectionLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<IntersectionLocationLabel> retLabels = new List<IntersectionLocationLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.IntersectionLabelStyles.LocationLabelStyles))
            {
                IntersectionLocationLabel labelObject = new IntersectionLocationLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static IntersectionLocationLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            IntersectionLocationLabel retLabel = new IntersectionLocationLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.IntersectionLabelStyles.LocationLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static IntersectionLocationLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            IntersectionLocationLabel retLabel = new IntersectionLocationLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.IntersectionLabelStyles.LocationLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

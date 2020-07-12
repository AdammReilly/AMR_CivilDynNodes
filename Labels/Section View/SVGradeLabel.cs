using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.SectionViews
{
    [IsVisibleInDynamoLibrary(true)]
    public class SVGradeLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected SVGradeLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Grade";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<SVGradeLabel> GetSVGradeLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SVGradeLabel> retLabels = new List<SVGradeLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionViewLabelStyles.GradeLabelStyles))
            {
                SVGradeLabel labelObject = new SVGradeLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SVGradeLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SVGradeLabel retLabel = new SVGradeLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionViewLabelStyles.GradeLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static SVGradeLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            SVGradeLabel retLabel = new SVGradeLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.SectionViewLabelStyles.GradeLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

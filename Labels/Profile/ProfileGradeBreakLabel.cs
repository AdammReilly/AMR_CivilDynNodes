using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Profiles
{
    [IsVisibleInDynamoLibrary(true)]
    public class GradeBreakLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected GradeBreakLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Grade Break";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<GradeBreakLabel> GetProfileLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<GradeBreakLabel> retLabels = new List<GradeBreakLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.GradeBreakLabelStyles))
            {
                GradeBreakLabel labelObject = new GradeBreakLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GradeBreakLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            GradeBreakLabel retLabel = new GradeBreakLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.GradeBreakLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static GradeBreakLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            GradeBreakLabel retLabel = new GradeBreakLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.GradeBreakLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

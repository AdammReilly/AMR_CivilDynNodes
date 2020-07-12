using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Profiles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ProfileCurveLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ProfileCurveLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Profile Curve";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<ProfileCurveLabel> GetProfileLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ProfileCurveLabel> retLabels = new List<ProfileCurveLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.CurveLabelStyles))
            {
                ProfileCurveLabel labelObject = new ProfileCurveLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileCurveLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ProfileCurveLabel retLabel = new ProfileCurveLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.CurveLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileCurveLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ProfileCurveLabel retLabel = new ProfileCurveLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.CurveLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Profiles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ProfileLineLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ProfileLineLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Profile Line";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<ProfileLineLabel> GetProfileLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ProfileLineLabel> retLabels = new List<ProfileLineLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.LineLabelStyles))
            {
                ProfileLineLabel labelObject = new ProfileLineLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileLineLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ProfileLineLabel retLabel = new ProfileLineLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.LineLabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileLineLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ProfileLineLabel retLabel = new ProfileLineLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ProfileLabelStyles.LineLabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

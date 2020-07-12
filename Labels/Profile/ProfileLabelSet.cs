using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.Profiles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ProfileLabelSet : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ProfileLabelSet(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Profile Label Set";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.Profiles.ProfileLabelSet> GetProfileLabelSets(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.Profiles.ProfileLabelSet> alignmentLabels = new List<CivilDynamoTools.LabelStyles.Profiles.ProfileLabelSet>();
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            ProfileLabelSetStyleCollection alignRoot = root.ProfileLabelSetStyles;

            foreach (ObjectId setStyle in alignRoot)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    ProfileLabelSet labelSet = new ProfileLabelSet(trans.GetObject(setStyle, OpenMode.ForRead), false);
                    alignmentLabels.Add(labelSet);
                    trans.Commit();
                }
            }
            return alignmentLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileLabelSet ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ProfileLabelSet retLabel;
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            ProfileLabelSetStyleCollection alignRoot = root.ProfileLabelSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new ProfileLabelSet(trans.GetObject(alignRoot[index], OpenMode.ForRead), false);
                trans.Commit();
            }
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileLabelSet ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ProfileLabelSet retLabel;
            Database db = document.AcDocument.Database;
            LabelSetStylesRoot root = CivilDocument.GetCivilDocument(db).Styles.LabelSetStyles;
            ProfileLabelSetStyleCollection alignRoot = root.ProfileLabelSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new ProfileLabelSet(trans.GetObject(alignRoot[labelStyleName], OpenMode.ForRead), false);
                trans.Commit();
            }
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

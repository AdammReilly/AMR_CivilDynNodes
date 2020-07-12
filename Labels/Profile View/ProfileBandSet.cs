using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.ProfileViews
{
    [IsVisibleInDynamoLibrary(true)]
    public class ProfileViewBandSet : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ProfileViewBandSet(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "Profile View Band Set";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<CivilDynamoTools.LabelStyles.ProfileViews.ProfileViewBandSet> GetProfileViewBandSets(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CivilDynamoTools.LabelStyles.ProfileViews.ProfileViewBandSet> alignmentLabels = new List<CivilDynamoTools.LabelStyles.ProfileViews.ProfileViewBandSet>();
            Database db = document.AcDocument.Database;
            ProfileViewBandSetStyleCollection bandRoot = CivilDocument.GetCivilDocument(db).Styles.ProfileViewBandSetStyles;

            foreach (ObjectId setStyle in bandRoot)
            {
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    ProfileViewBandSet labelSet = new ProfileViewBandSet(trans.GetObject(setStyle, OpenMode.ForRead), false);
                    alignmentLabels.Add(labelSet);
                    trans.Commit();
                }
            }
            return alignmentLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileViewBandSet ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ProfileViewBandSet retLabel;
            Database db = document.AcDocument.Database;
            ProfileViewBandSetStyleCollection bandRoot = CivilDocument.GetCivilDocument(db).Styles.ProfileViewBandSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new ProfileViewBandSet(trans.GetObject(bandRoot[index], OpenMode.ForRead), false);
                trans.Commit();
            }
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileViewBandSet ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ProfileViewBandSet retLabel;
            Database db = document.AcDocument.Database;
            ProfileViewBandSetStyleCollection bandRoot = CivilDocument.GetCivilDocument(db).Styles.ProfileViewBandSetStyles;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                retLabel = new ProfileViewBandSet(trans.GetObject(bandRoot[labelStyleName], OpenMode.ForRead), false);
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

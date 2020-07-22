using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using CivilDynamoTools.LabelStyles.Profiles;
using Autodesk.Civil.DatabaseServices;
using Autodesk.AutoCAD.DynamoNodes;
using System.Windows;
using CivilDynamoTools.Styles;
using Autodesk.DesignScript.Geometry;
using AecXBase;
using Autodesk.AutoCAD.Geometry;
using Autodesk.Civil.ApplicationServices;

namespace CivilDynamoTools.Objects
{
    [IsVisibleInDynamoLibrary(true)]
    public class ProfileView : CivilObject
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        internal ProfileView(Autodesk.Civil.DatabaseServices.Entity curCivilEntity, bool isDynamoOwned) : base(curCivilEntity, isDynamoOwned)
        {
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ProfileView ByAlignmentAndInsertion(Document document, Alignment alignment, Autodesk.DesignScript.Geometry.Point insertionPoint)
        {
            CivilDocument civilDoc = Autodesk.Civil.ApplicationServices.CivilDocument.GetCivilDocument(document.AcDocument.Database);
            Autodesk.Civil.DatabaseServices.ProfileView profileView;
            using (Transaction trans = document.AcDocument.TransactionManager.StartTransaction())
            {
                Point3d intPt = new Point3d(insertionPoint.X, insertionPoint.Y, insertionPoint.Z);
                ObjectId pvId = Autodesk.Civil.DatabaseServices.ProfileView.Create(alignment.InternalObjectId, intPt);
                profileView = (Autodesk.Civil.DatabaseServices.ProfileView)trans.GetObject(pvId, OpenMode.ForRead);
                trans.Commit();
            }
            return new ProfileView((Autodesk.Civil.DatabaseServices.Entity)profileView, true);
        }


        #endregion

        #region publichMethods


        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return "Profile View { " + Name + " }";
        }
        #endregion

        [IsVisibleInDynamoLibrary(true)]
        public ProfileView SetBandSetStyle(LabelStyles.ProfileViews.ProfileViewBandSet bandSet)
        {
                Autodesk.AutoCAD.ApplicationServices.Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Autodesk.AutoCAD.DatabaseServices.Database db = doc.Database;
                using (Autodesk.AutoCAD.DatabaseServices.Transaction trans = db.TransactionManager.StartTransaction())
                {
                    Autodesk.Civil.DatabaseServices.ProfileView entity = (Autodesk.Civil.DatabaseServices.ProfileView)trans.GetObject(_curCivilObject.ObjectId, OpenMode.ForWrite);
                if (!entity.IsErased)
                {
                    entity.Bands.ImportBandSetStyle(bandSet.InternalObjectId);
                }
                trans.Commit();
            }
            return this;
            
        }



        #region properties


        #endregion

        #region privateMethods


        #endregion

    }

}
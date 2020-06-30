using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using Autodesk.Civil.DatabaseServices;
using Autodesk.Civil.ApplicationServices;
using System.Collections.Generic;
using Autodesk.Civil.DynamoNodes;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(true)]
    public class Site : CivilObject
    {
        internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;

        protected Site(Autodesk.Civil.DatabaseServices.Entity entity, bool isDynamoOwned) : base(entity, isDynamoOwned)
        {
            _curCivilObject = entity;
        }

        /// <summary>
        /// Gets all sites in the current Civil Document.
        /// </summary>
        /// <returns>List of Sites.</returns>
        [IsVisibleInDynamoLibrary(true)]
        public static List<Profile> Sites
        {
            get
            {
                CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;

                ObjectIdCollection siteIds = civilDocument.GetSiteIds();
                //get the current document and database
                AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
                Database db = doc.Database;
                List<Profile> sites = new List<Profile>();
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId objectId in siteIds)
                    {
                        sites.Add(new Profile((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead), true));
                    }
                }
                return sites;
            }
        }

        /// <summary>
        /// Gets a Site matching the given name.
        /// </summary>
        /// <param name="siteName">The Site name to search for.</param>
        /// <returns>The requested Site, or null.</returns>
        [NodeCategory("Create")]
        [IsVisibleInDynamoLibrary(true)]
        public static Profile ByName(string siteName)
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;
            Profile site = null;
            ObjectIdCollection siteIds = civilDocument.GetSiteIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objectId in siteIds)
                {
                    site = new Profile((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead), true);
                    if (site.Name != siteName)
                    { site = null; }
                }
            }
            return site;
        }

        /// <summary>
        /// Gets a Site by the given index.
        /// </summary>
        /// <param name="index">The index number.</param>
        /// <returns>The Site, or null.</returns>
        [NodeCategory("Create")]
        [IsVisibleInDynamoLibrary(true)]
        public static Profile ByIndex(int index)
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;
            Profile site = null;
            ObjectIdCollection siteIds = civilDocument.GetSiteIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
               site = new Profile((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(siteIds[index], OpenMode.ForRead), true);
            }
            return site;
        }

        /// <summary>
        /// Gets all Parcels in the given Site.
        /// </summary>
        /// <returns>List of Parcels</returns>
        [IsVisibleInDynamoLibrary(true)]
        public List<Parcel> Parcels
        {
            get
            {
                //get the current document and database
                AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
                Database db = doc.Database;
                Autodesk.Civil.DatabaseServices.Site site = (Autodesk.Civil.DatabaseServices.Site)_curCivilObject;
                ObjectIdCollection parcelIds = site.GetParcelIds();
                List<Parcel> parcels = new List<Parcel>();
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId objectId in parcelIds)
                    {
                        Parcel curParcel = new Parcel((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead), true);
                        parcels.Add(curParcel);
                    }
                }
                return parcels;
            }
        }


        [IsVisibleInDynamoLibrary(true)]
        public IList<Autodesk.Civil.DatabaseServices.Entity> FeatureLines
        {
            get
            {
                //get the current document and database
                AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
                Database db = doc.Database;
                Autodesk.Civil.DatabaseServices.Site site = (Autodesk.Civil.DatabaseServices.Site)_curCivilObject;
                ObjectIdCollection flIds = site.GetFeatureLineIds();
                IList<Autodesk.Civil.DatabaseServices.Entity> retVal = new List<Autodesk.Civil.DatabaseServices.Entity>();
                using (Transaction trans = db.TransactionManager.StartTransaction())
                {
                    foreach (ObjectId objectId in flIds)
                    {
                        Autodesk.Civil.DatabaseServices.Entity curFLine = (Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead);
                        retVal.Add(curFLine);
                    }
                }
                return retVal;
            }
        }

    }
}

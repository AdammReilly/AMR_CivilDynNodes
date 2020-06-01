using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using Autodesk.Civil.DatabaseServices;
using Autodesk.Civil.ApplicationServices;
using System.Collections.Generic;
using Autodesk.Civil.DynamoNodes;

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(true)]
    public static class Sites
    {
        /// <summary>
        /// Gets all sites in the Civil Document.
        /// </summary>
        /// <returns>List of Sites.</returns>
        [IsVisibleInDynamoLibrary(true)]
        public static List<Site> GetSites()
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;

            ObjectIdCollection siteIds = civilDocument.GetSiteIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            List<Site> sites = new List<Site>();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objectId in siteIds)
                {
                    sites.Add((Site)trans.GetObject(objectId, OpenMode.ForRead));
                }
            }
            return sites;
        }
        [IsVisibleInDynamoLibrary(true)]
        public static Site GetSiteByName(string siteName)
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;
            Site site = null;
            ObjectIdCollection siteIds = civilDocument.GetSiteIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objectId in siteIds)
                {
                    site = (Site)trans.GetObject(objectId, OpenMode.ForRead);
                    if (site.Name != siteName)
                    { site = null; }
                }
            }
            return site;
        }
        [IsVisibleInDynamoLibrary(true)]
        public static Site GetSiteByIndex(int index)
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;
            Site site = null;
            ObjectIdCollection siteIds = civilDocument.GetSiteIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
               site = (Site)trans.GetObject(siteIds[index], OpenMode.ForRead);     
            }
            return site;
        }

        /// <summary>
        /// Gets all Parcels in the given Site.
        /// </summary>
        /// <param name="site">A Site object</param>
        /// <returns>List of Parcels</returns>
        [IsVisibleInDynamoLibrary(true)]
        public static List<Parcel> GetParcels(Site site)
        {
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            ObjectIdCollection parcelIds = site.GetParcelIds();
            List<Parcel> parcels = new List<Parcel>();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objectId in parcelIds)
                {
                    Parcel curParcel = new Parcel((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead));
                    parcels.Add(curParcel);
                }
            }
            return parcels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static Parcel GetParcelByName(Site site, string parcelName)
        {
            Parcel retParcel = null;
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            ObjectIdCollection parcelIds = site.GetParcelIds();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objectId in parcelIds)
                {
                    retParcel = new Parcel((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead));
                    if (retParcel.GetName != parcelName)
                    { retParcel = null; }
                    else { return retParcel; }
                }
            }
            return retParcel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static Parcel GetParcelByIndex(Site site, int index)
        {
            Parcel retParcel = null;
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            ObjectIdCollection parcelIds = site.GetParcelIds();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                    retParcel = new Parcel((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(parcelIds[index], OpenMode.ForRead));
            }
            return retParcel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<Autodesk.Civil.DatabaseServices.Entity> GetFeatureLines(Site site)
        {
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            ObjectIdCollection flIds = site.GetFeatureLineIds();
            List<Autodesk.Civil.DatabaseServices.Entity> retVal = new List<Autodesk.Civil.DatabaseServices.Entity>();
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

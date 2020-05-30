using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using Autodesk.Civil.DatabaseServices;
using Autodesk.Civil.ApplicationServices;
using System.Collections.Generic;


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
                    parcels.Add((Parcel)trans.GetObject(objectId, OpenMode.ForRead));
                }
            }
            return parcels;
        }
    }
}

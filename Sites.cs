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

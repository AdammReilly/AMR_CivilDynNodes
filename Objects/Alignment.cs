using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using CivilDynamoTools.Styles;

namespace CivilDynamoTools.Objects
{
    public class Alignment : Objects.CivilObject
    {
        internal Alignment(Autodesk.Civil.DatabaseServices.Entity entity, bool isDynamoOwned) : base(entity, isDynamoOwned)
        {
        }

        public static IList<Alignment> GetAlignments(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilDocument.GetCivilDocument(document.AcDocument.Database);
            ObjectIdCollection alignmentIds = civilDocument.GetAlignmentIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            List<Alignment> alignments = new List<Alignment>();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objectId in alignmentIds)
                {
                    alignments.Add(new Alignment((Autodesk.Civil.DatabaseServices.Alignment)trans.GetObject(objectId, OpenMode.ForRead), true));
                }
            }
            return alignments;
        }

        [IsVisibleInDynamoLibrary(false)]
        public new string ToString()
        {
            return "Alignment { " + base.Name + "}";
        }
    }
}

using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.Civil.DatabaseServices;
using System;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilDynamoTools
{
    public class Alignment : Autodesk.Civil.DynamoNodes.CivilObject
    {
        internal Autodesk.Civil.DatabaseServices.Entity _civilEntity;
        protected Alignment(Autodesk.Civil.DatabaseServices.Entity entity, bool isDynamoOwned) : base(entity, isDynamoOwned)
        {
            _civilEntity = entity;
            // isDynamoOwned came in as true
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

        //public string ObjectName
        //{ get => _civilEntity.Name; }

    }
}

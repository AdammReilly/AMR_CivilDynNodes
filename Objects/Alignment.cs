using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using CivilDynamoTools.Styles;
using Autodesk.Civil.DynamoNodes;
using Autodesk.AutoCAD.Internal.Calculator;

namespace CivilDynamoTools.Objects
{

    public class Alignment : Objects.CivilObject
    {

        protected Alignment(Autodesk.Civil.DatabaseServices.Entity entity, bool isDynamoOwned) : base(entity, isDynamoOwned)
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
                    alignments.Add(new Alignment((Autodesk.Civil.DatabaseServices.Alignment)trans.GetObject(objectId, OpenMode.ForRead), false));
                }
            }
            return alignments;
        }


        /// <summary>
        /// Gets an Alignment matching the given name.
        /// </summary>
        /// <param name="alignmentName">The Alignment name to search for.</param>
        /// <returns>The requested Alignment, or null.</returns>
        [Dynamo.Graph.Nodes.NodeCategory("Create")]
        [IsVisibleInDynamoLibrary(true)]
        public static Alignment ByName(string alignmentName)
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;
            Alignment alignment = null;
            ObjectIdCollection alignIds = civilDocument.GetAlignmentIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId objectId in alignIds)
                {
                    alignment = new Alignment((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(objectId, OpenMode.ForRead), false);
                    if (alignment.Name != alignmentName)
                    { alignment = null; }
                }
            }
            return alignment;
        }

        /// <summary>
        /// Gets an Alignment by the given index.
        /// </summary>
        /// <param name="index">The index number.</param>
        /// <returns>The Alignment, or null.</returns>
        [Dynamo.Graph.Nodes.NodeCategory("Create")]
        [IsVisibleInDynamoLibrary(true)]
        public static Alignment ByIndex(int index)
        {
            CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilApplication.ActiveDocument;
            Alignment alignment = null;
            ObjectIdCollection alignIds = civilDocument.GetAlignmentIds();
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                alignment = new Alignment((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(alignIds[index], OpenMode.ForRead), false);
            }
            return alignment;
        }

        [Dynamo.Graph.Nodes.NodeCategory("Query")]
        [IsVisibleInDynamoLibrary(true)]
        public List<Profile> Profiles()
        {
            List<Profile> retList = new List<Profile>();
            // get a civil Alignment of this object
            Autodesk.Civil.DatabaseServices.Alignment baseAlignment = (Autodesk.Civil.DatabaseServices.Alignment)_curCivilObject;
            //get the current document and database
            AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId profileId in baseAlignment.GetProfileIds())
                {
                    retList.Add(new Profile((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(profileId, OpenMode.ForRead), false));
                }
            }
            return retList;
        }


        [IsVisibleInDynamoLibrary(false)]
        public new string ToString()
        {
            return "Alignment { " + base.Name + "}";
        }
    }
}

using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using Autodesk.Civil.DatabaseServices;
using Autodesk.Civil.ApplicationServices;
using System.Collections.Generic;
using Autodesk.Civil.DynamoNodes;
using Dynamo.Graph.Nodes;
using Autodesk.AutoCAD.DynamoNodes;
using System.Windows;
using Autodesk.Civil.DatabaseServices.Styles;
using System.Collections;

namespace CivilDynamoTools.Objects
{
    [IsVisibleInDynamoLibrary(true)]
    public class Surface : CivilObject
    {
        #region variables
        internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected Surface(Autodesk.Civil.DatabaseServices.Entity curCivilEntity, bool isDynamoOwned) : base(curCivilEntity, isDynamoOwned)
        {
            _curCivilObject = curCivilEntity;
        }


        #endregion

        #region collections
        [IsVisibleInDynamoLibrary(true)]
        public static List<Surface> GetSurfaces(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<Surface> surfaces = new List<Surface>();
            Autodesk.AutoCAD.ApplicationServices.Document acDoc = document.AcDocument;
            Database db = acDoc.Database;
            CivilDocument civilDocument = CivilDocument.GetCivilDocument(db);
            ObjectIdCollection surfaceIds = civilDocument.GetSurfaceIds();
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                foreach (ObjectId surfaceId in surfaceIds)
                {
                    surfaces.Add(new Surface((Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(surfaceId, OpenMode.ForRead), true));
                }
            }
            return surfaces;
        }

        #endregion


        #region privateMethods


        #endregion
    }
}

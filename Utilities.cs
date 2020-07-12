using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(false)]
    public static class Utilities
    {
        [IsVisibleInDynamoLibrary(false)]
        public static ObjectId GetLayerByName(Database db, string layerName)
        {
            ObjectId retId = ObjectId.Null;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                LayerTable lyrTable = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
                if (lyrTable.Has(layerName) == true)
                {
                    retId = lyrTable[layerName];
                }
                trans.Commit();
            }
            return retId;
        }
    }
}

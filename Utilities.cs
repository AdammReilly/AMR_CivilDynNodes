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
                else
                {
                    LayerTableRecord newLayer = new LayerTableRecord();
                    LayerTableRecord defLayer = (LayerTableRecord)lyrTable["0"].GetObject(OpenMode.ForRead);
                    newLayer.Name = layerName;
                    newLayer.Color = defLayer.Color;
                    newLayer.LineWeight = defLayer.LineWeight;
                    newLayer.LinetypeObjectId = defLayer.LinetypeObjectId;
                    lyrTable.UpgradeOpen();
                    retId = lyrTable.Add(newLayer);
                    trans.AddNewlyCreatedDBObject(newLayer, true);
                }
                trans.Commit();
            }
            return retId;
        }
    }
}

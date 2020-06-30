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

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(true)]
    public class Profile : CivilObject
    {
        #region variables
        internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(true)]
        public Profile(Autodesk.Civil.DatabaseServices.Entity curCivilEntity, bool isDynamoOwned) : base(curCivilEntity, isDynamoOwned)
        {
            _curCivilObject = curCivilEntity;
        }

        public static Profile ByAlignmentAndSurface(Autodesk.AutoCAD.DynamoNodes.Document document, Alignment parentAlignment, Autodesk.Civil.DynamoNodes.Surface parentSurface, string name, string layerName, string styleName, string labelSetName)
        {
            Autodesk.Civil.DatabaseServices.Profile newProfile = null;
            AcadApp.Document curDoc = document.AcDocument;
            Database db = curDoc.Database;
            Autodesk.Civil.DatabaseServices.Surface civilSurface = (Autodesk.Civil.DatabaseServices.Surface)parentSurface.InternalDBObject;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                // need to assign these values based on the string inputs
                LayerTable lyrTable = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
                ObjectId layerId; // id of layer to add profile to
                ObjectId styleId; // id of style to assign the profile
                ObjectId labelSetId; // id of label set to assign
                ObjectId newProfileId = Autodesk.Civil.DatabaseServices.Profile.CreateFromSurface(name, parentAlignment.InternalObjectId, parentSurface.InternalObjectId, layerId, styleId, labelSetId);
                newProfile = (Autodesk.Civil.DatabaseServices.Profile)trans.GetObject(newProfileId, OpenMode.ForRead);
            }
            if (newProfile == null) { return null; }
            else { return new Profile(newProfile, true); }
        }

        #endregion

    }
}

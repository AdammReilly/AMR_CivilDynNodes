using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using CivilDynamoTools.LabelStyles.Profiles;
using Autodesk.Civil.DatabaseServices;
using Autodesk.AutoCAD.DynamoNodes;
using System.Windows;
using CivilDynamoTools.Styles;
using Autodesk.DesignScript.Geometry;
using Autodesk.Civil.ApplicationServices;

namespace CivilDynamoTools.Objects
{
    [IsVisibleInDynamoLibrary(true)]
    public class Profile : CivilObject
    {
        #region variables
        //internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        internal Profile(Autodesk.Civil.DatabaseServices.Entity curCivilEntity, bool isDynamoOwned) : base(curCivilEntity, isDynamoOwned)
        {
           // _curCivilObject = curCivilEntity;
        }

        public static Profile ByAlignmentAndSurface(Autodesk.AutoCAD.DynamoNodes.Document document, Alignment parentAlignment, Surface parentSurface, string name, Autodesk.AutoCAD.DynamoNodes.Layer layer, Styles.ProfileStyle profileStyle, ProfileLabelSet profileLabelSet)
        {
            Autodesk.Civil.DatabaseServices.Profile newProfile = null;
            AcadApp.Document curDoc = document.AcDocument;
            Database db = curDoc.Database;
            Autodesk.Civil.DatabaseServices.Surface civilSurface = (Autodesk.Civil.DatabaseServices.Surface)parentSurface.InternalDBObject;
            using (Transaction trans = db.TransactionManager.StartTransaction())
            {
                string oName = name;
                // need to assign these values based on the string inputs
                LayerTable lyrTable = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
                ObjectId layerId = Utilities.GetLayerByName(db, layer.Name); // id of layer to add profile to
                ObjectId styleId = profileStyle.InternalObjectId; // id of style to assign the profile
                ObjectId labelSetId = profileLabelSet.InternalObjectId; // id of label set to assign
                CivilDocument civilDocument = Autodesk.Civil.ApplicationServices.CivilDocument.GetCivilDocument(document.AcDocument.Database);
                ObjectIdCollection alignIds = civilDocument.GetAlignmentIds();
                // make sure the name doesn't already exist for any profile
                bool exists = false;
                int copy = 1;
                foreach (ObjectId aId in alignIds)
                {
                    Autodesk.Civil.DatabaseServices.Alignment civilAlignment = (Autodesk.Civil.DatabaseServices.Alignment)trans.GetObject(aId, OpenMode.ForRead);
                    ObjectIdCollection profIds = civilAlignment.GetProfileIds();
                    foreach (ObjectId pId in profIds)
                    {
                        Autodesk.Civil.DatabaseServices.Profile civilProfile = (Autodesk.Civil.DatabaseServices.Profile)trans.GetObject(pId, OpenMode.ForRead);
                        if (civilProfile.Name == name)
                        {
                            name = oName + " - " + copy;
                            copy += 1;
                        }
                    }
                }
                ObjectId newProfileId = Autodesk.Civil.DatabaseServices.Profile.CreateFromSurface(name, parentAlignment.InternalObjectId, parentSurface.InternalObjectId, layerId, styleId, labelSetId);
                newProfile = (Autodesk.Civil.DatabaseServices.Profile)trans.GetObject(newProfileId, OpenMode.ForRead);
                trans.Commit();
            }
            if (newProfile == null) { return null; }
            else { return new Profile(newProfile, true); }
        }

        // Create from a feature line. Will require feature line object (still missing)
        //Autodesk.Civil.DatabaseServices.Profile.CreateFromFeatureLine(profileName, corridorFeatureLine, alignmentId, layerId, styleId, labelSetId);
        //public static Profile ByFeatureLine(Autodesk.AutoCAD.DynamoNodes.Document document, string profileName, FeatureLine corridorFeatureLine, Alignment alignment, Layer layer, ProfileStyle style, ProfileLabelSet profileLabelSet)
        //{
        //    Autodesk.Civil.DatabaseServices.Profile newProfile = null;
        //    AcadApp.Document curDoc = document.AcDocument;
        //    Database db = curDoc.Database;
        //    Autodesk.Civil.DatabaseServices.Surface civilSurface = (Autodesk.Civil.DatabaseServices.Surface)parentSurface.InternalDBObject;
        //    using (Transaction trans = db.TransactionManager.StartTransaction())
        //    {
        //        // need to assign these values based on the string inputs
        //        LayerTable lyrTable = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
        //        ObjectId layerId = Utilities.GetLayerByName(db, layer.Name); // id of layer to add profile to
        //        ObjectId styleId = profileStyle.InternalObjectId; // id of style to assign the profile
        //        ObjectId labelSetId = profileLabelSet.InternalObjectId; // id of label set to assign
        //        ObjectId newProfileId = Autodesk.Civil.DatabaseServices.Profile.CreateFromSurface(name, parentAlignment.InternalObjectId, parentSurface.InternalObjectId, layerId, styleId, labelSetId);
        //        newProfile = (Autodesk.Civil.DatabaseServices.Profile)trans.GetObject(newProfileId, OpenMode.ForRead);
        //        trans.Commit();
        //    }
        //    if (newProfile == null) { return null; }
        //    else { return new Profile(newProfile, true); }

        //}

        //Autodesk.Civil.DatabaseServices.Profile.CreateByLayout(profileName, alignmentId, layerId, styleId, labelSetId);
        //public static Profile ByLayout(Autodesk.AutoCAD.DynamoNodes.Document document, string profileName, Alignment alignment, Layer layer, ProfileStyle profileStyle, ProfileLabelSet profileLabelSet)
        //{
        //    Autodesk.Civil.DatabaseServices.Profile newProfile = null;
        //    AcadApp.Document curDoc = document.AcDocument;
        //    Database db = curDoc.Database;
        //    Autodesk.Civil.DatabaseServices.Surface civilSurface = (Autodesk.Civil.DatabaseServices.Surface)parentSurface.InternalDBObject;
        //    using (Transaction trans = db.TransactionManager.StartTransaction())
        //    {
        //        // need to assign these values based on the string inputs
        //        LayerTable lyrTable = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
        //        ObjectId layerId = Utilities.GetLayerByName(db, layer.Name); // id of layer to add profile to
        //        ObjectId styleId = profileStyle.InternalObjectId; // id of style to assign the profile
        //        ObjectId labelSetId = profileLabelSet.InternalObjectId; // id of label set to assign
        //        ObjectId newProfileId = Autodesk.Civil.DatabaseServices.Profile.CreateFromSurface(name, parentAlignment.InternalObjectId, parentSurface.InternalObjectId, layerId, styleId, labelSetId);
        //        newProfile = (Autodesk.Civil.DatabaseServices.Profile)trans.GetObject(newProfileId, OpenMode.ForRead);
        //        trans.Commit();
        //    }
        //    if (newProfile == null) { return null; }
        //    else { return new Profile(newProfile, true); }
        //}

        //Autodesk.Civil.DatabaseServices.Profile.CreateFromGeCurve(geCurve);
        //public static Profile ByGeometry(Autodesk.AutoCAD.DynamoNodes.Document document, Alignment parentAlignment, Geometry geometry)
        //{
        //    Autodesk.Civil.DatabaseServices.Profile newProfile = null;
        //    AcadApp.Document curDoc = document.AcDocument;
        //    Database db = curDoc.Database;
        //    Autodesk.Civil.DatabaseServices.Surface civilSurface = (Autodesk.Civil.DatabaseServices.Surface)parentSurface.InternalDBObject;
        //    using (Transaction trans = db.TransactionManager.StartTransaction())
        //    {
        //        // need to assign these values based on the string inputs
        //        LayerTable lyrTable = (LayerTable)trans.GetObject(db.LayerTableId, OpenMode.ForRead);
        //        ObjectId layerId = Utilities.GetLayerByName(db, layer.Name); // id of layer to add profile to
        //        ObjectId styleId = profileStyle.InternalObjectId; // id of style to assign the profile
        //        ObjectId labelSetId = profileLabelSet.InternalObjectId; // id of label set to assign
        //        ObjectId newProfileId = Autodesk.Civil.DatabaseServices.Profile.CreateFromSurface(name, parentAlignment.InternalObjectId, parentSurface.InternalObjectId, layerId, styleId, labelSetId);
        //        newProfile = (Autodesk.Civil.DatabaseServices.Profile)trans.GetObject(newProfileId, OpenMode.ForRead);
        //        trans.Commit();
        //    }
        //    if (newProfile == null) { return null; }
        //    else { return new Profile(newProfile, true); }
        //}

        #endregion

        #region privateMethods


        #endregion

        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return "Profile { " + Name + " }";
        }

    }
}

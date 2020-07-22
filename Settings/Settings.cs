using System;
using System.Collections.Generic;
using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using CivilDynamoTools.LabelStyles.Profiles;
using Autodesk.Civil.DatabaseServices;
using Autodesk.AutoCAD.DynamoNodes;
using System.Windows;
using CivilDynamoTools.Styles;
using Autodesk.DesignScript.Geometry;
using AecXBase;
using Autodesk.AutoCAD.Geometry;
using Autodesk.Civil.ApplicationServices;
using Autodesk.Civil.Settings;

namespace CivilDynamoTools.Settings
{
    [IsVisibleInDynamoLibrary(false)]
    public class Settings
    {

        [IsVisibleInDynamoLibrary(false)]
        public static string GetLayerName(Autodesk.AutoCAD.DynamoNodes.Document document, SettingsObjectLayerType objectType, string objectName = "")
        {
            CivilDocument civilDoc = Autodesk.Civil.ApplicationServices.CivilDocument.GetCivilDocument(document.AcDocument.Database);
            SettingsDrawing settingsDrawing = civilDoc.Settings.DrawingSettings;
            SettingsObjectLayers sOL = settingsDrawing.ObjectLayerSettings;
            SettingsObjectLayer sOLayer = sOL.GetObjectLayerSetting(objectType);
            string layerName = "";
            string layerMod = sOLayer.ModifierValue;
            if (sOLayer.ModifierValue.Contains("*"))
            {
                layerMod = sOLayer.ModifierValue.Replace("*", objectName);
            }
            switch (sOLayer.Modifier)
            {
                case (ObjectLayerModifierType.Prefix):
                    {
                        layerName = layerMod + sOLayer.LayerName;
                        break;
                    }
                case (ObjectLayerModifierType.Suffix):
                    {
                        layerName = sOLayer.LayerName + layerMod;
                        break;
                    }
                default:
                    {
                        layerName = sOLayer.LayerName;
                        break;
                    }
            }
            return layerName;
        }

    }
}

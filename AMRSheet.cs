using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using System;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using ACSMCOMPONENTS24Lib;
using Autodesk.Civil.DatabaseServices;
using System.Collections.Generic;

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(false)]
    public class AMRSheet
    {
        private AcSmSheet _currentSheet;

        [IsVisibleInDynamoLibrary(false)]
        public AMRSheet(AcSmSheet sheet)
        {
            _currentSheet = sheet;
        }

        [IsVisibleInDynamoLibrary(false)]
        public string Name()
        {
            return _currentSheet.GetName();
        }
    }
}

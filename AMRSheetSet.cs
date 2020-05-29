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
    public class AMRSheetSet
    {
        private AcSmSheetSet _currentSheetSet;
        private AcSmDatabase _currentDatabase;

        [IsVisibleInDynamoLibrary(false)]
        public AMRSheetSet(AcSmDatabase sheetSetDbFromMgr)
        {
            _currentDatabase = sheetSetDbFromMgr;
            _currentSheetSet = _currentDatabase.GetSheetSet();
        }

        [IsVisibleInDynamoLibrary(false)]
        public AMRSheetSet()
        {
            _currentSheetSet = null;
            _currentDatabase = null;
        }

        [IsVisibleInDynamoLibrary(false)]
        public string Name()
        {
            return _currentSheetSet.GetName();
        }
        [IsVisibleInDynamoLibrary(false)]
        public string GetDesc()
        {
            return _currentSheetSet.GetDesc();
        }
        [IsVisibleInDynamoLibrary(false)]
        public string GetFileName()
        {
            return _currentDatabase.GetFileName();
        }

        [IsVisibleInDynamoLibrary(false)]
        public IList<AMRSheet> GetSheets()
        {
            IAcSmEnumComponent sheetEnumerator = _currentSheetSet.GetSheetEnumerator();
            sheetEnumerator.Reset();
            IList<AMRSheet> sheets = new List<AMRSheet>();
            IAcSmPersist curItem = sheetEnumerator.Next();
            while (curItem != null)
            {
                if (curItem is AcSmSheet)
                {
                    AcSmSheet comp = (AcSmSheet)curItem;
                    sheets.Add(new AMRSheet(comp));
                }
                curItem = sheetEnumerator.Next();
            }
            curItem = null;
            sheetEnumerator = null;
            return sheets;

        }

    }
}

using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using System;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using ACSMCOMPONENTS24Lib;
using System.Collections.Generic;

namespace CivilDynamoTools
{
    public static class SheetSetMgr
    {
		[IsVisibleInDynamoLibrary(true)]
		public static Object GetSheetSetMgr()
		{
			//get an instance of the sheet set manager object
			IAcSmSheetSetMgr ssMgr = new AcSmSheetSetMgr();
			return ssMgr;
		}

		

		
		[IsVisibleInDynamoLibrary(true)]
		public static AMRSheetSet OpenSheetSet(string dstPath, bool failIfOpen)
		{
			IAcSmSheetSetMgr ssMgr = new AcSmSheetSetMgr();
			if (System.IO.File.Exists(dstPath))
			{
				AMRSheetSet curDatabase = new AMRSheetSet(ssMgr.OpenDatabase(dstPath, failIfOpen));
				return curDatabase;
			}
			else
			{
				return new AMRSheetSet();
			}
		}

		[IsVisibleInDynamoLibrary(true)]
		public static string SheetSetName(AMRSheetSet sheetSet)
		{
			return sheetSet.Name();
		}

		[IsVisibleInDynamoLibrary(true)]
		public static string SheetSetDesc(AMRSheetSet sheetSet)
		{
			return sheetSet.GetDesc();
		}

		[IsVisibleInDynamoLibrary(true)]
		public static string FileName(AMRSheetSet sheetSet)
		{
			return sheetSet.GetFileName();
		}

		[IsVisibleInDynamoLibrary(true)]
		public static IList<AMRSheet> GetSheets(AMRSheetSet sheetSet)
		{
			return sheetSet.GetSheets();
		}

		[IsVisibleInDynamoLibrary(true)]
		public static string GetSheetName(AMRSheet sheet)
		{
			return sheet.Name();
		}
	}
}

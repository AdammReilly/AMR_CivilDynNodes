using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using System;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;

namespace CivilDynamoTools
{
	public static class CogoPoints
	{

		/// <summary>
		/// Applies the DescriptionKeys to the CogoPoint.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint ApplyDescriptionKeys(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ApplyDescriptionKeys();
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Renumbers the PointNumber to a new value.
		/// </summary>
		/// <param name="cogoPoint">The point to be renumbered.</param>
		/// <param name="newNumber">The number to assign the point.</param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint Renumber(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, int newNumber)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.Renumber((uint)newNumber);
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Resets the CogoPoint label object to its defaults.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint ResetLabel(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ResetLabel();
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Resets the location of the CogoPoint label object to its defaults.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint ResetLabelLocation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ResetLabelLocation();
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Resets the rotation status of the CogoPoint label object to its defaults.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint ResetLabelRotation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ResetLabelRotation();
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the convergence value of a point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double Convergence(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			double retVal = 0;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.Convergence;
					// save back 
					trans.Abort();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the description format string for the point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static string GetDescriptionFormat(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			string retVal = "";
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.DescriptionFormat;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the description format string for the point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetDescriptionFormat(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, string descriptionFormat)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.DescriptionFormat = descriptionFormat;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets a local easting value for the point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetEasting(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.Easting;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets a local easting value for the point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetEasting(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double easting)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.Easting = easting;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets an elevation for the CogoPoint.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetElevation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.Elevation;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets an elevation for the CogoPoint.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetElevation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double elevation)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.Elevation = elevation;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets an elevation for the CogoPoint. This property is applied the override settings in the point's primary PointGroup.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double ElevationOverride(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.ElevationOverride;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets an expanded description determined by a description key match.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static string FullDescription(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			string retVal = "";
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.FullDescription;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets an expanded description determined by a description key match. This property is applied to the override settings in the point's primary PointGroup.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static string FullDescriptionOverride(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			string retVal = "";
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.FullDescriptionOverride;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the calculated grid easting value for the point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetGridEasting(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.GridEasting;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the calculated grid easting value for the point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetGridEasting(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double gridEasting)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.GridEasting = gridEasting;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the calculated grid northing value for the point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetGridNorthing(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.GridNorthing;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the calculated grid northing value for the point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint MyDynamoMethod(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double gridNorthing)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.GridNorthing = gridNorthing;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets whether the CogoPoint has been checked out.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsCheckedOut(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = false;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsCheckedOut;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the dragged state of the CogoPoint label.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsLabelDragged(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = false;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsLabelDragged;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the pinned state of the CogoPoint label.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsLabelPinned(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = false;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsLabelPinned;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the pinned state of the CogoPoint label.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetLabelPin(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, bool labelPin)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.IsLabelPinned = labelPin;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets whether the label of the CogoPoint is visible.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsLabelVisible(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = true;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsLabelVisible;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets whether the label of the CogoPoint is visible.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetLabelVisible(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, bool labelVisibility)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.IsLabelVisible = labelVisibility;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets whether the CogoPoint is locked.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsLocked(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = false;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsLocked;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets whether the CogoPoint is locked.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetLocked(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, bool lockState)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.IsLocked = lockState;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Indicates whether this CogoPoint is movable.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsMovable(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = true;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsMovable;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets whether the CogoPoint is a project point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsProjectPoint(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = false;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsProjectPoint;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Indicates whether this Cogo Point is a Survey Point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool IsSurveyPoint(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = false;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.IsSurveyPoint;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the label location.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.DesignScript.Geometry.Point GetLabelLocation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			Autodesk.DesignScript.Geometry.Point labelPoint = Autodesk.DesignScript.Geometry.Point.ByCoordinates(0, 0, 0);
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					labelPoint = Autodesk.DesignScript.Geometry.Point.ByCoordinates(civilCogoPoint.LabelLocation.X, civilCogoPoint.LabelLocation.Y, civilCogoPoint.LabelLocation.Z);
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return labelPoint;
		}

		/// <summary>
		/// Sets the label location.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetLabelLocation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, Autodesk.DesignScript.Geometry.Point labelPoint)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					Point3d pt = new Point3d(labelPoint.X, labelPoint.Y, labelPoint.Z);
					civilCogoPoint.LabelLocation = pt;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the rotation value for the point label.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetLabelRotation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.LabelRotation;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the rotation value for the point label.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetLabelRotation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double labelRotation)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.LabelRotation = labelRotation;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the latitude for a point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetLatitude(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.Latitude;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the latitude for a point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetLatitude(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double latitude)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.Latitude = latitude;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the point location.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.DesignScript.Geometry.Point GetLocation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			Autodesk.DesignScript.Geometry.Point retVal = Autodesk.DesignScript.Geometry.Point.ByCoordinates(0, 0, 0); ;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = Autodesk.DesignScript.Geometry.Point.ByCoordinates(civilCogoPoint.LabelLocation.X, civilCogoPoint.LabelLocation.Y, civilCogoPoint.LabelLocation.Z);
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the longitude for a point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetLongitude(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.Longitude;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the longitude for a point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetLongitude(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double longitude)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.Longitude = longitude;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the rotation value for the point symbol.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetMarkerRotation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.MarkerRotation;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the rotation value for the point symbol.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetMarkerRotation(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double rotation)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.MarkerRotation = rotation;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets a local northing value for the point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetNorthing(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.Northing;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets a local northing value for the point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetNorthing(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double northing)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.Northing = northing;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the name of the Cogo Point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static string GetPointName(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			string retVal = "";
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.PointName;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the name of the Cogo Point.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetPointName(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, string name)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.PointName = name;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the point number.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static uint GetPointNumber(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			uint retVal = 0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.PointNumber;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the point number.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetPointNumber(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, uint number)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.PointNumber = number;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Specifies the version number of the local copy of the point in the drawing. Applies only to project points.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static int ProjectVersion(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			int retVal = 0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.ProjectVersion;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets an unexpanded description for the point, which could be the description entered by the surveyor in the field.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static string GetRawDescription(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			string retVal = "";
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.RawDescription;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets an unexpanded description for the point, which could be the description entered by the surveyor in the field.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetRawDescription(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, string rawDescription)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.RawDescription = rawDescription;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets an unexpanded description for the point, which could be the description entered by the surveyor in the field. This property is applied the override settings in its primary PointGroup.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static string GetRawDescriptionOverride(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			string retVal = "";
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.RawDescriptionOverride;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the scale factor value of a point, relative to the coordinate zone and the transformation settings specified for the drawing.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetScale(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.Scale;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Gets the X-Y scale factor for the point symbol.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetScaleXY(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.ScaleXY;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the X-Y scale factor for the point symbol.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetScaleXY(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double scaleXY)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ScaleXY = scaleXY;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets the Z scale factor for the point symbol.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static double GetScaleZ(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			double retVal = 0.0;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.ScaleZ;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets the Z scale factor for the point symbol.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetScaleZ(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double scaleZ)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ScaleZ = scaleZ;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Gets whether the point should show tooltips in the UI.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static bool GetShowToolTip(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint)
		{
			bool retVal = true;
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					retVal = civilCogoPoint.ShowToolTip;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return retVal;
		}

		/// <summary>
		/// Sets whether the point should show tooltips in the UI.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint SetShowToolTip(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, bool showToolTip)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ShowToolTip = showToolTip;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}

		/// <summary>
		/// Set the XY and Z scale at the same time.
		/// </summary>
		/// <param name="cogoPoint"></param>
		/// <param name="scaleXY">X-Y scale factor</param>
		/// <param name="scaleZ">Z scale factor</param>
		/// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
		public static Autodesk.Civil.DynamoNodes.CogoPoint Scale(Autodesk.Civil.DynamoNodes.CogoPoint cogoPoint, double scaleXY = 1, double scaleZ = 1)
		{
			//get the current document and database
			AcadApp.Document doc = AcadApp.Application.DocumentManager.MdiActiveDocument;
			Database db = doc.Database;
			try
			{
				// setup a transaction
				using (Transaction trans = db.TransactionManager.StartTransaction())
				{
					// convert the dynamo object to a civil 3d object
					Autodesk.Civil.DatabaseServices.CogoPoint civilCogoPoint = (Autodesk.Civil.DatabaseServices.CogoPoint)trans.GetObject(cogoPoint.InternalObjectId, OpenMode.ForWrite);
					// your code here
					civilCogoPoint.ScaleXY = scaleXY;
					civilCogoPoint.ScaleZ = scaleZ;
					// save back 
					trans.Commit();
				}
			}
			catch (System.Exception ex)
			{
				Console.WriteLine("Error: " + ex.Message);
			}
			// return the updated dynamo object
			return cogoPoint;
		}
	}
}

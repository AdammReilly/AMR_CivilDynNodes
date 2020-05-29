using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using System;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.Civil.DatabaseServices;

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(true)]
    public static class Parcels
    {
        /// <summary>
        /// Method to get the 2D Polyline represented by the Parcel
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
		[IsVisibleInDynamoLibrary(true)]
        public static Autodesk.AutoCAD.DatabaseServices.Polyline BaseCurve2d(Parcel parcel)
        {

            //This will fail to be set if there are any 3d segments
            Autodesk.AutoCAD.DatabaseServices.Polyline poly = parcel.BaseCurve as Autodesk.AutoCAD.DatabaseServices.Polyline;
            if (poly != null)
                return poly;

            //3d segments found, loop through and create 2d vertices for new polyline
            poly = new Autodesk.AutoCAD.DatabaseServices.Polyline();
            object comparcel = parcel.AcadObject;
            object[] args = new object[1];
            args[0] = 0;
            object loop = (object)comparcel.GetType().InvokeMember("ParcelLoops", System.Reflection.BindingFlags.GetProperty, null, comparcel, args);

            int count = (int)loop.GetType().InvokeMember("Count", System.Reflection.BindingFlags.GetProperty, null, loop, null);
            for (int i = 0; i < count; i++)
            {
                args[0] = i;
                object segelement = (object)loop.GetType().InvokeMember("Item", System.Reflection.BindingFlags.GetProperty, null, loop, args);
                double x = (double)segelement.GetType().InvokeMember("StartX", System.Reflection.BindingFlags.GetProperty, null, segelement, null);
                double y = (double)segelement.GetType().InvokeMember("StartY", System.Reflection.BindingFlags.GetProperty, null, segelement, null);
                double bulge = 0;
                try
                {
                    bulge = (double)segelement.GetType().InvokeMember("Bulge", System.Reflection.BindingFlags.GetProperty, null, segelement, null);
                }
                catch { }
                poly.AddVertexAt(i, new Point2d(x, y), bulge, 0, 0);
            }
            poly.Closed = true;
            return poly;
                       

        }
    }
}

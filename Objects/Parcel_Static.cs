using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using System;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.Civil.DatabaseServices;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace CivilDynamoTools.Objects
{
    [IsVisibleInDynamoLibrary(true)]
    public partial class Parcel
    {
        /// <summary>
        /// Method to get the outer 2D Polyline represented by the Parcel
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
		[IsVisibleInDynamoLibrary(false)] // make this true in order to test this function
        public static CivilDynamoTools.Objects.AutoCAD.Polyline BaseCurve2d(Parcel parcel)
        {
            //This will fail to be set if there are any 3d segments
            Autodesk.AutoCAD.DatabaseServices.Polyline poly = parcel.BaseCurve as Autodesk.AutoCAD.DatabaseServices.Polyline;
            if (poly != null)
            {
               // return poly;
                return new CivilDynamoTools.Objects.AutoCAD.Polyline(poly);
            }

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
            //return poly;
            return new CivilDynamoTools.Objects.AutoCAD.Polyline(poly);
        }

        [IsVisibleInDynamoLibrary(false)]
        public static IList<Autodesk.DesignScript.Geometry.PolyCurve> GetPolyCurves(Parcel parcel)
        {
            IList<Autodesk.DesignScript.Geometry.PolyCurve> retPolys = new List<Autodesk.DesignScript.Geometry.PolyCurve>();
            dynamic oParcel = parcel.AcadObject;
            dynamic loops = oParcel.ParcelLoops;
            foreach (dynamic loop in loops)
            {
                Autodesk.AutoCAD.DatabaseServices.Polyline poly = new Autodesk.AutoCAD.DatabaseServices.Polyline();
                int count = loop.Count;
                for (int i = 0; i < count; i++)
                {
                    dynamic segElement = loop.Item(i);
                    double x = segElement.StartX;
                    double y = segElement.StartY;
                    double bulge = 0;
                    try
                    {
                        bulge = (double)segElement.Bulge;
                    }
                    catch { }
                    poly.AddVertexAt(i, new Point2d(x, y), bulge, 0, 0);
                }
                poly.Closed = true;
                retPolys.Add(ConvertPolylineToPolyCurve(poly));
            }
            return retPolys;
        }


        /// <summary>
        /// Gets the outside area of the parcel
        /// </summary>
        /// <param name="parcel">CivilDynamoTools.Parcel object</param>
        /// <returns>PolyCurve representing the outer limits of the parcel.</returns>
        [IsVisibleInDynamoLibrary(false)]
        public static Autodesk.DesignScript.Geometry.PolyCurve PolyCurveByParcel(Parcel parcel)
        {
            Autodesk.DesignScript.Geometry.PolyCurve retVal = null;
            if (parcel != null)
            {
                Autodesk.AutoCAD.DatabaseServices.Polyline poly = parcel.BaseCurve as Autodesk.AutoCAD.DatabaseServices.Polyline;
                retVal = ConvertPolylineToPolyCurve(poly);
            }
            return retVal;
        }

        /// <summary>
        /// Converts an AutoCAD Polyline to a Dynamo PolyCurve
        /// </summary>
        /// <param name="polyline">AutoCAD Polyline</param>
        /// <returns>Dynamo PolyCurve object</returns>
        [IsVisibleInDynamoLibrary(false)]
        public static Autodesk.DesignScript.Geometry.PolyCurve ConvertPolylineToPolyCurve(Autodesk.AutoCAD.DatabaseServices.Polyline polyline)
        {
            Autodesk.DesignScript.Geometry.PolyCurve retVal = null;
            if (polyline != null)
            {
                // extract each segment
                Autodesk.DesignScript.Geometry.Curve[] curves; // = new Autodesk.DesignScript.Geometry.Curve[polyline.NumberOfVertices];
                if (polyline.Closed) { curves = new Autodesk.DesignScript.Geometry.Curve[polyline.NumberOfVertices]; }
                else { curves = new Autodesk.DesignScript.Geometry.Curve[polyline.NumberOfVertices -1]; }
                // convert segment into Dynamo curve or line
                int curIndex = 0;
                while (curIndex <= polyline.NumberOfVertices)
                {
                    if (polyline.GetSegmentType(curIndex) == SegmentType.Arc)
                    {
                        Autodesk.DesignScript.Geometry.Arc curCurve;
                        Autodesk.DesignScript.Geometry.Point centerPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetArcSegment2dAt(curIndex).Center.X,
                            polyline.GetArcSegment2dAt(curIndex).Center.Y,
                            0.0);
                        Autodesk.DesignScript.Geometry.Point startPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetArcSegment2dAt(curIndex).StartPoint.X,
                            polyline.GetArcSegment2dAt(curIndex).StartPoint.Y,
                            0.0);
                        Autodesk.DesignScript.Geometry.Point endPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetArcSegment2dAt(curIndex).EndPoint.X,
                            polyline.GetArcSegment2dAt(curIndex).EndPoint.Y,
                            0.0);
                        curCurve = Autodesk.DesignScript.Geometry.Arc.ByCenterPointStartPointEndPoint(centerPt, endPt, startPt);
                        curves.SetValue(curCurve, curIndex);
                    }
                    else if (polyline.GetSegmentType(curIndex) == SegmentType.Line)
                    {
                        Autodesk.DesignScript.Geometry.Line curLine;
                        Autodesk.DesignScript.Geometry.Point startPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetLineSegment2dAt(curIndex).StartPoint.X,
                            polyline.GetLineSegment2dAt(curIndex).StartPoint.Y,
                            0.0);
                        Autodesk.DesignScript.Geometry.Point endPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetLineSegment2dAt(curIndex).EndPoint.X,
                            polyline.GetLineSegment2dAt(curIndex).EndPoint.Y,
                            0.0);
                        curLine = Autodesk.DesignScript.Geometry.Line.ByStartPointEndPoint(startPt, endPt);
                        curves.SetValue(curLine, curIndex);
                    }
                    curIndex = curIndex + 1;
                }
                retVal = Autodesk.DesignScript.Geometry.PolyCurve.ByJoinedCurves(curves);
            }
            return retVal;
        }
       
        [IsVisibleInDynamoLibrary(true)]
        public static Autodesk.DesignScript.Geometry.PolyCurve ConvertDynamoPolylineToPolyCurve(Autodesk.AutoCAD.DynamoNodes.Polyline dynamoPolyline)
        {
            Autodesk.AutoCAD.DatabaseServices.Polyline polyline = (Autodesk.AutoCAD.DatabaseServices.Polyline)dynamoPolyline.InternalDBObject;
            Autodesk.DesignScript.Geometry.PolyCurve retVal = null;
            if (polyline != null)
            {
                // extract each segment
                Autodesk.DesignScript.Geometry.Curve[] curves; // = new Autodesk.DesignScript.Geometry.Curve[polyline.NumberOfVertices];
                if (polyline.Closed) { curves = new Autodesk.DesignScript.Geometry.Curve[polyline.NumberOfVertices]; }
                else { curves = new Autodesk.DesignScript.Geometry.Curve[polyline.NumberOfVertices - 1]; }
                // convert segment into Dynamo curve or line
                int curIndex = 0;
                while (curIndex <= polyline.NumberOfVertices)
                {
                    if (polyline.GetSegmentType(curIndex) == SegmentType.Arc)
                    {
                        Autodesk.DesignScript.Geometry.Arc curCurve;
                        Autodesk.DesignScript.Geometry.Point centerPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetArcSegment2dAt(curIndex).Center.X,
                            polyline.GetArcSegment2dAt(curIndex).Center.Y,
                            0.0);
                        Autodesk.DesignScript.Geometry.Point startPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetArcSegment2dAt(curIndex).StartPoint.X,
                            polyline.GetArcSegment2dAt(curIndex).StartPoint.Y,
                            0.0);
                        Autodesk.DesignScript.Geometry.Point endPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetArcSegment2dAt(curIndex).EndPoint.X,
                            polyline.GetArcSegment2dAt(curIndex).EndPoint.Y,
                            0.0);
                        curCurve = Autodesk.DesignScript.Geometry.Arc.ByCenterPointStartPointEndPoint(centerPt, endPt, startPt);
                        curves.SetValue(curCurve, curIndex);
                    }
                    else if (polyline.GetSegmentType(curIndex) == SegmentType.Line)
                    {
                        Autodesk.DesignScript.Geometry.Line curLine;
                        Autodesk.DesignScript.Geometry.Point startPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetLineSegment2dAt(curIndex).StartPoint.X,
                            polyline.GetLineSegment2dAt(curIndex).StartPoint.Y,
                            0.0);
                        Autodesk.DesignScript.Geometry.Point endPt = Autodesk.DesignScript.Geometry.Point.ByCoordinates(
                            polyline.GetLineSegment2dAt(curIndex).EndPoint.X,
                            polyline.GetLineSegment2dAt(curIndex).EndPoint.Y,
                            0.0);
                        curLine = Autodesk.DesignScript.Geometry.Line.ByStartPointEndPoint(startPt, endPt);
                        curves.SetValue(curLine, curIndex);
                    }
                    curIndex = curIndex + 1;
                }
                retVal = Autodesk.DesignScript.Geometry.PolyCurve.ByJoinedCurves(curves);
            }
            return retVal;
        }

        // currently only works for non-curve segments
        [IsVisibleInDynamoLibrary(false)]
        public static Autodesk.AutoCAD.DatabaseServices.Polyline ConvertPolyCurveToPolyline(Autodesk.DesignScript.Geometry.PolyCurve polyCurve)
        {
            Autodesk.AutoCAD.DatabaseServices.Polyline retVal = new Autodesk.AutoCAD.DatabaseServices.Polyline();
            if (polyCurve != null)
            {
                // extract each segment
                Autodesk.DesignScript.Geometry.Curve[] curves = new Autodesk.DesignScript.Geometry.Curve[polyCurve.NumberOfCurves];
                // convert segment into AutoCAD polyline
                int curIndex = 0;
                while (curIndex < polyCurve.NumberOfCurves)
                {
                    double bulge = 0.0;
                    Autodesk.DesignScript.Geometry.Curve curCurve = polyCurve.CurveAtIndex(curIndex);
                    // trying to figure out if the segment is an arc or line...for some reason it thinks lines are arcs
                    var typeOfcurve = curCurve.GetType();
                    if (typeOfcurve == typeof(Autodesk.DesignScript.Geometry.Arc))
                    {
                        // set the bulge for the curve
                        //bulge = BulgeFromCurve(curCurve, true);
                        bulge = 0.5;
                    }
                    // otherwise, it's a line, and default bulge applies                    
                    retVal.AddVertexAt(curIndex, new Point2d(curCurve.StartPoint.X, curCurve.StartPoint.Y), bulge, 0.0, 0.0);
                    curIndex = curIndex + 1;
                }
                if (polyCurve.StartPoint == polyCurve.EndPoint)
                { retVal.Closed = true; }
                else
                { retVal.AddVertexAt(curIndex, new Point2d(polyCurve.EndPoint.X, polyCurve.EndPoint.Y), 0.0, 0.0, 0.0); }
                //retVal = Autodesk.DesignScript.Geometry.PolyCurve.ByJoinedCurves(curves);
            }
            return retVal;
        }
        [IsVisibleInDynamoLibrary(false)]
        private static double BulgeFromCurve(Autodesk.DesignScript.Geometry.Curve cv, bool clockwise)
        {
            double bulge = 0.0;
            Autodesk.DesignScript.Geometry.Arc a = cv as Autodesk.DesignScript.Geometry.Arc;

            if (a != null)
            {
                double newStart;

                // The start angle is usually greater than the end
                // as arcs are all counter-clockwise.
                // (If it isn't it's because the arc crosses the
                // 0-degree line, and we can subtract 2PI from the
                // start angle.)

                if (a.StartAngle > a.SweepAngle)
                    newStart = a.StartAngle - 8 * Math.Atan(1);
                else
                    newStart = a.StartAngle;

                // Bulge is defined as the tan of
                // one fourth of the included angle

                bulge = Math.Tan((a.SweepAngle - newStart) / 4);

                // If the curve is clockwise, we negate the bulge

                if (clockwise)
                    bulge = -bulge;
            }
            return bulge;
        }

        /// <summary>
        /// Returns the area of a provided polyline
        /// </summary>
        /// <param name="polyline">An AutoCAD Polyline obejct</param>
        /// <returns>A double of the area.</returns>
        [IsVisibleInDynamoLibrary(false)]
        public static double AreaByPolyline(Autodesk.AutoCAD.DatabaseServices.Polyline polyline)
        {
            return polyline.Area;
        }

        [IsVisibleInDynamoLibrary(false)]
        public static IList<Autodesk.DesignScript.Geometry.Point> GetPolylineVertices(Autodesk.AutoCAD.DatabaseServices.Polyline polyline)
        {
            int curIndex = 0;
            //CivilDynamoTools.AutoCAD.Point2dCollection points = new CivilDynamoTools.AutoCAD.Point2dCollection(new Point2dCollection());
            //System.Collections.ArrayList points = new System.Collections.ArrayList();
            IList<Autodesk.DesignScript.Geometry.Point> points = new List<Autodesk.DesignScript.Geometry.Point>();
            while (curIndex < polyline.NumberOfVertices)
            {
                double x = polyline.GetPoint2dAt(curIndex).X;
                double y = polyline.GetPoint2dAt(curIndex).Y;
                double z = 0.0;
                points.Add(Autodesk.DesignScript.Geometry.Point.ByCoordinates(x, y, z));
                //points.Add(polyline.GetPoint2dAt(curIndex));
                curIndex = curIndex + 1;
            }
            return points;
        }

        [IsVisibleInDynamoLibrary(false)]
        public static IList<Autodesk.DesignScript.Geometry.Point> PointsFromPolyCurve(Autodesk.DesignScript.Geometry.PolyCurve polycurve)
        {
            IList<Autodesk.DesignScript.Geometry.Point> points = new List<Autodesk.DesignScript.Geometry.Point>();
            if (polycurve != null)
            {
                double x, y, z;
                
                Autodesk.DesignScript.Geometry.Curve[] curves = polycurve.Curves();
                foreach (Autodesk.DesignScript.Geometry.Curve curve in curves)
                {
                    x = curve.StartPoint.X;
                    y = curve.StartPoint.Y;
                    z = curve.StartPoint.Z;
                    points.Add(Autodesk.DesignScript.Geometry.Point.ByCoordinates(x, y, z));
                }
                x = polycurve.EndPoint.X;
                y = polycurve.EndPoint.Y;
                z = polycurve.EndPoint.Z;
                points.Add(Autodesk.DesignScript.Geometry.Point.ByCoordinates(x, y, z));
            }
            return points;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static double AreaByCoordinates(IList<Autodesk.DesignScript.Geometry.Point> points)
        {
            double retVal = Double.NaN;
            try
            {
                if (points != null)
                {
                    // initialize variables
                    int xCount = 0;
                    int yCount = 0;
                    double xTotals = 0;
                    double yTotals = 0;
                    // resize the list of points to add one space, in case the provided list doesn't close
                    IList<Autodesk.DesignScript.Geometry.Point> workingPoints = new List<Autodesk.DesignScript.Geometry.Point>(points.Count + 1);
                    // copy the provided list into the new list
                    foreach (Autodesk.DesignScript.Geometry.Point pt in points)
                    { workingPoints.Add(pt); }
                    // check if the first and last points are the same, if not, add the first point to the end of the points list
                    if (points[0] != points[points.Count - 1])
                    {
                        double x = points[0].X;
                        double y = points[0].Y;
                        double z = points[0].Z;
                        workingPoints.Add(Autodesk.DesignScript.Geometry.Point.ByCoordinates(x, y, z));
                    }
                    // step thru the list and calculate the values
                    foreach (Autodesk.DesignScript.Geometry.Point pt in workingPoints)
                    {
                        Autodesk.DesignScript.Geometry.Point coord = pt;
                        // if we're not working with the last point
                        if (yCount < workingPoints.Count - 1)
                        {
                            // multiply the current points X by the next points Y
                            // and add the value to the previous set of values
                            Autodesk.DesignScript.Geometry.Point nextYPoint = workingPoints[yCount + 1];
                            xTotals = xTotals + (coord.X * nextYPoint.Y);
                            yCount = yCount + 1;
                        }
                        // if we're not working with the last point
                        if (xCount < workingPoints.Count - 1)
                        {
                            // multiply the current points Y by the next points X
                            // and add the value to the previous set of values
                            Autodesk.DesignScript.Geometry.Point nextXPoint = workingPoints[xCount + 1];
                            yTotals = yTotals + (coord.Y * nextXPoint.X);
                            xCount = xCount + 1;
                        }
                    }
                    // subtract the X values from the Y values to get the area
                    retVal = Math.Abs((xTotals - yTotals) / 2);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {

            }
            return retVal;

        }


        // to calculate impervious cover per drainage area
        //
        // determine if the polys are within the drainage area
            // recursively check the corners of the polys against the drainage area
            // for each point, extend a line infinitely to the east
            // if the number of crossings of the drainage area and infinite line is odd, it's inside
            // double check by extending infinite to the west?
        // exclude any outside
        // get the total area of the polys inside - this would be easier with an Acad Polyline
        // determine if any polys are within another poly
        // subtract the internal polys from the total
        // provide the total area




    }
}

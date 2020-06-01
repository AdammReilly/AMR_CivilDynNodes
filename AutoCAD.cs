using AcadApp = Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using System;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.Civil.DatabaseServices;
using NUnit.Framework;
using System.Collections.Generic;
using System.Collections;

namespace CivilDynamoTools
{
    [IsVisibleInDynamoLibrary(false)]
    public class AutoCAD
    {
        [IsVisibleInDynamoLibrary(false)]
        public class Polyline
        {
            private Autodesk.AutoCAD.DatabaseServices.Polyline _curPolyline;

            public Polyline(Autodesk.AutoCAD.DatabaseServices.Polyline originalPolyline)
            {
                _curPolyline = originalPolyline;
            }

            public Point3d EndPoint {
                get => _curPolyline.EndPoint;
            }

            public override string ToString()
            {
                return String.Format("Polyline with {0} vertices.", _curPolyline.NumberOfVertices.ToString());
            }

            public Point2d GetPoint2dAt(int curIndex)
            {
                return _curPolyline.GetPoint2dAt(curIndex);
            }

            public int NumberOfVertices
            { get => _curPolyline.NumberOfVertices; }
        }

    }
}

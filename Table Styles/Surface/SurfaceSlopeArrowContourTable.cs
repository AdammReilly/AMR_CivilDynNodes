using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceSlopeArrowContourTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceSlopeArrowContourTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Surface Slope Arrow Contour Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SurfaceSlopeArrowContourTable> GetSurfaceSlopeArrowContourTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceSlopeArrowContourTable> retList = new List<SurfaceSlopeArrowContourTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceSlopeArrowContourTableStyles))
            {
                SurfaceSlopeArrowContourTable style = new SurfaceSlopeArrowContourTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SurfaceSlopeArrowContourTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceSlopeArrowContourTable retStyle = new SurfaceSlopeArrowContourTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceSlopeArrowContourTableStyles, index), false);
            return retStyle;
        }

        public static SurfaceSlopeArrowContourTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurfaceSlopeArrowContourTable retStyle = new SurfaceSlopeArrowContourTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceSlopeArrowContourTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

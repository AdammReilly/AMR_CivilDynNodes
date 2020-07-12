using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceContourTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceContourTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Surface Contour Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SurfaceContourTable> GetSurfaceContourTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceContourTable> retList = new List<SurfaceContourTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceContourTableStyles))
            {
                SurfaceContourTable style = new SurfaceContourTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SurfaceContourTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceContourTable retStyle = new SurfaceContourTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceContourTableStyles, index), false);
            return retStyle;
        }

        public static SurfaceContourTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurfaceContourTable retStyle = new SurfaceContourTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceContourTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

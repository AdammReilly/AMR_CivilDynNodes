using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceWatershedTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceWatershedTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Surface Watershed Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SurfaceWatershedTable> GetSurfaceWatershedTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceWatershedTable> retList = new List<SurfaceWatershedTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceWatershedTableStyles))
            {
                SurfaceWatershedTable style = new SurfaceWatershedTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SurfaceWatershedTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceWatershedTable retStyle = new SurfaceWatershedTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceWatershedTableStyles, index), false);
            return retStyle;
        }

        public static SurfaceWatershedTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurfaceWatershedTable retStyle = new SurfaceWatershedTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceWatershedTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

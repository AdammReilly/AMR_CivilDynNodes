using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceUserDefinedContourTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceUserDefinedContourTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Surface User Defined Contour Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SurfaceUserDefinedContourTable> GetSurfaceUserDefinedContourTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceUserDefinedContourTable> retList = new List<SurfaceUserDefinedContourTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceUserDefinedContourTableStyles))
            {
                SurfaceUserDefinedContourTable style = new SurfaceUserDefinedContourTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SurfaceUserDefinedContourTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceUserDefinedContourTable retStyle = new SurfaceUserDefinedContourTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceUserDefinedContourTableStyles, index), false);
            return retStyle;
        }

        public static SurfaceUserDefinedContourTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurfaceUserDefinedContourTable retStyle = new SurfaceUserDefinedContourTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceUserDefinedContourTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

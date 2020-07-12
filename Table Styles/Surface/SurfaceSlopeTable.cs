using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceSlopeTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceSlopeTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Surface Slope Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SurfaceSlopeTable> GetSurfaceSlopeTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceSlopeTable> retList = new List<SurfaceSlopeTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceSlopeTableStyles))
            {
                SurfaceSlopeTable style = new SurfaceSlopeTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SurfaceSlopeTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceSlopeTable retStyle = new SurfaceSlopeTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceSlopeTableStyles, index), false);
            return retStyle;
        }

        public static SurfaceSlopeTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurfaceSlopeTable retStyle = new SurfaceSlopeTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceSlopeTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

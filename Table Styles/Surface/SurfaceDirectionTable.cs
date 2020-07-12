using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Surfaces
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceDirectionTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceDirectionTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Surface Direction Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SurfaceDirectionTable> GetSurfaceDirectionTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceDirectionTable> retList = new List<SurfaceDirectionTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceDirectionTableStyles))
            {
                SurfaceDirectionTable style = new SurfaceDirectionTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SurfaceDirectionTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceDirectionTable retStyle = new SurfaceDirectionTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceDirectionTableStyles, index), false);
            return retStyle;
        }

        public static SurfaceDirectionTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurfaceDirectionTable retStyle = new SurfaceDirectionTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SurfaceDirectionTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

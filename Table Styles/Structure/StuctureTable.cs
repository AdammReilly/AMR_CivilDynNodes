using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables
{
    [IsVisibleInDynamoLibrary(true)]
    public class StructureTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected StructureTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Structure Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<StructureTable> GetStructureTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<StructureTable> retList = new List<StructureTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.StructureTableStyles))
            {
                StructureTable style = new StructureTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static StructureTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            StructureTable retStyle = new StructureTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.StructureTableStyles, index), false);
            return retStyle;
        }

        public static StructureTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            StructureTable retStyle = new StructureTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.StructureTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

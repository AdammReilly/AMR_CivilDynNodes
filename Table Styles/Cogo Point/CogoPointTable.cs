using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables
{
    [IsVisibleInDynamoLibrary(true)]
    public class CogoPointTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected CogoPointTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Cogo Point Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<CogoPointTable> GetCogoPointTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CogoPointTable> retList = new List<CogoPointTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.PointTableStyles))
            {
                CogoPointTable style = new CogoPointTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static CogoPointTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CogoPointTable retStyle = new CogoPointTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.PointTableStyles, index), false);
            return retStyle;
        }

        public static CogoPointTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            CogoPointTable retStyle = new CogoPointTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.PointTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

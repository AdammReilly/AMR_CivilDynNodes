using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables
{
    [IsVisibleInDynamoLibrary(true)]
    public class PipeTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected PipeTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Pipe Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<PipeTable> GetPipeTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<PipeTable> retList = new List<PipeTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.PipeTableStyles))
            {
                PipeTable style = new PipeTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static PipeTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            PipeTable retStyle = new PipeTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.PipeTableStyles, index), false);
            return retStyle;
        }

        public static PipeTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            PipeTable retStyle = new PipeTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.PipeTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

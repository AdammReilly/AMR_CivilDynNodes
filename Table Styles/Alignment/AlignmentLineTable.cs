using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Alignments
{
    [IsVisibleInDynamoLibrary(true)]
    public class AlignmentLineTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentLineTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Alignment Line Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<AlignmentLineTable> GetAlignmentLineTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<AlignmentLineTable> retList = new List<AlignmentLineTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentLineTableStyles))
            {
                AlignmentLineTable style = new AlignmentLineTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static AlignmentLineTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AlignmentLineTable retStyle = new AlignmentLineTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentLineTableStyles, index), false);
            return retStyle;
        }

        public static AlignmentLineTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            AlignmentLineTable retStyle = new AlignmentLineTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentLineTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

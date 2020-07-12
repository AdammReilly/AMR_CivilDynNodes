using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Alignments
{
    [IsVisibleInDynamoLibrary(true)]
    public class AlignmentSpiralTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentSpiralTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Alignment Spiral Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<AlignmentSpiralTable> GetAlignmentSpiralTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<AlignmentSpiralTable> retList = new List<AlignmentSpiralTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentSpiralTableStyles))
            {
                AlignmentSpiralTable style = new AlignmentSpiralTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static AlignmentSpiralTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AlignmentSpiralTable retStyle = new AlignmentSpiralTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentSpiralTableStyles, index), false);
            return retStyle;
        }

        public static AlignmentSpiralTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            AlignmentSpiralTable retStyle = new AlignmentSpiralTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentSpiralTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

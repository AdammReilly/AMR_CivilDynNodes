using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Alignments
{
    [IsVisibleInDynamoLibrary(true)]
    public class AlignmentSegmentTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentSegmentTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Alignment Segment Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<AlignmentSegmentTable> GetAlignmentSegmentTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<AlignmentSegmentTable> retList = new List<AlignmentSegmentTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentSegmentTableStyles))
            {
                AlignmentSegmentTable style = new AlignmentSegmentTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static AlignmentSegmentTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AlignmentSegmentTable retStyle = new AlignmentSegmentTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentSegmentTableStyles, index), false);
            return retStyle;
        }

        public static AlignmentSegmentTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            AlignmentSegmentTable retStyle = new AlignmentSegmentTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentSegmentTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

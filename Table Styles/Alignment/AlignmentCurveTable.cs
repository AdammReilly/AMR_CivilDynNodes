using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Alignments
{
    [IsVisibleInDynamoLibrary(true)]
    public class AlignmentCurveTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentCurveTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Alignment Curve Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<AlignmentCurveTable> GetAlignmentCurveTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<AlignmentCurveTable> retList = new List<AlignmentCurveTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentCurveTableStyles))
            {
                AlignmentCurveTable style = new AlignmentCurveTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static AlignmentCurveTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AlignmentCurveTable retStyle = new AlignmentCurveTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentCurveTableStyles, index), false);
            return retStyle;
        }

        public static AlignmentCurveTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            AlignmentCurveTable retStyle = new AlignmentCurveTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.AlignmentCurveTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

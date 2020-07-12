using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.QTO
{
    [IsVisibleInDynamoLibrary(true)]
    public class QTOMaterialTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected QTOMaterialTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "QTO Material Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<QTOMaterialTable> GetQTOMaterialTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<QTOMaterialTable> retList = new List<QTOMaterialTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.QuantityTakeoffMaterialTableStyles))
            {
                QTOMaterialTable style = new QTOMaterialTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static QTOMaterialTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            QTOMaterialTable retStyle = new QTOMaterialTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.QuantityTakeoffMaterialTableStyles, index), false);
            return retStyle;
        }

        public static QTOMaterialTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            QTOMaterialTable retStyle = new QTOMaterialTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.QuantityTakeoffMaterialTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

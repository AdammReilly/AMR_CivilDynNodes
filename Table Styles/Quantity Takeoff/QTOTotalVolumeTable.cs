using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.QTO
{
    [IsVisibleInDynamoLibrary(true)]
    public class QTOTotalVolumeTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected QTOTotalVolumeTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "QTO Total Volume Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<QTOTotalVolumeTable> GetQTOTotalVolumeTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<QTOTotalVolumeTable> retList = new List<QTOTotalVolumeTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.QuantityTakeoffTotalVolumeTableStyles))
            {
                QTOTotalVolumeTable style = new QTOTotalVolumeTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static QTOTotalVolumeTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            QTOTotalVolumeTable retStyle = new QTOTotalVolumeTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.QuantityTakeoffTotalVolumeTableStyles, index), false);
            return retStyle;
        }

        public static QTOTotalVolumeTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            QTOTotalVolumeTable retStyle = new QTOTotalVolumeTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.QuantityTakeoffTotalVolumeTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

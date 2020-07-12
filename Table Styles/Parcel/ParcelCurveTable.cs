using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Parcels
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelCurveTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelCurveTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Parcel Curve Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<ParcelCurveTable> GetParcelCurveTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelCurveTable> retList = new List<ParcelCurveTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelCurveTableStyles))
            {
                ParcelCurveTable style = new ParcelCurveTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static ParcelCurveTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelCurveTable retStyle = new ParcelCurveTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelCurveTableStyles, index), false);
            return retStyle;
        }

        public static ParcelCurveTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ParcelCurveTable retStyle = new ParcelCurveTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelCurveTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

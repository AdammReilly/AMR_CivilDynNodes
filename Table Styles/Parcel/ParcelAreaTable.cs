using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Parcels
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelAreaTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelAreaTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Parcel Area Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<ParcelAreaTable> GetParcelAreaTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelAreaTable> retList = new List<ParcelAreaTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelAreaTableStyles))
            {
                ParcelAreaTable style = new ParcelAreaTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static ParcelAreaTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelAreaTable retStyle = new ParcelAreaTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelAreaTableStyles, index), false);
            return retStyle;
        }

        public static ParcelAreaTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ParcelAreaTable retStyle = new ParcelAreaTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelAreaTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

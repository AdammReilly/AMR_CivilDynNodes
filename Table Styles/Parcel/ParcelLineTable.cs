using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Parcels
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelLineTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelLineTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Parcel Line Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<ParcelLineTable> GetParcelLineTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelLineTable> retList = new List<ParcelLineTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelLineTableStyles))
            {
                ParcelLineTable style = new ParcelLineTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static ParcelLineTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelLineTable retStyle = new ParcelLineTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelLineTableStyles, index), false);
            return retStyle;
        }

        public static ParcelLineTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ParcelLineTable retStyle = new ParcelLineTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelLineTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

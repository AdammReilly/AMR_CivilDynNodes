using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.Parcels
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelSegmentTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelSegmentTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Parcel Segment Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<ParcelSegmentTable> GetParcelSegmentTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelSegmentTable> retList = new List<ParcelSegmentTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelSegmentTableStyles))
            {
                ParcelSegmentTable style = new ParcelSegmentTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static ParcelSegmentTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelSegmentTable retStyle = new ParcelSegmentTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelSegmentTableStyles, index), false);
            return retStyle;
        }

        public static ParcelSegmentTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ParcelSegmentTable retStyle = new ParcelSegmentTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.ParcelSegmentTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.SectionViews
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionViewTotalVolumeTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SectionViewTotalVolumeTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Section View Total Volume Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SectionViewTotalVolumeTable> GetSectionViewTotalVolumeTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionViewTotalVolumeTable> retList = new List<SectionViewTotalVolumeTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SectionViewTotalVolumeTableStyles))
            {
                SectionViewTotalVolumeTable style = new SectionViewTotalVolumeTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SectionViewTotalVolumeTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionViewTotalVolumeTable retStyle = new SectionViewTotalVolumeTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SectionViewTotalVolumeTableStyles, index), false);
            return retStyle;
        }

        public static SectionViewTotalVolumeTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SectionViewTotalVolumeTable retStyle = new SectionViewTotalVolumeTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SectionViewTotalVolumeTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

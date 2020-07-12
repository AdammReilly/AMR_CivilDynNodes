using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles.Tables.SectionViews
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionViewMaterialTable : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SectionViewMaterialTable(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Section View Material Table";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties


        #endregion

        #region staticMethods
        public static List<SectionViewMaterialTable> GetSectionViewMaterialTables(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionViewMaterialTable> retList = new List<SectionViewMaterialTable>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SectionViewMaterialTableStyles))
            {
                SectionViewMaterialTable style = new SectionViewMaterialTable(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static SectionViewMaterialTable ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionViewMaterialTable retStyle = new SectionViewMaterialTable(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SectionViewMaterialTableStyles, index), false);
            return retStyle;
        }

        public static SectionViewMaterialTable ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SectionViewMaterialTable retStyle = new SectionViewMaterialTable(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.TableStyles.SectionViewMaterialTableStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

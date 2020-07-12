using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionViewStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SectionViewStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Section View";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new SectionViewStyle Style
        {
            get => new SectionViewStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<SectionViewStyle> GetSectionViewStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionViewStyle> retList = new List<SectionViewStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SectionViewStyles))
            {
                SectionViewStyle style = new SectionViewStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static SectionViewStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionViewStyle retStyle = new SectionViewStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SectionViewStyles, index), false);
            return retStyle;
        }

        public static SectionViewStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SectionViewStyle retStyle = new SectionViewStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SectionViewStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

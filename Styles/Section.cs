using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class SectionStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SectionStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Section";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new SectionStyle Style
        {
            get => new SectionStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<SectionStyle> GetSectionStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SectionStyle> retList = new List<SectionStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SectionStyles))
            {
                SectionStyle style = new SectionStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static SectionStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SectionStyle retStyle = new SectionStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SectionStyles, index), false);
            return retStyle;
        }

        public static SectionStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SectionStyle retStyle = new SectionStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SectionStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

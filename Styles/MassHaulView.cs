using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class MassHaulViewStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected MassHaulViewStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Mass Haul View";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new MassHaulViewStyle Style
        {
            get => new MassHaulViewStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<MassHaulViewStyle> GetMassHaulViewStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<MassHaulViewStyle> retList = new List<MassHaulViewStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MassHaulViewStyles))
            {
                MassHaulViewStyle style = new MassHaulViewStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static MassHaulViewStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            MassHaulViewStyle retStyle = new MassHaulViewStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MassHaulViewStyles, index), false);
            return retStyle;
        }

        public static MassHaulViewStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            MassHaulViewStyle retStyle = new MassHaulViewStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MassHaulViewStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

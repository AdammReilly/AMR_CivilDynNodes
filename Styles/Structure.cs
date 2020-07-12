using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class StructureStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected StructureStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Structure";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new StructureStyle Style
        {
            get => new StructureStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<StructureStyle> GetStructureStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<StructureStyle> retList = new List<StructureStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.StructureStyles))
            {
                StructureStyle style = new StructureStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static StructureStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            StructureStyle retStyle = new StructureStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.StructureStyles, index), false);
            return retStyle;
        }

        public static StructureStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            StructureStyle retStyle = new StructureStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.StructureStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

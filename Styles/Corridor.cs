using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class CorridorStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected CorridorStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Corridor";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new CorridorStyle Style
        {
            get => new CorridorStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<CorridorStyle> GetCorridorStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CorridorStyle> retList = new List<CorridorStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CorridorStyles))
            {
                CorridorStyle style = new CorridorStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static CorridorStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CorridorStyle retStyle = new CorridorStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CorridorStyles, index), false);
            return retStyle;
        }

        public static CorridorStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            CorridorStyle retStyle = new CorridorStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CorridorStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

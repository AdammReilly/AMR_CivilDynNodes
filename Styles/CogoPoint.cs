using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class CogoPointStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected CogoPointStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Cogo Point";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new CogoPointStyle Style
        {
            get => new CogoPointStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<CogoPointStyle> GetCogoPointStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CogoPointStyle> retList = new List<CogoPointStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.PointStyles))
            {
                CogoPointStyle style = new CogoPointStyle(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static CogoPointStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CogoPointStyle retStyle = new CogoPointStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.PointStyles, index), false);
            return retStyle;
        }

        public static CogoPointStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            CogoPointStyle retStyle = new CogoPointStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.PointStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

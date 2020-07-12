using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class CatchmentStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected CatchmentStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Catchment";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new CatchmentStyle Style
        {
            get => new CatchmentStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<CatchmentStyle> GetCatchmentStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<CatchmentStyle> retList = new List<CatchmentStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CatchmentStyles))
            {
                CatchmentStyle style = new CatchmentStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static CatchmentStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            CatchmentStyle retStyle = new CatchmentStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CatchmentStyles, index), false);
            return retStyle;
        }

        public static CatchmentStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            CatchmentStyle retStyle = new CatchmentStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.CatchmentStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

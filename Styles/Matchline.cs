using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    class MatchLineStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected MatchLineStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "MatchLine";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new MatchLineStyle Style
        {
            get => new MatchLineStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<MatchLineStyle> GetMatchLineStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<MatchLineStyle> retList = new List<MatchLineStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MatchLineStyles))
            {
                MatchLineStyle style = new MatchLineStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static MatchLineStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            MatchLineStyle retStyle = new MatchLineStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MatchLineStyles, index), false);
            return retStyle;
        }

        public static MatchLineStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            MatchLineStyle retStyle = new MatchLineStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MatchLineStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

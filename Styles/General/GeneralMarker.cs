using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.Styles.General
{
    [IsVisibleInDynamoLibrary(true)]
    public class MarkerStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected MarkerStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Marker";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new MarkerStyle Style
        {
            get => new MarkerStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<MarkerStyle> GetMarkerStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<MarkerStyle> retList = new List<MarkerStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MarkerStyles))
            {
                MarkerStyle style = new MarkerStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static MarkerStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            MarkerStyle retStyle = new MarkerStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MarkerStyles, index), false);
            return retStyle;
        }

        public static MarkerStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            MarkerStyle retStyle = new MarkerStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MarkerStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

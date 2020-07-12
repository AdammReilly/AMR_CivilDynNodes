using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class SuperelevationViewStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SuperelevationViewStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "SuperelevationView";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new SuperelevationViewStyle Style
        {
            get => new SuperelevationViewStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<SuperelevationViewStyle> GetSuperelevationViewStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SuperelevationViewStyle> retList = new List<SuperelevationViewStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SuperelevationViewStyles))
            {
                SuperelevationViewStyle style = new SuperelevationViewStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static SuperelevationViewStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SuperelevationViewStyle retStyle = new SuperelevationViewStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SuperelevationViewStyles, index), false);
            return retStyle;
        }

        public static SuperelevationViewStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SuperelevationViewStyle retStyle = new SuperelevationViewStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SuperelevationViewStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class InterferenceStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected InterferenceStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Interference";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new InterferenceStyle Style
        {
            get => new InterferenceStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<InterferenceStyle> GetInterferenceStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<InterferenceStyle> retList = new List<InterferenceStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.InterferenceStyles))
            {
                InterferenceStyle style = new InterferenceStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static InterferenceStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            InterferenceStyle retStyle = new InterferenceStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.InterferenceStyles, index), false);
            return retStyle;
        }

        public static InterferenceStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            InterferenceStyle retStyle = new InterferenceStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.InterferenceStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class AlignmentStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Alignment";
        }

        [IsVisibleInDynamoLibrary(false)]
        protected AlignmentStyle ByCivilStyle(CivilStyle civilStyle)
        {
            return (AlignmentStyle)civilStyle;
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new AlignmentStyle Style
        {
            get => new AlignmentStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }

        #endregion

        #region staticMethods
        public static List<AlignmentStyle> GetAlignmentStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<AlignmentStyle> retList = new List<AlignmentStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.AlignmentStyles))
            {
                AlignmentStyle style = new AlignmentStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static AlignmentStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AlignmentStyle retStyle = new AlignmentStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.AlignmentStyles, index), false);
            return retStyle;
        }

        public static AlignmentStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            AlignmentStyle retStyle = new AlignmentStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.AlignmentStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

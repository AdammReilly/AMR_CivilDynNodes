using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class PipeStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected PipeStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Pipe";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new PipeStyle Style
        {
            get => new PipeStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<PipeStyle> GetPipeStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<PipeStyle> retList = new List<PipeStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.PipeStyles))
            {
                PipeStyle style = new PipeStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static PipeStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            PipeStyle retStyle = new PipeStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.PipeStyles, index), false);
            return retStyle;
        }

        public static PipeStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            PipeStyle retStyle = new PipeStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.PipeStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

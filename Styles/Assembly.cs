using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class AssemblyStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected AssemblyStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Assembly";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]

        public new AssemblyStyle Style
        {
            get => new AssemblyStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }

        #endregion

        #region staticMethods
        public static List<AssemblyStyle> GetAssemblyStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<AssemblyStyle> retList = new List<AssemblyStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.AssemblyStyles))
            {
                AssemblyStyle style = new AssemblyStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static AssemblyStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            AssemblyStyle retStyle = new AssemblyStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.AssemblyStyles, index), false);
            return retStyle;
        }

        public static AssemblyStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            AssemblyStyle retStyle = new AssemblyStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.AssemblyStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

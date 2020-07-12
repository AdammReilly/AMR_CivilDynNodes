using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class SampleLineStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SampleLineStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Sample Line";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new SampleLineStyle Style
        {
            get => new SampleLineStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<SampleLineStyle> GetSampleLineStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SampleLineStyle> retList = new List<SampleLineStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SampleLineStyles))
            {
                SampleLineStyle style = new SampleLineStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static SampleLineStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SampleLineStyle retStyle = new SampleLineStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SampleLineStyles, index), false);
            return retStyle;
        }

        public static SampleLineStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SampleLineStyle retStyle = new SampleLineStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SampleLineStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

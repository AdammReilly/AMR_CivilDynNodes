using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class MassHaulLineStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected MassHaulLineStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Mass Haul Line";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new MassHaulLineStyle Style
        {
            get => new MassHaulLineStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<MassHaulLineStyle> GetMassHaulLineStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<MassHaulLineStyle> retList = new List<MassHaulLineStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MassHaulLineStyles))
            {
                MassHaulLineStyle style = new MassHaulLineStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static MassHaulLineStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            MassHaulLineStyle retStyle = new MassHaulLineStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MassHaulLineStyles, index), false);
            return retStyle;
        }

        public static MassHaulLineStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            MassHaulLineStyle retStyle = new MassHaulLineStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.MassHaulLineStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

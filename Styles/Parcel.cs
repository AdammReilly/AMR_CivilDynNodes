using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ParcelStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ParcelStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Parcel";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new ParcelStyle Style
        {
            get => new ParcelStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<ParcelStyle> GetParcelStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ParcelStyle> retList = new List<ParcelStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ParcelStyles))
            {
                ParcelStyle style = new ParcelStyle(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static ParcelStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ParcelStyle retStyle = new ParcelStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ParcelStyles, index), false);
            return retStyle;
        }

        public static ParcelStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ParcelStyle retStyle = new ParcelStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ParcelStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

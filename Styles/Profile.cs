using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ProfileStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ProfileStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Profile";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new ProfileStyle Style
        {
            get => new ProfileStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<ProfileStyle> GetProfileStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ProfileStyle> retList = new List<ProfileStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ProfileStyles))
            {
                ProfileStyle style = new ProfileStyle(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static ProfileStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ProfileStyle retStyle = new ProfileStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ProfileStyles, index), false);
            return retStyle;
        }

        public static ProfileStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ProfileStyle retStyle = new ProfileStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ProfileStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

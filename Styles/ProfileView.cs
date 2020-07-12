using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.DatabaseServices.Styles;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;
using Dynamo.Graph.Nodes;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class ProfileViewStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected ProfileViewStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Profile View";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new ProfileViewStyle Style
        {
            get => new ProfileViewStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<ProfileViewStyle> GetProfileViewStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ProfileViewStyle> retList = new List<ProfileViewStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ProfileViewStyles))
            {
                ProfileViewStyle style = new ProfileViewStyle(dbOb, false);
                retList.Add(style);

            }
            return retList;
        }

        public static ProfileViewStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ProfileViewStyle retStyle = new ProfileViewStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ProfileViewStyles, index), false);
            return retStyle;
        }

        public static ProfileViewStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            ProfileViewStyle retStyle = new ProfileViewStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.ProfileViewStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

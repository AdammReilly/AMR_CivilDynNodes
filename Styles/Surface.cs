using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.Styles
{
    [IsVisibleInDynamoLibrary(true)]
    public class SurfaceStyle : CivilStyle
    {
        #region variables

        #endregion

        #region constructors
        [IsVisibleInDynamoLibrary(false)]
        protected SurfaceStyle(Autodesk.AutoCAD.DatabaseServices.DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._objectStyleType = "Surface";
        }

        #endregion

        #region publicMethods


        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public new SurfaceStyle Style
        {
            get => new SurfaceStyle(GetStyleFromStyleObject(Autodesk.AutoCAD.DynamoNodes.Document.Current, _curDBObject), false);
        }


        #endregion

        #region staticMethods
        public static List<SurfaceStyle> GetSurfaceStyles(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<SurfaceStyle> retList = new List<SurfaceStyle>();
            foreach (DBObject dbOb in GetStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurfaceStyles))
            {
                SurfaceStyle style = new SurfaceStyle(dbOb, false);
                retList.Add(style);
            }
            return retList;
        }

        public static SurfaceStyle ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            SurfaceStyle retStyle = new SurfaceStyle(CivilStyle.DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurfaceStyles, index), false);
            return retStyle;
        }

        public static SurfaceStyle ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string styleName)
        {
            SurfaceStyle retStyle = new SurfaceStyle(CivilStyle.DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.SurfaceStyles, styleName), false);
            return retStyle;
        }

        #endregion

    }
}

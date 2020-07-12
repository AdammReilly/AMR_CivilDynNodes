using Autodesk.AutoCAD.DatabaseServices;
using System.Collections.Generic;
using Autodesk.Civil.ApplicationServices;
using Autodesk.DesignScript.Runtime;

namespace CivilDynamoTools.LabelStyles.ViewFrames
{
    [IsVisibleInDynamoLibrary(true)]
    public class ViewFrameLabel : LabelStyle
    {
        #region variables

        #endregion

        #region constructor
        [IsVisibleInDynamoLibrary(false)]
        protected ViewFrameLabel(DBObject obj, bool isDynamoOwned) : base(obj, isDynamoOwned)
        {
            base._labelStyleType = "View Frame";
        }

        [IsVisibleInDynamoLibrary(true)]
        public static List<ViewFrameLabel> GetViewFrameLabels(Autodesk.AutoCAD.DynamoNodes.Document document)
        {
            List<ViewFrameLabel> retLabels = new List<ViewFrameLabel>();
            foreach (DBObject dbObj in GetLabelStylesAsDBObjects(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ViewFrameLabelStyles.LabelStyles))
            {
                ViewFrameLabel labelObject = new ViewFrameLabel(dbObj, false);
                retLabels.Add(labelObject);
            }
            return retLabels;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ViewFrameLabel ByIndex(Autodesk.AutoCAD.DynamoNodes.Document document, int index)
        {
            ViewFrameLabel retLabel = new ViewFrameLabel(DBObjectByIndex(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ViewFrameLabelStyles.LabelStyles, index), false);
            return retLabel;
        }

        [IsVisibleInDynamoLibrary(true)]
        public static ViewFrameLabel ByName(Autodesk.AutoCAD.DynamoNodes.Document document, string labelStyleName)
        {
            ViewFrameLabel retLabel = new ViewFrameLabel(DBObjectByName(document, CivilDocument.GetCivilDocument(document.AcDocument.Database).Styles.LabelStyles.ViewFrameLabelStyles.LabelStyles, labelStyleName), false);
            return retLabel;
        }
        #endregion


        #region public methods


        #endregion

        #region properties


        #endregion


    }
}

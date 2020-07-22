using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.DesignScript.Runtime;
using CivilDynamoTools.Styles;

namespace CivilDynamoTools.Objects
{
    public class CivilObject : Autodesk.Civil.DynamoNodes.CivilObject
    {
        #region variables
        internal Autodesk.Civil.DatabaseServices.Entity _curCivilObject;
        internal string _name;
        internal string _description;
        #endregion

        #region constructor
        //[IsVisibleInDynamoLibrary(false)]
        internal CivilObject(Autodesk.Civil.DatabaseServices.Entity curCivilEntity, bool isDynamoOwned) : base(curCivilEntity, isDynamoOwned)
        {
            _curCivilObject = curCivilEntity;
            _name = curCivilEntity.Name;
            _description = curCivilEntity.Description;
            
        }
        #endregion

        #region public methods
        [IsVisibleInDynamoLibrary(false)]
        public Autodesk.Civil.DynamoNodes.CivilObject SetName(string name)
        {
            //Autodesk.AutoCAD.ApplicationServices.Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //Autodesk.AutoCAD.DatabaseServices.Database db = doc.Database;
            //using (Autodesk.AutoCAD.DatabaseServices.Transaction trans = db.TransactionManager.StartTransaction())
            //{
            //    Autodesk.Civil.DatabaseServices.Entity entity = (Autodesk.Civil.DatabaseServices.Entity) trans.GetObject(_curCivilObject.ObjectId, OpenMode.ForWrite);
            //    try { entity.Name = name; }
            //    catch (System.Exception ex)
            //    {
            //        // if
            //        // An exception of type 'System.ArgumentException' occurred in AeccDbMgd.dll but was not handled in user code
            //        // Additional information: The name may exist. occurred
            //        System.Diagnostics.Debug.WriteLine(ex.Message);
            //        if (ex.Message == "The name may exist.")
            //        {
            //            // then append the name with a number
            //            // possibly refactor this method to create a private method that accepts an optional counter
            //            // if counter is supplied, add as a suffix and try
            //            // if caught, call this method again and increment the counter
            //        }
            //    }
            //    finally
            //    { entity.Name = name; }
            //    trans.Commit();
            //}
            SetNameWithCounter(name);
            this._name = name;
            return this;
        }

        [IsVisibleInDynamoLibrary(false)]
        public Autodesk.Civil.DynamoNodes.CivilObject SetDescription(string description)
        {
            Autodesk.AutoCAD.ApplicationServices.Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Autodesk.AutoCAD.DatabaseServices.Database db = doc.Database;
            using (Autodesk.AutoCAD.DatabaseServices.Transaction trans = db.TransactionManager.StartTransaction())
            {
                Autodesk.Civil.DatabaseServices.Entity entity = (Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(_curCivilObject.ObjectId, OpenMode.ForWrite);
                entity.Name = description;
                trans.Commit();
            }
            this._description = description;
            return this;
        }
        [IsVisibleInDynamoLibrary(true)]
        public CivilObject SetStyle(CivilStyle civilStyle)
        {
            Autodesk.AutoCAD.ApplicationServices.Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Autodesk.AutoCAD.DatabaseServices.Database db = doc.Database;
            using (Autodesk.AutoCAD.DatabaseServices.Transaction trans = db.TransactionManager.StartTransaction())
            {
                Autodesk.Civil.DatabaseServices.Entity entity = (Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(_curCivilObject.ObjectId, OpenMode.ForWrite);
                entity.StyleId = civilStyle.InternalObjectId;
                trans.Commit();
            }
            return this;
        }

        #endregion

        #region privateMethods
        private Autodesk.Civil.DynamoNodes.CivilObject SetNameWithCounter(string name, int counter = 0)
        {
            Autodesk.AutoCAD.ApplicationServices.Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Autodesk.AutoCAD.DatabaseServices.Database db = doc.Database;
            using (Autodesk.AutoCAD.DatabaseServices.Transaction trans = db.TransactionManager.StartTransaction())
            {
                Autodesk.Civil.DatabaseServices.Entity entity = (Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(_curCivilObject.ObjectId, OpenMode.ForWrite);
                try { entity.Name = name; }
                catch (System.Exception ex)
                {
                    // if
                    // An exception of type 'System.ArgumentException' occurred in AeccDbMgd.dll but was not handled in user code
                    // Additional information: The name may exist. occurred
                    if (ex.Message == "The name may exist.")
                    {
                        // check if the name already has the current counter
                        string suffix = " - " + counter.ToString();
                        try { entity.Name = name + suffix; }
                        catch (System.Exception ex2)
                        {
                            // if
                            if (ex2.Message == "The name may exist.")
                            {
                                counter += 1;
                                SetNameWithCounter(name, counter);
                            }
                        }
                        // possibly refactor this method to create a private method that accepts an optional counter
                        // if counter is supplied, add as a suffix and try
                        // if caught, call this method again and increment the counter
                    }   
                }
                finally
                {  }
                trans.Commit();
            }
            this._name = name;
            return this;
        }

        #endregion

        #region properties
        [IsVisibleInDynamoLibrary(false)]
        public string Name
        { get => this._name; }
        [IsVisibleInDynamoLibrary(false)]
        public string Description
        { get => this._description; }
        public CivilStyle Style
        { get
            {
                Autodesk.AutoCAD.DatabaseServices.DBObject style = null;
                Autodesk.AutoCAD.ApplicationServices.Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Autodesk.AutoCAD.DatabaseServices.Database db = doc.Database;
                using (Autodesk.AutoCAD.DatabaseServices.Transaction trans = db.TransactionManager.StartTransaction())
                {
                    Autodesk.Civil.DatabaseServices.Entity entity = (Autodesk.Civil.DatabaseServices.Entity)trans.GetObject(_curCivilObject.ObjectId, OpenMode.ForRead);
                    style = trans.GetObject(entity.StyleId, OpenMode.ForRead);
                    trans.Commit();
                }
                return new CivilStyle(style, false);
            }
        }

        [IsVisibleInDynamoLibrary(true)]
        public override string ToString()
        {
            return "Civil Entity { " + Name + " }";
        }
        #endregion
    }
}

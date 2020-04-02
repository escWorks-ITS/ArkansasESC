using System;
using System.Collections.Generic;
using System.Text;

using Csla;
using Csla.Security;
using Csla.Data;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

/// <summary>
/// Summary description for Contents
/// </summary>
namespace tx_r3.BusinessObect.Accountability
{
    [Serializable()]
    public class Contents : BusinessListBase<Contents, Content>
    {
        #region Business Methods

        public bool AddNew(string contentName)
        {
            Content item = Content.NewContent();
            item.ObjId = ((Content)this.Parent).ObjId;
            item.ContentId = ((Content)this.Parent).ContentId;
            item.ContentName = contentName;
            this.Add(item);

            return true;
        }

        #endregion

        #region Factory Methods

        private Contents()
        { /* require use of factory methods */ }

        internal static Contents NewContents()
        {
            return DataPortal.CreateChild<Contents>();
        }

        public static Contents GetContents(int obj_id)
        {
            return DataPortal.FetchChild<Contents>(obj_id);
        }

        #endregion

        #region Data Access

        protected override void Child_Create()
        {
            //
        }

        public bool AddNew(Content r)
        {
            this.Add(r);

            return true;
        }

        private void Child_Fetch(int obj_id)
        {
            this.RaiseListChangedEvents = false;
            using (SqlConnection cn = region4.Common.DataConnection.DbConnection)
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "ItsContentsGet";
                    cm.Parameters.AddWithValue("@obj_id", obj_id);

                    SafeDataReader dr = new SafeDataReader(cm.ExecuteReader());
                    while (dr.Read())
                    {
                        this.Add(Content.GetContent(dr));
                    }
                }
            }
            this.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            base.Child_Update(this);
        }
        #endregion

    }
}
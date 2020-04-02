using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

using Csla;
using Csla.Security;
using Csla.Data;
/// <summary>
/// Summary description for Content
/// </summary>
namespace tx_r3.BusinessObect.Accountability
{
    [Serializable()]
    public class Content : BusinessBase<Content>
    {
        #region Properties

        private static PropertyInfo<int> KeyProperty = RegisterProperty<int>(new PropertyInfo<int>("key"));
        public int Key
        {
            get { return GetProperty(KeyProperty); }
            set { SetProperty(KeyProperty, value); }
        }

        private static PropertyInfo<int> ObjIdProperty = RegisterProperty<int>(new PropertyInfo<int>("obj_id"));
        public int ObjId
        {
            get { return GetProperty(ObjIdProperty); }
            set { SetProperty(ObjIdProperty, value); }
        }

        private static PropertyInfo<int> ContentIdProperty = RegisterProperty<int>(new PropertyInfo<int>("content_id"));
        public int ContentId
        {
            get { return GetProperty(ContentIdProperty); }
            set { SetProperty(ContentIdProperty, value); }
        }

        private static PropertyInfo<string> ContentNameProperty = RegisterProperty<string>(new PropertyInfo<string>("content_name"));
        public string ContentName
        {
            get { return GetProperty(ContentNameProperty); }
            set { SetProperty(ContentNameProperty, value); }
        }

        #endregion

        #region Factory Methods

        private Content()
        { /* require use of factory methods */ }

        internal static Content NewContent()
        {
            return DataPortal.CreateChild<Content>();
        }

        internal static Content GetContent(SafeDataReader dr)
        {

            return DataPortal.FetchChild<Content>(dr);
        }

        #endregion

        #region DataAccess
        protected override void Child_Create()
        {
            using (BypassPropertyChecks)
            {
                this.Key = -1;
            }
        }

        public static Content CreateNew()
        {
            return NewContent();
        }

        private void Child_Fetch(SafeDataReader dr)
        {
            MapFieldsFromData(dr);
        }

        protected void MapFieldsFromData(SafeDataReader dr)
        {
            using (BypassPropertyChecks)
            {
                LoadProperty(KeyProperty, dr.GetInt32("key"));
                LoadProperty(ObjIdProperty, dr.GetInt32("obj_id"));
                LoadProperty(ContentIdProperty, dr.GetInt32("content_id"));
                LoadProperty(ContentNameProperty, dr.GetString("content_name"));

            }
        }

        protected void Child_Insert(Assistance assistance, SqlConnection cn)
        {
            if (this.IsNew)
            {
                using (SqlCommand cmd = cn.CreateCommand())
                {
                    this.ObjId = assistance.ObjId;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "ItsContentsInsert";
                    cmd.Parameters.AddWithValue("@key", this.Key).Direction = ParameterDirection.Output;

                    this.MapFieldsToParams(cmd);
                    cmd.ExecuteNonQuery();
                    this.Key = Convert.ToInt32(cmd.Parameters["@key"].Value);
                }
            }
        }

        protected void Child_DeleteSelf(escWorks.BusinessObjects.Assistances a)
        {
            if (this.IsDeleted)
            {
                using (SqlConnection cn = region4.Common.DataConnection.DbConnection)
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ItsContentsDelete";
                        cmd.Parameters.AddWithValue("@obj_id", this.ObjId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        protected void MapFieldsToParams(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@obj_id", ObjId);
            cmd.Parameters.AddWithValue("@content_id", ContentId);
        }

        #endregion
        
    }
}
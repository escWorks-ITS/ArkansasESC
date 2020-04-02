using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

using Csla;
using Csla.Security;
using Csla.Data;

namespace tx_r3.BusinessObect.Accountability
{
    [Serializable()]
    public class Audience : BusinessBase<Audience>
    {
        #region Properties

        protected static PropertyInfo<int> KeyProperty = RegisterProperty<int>(new PropertyInfo<int>("key"));
        public int Key
        {
            get { return GetProperty(KeyProperty); }
            set { SetProperty(KeyProperty, value); }
        }

        protected static PropertyInfo<int> ObjIdProperty = RegisterProperty<int>(new PropertyInfo<int>("obj_id"));
        public int ObjId
        {
            get { return GetProperty(ObjIdProperty); }
            set { SetProperty(ObjIdProperty, value); }
        }

        protected static PropertyInfo<int> AmountProperty = RegisterProperty<int>(new PropertyInfo<int>("amount"));
        public int Amount
        {
            get { return GetProperty(AmountProperty); }
            set { SetProperty(AmountProperty, value); }
        }

        protected static PropertyInfo<string> AudienceNameProperty = RegisterProperty<string>(new PropertyInfo<string>("audience"));
        public string AudienceName
        {
            get { return GetProperty(AudienceNameProperty); }
            set { SetProperty(AudienceNameProperty, value); }
        }

        protected static PropertyInfo<int> Audience_IdProperty = RegisterProperty<int>(new PropertyInfo<int>("audience_id"));
        public int Audience_Id
        {
            get { return GetProperty(Audience_IdProperty); }
            set { SetProperty(Audience_IdProperty, value); }
        }


        private static PropertyInfo<double> HoursProperty = RegisterProperty<double>(new PropertyInfo<double>("hours"));
        public double Hours
        {
            get { return GetProperty(HoursProperty); }
            set { SetProperty(HoursProperty, value); }
        }

        private static PropertyInfo<int> HourIdProperty = RegisterProperty<int>(new PropertyInfo<int>("hour_id"));
        public int HourId
        {
            get { return GetProperty(HourIdProperty); }
            set { SetProperty(HourIdProperty, value); }
        }

        #endregion

        #region Factory Methods

        public Audience()
        { /* require use of factory methods */ }

        internal static Audience NewAudience()
        {
            return DataPortal.CreateChild<Audience>();
        }

        internal static Audience GetAudience(SafeDataReader dr)
        {

            return DataPortal.FetchChild<Audience>(dr);
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
        
        public static Audience CreateNew()
        {
            return NewAudience();
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
                LoadProperty(AmountProperty, dr.GetInt32("amount"));
                LoadProperty(AudienceNameProperty, dr.GetString("audience"));
                LoadProperty(Audience_IdProperty, dr.GetInt32("audience_id"));
                LoadProperty(HoursProperty, dr.GetDouble("hours"));
                LoadProperty(HourIdProperty, dr.GetInt32("hour_id"));
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
                    cmd.CommandText = "ItsAudiencesInsert";
                    cmd.Parameters.AddWithValue("@key", this.Key).Direction = ParameterDirection.Output;

                    this.MapFieldsToParams(cmd);
                    cmd.ExecuteNonQuery();
                    this.Key = Convert.ToInt32(cmd.Parameters["@key"].Value);
                }
            }
        }

        protected void Child_DeleteSelf(Assistances a)
        {
            if (this.IsDeleted)
            {
                using (SqlConnection cn = region4.Common.DataConnection.DbConnection)
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "ItsAudiencesDelete";
                        cmd.Parameters.AddWithValue("@obj_id", this.ObjId);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        protected void MapFieldsToParams(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@obj_id", ObjId);
            cmd.Parameters.AddWithValue("@amount", Amount);
            cmd.Parameters.AddWithValue("@itm_id", AudienceName);
            cmd.Parameters.AddWithValue("@item_id", Audience_Id);
            cmd.Parameters.AddWithValue("@hours", Hours);
            cmd.Parameters.AddWithValue("@hour_id", HourId);
        }

        #endregion
    }
}

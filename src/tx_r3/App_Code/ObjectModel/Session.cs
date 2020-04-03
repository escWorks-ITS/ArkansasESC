using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace escWeb.tx_r3.ObjectModel
{
    [Serializable]
    public class Session : region4.ObjectModel.Session
    {
        private string _dimensions = string.Empty;
        public string Dimensions { get { return this._dimensions; } }

        private string _standards = string.Empty;
        public string Standards { get { return this._standards; } }

        public Session(int session_id) : base(session_id)
        {
                    
        }


        protected override void LoadCustomerData(SqlDataReader reader)
        {
            this._allowPO = (bool)reader["allowPO"];
            this._dimensions = reader["dimensions"].ToString();
            this._standards = reader["standards"].ToString();

            //Added by VM 4-26-2017
            this._PrevSessionID = (int)(reader["PrerequisiteSessionID"] == DBNull.Value ? -1 : reader["PrerequisiteSessionID"]);
            this._NextSessionID = (int)(reader["NextSessionID"] == DBNull.Value ? -1 : reader["NextSessionID"]);
           
        }

        //Added by VM 4-26-2017
        public override int Limit
        {
            get
            {
                if (IsSelfPacedOnline || (IsOnDemandOnline && _limit == 0))//If it is 0, we treat it as unlimited
                    return 999999;
                else
                    return _limit;
            }
        }

        //public override DateTime RegistrationEndDate
        //{
        //    get
        //    {
        //        if (_regEnd == region4.ObjectModel.modelConstants.DefaultMaxDateTime)
        //        {
        //            DateTime time;
        //            if (!region4.escWeb.SiteVariables.EndRegistrationAtMidnight)
        //                time = (IsOnline || IsMultiVenueOnline) ? new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndDate.Hour, EndDate.Minute, EndDate.Second)
        //                    : new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartDate.Hour, StartDate.Minute, StartDate.Second);
        //            else
        //                time = (IsOnline || IsMultiVenueOnline) ? new DateTime(EndDate.Year, EndDate.Month, EndDate.Day)
        //                    : new DateTime(StartDate.Year, StartDate.Month, StartDate.Day);

        //          //  return time.AddHours(-region4.escWeb.SiteVariables.NumOfHoursBeforeRegistrationClosed);
        //              return this.StartDate.AddHours(-region4.escWeb.SiteVariables.NumOfHoursBeforeRegistrationClosed);
        //        }
        //        else
        //        {
        //            return _regEnd;
        //        }
        //    }

        //}


        //public override string RegistrationStatus(System.Web.HttpContext context, region4.escWeb.BasePage page)
        //{
        //    if (context.User.Identity.IsAuthenticated && this.IsUserRegistered(page.CurrentUser.Sid))
        //        return String.Format("You are currently registered for this {0}", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //    if (context.User.Identity.IsAuthenticated && this.IsUserOnWaitingList(page.CurrentUser.Sid))
        //        return String.Format("You are currently on the waiting list for this {0}", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //    else if (DateTime.Now > this.RegistrationEndDate)
        //        return String.Format("Registration for this {0} has ended", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //    else if (this.SessionFull)
        //    {
        //        if (region4.escWeb.SiteVariables.ObjectProvider.DisplayWaitingListButton(this, page, context))
        //            return String.Format("This {0} is full. If you would like to be added to the waiting list for this {0}, please click on the Waiting List button.", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //        else
        //            return String.Format("This {0} is full.", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //    }
        //    else if (page.ShoppingCart.Contains(region4.escWeb.SiteVariables.ObjectProvider.ReturnSessionRegistration(this, page.CurrentUser)))
        //        return String.Format("This {0} is in your cart", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //    else if (this.RegistrationStartDate > DateTime.Now)
        //        return String.Format("Registration for this {2} begins at {0:t} on {1}", this.RegistrationStartDate, this.RegistrationStartDate.ToLongDateString(), region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //    else if (DateTime.Now < this.RegistrationEndDate)
        //        return String.Format("Registration ends at {0:t} on {1}", this.RegistrationEndDate, this.RegistrationEndDate.ToLongDateString());
        //    else
        //        return String.Format("Registration for this {0} has ended", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        //}

    }
}
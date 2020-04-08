using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CoopCalendar : region4.escWeb.BasePages.Catalog.calendar_aspx
{
    protected override void AssignControls()
    {
        //Calendar Control
        base._calendar = cal1;
        this._calendarType = "external";
    }
}
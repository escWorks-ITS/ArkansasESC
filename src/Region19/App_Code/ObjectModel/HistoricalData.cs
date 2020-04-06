using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace escWeb.tx_r19.ObjectModel
{
    /// <summary>
    /// Summary description for AttendeeInfo
    /// </summary>
    [Serializable]
    public class HistoricalData : region4.ObjectModel.HistoricalData
    {
        public HistoricalData(DataRow reader)
            : base(reader)
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public override HtmlTableRow ReturnHistoricalDataRow(bool altRow)
        {
            HtmlTableRow row = new HtmlTableRow();
            row.ID = "HtmlTableRow_" + _obj_id;
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].InnerText = _SessionID;
            row.Cells[1].InnerText = _SessionTitle;
            row.Cells[2].InnerText = _SessionStartDate.ToShortDateString();
            PlaceHolder pLinks = new PlaceHolder();
            LinkButton link;
            link = new LinkButton();
            link.Text = "Certificate";
            link.CssClass = "link";
            link.ID = "showCertificate_" + this._obj_id;
            link.CommandArgument = this._obj_id + "|" + "1045";
            link.Click += new EventHandler(certificateLink_Click);
            AddLink(pLinks, link);
            row.Cells[3].Controls.Add(pLinks);
            return row;
        }
    }
}
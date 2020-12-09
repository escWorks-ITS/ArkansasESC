<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="calendar.aspx.cs" Inherits="catalog_calendar" Title="Untitled Page" %>
<%@ Register TagPrefix="myControl" Namespace="escWeb.ar_esc.ObjectModel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainBody" Runat="Server"><a name="MainBody"></a>
    <span style="padding-right: 10px;"><button type="button" onclick="javascript:history.back()" class="formInput btn btn-ARESCblue btn-lg" role="button" style="width: 130px; font-size:small" ToolTip="Click here to go to previous page.">Previous</button></span>
    <br /><br />
    <script type="text/javascript">
    $(document).ready(function () {

 
        window.onorientationchange = function () { location.reload() };

        $('span ul').wrap('<div class="outer"/>').contents().unwrap();
        $('span .outer li').wrap('<div class="item"/>').contents().unwrap();

        if ($(window).width() < 415) {
            $("#displayButton").show();
        }

        var getUrlParameter = function getUrlParameter(sParam) {
            var sPageURL = window.location.search.substring(1),
            sURLVariables = sPageURL.split('&'),
            sParameterName,
            i;

            for (i = 0; i < sURLVariables.length; i++) {
                sParameterName = sURLVariables[i].split('=');

                if (sParameterName[0] === sParam) {
                    return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
                }
            }
        };

        var currentMonth = new Date().getMonth();
        var whatYear = new Date().getFullYear();
        var currentYear = new Date().getFullYear();
        var nextYear = new Date().getFullYear() + 1;

        var monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec", "Break"];

        if (monthNames[currentMonth] != 'Break') {
            $("#one").text(monthNames[currentMonth]);
            //currentMonth++;
            //$("#one").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
			$("#one").prop("href", "?location=<%=Session["location"] %>" + "&iscooperative=<%=Session["iscoop"] %>&date=" + ++currentMonth + "/1/" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#one").text(monthNames[currentMonth]);
            currentMonth++;
            //$("#one").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
			$("#one").prop("href", "?location=<%=Session["location"] %>" + "&iscooperative=<%=Session["iscoop"] %>&date=" + ++currentMonth + "/1/" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#two").text(monthNames[currentMonth]);
            currentMonth++;
            $("#two").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#two").text(monthNames[currentMonth]);
            currentMonth++;
            $("#two").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#three").text(monthNames[currentMonth]);
            currentMonth++;
            $("#three").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#three").text(monthNames[currentMonth]);
            currentMonth++;
            $("#three").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#four").text(monthNames[currentMonth]);
            currentMonth++;
            $("#four").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#four").text(monthNames[currentMonth]);
            currentMonth++;
            $("#four").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#five").text(monthNames[currentMonth]);
            currentMonth++;
            $("#five").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#five").text(monthNames[currentMonth]);
            currentMonth++;
            $("#five").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#six").text(monthNames[currentMonth]);
            currentMonth++;
            $("#six").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#six").text(monthNames[currentMonth]);
            currentMonth++;
            $("#six").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#seven").text(monthNames[currentMonth]);
            currentMonth++;
            $("#seven").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#seven").text(monthNames[currentMonth]);
            currentMonth++;
            $("#seven").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#eight").text(monthNames[currentMonth]);
            currentMonth++;
            $("#eight").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#eight").text(monthNames[currentMonth]);
            currentMonth++;
            $("#eight").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#nine").text(monthNames[currentMonth]);
            currentMonth++;
            $("#nine").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#nine").text(monthNames[currentMonth]);
            currentMonth++;
            $("#nine").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#ten").text(monthNames[currentMonth]);
            currentMonth++;
            $("#ten").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#ten").text(monthNames[currentMonth]);
            currentMonth++;
            $("#ten").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#eleven").text(monthNames[currentMonth]);
            currentMonth++;
            $("#eleven").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#eleven").text(monthNames[currentMonth]);
            currentMonth++;
            $("#eleven").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
        }
        if (monthNames[currentMonth] != 'Break') {
            $("#twelve").text(monthNames[currentMonth]);
            currentMonth++;
            //$("#twelve").prop("href", "?month=" + currentMonth + "&year=" + whatYear);
			$("#twelve").prop("href", "?location=<%=Session["location"] %>" + "&iscooperative=<%=Session["iscoop"] %> &date=12/1/" + whatYear);
            //$("#twelve").prop("href", "?location=99&iscooperative=1&date=12/1/2020");

        }
        else {
            currentMonth = 0;
            whatYear = nextYear;
            $("#twelve").text(monthNames[currentMonth]);
            currentMonth++;
            //$("#twelve").prop("href", "?month=" + currentMonth + "&year=" + nextYear);
        }

        $(".monthButton").click(function () {
            $('.monthButton').removeClass('selected');
            sessionStorage.setItem('mthSelected', $(this).attr("id"));
        });
        $('#' + sessionStorage.getItem('mthSelected')).addClass('selected');
    });
</script>

<%--           <div id="displayButton" style="display: none;">
             <div class='container'>
               <div class='row'>
                    <div class='col-xs-2'><a class='monthButton btn' id='one'></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='two'></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='three'></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='four'></a></div>
               </div>
               <div class='row'>
                    <div class='col-xs-2'><a class='monthButton btn' id='five'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='six'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='seven'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='eight'></></a></div>
                </div>
               <div class='row'>
                    <div class='col-xs-2'><a class='monthButton btn' id='nine'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='ten'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='eleven'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='twelve'></></a></div>
               </div>
             </div>
           </div>--%>

<div class="CalendarDesktop">
    <table role="presentation" width="100%" style="border-collapse: collapse;">
        <tr>
            <td><asp:Label ID="Labelcoop"
        text="Co-op:"
        AssociatedControlID="ddlcooperative"
        runat="server"></asp:Label>
                <asp:DropDownList ID="ddlcooperative" runat="server" AutoPostBack="true" Width="100%" CssClass="form-control fullWidth smallFont" OnSelectedIndexChanged ="ddlcooperative_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td><asp:Label ID="Labeldistrict"
        text="District:"
        AssociatedControlID="ddldistrict"
        runat="server"></asp:Label>
                <asp:DropDownList ID="ddldistrict" runat="server" AutoPostBack="true" Width="100%" CssClass="form-control fullWidth smallFont" OnSelectedIndexChanged ="ddldistrict_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <br />
        <tr>
        <td colspan="2"><escWorks:Calendar runat="server" ID="cal1" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;" SetDateText="Go"  /></td>
        </tr>
    </table>
</div>
    
<br />

<div class="CalendarMobile col-sm-12 col-lg-5" style="float:right">
    <table role="presentation" width="100%" style="border-collapse: collapse;">
        <tr>
            <td><asp:Label ID="LabelcoopMobile"
        text="Co-op:"
        AssociatedControlID="ddlcooperativeMobile"
        runat="server"></asp:Label>
                <asp:DropDownList ID="ddlcooperativeMobile" runat="server" AutoPostBack="true" Width="100%" CssClass="form-control fullWidth smallFont" OnSelectedIndexChanged ="ddlcooperativeMobile_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LabeldistrictMobile"
        text="District:"
        AssociatedControlID="ddldistrictMobile"
        runat="server"></asp:Label>
                <asp:DropDownList ID="ddldistrictMobile" runat="server" AutoPostBack="true" Width="100%" CssClass="form-control fullWidth smallFont" OnSelectedIndexChanged ="ddldistrictMobile_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
<%--        <tr>
        <td colspan="2"><escWorks:Calendar runat="server" ID="cal2" PreviousText="&lt;&lt; Previous" NextText="Next &gt;&gt;" SetDateText="Go"  /></td>
        </tr>--%>
    </table>
    <br />
               <div id="displayButton" style="display: none;">
             <div class='container'>
               <div class='row'>
                    <div class='col-xs-2'><a class='monthButton btn' id='one'></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='two'></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='three'></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='four'></a></div>
               </div>
               <div class='row'>
                    <div class='col-xs-2'><a class='monthButton btn' id='five'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='six'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='seven'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='eight'></></a></div>
                </div>
               <div class='row'>
                    <div class='col-xs-2'><a class='monthButton btn' id='nine'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='ten'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='eleven'></></a></div>
                    <div class='col-xs-2'><a class='monthButton btn' id='twelve'></></a></div>
               </div>
             </div>
           </div>

    <br />

    <%--<div id="displayButton" style="display: none;">
        <div class='container'>
            <div class='row'>
                <div class='col-xs-2'><a class='monthButton btn' id='one'></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='two'></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='three'></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='four'></a></div>
            </div>
            <div class='row'>
                <div class='col-xs-2'><a class='monthButton btn' id='five'></></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='six'></></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='seven'></></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='eight'></></a></div>
            </div>
            <div class='row'>
                <div class='col-xs-2'><a class='monthButton btn' id='nine'></></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='ten'></></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='eleven'></></a></div>
                <div class='col-xs-2'><a class='monthButton btn' id='twelve'></></a></div>
            </div>
        </div>
    </div>--%>
<br />
    <div><h3 style="line-height:1.6">
        <myControl:MobileCalendar2 runat="server" ID="MobileCalendar"  />
        </h3>
    </div>
</div>
</asp:Content>


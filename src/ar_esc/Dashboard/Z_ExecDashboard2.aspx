<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExecDashboard.aspx.cs" Inherits="ExecDashboard" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<!DOCTYPE html>
<html lang="en-us">
<head>
    <title>Executive Dashboard</title>
    <style type="text/css">
        body
        {
            background: #42413C;
            margin: 0;
            padding: 0;
            color: #000;
            font-weight: bold;
            background-color: #FFFFFF;
            font-family: Verdana, Arial, Helvetica, sans-serif;
            font-size: 1em;
            line-height: normal;
            font-variant: normal;
            text-transform: none;
        }
        
        ul, ol, dl
        {
            padding: 0;
            margin: 0;
            font-variant: normal;
            text-transform: none;
        }
        .container .content p
        {
            font-size: 16px;
            font-family: Arial, Helvetica, sans-serif;
            font-variant: normal;
            text-transform: none;
        }
        h1, h2, h3, h4, h5, h6, p
        {
            margin-top: 0;
            padding-right: 15px;
            padding-left: 15px;
            color: #000;
            font-size: 16px;
            font-family: Arial, Helvetica, sans-serif;
            font-variant: normal;
            text-transform: none;
        }
        a img
        {
            border: none;
        }
        
        a:link
        {
            color: #005695;
            text-decoration: none;
        }
        a:visited
        {
            color: #005695;
            text-decoration: none;
        }
        a:hover, a:active, a:focus
        {
            text-decoration: none;
            color: #3399ff;
            font-size: 16px;
            font-family: Arial, Helvetica, sans-serif;
        }
        
        .container
        {
            width: 99%;
            background: #FFFFFF;
            margin: 0 auto;
        }
        
        header
        {
            background-color: #005695;
        }
        
        
        .sidebar1
        {
            float: left;
            width: 180px;
            background: #EADCAE;
            padding-bottom: 10px;
        }
        .content
        {
            width: 100%;
            float: none;
            padding-top: 10px;
            padding-right: 0;
            padding-bottom: 10px;
            padding-left: 0;
            color: #005695;
            font-size: 18px;
        }
        aside
        {
            float: left;
            width: 180px;
            background: #EADCAE;
            padding: 10px 0;
        }
        
        
        .content ul, .content ol
        {
            padding: 0 15px 15px 40px;
        }
        
        
        nav ul
        {
            list-style: none;
            border-top: 1px solid #666;
            margin-bottom: 15px;
        }
        nav ul li
        {
            border-bottom: 1px solid #666;
        }
        nav ul a, nav ul a:visited
        {
            padding: 5px 5px 5px 15px;
            display: block;
            width: 160px;
            text-decoration: none;
            background: #C6D580;
        }
        nav ul a:hover, nav ul a:active, nav ul a:focus
        {
            background: #ADB96E;
            color: #FFF;
        }
        
        footer
        {
            padding: 10px 0;
            position: relative;
            clear: both;
            background-color: #99CCFF;
            color: #fff;
            text-decoration: none;
            a: link text decoration: none;
            color: #ffffff;
            a: visited color:#ffffff;
            a: hover color:#ffffff;
        }
        
        .fltrt
        {
            float: right;
            margin-left: 8px;
        }
        .fltlft
        {
            float: left;
            margin-right: 8px;
        }
        .clearfloat
        {
            clear: both;
            height: 0;
            font-size: 1px;
            line-height: 0px;
        }
        
        
        header, section, footer, aside, nav, article, figure
        {
            display: block;
            font-size: 12px;
        }
        #links
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            font-style: normal;
            font-weight: normal;
            font-variant: normal;
            color: #005695;
            text-decoration: none;
            background-color: #FFF;
            padding: 3px;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: solid;
            border-right-style: solid;
            border-bottom-style: solid;
            border-left-style: solid;
            position: relative;
        }
        .container .content section table tr td div p img
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .container .content section table tr td div
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        .container footer p
        {
            color: #FFF;
            a: link=#fff;
            a: visited=#fff;
            a: hover=#fff;
        }
        .container
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
            font-style: normal;
            line-height: normal;
            font-weight: bold;
            font-variant: small-caps;
            color: #FFF;
            text-decoration: none;
        }
        body, td, th
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 16px;
        }
        a
        {
            font-family: Arial, Helvetica, sans-serif;
        }
        h1
        {
            font-size: 18px;
            color: #FFF;
        }
        h2
        {
            font-size: 18px;
        }
        h4
        {
            font-size: 14px;
        }
        h5
        {
            font-size: 12px;
        }
        h6
        {
            font-size: 10px;
            color: #FFF;
        }
    </style>
   
</head>
<body link="#005695" vlink="#3399ff" alink="#3399ff">
    <form id="form1" runat="server">
    <div class="container">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true" runat="server">
        </asp:ScriptManager>
        <header>
    <br /><br />
    <h1 align="center"><em>Welcome to the Executive Dashboard</em></h1>
    <p align="center">&nbsp;</p>
  </header>
        <h5 align="center">
            Powered by:</h5>
        <h1 align="center">
            <a href="#">
                <img src="escworks_logo_lrg.png" width="198" alt="escWorks Logo" height="42" align="absmiddle"></a></h1>
        <br /><br />
        <telerik:RadTabStrip ID="radTabStrip" AutoPostBack="true" runat="server" MultiPageID="RadMultiPage1"
            SelectedIndex="0">
            <Tabs>
                <telerik:RadTab runat="server" Text="About the Exective Dashboard" Value="About the Exective Dashboard"
                    PostBack="false">
                </telerik:RadTab>
                <telerik:RadTab runat="server" Text="Executive Dashboard" Value="Executive Dashboard"
                    PostBack="false">
                </telerik:RadTab>

                

             <%--     <telerik:RadTab runat="server" Text="PD Year to Year Comparison " Value="PD Year to Year Comparison "
                    PostBack="false">
                </telerik:RadTab>--%>
                
                 
            </Tabs>
        </telerik:RadTabStrip>
        <telerik:RadMultiPage runat="server" ID="RadMultiPage1" SelectedIndex="0">
            <telerik:RadPageView runat="server" ID="RadPageView1">
                <section>
      <p></p><h2 align="center">About the Exective Dashboard...</h2>
       <h4 align="center"><em>Executive Dashboard requires an HTML 5 compatible browser such as Chrome (the preferred choice), Firefox, or Internet Explorer 10 or higher</em></h4>
      <table width="100%" border="0" cellspacing="2" cellpadding="0" summary="Links to ESC Standards and Indicators, User Guide, Data Description documents">
        <caption>&nbsp;
        </caption>
        <tr>
          <th scope="col"><p><img src="documentation.png" width="38" height="49" alt="Data Sources"></p>
          <p><a href="escWorks Executive Dashboard Guide ver2.pdf" title="How to Use the Dashboard" target="_new">• How to Use the Dashboard</a></p>
          <p></p>
          <p></p>
          <p></p></th>
         
       
        </tr>
      </table>
      <hr/>
    </section>
                <h2 align="center">
                    About the Data...</h2>
                <h5 align="center">
                    The data within the escWorks Dashboard is updated on a nightly basis. All data should
                    be current as of 5:00 AM the day of viewing.</h5>
                <hr>
                </section>
                <section>
    </section>
                <section>
      <h2 align="center">Helpful Information...</h2>
      <h5 align="center">Please note: Revisions to the escWorks Dashboard will be made in order to better inform our customers.</h5>
      <h3 align="center">Have a question? Contact us at: <span style="color:white; link color:white; visited color:white; hover color:white; active color:black"><a href="mailto:helpdesk@esc4.net">helpdesk@esc4.net</a></span></h3>
    </section>
            </telerik:RadPageView>
             <telerik:RadPageView ID="RadPageView2" height="800px" runat="server">
                
                <h2><p></p>
                    Executive Dashboard - </h2>
                
               
                    <iframe frameborder="1" scrolling="yes" width="99.7%" height="800px" radius-r="5px" id="iframe1" 
                        src="https://www.escworks.app/sense/app/bc59defc-9e0e-4bc6-9802-76560c98bd42">
                    </iframe>
                
                <hr width="90%"/>
                 <h5>
             Copyright © 2014-
<script language="JavaScript" type="text/javascript">
    now = new Date
    theYear = now.getYear()
    if (theYear < 1900)
        theYear = theYear + 1900
    document.write(theYear)
</script>
escWorks.NET<sup>®</sup> All Rights Reserved
        </h5>
                
            </telerik:RadPageView>
             
           

       <%--       <telerik:RadPageView ID="RadPageView4" height="800px" runat="server">
                
                <h2><p></p>
                    PD Year to Year  Comparison - </h2>
                
                
                    <iframe frameborder="1" scrolling="yes" width="99.7%" height="800px" radius-r="5px" id="iframe3" 
                        src="https://dashboard.escworks.net/app/main#/dashboards/5a2012d79334fdd81c000189?folder=5a007a1228a238e80c00044f&embed=true&r=true&l=false">
                    </iframe>
                
                <hr width="90%"/>
                   <h5>
             Copyright © 2014-
<script language="JavaScript" type="text/javascript">
    now = new Date
    theYear = now.getYear()
    if (theYear < 1900)
        theYear = theYear + 1900
    document.write(theYear)
</script>
escWorks.NET<sup>®</sup> All Rights Reserved
        </h5>
                
            </telerik:RadPageView>--%>
           
             <%-- <telerik:RadPageView ID="RadPageView6" height="600px" runat="server">
                
                <h2><p></p>
                    COOPs - </h2>
                
               
                    <iframe frameborder="1" scrolling="yes" width="99.7%" height="600px" radius-r="5px" id="iframe5" 
                        src="https://dashboard.escworks.net/app/main#/dashboards/57573aca9b1908bc3a00024a?folder=56d98ab3586e510814000396&embed=true">
                    </iframe>
                
                <hr width="90%"/>
                   <h5>
            Copyright © 2014-16 escWorks.NET<sup>®</sup> All Rights Reserved
        </h5>
                
            </telerik:RadPageView>--%>
             
             
             </telerik:RadMultiPage>
    </div>
    </form>
</body>
</html>

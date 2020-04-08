<%@ Application Language="C#" Inherits="region4.escWeb.global_aspx" %>

<script runat="server">
       
    protected override void LoadObjectProvider()
    {
        Application["objectProvider"] = new ObjectProvider();
    }

    protected override void LoadReportsProvider()
    {
        Application["commonReportsProvider"] = new escWeb.ar_esc.ObjectModel.CommonReports();
    }
   
       
</script>

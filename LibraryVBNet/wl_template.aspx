<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="wl_template.aspx.vb" Inherits="wl" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="Compass.master" %>
       
       
 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server" EnableViewState="true">      
        <asp:Label ID="bread_label" runat="server" Text=""></asp:Label><br /><br />
         <h2 align="center"><asp:Label ID="wl_title" runat="server" Text=""></asp:Label></h2>
        
        
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
 
        <div align="center">
        <asp:PlaceHolder ID="MenuItems" runat="server"></asp:PlaceHolder></div>
        <br/> 
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
<br/> 
   


<script type="text/javascript">

var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");

document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));

</script>

<script type="text/javascript">

try {

var pageTracker = _gat._getTracker("UA-7448690-1");

pageTracker._trackPageview();

} catch(err) {}</script>
</asp:Content>

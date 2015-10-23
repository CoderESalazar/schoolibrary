<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="user_area.aspx.vb" Inherits="user_area1" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>


 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
<div>  

      <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
      <br/> 
      <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
    <asp:Label ID="NoQs" runat="server" Text=""></asp:Label>  
    <asp:Label ID="LibGuides" runat="server" Text=""></asp:Label>
  
  <p>Have you checked out these other areas of the Library? <a style="color:#445577;" target="_blank" href="/dw_template.aspx?parent_id=8">Databases</a>, <a target="_blank" style="color:#445577;" href="/research_help/default.aspx">Library Guides</a>, and <a style="color:#445577;" target="_blank" href="/dw_template.aspx?parent_id=170">Learn the Library</a>.</p> 
  
</div>

 </asp:Content>





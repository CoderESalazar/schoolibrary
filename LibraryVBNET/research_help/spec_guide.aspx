<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="spec_guide.aspx.vb" Inherits="research_help_spec_guide" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
     <asp:Label ID="SpecLinks" runat="server" Text=""></asp:Label>
    <h2 align="center"><asp:Label ID="title_page" runat="server" Text=""></asp:Label></h2>
                  
   <div style="margin: 0px 5px 0px 5px;">
        <br/>
        <asp:PlaceHolder ID="Spec_Guide" runat="server"></asp:PlaceHolder>
    
    </div>
 
</asp:Content>   

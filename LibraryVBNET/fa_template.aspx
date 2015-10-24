<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="fa_template.aspx.vb" Inherits="fa" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="Compass.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server">
<asp:Label ID="bread_label" runat="server" Text=""></asp:Label><br /> <br /> 
 <h2 align="center"><asp:Label ID="fa_title" runat="server" Text=""></asp:Label></h2>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        

</asp:Content>
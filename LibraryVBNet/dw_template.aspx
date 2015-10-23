<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="dw_template.aspx.vb" Inherits="dw_template" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="Compass.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" Runat="Server" EnableViewState="true">
 <asp:Label ID="bread_label" runat="server" Text=""></asp:Label><br /><br /> 
    <h2 align="center"><asp:Label ID="dw_title" runat="server" Text=""></asp:Label></h2>
    
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False">
        <Columns>
            <asp:BoundField HtmlEncode="false" DataField="text_dw"/>  
        </Columns>
    
   </asp:GridView>

</asp:Content>

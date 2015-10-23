<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="search" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">       
   
        <asp:Label ID="bread_crumb" runat="server" Text=""></asp:Label>
        
        <h3><asp:Label ID="SearchResults" runat="server" Text=""></asp:Label></h3>
        
        <asp:Label ID="NoResults" runat="server" Text=""></asp:Label>
        
        <asp:Label ID="NothingEntered" runat="server" Text=""></asp:Label>
       <br/> 
     
        <asp:GridView ID="GridView1" runat="server" RowStyle-Height="40px" AutoGenerateColumns="false" ShowHeader="False" GridLines="None">
            
            <Columns>
                             
                <asp:HyperLinkField DataNavigateUrlFields="q_id" DataTextField="lib_q_edit" DataNavigateUrlFormatString="/ncu_kb/kb_view.aspx?q_id={0}">
                
                 <ControlStyle forecolor="#445577"></ControlStyle>
                </asp:HyperLinkField>
                                
            </Columns>
        <AlternatingRowStyle BackColor="#E0E0E0" />
      
        </asp:GridView>
   
    </asp:Content>
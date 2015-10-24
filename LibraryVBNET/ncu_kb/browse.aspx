<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="browse.aspx.vb" Inherits="browse" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
  

    <div> 
              
       <asp:Label ID="no_q_found" runat="server" Text=""></asp:Label>
       <asp:Label ID="bread_crumb" runat="server" Text=""></asp:Label>
        
       <h3><asp:Label ID="cat_name" runat="server" Text=""></asp:Label></h3>
   
        <asp:GridView ID="GridView1" RowStyle-Height="40px" runat="server" AutoGenerateColumns="False" ShowHeader="False" GridLines="Horizontal" BorderWidth="0px">
            <Columns>
                             
                <asp:HyperLinkField DataNavigateUrlFields="q_id" DataTextField="lib_q_edit" DataNavigateUrlFormatString="/ncu_kb/kb_view.aspx?q_id={0}">
                <ControlStyle ForeColor="#445577"></ControlStyle> 
                </asp:HyperLinkField>
                                
            </Columns>
            <AlternatingRowStyle BackColor="#E0E0E0" />
        
        
        
        
        </asp:GridView>
  
        </div> 
    <br /> 
    
    </asp:Content>

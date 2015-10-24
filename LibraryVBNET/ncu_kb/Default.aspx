<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>



 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">    
 
   
    
    <h2 align="center">Welcome to the Library FAQs</h2>
    
    <p align="center">Find answers to frequently asked questions by searching or browsing the FAQs. For immediate assistance, please click the <a style="color:#445577;" href="/ncu_kb/user/user_page.aspx">Ask a Librarian</a> link. For help with database problems, such as access issues, please search the Library FAQs or submit a 
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../db_prob/default.aspx">database problem form</asp:HyperLink></p> 
    
    <br/> 
    
    <div align="center"> 
        <asp:TextBox ID="TextBox1" KeyPress="True" runat="server"></asp:TextBox>
       
        <asp:Button ID="btnSearch" runat="server" Text="Search" />&nbsp;&nbsp;<asp:Label
            ID="lblSearch" runat="server" Text=""></asp:Label>
     
    <h3>Browse by Available Categories</h3>

        <asp:GridView ID="GridView1" AutoGenerateColumns="False" BorderWidth="0" runat="server" ShowHeader="False">
           <Columns> 
            
                <asp:hyperlinkfield datanavigateurlfields="cat_id" datatextfield="cat_name" datanavigateurlformatstring="browse.aspx?lib_cat={0}"> 
                <ControlStyle forecolor="#445577"></ControlStyle> </asp:hyperlinkfield>
            </Columns>
        
        
        </asp:GridView>
   </div> 
    
    </asp:Content>

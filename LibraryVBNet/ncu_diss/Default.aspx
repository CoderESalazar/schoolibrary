<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
 
     <a name="top"></a>
       <h2 style="color:#00467F;">Northcentral University Dissertations</h2>
                   
                      <asp:Label ID="DissText" runat="server" Text=""></asp:Label>               
            
                   <br/> 
                   <br/> 
            
        <asp:Panel ID="Panel1" runat="server" DefaultButton="SearchButton">
            Search By: <asp:DropDownList ID="SearchSelectDrop" runat="server"> <asp:ListItem>Title</asp:ListItem>
            <asp:ListItem>Author</asp:ListItem><asp:ListItem>Abstract</asp:ListItem>
               
                    </asp:DropDownList>
          
    
                    <asp:textbox ID="searchme" runat="server" Visible="True"></asp:textbox>
                    <asp:button ID="SearchButton" runat="server" text=" Search " Visible="True" />              
                
                 </asp:Panel>
                
                 <br/>      
                <h3>Browse</h3>          
    <!--PlaceHolder2:Displays Menu at top-->  
         <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
       <br/> 
        <div>
        
    <!--PlaceHolder1:Displays page content-->     
        <asp:Label ID="BusLabel" runat="server" Text="" style="color: #702138"></asp:Label>
        <asp:Label ID="EdLabel" runat="server" Text="" style="color: #702138"></asp:Label>
        <asp:Label ID="PsyLabel" runat="server" Text="" style="color: #702138"></asp:Label>
        <asp:Label ID="TechLabel" runat="server" Text="" style="color: #702138"></asp:Label>
        
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
       
       

        </div>

</asp:Content> 

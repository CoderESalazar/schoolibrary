<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="kb_view.aspx.vb" Inherits="kb_view" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>


   <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">     
    
     
     <asp:Label ID="bread_crumb" runat="server" Text=""></asp:Label>
     
     <h3><asp:Label ID="lib_q_edit" runat="server" Text=""></asp:Label></h3>
     <br />
   <b>Resolution:</b> <asp:Label ID="lib_response" runat="server" Text=""></asp:Label>
    <br /> 
    <br /> 
        
    <table> 
        <tr> 
            <td><b>Category Assigned to Question:</b> <asp:Label ID="cat_desc" runat="server" Text=""></asp:Label></td> 
               
        </tr> 
        <tr>
            <td><b>Date and Time Question Submitted:</b> <asp:Label ID="date_time" runat="server" Text=""></asp:Label></td> 
        
        </tr> 
    </table> 
            
 <hr /> 
     
     <p>Did you find the answer to your question?</p> 
     
           <asp:Label ID="btnYes_true" runat="server" Text="True" Visible="false"></asp:Label>
           <asp:Label ID="btnNo_false" runat="server" Text="False" Visible="false"></asp:Label>
     <table> 
     
        <tr> 
        
            <td><asp:Button ID="btnYes" runat="server" Text="Yes" /></td>
            <td><asp:Button ID="btnNo" runat="server" Text="No" /></td> 
            <td><asp:Button ID="btnAsk" runat="server" Text="Ask a Librarian" /></td>
            <!--
            <td><asp:Button ID="fdbk" runat="server" Text="Feedback" /></td>
            --> 
        </tr>
        
     </table> 
         <asp:Label ID="Vwfdbk" runat="server" Text="Thank you. Your response has been recorded." Visible="false"></asp:Label>

    </asp:Content>
<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="fdbk_form.aspx.vb" Inherits="request_forms_fdbk_form" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>


 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">       
        <h2 style="color: #702318;">Library Comments</h2>    

        <p>Hi <asp:Label ID="patron_name" runat="server" Text=""></asp:Label></p> 
        
         
        <textarea rows="10" cols="80" id="comments_box" runat="server"></textarea>
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="comments_box" ErrorMessage="You must enter comments."></asp:RequiredFieldValidator>
        <br/> 
        
        <asp:Button ID="CommentButton" runat="server" Text="Submit" />

    </asp:Content>
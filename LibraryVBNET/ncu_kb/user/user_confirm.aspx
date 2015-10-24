<%@ Page Language="VB" MasterPageFile="~/Compass.master" ValidateRequest="false" AutoEventWireup="false" CodeFile="user_confirm.aspx.vb" Inherits="user_confirm" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>
 
 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
    
    <div style="margin: 10px 10px 10px 10px;font-size:1.2em;">
    <p>Thank you for submitting an Ask a Librarian question. When your question is answered you will receive a notification 
    at the email address you have registered with the University. Please be sure to check
    your junkmail or spam folder for our response. You can also check the unread messages notification 
    located at the top of each page in the Library to see if your question has been answered.</p>
    
    <p>We will try to respond to your question as quickly as possible.</p>
    
    <p>To return to the Library, please click <a href="/">here</a>.</p>
    </div>
 </asp:Content>
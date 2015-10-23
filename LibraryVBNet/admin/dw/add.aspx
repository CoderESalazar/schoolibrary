<%@ Page Language="VB" AutoEventWireup="false" CodeFile="add.aspx.vb" Inherits="admin_dw_add" %>
<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Adding New DW Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h2>Add New DW Page</h2><br /> 
    
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/admin/dw/">Return to DW Table</asp:HyperLink><br />
    
    <br />
    
        Title of DW Page: <asp:TextBox ID="AddDWTitle" Width="150" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="AddDWTitle" runat="server" ErrorMessage="*Please enter title."></asp:RequiredFieldValidator>
        <br /> 
        <br /> 
        
        Enter Text Below: 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="dw_body" runat="server" ErrorMessage="*Please enter page content."></asp:RequiredFieldValidator>
        <br /> 
        <obout:Editor ID="dw_body" runat="server" AutoFocus="false" Appearance="lite" SuppressTab="true" NoUnicode="true" Submit="False" pathprefix="/includes_shared/oboutSuite/Editor/Editor_data/">
        </obout:Editor>
        <br /> <br /> 
        <asp:Button ID="SubBtn" runat="server" Text="Add DW" />
       
    
       
    </div>
    </form>
</body>
</html>

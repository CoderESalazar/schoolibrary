<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit.aspx.vb" Inherits="ncu_kb_alert_admin_edit" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Alert</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Alert Title: <asp:TextBox ID="alert_title" Width="250px" runat="server"></asp:TextBox><br/> 
        
        <obout:Editor ID="alert_mess" Appearance="lite" runat="server" Submit="false" pathprefix="../includes_shared/oboutSuite/Editor/Editor_data/">
        </obout:Editor>
        
        <br/> 
        
        Display: 
        <asp:CheckBox ID="alert_bit" runat="server" />
        
       <br/><br/>
        <asp:Button ID="Button1" runat="server" Text="Update" />
       
    </div>
    </form>
</body>
</html>

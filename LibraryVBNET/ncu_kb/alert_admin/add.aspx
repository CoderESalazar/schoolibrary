<%@ Page Language="VB" AutoEventWireup="false" CodeFile="add.aspx.vb" Inherits="ncu_kb_alert_admin_add" %>
<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library Alert Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    Alert title: 
        <asp:TextBox ID="alert_title" runat="server" Width="250"></asp:TextBox>
      <br/><br/>    
    Alert Message: 
    
        <obout:Editor ID="Editor1" runat="server" Appearance="lite" AutoFocus="false" Submit="False" pathprefix="../includes_shared/oboutSuite/Editor/Editor_data/">
        </obout:Editor>
        
        <br/> 
        
        <asp:Button ID="Button1" runat="server" Text="Add" />
    
    </div>
    </form>
</body>
</html>

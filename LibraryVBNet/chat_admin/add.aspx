<%@ Page Language="vb" AutoEventWireup="false" CodeFile="add.aspx.vb" Inherits="add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Chat Entry</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
        
    
    To start session, click the Start button below. Clicking the start button below makes the chat link available
    on the Library website.<br/> 
    <asp:CheckBox ID="CheckBox1" runat="server" checked="true" Visible="false"/><br/><br/>  
    <asp:Button ID="Button1" runat="server" Text="Start" />
    
    
    </asp:Panel>
    </div>
    </form>
</body>
</html>

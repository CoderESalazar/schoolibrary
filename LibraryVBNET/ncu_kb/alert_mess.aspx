<%@ Page Language="VB" AutoEventWireup="false" CodeFile="alert_mess.aspx.vb" Inherits="ncu_kb_alert_mess" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Library Alert Message</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <p><a href="/admin/default.aspx">Library Admin</a></p> 
    <p><a href="/ncu_kb/alert_admin/add.aspx">Add an alert</a></p> 
      
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="key_id" ItemStyle-Width="50px" DataTextField="key_id" DataTextFormatString="Select" DataNavigateUrlFormatString="/ncu_kb/alert_admin/edit.aspx?key_id={0}"></asp:HyperLinkField>
            <asp:BoundField DataField="alert_title" HeaderText="alert_title" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField DataField="date_time" HeaderText="Letter Date" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
            <asp:BoundField DataField="alert_bit" HeaderText="Display" ItemStyle-HorizontalAlign="Center"></asp:BoundField>
        </Columns>
    
    </asp:GridView>
    
    </div>
    
    </form>
</body>
</html>

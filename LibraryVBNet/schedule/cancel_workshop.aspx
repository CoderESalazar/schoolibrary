﻿<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cancel_workshop.aspx.vb" Inherits="schedule_cancel_workshop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="../default.aspx">Return to Library</asp:HyperLink>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateDeleteButton="True" DataKeyNames="key_id" AutoGenerateColumns="false" Width="80%">
            <Columns>
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="event_date" HeaderText="Registered Workshops" />
                <asp:BoundField DataField="event_details" HtmlEncode="false" HeaderText="Library Workshop Description" />
            </Columns>
  
        </asp:GridView>
    </div>
    </form>
</body>
</html>

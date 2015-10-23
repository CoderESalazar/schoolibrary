<%@ Page Language="VB" AutoEventWireup="false" CodeFile="cmts_vwr.aspx.vb" Inherits="request_forms_cmts_vwr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>NCU Library Comments</title>
</head>
<body style="font-family: Verdana; font-size: .85em;">
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                    <Columns>
                <asp:BoundField DataField="u_name" HeaderText="UserName" />
                <asp:BoundField DataField="notes_comments" HeaderText="Comments" />
                <asp:BoundField DataField="email_address" HeaderText="Email Address" />
                <asp:BoundField DataField="deg_prog" HeaderText="Degree Program" />
                <asp:BoundField DataField="date_time" HeaderText="Date/Time" />
                <asp:BoundField DataField="user_id" HeaderText="UserID" />
                </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>

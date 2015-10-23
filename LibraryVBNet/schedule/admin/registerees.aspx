<%@ Page Language="vb" AutoEventWireup="false" CodeFile="registerees.aspx.vb" Inherits="registerees" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>List of Attendees</title>
</head>
<body>
    <form id="form1" runat="server">
           <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/schedule/admin/default.aspx">Return to Schedule</asp:HyperLink><br/><br/> 
        <asp:HyperLink ID="AddAttendee" runat="server">Add Attendee</asp:HyperLink>
 
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
             <HeaderStyle BackColor="#FFE0C0" />
               <AlternatingRowStyle BackColor="#FFC0C0" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="key_id" ItemStyle-Width="50px" DataTextField="key_id" DataTextFormatString="Delete" DataNavigateUrlFormatString="/schedule/admin/delete.aspx?key_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="email_address" HeaderText="Email"/>
                <asp:BoundField DataField="date_time" HeaderText="Date"/>
            </Columns>
        </asp:GridView>
    
     </div>
    </form>
</body>
</html>
 
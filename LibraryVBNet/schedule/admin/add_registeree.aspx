<%@ Page Language="vb" AutoEventWireup="false" CodeFile="add_registeree.aspx.vb" Inherits="add_registeree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Registeree</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h2>Add Attendee</h2>
        First Name: <asp:TextBox ID="first_name" runat="server"></asp:TextBox><br/> 
        Last Name: <asp:TextBox ID="last_name" runat="server"></asp:TextBox><br/> 
        Email Address: <asp:TextBox ID="email_address" runat="server"></asp:TextBox><br/> 
        <asp:Button ID="Submit" runat="server" Text="Button" />
    
    </div>
    </form>
</body>
</html>

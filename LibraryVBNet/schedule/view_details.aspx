<%@ Page Language="vb" AutoEventWireup="false" CodeFile="view_details.aspx.vb" Inherits="register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Schedule - Email Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <!--
        Hi <asp:Label ID="first_name_invite" runat="server" Text=""></asp:Label> 
        <asp:Label ID="last_name_invite" runat="server" Text=""></asp:Label>! Thanks for registering. 
        -->
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
         
        <asp:Label ID="email_sent" runat="server" Text=""></asp:Label>
        
        <table> 
        
            <tr> 
                <td><asp:TextBox ID="first_name" runat="server" Visible="false"></asp:TextBox></td> 
            </tr>
            <tr> 
                <td><asp:TextBox ID="last_name" runat="server" Visible="false"></asp:TextBox></td> 
                
            </tr>  
             <tr> 
                <td><asp:TextBox ID="email_address" runat="server" Visible="false"></asp:TextBox></td> 
            </tr> 
       
                  
       </table> 
    </div>
    </form>
</body>
</html>

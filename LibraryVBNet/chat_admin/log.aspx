<%@ Page Language="vb" AutoEventWireup="false" CodeFile="log.aspx.vb" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Chat Admin Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel ID="Panel1" runat="server" Visible="false" >
       <h3>Chat Admin Area</h3> 
       
              <p>Return to the <a href="/admin/">LibraryAdmin page</a></p> 
       
       <p><a href="add.aspx">Start Chat Session</a></p>
       

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" PageSize="5">
        
            <HeaderStyle BackColor="#FFE0C0" />
            <AlternatingRowStyle BackColor="#FFC0C0" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="lib_id" DataTextField="lib_id" DataTextFormatString="Select" DataNavigateUrlFormatString="/chat_admin/update.aspx?lib_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="user_id" HeaderText="Librarian" />
                <asp:BoundField DataField="start_time" HeaderText="Start Time" />
                <asp:BoundField DataField="end_time" HeaderText="End Time" />
                <asp:BoundField DataField="lib_chat" HeaderText="Chat Active" />  
              
            </Columns>
        
        
        </asp:GridView>
       
</asp:Panel>
    </div>
    </form>
</body>
</html>

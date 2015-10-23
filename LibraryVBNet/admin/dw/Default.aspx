<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="admin_dw_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3 style="color:darkred;">NCU DW Pages</h3>
    <a href="../default.aspx">Back to Admin Area</a><br />
    <a href="../dw/add.aspx">Add New</a><br />
    
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                AllowSorting="true" OnSorting="GridView1_Sorting" 
                Width="600px">
            <HeaderStyle BackColor="#FFE0C0" /> 
            
            <AlternatingRowStyle BackColor="#FFC0C0" /> 
            <Columns> 
                <asp:HyperLinkField DataNavigateUrlFields="key_id" DataTextField="key_id" DataTextFormatString="Edit" DataNavigateUrlFormatString="/admin/dw/edit.aspx?key_id={0}"></asp:HyperLinkField> 
                <asp:BoundField DataField="key_id" SortExpression="key_id" HeaderText="Primary Key" ItemStyle-HorizontalAlign="Center" />  
                <asp:BoundField DataField="title_dw" SortExpression="title_dw" HeaderText="Page Title" />  
               
           </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>

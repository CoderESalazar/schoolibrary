<%@ Page Language="vb" AutoEventWireup="false" CodeFile="add_cat.aspx.vb" Inherits="add_cat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add Category Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table> 
    
        <tr> 
        
            <td>Create Category: </td><td><asp:TextBox ID="cat_created" runat="server"></asp:TextBox>  </td> 
            
            
        </tr> 
        
        <tr> 
        
            <td><asp:Button ID="btnCatCreate" runat="server" Text="Add Category" /></td> 
            
            
        </tr> 
        
        
  </table>     
    
    
    </div>
    </form>
</body>
</html>

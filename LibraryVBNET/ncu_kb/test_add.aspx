<%@ Page Language="vb" AutoEventWireup="false" CodeFile="test_add.aspx.vb" Inherits="test_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <asp:FileUpload ID="FileUpload1" runat="server" /><br /><br /> 
        <asp:Button ID="btnAdd" runat="server" Text="Upload" />
    
        </div>
    </form>
</body>
</html>

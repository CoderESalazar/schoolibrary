<%@ Page Language="vb" AutoEventWireup="false" CodeFile="add.aspx.vb" Inherits="add" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Schedule - Add</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <table border="0"> 
    
        <tr> 
            <td nowrap>Event Date (ex: 1/1/2008 9:00am):</td> 
            <td><asp:TextBox ID="event_date" runat="server"></asp:TextBox></td> 
        </tr> 
        <tr> 

             <td><asp:Button ID="btnAdd" runat="server" Text="Add Event Date" /></td>
        </tr> 
        
    </table>      
             
             
</div>
    </form>
</body>
</html>

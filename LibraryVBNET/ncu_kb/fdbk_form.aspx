<%@ Page Language="vb" AutoEventWireup="false" CodeFile="fdbk_form.aspx.vb" Inherits="fdbk_form" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Feedback Form</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>Feedback form</h3> 
    
    <table> 
        <tr> 
            <td>Please enter feedback in the box below:</td> 
            
        </tr> 
         <tr>  
            <td><textarea rows="10" cols="80" id="fdbk_desc" runat="server"></textarea></td> 
                    
          </tr> 
     </table> 
     
        <asp:Button ID="fdbkBtn" runat="server" Text="Submit" />
    </div>
    </form>
</body>
</html>

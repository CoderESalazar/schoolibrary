<%@ Page Language="vb" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Chat Admin</title>
</head>
<body>
    <form id="form1" runat="server">
    
    
    <div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">

    
            <p>This is the Library Chat Admin Area. To activate a current session, please place checmark below. To end the session, remove checkmark
            from the checkbox. Adding or removing the checkmark from the checkbox, makes the link on the Library site visible or not visible.</p> 
            
            <p>Activate Library Chat Session  
               <!-- <asp:CheckBox ID="lib_checkBox" Checked="false" runat="server" />--> 
            
            </p> 
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br/> 
                <asp:Button ID="chat_button" runat="server" Text="Activate/Deactivate" />
        
            <br/> 
            
            
        
        </asp:Panel>
    </div>
    </form>
</body>
</html>

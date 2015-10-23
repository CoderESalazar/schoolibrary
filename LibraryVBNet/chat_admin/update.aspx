<%@ Page Language="vb" AutoEventWireup="false" CodeFile="update.aspx.vb" Inherits="update" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Update Chat Grid Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        Remove checkmark to end your session: <asp:CheckBox ID="CheckBox1" checked="true" runat="server" /><br/>
        <br/>  
        Copy and paste chat transcript into box below: 
        <br/>
        <table>
            <tr> 
                <td>  
        <obout:Editor ID="Editor1" runat="server" AutoFocus="false" EnableViewState="true" Appearance="lite" Submit="False" pathprefix="/includes_shared/oboutSuite/Editor/Editor_data/">
        </obout:Editor>
        
                </td> 
                
             </tr>
             
         </table>
        <br/> 
        <br/> 
        <asp:Button ID="Button1" runat="server" Text="Update" />
    </div>
    </form>
</body>
</html>

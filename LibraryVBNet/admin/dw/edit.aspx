<%@ Page Language="VB" AutoEventWireup="false" CodeFile="edit.aspx.vb" Inherits="admin_dw_edit" %>
<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="/admin/dw/">Return to DW Table</a>
        
        <br /> 
        <br /> 
        
        Page Title: <asp:TextBox ID="title_dw" runat="server" Width="200"></asp:TextBox>
        
        <br /> 
        <br /> 
      
       <obout:Editor ID="Editor1" runat="server"  AutoFocus="false" Appearance="lite" SuppressTab="true" NoUnicode="true" Submit="False" pathprefix="../includes_shared/oboutSuite/Editor/Editor_data/">
                <Buttons> 
                   
                       <obout:Method Name="InsertIMG" />
                       <obout:Method Name="ForeColor" />  
                    
                </Buttons>
        </obout:Editor>
        <br /> 
        <br /> 
                
        <asp:Button ID="SubBtn" runat="server" Text="Update" />
        <br /> 
        
        <div align="right">
         <asp:Button ID="deleteDW" runat="server" Text="Delete?" OnClientClick="return confirm('Do you want to Delete?')"/>     
        </div>
        
    </div>
    </form>
</body>
</html>

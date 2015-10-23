<%@ Page Language="vb" AutoEventWireup="false" CodeFile="reassign.aspx.vb" Inherits="reassign" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Re-assign Librarian Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    QuestionID: 
        <asp:Label ID="q_ids" runat="server" Text="Label"></asp:Label>
        
        <br/>
        <br/> 
       
      Re-assigning this question: 
        <asp:Label ID="q_detail" runat="server" Text=""></asp:Label>

     <br /> 
     <br /> 
     Please Select Librarian: <asp:DropDownList ID="lib_drop" runat="server">
        </asp:DropDownList>
        
    <br /> 
    <br /> 
        <asp:Button ID="btnReassign" runat="server" Text="Re-assign" />
    
    
   
    </div>
    </form>
</body>
</html>

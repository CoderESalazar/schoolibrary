<%@ Page Language="vb" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Test Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:DataGrid ID="DataGrid1" AutoGenerateColumns="false"  DataKeyField="event_id" runat="server" >
     
     <Columns>
     <asp:TemplateColumn HeaderText="Event ID">
     <ItemTemplate>
     <%#DataBinder.Eval(Container.DataItem, "event_id")%>
          
      
     </ItemTemplate>
    
     </asp:TemplateColumn>
       <asp:TemplateColumn HeaderText="Library Event">
     <ItemTemplate>
     <%#DataBinder.Eval(Container.DataItem, "lib_event")%>
        
      
     </ItemTemplate>
        <EditItemTemplate>
     <asp:TextBox ID="t1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "lib_event")%>'></asp:TextBox>
     
     
     </EditItemTemplate>
     </asp:TemplateColumn>
       <asp:TemplateColumn>
     <ItemTemplate>
     <asp:LinkButton ID="edit" runat="server" Text="Edit" CommandName="edit"></asp:LinkButton>
     <asp:LinkButton ID="cancel" runat="server" Text="Cancel" CommandName="cancel"></asp:LinkButton>
           <asp:LinkButton ID="delete" runat="server" Text="Delete" CommandName="delete"></asp:LinkButton>
            <asp:LinkButton ID="update" runat="server" Text="Update" CommandName="update"></asp:LinkButton>
      
     </ItemTemplate>
     
     </asp:TemplateColumn>
     
     
     
     </Columns>
     
     </asp:DataGrid>
    </div>
    </form>
</body>
</html>

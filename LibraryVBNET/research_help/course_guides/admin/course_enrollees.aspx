<%@ Page Language="vb" AutoEventWireup="false" CodeFile="course_enrollees.aspx.vb" Inherits="course_enrollees" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Courses and Students</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h3>Courses for which there are students: </h3>
    
    <a href="/">Back to Library Admin</a> <br/> <br/> 
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                AllowPaging="True" PageSize="50" AllowSorting="true" 
                OnPageIndexChanging="grdView1_PageIndexChanging" OnSorting="GridView1_Sorting" 
                HeaderStyle-Wrap="true">
            <HeaderStyle BackColor="#FFE0C0" /> 
            
            <AlternatingRowStyle BackColor="#FFC0C0" /> 
        
        
            <RowStyle HorizontalAlign="Center" />
        
        
            <Columns> 

                
                <asp:BoundField DataField="Num_Learners" SortExpression="Num_Learners" HeaderText="Number of Learners" />  
                <asp:BoundField DataField="course_code" SortExpression="course_code" HeaderText="Courses" />
                  
            
            </Columns>
        
        </asp:GridView>
    
    
    </div>
    </form>
</body>
</html>

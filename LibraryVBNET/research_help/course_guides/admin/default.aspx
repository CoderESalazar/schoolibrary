<%@ Page Language="vb" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Course Guides</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h3>Currently available courses that we have course guides for: </h3> 
    
    <a href="/admin/">Back to Library Admin</a> <br/> <br/>
    
   Search for a guide (e.g. ACT4051) or Creator:  <asp:TextBox ID="course_guide_search" runat="server"></asp:TextBox><asp:Button
       ID="guide_search_button" runat="server" Text="Search" /> <br/> 
 
    <p><a style="font-weight:700;color:darkred;" href="/research_help/course_guides/admin/add.aspx">Add a Course</a> </p>
 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" 
                AllowPaging="True" PageSize="50" AllowSorting="true" 
                OnPageIndexChanging="grdView1_PageIndexChanging" OnSorting="GridView1_Sorting" 
                Width="600px">
            <HeaderStyle BackColor="#FFE0C0" /> 
            
            <AlternatingRowStyle BackColor="#FFC0C0" /> 
            
            
            <Columns> 
                <asp:HyperLinkField DataNavigateUrlFields="guide_id" DataTextField="guide_id" DataTextFormatString="Edit" DataNavigateUrlFormatString="/research_help/course_guides/admin/edit.aspx?guide_id={0}"></asp:HyperLinkField> 
                <asp:BoundField DataField="course_code" SortExpression="course_code" HeaderText="Course Code" />  
                <asp:BoundField DataField="course_name" HeaderText="Course Name" />  
                <asp:BoundField DataField="Enrollees" SortExpression="Enrollees" 
                    HeaderText="Enrollees" ItemStyle-HorizontalAlign="Center" >  
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="company_department_name" SortExpression="company_department_name" HeaderText="Program" />
                <asp:BoundField DataField="display_id" HeaderText="Display" />
                <asp:BoundField DataField="last_name" SortExpression="last_name" HeaderText="Creator" />
                <asp:HyperLinkField DataNavigateUrlFields="guide_id" Target="_blank" DataTextField="guide_id" DataTextFormatString="Guide" DataNavigateUrlFormatString="/research_help/guide.aspx?guide_id={0}" ></asp:HyperLinkField> 
                    
            </Columns>

        
        
        </asp:GridView>
        
        
        
        
    
    </div>
    </form>
</body>
</html>

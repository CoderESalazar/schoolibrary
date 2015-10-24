<%@ Page Language="vb" AutoEventWireup="false" CodeFile="search.aspx.vb" Inherits="search" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Course Guides Search Results Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="/research_help/course_guides/admin/default.aspx">Return to Course Guide Admin Page</a> <br/><br/> 
    
        
    
     Search for a guide (e.g. ACT4051):  <asp:TextBox ID="course_guide_search" runat="server"></asp:TextBox><asp:Button
       ID="guide_search_button" runat="server" Text="Search" /> <br/><br/> 
    
        <asp:Label ID="NoResults" runat="server" Text=""></asp:Label><br/> 
        <asp:Label ID="NothingEntered" runat="server" Text=""></asp:Label><br/> 
    
              <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
            <HeaderStyle BackColor="#FFE0C0" /> 
            
            <AlternatingRowStyle BackColor="#FFC0C0" />
            
            
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="guide_id" DataTextField="guide_id" DataTextFormatString="Edit" DataNavigateUrlFormatString="/research_help/course_guides/admin/edit.aspx?guide_id={0}" ></asp:HyperLinkField>  
                <asp:BoundField DataField="course_code" SortExpression="course_code" HeaderText="Course Code" />  
                <asp:BoundField DataField="guide_title" SortExpression="guide_title" HeaderText="Guide Title" />    
                <asp:BoundField DataField="last_name" SortExpression="display_id" HeaderText="Creator" />
                <asp:HyperLinkField DataNavigateUrlFields="guide_id" DataTextField="guide_id" DataTextFormatString="Guide" Target="_blank" DataNavigateUrlFormatString="/research_help/guide.aspx?guide_id={0}" ></asp:HyperLinkField>                 
            </Columns>

        
        
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>

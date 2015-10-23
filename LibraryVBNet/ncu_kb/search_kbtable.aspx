<%@ Page Language="vb" AutoEventWireup="false" CodeFile="search_kbtable.aspx.vb" Inherits="search_kbtable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Search Results</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="prevLink" runat="server">Return to Previous Page</asp:HyperLink><br/><br/> 
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <HeaderStyle BackColor="#FFE0C0" />
        <AlternatingRowStyle BackColor="#FFC0C0" />
       
        <Columns> 
        <asp:HyperLinkField DataNavigateUrlFields="q_id" DataTextField="q_id" HeaderText="Q ID" DataNavigateUrlFormatString="/ncu_kb/librarian/update.aspx?q_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="lib_date_time" HeaderText="Date/Time" />
                <asp:BoundField DataField="last_name" HeaderText="LLast Name" />
                <asp:BoundField DataField="new_cat" HeaderText="Category" />
                <asp:BoundField DataField="u_last_name" HeaderText="PLast Name" />
                <asp:BoundField DataField="deg_prog" HeaderText="DegProg" />
                <asp:BoundField DataField="course_num" HeaderText="CourseNum" />
                <asp:BoundField DataField="email_sent" HeaderText="Email Sent" />
                <asp:BoundField DataField="q_type" HeaderText="Q Type" />
                
                             
        </Columns>
        </asp:GridView>
    
        
    
    </div>
    </form>
</body>
</html>

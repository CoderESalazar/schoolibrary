<%@ Page Language="vb" AutoEventWireup="false" CodeFile="submitted.aspx.vb" Inherits="submitted" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Submitted Page</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:hyperlink runat="server" navigateurl="/ncu_kb/kb_table.aspx">Return to Admin Area</asp:hyperlink><br /><br />
    
    <div>
    Total Rows Retrieved: <asp:Label runat="server" ID="rowCount" Text=""></asp:Label><br /><br /> 
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="q_id" HeaderText="LibLastName" DataTextField="last_name" DataNavigateUrlFormatString="/ncu_kb/librarian/update.aspx?q_id={0}"></asp:HyperLinkField>
                <asp:BoundField HeaderText="Q ID" SortExpression="q_id" DataField="q_id" />
                <asp:BoundField HeaderText="Date/Time" SortExpression="lib_date_time" DataField="date_time" />
                <asp:BoundField HeaderText="Category" SortExpression="new_cat" DataField="new_cat" />
                <asp:BoundField HeaderText="PLastName" SortExpression="u_last_name" DataField="u_last_name" />  
                <asp:BoundField HeaderText="DegProg" SortExpression="deg_prog" DataField="deg_prog" /> 
                <asp:BoundField HeaderText="CourseNum" SortExpression="course_num" DataField="course_num" />  
                <asp:BoundField HeaderText="Email Sent" DataField="email_sent" />
                <asp:BoundField HeaderText="Q Type" SortExpression="q_type" DataField="q_type" />
               <asp:hyperlinkfield datanavigateurlfields="q_id" datatextfield="file_upload" HeaderText="File Uploaded" datanavigateurlformatstring="file_download.aspx?q_id={0}"> </asp:hyperlinkfield>                             
            </Columns>
            <HeaderStyle BackColor="#FFE0C0" />
            <AlternatingRowStyle BackColor="#FFC0C0" />
        </asp:GridView>
        
        <br /><br /> 
    
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField HeaderText="TotalNumQuestions" DataField="TotalNumQuestions" />
                <asp:BoundField HeaderText="CourseNumber" DataField="CourseNumber" />                        
            </Columns>
            <HeaderStyle BackColor="#FFE0C0" />
            <AlternatingRowStyle BackColor="#FFC0C0" />
        </asp:GridView> 
    
    
    
    </div>
    </form>
</body>
</html>

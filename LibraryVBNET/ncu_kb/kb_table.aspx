<%@ Page Language="vb" AutoEventWireup="false" CodeFile="kb_table.aspx.vb" Inherits="kb_table" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>KnowledgeBase Questions Queue</title>
</head>
<body style="font-family:Calibri;font-size:1em;">
    <form id="form1" runat="server">
    <div>
  
    <a href="/admin/default.aspx">Back to Library Admin Page</a> <br /> 
    <br/> 
   <b>Search by: Patron LastName</b>:
        <asp:TextBox ID="l_name_search" runat="server"></asp:TextBox> OR <b>QID</b> <asp:TextBox ID="q_id_search" Width="45" runat="server"></asp:TextBox>&nbsp; <asp:Button ID="search_qlib_table"
            runat="server" Text="Search" /> <asp:Button Text="Reset" id="btnReset" runat="server"></asp:Button>
   
   <br/> 
   <br/>
        <strong>Search by Keywords: </strong><asp:TextBox ID="searchText1" runat="server"></asp:TextBox>&nbsp;
        <asp:DropDownList ID="boolSearch" runat="server">
            <asp:ListItem Selected="True">AND</asp:ListItem>
            <asp:ListItem>OR</asp:ListItem>
            <asp:ListItem>NOT</asp:ListItem>
        </asp:DropDownList>
            &nbsp;<asp:TextBox id="searchText2" runat="server">
            </asp:TextBox>&nbsp;<asp:Button ID="searchBoolbutt" runat="server" Text="Search" />
             
        <br/><br/>
        
   <b>Search for course:</b>&nbsp;&nbsp;<asp:TextBox ID="search_course" runat="server"></asp:TextBox>&nbsp;FirstDate:&nbsp;&nbsp;
  <asp:TextBox ID="f_date" runat="server" Width="90px"></asp:TextBox>&nbsp;&nbsp;SecondDate:&nbsp;&nbsp;<asp:TextBox ID="s_date" runat="server" Width="90px"></asp:TextBox>&nbsp;<asp:Button ID="course_search" runat="server" Text="Search" />  
        
        
        <br/><br/> 
   <div><a href="/ncu_kb/phone_ref.aspx">Add Phone/Email/In-Person/Chat Question</a></div>
    <h4>Submitted e-Ref Questions</h4> 

        <asp:GridView ID="GridView1" AutoGenerateColumns="False" AllowPaging="true" runat="server" AllowSorting="True" PageSize="10" OnPageIndexChanging="grdView1_PageIndexChanging">
            <HeaderStyle BackColor="#FFE0C0" />
            <AlternatingRowStyle BackColor="#FFC0C0" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="q_id" DataTextField="q_id" DataTextFormatString="Select" DataNavigateUrlFormatString="/ncu_kb/librarian/assign_form.aspx?q_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="q_id" HeaderText="Q ID" />
                <asp:BoundField DataField="date_time" HeaderText="Date/Time" />
                <asp:BoundField DataField="u_first_name" HeaderText="PFirst Name" />
                <asp:BoundField DataField="u_last_name" HeaderText="PLast Name" />
                 
            </Columns>
  
         </asp:GridView>
    <br/> 
    <h4>Phone/Email/In-Person Questions</h4> 
    
        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" AllowSorting="True" PageSize="5" OnPageIndexChanging="grdView1_PageIndexChanging">
        
            <HeaderStyle BackColor="#FFE0C0" />
            <AlternatingRowStyle BackColor="#FFC0C0" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="q_id" DataTextField="q_id" DataTextFormatString="Select" DataNavigateUrlFormatString="/ncu_kb/librarian/default.aspx?q_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="q_id" HeaderText="Q ID" />
                <asp:BoundField DataField="date_time" HeaderText="Date/Time" />
                <asp:BoundField DataField="u_first_name" HeaderText="PFirst Name" />
                <asp:BoundField DataField="u_last_name" HeaderText="PLast Name" />
                <asp:BoundField DataField="q_type" HeaderText="Q Type" />  
                <asp:BoundField DataField="lib_last_name" HeaderText="LLast Name" /> 
            </Columns>
        
        </asp:GridView>
    
    
    
    <br /> 
    
    

       <h4>Librarian Assigned Questions</h4> 

        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="true" PageSize="5" OnPageIndexChanging="grdView3_PageIndexChanging" OnSorting="GridView3_Sorting">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="q_id" HeaderText="LibLastName" DataTextField="last_name" DataNavigateUrlFormatString="/ncu_kb/librarian/update.aspx?q_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="q_id" SortExpression="q_id" HeaderText="Q ID" />
                <asp:BoundField DataField="lib_date_time" HeaderText="Date/Time" />
                <asp:BoundField DataField="new_cat" HeaderText="Category" />
                <asp:BoundField DataField="u_last_name" SortExpression="u_last_name" HeaderText="PLastName" />
            </Columns>
            <HeaderStyle BackColor="#FFE0C0" />
            <AlternatingRowStyle BackColor="#FFC0C0" />
       
        
       
        </asp:GridView>
   
   <br /> 
   
   <h4>Questions Submitted to the KB</h4> 

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" PageSize="10" OnPageIndexChanging="grdView2_PageIndexChanging" OnSorting="GridView2_Sorting">
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
    <br /> 
    
    <h4>Questions Not Submitted to KB</h4>
    
        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" AllowPaging="True" AllowSorting="true" PageSize="10" OnPageIndexChanging="grdView4_PageIndexChanging" OnSorting="GridView4_Sorting">
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
    <br />        

    </div>
    </form>
</body>
</html>

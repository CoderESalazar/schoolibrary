<%@ Page Language="vb" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Schedule</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       <p>Return to the <a href="/admin/">Library Admin</a></p> 
   <p>Library Admin Schedule - <a href="add.aspx">Add</a>.</p> 
   
   <asp:GridView ID="GridView1" runat="server"  
           AutoGenerateColumns="False" AllowPaging="true" AllowSorting="True" 
           PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="GridView1_Sorting" Width="700px">
            <HeaderStyle BackColor="#FFE0C0" />
               <AlternatingRowStyle BackColor="#FFC0C0" />
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="event_id" ItemStyle-Width="50px" DataTextField="event_id" DataTextFormatString="Select" DataNavigateUrlFormatString="/schedule/admin/edit.aspx?event_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="event_id" HeaderText="EventID" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="event_date" HeaderText="Event Date" SortExpression="event_date"/>
                <asp:BoundField DataField="total_attendees" HeaderText="Total Attendees" ItemStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="last_name" HeaderText="InstructorName"/>
                <asp:HyperLinkField DataNavigateUrlFields="event_id" ItemStyle-Width="50px" ItemStyle-HorizontalAlign="Center" DataTextField="Registerees" HeaderText="Registerees" DataNavigateUrlFormatString="/schedule/admin/registerees.aspx?event_id={0}"></asp:HyperLinkField>
                <asp:BoundField DataField="event_details" HeaderText="Event Details" 
                    HtmlEncode="false" ItemStyle-Wrap="true">
                    <ItemStyle Wrap="True"></ItemStyle>
                </asp:BoundField>
              
                 
            </Columns>
        </asp:GridView>

        
        

    </div>
    </form>
      

</body>
</html>

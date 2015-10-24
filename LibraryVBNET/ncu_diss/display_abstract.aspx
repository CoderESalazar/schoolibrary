<%@ Page Language="vb" AutoEventWireup="false" CodeFile="display_abstract.aspx.vb" Inherits="display_abstract" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Northcentral University Library</title>
</head>
<body style="font-family:verdana; font-size:.9em;">
    <form id="form1" runat="server">
    <div>
    <h2>Author: <asp:Label ID="a_last_name" runat="server" Text=""></asp:Label>, 
        <asp:Label ID="a_first_name" runat="server" Text=""></asp:Label> 
        <asp:Label ID="a_middle_name" runat="server" Text=""></asp:Label></h2>
    
    <h2>Dissertation Title: <asp:Label ID="diss_title" runat="server" Text=""></asp:Label></h2>
    <h2>Doctoral Degree: <asp:Label ID="docDegree" runat="server" Text="Label"></asp:Label></h2>
    <p><b>Chair: <asp:Label ID="cm_first_name" runat="server" Text="Label"></asp:Label>&nbsp;<asp:Label ID="cm_mid_name" runat="server" Text=""></asp:Label>&nbsp;
        <asp:Label ID="cm_last_name" runat="server" Text=""></asp:Label></b>
    </p>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" GridLines="None" ShowHeader="false">
         <Columns> 
           <asp:BoundField HtmlEncode="false" DataField="dissertation_abstract" />
         </Columns>        
        
        </asp:GridView>
        
   <hr/>      
    <p>Note that NCU dissertations are only available to currently enrolled students, faculty, and staff. If you 
    are not affiliated with the University, please purchase this dissertation through 
    <a target="_blank" href="http://disexpress.umi.com/">UMI</a>.</p>
    
    To view this dissertation, click  
        <asp:Label ID="diss_download" runat="server" Text=""></asp:Label> (Google Chrome users, please use another browser to download). 

    
    </div>
    </form>
</body>
</html>

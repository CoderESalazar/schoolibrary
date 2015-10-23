<%@ Page Language="vb" AutoEventWireup="false" CodeFile="db_index.aspx.vb" Inherits="db_index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Northcentral University Library</title>
    <style type="text/css">
    .color
    {
    	color: White;
    }
    
    
    
    </style> 
</head>
<body style="font-size: .85em; font-family:Verdana;">

   <form id="form1" runat="server">
    <div>
    
    <p><strong>Below is an index of all databases currently available in the Northcentral University Library.</strong></p> 
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#00467F" AlternatingRowStyle-BackColor="#DEAE73">
                   <Columns>
                   
                            <asp:HyperLinkField DataNavigateUrlFields="url_id" HeaderText="Database Title" Target="_blank" HeaderStyle-CssClass="color" DataTextField="db_title"></asp:HyperLinkField>
                            <asp:BoundField HeaderText="Coverage" DataField="cover_id" HeaderStyle-CssClass="color"/>
                            <asp:BoundField HeaderText="FullText" DataField="full_text" HeaderStyle-CssClass="color"/>
                             <asp:BoundField HeaderText="Scholarly" DataField="scholary_id" HeaderStyle-CssClass="color"/>
                            <asp:BoundField HeaderText="Description" HtmlEncode="false" DataField="desc_resource" HeaderStyle-CssClass="color"/>
                               
                    </Columns>
        
        
        
        </asp:GridView>
    </div>
    </form>
</body>
</html>

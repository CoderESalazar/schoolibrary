<%@ Page Language="vb" AutoEventWireup="false" CodeFile="letter.aspx.vb" Inherits="mess_frm_dir" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Message from the Library Director</title>
<style type="text/css">
#LetterView
{
	font-family: Verdana;
	font-size: .9em;
}
#LetterTitle
{
	font-family: Verdana;
	font-weight: 700;
}	
</style>    
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
             
        <h2><asp:Label ID="LetterTitle" runat="server" Text=""></asp:Label></h2>
        
        <br/> 
        <asp:GridView ID="LetterView" runat="server" AutoGenerateColumns="false" CssClass="LetterView" ShowHeader="false" GridLines="None" BackColor="#FFFFCC">
            <Columns>
                    
                <asp:BoundField HtmlEncode="false" DataField="letter_content"/>
                           
             </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>

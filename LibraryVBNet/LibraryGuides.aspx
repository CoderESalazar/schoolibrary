<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LibraryGuides.aspx.vb" Inherits="LibraryGuides" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
  <script type="text/javascript" src="tabbed.js"></script>
  <link href="/Styles/main.css" rel="stylesheet" type="text/css" media="all" />
</head>
<body style="background-color: white;">

<form runat="server"> 
    <br />                                     
    <br />
<!--End of Header Information-->     
 <!--   
    <div style="margin-left:10px;">
    <p>Library Guides are guides that contain library resources pertinent to a specialization or individual course.
    To get started, select the desired item from one of the two drop down menus below.
    </p> 
    </div>
 <br/> 
 --> 
 
 
 <table align="center"> 
 
        <tr> 
            <td> 
                <p><font color="#00467F"><strong>Specializations:</strong>&nbsp;&nbsp;</font></p></td><td> <asp:DropDownList ID="SpecialDrop" runat="server"></asp:DropDownList> <asp:Button ID="SpecButton" runat="server" Text=" Select " />
                &nbsp;&nbsp;<asp:Label ID="lblSpecDrop" runat="server" Text=""></asp:Label>
                
                </td> 
           </tr> 
        
        <tr> 
            <td>&nbsp;</td><td>&nbsp;</td>  
            
        </tr> 
        
        <tr>     
            <td align="right">
            <p><font color="#00467F"><strong>Courses:</strong>&nbsp;&nbsp;</font></p></td><td><asp:DropDownList ID="CoursesDrop" runat="server">
            </asp:DropDownList> <asp:Button ID="CourseButton" runat="server" Text=" Select " />&nbsp;&nbsp;<asp:Label
                ID="lblCourseDrop" runat="server" Text=""></asp:Label>
            </td> 
            
        </tr> 
    
  </table> 
  
  </form>
</body>
</html>

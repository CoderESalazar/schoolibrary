<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="default1" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>


 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  

<h2>Library Guides</h2>
                                         

<!--End of Header Information-->     
    
    <div style="margin-left:10px;">
    <p>Library Guides are guides that contain library resources pertinent to a specialization or individual course.
    To get started, select the desired item from one of the two drop down menus below.
    </p> 
    </div>
 <br/> 
 
 <table> 
 
        <tr> 
            <td> 
                <strong>Specializations:&nbsp;&nbsp;</strong></td><td> <asp:DropDownList ID="SpecialDrop" runat="server"></asp:DropDownList> <asp:Button ID="SpecButton" runat="server" Text="Select" />
                    <asp:Label ID="Lbl_SpecialDrop" runat="server" Text=""></asp:Label>
            </td> 
        </tr> 
        
        <tr> 
            <td>&nbsp;</td><td>&nbsp;</td>  
            
        </tr> 
        
        <tr>     
            <td align="right">
            <strong>Courses:&nbsp;&nbsp;</strong></td><td><asp:DropDownList ID="CoursesDrop" runat="server">
            </asp:DropDownList> <asp:Button ID="CourseButton" runat="server" Text="Select" />
                <asp:Label ID="Lbl_CoursesDrop" runat="server" Text=""></asp:Label>
            
            </td> 
            
        </tr> 
    
  </table> 

    </asp:Content>              

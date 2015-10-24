<%@ Control Language="VB" AutoEventWireup="false" CodeFile="guides.ascx.vb" Inherits="research_help_guides" %>

<table width="100%" cellpadding="0" cellspacing="0" border="0" style="height: 1em;"> 
    <tr> 
        <td width="30%" nowrap="nowrap" valign="top"><asp:HyperLink ID="BannerLink" runat="server"><img alt="" src="../images/library_header.jpg" border="0" /></a></asp:HyperLink></td>
        <td align="right" valign="top"><asp:Label ID="user_name" CssClass="user_name" runat="server" Text=""></asp:Label>&nbsp;<!--<asp:HyperLink ID="sign_out" runat="server" Visible="false">Sign Out</asp:HyperLink>--></td> 
            
     
     </tr>
 </table> 
    <table width="100%" style="background-color:#C27B13;"> 
        <tr>
            <td style="text-indent: 5px;"><asp:HyperLink ID="HyperLink3" CssClass="links1" runat="server" NavigateUrl="/ncu_kb/user/user_page.aspx">Ask a Librarian</asp:HyperLink> |
            <asp:HyperLink ID="HyperLink4" CssClass="links1" runat="server" NavigateUrl="/request_forms/fdbk_form.aspx">Leave Feedback</asp:HyperLink> |
            <asp:HyperLink ID="HyperLink5" CssClass="links1" runat="server" NavigateUrl="/dw_template.aspx?parent_id=20">About Us</asp:HyperLink></td>
        </tr>
        
        
   </table> 
   

<table style="background-color:#00467F;color: White;" width="100%">
    <tr> 
        <td><asp:Label ID="LibCrumbs" runat="server" Text="" CssClass="Label1" Font-Size=".9em"></asp:Label></td>
        <td align="right"><asp:HyperLink ID="LearnerPortal" CssClass="Portal" style="color:White;font-size:.9em; margin-right:5px;" runat="server">Learner Portal </asp:HyperLink>| 
        <asp:HyperLink ID="MentorsPortal" CssClass="Portal" style="color:White;font-size:.9em; margin-right:5px;" runat="server">Mentor Portal</asp:HyperLink> | 
        <asp:HyperLink ID="StaffPortal" CssClass="Portal" style="color:White;font-size:.9em; margin-right:5px;" runat="server">Staff Portal</asp:HyperLink></td> 
    </tr> 
</table>     

    
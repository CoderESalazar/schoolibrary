<%@ Page Language="vb" AutoEventWireup="false" CodeFile="add.aspx.vb" Inherits="add" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Adding a Course</title>
</head>
<body style="font-family: Verdana;">
    <form id="form1" runat="server">
    <div>
    <h3>Add New Course Guide</h3>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/research_help/course_guides/admin/default.aspx">Return to Course Guides Admin Area</asp:HyperLink>
        <br/><br/> 
    
    Title:  
        <asp:DropDownList ID="CourseDropDown" runat="server">
        </asp:DropDownList>
    <br/> 
    <br/> 
        <asp:Button ID="Continue" runat="server" Text="Add Course Code and Course Name" />
    
    <br/> 
    <br/> 
        Course Code: <asp:Label ID="course_code" runat="server" Text=""></asp:Label><br/> 
        
        Course Name: <asp:Label ID="course_name" runat="server" Text=""></asp:Label><br/><br/> 
        
        <obout:Editor ID="guide_body" runat="server" AutoFocus="false" Appearance="lite" SuppressTab="true" NoUnicode="true" Submit="False" pathprefix="/includes_shared/oboutSuite/Editor/Editor_data/">
        </obout:Editor>
    <br/> 
        <asp:Button ID="AddLibGuide" runat="server" Text="Submit" />
    </div>
    </form>
</body>
</html>

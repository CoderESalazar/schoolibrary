<%@ Page Language="vb" AutoEventWireup="false" CodeFile="edit.aspx.vb" Inherits="edit" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Library Guide</title>
    
<style type="text/css">

.nav {background: #445577; padding: 5px 10px 2px; margin: 0; list-style: none; font: bold 0.8em Verdana, sans-serif;}
.nav li {display: inline; padding: 2px 0; background: white;}
.nav li a {padding: 2px 10px; text-decoration: none;}
.nav li a:link {color:gray}
.nav li a:visited {color: gray;}

</style>     
    
</head>
<body style="font-family: Verdana;">
    <form id="form1" runat="server">
    <div>
        <h3>Edit/Add Tabs Page</h3>
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="/research_help/course_guides/admin/default.aspx">CourseGuides</asp:HyperLink>
        
        <p>Course Title: <asp:TextBox ID="GuideTitle" runat="server" Width="400"></asp:TextBox><asp:Label
            ID="GuideTitleLabel" runat="server" Text="" Visible="false"></asp:Label></p>
        <p>Course Code: <asp:TextBox ID="CourseCode" runat="server"></asp:TextBox><asp:Label
            ID="CourseCodeLabel" runat="server" Text="" Visible="false"></asp:Label></p> 
        
        
        
        <p>Add To Tab List: 
            <asp:TextBox ID="createtab" runat="server"></asp:TextBox>
            <asp:Button ID="AddTab" runat="server" Text="Add to Tabs List" />
            <asp:Label ID="Lbl_CreateTab" runat="server" Text=""></asp:Label>
        </p>
        
                         
        <p>Add Tab: 
            <asp:DropDownList ID="TabDropList" runat="server">
            </asp:DropDownList>&nbsp;
            <asp:Button ID="AddTab2" runat="server" Text="Add Tab" />
            <asp:Label ID="Lbl_DropList" runat="server" Text=""></asp:Label>
        </p> 
        <br/>
        
        
        <asp:Label ID="TabsLabel" runat="server" Text="Tabs" Visible="false"></asp:Label><asp:PlaceHolder ID="Tabs" runat="server"></asp:PlaceHolder>
        
        <br/> 
        <asp:Label ID="Label1" runat="server" Text="Guide Body" ></asp:Label>
        <obout:Editor ID="Editor1" runat="server"  AutoFocus="false" Appearance="lite" SuppressTab="true" NoUnicode="true" Submit="False" pathprefix="../includes_shared/oboutSuite/Editor/Editor_data/">
                <Buttons> 
                   
                       <obout:Method Name="InsertIMG" />
                       <obout:Method Name="ForeColor" />  
                    
                </Buttons>
        </obout:Editor>
        
        <br/><br/> 
        Display: <asp:Label ID="Display" runat="server" Text="Display:">&nbsp;</asp:Label><asp:CheckBox ID="DisplayCheckBox" runat="server" />
        <br/><br/> 
        <asp:Button ID="CreatorButt" runat="server" Text="Creator" />&nbsp;&nbsp;<asp:Button
            ID="UpdateButt" runat="server" Text="Update" />
       <br/> 
           
       <div align="right">
         <asp:Button ID="deleteGuide" runat="server" Text="Delete?" OnClientClick="return confirm('Do you want to Delete?')"/>     
         
         
         
       </div>
    </div>
    </form>
</body>
</html>

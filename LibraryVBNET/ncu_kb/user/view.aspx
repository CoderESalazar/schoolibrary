<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="view.aspx.vb" Inherits="user_area" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>


 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">
    <div> 
    <a href="/ncu_kb/user/user_area.aspx">Return to My e-Reference</a><br/> 
   
    <h3>Librarian Response</h3>
        <asp:Label ID="lib_response" runat="server" Text=""></asp:Label>
    
    <!--
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False">
            <Columns>
                <asp:BoundField HtmlEncode="false" DataField="lib_response"/>
                   
            </Columns>
        </asp:GridView> --> 
     
     <br/>  
    <h3>Attached Documents</h3>    
      <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="false">
          <Columns> 
              <asp:HyperLinkField DataNavigateUrlFields="q_id" DataTextField="attachment_file_name" DataNavigateUrlFormatString="/ncu_kb/file_download.aspx?q_id={0}"></asp:HyperLinkField>
         
          </Columns>
      </asp:GridView>
    
    <br/> 
       
    <h3>Your Question</h3>
       
        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="false" GridLines="None" ShowHeader="false">
    
            <Columns><asp:BoundField HtmlEncode="false" DataField="q_detail"/></Columns>
            
        </asp:GridView>
   <br/> 
   
       <h3>Need Additional Assistance?</h3>     
        <p>Please email us at <a style="color:#445577;" href="mailto:library@ncu.edu">library@ncu.edu</a>. Be sure to include <strong>QuestionID 
            <asp:Label ID="quest_id" runat="server" Text=""></asp:Label></strong> in your email so we know 
        which question you are referring to. Thanks.</p>  
   
   <br/>  

        <asp:Button ID="btnFdbk" runat="server" Text="Leave Feedback" />


    </div>
 
 </asp:Content>
<%@ Page Title="" Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="research_consult_fdbk.aspx.vb" Inherits="ncu_kb_user_research_consult_fdbk" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <asp:Panel ID="research_consult_message" runat="server">
        <asp:Label ID="consult_mess" runat="server" Text=""></asp:Label>
    </asp:Panel>


<asp:Panel ID="research_consult_fdbk" runat="server">

<h2 align="center">Research Consultation Satisfaction Survey</h2> 

<p>The information you provide will help us to improve our Research Consultation service.</p>

<p>1. What is your primary role at Northcentral University.</p>
    <asp:DropDownList ID="primary_role" runat="server">
        <asp:ListItem Selected="True">Please Select</asp:ListItem>    
        <asp:ListItem>Student</asp:ListItem>
        <asp:ListItem>Faculty</asp:ListItem>
        <asp:ListItem>Staff</asp:ListItem>
    </asp:DropDownList>
    
       
    <br /> 
    
 <p>2. Select a Librarian name</p>
    <asp:DropDownList ID="LibList" runat="server">
    <asp:ListItem Selected="True">Please Select</asp:ListItem>
        <asp:ListItem>Amanda Bezet</asp:ListItem>
        <asp:ListItem>Jeff Murdock</asp:ListItem>
        <asp:ListItem>Ed Salazar</asp:ListItem>
    </asp:DropDownList>
    
 <p>3. Was this your first research consultation?</p>
       <asp:RadioButtonList ID="first_research_consult" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
         <asp:ListItem>Yes</asp:ListItem>
         <asp:ListItem>No</asp:ListItem>
       </asp:RadioButtonList>
 
 
 <p>4. Did you experience any difficulty in setting-up your appointment? </p>
        <asp:RadioButtonList ID="difficult_consult_set_up" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
         <asp:ListItem>Yes</asp:ListItem>
         <asp:ListItem>No</asp:ListItem>
       </asp:RadioButtonList>
       <p>If yes, please leave your comment in the comment box at the end of the survey.</p>
 
 <p>5. My research needs were met as a result of the research consultation. 
     <asp:RadioButtonList ID="needs_met" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
         <asp:ListItem>Strongly Agree</asp:ListItem>
         <asp:ListItem>Agree</asp:ListItem>
         <asp:ListItem>Neutral</asp:ListItem>
         <asp:ListItem>Disagree</asp:ListItem>
         <asp:ListItem>Strongly Disagree</asp:ListItem>
     </asp:RadioButtonList>
 </p>
 
 <p>6. The librarian was well-prepared for my consultation.  </p>
    <asp:RadioButtonList ID="librarian_preparation" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
    
         <asp:ListItem>Strongly Agree</asp:ListItem>
         <asp:ListItem>Agree</asp:ListItem>
         <asp:ListItem>Neutral</asp:ListItem>
         <asp:ListItem>Disagree</asp:ListItem>
         <asp:ListItem>Strongly Disagree</asp:ListItem>
    
    </asp:RadioButtonList>
 
<p>7. The librarian was knowledgeable about Library resources and research techniques.</p> 

    <asp:RadioButtonList ID="librarian_knowledge" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
    
         <asp:ListItem>Strongly Agree</asp:ListItem>
         <asp:ListItem>Agree</asp:ListItem>
         <asp:ListItem>Neutral</asp:ListItem>
         <asp:ListItem>Disagree</asp:ListItem>
         <asp:ListItem>Strongly Disagree</asp:ListItem>
    
    </asp:RadioButtonList>

<p>8. I would recommend the Research Consultation service to others. </p>
    
    <asp:RadioButtonList ID="recommend_consult" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
    
         <asp:ListItem>Strongly Agree</asp:ListItem>
         <asp:ListItem>Agree</asp:ListItem>
         <asp:ListItem>Neutral</asp:ListItem>
         <asp:ListItem>Disagree</asp:ListItem>
         <asp:ListItem>Strongly Disagree</asp:ListItem>
    
    </asp:RadioButtonList>
    
 <p>9.	The technology used to deliver the Research Consultation was easy to use.</p>   
 
     <asp:RadioButtonList ID="technology_used" runat="server" RepeatDirection="Horizontal" RepeatColumns="5">
    
         <asp:ListItem>Strongly Agree</asp:ListItem>
         <asp:ListItem>Agree</asp:ListItem>
         <asp:ListItem>Neutral</asp:ListItem>
         <asp:ListItem>Disagree</asp:ListItem>
         <asp:ListItem>Strongly Disagree</asp:ListItem>
    
    </asp:RadioButtonList>
    
  <p>10. Please provide any comments or suggestions. </p>
        <textarea rows="7" cols="80" id="comments_box" runat="server"></textarea>
        
   <br /> <br /> 
   
       <asp:Button ID="Sbmt_bttn" runat="server" Text="Submit" />
       
     <table>

           <tr>  
              <td>   
                <asp:TextBox ID="info" runat="server" Visible="False"></asp:TextBox>
               </td>
            </tr>

     </table>  
</asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>


<%@ Page Title="" Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="research_consult.aspx.vb" Inherits="ncu_kb_research_consult" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">
    
     
    <asp:Panel ID="not_logged_in" runat="server" Visible="false">
    <p>Sorry you're not logged in. Please login to view this page.</p>
    </asp:Panel>

    
    <asp:Panel ID="consult_message" runat="server" Visible="false">
    
    <asp:Label ID="consult_mess" runat="server" Text=""></asp:Label>
    </asp:Panel>

    <asp:Panel ID="research_consult" runat="server" Visible="true">
 

<h2 align="center">Schedule a Research Consultation</h2> 
<p>The NCU Library offers a research consultation service for students, faculty, and staff. This is an in-depth, customized, one-on-one meeting with a reference librarian to discuss possible information resources and search strategies for class assignments, papers, presentations, Masters theses, and doctoral dissertations.</P>
<p><strong>Need help right away?</strong></p>
<p>If your deadline is within the next four business days (M-F), request immediate help (i.e., not a research consultation). Here are ways to get help right away: </P>
<p><a href="http://library.ncu.edu/ncu_kb/user/user_page.aspx">Ask a Librarian</a> </p>
<p>Phone 888-628-1569 </p>

<p><strong>Already completed a consultation?</strong></p>

<p>Please take the <a href="https://ncu.co1.qualtrics.com/SE/?SID=SV_3ryXQEaJc38GjaJ" target="_blank">Research Consultation Satisfaction Survey</a> and let us know if your consultation helped you! We appreciate your comments and suggestions.</p>


<strong>Research Consultation Policies</strong>
<ol>

    <li>This service is available to NCU students, faculty and staff. <strong>However, we are unable to schedule consultations with students who are currently taking their comprehensive exam course nor can we provide any assistance, advice, or preparation related to the comprehensive exam course. </strong></li>
    <li>Consultations are normally scheduled during <a href="/dw_template.aspx?parent_id=22" style="color: darkblue;">normal operating hours</a>.</li>
    <li>Requests must be made at least 2 business days in advance to allow time for the librarian to prepare. <b>You may have only one consultation scheduled at any one time.</b></li>
    <li>Once your request is received, a librarian will contact you within 24 hours (excluding weekends) to schedule your appointment.</li>
    <li>It is expected that you review the <a href="/dw_template.aspx?parent_id=179">Research Process</a> prior to your scheduled consultation.</li>
    <li>It is expected that you will meet your appointment time, or contact us within in a reasonable time period to cancel. The Library relies on the punctuality and consistency of students in order to continue providing the Research Consultation service. 
        Repeated cancellations and "no shows" may result in suspension of appointment-making privileges.</li>
    <li>The reference librarians will not do the actual research for you, nor will they answer questions that a professor has assigned as part of a class activity. </li>
    <li>The reference librarians may not help you with the mechanics and style of writing a research paper. You are advised to contact the Academic Success Center for assistance <a href="mailto:asc@ncu.edu">asc@ncu.edu</a>.</li>
    <li>Consultations take place through GoToMeeting, the Library’s online meeting software. Once the meeting time is confirmed, you will be sent a meeting invitation containing access and call-in information.
    <Strong>IT IS YOUR RESPONSIBILITY TO CHECK YOUR EMAIL FOR THE MEETING INVITATION. </Strong></li>
    <li>You will be asked to complete a satisfaction survey following the consultation session.</li>
</ol>
<br /> 
<strong>Areas of Assistance</strong>
<ol>
    <li>Developing your research strategy</li> 
    <li>Identifying relevant databases and journals </li>
    <li>Finding and evaluating information resources </li>
    <li>Discovering alternative search terms for your topic</li> 
    <li>Using advanced search techniques for specific databases</li>
    <li>Narrowing your search results</li>
</ol>

<br /><br />
Use the form below to request a consultation appointment with a reference librarian. <strong>Please be as thorough as possible to ensure that both you and the librarian are prepared for your session.</strong> 
        <br />Course #  <asp:TextBox ID="courseNum" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="courseNum" ErrorMessage="Please enter a course number."></asp:RequiredFieldValidator>
        
        <br />Activity # <asp:TextBox ID="courseAssign" runat="server"></asp:TextBox><br /> 

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="courseAssign" ErrorMessage="Please enter course assignment number."></asp:RequiredFieldValidator>
        
        <br />Describe your question or research need as thoroughly as possible: <br />

        <textarea rows="7" cols="50" id="desc_quest" runat="server"></textarea>
        
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="desc_quest" ErrorMessage="Please enter a description of your research question."></asp:RequiredFieldValidator>

        <br />What steps have you already taken to locate the desired information? <br />

        <textarea rows="7" cols="50" id="steps_taken" runat="server"></textarea>

        <br />Have you encountered any difficulties? <br />
        <textarea rows="7" cols="50" id="diff_encount" runat="server"></textarea>

        <br />What would you like assistance with? <br />

        <textarea rows="7" cols="50" id="req_assist" runat="server"></textarea><br /><br /> 
        
        Desired time of day for consultation (Arizona Time): <asp:DropDownList ID="best_time" runat="server">
            <asp:ListItem Selected="True">Please Select</asp:ListItem>
            <asp:ListItem>Early Morning</asp:ListItem>
            <asp:ListItem>Late Morning</asp:ListItem>
            <asp:ListItem>Early Afternoon</asp:ListItem>
            <asp:ListItem>Late Afternoon</asp:ListItem>
            <asp:ListItem>Evening</asp:ListItem>
            
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
            runat="server" ControlToValidate="best_time" InitialValue="Please Select" ErrorMessage="Please select desired time of day."></asp:RequiredFieldValidator>
        
<!--these are hidden fields below--> 

<table>

           <tr>  
              <td>   
                <asp:TextBox ID="first_names" runat="server" Visible="False"></asp:TextBox>
               </td>
            </tr>

            <tr> 
                <td><asp:TextBox ID="last_name" runat="server" Visible="False"></asp:TextBox></td> 
            </tr>
              
            <tr> 
                <td><asp:TextBox ID="email_address" runat="server" Visible="False"></asp:TextBox></td> 
             </tr>
             <tr> 
                <td><asp:TextBox ID="current_user_id" runat="server" Visible="False"></asp:TextBox></td> 
             </tr>
             
              <tr> 
                <td><asp:TextBox ID="current_time" runat="server" Visible="False"></asp:TextBox></td> 
             </tr>
              <tr> 
                <td><asp:TextBox ID="deg_prog" runat="server" Visible="False"></asp:TextBox></td> 
             </tr>
             
            <tr> 
          
                <td>&nbsp;</td> 
                
            </tr> 

             <tr> 
                  
                <td align="center">
                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
                </td> 
                
            </tr> 
             
        </table> 
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphFooter" Runat="Server">
</asp:Content>


<%@ Page Language="VB" MasterPageFile="~/Compass.master" ValidateRequest="false" AutoEventWireup="false" CodeFile="user_page.aspx.vb" Inherits="user_page" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
    
    <asp:Panel ID="not_logged_in" runat="server" Visible="false">
        <p>Sorry you're not logged in. Please login to view this page.</p>
    </asp:Panel>
    
    <div style="margin: 10px 10px 10px 10px;font-size:1.2em;" visible="false">
    

        <asp:Panel ID="ask_a_librarian" runat="server" Visible="true">

        <p>Hi <asp:Label ID="first_name_invite" runat="server" ></asp:Label>. Please fill out the form below. <strong>Have you checked the Library FAQs for an answer to your question?</strong> To seach the Library FAQs, click <a href=/ncu_kb/>here</a>.</p>
       
        <strong><asp:Label ID="Label1" runat="server" Text="" BackColor="Yellow"></asp:Label></strong> 
        
        <table>
            <tr> 
                <td>Category of your question:  
                
           
                        <asp:DropDownList ID="cat_drop" runat="server">
                        </asp:DropDownList>

                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cat_drop" ErrorMessage="Please select a category." Display="Dynamic"></asp:RequiredFieldValidator>          
    
                 
               </td> 
              
                   
                
            </tr>  
            <tr> 
                <td>&nbsp;</td> 
            </tr> 
            <tr>     
                
                <td style="color:darkred;font-weight:600;">*If your question is for a course activity, please provide course and activity number.</td> 
            </tr> 
            <tr> 
                <td>&nbsp;</td> 
            </tr> 
            
            <tr>   
              
                <td>Course Number:
                    <asp:TextBox ID="courseNum" runat="server"></asp:TextBox>
                </td> 
           </tr> 
           <tr> 
           
                <td>Activity Number:
              
                    <asp:TextBox ID="courseAssign" runat="server"></asp:TextBox>
                </td> 
           </tr> 
           <tr> 
         
                <td>&nbsp;</td> 
                
                
           </tr> 
        
 
</table>
<p>Please type your question into box below.</p>
<textarea rows="15" cols="80" id="comments_box" runat="server"></textarea>


<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="comments_box" ErrorMessage="Please type in question." Display="Dynamic"></asp:RequiredFieldValidator></p>
<!--
        <FTB:FreeTextBox ID="TftbUserNotes" runat="server" Height="200px" Width="617px" BackColor="WhiteSmoke">
        <Toolbars>
            <FTB:Toolbar runat="server">
                <FTB:NetSpell runat="server" />
                <FTB:WordClean />
            </FTB:Toolbar>
        </Toolbars>
        </FTB:FreeTextBox>
        
        <br /> 
       
-->         
<!-- these are hidden fields that need to be updated --> 
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
   </div> 
 </asp:Content>
<%@ Page Language="vb" AutoEventWireup="false" CodeFile="phone_ref.aspx.vb" Inherits="phone_ref" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Phone/MISC Reference</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h3>Phone Reference/Email/In-Person/Chat</h3>
    
    <a href="kb_table.aspx">Return to Library Work Queue</a> 
    <br/> 
    <br /> 
    <table> 
       <tr>    
            <td>Search for <a href="http://admin.ncu.edu/learner_info/" target="_blank">LearnerID</a> or <a href="http://admin.ncu.edu/mentor_info/" target="_blank">MentorID</a></td> 
       </tr> 
            
       <tr> 
       
            <td>PatronID: <asp:TextBox ID="user_id" runat="server"></asp:TextBox>*<asp:RequiredFieldValidator
                ID="user_id_validate" ControlToValidate="user_id" runat="server" ErrorMessage="Enter UserId" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:Button ID="IDSearch" CausesValidation="false" runat="server" Text="PoPLInfo" />&nbsp;&nbsp;<asp:Button
                    ID="MIDSearch" CausesValidation="false" runat="server" Text="PoPMInfo" />
            </td> 
       
       </tr> 
    <tr>
            
            <td>Patron First Name: <asp:TextBox ID="f_name" runat="server"></asp:TextBox>* <asp:RequiredFieldValidator
                ID="f_name_validate" ControlToValidate="f_name" runat="server" ErrorMessage="Enter first name" Display="Dynamic"></asp:RequiredFieldValidator></td> 
       
       </tr> 
       
       <tr> 
       
            <td>Patron Last Name: <asp:TextBox ID="l_name" runat="server"></asp:TextBox>* 
                <asp:RequiredFieldValidator ID="l_name_validate" ControlToValidate="l_name" runat="server" ErrorMessage="Enter last name" Display="Dynamic"></asp:RequiredFieldValidator></td> 
       </tr>
       
         <tr> 
       
            <td>Patron Email: <asp:TextBox ID="email_add" runat="server"></asp:TextBox>*<asp:RequiredFieldValidator
                ID="email_add_validate" runat="server" ControlToValidate="email_add" ErrorMessage="Enter Email Address" Display="Dynamic"></asp:RequiredFieldValidator> </td> 
       </tr>
        <tr> 
        
            <td>&nbsp;</td> 
            
        </tr> 
      
       <tr> 
        
        
        
            <td>Type of Question &nbsp;
                <asp:DropDownList ID="q_type" runat="server">
                    <asp:ListItem Value="-1">Please Select</asp:ListItem>
                    <asp:ListItem Value="Phone">Phone</asp:ListItem>
                    <asp:ListItem Value="In-person">In-person</asp:ListItem>
                    <asp:ListItem Value="Email">Email</asp:ListItem>
                    <asp:ListItem Value="Chat">Chat</asp:ListItem>
                    <asp:ListItem Value="Consult">Consultation</asp:ListItem>
                    <asp:ListItem Value="ServiceD">Service Desk</asp:ListItem>
                </asp:DropDownList>
                   
                *<asp:RequiredFieldValidator ID="q_type_validate" runat="server" InitialValue="-1" ControlToValidate="q_type" ErrorMessage="Select question type" display="Dynamic"></asp:RequiredFieldValidator>
            </td> 
        </tr>
    
        <tr> 
        
            <td>&nbsp;</td> 
            
        </tr> 
            
        
        
        <tr>
            <td>Category of your question:  
                <asp:DropDownList ID="cat_drop" runat="server">
                </asp:DropDownList>
            
                *<asp:RequiredFieldValidator ID="cat_drop_validate" runat="server" ControlToValidate="cat_drop" ErrorMessage="Select question category" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
            
        </tr>
        
        
        <tr> 
            <td>&nbsp;</td> 
        </tr>
        <tr> 
        
            <td>Course Number: <asp:TextBox ID="c_numb" runat="server"></asp:TextBox></td> 
       
        </tr> 
        
        <tr>      
            <td>Assignment Number: <asp:TextBox ID="assign_numb" runat="server"></asp:TextBox></td> 
        </tr> 
        
        
        
        
    
        <tr> 
            <td>&nbsp;</td>
        </tr>
        
         
        <tr> 
            <td>Question taken: * <asp:RequiredFieldValidator ID="quest_desc_validate" ControlToValidate="quest_desc" runat="server" ErrorMessage="Enter a question" Display="Dynamic"></asp:RequiredFieldValidator></td>
        
        </tr> 
        
         <tr> 
        
            <td><textarea rows="10" cols="80" id="quest_desc" runat="server"></textarea>
            
            </td>
            
            
        </tr>
        
        <tr>
        
            <td>Librarian Response:</td> 
            
        </tr> 
        
        <tr>  
            
            <td><textarea rows="10" cols="80" id="lib_response" runat="server"></textarea></td>
       
       </tr> 
        
        <tr> 
            <td> 
                <asp:Button ID="btnAdd" runat="server" Text="Submit" CausesValidation="true" />
            </td>
        </tr>
        
    </table> 
    
    
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    
        <asp:TextBox ID="staff_name" runat="server" Text="" Visible="false"></asp:TextBox>
    
    
    </div>
    </form>
</body>
</html>

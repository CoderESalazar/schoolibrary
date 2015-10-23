<%@ Page Language="vb" AutoEventWireup="false" CodeFile="update.aspx.vb" Inherits="update" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="obout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Librarian Update Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <asp:HyperLink ID="searchLink" runat="server">Return to Previous Page</asp:HyperLink>
     
    <h3>Librarian Work Area</h3> 
    
    <table> 
    
        <tr> 
            <td>
               <asp:HyperLink ID="reassign" runat="server" NavigateUrl="~/ncu_kb/librarian/reassign.aspx" Visible="false">Re-assign</asp:HyperLink></td> 
        
        </tr> 
        
        <tr> 
            <td>&nbsp;</td> 
        </tr> 
        <tr> 
            <td><h4>Patron Info</h4></td> 
        </tr> 
        <tr> 
            <td>User Name:</td><td><asp:Label ID="u_f_name" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="u_l_name" runat="server" Text=""></asp:Label></td> 
            
            
       </tr> 
       <tr> 
            <td>UserId: </td><td><asp:Label ID="u_id" runat="server" Text=""></asp:Label></td>
    
       </tr>
       <tr> 
            <td>Address: </td><td><asp:Label ID="address_street" runat="server" Text=" "></asp:Label> </td> 
            
       </tr> 
       
       <tr> 
            <td>&nbsp;</td><td><asp:Label ID="address_city" runat="server" Text=" "></asp:Label> , 
                <asp:Label ID="address_state" runat="server" Text=" "></asp:Label>
                <asp:Label ID="address_postal_code" runat="server" Text=" "></asp:Label>
                <asp:Label ID="address_country" runat="server" Text=" "></asp:Label>
                </td> 
            
       </tr> 
       
       <tr> 
            <td>Phone:</td><td> <asp:Label ID="phone" runat="server" Text=" "></asp:Label></td> 
            
           
       </tr>  
       <tr> 
       
            <td>Email: </td> <td><asp:Label ID="e_mail" runat="server" Text=" "></asp:Label></td> 
      

       </tr> 
       <tr> 
            <td>&nbsp;</td> 
      </tr> 
        
       <tr> 
           <td><h4>Question Info</h4></td> 
           
       </tr>  
       <tr> 
            <td>Date/Time Question Posted:</td><td><asp:Label ID="date_time" runat="server" Text=""></asp:Label></td> 
       </tr>                
       <tr> 
            <td>Category:</td><td><asp:Label ID="cat_u_name" runat="server" Text=""></asp:Label></td>
       </tr> 
       <tr> 
            <td>Course Number (if provided):</td><td><asp:Label ID="c_num" runat="server" Text=""></asp:Label> </td> 
       
       </tr>
       <tr>  
            <td>Course Assignment (if provided):</td><td><asp:Label ID="c_assign" runat="server" Text=""></asp:Label></td>
            
       </tr> 
       </table> 
       <h4>Question Status</h4> 
       <table> 
            <tr>
                   <td><asp:Label ID="q_status" runat="server" Text="Question Status" Visible="false"></asp:Label>
                       <asp:Label ID="remove_kb" runat="server" Text="Leave in KB" visible="false"></asp:Label>
                   </td> 
                           
                   <td style="height: 24px">
                   
                   
                        <asp:DropDownList ID="lib_q_status" runat="server" Visible="false">  
                        <asp:ListItem Value="-1">Please Select</asp:ListItem>
                       <asp:ListItem Value="Partial">Leave in Queue</asp:ListItem>
                       <asp:ListItem Value="Submitted to KB">Submitted to KB</asp:ListItem>
                       <asp:ListItem Value="Not Submitted to KB">Not Submitted to KB</asp:ListItem>
                       </asp:DropDownList>  

                    </td> 
                   
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="-1" ControlToValidate="lib_q_status" ErrorMessage="Please select question status" Display="Dynamic"></asp:RequiredFieldValidator></td>
                
                
                   <td>         
                       <asp:CheckBox ID="checkBox" Checked="true" runat="server" Visible="false" />
                   
                   </td> 
                
                
                
             </tr> 
           
             
       </table> 
                 
       <h4>Editing Areas</h4> 
       <p>If the category differs from user designated category, please select correct category or create new category.</p> 
        
        <table> 
      
        <tr> 
            <td>Select category</td>
             <td><asp:DropDownList ID="cat_drop" runat="server">
                </asp:DropDownList>
            </td><td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cat_drop" ErrorMessage="Please select a category" Display="Dynamic"></asp:RequiredFieldValidator></td>
            
       </tr>  
       <tr>
            <td>&nbsp;</td><td><asp:HyperLink ID="cat_create" runat="server" Visible="False" NavigateUrl="add_cat.aspx">Create Category Name</asp:HyperLink></td> 
       
      </tr> 
      </table> 
      
      <table>   
      <tr> 
            <td>Patron's Question (Edited)</td>  
            
    
      </tr>
      
      
        <tr> 
            <td>
                  <obout:Editor ID="q_detail" runat="server" AutoFocus="false" EnableViewState="true" Appearance="lite" Submit="False" pathprefix="../includes_shared/oboutSuite/Editor/Editor_data/">
                    <Buttons> 
                   
                      <obout:Method Name="ForeColor" />  
                    
                    </Buttons>
                  </obout:Editor>
            
            </td> 
       
       </tr>
       <tr> 
            <td>&nbsp;</td> 
            
      </tr> 
        
       <tr> 
            <td>Librarian Response  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lib_response" ErrorMessage="Please write something in the box below"></asp:RequiredFieldValidator> </td> 
       </tr>      
       <tr>
            <td>
                <obout:Editor ID="lib_response" runat="server" AutoFocus="false" Appearance="lite" Submit="False" FixedToolBar="false" pathprefix="../includes_shared/oboutSuite/Editor/Editor_data/">
                  
                  <Buttons> 
                   
                       <obout:Method Name="InsertIMG" />
                       <obout:Method Name="ForeColor" />  
                    
                    </Buttons>
                
                
                </obout:Editor>
            </td> 
            
       </tr>
 
      <tr>
            <td>&nbsp;</td> 
            
      </tr>  
      
      <tr> 
        <td>
            <asp:Label ID="file_upload_text" runat="server" visible="false" Text="File Upload:"></asp:Label><asp:FileUpload ID="FileUpload1" visible="false" runat="server" />
        </td>
      </tr>
      <tr> 
           <td> </td> 
             
      
      </tr>   
        
       <tr> 
                <td>&nbsp;</td> 
           
           </tr>
      <tr> 
           <td>
               <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" DisplayMode="BulletList" />
               &nbsp;<asp:Button ID="btnUpdate" runat="server" Text="Update Record" /> 
              
                    
            </td> 
            
      </tr>
  
      
    </table> 
    
    <div align="right"><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="return confirm('Do you want to Delete?')" /></div>

    
    </div>
    </form>
</body>
</html>

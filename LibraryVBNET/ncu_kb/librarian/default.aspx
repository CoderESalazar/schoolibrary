<%@ Page Language="vb" AutoEventWireup="false" CodeFile="default.aspx.vb" Inherits="_default1" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Librarian Work Area</title>
    
    
<style type="text/css"> 
label.test { 
color: red;
}



</style> 



    
    
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    

    <a href="/ncu_kb/kb_table.aspx">Return To Library Ref Queues</a> <br/> 
    <h3>Librarian Work Area</h3> 
        <asp:Label ID="q_type" runat="server" Text=" " Visible="false"></asp:Label>
    <table> 
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
            <td>Email:</td><td> <asp:Label ID="email" runat="server" Text=" "></asp:Label></td> 
            
           
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
                   <td style="width: 193px; height: 24px;">Question Status: 
                   
                   </td>
                   
                   <td style="height: 24px"><asp:DropDownList ID="lib_q_status" runat="server">   
                        <asp:ListItem Value="-1">Please Select</asp:ListItem>
                       <asp:ListItem Value="Submitted to KB">Submitted to KB</asp:ListItem>
                       <asp:ListItem Value="Not Submitted to KB">Not Submitted to KB</asp:ListItem>
                        <asp:ListItem Value="Partial">Leave in Queue</asp:ListItem>
                       </asp:DropDownList>  </td> <td><asp:Label ID="q_status" runat="server" Text=" " Font-Bold="true" forecolor="red"></asp:Label></td>
                   
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" InitialValue="-1" ControlToValidate="lib_q_status" ErrorMessage="Please select question status" Display="Dynamic" EnableClientScript="true"></asp:RequiredFieldValidator></td>
             </tr> 
             
       </table> 
                 
       <h4>Editing Areas</h4> 
       <p>If the category differs from user designated category, please select correct category or create new category.</p> 
        
       <table> 
      
        <tr> 
            <td>Select category </td>
             <td><asp:DropDownList ID="cat_drop" runat="server">
                </asp:DropDownList>
             </td>   
            <td><asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="cat_drop" runat="server" ErrorMessage="Please select or create a category"></asp:RequiredFieldValidator></td>    
            <td><asp:Label ID="cat_names" runat="server" Text="" Font-Bold="true" ForeColor="Red"></asp:Label></td>             
       </tr>  
       <tr>
            <td>&nbsp;</td><td><asp:HyperLink ID="cat_create" runat="server" NavigateUrl="add_cats.aspx">Create Category Name</asp:HyperLink></td> 
       
      </tr> 
      </table> 
      
      <table>   
      <tr> 
            <td>Patron's Question</td>  
            
            
      </tr>
      
      
        <tr> 
            <td><cc1:Editor ID="q_detail" runat="server" AutoFocus="false" Appearance="lite" SuppressTab="true" NoUnicode="true" Submit="False" pathprefix="/includes_shared/oboutSuite/Editor/Editor_data/" previewmode="True"></cc1:Editor></td> 
       
       </tr>
       <tr> 
            <td>&nbsp;</td> 
            
      </tr> 
        
       <tr> 
            <td>Librarian Response  
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="lib_response" Display="Dynamic" ErrorMessage="Please write something in the box below"></asp:RequiredFieldValidator></td> 
       </tr>      
       <tr>
            <td>
                <cc1:Editor ID="lib_response" runat="server" AutoFocus="false" Appearance="lite" SuppressTab="true" NoUnicode="true" Submit="False" pathprefix="/includes_shared/oboutSuite/Editor/Editor_data/">
                </cc1:Editor>
            </td> 
            
       </tr>
 
      <tr>
            <td>&nbsp;</td> 
            
      </tr>  
           
      <tr> 
           <td>
               <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="true" DisplayMode="BulletList" />
               &nbsp;<asp:Button ID="btnKb" causesvalidation="true" runat="server" Text="Move Record" /> &nbsp;
               <asp:Button ID="btnUpdate" runat="server" Text="Save Record" />
          
              
            </td> 
              
      </tr>
  <tr> 
        <td><asp:CheckBox ID="checkBox" Checked="true" runat="server" Visible="false" /></td> 
  </tr> 
      
    </table> 
    
  <div align="right"><asp:Button ID="btnDelete" runat="server" Text="Delete" OnClientClick="return confirm('Do you want to Delete?')" /></div>
    
    
    </div>
    </form>
</body>
</html>

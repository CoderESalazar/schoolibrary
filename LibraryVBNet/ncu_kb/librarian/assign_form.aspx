<%@ Page Language="vb" AutoEventWireup="false" CodeFile="assign_form.aspx.vb" Inherits="assign_form" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Assignment Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <a href="/ncu_kb/kb_table.aspx">Return To Library Ref Queues</a> <br/> 
    <h3>Librarian Work Area</h3> 
        <asp:CheckBox ID="CheckBox1" runat="server" visible="false" Checked="true" />
        <asp:TextBox ID="deg_prog" runat="server" Visible="false"></asp:TextBox>
              
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
      
<table>   
      <tr> 
            <td>Patron's question below: <br/><asp:Label ID="q_detail" runat="server" Text="Label"></asp:Label></td>  
            
            
      </tr>  
          <tr>
            <td>&nbsp;</td> 
            
      </tr> 
      
     
      
       
      <tr> 
      
               <td>
               
              <asp:Button ID="btnKb" causesvalidation="true" runat="server" Text="Assign yourself this question" /> 
              
              
            </td> 
   
               
       
           
      </tr>
 
      
    </table> 
    </div>
    </form>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="false" CodeFile="edit.aspx.vb" Inherits="edit" %>

<%@ Register Assembly="obout_Editor" Namespace="OboutInc.Editor" TagPrefix="cc1" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc2" %>





<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Library Event Schedule</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
  
    <h3>Edit Library Event Schedule</h3>
    <table> 
         <tr>
                  
        <td><strong>EventID:</strong></td> 
			<td>
                <asp:Label ID="events_id" runat="server" Text="Label"></asp:Label></td>
       
        </tr>
     <tr> 
        <td><strong>Event Date:</strong></td> 
			<td><asp:TextBox ID="event_date" runat="server"></asp:TextBox></td>
       
        </tr>
        <tr>
        <td><strong>Library Homepage Title: </strong></td>
        <td><asp:TextBox ID="lib_home" width="180" runat="server"></asp:TextBox></td>
        </tr>

        <tr> 
            <td><strong>Total Attendees:</strong></td> 
            <td>
                <asp:TextBox ID="attendees" runat="server" Width="20"></asp:TextBox> 
            </td> 
        </tr> 
        
        
      </table> 
      
      <table> 
        
        <tr> 
            <td><strong>Library Event:</strong></td> 
            
        </tr> 
        
        <tr>     
            <td> 
                   <cc1:Editor ID="event_details" runat="server"  Appearance="lite" Submit="False" AutoFocus="false" FixedToolBar="false" pathprefix="../includes_shared/oboutSuite/Editor/Editor_data/">
                         <Buttons> 
                            <cc1:Method Name="ForeColor" /> 
                            
                 
                        </Buttons>
        
        </cc1:Editor>  
        
            </td> 
            
        </tr> 

    

        <tr>
				<td>&nbsp;</td>
	</tr> 	

	<tr> 
	    <td>&nbsp;</td>
	</tr>  		
    <tr> 				
				<td>
					<asp:Button ID="btnUpdate" runat="server" Text="Update" /></td>
				<td></td>
		</tr>
        
    </table>
     <div align="right"><asp:Button ID="btnDelete" runat="server" OnClientClick="return confirm('Do you want to Delete')" Text="Delete?" /></div>
  
    
     </div>
    
    </form>
</body>
</html>

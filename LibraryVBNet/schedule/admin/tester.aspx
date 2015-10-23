<%@ Page Language="vb" AutoEventWireup="false" CodeFile="tester.aspx.vb" Inherits="tester" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <cc1:Grid ID="Grid1"  OnUpdateCommand="Grid1_UpdateCommand" runat="server" AllowGrouping="True" AllowKeyNavigation="true" AllowAddingRecords="True"
			EnableRecordHover="True" FolderStyle="/includes_shared/oboutSuite/Grid/styles/style_7" 
			ShowTooltipOnResize="False" Width="100%" AutoGenerateColumns="False" PageSize="50" AllowFiltering="True">
			
			<Columns>
				<cc1:Column DataField="event_id" id="event_id" Visible="False" Index="0" Width="0" ReadOnly="True" HeaderText="event_id"></cc1:Column>
				<cc1:Column DataField="lib_event" id="lib_event" HeaderText="lib_event" Index="1" Width="80" AllowEdit="true">
		         </cc1:Column>
		        <cc1:Column AllowEdit="True" HeaderText="Edit" Width="100" Index="12" ></cc1:Column>		
			</Columns>
	         

        </cc1:Grid>
    </div>
    </form>
</body>
</html>

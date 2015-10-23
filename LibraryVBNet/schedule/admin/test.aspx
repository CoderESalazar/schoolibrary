<%@ Page Language="vb" AutoEventWireup="false" CodeFile="test.aspx.vb" Inherits="test2" %>

<%@ Register Assembly="obout_Calendar2_Net" Namespace="OboutInc.Calendar2" TagPrefix="obout" %>

<%@ Register Assembly="obout_Grid_NET" Namespace="Obout.Grid" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Library Grid Test Page</title>

    <link href="mvwres:1-obout_Grid_NET.resources.styles.style_3.style.css,obout_Grid_NET, Version=3.0.0.0, Culture=neutral, PublicKeyToken=5ddc49d3b53e3f98"
        rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:Grid ID="Grid1" OnUpdateCommand="Grid1_UpdateCommand" runat="server" AllowGrouping="True"  AllowKeyNavigation="true" AllowAddingRecords="True"
			EnableRecordHover="True" FolderStyle="/includes_shared/oboutSuite/Grid/styles/style_7" 
			ShowTooltipOnResize="False" Width="100%" AutoGenerateColumns="False" PageSize="50" AllowFiltering="True">
       <Columns>
            <cc1:Column DataField="event_id" Visible="False" Index="0" Width="0" ReadOnly="True" HeaderText="event_id"></cc1:Column>
           
            <cc1:Column DataField="event_date" HeaderText="Event Date" Index="1" AllowEdit="true" EditTemplateId="tplDatePicker2" HeaderTemplateId="GridTemplate2">
            <TemplateSettings EditTemplateId="tplDatePicker2" /> 
            </cc1:Column>
                                
            <cc1:Column DataField="lib_event" HeaderText="Library Event" Index="2" AllowEdit="true">
            
           </cc1:Column>
            
            <cc1:Column DataField="event_details" width="400" wrap="True" HeaderText="Event Details" Index="3" AllowEdit="true">
            
            </cc1:Column>
           
            <cc1:Column DataField="attend_details" wrap="True" width="400" HeaderText="How to Attend" Index="4" AllowEdit="true">
            
            </cc1:Column>
           <cc1:Column AllowEdit="True" HeaderText="Edit" Width="100" Index="5" ></cc1:Column>
        </Columns>
            <Templates>
       
            <cc1:GridTemplate ID="tplDatePicker2" runat="server" ControlID="" ControlPropertyName="">
            
                <Template>
                <table cellspacing="0" cellpadding="0" style="border-collapse:collapse;">
                   <tr> 
                   
                    <td valign="top"> 
                    <input type="text" id="txtDate2" class="ob_gEC" style="width:50px;" />
                    </td> 
                    <td valign="top">
                    <obout:Calendar ID="Calendar1" runat="server" StyleFolder="/includes_shared/oboutSuite/calendar/styles/default"
                    DatePickerMode="true"
                    ShowYearSelector="true"
                    TextBoxId="txtDate2"
                    DatePickerImagePath="/includes_shared/oboutSuite/calendar/styles/icon2.gif" 
                    >
                    </obout:Calendar>
                    </td>
                   </tr> 
                   
                </table>
        
                    
                </Template>
            </cc1:GridTemplate>
               
            </Templates>

        
        
        </cc1:Grid>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
       
        
    </div>
    </form>
</body>
</html>

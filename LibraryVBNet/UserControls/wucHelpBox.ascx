<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucHelpBox.ascx.vb" Inherits="UserControls_wucHelpBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>


<asp:ScriptManagerProxy ID="smp1" runat="server"></asp:ScriptManagerProxy>
<asp:Button ID="btnScreenLink" runat="server" Text="Show Screen Help" />
<br />
<br />
<asp:Literal ID="ltlHelpField" runat="server"></asp:Literal>
<style type="text/css">
    .paneHeader
    {
    	text-align:left;
    }
</style>
<div align="center" style="margin-left:auto;margin-right:auto">

<cc1:Accordion ID="accGeneral" runat="server" BorderColor="Black" BorderWidth="1px"  HeaderCssClass="accordianHeader" HeaderSelectedCssClass="accordianSelected" ContentCssClass="accordianContent" Width="625px">
    <Panes>
        <cc1:AccordionPane ID="apGenDoc" runat="server">
            <Header> 
            <table> 
            <tr><td width="200" align="left"> 
                <asp:Image ID="imgGenDoc" runat="server" ImageUrl = "~/images/addnew.gif" />
               <asp:Label ID="lblExGenDoc" runat="server" Text="Expand"></asp:Label>
               
                </td><td width="210px">  
                <asp:Label ID="lblGenDoc" Text = "General Documentation" Font-Bold="true" Font-Size="Medium" runat="server" CssClass="paneHeader"></asp:Label>
               </td>
                <td align="right" width="200px">
                <asp:Image ID="imgHlpGenDoc" runat="server" ImageUrl = "~/images/help_button.gif" />
            </td> </tr></table></Header>
      
            <Content>
                <FTB:FreeTextBox ID="ftbGeneralDoc" runat="server" Height="200px" Width="617px">
                <Toolbars>
                        <FTB:Toolbar runat="server">
                        <FTB:NetSpell runat="server" />
                        <FTB:WordClean />
                    </FTB:Toolbar>
                </Toolbars>
                </FTB:FreeTextBox>
                <asp:Panel ID="pnlGeneralDoc" runat="server" CssClass="accordianPane">
                    <asp:Literal ID="ltlGeneralDoc" runat="server"></asp:Literal>
                </asp:Panel>
            </Content>
        </cc1:AccordionPane>
        <cc1:AccordionPane ID="apUserDoc" runat="server">
            <Header>
            <table><tr><td width="200px" align="left">
                <asp:Image ID="imgUserDoc" runat="server" ImageUrl = "~/images/addnew.gif" />
                <asp:Label ID="lblExYourDoc" runat="server" Text="Expand"></asp:Label>
                </td><td width="210px">
                <asp:Label ID="lblYourDoc" Text = "Your Notes" Font-Bold="true" Font-Size="Medium" runat="server"></asp:Label>
                </td><td align="right" width="200px">
                <asp:Label ID="lblDelDoc" runat="server" Text="Delete Comment"></asp:Label>
                <asp:CheckBox ID="cbUserDoc" runat="server" />
                </td></tr></table></Header>
            
            <Content>
                <FTB:FreeTextBox ID="ftbUserNotes" runat="server" Height="200px" Width="617px" BackColor="WhiteSmoke">
                <Toolbars>
                    <FTB:Toolbar runat="server">
                        <FTB:NetSpell runat="server" />
                        <FTB:WordClean />
                    </FTB:Toolbar>
                </Toolbars>
                </FTB:FreeTextBox>
            </Content>
        </cc1:AccordionPane>
    </Panes>
</cc1:Accordion>
<br /><br />
<asp:Label ID="lblOtherDoc" Text = "Other User's Notes" Font-Bold="true" Font-Size="Larger" runat="server"></asp:Label>
<cc1:Accordion ID="accEdit" runat="server" BorderColor="Black" BorderWidth="1px" Width="625px" HeaderCssClass="accordianHeader" HeaderSelectedCssClass="accordianSelected" ContentCssClass="accordianContent">
</cc1:Accordion>

<asp:Button ID="btnSave" runat="server" Text="Save" />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</div>
<asp:HiddenField ID="hfUserId" runat="server" />
<asp:HiddenField ID="hfSecurity" runat="server" />
<asp:HiddenField ID="hfScreenName" runat="server" />
<asp:HiddenField ID="hfUniqueUsrBlobID" runat="server" />
<asp:HiddenField ID="hfUniqueGdBlobID" runat="server" />
<asp:HiddenField ID="hfFieldName" runat="server" />
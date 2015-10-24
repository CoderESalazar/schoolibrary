<%@ Page Language="VB" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="guide.aspx.vb" Inherits="guide" title="Northcentral University Library" %>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>

 
 <asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
     
     <asp:Label id="LibGuideString" runat="server" text=""></asp:Label><br /><br />
               
    <h2 style="color:#00467F;"><asp:Label ID="GuideTitle" runat="server" Text=""></asp:Label></h2>
                                                 
        <br/> 

    <!--tabs are placed here-->   
     <asp:PlaceHolder ID="tabs" runat="server"></asp:PlaceHolder>
               <br/>   
    <div style="margin: 0 10px 10px 10px;font-size:1.2em;">          
        <asp:Label ID="GuideBody" runat="server" Text=""></asp:Label>
    </div>

    <div style="margin: 0px 10px 0px 10px;"> 
          <p style="font-family:Verdana; font-size:11px;">Copyright:
          Consider all Internet sites copyrighted. When using material from sources,
          be sure to properly cite in
          APA format and use quotation marks around direct quotes.</p>
        
        <p><font face="Verdana" size="1">Disclaimer:</font>
        <font face="Verdana" size="1px">
        Northcentral University Library is not responsible for the content appearing on any of the sites listed on the Library's pages.
        </font></p>
    </div> 
    </asp:Content>   
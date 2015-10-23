<%@ Page Language="vb" MasterPageFile="~/Compass.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="Northcentral University Library"%>
<%@ Register Src="~/UserControls/wucNavBar.ascx" TagName="NavBar" TagPrefix="wuc" %>
<%@ MasterType VirtualPath="~/Compass.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphMainContent" runat="server">  
        <table border="0" width="100%" cellpadding="0" cellspacing="0">
            <tr>
                    <td id="tdimage" width="75%">
                    
                    
                            <table border="0" align="right" width="100%" cellpadding="0" cellspacing="0">

                                <tr>
                                                                  
                                <td><h2 class="header">Library Workshops</h2></td>
                                                 
                                </tr>   
                             
                            </table>
                     </td>               
             
           
             </tr>
             
        </table>     

       <p>Library workshops are a great way to quickly become familiar with the NCU Library. Learn how to effectively use the Library’s resources and services and improve your research skills. To sign up for a Library workshop, click on the “Register” link below. 
        Note that Library workshops are scheduled in Mountain Standard Time. Click <a href="http://www.timeanddate.com/worldclock/converter.html">here</a> for a time zone converter. </p>
        <p>Library workshops require access to an Internet enabled computer for the entire length of the session. Workshops are typically between 30 and 60 minutes, and include time for questions and answers.</p>
       

        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:GridView ID="GridView1" Width="90%" CellPadding="10" runat="server" AutoGenerateColumns="False">
                          
                            <HeaderStyle BackColor="#C27B13" />
                            <AlternatingRowStyle BackColor="#BCBEC0" />
                            
                              <Columns>
                                 <asp:BoundField DataField="event_date" HeaderText="Event Date" />
                                 <asp:BoundField DataField="event_details" HtmlEncode="false" HeaderText="Event Details" />
                                 <asp:HyperLinkField DataNavigateUrlFields="event_id" HeaderText="Register for Event" ItemStyle-Width="50px" DataTextField="event_id" DataTextFormatString="Register" DataNavigateUrlFormatString="/schedule/view_details.aspx?event_id={0}"></asp:HyperLinkField>
                              </Columns>
                    
                    </asp:GridView>


        <p>If you have registered for a session and a schedule conflict has arisen, please click <asp:HyperLink ID="HyperLink1" NavigateUrl="cancel_workshop.aspx" runat="server">here</asp:HyperLink> to cancel your registration. 
        If you are unable to attend a live session, visit the <asp:HyperLink ID="HyperLink2" NavigateUrl="http://library.ncu.edu/wl_template.aspx?parent_id=271" Target="_blank" runat="server">Workshop Videos page</asp:HyperLink> to view recordings and to download the workshop outlines.</p>
        <table align="center">
            <tr>
                <td> <img src="http://library.ncu.edu/public_images/elrc/2013/web/what_you_think.jpg" alt="what_you_think" align="left"/><br /></td>
            </tr>
        </table>
       

        <p>If you have already attended a Library Workshop, please take the <asp:HyperLink ID="HyperLink3" NavigateUrl="https://ncu.co1.qualtrics.com/SE/?SID=SV_4Ux4PIwTA7WsQsZ" Target="_blank" runat="server"> Library Workshop Feedback Survey </asp:HyperLink>and let us know if the session helped you. We appreciate your comments and suggestions.</p>
        
 </asp:Content>   
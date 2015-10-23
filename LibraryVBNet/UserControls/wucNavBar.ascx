<%@ Control Language="VB" AutoEventWireup="false" CodeFile="wucNavBar.ascx.vb" Inherits="UserControls_wucNavBar" %>

<link href="/Styles/mainNav.css" rel="stylesheet" type="text/css" media="all" />

<script type="text/javascript" src="/scripts/menu_main_nav.js"></script>
    <script type="text/javascript" src="/scripts/ext-core-debug.js"></script>
    <script type="text/javascript" src="/scripts/lightbox_form.js"></script>
    
    <script type="text/javascript">
        function SetLinkVal(linkName) {
            document.getElementById("<%=hfLinkText.ClientID%>").value = linkName;
            alert(document.getElementById("<%=hfLinkText.ClientID%>").value);
            document.getElementById("<%=hfLinkText.ClientID%>").name = linkName;
        }
    </script>
       
<asp:ScriptManagerProxy ID="smpNavBar" runat="server"></asp:ScriptManagerProxy>        

         <ul id="main_nav">
  
    <div id="mainNavHide" runat="server">
    <li class="home"><a href="/">&nbsp;</a>
        <ul class="secondary" id="ulLink0" runat="server" visible="false">
            <asp:PlaceHolder ID="phSecLink0" runat="server"></asp:PlaceHolder>
            <li><asp:LinkButton ID="lblMyFaves" runat="server" Text="Most Visited"></asp:LinkButton>
                <ul class="terciary" id="ulLink00" runat="server" visible="false">
                    <asp:PlaceHolder ID="phThrdLink0" runat="server"></asp:PlaceHolder>
                </ul>
            </li>
        </ul>
    </li>
    <li class="programs"><asp:PlaceHolder ID="phLink1" runat="server"><asp:Literal ID="ltlLink1" runat="server" Text="<a>&nbsp;</a>"></asp:Literal></asp:PlaceHolder>
        <ul class="secondary" id="ulLink1" runat="server" visible="false">
            <asp:PlaceHolder ID="phSecLink1" runat="server"></asp:PlaceHolder>
        </ul>
    </li>
    <li class="why_northcentral"><asp:PlaceHolder ID="phLink2" runat="server"><asp:Literal ID="ltlLink2" runat="server" Text="<a>&nbsp;</a>"></asp:Literal></asp:PlaceHolder>
       <ul class="secondary" id="ulLink2" runat="server" visible="false">
            <asp:PlaceHolder ID="phSecLink2" runat="server"></asp:PlaceHolder>
       </ul>
    </li>
    <li class="admissions"><asp:PlaceHolder ID="phLink3" runat="server"><asp:Literal ID="ltlLink3" runat="server" Text="<a>&nbsp;</a>"></asp:Literal></asp:PlaceHolder>
        <ul class="secondary" id="ulLink3" runat="server" visible="false">
            <asp:PlaceHolder ID="phSecLink3" runat="server"></asp:PlaceHolder>             
        </ul>
    </li>
    <li class="news_events"><asp:PlaceHolder ID="phLink4" runat="server"><asp:Literal ID="ltlLink4" runat="server" Text="<a>&nbsp;</a>"></asp:Literal></asp:PlaceHolder>
        <ul class="secondary" id="ulLink4" runat="server" visible="false">
            <asp:PlaceHolder ID="phSecLink4" runat="server"></asp:PlaceHolder>               
        </ul>
    </li>
    <li class="about_northcentral"><asp:PlaceHolder ID="phLink5" runat="server"><asp:Literal ID="ltlLink5" runat="server" Text="<a>&nbsp;</a>"></asp:Literal></asp:PlaceHolder>
        <ul class="secondary" id="ulLink5" runat="server" visible="false">
            <asp:PlaceHolder ID="phSecLink5" runat="server"></asp:PlaceHolder>                
        </ul>
    </li>
    </div>
</ul>

<asp:HiddenField ID="hfLinkText" runat="server" />


       
<%@ Language=VBScript %>
<!-- #include virtual="/ADOVBS.inc"-->
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/CurrentLetmeinUserID.asp"-->
<!-- #include virtual="/letmeinlite/WhoIsIt.asp"-->

<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<!-- #include virtual="/includes/Header.asp"-->

<%
sSubDomain = lcase( Split( Request.ServerVariables("SERVER_NAME"), "." )(0) )
Dim strInsert


	strInsert = "Insert into stats_id_course_guides (user_id, site_id) Values ('" & CurrentLetmeinUserID() & "','" & sSubDomain & "')" 
	sSQL = strInsert


	dbElrc.Execute(sSQL)

Set rsThis = dbElrc.Execute("SELECT count(*) as the_count FROM dbo.concspec_list_v WHERE department_id = 'bus' AND gen_ed <> 1") 

    if iMaxMenuItems = rsThis("the_count") then
	    iMaxCols = 1
	    iMaxRows = Int( iMaxMenuItems / iMaxCols ) + 1
		    else 				
	    iMaxMenuItems = rsThis("the_count") 
	    iMaxCols = 2			
	    iMaxRows = Int( iMaxMenuItems / iMaxCols ) + 2	
    	
	    end if

rsThis.Close
Set rsThis = Nothing	

%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Course Guides</title>

<style type="text/css">
    a {
    color:#445577;
    font-size: .95em;
    font-family: verdana;
    } 
    a:hover { 
    text-decoration: none;
    background-color: lightgrey;
    color:black;
    }
    p { 
    font-size:.95em;
    font-family: verdana;
    margin-right: 10px;
    margin-left:10px;
    }
    h2 {
    color:#702318;
    font-family:verdana;
    }
    h3 {
    color:#702318;
    background:url(/library/images/elrc_logos/header_gradient2.gif);
    text-indent: 5px;
    font-family:verdana;
    background-repeat: no-repeat;
    }
    #tdimage {
    background-image: url(/library/images/elrc_logos/fadeWide1.jpg);
	background-repeat: no-repeat;
	}
    #tdImageHeader1 {
    background:url(/library/images/elrc_logos/header_gradient2.gif);
    background-repeat: no-repeat;
    text-indent:5px;
	}
    .borderTable { 
    padding: 2px 4px 2px 4px;
    border: 1px solid #702318;
    }
    
</style>
</head>
<body style="margin: 0 0 0 0">

<!--Header Information--> 
<a href="/"><img alt="" src="/library/images/www_logo_header1.jpg" border="0" /></a><br/> 
    <table width="100%" style="background-color: #cccc99;"> 
    
        <tr>
            <td style="text-indent: 5px;"><asp:HyperLink ID="HyperLink3" CssClass="links1" runat="server" NavigateUrl="http://www.ncu.edu/">Ask a Librarian</asp:HyperLink> |
            <asp:HyperLink ID="HyperLink4" CssClass="links1" runat="server" NavigateUrl="http://www.ncu.edu/">Leave Feedback</asp:HyperLink> |
            <asp:HyperLink ID="HyperLink5" CssClass="links1" runat="server" NavigateUrl="http://www.ncu.edu/">About Us</asp:HyperLink></td>
            <td align="right"><asp:HyperLink ID="SiteLogout" runat="server" CssClass="links1" Visible="false" NavigateUrl="~/logout.aspx">Logout</asp:HyperLink><asp:Button ID="SiteLogin" runat="server" Text="Login" visible="false" /></td>
            
        </tr>
        
   </table> 
<div style="background-color:#445577;"><asp:Label ID="Label1" runat="server" Text="" CssClass="Label1" Font-Size=".8em"></asp:Label></div>
<table border="0" width="100%" cellpadding="0" cellspacing="0">
    <tr>
            <td id="tdimage" width="75%">
            
            
                    <table border="0" align="right" width="100%" cellpadding="0" cellspacing="0">
                    <!--
                      <tr>
                            <td colspan="2"></td>
                          
                        </tr>
                        
                     --> 
                        <tr>
                         <td width="20%">&nbsp;</td>                                                          
                        <td valign="bottom" align="center"><br/><h2 style="color:#702318">
                            <asp:Label ID="title_page" runat="server" Text=""></asp:Label></h2></td>
                                         
                        </tr>   
                     
                    </table>
             </td>               
  
   
     </tr>
     
</table> 
<!--End of Header Information--> 

<br /> 



           <p>The Course Guides provide you with resources specific to a specialization and/or individual courses. Select a specialization to view resources. Each specialization offers course guides to individual courses available via dropdown menus, or use the search box above to locate a specific guide.</p>
     

<table cellpadding="5px"> 
        <tr>
           
    <%
    'this is the quick reference area of the page
    Set rsThis = dbElrc.Execute("SELECT department_discipline_id, discipline_title FROM dbo.department_disciplines" ) 
    while not rsThis.eof 
    
    %>

        <td width="33%" align="center"><a style="font-weight:700;" href="#<%=rsThis("department_discipline_id")%>"><%=rsThis("discipline_title")%></a></td> 
        
     <%rsThis.MoveNext  
       Wend
       rsThis.Close
       Set rsThis = Nothing 
        
      %>  
       
        
        </tr> 
    
</table> 

<div style="margin-left:5px;margin-right:5px;">
  
<!--Business Resources Area-->

  <table width="100%" class="newBorder" align="center">

     <th colspan="3" align="left">     
   

<%
'This is the header
Set rsThis = dbElrc.Execute("SELECT department_discipline_id, discipline_title FROM dbo.department_disciplines WHERE department_id = 'bus'")
   
    while not rsThis.eof
  
     %>
    
       <a id="<%=rsThis("department_discipline_id")%>"></a><h3><%=rsThis("discipline_title")%></h3>
    
 
    <%rsThis.MoveNext
    Wend
    rsThis.Close
    Set rsThis = nothing
    %>
    </th> 
    <tr>
          <td>  

        <%
        'children are displayed here
        Set rsGuide = dbElrc.Execute("SELECT guide_title, department_discipline_id, department_guide_main_id, display_id FROM concspec_list_v WHERE department_id = 'bus' AND gen_ed = 0 AND display_id = 'True' ORDER BY guide_title")
        iRow = 0
          while not rsGuide.eof 
           iRow = iRow + 1 %>
    
                 
            <a href="/library/research_help/course_guides/bus_template.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>"><%=rsGuide("guide_title")%></a><br />

            <% if ( iRow mod iMaxRows ) = 0 then Response.Write("</td><td valign=top>")%>
         
            <%rsGuide.MoveNext
            Wend
            rsGuide.Close
            Set rsGuide = nothing   
            %>
  
        </td>
   </tr>


</table>
<br /> 
<!--Education Resources Area-->
<table width="100%" class="newBorder" > 


<th colspan="3" align="left"> 

<%Set rsThis = dbElrc.Execute("SELECT department_discipline_id, discipline_title FROM department_disciplines WHERE department_id = 'edu'")

    while not rsThis.eof
    
     %>
    
    <a id="<%=rsThis("department_discipline_id")%>"></a><h3><%=rsThis("discipline_title")%></h3>
   
    <%rsThis.MoveNext
    Wend
    rsThis.Close
    Set rsThis = nothing
    %>
    
 </th> 
       <tr>
           <td> 

            <%Set rsGuide = dbElrc.Execute("SELECT guide_title, department_guide_main_id, display_id FROM concspec_list_v WHERE department_id = 'edu' AND gen_ed = 0 AND display_id = 'True' ORDER BY guide_title")
            iRow = 0
              while not rsGuide.eof 
                iRow = iRow + 1%>
          
                
                <a href="/library/research_help/course_guides/ed_template.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>"><%=rsGuide("guide_title")%></a><br />
                
                <%if (iRow Mod iMaxRows) = 0 then Response.Write("</td><td valign=top>")%>
                
             
                <%rsGuide.MoveNext
                Wend
                rsGuide.Close
                Set rsGuide = nothing
                %>
        
            </td>     
     
        </tr>
     
  </table> 

<br /> 
  
<!--Psychology Resources Area-->
<table width="100%" class="newBorder"> 
    <th colspan="3" align="left"> 
       
<%Set rsThis = dbElrc.Execute("SELECT department_discipline_id, discipline_title FROM dbo.department_disciplines WHERE department_id = 'psy'")

    while not rsThis.eof
    
     %>
    
    <a id="<%=rsThis("department_discipline_id")%>"></a><h3><%=rsThis("discipline_title")%></h3>
    
    
    <%rsThis.MoveNext
    Wend
    rsThis.Close
    Set rsThis = nothing
    %>
 
    </th> 
        <tr> 
        
            <td>  
        <%Set rsGuide = dbElrc.Execute("SELECT guide_title, department_guide_main_id, display_id FROM concspec_list_v WHERE department_id = 'psy' AND gen_ed = 0 AND display_id= 'True' ORDER BY guide_title")

          while not rsGuide.eof %>
    
                          
                <a href="/library/research_help/course_guides/psy_template.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>"><%=rsGuide("guide_title")%></a><br />

            <%rsGuide.MoveNext
            Wend
            rsGuide.Close
            Set rsGuide = nothing
            %>
    

            </td> 
      </tr>  
</table>
</div>
<br/>

<!--#include virtual= "/library/includes/newFooter.asp"-->
</body>
</html>

<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<!-- #include virtual="/includes/Header.asp"-->

<%Set rsThis = dbElrc.Execute("SELECT count(*) as the_count FROM dbo.concspec_list_v WHERE department_id = 'bus' AND gen_ed <> 1") 

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
    a {
    color:#445577;
    font-size: .95em;
    font-family:verdana;
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
  
    
</style>



    
</head>
<body style="margin: 0 0 0 0">

<!--#include virtual= "/library/includes/course_guide_header.asp"-->


<br /> 


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

<br />    

<div style="margin-left:5px;margin-right:5px;">
<!--Business Resources Area-->

  <table width="100%" class="newBorder" align="center">

     <th colspan="3" align="left">     
   

<%
'This is the header
Set rsThis = dbElrc.Execute("SELECT department_discipline_id, discipline_title FROM dbo.department_disciplines WHERE department_id = 'bus'")
   
    while not rsThis.eof
  
     %>
    
          <a id="<%=rsThis("department_discipline_id")%>"></a>
      
      <h3><%=rsThis("discipline_title")%></h3>
    
 
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
    
             
            <a href="band_aid.asp"><%=rsGuide("guide_title")%></a><br />

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
          
                
                <a href="band_aid.asp"><%=rsGuide("guide_title")%></a><br />
                
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
    <a id="<%=rsThis("department_discipline_id")%>"></a>
    <a id="A2"></a><h3><%=rsThis("discipline_title")%></h3>
    
    
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
    
                          
                <a href="band_aid.asp"><%=rsGuide("guide_title")%></a><br />

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

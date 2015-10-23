<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->


<% 

'response.Write(CurrentLetmeinUserId())
Set rsCount = dbThisUniversity.Execute("Select count(ec.course_code) As the_count from elrc_cr_guides ec INNER JOIN learner_courses lc on ec.course_code = lc.course_code where lc.completed_date IS NULL AND lc.learner_id = '" &  CurrentLetmeinUserID() & "'") 

    if rsCount("the_count") > 0 then 
    
       Set rsThis = dbThisUniversity.Execute("Select learner_id, ec.course_code, ec.guide_id from learner_courses lc INNER JOIN elrc_cr_guides ec ON lc.course_code = ec.course_code where learner_id= '" &  CurrentLetmeinUserID() & "' AND completed_date is NULL") 
                  
            course_guide = rsThis("course_code")   
            guide_id = rsThis("guide_id") 

        rsThis.Close
        Set rsThis = Nothing 
      
     else
     
    'response.Write(rsCount("the_count")) 
 
  
 
rsCount.Close
Set rsCount = Nothing
End if

 %> 


<html>
<head>
    <title>My e-Reference Area</title>

<style type="text/css"> 
    body { 
    margin: 0px; font: 500 1em verdana;
    font-family: verdana;
    }
   .borderTable { 
    padding: 2px 4px 2px 4px;
    border: 1px solid #702318;
    font-size: .9em;
    }
 
</style>    
    
    
</head>
<body style="font-family:Verdana; font-size: .9em;">


<table cellpadding="0" cellspacing="0" border="0" style="margin-bottom:-3px;">
	<tr>
		<td style="background-color: #700; color: White; white-space: nowrap; height: 40px;">
			
			<a href="/library/"><img src="/library/images/elrc_logos/header_globeSm.jpg" alt="" border="0" /></a> 
			
		</td>
		<td style="background-color: #700; color: White; white-space: nowrap; height: 40px;">
		    <div>Northcentral University</div> 
	        <div style="font-weight: 700; font-size: 1.1em;">My e-Reference Area</div> 
		</td>
		<td style="background-color: #700; color: White; white-space: nowrap; height: 40px;">
			<img src="/library/images/elrc_logos/headerFadeSm.jpg" alt="" /> 
		

		</td>
   
	</tr>
</table>	    

<table border="0" width="100%" style="background-color:#cccc99;"> 
    <tr> 
    
        <td><a style="color:Black; font-size: .9em; text-indent: 5px;" href="/library/">Library Home</a></td> 
        <td>&nbsp;</td> 
     
        <td align="right"><a href="/library/ncu_kb/user/user_page.aspx" style="color: black; font-size:.9em;">Ask a Librarian</a></td> 
        
  </tr> 
     
</table> 
    <br /> 
 
 
<div style="margin:10px 0px 10px 10px;"> 
<table border="0"> 

     <tr> 
       
<%   
'Dim sUserId 

'sUserId = CurrentLetmeinUserID()

'this was a tough fix, keep this one in your memory...
Set rsCount = dbElrc.Execute("Select count(u_last_name) As the_count from quest_tb WHERE q_status is not NULL AND q_status LIKE '%Submitted to KB%' AND user_id = '" &  CurrentLetmeinUserID() & "'") 

'Response.Write(rsCount("the_count")) 
'Response.Write(sUserId)  

    if rsCount("the_count") > 0 then 

        Set rsThis = dbElrc.Execute("select quest_tb.q_id, quest_tb.u_first_name, quest_tb.u_last_name, user_id, quest_tb.date_time, q_detail, quest_lib.lib_response from quest_tb INNER JOIN quest_lib ON quest_tb.q_id = quest_lib.q_id where quest_tb.user_id = '" &  CurrentLetmeinUserID() & "' AND quest_lib.q_status LIKE '%Submitted to KB%' ORDER BY  quest_tb.date_time DESC") 
                
               first_name = rsThis("u_first_name") 
               last_name = rsThis("u_last_name") %>
               
               <td>Hello <%=first_name%>&nbsp;<%=last_name%>. This is your My e-Reference area where all your reference questions are answered and made available. To view the Librarian's response to your e-reference question(s), click on the View Response link.  </td>
               
               
               <td align="center"> 
               
                    <table class="borderTable">
                        <tr> 
                        
                            <td style="background-color:#cccc99;font-family:Verdana;"><div style="font-weight:700;">Need help with an assignment or course?</div><div style="font-weight:700;"> Check out available course guide(s).</div></td>
                             
                            
                       </tr> 
                        <tr> 
                        <%if LEN(course_guide) > 0 then %>
                        
                            <td><a target="_blank" href="/library/research_help/course_guides/crg.asp?guide_id=<%=guide_id%>"><%=course_guide%></a></td> 
                        
                            <%else%>

                            <td>Sorry, no guides available</td>                     
                            
                        <%end if%>
                       </tr>               
                       
                    </table> 
                    
                </td>  
               
               </tr>
        </table> 

<table> 

       
       <%
        
        while not rsThis.eof
        
        quest_detail = rsThis("q_detail") 
        lib_response = rsThis("lib_response") 
         %> 
         
        <tr> 
            <td><strong>Date Question Submitted:</strong> <%=rsThis("date_time")%>. MST</td><td>&nbsp;</td><td><a style="color:#445577;font-size: .9em;" href="/library/ncu_kb/user/view.aspx?q_id=<%=rsThis("q_id")%>">View Response</a> </td>
        </tr>
         
        <tr>
            <td style="font-size: .9em;">Question Submitted: <%=Response.Write(mid(quest_detail, 1, 80))%>...</td>
           
            
            </tr>
        
        <!--
        <tr> 
    
            <td style="font-size: .9em;">Librarian Response: <%'=Response.Write(mid(lib_response, 1, 60))%>...</td>
        </tr>
      --> 
         <tr> 
            <td>&nbsp;</td>
            
        </tr>  
    <% rsThis.MoveNext 
    Wend   

    rsThis.Close
    Set rsThis = Nothing 
     %>



</table>

        <%else%>
        
<table> 

        <tr> 
        
            <td>Welcome to your My e-Reference Area, the place where all your reference questions are answered. Sorry, no reference question(s) have been submitted or they are being answered. If you need assistance with any of the Library resources and services, please contact us by clicking <a style="font-family: Verdana; color: #445577;" href="/library/ncu_kb/user/user_page.aspx">Ask a Librarian.</a> We appreciate your patience.</td> 
            
        </tr> 
        
</table> 

        <%end if%>

 

<p>Have you checked out these areas of the Library? <a style="color:#445577;" target="_blank" href="/library/dw_template.asp?parent_id=8">NCU Databases</a>, <a target="_blank" style="color:#445577;" href="/library/research_help/course_guides/default.asp">Course Guides</a>, and <a style="color:#445577;" target="_blank" href="/library/qz_template.asp?parent_id=152">Guides & Quizzes</a></p> 
</div>

<!--#include virtual= "/library/includes/newFooter.asp"-->


                

</body>
</html>

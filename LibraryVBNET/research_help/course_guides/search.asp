<%@ Language=VBScript %>
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/includes/Header.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ezproxy_md5_ticket.asp" -->

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Search Page</title>
</head>
<body style="font-family: Verdana;">

<h2>Results</h2> 
<% 

sSearchString = trim( replace(Request.QueryString("search"),";","") )
if len( sSearchString ) > 0 then 

    Set rsThis = dbThisUniversity.Execute("Select ecr.guide_id, ecr.course_code, ecr.guide_title, ecr.display_id, ci.course_name from elrc_cr_guides ecr INNER JOIN course_info ci ON ecr.course_code = ci.course_code WHERE ecr.course_code LIKE '%" & ADOStringFieldExec( sSearchString ) & "%' OR ecr.guide_title LIKE '%" & ADOStringFieldExec( sSearchString ) & "%' ORDER By ecr.course_code" )  
        iRow = 0 
        
        %> 
        
       
        <%
        if not rsThis.eof then
    
        do while not rsThis.eof 
        
        
        iRow =+ 1 
       
        %>
           
        
           
              
         <div><a href="/library/research_help/course_guides/crg.asp?guide_id=<%=rsThis("guide_id")%>"><%=rsThis("course_code")%></a> - <%=rsThis("course_name")%></div> 
        
        
                     
   
   
   <%rsThis.MoveNext
   loop%> 
   
   <%else 
   
   response.Write("Sorry, nothing was found")
   
   end if
    %>
   
   
   <%
    rsThis.Close
    Set rsThis = Nothing
    %> 
    
            
<%else %>


<%Response.Write("Please type something in the search box.")%>



<%end if%>    
        
            



</body>
</html>

<%@ Language=VBScript %>
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Feedback Viewer Page</title>
</head>
<body>


<table width="80%" border="1" >     
<% 
Set rsThis = dbElrc.Execute( "SELECT u_first_name, u_last_name, email_address, deg_prog, notes_comments, date_time, user_id FROM quest_tb_1 ORDER BY date_time DESC" )
    

%>
  	<tr>
		<th>Full Name</th>
		<th>Email address</th>
		<th>Comments</th>
		<th>Degree Program</th>
		<th>Date/Time</th> 
		<th>User ID</th>
	
	</tr>
<%  while not rsThis.eof        %>	
	<tr> 
	    <td><%=rsThis("u_last_name")%>, <%=rsThis("u_first_name")%>&nbsp;</td>
	    
	    <td><%=rsThis("email_address")%>&nbsp;</td>
	    
	    <td><%=rsThis("notes_comments")%>&nbsp;</td>
	    
	    <td><%=rsThis("deg_prog")%>&nbsp;</td>
	    
	    <td><%=rsThis("date_time")%>&nbsp;</td>
	    
	    <td><%=rsThis("user_id")%>&nbsp;</td>
	    
	    
	</tr> 
	<%
	 rsThis.MoveNext
	wend
    %>
</table>

    <%
    
    rsThis.Close
    Set rsThis = nothing
    dbElrc.Close
    Set dbElrc = nothing
     %>
 
</body>
</html>

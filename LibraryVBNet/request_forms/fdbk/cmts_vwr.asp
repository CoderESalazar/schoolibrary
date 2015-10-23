<%@ Language=VBScript %>
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->


<% 
Set rsThis = dbElrc.Execute( "SELECT * FROM elrc_feedback_main ORDER BY entered_datetime DESC" )
%>


<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>


<table cellpadding= "5px" border="1px"> 
	<tr>
		<th>Full Name</th>
		<th>Email address</th>
		<th>Comments</th>
		<th>Date/Time</th> 
	</tr>

	<%
	while not rsThis.eof %>
		<tr>
			<td>
			  <%=rsThis("full_name")%>&nbsp
			</td>
			<td>
		     <%=rsThis("email_address")%>&nbsp
			</td>
			<td>
			  <%=rsThis("notes_comments")%>&nbsp
			</td>
			<td> 
			  <%=rsThis("entered_datetime")%>&nbsp
			</td> 
		</tr>
		<% rsThis.MoveNext
	wend
	%>

</table> 

</BODY>
</HTML>


<%
rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing
%>

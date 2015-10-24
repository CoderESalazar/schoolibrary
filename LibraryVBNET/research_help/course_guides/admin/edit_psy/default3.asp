<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_corp/EnvPrefix.asp" -->

<%
iKey = CInt(trim(replace(Request.QueryString("course_guide_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM concspec_course_list_v WHERE course_guide_id = " & iKey ) 


%> 


<HTML>
<HEAD>
	<title>Edit Individual Course Title</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">


</HEAD>
<body topmargin="0" leftmargin="0">

<form action="default_action3.asp" method="POST" id="form1" name="form1">
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="course_guide_id" value="<%=iKey%>">
		<tr valign="top">
			<td align="right">Course Title:</td>
			<td><input type="text" name="course_code" size="20" value="<%=rsDW("course_code")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">URL #:</td>
			<td><input type="text" name="url_address" size="20" value="<%=rsDW("url_address")%>" /></td>
		</tr>
	
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Course" name="action" /></td>
		</tr>
	
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=DeleteCourse&course_guide_id=<%=rsDW("course_guide_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>






</BODY>
</HTML>
<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>





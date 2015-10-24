<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->


<%
iKey = CInt(trim(replace(Request.QueryString("guide_header_info_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM guide_headers_info WHERE guide_header_info_id = " & iKey ) 


%> 


<HTML>
<HEAD>
	<title>Edit Header</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">


</HEAD>
<body topmargin="0" leftmargin="0">

<form action="default_action.asp" method="POST" id="form1" name="form1">
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="guide_header_info_id" value="<%=iKey%>">
		<input type="hidden" name="department_discipline_id" value="<%=rsDW("department_discipline_id")%>">
		<tr valign="top">
			<td align="right">Header Title <font color="red"><b>"required"</b></font></td>
			<td><input type="text" name="head_title" size="20" value="<%=rsDW("head_title")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">Display Order:</td>
			<td><input type="text" name="display_order" size="20" value="<%=rsDW("display_order")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Header" name="action"></td>
		</tr>
	
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=DeleteHead&guide_header_info_id=<%=rsDW("guide_header_info_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>






</BODY>
</HTML>
<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>




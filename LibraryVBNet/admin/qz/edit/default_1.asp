<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->

<!-- #include virtual="/includes_corp/EnvPrefix.asp" -->

<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<%
iKey = CInt(trim(replace(Request.QueryString("guide_header_id"),";","")))

Set rsHeader = dbElrc.Execute("SELECT guide_header_id, guide_header FROM guide_table_1 WHERE guide_header_id = " & iKey ) 


sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)%>

<HTML>
<HEAD>
	<title>Edit Header Page</title>
	<link rel="stylesheet" type="text/css" href="/style.css" />
	<link rel="stylesheet" type="text/css" href="/style_list.css" />
	<style type="text/css">

	</style>

</HEAD>

<%if sSite = "ncu" then %>

<body style="background-color:lightyellow;">

<h2>Edit Header</h2> 

<form action="default_action.asp" method="POST">
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="guide_header_id" value="<%=rsHeader("guide_header_id")%>">
		<tr valign="top">
			<td align="right">Header Name:</td>
			<td><input type="text" name="guide_header" size="40" value="<%=rsHeader("guide_header")%>"></td>
		</tr>
		
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Header" name="action"></td>
		</tr>
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=DeleteHeader&guide_header_id=<%=rsHeader("guide_header_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>


</body>
<%else%>

<body style="background-color:lightgrey;">

<h2>Edit Guides</h2> 

<form action="default_action.asp" method="POST">
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="guide_header_id" value="<%=rsHeader("guide_header_id")%>" />
		<tr valign="top">
			<td align="right">Header Name:</td>
			<td><input type="text" name="guide_header" size="40" value="<%=rsHeader("guide_header")%>" /></td>
		</tr>
		
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Header" name="action"></td>
		</tr>
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=DeleteHeader&guide_header_id=<%=rsHeader("guide_header_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>


</body>

<%end if %>

<%
rsHeader.Close
Set rsHeader = nothing
dbElrc.Close
Set dbElrc = nothing
%>

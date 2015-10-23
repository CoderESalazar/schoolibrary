<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->

<%
iKey = CInt(trim(replace(Request.QueryString("key_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM elrc_wl_info WHERE key_id = " & iKey ) 


%> 


<HTML>
<HEAD>
	<title>Info Pages</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">
	<style><!-- 
		TEXTAREA { display: block; overflow-x: hidden;overflow-y: visible; }
	-->
	</STYLE>

</HEAD>
<body topmargin="0" leftmargin="0">

<form action="default_action.asp" method="POST" id=form1 name=form1>
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="key_id" value="<%=rsDW("key_id")%>">
		<tr valign="top">
			<td align="right">Title:</td>
			<td><input type="text" name="title_wl" size="60" value="<%=rsDW("title_wl")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">WL Description:</td>
			<td><input type="text" name="desc_wl" size="60" value="<%=rsDW("desc_wl")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Info" name="action"></td>
		</tr>
	
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=DeleteInfo&key_id=<%=rsDW("key_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>






</BODY>
</HTML>
<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>


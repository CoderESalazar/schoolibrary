<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->

<%
iKey = CInt(trim(replace(Request.QueryString("key_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM elrc_wl_cat WHERE key_id = " & iKey ) 


%> 


<HTML>
<HEAD>
	<title>Cat Pages</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">


</HEAD>
<body topmargin="0" leftmargin="0">

<form action="default_action.asp" method="POST" id=form1 name=form1>
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="key_id" value="<%=rsDW("key_id")%>">
		<tr valign="top">
			<td align="right">Category Title:</td>
			<td><input type="text" name="cat_id" size="20" value="<%=rsDW("cat_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Parent ID: </td>
			<td><input type="text" name="parent_id" size="20" value="<%=rsDW("parent_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Order ID:</td>
			<td><input type="text" name="order_id" size="20" value="<%=rsDW("order_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Cat" name="action"></td>
		</tr>
	
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=DeleteCat&key_id=<%=rsDW("key_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>






</BODY>
</HTML>
<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>



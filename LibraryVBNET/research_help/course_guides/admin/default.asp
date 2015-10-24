<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->

<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<% LetMeInApplicationKey = "Library" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->




<%'
'Set rsNLMain = Server.CreateObject("ADODB.Recordset")
'rsNLMain.Open "SELECT ecg.*,category_title FROM elrc_cr_guides ecg LEFT JOIN elrc_cr_categories ecc ON ecg.cr_cat_id = ecc.cr_cat_id ORDER BY category_title,guide_title", dbThisUniversity, adOpenForwardOnly, adLockReadOnly
%>

<% sOrderKey = "guide_id"
if len(trim(Request.QueryString("order_by"))) > 0 then sOrderKey = trim(Request.QueryString("order_by"))
%>

<html>
<head>
	<title>Course Related Subject Guides</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">
</head>

<body topmargin="0" leftmargin="0">

<%' Call Header( "Course Related Guides", 0, nothing ) %>
<p>
<table border="0" cellPadding="0" cellSpacing="0">
	<tr valign="top" class="ListTitle">
		<td colspan="5">Course Related Guides</td>
		<td colspan="1" align="right"><a href="addnew" style="color: white;">Add New</a></td>
	</tr>
	<tr valign="top" class="ListHeader">
		<td></td>
		<td><a href="default.asp?order_by=guide_id" style="color:white;">Code</a></td>
		<td><a href="default.asp?order_by=category_title" style="color:white;">Category</a></td>
		<td><a href="default.asp?order_by=guide_title" style="color:white;">Title</a></td>
		<td>Date</td>
		<td>View</td>
	</tr>
	<%Set rsNLMain = Server.CreateObject("ADODB.Recordset")
	
	sSQL = "SELECT ecg.*,category_title FROM elrc_cr_guides ecg LEFT JOIN elrc_cr_categories ecc ON ecg.cr_cat_id = ecc.cr_cat_id" 
	sOrder = " ORDER BY " & sOrderKey & " DESC"
	rsNLMain.Open ( sSQL & sOrder ), dbThisUniversity, adOpenForwardOnly, adLockReadOnly
	while not rsNLMain.EOF 
		iRowCount = iRowCount + 1 %>
		<tr valign="top" class="ListData<%=(iRowCount mod 2)%>">
			<td><a href="edit/default1.asp?guide_id=<%=rsNLMain("guide_id")%>"><img src="/images_shared/edit.gif" border="0" width="14" height="14" alt="Edit"></a></td>
			<td><%=rsNLMain("guide_id")%></td>
			<td><%=rsNLMain("category_title")%></td>
			<td><%=rsNLMain("guide_title")%></td>
			<td><%=rsNLMain("update_datetime")%></td>
			<td><a href="../crg.asp?guide_id=<%=rsNLMain("guide_id")%>" target="_blank">View</a></td>
		</tr>
		<% rsNLMain.MoveNext
	wend
	rsNLMain.Close
	Set rsNLMain = nothing %>
</table>
  

</body>
</html>

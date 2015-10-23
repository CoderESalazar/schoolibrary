<%@ Language=VBScript %>
<!-- #include virtual="/elrc/dbElrc.asp" -->
<% LetMeInApplicationKey = "Library" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->

<% sOrderKey = "title_dw"
if len(trim(Request.QueryString("order_by"))) > 0 then sOrderKey = trim(Request.QueryString("order_by"))
%>

<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<link rel="stylesheet" type="text/css" href="/style.css">
<link rel="stylesheet" type="text/css" href="/style_list.css">

</HEAD>
<BODY>

<%=Request.QueryString("IncomingMessage")%>

<h3>DW Pages</h3>
<a href="../default.asp">Back to selection</a><br>
<a href="../mm/addnew/default.asp">Add New</a><br>


<table width="80%" cellpadding="2px">
	<tr class="ListHeader"> 
		<th><a href="test.asp?order_by=key_id" style="color: white;">Key ID</a></th> 
		<th><a href="test.asp?order_by=title_dw" style="color: white;">DW Title</a></th> 
		<th>DW Type</th>  
	</tr> 
	<tr> 
		<% 
		sSQL = "SELECT * FROM elrc_dw_info"
		sOrder = " ORDER BY " & sOrderKey
		Set rsThis = dbElrc.Execute( sSQL & sOrder )
		while not rsThis.eof %>
		<%iRowCount = iRowCount + 1 %>
		<tr valign="top" class="ListData<%=(iRowCount mod 2)%>">
			<td width="10%"><%=rsThis("key_id")%></td>
			<td width="20%"><div><a href="edit/default.asp?key_id=<%=rsThis("key_id")%>"><%=rsThis("title_dw")%></a></td>
			<td width="10%"><%=rsThis("type_dw")%></td>
			</tr>
	<% rsThis.MoveNext 
wend %>

</table>

<P>&nbsp;</P>

</BODY>
</HTML>
<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->

<% sOrderKey = "title_dw"
if len(trim(Request.QueryString("order_by"))) > 0 then sOrderKey = trim(Request.QueryString("order_by"))
%>


<html>
<head>
<title>Admin Site</title>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
<link rel="stylesheet" type="text/css" href="/style.css" />
<link rel="stylesheet" type="text/css" href="/style_list.css" />
<style type="text/css">

</style>
</head>

<body style="background-color: lightyellow;">

<%=Request.QueryString("IncomingMessage")%>

    <h3 style="color:darkred;">NCU DW Pages</h3>
    <a href="../default.aspx">Back to Admin Area</a><br />
    <a href="../dw/addnew/default.asp">Add New</a><br />

        <table width="60%" cellpadding="2px">
	        <tr class="ListHeader"> 
		        <th><a href="default.asp?order_by=key_id" style="color: white;">Key ID</a></th> 
		        <th><a href="default.asp?order_by=title_dw" style="color: white;">DW Title</a></th> 

	        </tr> 

		        <% 
		        sSQL = "SELECT * FROM elrc_dw_info"
		        sOrder = " ORDER BY " & sOrderKey
		        Set rsThis = dbElrc.Execute( sSQL & sOrder )
		        while not rsThis.eof %>
		        <%iRowCount = iRowCount + 1%>
		        <tr valign="top" class="ListData<%=(iRowCount mod 2)%>">
			        <td width="10%"><%=rsThis("key_id")%></td>
			        <td width="20%"><a href="edit/default.asp?key_id=<%=rsThis("key_id")%>"><%=rsThis("title_dw")%></a></td>
		        </tr>
	        <% rsThis.MoveNext 
        wend %>

        </table>


</body>
</html>
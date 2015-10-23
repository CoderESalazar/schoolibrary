<%@ Language=VBScript %>

<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->

<% sOrderKey = "high_id"
if len(trim(Request.QueryString("order_by"))) > 0 then sOrderKey = trim(Request.QueryString("order_by"))

'sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>

<html>
<head>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
<title>Library Admin Site</title>
<link rel="stylesheet" type="text/css" href="/style.css" />
<link rel="stylesheet" type="text/css" href="/style_list.css" />

</head>

<%=Request.QueryString("IncomingMessage")%>
<body style="background-color: lightyellow;">

<h3 style="color:darkred;">All NCU Library Pages</h3>
<a href="../default.aspx">Back to Admin Area</a><br />
<a href="../mm/addnew/default.asp">Add Library Entry</a><br />

    <table cellpadding="2px">
	    <tr class="ListHeader"> 
		    <th><a href="default.asp?order_by=high_id" style="color: white;">Primary Key</a></th> 
		    <th><a href="default.asp?order_by=title_name" style="color: white;">Page Title</a></th> 
		    <th><a href="default.asp?order_by=type_page" style="color: white;">Page Type</a></th> 
		    <th><a href="default.asp?order_by=parent_id" style="color: white;">Parent ID</a></th>
		    <th>Link Data</th>
		    <th>Display Order</th>  

	    </tr> 
    	
	    <% 
	    sSQL = "SELECT high_id, title_name, type_page, link_data, parent_id, display_order FROM elrc_structure"
	    sOrder = " ORDER BY " & sOrderKey
	    Set rsThis = dbElrc.Execute( sSQL & sOrder )
	    while not rsThis.eof %>
		    <%iRowCount = iRowCount + 1 %>
	        <tr valign="top" class="ListData<%=(iRowCount mod 2)%>"> 
			    <td><%=rsThis("high_id")%></td> 
			    <td><a href="edit/default.asp?high_id=<%=rsThis("high_id")%>"><%=rsThis("title_name")%></a></td>
			    <td align="center"><a href="edit/default.asp?high_id=<%=rsThis("high_id")%>"><%=rsThis("type_page")%></a></td>
			    <td align="center"><a href="edit/default.asp?high_id=<%=rsThis("high_id")%>"><%=rsThis("parent_id")%></a></td>
			    <td><%=rsThis("link_data")%></td>
			    <td align="center"><%=rsThis("display_order")%>&nbsp;</td>
		    </tr>
	    <% rsThis.MoveNext 
    wend %>

    </table>

</body>
</html>

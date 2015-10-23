<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<%
iKey = CInt(trim(replace(Request.QueryString("high_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM elrc_structure WHERE high_id = " & iKey ) 

'sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>
 
<html>
<head>
	<title>NCU Library Pages</title>
	<link rel="stylesheet" type="text/css" href="/style.css" />
	<link rel="stylesheet" type="text/css" href="/style_list.css" />

</head>

<body style="background-color: lightyellow;">
<h1><font>Edit Library Page</font></h1>
 
<form action="default_action.asp" method="post" id="form1" name="form1">
	<input type="hidden" name="high_id" value="<%=rsDW("high_id")%>" />
	<table border="0" cellspacing="1" cellpadding="1">
		<tr valign="top">
			<td align="right">Title:</td>
			<td><input type="text" name="title_name" size="40" value="<%=rsDW("title_name")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">Type:</td>
			<td><input type="text" name="type_page" size="2" value="<%=rsDW("type_page")%>" /></td>
			
		</tr>
		<tr valign="top">
			<td align="right">Link Data:</td>
			<td><input type="text" name="link_data" size="60" value="<%=rsDW("link_data")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">Parent ID:</td>
			<td><input type="text" name="parent_id" size="2" value="<%=rsDW("parent_id")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">Display Order:</td>
			<td><input type="text" name="display_order" size="2" value="<%=rsDW("display_order")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Library" name="action" /></td>
		</tr>
	</table>
</form>

    <div align="right">
	    <a href="default_action.asp?action=Delete&high_id=<%=rsDW("high_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
    </div>

    <!-- automatically expand text areas based on input -->
    <script type="text/javascript" src="/includes_shared/jsTextareaRowExpand.js"></script>
    <script type="text/javascript">

    function initAllRowTextAreas() {
 	    var tas = document.getElementsByTagName("TEXTAREA");
 	    var l = tas.length;
	    for	(var i = 0; i < l; i++)
 		    new AdjustableRowsTextArea(tas[i]);
    }
     
    if (window.addEventListener) {
 	    window.addEventListener("load", initAllRowTextAreas, false);
    }
     
    </script>

</body>
</html>
<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>

<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%' sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>

<html>
<head>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
<title>Add New Info Page - NCU</title>
</head>

<body style="background-color:lightyellow;">

<h1>Add New Info Page - NCU</h1>

<form action="default_action.asp" method="post" id="form1" name="form1">
	Title of page: <input type="text" name="title_wl" size="20" /><br />
	Page Description: <input type="text" name="desc_wl" size="80" /><br /> 
	<input type="submit" value="Continue >" id="submit1" name="submit1" />
</form>

</body>
</html>
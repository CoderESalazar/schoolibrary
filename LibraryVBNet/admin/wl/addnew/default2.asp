<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->

<%' sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>

<html>
<head>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
<title>WL Add New Link</title>
</head>

<body style="background-color:lightyellow;">

<h1>WL Add New Link</h1>

<form action="default_action2.asp" method="post" id="form1" name="form1">
	Title of Link: <input type="text" name="title_id" size="60" /><br />
	URL: <input type="text" name="url_id" size="60" /><br />
	Description: <input type="text" name="desc_id" size="60" /><br />
	Parent ID: <input type="text" name="parent_id" size="2" value="<%=replace(Request.QueryString("parent_id"),";","")%>" /><br />
	<!--Order ID: <input type="text" name="display_order" size="2" value="<%=replace(Request.QueryString("display_order"),";","")%>"><br /> --> 
	<input type="submit" value="Continue >" id="submit1" name="submit1" />
</form>

</body>
</html>
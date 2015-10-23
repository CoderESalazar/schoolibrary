<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->

<% sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)%>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>

<%if sSite = "ncu" then %> 


<BODY style="background-color:lightyellow;">

<h1>Add New Category - NCU</h1>

<form action="default_action1.asp" method="POST" id=form1 name=form1>
	Title of Category Page: <input type="text" name="cat_id" size="60"><br>
	Parent ID: <input type="text" name="parent_id" size="2" value="<%=replace(Request.QueryString("parent_id"),";","")%>"><br>
	Order ID: <input type="text" name="order_id" size="2" value="<%=replace(Request.QueryString("order_id"),";","")%>"><br>
	<input type="submit" value="Continue >" id=submit1 name=submit1>
</form>

<%else%> 

<BODY style="background-color:lightblue;">

<h1>Add New Category - SCUPS</h1>

<form action="default_action1.asp" method="POST" id=form1 name=form1>
	Title of Category Page: <input type="text" name="cat_id" size="60"><br>
	Parent ID: <input type="text" name="parent_id" size="2" value="<%=replace(Request.QueryString("parent_id"),";","")%>"><br>
	Order ID: <input type="text" name="order_id" size="2" value="<%=replace(Request.QueryString("order_id"),";","")%>"><br>
	<input type="submit" value="Continue >" id=submit1 name=submit1>
</form>

<%end if%> 

</BODY>
</HTML>

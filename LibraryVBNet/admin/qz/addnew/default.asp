<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%  sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)


iKey = CInt(trim(replace(Request.QueryString("guide_header_id"),";","")))
'this connection might not be needed
'Set rsThis = dbElrc.Execute("SELECT * FROM guide_table WHERE guide_header_id = " & iKey ) 
%> 

<html>
<head>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
<title>Quiz Add New</title>
</head>

<%if sSite = "ncu" then %> 

<BODY style="background-color: lightyellow;">

<h1>Add a Guide/Quiz - NCU</h1>
<form action="default_action.asp" method="POST" id="form2">
    <input type="hidden" name="guide_header_id" value="<%=iKey%>"/>
<table>
	<tr>
	    <td>Guide/Quiz Title:</td>  
	    <td><input type="text" name="title_guide" size="40" /></td>
	</tr>
	<tr>
	    <td>URL:</td>
	    <td><input type="text" name="link_id" size="50" /></td>
	</tr> 
    <tr>
        <td>Format:</td>
        <td> <input type="text" name="format_id" size="20" /></td>
    </tr> 
    <tr>
        <td>Duration:</td>
        <td> <input type="text" name="length_id" size="20" /></td>
    </tr> 
	<tr>
	    <td>Sound:</td>
	    <td><input type="text" name="sound_id" /></td>
	</tr>
	<tr>
	   
	</tr>
	
</table>
<br /> 

<br /> 
    <input type="submit" value="Continue >" id="submit2" name="submit2" />
</form>

<%else%> 
<!--scups site begins-->

<BODY style="background-color: lightblue;">

<h1>Add a Guide/Quiz - SCUPS</h1>
<form action="default_action.asp" method="POST">
<input type="hidden" name="guide_header_id" value="<%=iKey%>"/>
<table>
    
	<tr>
	    <td>Guide/Quiz Title:</td>
	    <td><input type="text" name="title_guide" size="40" /></td>
	</tr>
	<tr>
	    <td>URL:</td>
	    <td><input type="text" name="link_id" size="50" /></td>
	</tr> 
    <tr>
        <td>Format:</td>
        <td><input type="text" name="format_id" size="20" /></td>
    </tr>
    <tr>
        <td>Duration:</td>
        <td><input type="text" name="length_id" size="20" /></td>
    </tr> 
	<tr>
	    <td>Sound:</td>
	    <td><input type="text" name="sound_id" /></td>
	</tr>
	
</table>
    <input type="submit" value="Continue >" id="submit1" name="submit1" />
</form>

<%end if%> 

</BODY>
</HTML>

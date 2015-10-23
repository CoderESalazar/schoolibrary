<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->


<html>
<head>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
<title>Admin Site</title>
</head>

<body style="background-color: lightyellow;">
    <form action="default_action.asp" method="post" id="form1" name="form1">

    <h1><font color="darkred">Add DW Page</font></h1>

    <table style="background-color:white;">

        <tr>
            <td>Title: <input type="text" name="title_dw" size="40" /></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><input type="submit" value="Continue >" id="submit1" name="submit1" />
            </td>
        </tr>
    </table>

     </form>
</body>
</html>
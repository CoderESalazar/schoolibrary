<%@ Language=VBScript %>
<!--#include virtual="/adovbs.inc" -->
<!--#include virtual="/includes_shared/dbThisUniversity.asp" -->
<!--#include virtual="/includes_shared/FormatName.asp" -->
<html>

<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="Microsoft FrontPage 4.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<title>NCU Dissertations</title>
</head>

<body style="MARGIN: 0px 0px 20px;font-family:Verdana;">

    <a href="/"><img src="/library/images/elrc_logos/www_logo_header.jpg" border="0"></a>
     

     <div style="background-color:#cccc99;"><a style="font-size:.9em;color:black;text-indent:5px;" href="/library/ncu_diss/default.asp">Previous Page</a></div>


<div style="margin: 10px 10px 10px 10px">
<%

   Set rsDissertationChecklist = Server.CreateObject("ADODB.Recordset")
   rsDissertationChecklist.Open "SELECT * FROM dissertation_checklist_report WHERE dissertation_id = " & Replace(Request.QueryString("dissertation_id"), "CAST", "--"), dbThisUniversity, adOpenForwardOnly, adLockReadOnly

%>

<table border="0" cellpadding="0">
	<tr valign="top">
		
		<td>
			<h2 style="color:#702318;">Author: <%=rsDissertationChecklist("learner_first_name")%>&nbsp;<%=rsDissertationChecklist("learner_middle_name")%>&nbsp;<%=rsDissertationChecklist("learner_last_name")%></h2>
		</td>
	</tr>
</table>

<h2 style="color:#702318;">Article Title: <%=rsDissertationChecklist("i899a_title_of_diss")%></h2>

<p><%=Replace(rsDissertationChecklist("dissertation_abstract"),vbCRLF,"<br>")%>


<hr>
<br>
<p>
Note that NCU dissertations are only available to currently enrolled students, faculty, and staff. If you 
are not affiliated with the University, please purchase this dissertation through 
<a target="_blank" href="http://wwwlib.umi.com/dxweb/gateway">UMI</a>. 
</p>
To view this dissertation, click <a style="color:#445577;" href="/library/ncu_diss/logon.asp?dissertation_id=<%=rsDissertationChecklist("dissertation_id")%>">here</a>. <a style="#702318" href="/library/ncu_diss/logon.asp?dissertation_id=<%=rsDissertationChecklist("dissertation_id")%>"><img src="/library/images/full_text_symbol.gif" alt="download" border="0"/></a>
<% rsDissertationChecklist.Close
Set rsDissertationChecklist = nothing 

%></div>
</body>

</html>


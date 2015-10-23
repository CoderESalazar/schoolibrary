<%@ Language=VBScript %>
<!--#include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<!-- #include virtual="/includes/Header.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dissertation Download</title>
</head>
<body>


<% sSQL =   "SELECT top 1* " &_
			    "FROM dissertation_checklist_report dcr " &_ 
			        "WHERE dcr.dissertation_id = " & Request.QueryString("dissertation_id") 




			
			
Set rsThis = dbThisUniversity.Execute(sSQL)
%>


<%while not rsThis.eof%>

<p style="color:red;font-weight:600;">Dissertations appearing on this website serve as examples only. For formatting and style elements, please refer to the NCU Dissertation Handbook for Learners, Dissertation Form and Style Handbook, DIS or RSH syllabi, and APA Manual. Formatting and style guidelines are continually being updated and the dissertations appearing on this website might not reflect the most recent changes to the handbooks, syllabi and/or APA Manual. If you have any questions, feel free to contact the NCU Writing Center at <a href="mailto:writing@ncu.edu">writing@ncu.edu</a></p>

<p>Reminder: This work is protected by copyright law (Title 17 U.S.C). </p>

<p>You will need Acrobat Reader to open the attached file.  You may download a free copy at 
<a href="http://www.adobe.com/products/acrobat/readstep2.html">http://www.adobe.com/products/acrobat/readstep2.html</a></p>


To view this dissertation, click this link 
<a href="download.asp?dissertation_id=<%=Request.QueryString("dissertation_id")%>">download file</a>


<%
rsThis.MoveNext
Wend%>



<%rsThis.Close
Set rsThis = nothing %>



</body>
</html>

<%@ Language=VBScript %>

<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<title>Ask a Librarian Form</title>
<link rel="stylesheet" type="text/css" href="/library/style_elrc_ncu.css">

</HEAD>
<body style="margin: 0px 0px 20px; font-family:Verdana;font-size: .9em;">
<a href="/"><img src="/library/images/elrc_logos/www_logo_header.jpg" border="0"></a>
<div style="background-color:#cccc99;"><a style="text-indent: 10px;font-size:.9em;color:Black;" href="/library/">Library Home</a></div>

<br/>
<div style="margin-left:20px;">Thank you for submitting your question. We will try to respond to your question as quickly as possible. Click <a href="/library/">here</a> to return to the NCU Library.</div>  

<br/>
<br/>
<br/>
<!--#include virtual= "/library/includes/newFooter.asp"-->
<%

dNow = Now()

Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM ncuelrc.dbo.quest_tb", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew

rsThis("user_id") = Request.Form("user_id")
rsThis("u_first_name") = Request.Form("first_name")
rsThis("u_last_name") = Request.Form("last_name")
rsThis("email_address") = Request.Form("email_address")
rsThis("cat_desc") = Request.Form("cat_drop")
rsThis("q_detail") = Request.Form("user_question")
rsThis("course_num") = Request.Form("course_num")
rsThis("assign_num") = Request.Form("assign_num")
rsThis("deg_prog") = Request.Form("deg_prog")

rsThis("date_time") = dNow

rsThis.Update

rsThis.Close
Set rsThis = nothing

'Set rsThis = dbElrc.Execute("SELECT title_id FROM guide_table WHERE entered_datetime = '" & dNow & "'")
'iKeyId = rsThis("title_id")
'Set rsThis = nothing

dbElrc.Close
Set dbElrc = nothing

'Response.Redirect("../edit/default.asp?title_id=" & iKeyId & "&IncomingMessage=Page added.") 




'dim Body
'Body = "e-Reference Request form" & vbcrlf & vbcrlf

'Body = Body & "User ID: " & Request.Form("user_id") & vbcrlf
'Body = Body & "First name: " & Request.Form("first_name") & vbcrlf
'Body = Body & "Middle name: " & Request.Form("middle_name") & vbcrlf
'Body = Body & "Last Name: " & Request.Form("last_name") & vbcrlf
'Body = Body & "Phone Number: " & Request.Form("phone_number") & vbcrlf
'Body = Body & "Email Address: " & Request.Form("email_address") & vbcrlf
'Body = Body & "Address Street: " & Request.Form("address_street") & vbcrlf
'Body = Body & "Address City: " & Request.Form("address_city") & vbcrlf
'Body = Body & "Address State: " & Request.Form("address_state") & vbcrlf
'Body = Body & "Zip Code : " & Request.Form("zip_code") & vbcrlf
'Body = Body & "Course Assignment: " & Request.Form("course_assign") & vbcrlf
'Body = Body & "Course Number: " & Request.Form("course_num") & vbcrlf
'Body = Body & "Question: " & Request.Form("assign_desc") & vbcrlf
'Body = Body & "Question: " & Request.Form("user_question") & vbcrlf
'Body = Body & "Postal Address: " & Request.Form("postal_address") & vbcrlf
'Body = Body & "Phone Number: " & Request.Form("phone_number") & vbcrlf
'Body = Body & "Question/Comment: " & Request.Form("question_comment") & vbcrlf
'Body = Body & "Resources Consulted: " & Request.Form("resources_consulted") & vbcrlf
'Body = Body & "Database Used: " & Request.Form("database") & vbcrlf
'Body = Body & "Internet Site: " & Request.Form("url") & vbcrlf
'Body = Body & "Other Resources: " & Request.Form("other_resources") & vbcrlf


'Set objMail = Server.CreateObject("Persits.MailSender")		' for ASPMail
'objMail.Reset                  ' for ASPMail
'objMail.Host = "smtp.ncu.edu"		' for ASPMail
'objMail.From = "library@ncu.edu"		' for ASPMail
'objMail.Subject = "e-Reference Request"		' for ASPMail or JMail
						
'objMail.AddAddress "library@ncu.edu"			' for ASPMail
'objMail.Body = Body

'objMail.Send

'set objMail=nothing

%> 



</body>
</HTML>

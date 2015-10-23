<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->

<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>
<P>Thank you. We appreciate your comments.</P>
<p>To return to the NCU Library, please click <a href="/">here.</a></p> 

<% 

dNow = Now()

Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM quest_tb_1", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew

rsThis("u_first_name") = Request.Form("first_name")
rsThis("u_last_name") = Request.Form("last_name")
rsThis("email_address") = Request.Form("email_address")
rsThis("deg_prog") = Request.Form("deg_prog")
rsThis("notes_comments") = Request.Form("notes_comments")
rsThis("date_time") = dNow
rsThis("user_id") = Request.Form("user_id")
rsThis.Update

rsThis.Close
Set rsThis = nothing

'Dim strInsert
'Dim strValues

'if Request.Form("Action") = "Submit" then 
'	strInsert = "Insert into elrc_feedback_main (notes_comments, full_name, email_address) Values (" & ADOStringFieldQ(Request.Form("notes_comments")) & "," & ADOStringFieldQ(Request.Form("full_name")) & "," & ADOStringFieldQ(Request.Form("email_address")) & ")"
'	sSQL = strInsert
'	Response.Write "sSQL: " & sSQL

'	dbElrc.Execute(sSQL)

'end if

' Done. Close the connection
'dbElrc.Close
'Set dbElrc = Nothing 

%> 
 
</BODY>
</HTML>

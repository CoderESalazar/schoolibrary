<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->

<%
Select Case replace(Request.QueryString("action"),";","")

Case "Delete"


	dbThisUniversity.Execute("DELETE FROM elrc_cr_guides WHERE guide_id = " & replace(Request.QueryString("guide_id"),";",""))
	Response.Redirect("../default.aspx?IncomingMessage=Guide Deleted.")

End Select

Select Case Request.Form("action")
Case "Creator" 
Set rsNLMain = Server.CreateObject("ADODB.Recordset")
rsNLMain.Open "SELECT guide_title, update_datetime, update_by, guide_body, course_code, display_id FROM elrc_cr_guides WHERE guide_id=" & Request.Form("guide_id"), dbThisUniversity, adOpenForwardOnly, adLockOptimistic

rsNLMain("guide_title") = Request.Form("guide_title")
'rsNLMain("course_code") = Request.Form("course_code")
rsNLMain("guide_body") = Request.Form("guide_body")
rsNLMain("update_datetime") = Now()
rsNLMain("update_by") = CurrentLetmeinUserID()

if Request.Form("display_id") = "True" then
    rsNLMain("display_id") = "True"
else 
    rsNLMain("display_id") = "False"
end if


rsNLMain.Update

rsNLMain.Close
Set rsNLMain = nothing
dbThisUniversity.Close
Set dbThisUniversity = nothing

Response.Redirect("../default.aspx?IncomingMessage=Your changes have been saved." )

End Select

Select Case Request.Form("action")

Case "Update" 

Set rsNLMain = Server.CreateObject("ADODB.Recordset")
rsNLMain.Open "SELECT guide_title, update_datetime, update_by, guide_body, course_code, display_id FROM elrc_cr_guides WHERE guide_id=" & Request.Form("guide_id"), dbThisUniversity, adOpenForwardOnly, adLockOptimistic

rsNLMain("guide_title") = Request.Form("guide_title")
rsNLMain("course_code") = Request.Form("course_code")
rsNLMain("guide_body") = Request.Form("guide_body")
rsNLMain("update_datetime") = Now()
'rsNLMain("update_by") = CurrentLetmeinUserID()

if Request.Form("display_id") = "True" then
    rsNLMain("display_id") = "True"
else 
    rsNLMain("display_id") = "False"
end if


rsNLMain.Update

rsNLMain.Close
Set rsNLMain = nothing
dbThisUniversity.Close
Set dbThisUniversity = nothing

Response.Redirect("../default.aspx?IncomingMessage=Your changes have been saved." )

End Select

%>
<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->

<%
Set rsNLMain = Server.CreateObject("ADODB.Recordset")
rsNLMain.Open "SELECT * FROM elrc_cr_guides", dbThisUniversity, adOpenForwardOnly, adLockOptimistic

dNow = Now()
rsNLMain.AddNew
rsNLMain("course_code") = Request.Form("guide_title")
'rsNLMain("course_code") = Request.Form("CourseCode")
rsNLMain("update_datetime") = dNow
rsNLMain("update_by") = CurrentLetmeinUserID()
rsNLMain.Update

rsNLMain.Close

rsNLMain.Open "SELECT * FROM elrc_cr_guides WHERE update_datetime='" & dNow & "'", dbThisUniversity, adOpenForwardOnly, adLockReadOnly
iId = rsNLMain("guide_id")
rsNLMain.Close
Set rsNLMain = nothing
dbThisUniversity.Close
Set dbThisUniversity = nothing

Response.Redirect("../edit/default1.asp?guide_id=" & iId )
%>
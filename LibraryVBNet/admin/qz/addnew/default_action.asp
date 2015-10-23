<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<%
dNow = Now()

Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM guide_table", dbElrc, adOpenForwardOnly, adLockOptimistic



rsThis.AddNew
rsThis("guide_header_id") = Request.Form("guide_header_id")
rsThis("title_guide") = Request.Form("title_guide")
rsThis("link_id") = Request.Form("link_id")
rsThis("format_id") = Request.Form("format_id")
rsThis("length_id") = Request.Form("length_id")
rsThis("sound_id") = Request.Form("sound_id")

rsThis("entered_datetime") = dNow

rsThis.Update

rsThis.Close
Set rsThis = nothing

Set rsThis = dbElrc.Execute("SELECT title_id FROM guide_table WHERE entered_datetime = '" & dNow & "'")
iKeyId = rsThis("title_id")
Set rsThis = nothing

dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../edit/default.asp?title_id=" & iKeyId & "&IncomingMessage=Page added.") 
%>
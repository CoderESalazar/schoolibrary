<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<%
Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM department_guides_main", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew
rsThis("guide_title") = Request.Form("guide_title")
rsThis("department_discipline_id") = ADOIntField( Request.Form("department_discipline_id"))
rsThis("gen_ed") = Request.Form("gen_ed")

rsThis.Update

rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../default_subject.asp?IncomingMessage=Resource Added" )
%>
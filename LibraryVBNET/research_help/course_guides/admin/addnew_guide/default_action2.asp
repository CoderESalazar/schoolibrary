<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<%
dNow = Now()

Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM dbo.course_guides_all", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew
rsThis("department_guide_main_id") = ADOIntField( Request.Form("department_guide_main_id"))
rsThis("department_discipline_id") = ADOIntField( Request.Form("department_discipline_id"))
rsThis("course_code") = Request.Form("course_code")
'rsThis("url_id") = ADOIntField( Request.Form("url_id"))
rsThis("course_name") =  Request.Form("course_name") 
rsThis("gen_ed") = Request.Form("gen_ed")
rsThis("entered_datetime") = dNow

rsThis.Update

rsThis.Close
Set rsThis = nothing

Set rsThis = dbElrc.Execute("SELECT department_guide_main_id FROM department_guides_main WHERE department_guide_main_id = " & Request.Form("guide_main_id"))
iKeyId = rsThis("department_guide_main_id")

'rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId )
%>

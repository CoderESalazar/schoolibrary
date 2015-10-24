<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->


<%
dNow = Now()

Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM guide_resources", dbElrc, adOpenForwardOnly, adLockOptimistic



rsThis.AddNew
rsThis("guide_header_info_id") = ADOIntField( Request.Form("guide_header_info_id"))
rsThis("key_id") = ADOIntField( Request.Form("key_id"))
rsThis("department_discipline_id") = ADOIntField( Request.Form("department_discipline_id"))
rsThis("resource_title") = Request.Form("resource_title") 
rsThis("url_resource") =  Request.Form("url_resource") 
rsThis("desc_resource") = Request.Form("desc_resource")
rsThis("display_order") = ADOIntField( Request.Form("display_order") )

rsThis("entered_datetime") = dNow
rsThis.Update

rsThis.Close
Set rsThis = nothing

Set rsThis = dbElrc.Execute("SELECT department_discipline_id FROM guide_resources WHERE entered_datetime = '" & dNow & "'")
iKeyId = rsThis("department_discipline_id")

dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId ) 

%> 
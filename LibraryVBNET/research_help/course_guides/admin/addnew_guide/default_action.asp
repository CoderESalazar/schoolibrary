<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<%
dNow = Now()

Select Case Request.Form("action")
Case "Add Header"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM guide_headers_info", dbElrc, adOpenForwardOnly, adLockOptimistic
	
    rsThis.AddNew
    rsThis("department_discipline_id") = Request.Form("department_discipline_id")
    rsThis("head_title") = Request.Form("header_title")
    rsThis("display_order") = ADOIntField(Request.Form("display_order"))
    rsThis("entered_datetime") = dNow
    rsThis.Update
    
    rsThis.Close
	Set rsThis = nothing
	
	Set rsThis = dbElrc.Execute("SELECT department_discipline_id FROM guide_headers_info WHERE entered_datetime = '" & dNow & "'")
    iKeyId = rsThis("department_discipline_id")
	
	dbElrc.Close
	Set dbElrc = nothing

Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId ) 

Case "Other Header"

Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM guide_headers_info", dbElrc, adOpenForwardOnly, adLockOptimistic
	
    rsThis.AddNew
    rsThis("department_discipline_id") = Request.Form("department_discipline_id")
    rsThis("head_title") = Request.Form("header_title")
    rsThis("display_order") = Request.Form("display_order")
    rsThis("entered_datetime") = dNow
    rsThis.Update

    rsThis.Close
	Set rsThis = nothing
	
	Set rsThis = dbElrc.Execute("SELECT department_discipline_id FROM guide_headers_info WHERE entered_datetime = '" & dNow & "'")
    iKeyId = rsThis("department_discipline_id")
	
	
	
	dbElrc.Close
	Set dbElrc = nothing

Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId ) 


end Select

%>


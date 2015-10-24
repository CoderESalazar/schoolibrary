<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->


<%

Select Case Request.QueryString("action")

Case "DeleteDetail"

    Set rsThis = dbElrc.Execute("SELECT department_discipline_id FROM guide_resources WHERE guide_resource_id = " & Request.QueryString("guide_resource_id"))
    iKeyId = rsThis("department_discipline_id")

	dbElrc.Execute("DELETE FROM guide_resources WHERE guide_resource_id = " & Request.QueryString("guide_resource_id"))
	Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId ) 
	
	
	rsThis.Close
	Set rsThis = nothing
    dbElrc.Close
	Set dbElrc = nothing
		
End Select

Select Case Request.Form("action")

Case "Update Link"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	
	rsThis.Open "SELECT * FROM guide_resources WHERE guide_resource_id = " & Request.Form("guide_resource_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	rsThis("resource_title") = Request.Form("resource_title")
	rsThis("url_resource") = Request.Form("url_resource")
	'rsThis("guide_header_info_id") = ADOIntField( Request.Form("guide_header_info_id") )
	rsThis("desc_resource") = Request.Form("desc_resource")
	rsThis("display_order") = ADOIntField (Request.Form("display_order") )
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	    
    Set rsThis = dbElrc.Execute("SELECT department_discipline_id FROM guide_resources WHERE guide_resource_id = " & Request.Form("guide_resource_id"))
    iKeyId = rsThis("department_discipline_id")
    'response.write("test")
    
    dbElrc.Close
	Set dbElrc = nothing
    
	Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId )
End Select
%> 

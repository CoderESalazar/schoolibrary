<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->


<%

Select Case Request.QueryString("action")

Case "DeleteHead"

    Set rsThis = dbElrc.Execute("SELECT * FROM guide_headers_info WHERE guide_header_info_id = " & Request.QueryString("guide_header_info_id"))
    iKeyId = rsThis("department_discipline_id")

	dbElrc.Execute("DELETE FROM guide_headers_info WHERE guide_header_info_id = " & Request.QueryString("guide_header_info_id"))
	Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId ) 
	
	
	rsThis.Close
	Set rsThis = nothing
    dbElrc.Close
	Set dbElrc = nothing
		
End Select

Select Case Request.Form("action")

Case "Update Header"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	
	rsThis.Open "SELECT * FROM guide_headers_info WHERE guide_header_info_id = " & Request.Form("guide_header_info_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	rsThis("head_title") = Request.Form("head_title")
	'rsThis("parent_id") = ADOIntField( Request.Form("parent_id") )
	rsThis("display_order") = ADOIntField (Request.Form("display_order") )
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	    
    Set rsThis = dbElrc.Execute("SELECT * FROM guide_headers_info WHERE guide_header_info_id = " & Request.Form("guide_header_info_id"))
    iKeyId = rsThis("department_discipline_id")
    
    dbElrc.Close
	Set dbElrc = nothing
    
	Response.Redirect("../guide.asp?department_guide_main_id=" & iKeyId )
End Select
%> 

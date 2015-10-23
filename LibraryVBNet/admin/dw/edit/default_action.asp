<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%

Select Case Request.QueryString("action")
Case "Delete"
	dbElrc.Execute("DELETE FROM elrc_dw_info WHERE key_id = " & Request.QueryString("key_id"))
	Response.Redirect("../default.asp?IncomingMessage=DW Page Deleted.")
	
	
End Select

Select Case Request.Form("action")
Case "Update DW"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM elrc_dw_info WHERE key_id = " & Request.Form("key_id"), dbElrc, adOpenForwardOnly, adLockOptimistic

	rsThis("title_dw") = Request.Form("title_dw")
	rsThis("text_dw") = Request.Form("text_dw")
	'rsThis("type_dw") = Request.Form("type_dw") 
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )
End Select
%>

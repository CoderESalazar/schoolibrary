<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%

Select Case Request.QueryString("action")
Case "Delete"
	dbElrc.Execute("DELETE FROM elrc_structure WHERE high_id = " & Request.QueryString("high_id"))
	Response.Redirect("../default.asp?IncomingMessage=Page Deleted.")
	
	
End Select

Select Case Request.Form("action")
Case "Update Library"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM elrc_structure WHERE high_id = " & Request.Form("high_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	
	rsThis("title_name") = Request.Form("title_name")
	rsThis("type_page") = Request.Form("type_page") 
	rsThis("link_data") = Request.Form("link_data") 
	rsThis("parent_id") = ADOIntField(Request.Form("parent_id"))
	rsThis("display_order") = ADOIntField( Request.Form("display_order") )
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )
End Select
%>

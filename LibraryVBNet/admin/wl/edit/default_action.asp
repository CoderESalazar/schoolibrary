<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%

Select Case Request.QueryString("action")
Case "DeleteDetail"
	dbElrc.Execute("DELETE FROM elrc_wl_detail WHERE key_id = " & Request.QueryString("key_id"))
	Response.Redirect("../default.asp?IncomingMessage=Page Deleted.")
Case "DeleteInfo"
	dbElrc.Execute("DELETE FROM elrc_wl_info WHERE key_id = " & Request.QueryString("key_id"))
	Response.Redirect("../default.asp?IncomingMessage=Page Deleted.")
Case "DeleteCat"
	dbElrc.Execute("DELETE FROM elrc_wl_cat WHERE key_id = " & Request.QueryString("key_id"))
	Response.Redirect("../default.asp?IncomingMessage=Page Deleted.")
	
End Select

Select Case Request.Form("action")
Case "Update Info"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM elrc_wl_info WHERE key_id = " & Request.Form("key_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	
	rsThis("title_wl") = Request.Form("title_wl")
	rsThis("desc_wl") = Request.Form("desc_wl") 
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )

Case "Update Cat"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM elrc_wl_cat WHERE key_id = " & Request.Form("key_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	
	rsThis("cat_id") = Request.Form("cat_id")
	rsThis("parent_id") = ADOIntField(Request.Form("parent_id"))
	rsThis("order_id") = ADOIntField(Request.Form("order_id"))
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )

Case "Update Detail"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM elrc_wl_detail WHERE key_id = " & Request.Form("key_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	
	rsThis("title_id") = Request.Form("title_id")
	rsThis("url_id") = Request.Form("url_id") 
	rsThis("title_id") = Request.Form("title_id") 
	rsThis("desc_id") = Request.Form("desc_id") 
	rsThis("display_order") = ADOIntField(Request.Form("display_order")) 
	'rsThis("protect_from_public") = Request.Form("protect_from_public") 
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )
End Select
%> 
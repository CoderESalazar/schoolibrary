<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%

Select Case Request.QueryString("action")
Case "Delete"
	dbElrc.Execute("DELETE FROM guide_table WHERE title_id = " & Request.QueryString("title_id"))
	Response.Redirect("../default.asp?IncomingMessage=QZ Guide Deleted.")
	
Case "DeleteHeader"
	dbElrc.Execute("DELETE FROM guide_table_1 WHERE guide_header_id = " & Request.QueryString("guide_header_id"))
	Response.Redirect("../default.asp?IncomingMessage=QZ Guide Deleted.")
	
End Select

Select Case Request.Form("action")
Case "Update Guide"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM guide_table WHERE title_id = " & Request.Form("title_id"), dbElrc, adOpenForwardOnly, adLockOptimistic

	rsThis("title_guide") = Request.Form("title_guide")
	rsThis("link_id") = Request.Form("link_id")
	rsThis("format_id") = Request.Form("format_id") 
	rsThis("length_id") = Request.Form("length_id") 
	rsThis("sound_id") = Request.Form("sound_id") 
	rsThis("notes_id") = Request.Form("notes_id") 
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )
	
Case "Update Header"	

    Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM guide_table_1 WHERE guide_header_id = " & Request.Form("guide_header_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	rsThis("guide_header") = Request.Form("guide_header")
	
	rsThis.Update
	
	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing
	
	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )
	
End Select
%>
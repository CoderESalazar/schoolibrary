<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOStringField.asp" -->
<%
'Response.Write("test")

Select Case Request.QueryString("action")
Case "DeleteDatabase"
	dbElrc.Execute("DELETE FROM db_index WHERE key_id = " & Request.QueryString("key_id"))
	Response.Redirect("../default.asp?IncomingMessage=Page Deleted.")

End Select

Select Case Request.Form("action")
Case "Update"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT db_title, url_id, full_text, cover_id, scholary_id, identify_id, desc_resource, display_id, pop_db FROM db_index WHERE key_id = " & Request.Form("key_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	
	rsThis("db_title") = Request.Form("db_title")
	rsThis("url_id") = trim (Request.Form("url_id") )
	rsThis("full_text") = UCase (Request.Form("full_text"))
	rsThis("cover_id") = Request.Form("cover_id")
	rsThis("scholary_id") = UCase (Request.Form("scholary_id"))
	rsThis("identify_id") = LCase (Request.Form("identify_id"))
	
	rsThis("desc_resource") = Request.Form("desc_resource")
	if Request.Form("display_id") = 1 then
	    rsThis("display_id") = 1
	else 
	    rsThis("display_id") = 0
	end if
	
	if Request.Form("pop_db") = 1 then
	    rsThis("pop_db") = 1
	else 
	    rsThis("pop_db") = 0
	end if
    
    rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

	Response.Redirect("../default.asp?IncomingMessage=Your changes have been saved." )
	End Select
	%> 

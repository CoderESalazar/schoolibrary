<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->

<%
Select Case Request.QueryString("action")
Case "Delete"
	dbElrc.Execute("DELETE FROM department_guides_main WHERE department_guide_main_id = " & Request.QueryString("department_guide_main_id") )
	Response.Redirect("../default_subject.asp?IncomingMessage=Item Deleted.")
End Select



Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM department_guides_main WHERE department_guide_main_id = " & Request.Form("department_guide_main_id"), dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis("guide_title") = Request.Form("guide_title")

if Request.Form("display_id") = "True" then
    rsThis("display_id") = "True"
else 
    rsThis("display_id") = "False"
end if

rsThis.Update

rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../default_subject.asp?IncomingMessage=Your changes have been saved." )
%>


<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->

<%
dNow = Now()

Set rsThis = Server.CreateObject("ADODB.Recordset")
    rsThis.Open "SELECT * FROM elrc_dw_info", dbElrc, adOpenForwardOnly, adLockOptimistic
    rsThis.AddNew
    rsThis("title_dw") = Request.Form("title_dw")
    rsThis("entered_datetime") = dNow

    rsThis.Update

    rsThis.Close
    Set rsThis = nothing

    Set rsThis = dbElrc.Execute("SELECT key_id FROM elrc_dw_info WHERE entered_datetime = '" & dNow & "'")
    iKeyId = rsThis("key_id")
    Set rsThis = nothing

    dbElrc.Close
    Set dbElrc = nothing

Response.Redirect("../edit/default.asp?key_id=" & iKeyId & "&IncomingMessage=Page added.") 
%>


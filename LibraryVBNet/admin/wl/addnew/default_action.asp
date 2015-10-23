<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->

<%
Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM elrc_wl_info", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew

rsThis("title_wl") = Request.Form("title_wl")
rsThis("desc_wl") = Request.Form("desc_wl")

rsThis.Update

rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../default.asp?IncomingMessage=Page added." )
%>


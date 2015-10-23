<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->

<%
Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM elrc_wl_cat", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew

rsThis("cat_id") = Request.Form("cat_id")
rsThis("parent_id") = ADOIntField (Request.Form("parent_id"))
rsThis("order_id") = ADOIntField (Request.Form("order_id"))
rsThis.Update

rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../default.asp" )
%>

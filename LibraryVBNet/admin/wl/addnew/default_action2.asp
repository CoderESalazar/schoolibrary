<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->

<%
Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM elrc_wl_detail", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew

rsThis("title_id") = Request.Form("title_id")
rsThis("url_id") = Request.Form("url_id")
rsThis("desc_id") = Request.Form("desc_id")
rsThis("parent_id") = ADOIntField( Request.Form("parent_id") )
rsThis("display_order") = ADOIntField( Request.Form("display_order") )

rsThis.Update

rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../default.asp?IncomingMessage=Page added." )
%>

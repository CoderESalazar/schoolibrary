<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<%
Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM guide_table_1", dbElrc, adOpenForwardOnly, adLockOptimistic



rsThis.AddNew
rsThis("guide_header") = Request.Form("guide_header")
rsThis("display_order") = Request.Form("display_order")

rsThis.Update

rsThis.Close
Set rsThis = nothing


Response.Redirect("../default.asp") 
%>

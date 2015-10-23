<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<%
Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM db_index", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew

rsThis("db_title") = Request.Form("db_title")
rsThis("url_id") = Request.Form("url_id")
rsThis("cover_id") = Request.Form("cover_id")
rsThis("full_text") = UCase (Request.Form("full_text"))
rsThis("scholary_id") = UCase (Request.Form("scholary_id"))
rsThis("identify_id") = LCase (Request.Form("identify_id")) 
rsThis("desc_resource") = Request.Form("desc_resource")
rsThis.Update

rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../default.asp?IncomingMessage=Database added." )
%>

<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<%
dNow = Now()

Set rsThis = Server.CreateObject("ADODB.Recordset")
rsThis.Open "SELECT * FROM elrc_structure", dbElrc, adOpenForwardOnly, adLockOptimistic

rsThis.AddNew

rsThis("title_name") = Request.Form("title_name")
rsThis("desc_text") = Request.Form("desc_text")
rsThis("type_page") = Request.Form("type_page")
rsThis("link_data") = Request.Form("link_data")
rsThis("parent_id") = ADOIntField( Request.Form("parent_id") )
rsThis("learner_view") = ADOIntField( Request.Form("learner_view") )
rsThis("mentor_view") = ADOIntField( Request.Form("mentor_view") )
rsThis("public_view") = ADOIntField( Request.Form("public_view") )
rsThis("entered_datetime") = dNow

rsThis.Update

rsThis.Close
Set rsThis = nothing


Set rsThis = dbElrc.Execute("SELECT high_id FROM elrc_structure WHERE entered_datetime = '" & dNow & "'")
iHighId = rsThis("high_id")
Set rsThis = nothing

dbElrc.Close
Set dbElrc = nothing

Response.Redirect("../default.asp?IncomingMessage=Page added." )
%>


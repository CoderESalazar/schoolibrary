<!--#include virtual="/adovbs.inc" -->
<!--#include virtual="/includes_shared/dbThisC.asp" -->


<%

Set dbThis=dbThisC("","","","","")

Set rsDissertationChecklist = Server.CreateObject("ADODB.Recordset")

sDBFieldName = "dissertation_file"

rsDissertationChecklist.Open "SELECT " & sDBFieldName & "_name," & sDBFieldName & " FROM dissertation_checklist WHERE dissertation_id = " & replace(Request.QueryString("dissertation_id"),";",""), dbThis, adOpenForwardOnly, adLockReadOnly

sFileName = rsDissertationChecklist( sDBFieldName & "_name" )

Response.ContentType = "application/octet-stream"

Response.AddHeader "content-disposition", "attachment;filename=" & sFileName

Response.BinaryWrite rsDissertationChecklist(sDBFieldName)

rsDissertationChecklist.Close

Set rsDissertationChecklist = nothing

dbThis.Close

Set dbThis = nothing
%>

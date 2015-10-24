<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->

<%

Select Case Request.Form("action")
Case "Continue"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	rsThis.Open "SELECT * FROM guide_resources WHERE guide_header_info_id = " & Request.Form("guide_header_info_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	
	sHeaderID = Request.Form("guide_header_info_id")
    sDisciplineID = Request.Form("department_discipline_id")
    sTitle = Request.Form("resource_title")
  
    
   	rsThis.Close
	Set rsThis = nothing
	dbElrc.Close
	Set dbElrc = nothing

end Select


%>

<html>
<head>
<title></title>

</head>
<body>

<form action="default_action_res.asp" method="POST" id="form1" name="form1">
    
	<input type="hidden" name="guide_header_info_id" value="<%=sHeaderID%>" /><br />
	<input type="hidden" name="department_discipline_id" value="<%=sDisciplineID%>" /><br />
	
	Resource Title: <input type="text" name="resource_title" value="<%=sTitle%>" size="40" /><br /> 
	
    Resource Description:  <br /> 
    <textarea cols="40" rows="5" name="desc_resource"></textarea><br />
    <br /> 
    
    Resource URL: <input type="text" name="url_resource" size="50" /><br /> 
    
    Display Order: <input type="text" name="display_order" size="1" /><br /> 
 
    <input type="submit" value="Continue" name="action" />

</form>	



    

</body>
</html>

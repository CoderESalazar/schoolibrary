<%@ Language=VBScript %>
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOBitField.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->


<% 

Select Case Request.QueryString("action")

Case "DeleteCourse"

	dbElrc.Execute("Delete FROM course_guides_all WHERE course_guide_id = " & Request.QueryString("course_guide_id"))
	Response.Redirect("../default_subject.asp")	
	
End Select

Select Case Request.Form("action")

Case "Update Course"
	Set rsThis = Server.CreateObject("ADODB.Recordset")
	
	rsThis.Open "SELECT * FROM course_guides_all WHERE course_guide_id = " & Request.Form("course_guide_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	'rsThis("course_guide_id") = Request.Form("course_guide_id")
	rsThis("course_code") = Request.Form("course_code")
	rsThis("url_address") = ADOIntField( Request.Form("url_address") )
	rsThis("gen_ed") = Request.Form("gen_ed")
	'rsThis("desc_id") = Request.Form("desc_id")
	'rsThis("display_order") = ADOIntField (Request.Form("display_order") )
	rsThis.Update

	rsThis.Close
	Set rsThis = nothing
	    
    Set rsThis = dbElrc.Execute("SELECT * FROM course_guides_all WHERE department_guide_main_id = " & Request.Form("department_guide_main_id"))
    iDeptId = rsThis("department_guide_main_id")
   
    
    dbElrc.Close
	Set dbElrc = nothing
    
	Response.Redirect("../default_subject.asp")
End Select
%> 

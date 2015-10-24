<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%' sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>

<% 
iKey = CInt(trim(replace(Request.QueryString("department_guide_main_id"),";","")))

 Set rsThisSub = dbElrc.Execute("SELECT * FROM course_guides_all WHERE department_guide_main_id = '" & iKey &"'") %>

<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<%'if sSite = "ncu" then%> 
    
<BODY>

<h2>Add an Individual Course</h2>
   

<form action="default_action2.asp" method="POST" id="form1" name="form1">

	<input type="hidden" name="department_guide_main_id" value="0" />
	
	<input type="hidden" name="department_discipline_id" value="1" />
	
	<input type="hidden" name="guide_main_id" value="<%=iKey%>" />
	
	Course Code(required, no spaces): <input type="text" name="course_code" size="10" /><br />
		
    Course Name(required): <input type="text" name="course_name" size="40" /><br />
      
    GenEd (required: True or False): <input type="text" name="gen_ed" size="10" />
	<br />
	<br />
	<input type="submit" value="Add >">
</form>
<%rsThisSub.Close
Set rsThisSub = nothing%>

 
</BODY>
</HTML>
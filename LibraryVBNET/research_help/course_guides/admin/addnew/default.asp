<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<h1>Add New Course Guide</h1>

<form action="default_action.asp" method="post" id="form1" name="form1">
	
	Title: 
	
	<select name="guide_title">
		<% Set rsThis = dbThisUniversity.Execute("SELECT ci.course_code, ci.course_name, ecr.guide_id, company_department_name from course_info ci LEFT JOIN elrc_cr_guides ecr ON ci.course_code = ecr.course_code where LEN(ci.company_department_name) > 0 and ci.course_end_date is NULL and ecr.guide_id is NULL ORDER BY course_code")
		while not rsThis.eof 
		
		'GuideTitle = rsThis("course_code") & "-" & rsThis("course_name")
		'CourseCode = rsThis("course_code")   
		%>

			<option value="<%=rsThis("course_code")%>"><%=rsThis("course_code")%></option>

            
			
			<% rsThis.MoveNext
		wend 
		
		rsThis.close
		Set rsThis = nothing
		%>
	</select>
	

	
	<br />
	<br />
	<input type="submit" value="Continue >" /> 
	
	
	
</form>

</BODY>
</HTML>

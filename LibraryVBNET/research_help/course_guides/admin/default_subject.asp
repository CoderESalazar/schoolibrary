<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<% LetMeInApplicationKey = "Library" %>


<%' 
'iParentId = 0
'if len(trim(Request.QueryString("parent_id"))) > 0 then iParentId = CInt(trim(Request.QueryString("parent_id")))

%>

<html>
<head>
	<title>Subject Guides Admin Area</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">

</head>

<body style="margin:0 0 0 0;">
<div style="margin:0 10 0 10;">
 <a style="background-color:yellow;" href="/admin/default.aspx">Back to Main Library Admin Area</a><br/>
<br/>
Which area to do you wish to edit: <br />

<!--Business and Technology section-->

<%Set rsThis = dbElrc.Execute("SELECT discipline_title, department_id FROM department_disciplines WHERE department_id = 'bus'")

    while not rsThis.eof
    
     %>
    
    <h3><%=rsThis("discipline_title")%></h3>
    
  
 
    
<%rsThis.MoveNext
 
Wend 
rsThis.Close
Set rsThis = nothing
%>
 
<%Set rsThis = dbElrc.Execute("SELECT department_discipline_id FROM concspec_list_v WHERE department_id = 'bus'")

    'while not rsThis.eof
    
     %>
      <a href="/research_help/course_guides/admin/addnew_guide/default3.asp?department_discipline_id=<%=rsThis("department_discipline_id")%>">Add a new specialization</a><br /><br />
        <%Set rsGuide = dbElrc.Execute("SELECT guide_title, department_discipline_id, department_guide_main_id FROM concspec_list_v WHERE department_id = 'bus' AND gen_ed = 0 ORDER BY guide_title")
          
          while not rsGuide.eof %>
       
                <%'Select case LCase(rsGuide("page_type")) 
           
                'case "bus"
						'sUrl = "bus.asp?key_id=" & rsGuide("key_id")
				'case "ed"
						'sUrl = "ed_template.asp?key_id=" & rsGuide("key_id")
				'case "psy"
						'sUrl = "psy_template.asp?key_id=" & rsGuide("key_id")
				'case "gen_ed"
						'sUrl = "gen_ed_template.asp?key_id=" & rsGuide("key_id")
                'end Select
                %>
            
          
            <a href="guide.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>"><%=rsGuide("guide_title")%> </a>&nbsp;<a style="font-size:10pt;color:red;" href="/research_help/course_guides/admin/edit_guide/default1.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>">edit title</a><br />

          
            
            <%rsGuide.MoveNext
            Wend
            rsGuide.Close
            Set rsGuide = nothing
            %>
    
    <%
    'rsThis.MoveNext
    'Wend
    rsThis.Close
    Set rsThis = nothing
    %>
    
    
    
 <!--Education Resources section-->   
 <br>
 <%Set rsThis = dbElrc.Execute("SELECT discipline_title, department_id FROM department_disciplines WHERE department_id = 'edu'")

    while not rsThis.eof
    
     %>
    
    <h3><%=rsThis("discipline_title")%></h3>
    
  
    
    
    <%rsThis.MoveNext
    Wend
    rsThis.Close
    Set rsThis = nothing
    %>
 
        
    
    <%Set rsThis = dbElrc.Execute("SELECT guide_title, department_discipline_id, department_guide_main_id FROM concspec_list_v WHERE department_id = 'edu' AND gen_ed = 0 ORDER BY guide_title")

    'while not rsThis.eof
    
     %>
       <a href="/research_help/course_guides/admin/addnew_guide/default3.asp?department_discipline_id=<%=rsThis("department_discipline_id")%>">Add a new specialization</a><br /><br />
        <%Set rsGuide = dbElrc.Execute("SELECT guide_title, department_discipline_id, department_guide_main_id FROM concspec_list_v WHERE department_id = 'edu' AND gen_ed = 0 ORDER BY guide_title")
        iRow = 0
          while not rsGuide.eof 
            'iRow = iRow + 1%>
            
                <%'Select case LCase(rsGuide("page_type")) 
           
                'case "bus"
						'sUrl = "bus_template.asp?parent_id=" & rsGuide("key_id")
				'case "ed"
						'sUrl = "ed_template.asp?parent_id=" & rsGuide("key_id")
				'case "psy"
						'sUrl = "psy_template.asp?parent_id=" & rsGuide("key_id")
				'case "gen_ed"
						'sUrl = "gen_ed_template.asp?parent_id=" & rsGuide("key_id")
                'end Select
                %>
            
            
            <a href="guide.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>"><%=rsGuide("guide_title")%> </a>&nbsp;<a style="font-size:10pt;color:red;" href="/research_help/course_guides/admin/edit_guide/default1.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>">edit title</a><br />

    
            
            <%rsGuide.MoveNext
            Wend
            rsGuide.Close
            Set rsGuide = nothing
            %>
    
    <%'
    'rsThis.MoveNext
    'Wend
    rsThis.Close
    Set rsThis = nothing
    %>
 
 <!--Psychology Resources section-->  
  <br>
 <%Set rsThis = dbElrc.Execute("SELECT discipline_title, department_id FROM department_disciplines WHERE department_id = 'psy'")

    while not rsThis.eof
    
     %>
    
    <h3><%=rsThis("discipline_title")%></h3>
    
  
    
    
    <%rsThis.MoveNext
    Wend
    rsThis.Close
    Set rsThis = nothing
    %>
 
        
    
    <%Set rsThis = dbElrc.Execute("SELECT guide_title, department_discipline_id, department_guide_main_id FROM concspec_list_v WHERE department_id = 'psy' AND gen_ed = 0 ORDER BY guide_title")

    'while not rsThis.eof
    
     %>
       <a href="/research_help/course_guides/admin/addnew_guide/default3.asp?department_discipline_id=<%=rsThis("department_discipline_id")%>">Add a new specialization</a><br /><br /> 
        <%Set rsGuide = dbElrc.Execute("SELECT guide_title, department_discipline_id, department_guide_main_id FROM concspec_list_v WHERE department_id = 'psy' AND gen_ed = 0 ORDER BY guide_title")
        iRow = 0
          while not rsGuide.eof 
            'iRow = iRow + 1%>
            
                <%'Select case LCase(rsGuide("page_type")) 
           
                'case "bus"
						'sUrl = "bus_template.asp?parent_id=" & rsGuide("key_id")
				'case "ed"
						'sUrl = "ed_template.asp?parent_id=" & rsGuide("key_id")
				'case "psy"
						'sUrl = "psy_template.asp?parent_id=" & rsGuide("key_id")
				'case "gen_ed"
						'sUrl = "gen_ed_template.asp?parent_id=" & rsGuide("key_id")
                'end Select
                %>
            
            
            <a href="guide.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>"><%=rsGuide("guide_title")%> </a>&nbsp;<a style="font-size:10pt;color:red;" href="/research_help/course_guides/admin/edit_guide/default1.asp?department_guide_main_id=<%=rsGuide("department_guide_main_id")%>">edit title</a><br />

    
            
            <%rsGuide.MoveNext
            Wend
            rsGuide.Close
            Set rsGuide = nothing
            %>
    
    <%'
    'rsThis.MoveNext
    'Wend
    rsThis.Close
    Set rsThis = nothing
    %>
 
 

<br /> 
<br />     
</div>
</body>
</html>

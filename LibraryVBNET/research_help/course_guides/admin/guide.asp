<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<!-- #include virtual="/includes_shared/EnvPrefix.asp" -->
<!-- #include virtual="/includes/Header.asp"-->
<%
iKey = CInt(trim(Request.QueryString("department_guide_main_id")))


Set rsThisInd = dbElrc.Execute ("Select count(*) as the_count FROM course_guides_all WHERE department_discipline_id = 1" )

    if iMaxMenuItems = rsThisInd("the_count") then
    iMaxCols = 5    
    iMaxRows = Int( iMaxMenuItems / iMaxCols ) + 1
	    else 				
    iMaxMenuItems = rsThisInd("the_count") 
    iMaxCols = 6			
    iMaxRows = Int( iMaxMenuItems / iMaxCols ) + 2	

    end if

rsThisInd.Close
Set rsThisInd = Nothing
%>

<HTML>
<HEAD>
	<title>Subject Guide Edit</title>
	
	
	<style>
	
	</STYLE>

</HEAD>
<body style="margin:0 0 0 0;">

 
<div style="margin: 0 10 0 10;">


<%'response.Write(iMaxRows)%>

<p>Return to <a href="default_subject.asp">Admin section</a></p>

<%
Set rsThis = dbElrc.Execute("SELECT guide_title FROM concspec_list_v WHERE department_guide_main_id = " & iKey ) 
%>	
    
   <h2><%=rsThis("guide_title")%></h2>
        

    
<%
rsThis.Close
Set rsThis = nothing
'dbElrc.Close
'Set dbElrc = nothing
%>	

<%
Set rsThisSub = dbElrc.Execute("SELECT guide_header_info_id, head_title FROM guide_headers_info WHERE department_discipline_id = " & iKey & " ORDER BY display_order" ) %>


 <% 

while not rsThisSub.eof %>
 

    <a style="background-color:lightblue;" href="/research_help/course_guides/admin/edit_guide/default_head.asp?guide_header_info_id=<%=rsThisSub("guide_header_info_id")%>"><%=rsThisSub("head_title")%><br /></a>
    

        <%Set rsThisSub1 = dbElrc.Execute("SELECT guide_resource_id, resource_title FROM guide_resources WHERE guide_header_info_id = " & rsThisSub("guide_header_info_id") & " ORDER BY display_order" ) %> 
        <div style="text-indent:20px;"><a style="background-color:Yellow;" href="/research_help/course_guides/admin/addnew_guide/default1.asp?guide_header_info_id=<%=rsThisSub("guide_header_info_id")%>">Add a new resource</a></div><%'response.Write(rsThisSub("key_id"))%>
        
        <%while not rsThisSub1.eof %>
        <div style="text-indent:40px;"><a href="/research_help/course_guides/admin/edit_guide/default_res.asp?guide_resource_id=<%=rsThisSub1("guide_resource_id")%>"><%=rsThisSub1("resource_title")%></a><%'response.write(rsThisSub1("key_id"))%></div>



        <%rsThisSub1.MoveNext
        Wend
        rsThisSub1.Close
        Set rsThisSub1 = nothing%>
<% 
rsThisSub.MoveNext
Wend
rsThisSub.Close
Set rsThisSub = nothing



'dbElrc.Close
'Set dbElrc = nothing

%> 
<h3>Add Header Section</h3>
<a href="/research_help/course_guides/admin/addnew_guide/default.asp?department_guide_main_id=<%response.Write(iKey)%>">Add new header</a>
<!--
<h3>Individual Courses</h3>
<p><b><font color="red">**Individual courses must have a number beside link</font></b>. To get your number for a course or to create a course, go to 
the <a target="_blank" href="/library/research_help/course_guides/admin/">Course Guide Admin area</a>.

--> 

</p>
<br />


 
 

           
</div>
</body>

</HTML>
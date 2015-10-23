<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<% sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)%>


<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<title>Library Admin Site</title>
<style type="text/css">

a  { 
color: #445577;
}
</style>

</HEAD>
<BODY style="background-color: #eeeedd;">

<table border="1" style="background-color:white;">

	<tr> 
		<td> 



	<h2 style="color:darkred;">Various Admin Areas of the Library</h2> 

	
    Back to the <a href="/">Library</a>


		</td> 
	</tr>
	<tr> 
		<td>
<br/>
<a style="color:#445577;" href="mm/">Library Area</a><br/>
<a style="color:#445577;" href="/ncu_kb/kb_table.aspx">Librarian Workspace Area - KnowledgeBase</a><br/>
<a style="color:#445577;" href="dw/">DW Area</a><br/>
<a style="color:#445577;" href="wl/">WL Area</a><br/>
<a style="color:#445577;" href="/IL/admin/">IL Admin Area</a><br/>
<a style="color:#445577;" href="/article/default.aspx">Find an Article</a>
        </td>
    </tr>
    <tr>
        <td>


<br/>
<a style="color:#445577;" href="/db_admin/default.asp">DB Index Admin</a>

        </td>
    </tr>
    <tr>
        <td>   
<br/>
<a style="color:#445577;" href="/research_help/course_guides/admin/default_subject.asp">Subject Guide Admin Area</a><br/> <br/> 

<a style="color:#445577;" href="/research_help/course_guides/admin/default.aspx">Course Guide Admin Area</a>
        </td>
    </tr>
    
    <tr>
        <td>
    <br/>
<a style="color:#445577;" href="/tips_admin/tip_vwr.asp">Tips Area</a>

        </td>
    </tr>
    
    <tr>
        <td>
<br/>
    <a style="color:#445577;" href="/stats/default.aspx">Library Stats Area</a>
    
    

		</td>
    </tr>
    <tr>
    
        <td>
        <br/>
    <a style="color:#445577;" href="http://ncusqlwh001/Reports/Pages/Folder.aspx">SQL Reports</a>
        
        </td>
     </tr>
      <tr>   
		<td>
        <br/>
    <a style="color:#445577;" href="/request_forms/cmts_vwr.aspx">Leave Feedback Area</a>
        
        </td>
		
	</tr>
	
	    <tr>   
		<td>
        <br/>
    <a style="color:#445577;" href="/policy/ncu/admin/default.aspx">Library Policies Admin Area</a>
        
        </td>
		
	</tr>
	<tr> 
	
	   
	   <td>
	   <br /> 
	   <a style="color:#445577;" href="/schedule/admin/default.aspx">Library Schedule Admin Area</a></td> 
	
	</tr> 
		<tr> 
	
	   
	   <td>
	   <br /> 
	   <a style="color:#445577;" href="/pub_center_admin/default.asp">Mentor Pub Admin Area</a></td> 
	
	</tr> 
	
	<tr> 
	    
	    <td><br/> 
	    
	    <a style="color:#445577;" href="/chat_admin/log.aspx" >Library Chat Log</a> </td> 
	    
    </tr> 
    <tr>
        <td><a href="/letter/admin_res/default.aspx">Resource of the Month</a></td>
    </tr> 
    <tr> 
        <td><a href="/letter/admin/default.aspx">Monthly Letter by Director</a></td>
    </tr> 
</table>
</BODY>
</HTML>

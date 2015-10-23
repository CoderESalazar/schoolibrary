<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<% sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)%>


<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<title>Library Admin Site</title>
<style type="text/css">

a  { 
font-color: #445577;
}
</style>

</HEAD>
<BODY style="background-color: #eeeedd;">

<table border="1" style="background-color:white;">

	<tr> 
		<td> 



	<h2 style="color:darkred;">Various Admin Areas of the Library</h2> 

	
    Back to the <a href="/library/">Library</a>


		</td> 
	</tr>
	<tr> 
		<td>
<br/>
<a style="color:#445577;" href="dw/">DW Area</a><br/>
<a style="color:#445577;" href="mm/">Library Area</a><br/>
<a style="color:#445577;" href="wl/">WL Area</a><br/>
<a style="color:#445577;" href="qz/">QZ Area</a><br/>
<a style="color:#445577;" href="/library/article/admin/default.aspx">Find an Article</a>
        </td>
    </tr>
    <tr>
        <td>


<br/>
<a style="color:#445577;" href="/library/db_admin/">DB Index Admin</a>

        </td>
    </tr>
    <tr>
        <td>   
<br/>
<a style="color:#445577;" href="/library/research_help/course_guides/admin/default_subject.asp">Course Guide Admin Area</a>
        </td>
    </tr>
    
    <tr>
        <td>
    <br/>
<a style="color:#445577;" href="/library/tips_admin/tip_vwr.asp">Tips Area</a>

        </td>
    </tr>
    
    <tr>
        <td>
<br/>
    <a style="color:#445577;" href="/library/stats/admin/default.aspx">Library Stats Area</a>
    
    

		</td>
    </tr>
    <tr>
    
        <td>
        <br/>
    <a style="color:#445577;" href="http://ncuappdv001/Reports/Pages/Folder.aspx">SQL Reports</a>
        
        </td>
		
		
	</tr>
	
</table>
</BODY>
</HTML>

<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%' sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>



<% 
iKey = CInt(trim(replace(Request.QueryString("department_guide_main_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM concspec_list_v WHERE department_guide_main_id =  '" & iKey & "'") 

%>


<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<%'if sSite = "ncu" then%> 

<BODY>





<form action="default_action1.asp" method="POST" id="form1" name="form1">
    <input type="hidden" name="department_guide_main_id" value="<%=rsDW("department_guide_main_id")%>" />
	Edit specialization title: <input type="text" name="guide_title" size="40" value="<%=rsDW("guide_title")%>" /><br />
	
	<%
	
	 rsDW.Close
     Set rsDW = nothing
	
	 %>
	
    <br />
    
<%Set rsThis = dbElrc.Execute("SELECT display_id FROM department_guides_main WHERE department_guide_main_id = '" & iKey & "'") %>    

    Display:<input type="checkbox" name="display_id" value="True" <%if rsThis("display_id") = "True" then response.write( " checked ")  %> />
	<br /> 
	<br /> 
	<input type="submit" value="Update Spec >" name="action" />

</form>

 
<div align="right">
	<a href="default_action1.asp?action=Delete&department_guide_main_id=<%=iKey%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>


<%'
'
'Set rsThis = dbElrc.Execute("Select Count(*) as the_count FROM guide_headers_bus WHERE head_title = 'Find an Article'")

'sSQL = rsThis("the_count")
' %>
 
<%'=sSQL%>


</BODY>
</HTML>

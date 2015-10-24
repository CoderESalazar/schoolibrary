<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%' sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>



<% 
iKey = CInt(trim(replace(Request.QueryString("department_guide_main_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM department_guides_main WHERE department_guide_main_id =  '" & iKey & "'") 
%>

<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<%'if sSite = "ncu" then%> 

<BODY>

<h2>Add new header for <%=rsDW("guide_title")%></h2>



<form action="default_action.asp" method="POST" id="form1" name="form1">

	<input type="hidden" name="department_discipline_id" value="<%=iKey%>" /><br />
    Title of Header:     
     <select name="header_title">
         
     <% Set rsThis = dbElrc.Execute("SELECT * FROM master_header ORDER BY display_order")

        while not rsThis.eof  %>


            <option><%=rsThis("header_title")%></option>
    
    
     <%
     rsThis.MoveNext
     Wend  
     %> 
     
     </select>
     <br /> 
     Display Order: <input type="text" name="display_order" size="1" /><br />  
     <%
     rsThis.Close
     Set rsThis = nothing
     %>
    
    <br /> 
    
    <br /> 
    

   <br /> 
   <input type="submit" value="Add Header" name="action" />
</form>
<%rsDW.Close
 Set rsDW = nothing%>
    
<form action="default_action.asp" method="POST" id="form2" name="form2">
   <input type="hidden" name="department_discipline_id" value="<%=iKey%>" /><br />
  
   
    Other Header: <input type="text" name="header_title" size="35" /><br />  
    Display Order: <input type="text" name="display_order" size="1" /><br />  

<br />
    <br />  
    <input type="submit" value="Other Header" name="action" />


</form>


</BODY>
</HTML>
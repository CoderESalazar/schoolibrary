<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%' sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>



<% 
'Response.Write (Request.QueryString())

iKey = CInt(trim(replace(Request.QueryString("guide_header_info_id"),";","")))
Set rsThis = dbElrc.Execute("SELECT * FROM guide_headers_info WHERE guide_header_info_id =  '" & iKey & "'") 
%>

<HTML>
<HEAD>


<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0" />
</HEAD>
<%'if sSite = "ncu" then%> 

<BODY>

<h2>Add new resource for <%=rsThis("head_title")%></h2>

<form action="catcher_page1.asp" method="POST" id="form1" name="form1">
    
	<input type="hidden" name="guide_header_info_id" value="<%=replace(request.querystring("guide_header_info_id"),";","")%>" /><br />
	<input type="hidden" name="department_discipline_id" value="<%=rsThis("department_discipline_id")%>" /><br />
	Select Resource Title: 
	<select name="key_id">  
    <%
         Set rsThisSub = dbElrc.Execute("SELECT key_id, db_title FROM db_index WHERE display_id = 1 ORDER By db_title") 
                    
            while not rsThisSub.eof%>
                
                <option value="<%=rsThisSub("key_id")%>"><%=rsThisSub("db_title")%>&nbsp;<%=rsThisSub("key_id")%></option>
              
            <%rsThisSub.MoveNext
             Wend %> 
             
            
            
    </select>  
 
     <%
     rsThisSub.Close
     Set rsThisSub = nothing
     %> 
    <br /> 
    <br />  
  
    <input type="submit" value="Continue" name="action" />
    <br /> 

</form>

<form action="catcher_page2.asp" method="POST" id="form2" name="form2">
   <input type="hidden" name="guide_header_info_id" value="<%=replace(request.querystring("guide_header_info_id"),";","")%>" /><br />
   <input type="hidden" name="department_discipline_id" value="<%=rsThis("department_discipline_id")%>" /><br />
   
    Other Resource Title: <input type="text" name="resource_title" size="50" /><br />  

<br />
    <br />  
    <input type="submit" value="Continue" name="action" />

</form>



<%rsThis.Close
 Set rsThis = nothing%>
 
</BODY>
</HTML>
<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<% LetMeInApplicationKey = "Library" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<%
sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Select Quiz Header Page</title>
</head>

<%if sSite = "ncu" then %> 
<body style="background-color: lightyellow;">

<h2>Select a header</h2>
    <p>Please select the header where you want the guide or quiz to appear under.</p> 


<form action="/elrc/admin/qz/addnew/default.asp" method="get"> 

    
    
       <select name="guide_header_id">  
<%Set rsThis = dbElrc.Execute("SELECT guide_header_id, guide_header, display_order FROM guide_table_1")

    while not rsThis.eof
 %>    
    
       
         <option value="<%=rsThis("guide_header_id")%>"><%=rsThis("guide_header")%> &nbsp;<%=rsThis("guide_header_id")%></option> 
                 
   
    <%   
     rsThis.MoveNext
    Wend %> 
     </select> 
 
   <br /> 
   
   <br /> 
      
   <input type="submit" value="Continue >" />
   
   
   </form> 
   
    
</body>

    <%else%>

<body style="background-color: lightgrey;">

<h2>Select a header</h2>
    <p>Please select the header where you want the guide or quiz to appear under.</p> 


<form action="/elrc/admin/qz/addnew/default.asp" method="get"> 

    
    
       <select name="guide_header_id">  
<%Set rsThis = dbElrc.Execute("SELECT guide_header_id, guide_header, display_order FROM guide_table_1")

    while not rsThis.eof
 %>    
    
       
         <option value="<%=rsThis("guide_header_id")%>"><%=rsThis("guide_header")%> &nbsp;<%=rsThis("guide_header_id")%></option> 
                 
   
    <%   
     rsThis.MoveNext
    Wend %> 
     </select> 
 
   <br /> 
   
   <br /> 
      
   <input type="submit" value="Continue >" />
   
   
   </form> 
   
 <%end if %>   
</body>




</html>
   <%
    rsThis.close
    Set rsThis = Nothing
    dbElrc.Close
    Set dbElrc = nothing
    
    %>
   
   
   
   
   
   
   
   
   
   
   
   
   
   
   

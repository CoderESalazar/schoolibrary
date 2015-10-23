<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<% LetMeInApplicationKey = "Library" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->

<!--sort script-->
<%' sOrderKey = "title_id"
'if len(trim(Request.QueryString("order_by"))) > 0 then sOrderKey = trim(Request.QueryString("order_by"))
%>

<%
sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)%>
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
<link rel="stylesheet" type="text/css" href="/style.css">
<link rel="stylesheet" type="text/css" href="/style_list.css">
<style type="text/css">
th.scups { 
background-color:darkblue;
}
a { 
font-size: .9em;
}
</style>

</HEAD>
<%if sSite = "ncu" then %> 

<body style="background-color:lightyellow;">

<%'=Request.QueryString("IncomingMessage")%>

<h2>Add or Edit Quizzes</h2> 
<a href="../default.asp">Back to Admin Area</a><br /><br /> 

<a href="../qz/addnew/default_1.asp">Add a Header</a> 


<% Set rsThis = dbElrc.Execute("Select guide_header_id, guide_header FROM guide_table_1")

    while not rsThis.eof 
 %>
        <h3><a style="color: Maroon;"href="../qz/edit/default_1.asp?guide_header_id=<%=rsThis("guide_header_id")%>"><%=rsThis("guide_header")%></a></h3> 
        <a href="../qz/addnew/default.asp?guide_header_id=<%=rsThis("guide_header_id")%>">Add New Guide</a><br /><br /> 
            <%Set rsThisSub = dbElrc.Execute("Select title_id, title_guide, guide_header_id FROM guide_table WHERE guide_header_id = " & rsThis("guide_header_id") & " ORDER BY title_guide")
            
                while not rsThisSub.eof%>
                      
                <div style="text-indent:5px;"><a href="../qz/edit/default.asp?title_id=<%=rsThisSub("title_id")%>"><%=rsThisSub("title_guide")%></a></div> 
                
                
                <%rsThisSub.MoveNext
                Wend
                %> <br /> 
                
                <%
                
                rsThisSub.Close
                Set rsThisSub = Nothing
                %>
        
        
         <%rsThis.MoveNext
            Wend
            rsThis.Close
            Set rsThis = Nothing
        %>

</body>
<!--scups site begins here-->

<%else%> 

<body style="background-color:lightgrey;">

<%'=Request.QueryString("IncomingMessage")%>

<h2><font color="darkblue">Add or Edit Quizzes</font></h2> 
<a href="../default.asp">Back to Admin Area</a><br>

<% Set rsThis = dbElrc.Execute("Select guide_header_id, guide_header FROM guide_table_1")

    while not rsThis.eof 
 %>
        <h3><a style="color: Maroon;"href="../qz/edit/default_1.asp?guide_header_id=<%=rsThis("guide_header_id")%>"><%=rsThis("guide_header")%></a></h3> 
         <a href="../qz/addnew/default.asp?guide_header_id=<%=rsThis("guide_header_id")%>">Add New Guide</a><br /><br /> `
            <%Set rsThisSub = dbElrc.Execute("Select title_id, title_guide, guide_header_id FROM guide_table WHERE guide_header_id = " & rsThis("guide_header_id") & " ORDER BY title_guide")
            
                while not rsThisSub.eof%>
                      
                <div style="text-indent:5px;"><a href="../qz/edit/default.asp?title_id=<%=rsThisSub("title_id")%>"><%=rsThisSub("title_guide")%></a></div> 
                
                
                <%rsThisSub.MoveNext
                Wend
                %> <br /> 
                
                <%
                
                rsThisSub.Close
                Set rsThisSub = Nothing
                %>
        
        
         <%rsThis.MoveNext
            Wend
            rsThis.Close
            Set rsThis = Nothing
        %>
	

<%end if%>  
</body>
</HTML>

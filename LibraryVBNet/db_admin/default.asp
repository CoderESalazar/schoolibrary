<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<% LetMeInApplicationKey = "LibraryAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Database Admin Page</title>
<style type="text/css">
td { 
font-size: .9em;

} 
</style>    
    
    
</head>
<body>

<h2><font color="#702318">Database Index</font></h2>

 <a style="background-color:yellow;" href="/admin/default.aspx">Back to Main Library Admin Area</a><br/><br/>

<a href="/db_admin/add/default.asp">Add new database</a>

<br /><br />
<table width="75%" border="1">
    <th>keyId</th>
    <th>Database Title</th>
    <th>Coverage</th>
    <th>Full Text</th>
    <th>Scholarly/Peer Reviewed</th>
    <th>Identify</th>
    

<% 
Set rsThis = dbElrc.Execute( "SELECT * FROM db_index ORDER By db_title")
    
    
    while not rsThis.eof    %>
    
    <tr>
        <td><%=rsThis("key_id")%></td>
        <td><a href="/db_admin/edit/default.asp?key_id=<%=rsThis("key_id")%> "><%=rsThis("db_title")%></a></td>
        <td ><%=rsThis("cover_id")%>&nbsp;</td> 
        <td align="center"><%=rsThis("full_text")%>&nbsp;</td>
        <td align="center"><%=rsThis("scholary_id")%>&nbsp;</td>
        <td align="center"><%=rsThis("identify_id")%>&nbsp;</td>
    <%
    rsThis.MoveNext
    wend
    rsThis.Close
    Set rsThis = Nothing
     %>
      
     </tr>

</table>    
    
 

    
</body>
</html>

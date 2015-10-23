<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->

<html>
<head>
<title>Admin Site</title>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
<link rel="stylesheet" type="text/css" href="/style.css" />
<link rel="stylesheet" type="text/css" href="/style_list.css" />

</head>

<body style="background-color: lightyellow;">



<%=Request.QueryString("IncomingMessage")%>
<a name="top" id="top"></a>
<h3><font color="darkred">All NCU WL Pages</font></h3>
<b><a href="../default.aspx">Back to Admin Area</a></b><br>
<br> 
<a name="top" id="top"></a>

<% Set rsThis = dbElrc.Execute("SELECT * FROM elrc_wl_info order by title_wl")
		while not rsThis.eof%>
			
	<a href="#<%=rsThis("key_id")%>"><%=rsThis("title_wl")%></a>&nbsp
		 
		<%rsThis.MoveNext %> 
<% wend
Set rsThis = nothing %> 
<br> 
<br> 
<a href="../wl/addnew/default.asp">Add New Info Page</a><br>


	
	<% Set rsThis = dbElrc.Execute("SELECT * FROM elrc_wl_info order by title_wl")
		while not rsThis.eof%>	
		
		<div style="font: 700 1em verdana; background-color: white;">
		<a id="<%=rsThis("key_id")%>"></a>
		<a href="edit/edit_info.asp?key_id=<%=rsThis("key_id")%>"><%=rsThis("key_id")%> - <%=rsThis("title_wl")%> - <%=rsThis("desc_wl")%></a></div>
		
		<div style="white-space: nowrap;">		<!-- Add New Detail to this category -->
			<% for iL = 0 to 20 
				Response.Write("&nbsp;")
			next %>
			<a href="addnew/default1.asp?parent_id=<%=rsThis("key_id")%>" style="color: Forestgreen;">Add a new category</a></div>
					

		<%Set rsCat = dbELRC.Execute("SELECT * FROM elrc_wl_cat WHERE parent_id = " & rsThis("key_id") & " order by cat_id " ) 
		while not rsCat.eof %>
		
			<% for iL = 0 to 10 
				Response.Write("&nbsp;")
			next %>
		 
			<a href="edit/edit_cat.asp?key_id=<%=rsCat("key_id")%>"><%=rsCat("cat_id")%></a><br>


			<div style="white-space: nowrap;">		<!-- Add New Detail to this category -->
			<% for iL = 0 to 20 
				Response.Write("&nbsp;")
			next %>
			<a href="addnew/default2.asp?parent_id=<%=rsCat("key_id")%>" style="color: Forestgreen;">Add New Link</a></div>


			<%Set rsDetail = dbELRC.Execute("SELECT * FROM elrc_wl_detail WHERE parent_id = " & rsCat("key_id") & " order by title_id" )  
			while not rsDetail.eof %> 


				<div style="white-space: nowrap;">
				<% for iL = 0 to 20 
					Response.Write("&nbsp;")
				next %>
				<a href="edit/edit_detail.asp?key_id=<%=rsDetail("key_id")%>"><%=rsDetail("url_id")%> - <%=rsDetail("title_id")%></a></div>
					
				<% rsDetail.MoveNext
			wend %> 

			
	<%rsCat.MoveNext
	wend %> 
<p align="right"><a href="#top" id="top">Back to top</a></p> 	
<% rsThis.MoveNext 
wend %>
 
</body>
</html>

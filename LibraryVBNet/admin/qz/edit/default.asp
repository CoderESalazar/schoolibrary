<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->

<!-- #include virtual="/includes_corp/EnvPrefix.asp" -->

<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<%
iKey = CInt(trim(replace(Request.QueryString("title_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM guide_table WHERE title_id = " & iKey ) 
sTextDW = rsDW("notes_id") & ""


sSite = lcase( Request.ServerVariables("SERVER_NAME") )
sSite = split( sSite, "." )(1)%>




<HTML>
<HEAD>
	<title>QZ Pages</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">
	<style type="text/css"><!-- 
		TEXTAREA { display: block; overflow-x: hidden;overflow-y: visible; }
	-->
	</STYLE>

</HEAD>



<!-- jspelliframe - pre code -->
<script language="Javascript1.2"><!-- // load htmlarea
_editor_url = "/includes_shared/jspelliframe2k4/htmlarea/";                     // URL to htmlarea files
var win_ie_ver = parseFloat(navigator.appVersion.split("MSIE")[1]);
if (navigator.userAgent.indexOf('Mac')        >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Windows CE') >= 0) { win_ie_ver = 0; }
if (navigator.userAgent.indexOf('Opera')      >= 0) { win_ie_ver = 0; }
if (win_ie_ver >= 5.5) {
  document.write('<scr' + 'ipt src="' +_editor_url+ 'editor.js"');
  document.write(' language="Javascript1.2"></scr' + 'ipt>');  
} else { document.write('<scr'+'ipt>function editor_generate() { return false; }</scr'+'ipt>'); }
// -->
</script>
<script language="JavaScript" src="/includes_shared/jspelliframe2k4/jspelliframe.js"></script>

<%if sSite = "ncu" then %>
<body style="background-color:lightyellow;">

<h2>Edit Guides</h2> 

<form action="default_action.asp" method="POST" id=form1 name=form1>
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="title_id" value="<%=rsDW("title_id")%>">
		<tr valign="top">
			<td align="right">Title:</td>
			<td><input type="text" name="title_guide" size="60" value="<%=rsDW("title_guide")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">URL:</td>
			<td><input type="text" name="link_id" size="60" value="<%=rsDW("link_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Format:</td>
			<td><input type="text" name="format_id" size="20" value="<%=rsDW("format_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Length:</td>
			<td><input type="text" name="length_id" size="20" value="<%=rsDW("length_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Sound:</td>
			<td><input type="text" name="sound_id" size="2" value="<%=rsDW("sound_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Add Notes</td>
			<td><textarea name="notes_id" rows="5" cols="100"><%=Server.HTMLEncode( sTextDW )%></textarea></td>
		</tr>
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Guide" name="action"></td>
		</tr>
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=Delete&title_id=<%=rsDW("title_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>


<!-- automatically expand text areas based on input -->
<script type="text/javascript" src="/includes_shared/jsTextareaRowExpand.js"></script>
<script type="text/javascript">

function initAllRowTextAreas() {
 	var tas = document.getElementsByTagName("TEXTAREA");
 	var l = tas.length;
	for	(var i = 0; i < l; i++)
 		new AdjustableRowsTextArea(tas[i]);
}
 
if (window.addEventListener) {
 	window.addEventListener("load", initAllRowTextAreas, false);
}
 
</script>




<!-- jSpellIFrame Post Code -->
<script language="javascript1.2">
var objname='notes_id';

var config = new Object();    // create new config object

config.width = "100%";
config.height = "200px";
config.bodyStyle = 'background-color: white; font-family: "Verdana"; font-size: x-small;';
config.debug = 0;

editor_generate(objname,config);
</script>






</body>
<%else%>

<body style="background-color:lightgrey;">

<h2>Edit Guides</h2> 

<form action="default_action.asp" method="POST" id=form2 name=form1>
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="title_id" value="<%=rsDW("title_id")%>">
		<tr valign="top">
			<td align="right">Title:</td>
			<td><input type="text" name="title_guide" size="60" value="<%=rsDW("title_guide")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">URL:</td>
			<td><input type="text" name="link_id" size="60" value="<%=rsDW("link_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Format:</td>
			<td><input type="text" name="format_id" size="20" value="<%=rsDW("format_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Length:</td>
			<td><input type="text" name="length_id" size="20" value="<%=rsDW("length_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Sound:</td>
			<td><input type="text" name="sound_id" size="2" value="<%=rsDW("sound_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Add Notes</td>
			<td><textarea name="notes_id" rows="5" cols="100"><%=Server.HTMLEncode( sTextDW )%></textarea></td>
		</tr>
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Guide" name="action"></td>
		</tr>
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=Delete&title_id=<%=rsDW("title_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>


<!-- automatically expand text areas based on input -->
<script type="text/javascript" src="/includes_shared/jsTextareaRowExpand.js"></script>
<script type="text/javascript">

function initAllRowTextAreas() {
 	var tas = document.getElementsByTagName("TEXTAREA");
 	var l = tas.length;
	for	(var i = 0; i < l; i++)
 		new AdjustableRowsTextArea(tas[i]);
}
 
if (window.addEventListener) {
 	window.addEventListener("load", initAllRowTextAreas, false);
}
 
</script>




<!-- jSpellIFrame Post Code -->
<script language="javascript1.2">
var objname='notes_id';

var config = new Object();    // create new config object

config.width = "100%";
config.height = "200px";
config.bodyStyle = 'background-color: white; font-family: "Verdana"; font-size: x-small;';
config.debug = 0;

editor_generate(objname,config);
</script>


</HTML>

<%end if %>

<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>
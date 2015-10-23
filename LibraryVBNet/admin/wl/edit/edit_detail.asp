<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->


<%
iKey = CInt(trim(replace(Request.QueryString("key_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM elrc_wl_detail WHERE key_id = " & iKey ) 
sTextDW = rsDW("desc_id")

%> 


<HTML>
<HEAD>
	<title>Detail Pages</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">

<style><!-- 
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


<body topmargin="0" leftmargin="0">

<form action="default_action.asp" method="POST" id=form1 name=form1>
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="key_id" value="<%=rsDW("key_id")%>">
		<tr valign="top">
			<td align="right">Link Title:</td>
			<td><input type="text" name="title_id" size="40" value="<%=rsDW("title_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">URL ID: </td>
			<td><input type="text" name="url_id" size="60" value="<%=rsDW("url_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Parent ID:</td>
			<td><input type="text" name="parent_id" size="20" value="<%=rsDW("parent_id")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Description:</td>
			</td>
			<td><textarea name="desc_id" rows="5" cols="100"><% if not IsNull(sTextDW) then Response.Write( Server.HTMLEncode( sTextDW ) )%></textarea></td>
		</tr>
		<tr valign="top">
			<td align="right">Display Order:</td>
			<td><input type="text" name="display_order" size="20" value="<%=rsDW("display_order")%>"></td>
		</tr>
		<!--
		<tr valign="top">
			<td align="right">Protect From Public:</td>
			<td><input type="text" name="protect_from_public" size="20" value="<%=rsDW("protect_from_public")%>"></td>
		</tr>
		-->
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Detail" name="action"></td>
		</tr>
	
	</table>
</form>
<div align="right">
	<a href="default_action.asp?action=DeleteDetail&key_id=<%=rsDW("key_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
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
var objname='desc_id';

var config = new Object();    // create new config object

config.width = "100%";
config.height = "500px";
config.bodyStyle = 'background-color: white; font-family: "Verdana"; font-size: x-small;';
config.debug = 0;

editor_generate(objname,config);
</script>




</BODY>
</HTML>
<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>




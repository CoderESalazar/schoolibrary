<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/EnvPrefix.asp" -->

<%
iKey = CInt(trim(replace(Request.QueryString("guide_resource_id"),";","")))
Set rsDW = dbElrc.Execute("SELECT * FROM guide_resources WHERE guide_resource_id= " & iKey ) 
sTextDW = rsDW("desc_resource")

%> 


<HTML>
<HEAD>
	<title>Psychology</title>
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

<form action="default_action_res.asp" method="POST" id="form1" name="form1">
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="guide_resource_id" value="<%=rsDW("guide_resource_id")%>">
		<input type="hidden" name="guide_header_info_id" value="<%=rsDW("guide_header_info_id")%>">
		<tr valign="top">
			<td align="right">Link Title:</td>
			<td><input type="text" name="resource_title" size="40" value="<%=rsDW("resource_title")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">URL Resource: </td>
			<td><input type="text" name="url_resource" size="60" value="<%=rsDW("url_resource")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right">Description:</td>
			</td>
			<td><textarea name="desc_resource" rows="5" cols="100"><% if not IsNull(sTextDW) then Response.Write( Server.HTMLEncode( sTextDW ) )%></textarea></td>
		</tr>
		<tr valign="top">
			<td align="right">Display Order:</td>
			<td><input type="text" name="display_order" size="1" value="<%=rsDW("display_order")%>"></td>
		</tr>
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Update Link" name="action" /></td>
		</tr>
	
	</table>
</form>
<div align="right">
	<a href="default_action_res.asp?action=DeleteDetail&guide_resource_id=<%=rsDW("guide_resource_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
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
var objname='desc_resource';

var config = new Object();    // create new config object

config.width = "100%";
config.height = "200px";
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




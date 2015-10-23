<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->

<%
iKey = CInt(trim(Request.QueryString("key_id")))
Set rsDW = dbElrc.Execute("SELECT * FROM elrc_dw_info WHERE key_id = " & iKey ) 
sTextDW = rsDW("text_dw") & ""

%>

<html>
<head>
	<title>Admin Pages</title>
	<link rel="stylesheet" type="text/css" href="/style.css" />
	<link rel="stylesheet" type="text/css" href="/style_list.css" />
</head>

<!-- jspelliframe - pre code -->
<script type="text/javascript" language="Javascript1.2"><!-- // load htmlarea
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
<script type="text/javascript" language="JavaScript" src="/includes_shared/jspelliframe2k4/jspelliframe.js"></script>

<body style="background-color:lightyellow;">

    <form action="default_action.asp" method="post" id="form1" name="form1">
	     <input type="hidden" name="key_id" value="<%=rsDW("key_id")%>" /> 
	   
	    <table border="0" cellspacing="1" cellpadding="1">
	
		    <tr valign="top">
			    <td align="right">Title:</td>
			    <td><input type="text" name="title_dw" size="60" value="<%=rsDW("title_dw")%>" /></td>
		    </tr>
			    <tr valign="top">
			    <td align="right">Body:</td>
			    <td><textarea name="text_dw" rows="5" cols="100"><%=Server.HTMLEncode( sTextDW )%></textarea></td>
		    </tr>
		    <tr valign="top">
			    <td align="right"></td>
			    <td><input type="submit" value="Update DW" name="action" /></td>
		    </tr>
	    </table>
    </form>


<div align="right">
	<a href="default_action.asp?action=Delete&key_id=<%=rsDW("key_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
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
<script type="text/javascript" language="javascript1.2">
var objname='text_dw';

var config = new Object();    // create new config object

config.width = "100%";
config.height = "500px";
config.bodyStyle = 'background-color: white; font-family: "Verdana"; font-size: x-small;';
config.debug = 0;

editor_generate(objname,config);
</script>

</body>
</html>
<%
rsDW.Close
Set rsDW = nothing
dbElrc.Close
Set dbElrc = nothing
%>

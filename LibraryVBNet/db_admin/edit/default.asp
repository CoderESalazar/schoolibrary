<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->

<%
iKey = CInt(trim(Request.QueryString("key_id")))
Set rsThis = dbElrc.Execute("SELECT * FROM db_index WHERE key_id = " & iKey ) 


sDesc = rsThis("desc_resource") & ""

%> 


<HTML>
<HEAD>
	<title>Edit Database Page</title>
	<link rel="stylesheet" type="text/css" href="/style.css">
	<link rel="stylesheet" type="text/css" href="/style_list.css">


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



<body>
<h3>Edit Database Page</h3> 
<form action="default_action.asp" method="POST" id="form1" name="form1" />
	<table border="0" cellspacing="1" cellpadding="1">
		<input type="hidden" name="key_id" value="<%=rsThis("key_id")%>" />
		
		
		<tr valign="top">
			<td align="right">DB Title</td>
			<td><input type="text" name="db_title" size="60" value="<%=rsThis("db_title")%>" /></td>
		</tr>
		
	
		<tr valign="top">
			<td align="right">URL Info:</td>
			<td><input type="text" name="url_id" size="50" value="<%=trim(rsThis("url_id"))%>" /></td>
		</tr>
	
		<tr valign="top">
			<td align="right">Full Text:</td>
			<td><input type="text" name="full_text" size="1" value="<%=rsThis("full_text")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">Coverage:</td>
			<td><input type="text" name="cover_id" size="50" value="<%=rsThis("cover_id")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">Scholarly:</td>
			<td><input type="text" name="scholary_id" size="1" value="<%=rsThis("scholary_id")%>" /></td>
		</tr>
		<tr valign="top">
			<td align="right">Subscription or freebie:</td>
			<td><input type="text" name="identify_id" size="1" value="<%=rsThis("identify_id")%>" /></td>
		</tr>
	
		<tr align="top"> 
		    <td align="right">Description:</td> 
		    <td><textarea name="desc_resource" rows="5" cols="75"><%=Server.HTMLEncode( sDesc )%></textarea></td> 
		</tr> 
		<tr align="top"> 
		    <td align="right">Display:</td> 
	        <td><input type="checkbox" name="display_id" value="1" <%if rsThis("display_id") = True then response.write( " checked ")  %> /></td>
        </tr> 
	    <tr align="top"> 
		    <td align="right">Popular Database:</td> 
	        <td><input type="checkbox" name="pop_db" value="1" <%if rsThis("pop_db") = True then response.write( " checked ")  %> /></td>
        </tr> 

		<tr valign="top">
			<td align="right">&nbsp;</td>
			<td><input type="submit" value="Update" name="action" /></td>
		</tr>
	
	</table>
</form>





<div align="right">
	<a href="default_action.asp?action=DeleteDatabase&key_id=<%=rsThis("key_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
</div>

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
rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing
%>



<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/EnvPrefix.asp"-->
<!-- #include virtual="/includes/Header.asp"-->

<%
iKey = CInt(trim(replace(Request.QueryString("guide_id"),";","")))
Set rsNLMain = dbThisUniversity.Execute("Select ecr.course_code, ecr.guide_id, ecr.guide_body, ci.course_name, display_id from elrc_cr_guides ecr INNER JOIN course_info ci on ecr.course_code = ci.course_code where guide_id = " & iKey ) 

if rsNLMain.eof then

Response.Write("**Sorry, please check to see if a guide has been created in the Course Guide area.**")

else  
sCourseCode = rsNLMain("course_code") & ""
sTextDW = rsNLMain("guide_body") & ""
GuideTitle = rsNLMain("course_code") & " - " & rsNLMain("course_name") 

end if 


%> 



<HTML>
<HEAD>
	<title>Guide Edit</title>
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

<body style="margin: 0px 0px 0px 0px;" >

<% Call Header( "Guides", HEADER_BACK_JS, nothing ) %>

<form action="default_action.asp" method="post">
	<table border="0" cellspacing="1" cellpadding="1">
		
		<tr> 
		    <td><input type="hidden" name="guide_id" value="<%=rsNLMain("guide_id")%>" /></td>
		    
		</tr> 
 	
		<tr valign="top">
			<td align="right"><h3>Title:</h3></td>
			<td><input type="text" name="guide_title" size="50" value="<%=GuideTitle%>" /></td>
		</tr>
	    <tr> 
	        <td><h3>Course Code:</h3></td>
	        <td><input type="text" name="course_code" size="10" value="<%=sCourseCode%>" /></td>
	        
	    </tr> 
		<tr valign="top">
			<td align="right">Body:</td>
			<td><textarea name="guide_body" rows="8" cols="40"><%=Server.HTMLEncode( sTextDW )%></textarea></td>
		</tr>
		<tr> 
		    <td> Display:<input type="checkbox" name="display_id" value="True" <%if rsNLMain("display_id") = "True" then response.write( " checked ")  %> /></td> 
		    
        </tr> 
			
		<tr valign="top">
			<td align="right"></td>
			<td><input type="submit" value="Creator" name="action" /> &nbsp; <input type="submit" value="Update" name="action" /></td>
		</tr>
		
	</table>
</form>


<div align="right">
	<a href="default_action.asp?action=Delete&guide_id=<%=rsNLMain("guide_id")%>" onclick="return window.confirm('Are you sure you want to delete this guide?');"><img src="/images_shared/delete_red_x.gif" border="0" width="14" height="14" alt="Delete?"></a>
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
var objname='guide_body';

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
rsNLMain.Close
Set rsNLMain = nothing
dbThisUniversity.Close
Set dbThisUniversity = nothing
%>
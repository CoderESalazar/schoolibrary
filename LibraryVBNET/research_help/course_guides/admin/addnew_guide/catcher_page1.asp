<%@ Language=VBScript %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->

<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/EnvPrefix.asp" -->


<%

Select Case Request.Form("action")
Case "Continue"
	'Set rsThis = Server.CreateObject("ADODB.Recordset")
	'rsThis.Open "SELECT * FROM db_index WHERE key_id = " & Request.Form("key_id"), dbElrc, adOpenForwardOnly, adLockOptimistic
	'this is database description
	Set rsThis = dbElrc.Execute("SELECT * FROM db_index WHERE key_id = " & Request.Form("key_id"))  
	
	sTextDW = rsThis("desc_resource")
	'Response.Write(rsThis("desc_resource") & ", " & "Hello World!" & " , " & rsThis("db_title"))
	sHeaderID = Request.Form("guide_header_info_id")
	sKeyID = Request.Form("key_id")
	sDisciplineID = Request.Form("department_discipline_id")
	sTitle = rsThis("db_title")
	'sDesc = rsThis("desc_resource") & ""
	sUrl = rsThis("url_id")
	'sDisplay = rsThis("display_order")
		

       
end Select

%>

<html>
<head>
<title></title>

	<link rel="stylesheet" type="text/css" href="/style.css" />
	<link rel="stylesheet" type="text/css" href="/style_list.css" />    
<style type="text/css">
	    <!-- 
		TEXTAREA { display: block; overflow-x: hidden;overflow-y: visible; }
	-->
	</STYLE>

</head>



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

<form action="default_action_res.asp" method="POST" id="form1" name="form1">
    
	<input type="hidden" name="guide_header_info_id" value="<%=sHeaderID%>" /><br />
    <input type="hidden" name="key_id" value="<%=sKeyID%>" /><br />
    <input type="hidden" name="department_discipline_id" value="<%=sDisciplineID%>" /><br />
	<table>
	    <tr>
	        <td>Title: <input type="text" name="resource_title" value="<%=sTitle%>" size="40"/></td>
	      
	    
	    </tr>
	    <tr>
	        <td>Resource URL:  <input type="text" name="url_resource" value="<%=sUrl%>" size="80" /></td>
	       
	
        </tr>
        <tr>
            <td>Description of Resource:</td>
        </tr> 
        <tr>     
        <td> 
         <textarea name="desc_resource" rows="5" cols="100"><% if not IsNull(sTextDW) then Response.Write( Server.HTMLEncode( sTextDW ) )%></textarea></td>
        </tr>
	   <tr>     
	
	<!--<input type="text" name="desc_resource" value="<%=sDesc%>" size="100" /><br />

	<textarea name="desc_resource" rows="5" cols="100"><%=Server.HTMLEncode( sDesc )%></textarea><br /> 
		-->
            <td>Display Order: <input type="text" name="display_order" size="1"/></td>
		</tr>
	</table>
	<br /> 

	<input type="submit" value="Continue" name="action" />

</form>	
<br /> 

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

</body>
</html>

<%

rsThis.Close
Set rsThis = nothing
dbElrc.Close
Set dbElrc = nothing

 %>
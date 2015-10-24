 <%@ Page Language="VB" AutoEventWireup="false" CodeFile="RoadRunner.aspx.vb" Inherits="RoadRunner" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    
<link href="/Styles/main.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="tabbed.js">
</script>

<script type="text/javascript">
   //<![CDATA[
    function limittoFullText(myForm) {
        if (myForm.fulltext_checkbox.checked) myForm.clv0.value = "Y";
        else myForm.clv0.value = "N";
    }
    function limittoScholarly(myForm) {
        if (myForm.scholarly_checkbox.checked) myForm.clv1.value = "Y";
        else myForm.clv1.value = "N";
    }
    function ebscoPreProcess(myForm) {
        myForm.bquery.value = myForm.search_prefix.value + myForm.uquery.value;
    }
    //]]>
</script>
</head>
<body style="background-color: white;">
<br />
<table width="100%" border="0" align="center"> 
<tr> 
<td valign="middle"><img src="http://library.ncu.edu/Images/RoadRunner.jpg" alt="" align="middle"/></td> 
<td rowspan="2" valign="top">

<form action="http://search.ebscohost.com.proxy1.ncu.edu/login.aspx" method="get" target="_blank" onsubmit="ebscoPreProcess(this)">
        <h3><b><font color="#00467F">Roadrunner Search</font></b></h3>
        
	<input name="direct" value="true" type="hidden" />
        <input name="scope" value="site" type="hidden" />
	<input name="site" value="eds-live" type="hidden" />
        <!-- Authentication and Profile Values -->
	<input name="authtype" value="uid" type="hidden" />
	<input name="profile" value="eds" type="hidden" />
	<input name="user" value="northcentraluniv" type="hidden" />
        <input name="password" value="ebsco" type="hidden" />
	<!-- Limiter: Full Text -->
        <input name="cli0" value="FT" type="hidden" />
        <input name="clv0" value="N" type="hidden" />
        <!-- Limiter: Scholarly/Peer-Reviewed -->
        <input name="cli1" value="RV" type="hidden" />
        <input name="clv1" value="N" type="hidden" />
	<!-- search box and submit button -->
        <input name="bquery" value="" type="hidden" />
	<input name="uquery" size="35" type="text" />
	<select onchange="#" size="1" name="search_prefix" style="width: 100px">
        	<option selected="selected" value="">Keyword</option>
        	<option value="TI ">Title</option>
        	<option value="AU ">Author</option>
        </select>

	<br /><br />
        <!-- Limiter: Full text check box set the above value to Y -->
        <input name="fulltext_checkbox" id="fulltext_checkbox_all" onclick="limittoFullText(this.form)" type="checkbox" /> <label for="fulltext_checkbox_all">Full Text</label>
        <!-- Limiter: Scholarly/Peer-Reviewed check box set the above value to Y -->
	&nbsp;&nbsp;&nbsp;&nbsp;
        <input name="scholarly_checkbox" id="scholarly_checkbox_articles" onclick="limittoScholarly(this.form)" type="checkbox" /> <label for="scholarly_checkbox_articles">Scholarly/Peer Reviewed Journals</label>
<br /><br />

  <a id="advancedSearch" class="linksRR" href="http://search.ebscohost.com.proxy1.ncu.edu/login.aspx?direct=true&type=1&authtype=uid&user=northcentraluniv&password=ebsco&profid=eds" target="_blank"><strong>Advanced Search</strong></a>
  
  &nbsp;&nbsp;&nbsp;<a class="linksRR" runat="server" target="_top" href="/ncu_kb/kb_view.aspx?q_id=1938"><strong>FAQs</strong></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input value=" GO! " type="submit" />
        
</form>
</td>
</tr> 
</table>
</body>
</html>

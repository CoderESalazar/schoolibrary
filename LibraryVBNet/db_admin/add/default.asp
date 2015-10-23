<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<BODY>

<h1>Add a new database</h1>

<form action="default_action.asp" method="POST" id="form1" name="form1">
	Database Title: <input type="text" name="db_title" size="40" /><br />
	URL: <input type="text" name="url_id" size="60" /><br />
	Coverage (example: 2002 - current, if n/a, then varies or n/a): <input type="text" name="cover_id" size="30" /><br />
	Full Text (Y for yes, if No then leave blank): <input type="text" name="full_text" size="1" /><br />
	Scholarly/Peer Reviewed (Y for yes, if No then leave blank): <input type="text" name="scholary_id" size="1" /><br />
	Subscription or Free Resource (type n for subscription, leave blank for free): <input type="text" name="identify_id" size="1" /><br />
	<br /> 
	Resource Description: 
	<br/>

	<textarea name="desc_resource" rows="5" cols="75"></textarea>
	<br /><br /> 
	<input type="submit" value="Add >" id="submit1" name="submit1" />
</form>

</BODY>
</HTML>


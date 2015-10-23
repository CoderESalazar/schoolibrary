<%@ Language=VBScript %>
<% LetMeInApplicationKey = "LibraryAdmin" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->



<html>
<head>
<meta name="GENERATOR" content="Microsoft Visual Studio 6.0" />
    <script language="JavaScript" type="text/javascript">
    function validateForm ()
    {
	    valid = true; 
      
      if (document.form1.type_page.selectedIndex==0)
      {
        alert("Please select from the 'Page Type' box.");
        form1.type_page.focus();
        return false;    
      }
	    return true;
    }


    </script>
</head>
<body style="background-color: lightyellow;">

<h1>Add New NCU Library Page</h1>
    <form onsubmit="return validateForm();" action="default_action.asp" method="post" id="form1" name="form1">
	    Title of page: <input type="text" name="title_name" size="20" /><br />
	    Page Description: <input type="text" name="desc_text" size="80" /><br /> 
	    Page Type:   
	        <select name="type_page"> 
	        <option>--Select--</option>
	        <option>sw</option> 
	        <option>mm</option> 
	        <option>dw</option> 
	        <option>wl</option> 
	        <option>fa</option>
	        </select>
	    <br /> 
	    Enter Link Data URL or KeyID number: <input type="text" name="link_data" size="20" /><br />
	    Type in parent id :  <input type="text" name="parent_id" size="2" /><br />
	    <br /> 
	    <br /> 
	    <input type="submit" value="Continue >" id="submit1" name="submit1" />
    </form>
   
</body>
</html>

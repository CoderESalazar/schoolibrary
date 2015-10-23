<%@ Language=VBScript %>
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/includes/header.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/library/elrc_routines.asp" -->

<%
sCommonColumns = "address_street,address_city,address_state,address_postal_code,phone_1,first_name,middle_name,last_name"
Set rsThis = dbThisUniversity.Execute("SELECT email_address," & sCommonColumns & " from staff_info WHERE staff_id = '" & CurrentLetmeinUserID() & "'")
if rsThis.eof then
	Set rsThis = dbThisUniversity.Execute("SELECT first_name,last_name,phone_1,email_address_public," & sCommonColumns & " from mentor_info WHERE mentor_id = '" & CurrentLetmeinUserID() & "'")
	if rsThis.eof then
		Set rsThis = dbThisUniversity.Execute("Select learner_info.learner_id, first_name, last_name, email_address_1, degree_program_code," & sCommonColumns & " from learner_info INNER JOIN learner_programs ON learner_info.learner_id = learner_programs.learner_id WHERE learner_info.learner_id = '" & CurrentLetmeinUserID() & "' AND degree_program_code <> 'PROFDEV'" )
		if rsThis.eof then
			Response.Write("ERROR!!!")
		else
			sPersonType = "L"
			sFirstName = rsThis("first_name")
			sLastName = rsThis("last_name")
			sPhoneNum = rsThis("phone_1")
			sEmailAddress = rsThis("email_address_1")
			sAddressStreet = rsThis("address_street")
			sAddressCity = rsThis("address_city")
			sAddressState = rsThis("address_state")
			sAddressPostalCode = rsThis("address_postal_code")
			sDegProg = rsThis("degree_program_code")
		end if
	else
		sPersonType = "M"
		sFirstName = rsThis("first_name")
		sLastName = rsThis("last_name")
		sPhoneNum = rsThis("phone_1")
		sEmailAddress = rsThis("email_address_public")
		sAddressStreet = rsThis("address_street")
		sAddressCity = rsThis("address_city")
		sAddressState = rsThis("address_state")
		sAddressPostalCode = rsThis("address_postal_code")
	end if

else
	sPersonType = "S"
	sFirstName = rsThis("first_name")
	sMiddleName = rsThis("middle_name")
	sLastName = rsThis("last_name")
	sPhoneNum = rsThis("phone_1")
	sEmailAddress = rsThis("email_address")
	sAddressStreet = rsThis("address_street")
	sAddressCity = rsThis("address_city")
	sAddressState = rsThis("address_state")
	sAddressPostalCode = rsThis("address_postal_code")
end if
%> 

<html>

<head>

<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta name="GENERATOR" content="Microsoft FrontPage 4.0">
<meta name="ProgId" content="FrontPage.Editor.Document">
<title>Ask a Librarian Form</title>
<link rel="stylesheet" type="text/css" href="/library/style_elrc_ncu.css">

<style type="text/css">
a { 
color:#702308;
 }
h2 { 
color: #702308;
}
h3 { 
color: #702308;
}
</style>


</head>
<!--#include virtual= "/library/includes/NewHeader.asp"-->
<body style="margin: 0px 0px 20px; font-family:Verdana;font-size: .9em;">

<div id="ELRCHeader" style="position:relative; bottom: .20em;">
<%' Call ELRCHeader( dbElrc, iParentId ) %>
</div>

<br / > 

<div style="margin: 0px 10px 20px 10px;">
<%Response.Write "Hi " & sFirstName & ". "%> Please fill out the form below.

<br /><br /> 
<!--
<h3 style="color:#702308;">Personal Information Area</h3> 
Name: <%=sFirstName%>&nbsp;<%=sMiddleName%>&nbsp;<%=sLastName%><br> 
Phone Number: <%=sPhoneNum%><br> 
Email: <%=sEmailAddress%><br> 
Address: <%=sAddressStreet%> <br> 
<%=sAddressCity%>, <%=sAddressState%>&nbsp;<%=sAddressPostalCode%> 

--> 

<form method="post" name="E-reference" action="eref_action.asp">

       Category of Question:
<select name="cat_drop"> 

 <option>Please Select</option>
<%Set rsSelect = dbElrc.Execute("Select cat_id, cat_name from quest_cat order by cat_name")
    
    while not rsSelect.eof %>
     
  <option value="<%=rsSelect("cat_id")%>"> <%=rsSelect("cat_name")%>  </option>
        
 <%rsSelect.MoveNext
  wend
  rsSelect.Close
  Set rsSelect = Nothing 
  %>
      
   
</select>       

<input type="hidden" name="user_id" value="<%=CurrentLetmeinUserId()%>" />
<input type="hidden" name="first_name" value="<%=sFirstName%>" />
<input type="hidden" name="middle_name" value="<%=sMiddleName%>" />
<input type="hidden" name="last_name" value="<%=sLastName%>" />
<input type="hidden" name="phone_number" value="<%=sPhoneNum%>" />
<input type="hidden" name="email_address" value="<%=sEmailAddress%>" /> 
<input type="hidden" name="address_street" value="<%=sAddressStreet%>" />
<input type="hidden" name="address_city" value="<%=sAddressCity%>" />
<input type="hidden" name="address_state" value="<%=sAddressState%>" />
<input type="hidden" name="zip_code" value="<%=sPostalCode%>" />
<input type="hidden" name="deg_prog" value="<%=sDegProg%>" />

<br />
<br /> 

<div style="color:darkred;font-weight:700;">*If your question is for a course assignment, please provide course and assignment number.</div> 
<!--

1. Does your question concern a course assignment? <br>

<div style="text-indent:10px"><input type="radio" name="course_assign" value="yes">Yes<br>  
<div style="text-indent:10px"><input type="radio" name="course_assign" value="no">No. If no, skip to question #4.<br>

<br>  
--> 
<br /> 
Course Number: <input type="text" name="course_num" size="10"> <br /> 


Assignment Number: <input type="text" name="assign_num" size="10">
<!--
 Briefly describe the assignment and provide the assignment number if possible.

<div style="margin-left:20px;"><textarea name="assign_desc" rows=5 cols=40></textarea></div>
-->  
<br />

  
<br />
Question:

<br /> 

<div style="margin-left:20px;"><textarea name="user_question" rows="10" cols="75"></textarea></div>

<br /> 


<div style="margin-left:185px;"><input type="submit" value="Submit Question" name="B1" /></div> 


</div>
</form>

<!--#include virtual= "/library/includes/newFooter.asp"-->
</body>
</html>

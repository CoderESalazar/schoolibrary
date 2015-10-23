<%@ Language=VBScript %>
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/letmeinlite/validation_check.asp"-->

<%
sCommonColumns = "address_street,address_city,address_state,address_postal_code,phone_1,first_name,middle_name,last_name"
Set rsThis = dbThisUniversity.Execute("SELECT email_address," & sCommonColumns & " from staff_info WHERE staff_id = '" & CurrentLetmeinUserID() & "'")
if rsThis.eof then
	Set rsThis = dbThisUniversity.Execute("SELECT first_name,last_name,phone_1,email_address_public," & sCommonColumns & " from mentor_info WHERE mentor_id = '" & CurrentLetmeinUserID() & "'")
	if rsThis.eof then
		Set rsThis = dbThisUniversity.Execute("Select learner_info.learner_id, first_name, last_name, email_address_1, degree_program_code, " & sCommonColumns & " from learner_info INNER JOIN learner_programs ON learner_info.learner_id = learner_programs.learner_id WHERE learner_info.learner_id = '" & CurrentLetmeinUserID() & "' AND degree_program_code <> 'PROFDEV'" )
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
<meta NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</head>
<body bgcolor="white"> 
<h2 style="color:#702318;">Feedback Form</h2>

<p>Hello <%=sFirstName%>&nbsp;<%=sLastName%>, let us know how we are doing by entering comments into the box below. If you have a reference question
or are experiencing difficulties accessing the site or database, please complete the <a href="/ncu_kb/user/user_page.aspx">Ask a Librarian</a> form.
</p> 

<form action="fdbk_rspns.asp" method="post" name="frmadd">  
	
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

<strong>Comments:</strong> <font color="red"><strong>(Required)</strong></font><br /> 
	<textarea name="notes_comments" rows="15" cols="60"></textarea><br /> 
<br/>
	
<input type="submit" name="action" value="Submit" /> 
</form> 
 


</body>
</html>

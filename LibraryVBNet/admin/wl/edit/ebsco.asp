<%@ Language=VBScript %>

<% LetMeInApplicationKey = "UnivPeople" %>

<!-- #include virtual="/letmeinlite/validation_check.asp"-->

<!-- #include virtual="/includes_shared/ezproxy_md5_ticket.asp" -->

<!-- #include virtual="/includes_shared/dbThisC.asp" -->

<% Set dbThis = dbThisC("","","","","") %>

 


<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
 

<% 

Response.Write Request.servervariables("query_string") & "<br>"

 

'sNewUrl = "http://web.ebscohost.com.proxy1.ncu.edu/ehost/search?" & Request.servervariables("query_string")

sNewUrl = mid(Request.servervariables("query_string"), 5)

'sNewUrl = "http://web.ebscohost.com/ehost/search?" & Request.servervariables("query_string")


Response.Write "Url to Redirect: " & sNewUrl & "<br>"

 

 

sUserName = WhoIsIt(CurrentLetmeinUserID())

Set rsProxyPrefs = dbThis.Execute( "SELECT TOP 1 * from compass_preferences" )

EZproxyURLInit Trim(rsProxyPrefs("proxy_url")), Trim(rsProxyPrefs("proxy_password")), sUserName, Trim(rsProxyPrefs("proxy_groups"))

 

sNewUrl = EZproxyURL( sNewUrl )

 

'Response.Write ("<p><a href=""" & sNewUrl & """>" & sNewUrl & "</a></p>")                 ''' debug code

 Response.Redirect sNewUrl   

'Response.Redirect sNewUrl                ''' real code

%>
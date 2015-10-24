<%@ Language=VBScript %>
<% LetMeInApplicationKey = "UnivPeople" %>

<!-- #include virtual="/letmeinlite/SecurityRoutines.asp" -->
<!-- #include virtual="/letmeinlite/CurrentLetmeinUserID.asp"-->
<!-- #include virtual="/letmeinlite/WhoIsIt.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<!-- #include virtual="/includes/Header.asp" -->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/includes_shared/ezproxy_md5_ticket.asp" -->

<% 
iParentId = 0
if len(trim(Request.QueryString("department_guide_main_id"))) > 0 then
    iParentId = CInt(trim(Request.QueryString("department_guide_main_id"))) 
    SET rsThis = dbElrc.Execute("SELECT guide_title FROM concspec_list_v WHERE department_guide_main_id = " & iParentId )
    
    sTitlePage = rsThis("guide_title")

    rsThis.Close
    Set rsThis = nothing

else 


end if 
%>

<html lang="eng">
<head>
	<link rel="stylesheet" href="/style_elrc_ncu.css" />
<style type="text/css">
a.link { 
font-size: .95em;
color: #445577;
font-family: verdana;
font-weight:700;
}
a:hover { 
text-decoration: none;
color:black;
}
#text { 
font-size: .9em;
font-family: verdana;
}
h1, h2, h3 {
color: #702318;
font-family: verdana;
}
#tdimageHeader {
background-image: url(/images/elrc_logos/header_gradient.gif);
background-repeat: no-repeat;
}
#tdQuickLinks {
font-size: .9em;
color:#445577;
font-family:verdana;
}
#tdimage {
background-image: url(/images/elrc_logos/fadeWide1.jpg);
background-repeat: no-repeat;
}
#tdImageHeader1 {
background:url(/images/elrc_logos/header_gradient2.gif);
background-repeat: no-repeat;
text-indent:5px;
}
.borderTable { 
padding: 2px 4px 2px 4px;
border: 1px solid #702318;
}
</style>
</head>
<body style="margin: 0 0 0 0; ">
<!--#include virtual= "/lib_includes/dept_header.asp"-->

<!--#include virtual= "/lib_includes/course_guides_dept.asp"-->
<br/>
<!--Business resources--> 


<table cellpadding="5px" cellspacing="5px">
    <tr>

        <td valign="top">
  <%
  Set rsThis = dbElrc.Execute("SELECT guide_header_info_id, head_title, department_discipline_id, display_order FROM guide_headers_info WHERE department_discipline_id = " & iParentId & " ORDER BY display_order")
  
    while not rsThis.eof %>
    
        <h2><%=rsThis("head_title")%></h2>
        
  
        <%Set rsThisSub = dbElrc.Execute("SELECT guide_resource_id, guide_header_info_id, resource_title, url_resource, desc_resource, display_order FROM guide_resources WHERE guide_header_info_id = " & rsThis("guide_header_info_id") & "ORDER BY display_order" )
  
            while not rsThisSub.eof 
            
            sUrl = Replacer(rsThisSub("url_resource"))
            
            sDesc = rsThisSub("desc_resource")
            
            %> 
                        
           <div id = "text">  
           <a class="link" target="_blank" href="<%=sUrl%>"><%=rsThisSub("resource_title")%></a> 
          
           <%if len( trim( sDesc ) ) > 0 then
           
           Response.Write(" - ")%>
          
           <%=sDesc%> 
           
           <%end if%>
           <br /><br /> </div> 
           
        <%rsThisSub.MoveNext
        Wend
        rsThisSub.Close
        Set rsThisSub = nothing
        %> 
            
    <%rsThis.MoveNext
    Wend
    rsThis.Close
    Set rsThis = nothing
    %>        
     
        </td>
        
    </tr> 
</table>               

    

<br /> 

<!--#include virtual= "/lib_includes/newFooter.asp"--> 


</body>

<%
Function Replacer( sText )


	bInitEZ = False

	sRText = ""
	iCP = 1		' current pointer
	iEP = 1		' cu
	iReplaceCount = 0

	while iCP < len( sText )
		iBP = InStr( iCP, sText, "{{EZ:" )
		if iBP = 0 then		' no more {{ found, wrap it up
			sRText = sRText & Mid( sText, iCP )		' the rest of the string
			iCP = len( sText )
		else	' found a {{EZ:

			if bInitEZ = False then
				bInitEZ = True
				' --- BCB 
				Set rsProxyPrefs = dbThisUniversity.Execute( "SELECT TOP 1 * from compass_preferences" )
				sUserName = WhoIsIt(CurrentLetmeinUserID())
				EZproxyURLInit Trim(rsProxyPrefs("proxy_url")), Trim(rsProxyPrefs("proxy_password")), sUserName, Trim(rsProxyPrefs("proxy_groups"))
			end if

			iCP = iBP
			sRText = sRText & Mid( sText, iEP, (iCP-iEP))

			iEP = InStr( iBP, sText, "}}" )
			if iEP = 0 then		' weird, no }}, assume the rest of the string
				sRText = sRText & Mid( sText, iCP )		' the rest of the string
				iCP = len( sText )
			else		' found }}
				iReplaceCount = iReplaceCount + 1
				sKeyword = Mid( sText, (iBP+5), iEP - (iBP+5) )

				sNewUrl = EZproxyURL( sKeyword )
				sRText = sRText & sNewUrl

				iEP = iEP + 2
				iCP = iEP			' carry on
			end if
		end if
	wend
	Replacer = sRText

End Function

%>

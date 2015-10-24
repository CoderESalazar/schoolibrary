<%@ Language=VBScript %>
<% LetMeInApplicationKey = "UnivPeople" %>
<!-- #include virtual="/letmeinlite/validation_check.asp"-->
<!-- #include virtual="/letmeinlite/CurrentLetmeinUserID.asp"-->
<!-- #include virtual="/letmeinlite/WhoIsIt.asp"-->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/CommonRoutines.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp"-->
<!-- #include virtual="/includes/Header.asp"-->
<!-- #include virtual="/includes_shared/dbThisUniversity.asp" -->
<!-- #include virtual="/includes_shared/ezproxy_md5_ticket.asp" -->
<!-- #include virtual="/library/research_help/course_guides/breadcrumb.asp" -->



<%
iGuideId = 0
if len(trim(Request.QueryString("guide_id"))) > 0 then iGuideId = CInt(trim(Request.QueryString("guide_id")))


    if iGuideId > 0 then 

        Set rsThis = dbThisUniversity.Execute("SELECT guide_id, guide_title, guide_body, update_datetime FROM elrc_cr_guides WHERE guide_id = " & Request.QueryString("guide_id") )
        sTitlePage = rsThis("guide_title")
        sBody = rsThis("guide_body")
        dUpdateDatetime = rsThis("update_datetime")

        rsThis.Close
        Set rsThis = Nothing

        deptId = request.QueryString("department_guide_main_id")

    else



end if

%>



<html>

<head>
	<title><%=sTitle%></title>
<link rel="stylesheet" href="/library/style_elrc_ncu.css" />
<style type="text/css">
    h1, h2, h3 {
    color: #702318;
    font-family: verdana;
    }
    a {
    color:#445577;
    font-size: .9em;
    font-family: verdana;
    } 
    a:hover { 
    text-decoration: none;
    color:black;
    }
    crg_ncu { 
    font-family: verdana;
    font-size: .95em;
    }
    #tdimageHeader {
    background-image: url(/library/images/elrc_logos/header_gradient.gif);
    background-repeat: no-repeat;
    }
    #tdQuickLinks {
    font-size: .9em;
    color:#445577;
    font-family:verdana;
    }
    #tdimage {
    background-image: url(/library/images/elrc_logos/fadeWide1.jpg);
    background-repeat: no-repeat;
    }
    #tdImageHeader1 {
    background:url(/library/images/elrc_logos/header_gradient2.gif);
    background-repeat: no-repeat;
    text-indent:5px;
    }
    .borderTable { 
    padding: 2px 4px 2px 4px;
    border: 1px solid #702318;
    }
    #crgBread {
    font-size:.9em;
    color:black;
    }
    #crgBread a{
    font-size:.9em;
    color:black;
    }
</style>
	
	
</head>

<body id="crg_body" style="margin: 0 0 0 0; font-family:Verdana;" >

<!--#include virtual= "/library/includes/dept_header.asp"-->

<!-- #includes virtual="/library/includes/course_guides_dept.asp"-->

<table width="100%" cellspacing="0" cellpadding="10">
 <tr>
    <td valign="top" width="10" bgcolor="#FFFFFF"></td>
        <td valign="top" width="100%" id="td_body">
		
		
				
				<!--a href="/elrc/default.asp"><img src="/elrc/images/elrc_logos/logo_2.gif" border="0" alt="ELRC Logo"></a><h1 align="center" style="color:darkgreen"><%=sTitle%></h1>-->
				
				<% 
				sInText = Replacer(sBody)
				
				 %>
				
				
				<div id="crg_ncu"><%=sInText%></div>
	
			
               
        </td> 
    </tr> 
  </table>
  <br />

  <br />    
  
  
   
  <table width="100%" border="0">
    <tr> 	
            <td><div style="text-align:right;"><strong>Last Update:</strong> <%=dUpdateDatetime%></div></td>
    </tr>
  </table>		        
        
 <!--#include virtual= "/library/includes/newFooter.asp"-->              

<div style="margin: 0px 10px 0px 10px;"> 
                  <p style="font-family:Verdana; font-size:11px;">Copyright:
                  Consider all Internet sites copyrighted. When using material from sources,
                  be sure to properly cite in
                  APA format and use quotation marks around direct quotes.</p>
                
                </font>
                
                
                  <p><font face="Verdana"><font size="1">Disclaimer:</font>
                  <font face="Arial" size="1">
                Although the NCU Library provides links on the Course Guides, it is not responsible for the content appearing on those websites.</font></p>
                
                 
</div>

</body>
</html>



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






<%@ Language=VBScript %>
<!-- #include virtual="/includes_shared/dbThisUniversity.asp"-->
<!-- #include virtual="/includes_shared/dbElrc.asp" -->
<!-- #include virtual="/adovbs.inc" -->
<!-- #include virtual="/includes_shared/ADOFields.asp" -->
<%' sSite = lcase( Request.ServerVariables("SERVER_NAME") )
'sSite = split( sSite, "." )(1)%>

<%' 
iKey = CInt(trim(replace(Request.QueryString("department_discipline_id"),";","")))
 %>

<HTML>
<HEAD>
<META NAME="GENERATOR" Content="Microsoft Visual Studio 6.0">
</HEAD>
<%'if sSite = "ncu" then%> 
    
<body>



<%

Select Case replace(Request.QueryString("department_discipline_id"),";","")
Case 1

Set rsThis = dbElrc.Execute ("SELECT d.department_discipline_id, d.discipline_title, a.section_name " &_
	"FROM ncu.dbo.dpro_concspec_current_v a " &_
		"INNER JOIN ncuelrc.dbo.department_disciplines d " &_
			"ON a.department_id = d.department_id " &_
				"LEFT OUTER JOIN ncuelrc.dbo.department_guides_main b " &_
					"ON a.section_name  = b.guide_title " &_
						"AND d.department_discipline_id = b.department_discipline_id " &_
							"WHERE b.department_guide_main_id IS NULL AND d.department_discipline_id = 1 " &_
								"GROUP BY  d.department_discipline_id, d.discipline_title, a.section_name " ) %> 



 <h2>Add new specialization for Business</h2>                       
<form action="default_action3.asp" method="POST">
    <input type="hidden" name="department_discipline_id" value="<%=iKey%>" /><br />
    <!--ask renee about this value, not sure why we need it????--> 
    
    <input type="hidden" name="gen_ed" value="0" /><br />  
    
       
       
       <select name="guide_title">   
        
        <%if not rsThis.eof then 
                do while not rsThis.eof
        %>
        
                                               
          <!--need to ask renee about how to eliminate dupes-->  
            <option><%=rsThis("section_name")%></option>  

                <%rsThis.MoveNext
                loop%> 
                
        <%else
                
        response.Write("No Matches")
                
        end if 
                
        %>
         
    </select>
    <br /> 

    <br />  
  
    <input type="submit" value="Continue" name="action" />

</form>         
     
    <%  
    rsThis.Close
    Set rsThis = Nothing
    %>   
 
<%Case 2

Set rsThis = dbElrc.Execute ("SELECT d.department_discipline_id, d.discipline_title, a.section_name " &_
	"FROM ncu.dbo.dpro_concspec_current_v a " &_
		"INNER JOIN ncuelrc.dbo.department_disciplines d " &_
			"ON a.department_id = d.department_id " &_
				"LEFT OUTER JOIN ncuelrc.dbo.department_guides_main b " &_
					"ON a.section_name  = b.guide_title " &_
						"AND d.department_discipline_id = b.department_discipline_id " &_
							"WHERE b.department_guide_main_id IS NULL AND d.department_discipline_id = 2 " &_
								"GROUP BY  d.department_discipline_id, d.discipline_title, a.section_name " )%> 

<h2>Add new specialization for Education</h2>                               
<form action="default_action3.asp" method="POST">
    <input type="hidden" name="department_discipline_id" value="<%=iKey%>" /><br />                       
    <input type="hidden" name="gen_ed" value="0" /><br />
    
    <select name="guide_title">  
    
     <%if not rsThis.eof then 
            do while not rsThis.eof%> 
                   
           
             <option><%=rsThis("section_name")%></option>  

              <%rsThis.MoveNext
                loop%> 

        <%else
                
        response.Write("No Matches")
                
        end if 
                
                
        rsThis.Close
        Set rsThis = Nothing
    
         %>
 
      </select>

    <br /> 
    <br />  
  
    <input type="submit" value="Continue" name="action" />

</form>   

       
 
<%Case 3



Set rsThis = dbElrc.Execute ("SELECT d.department_discipline_id, d.discipline_title, a.section_name " &_
	"FROM ncu.dbo.dpro_concspec_current_v a " &_
		"INNER JOIN ncuelrc.dbo.department_disciplines d " &_
			"ON a.department_id = d.department_id " &_
				"LEFT OUTER JOIN ncuelrc.dbo.department_guides_main b " &_
					"ON a.section_name  = b.guide_title " &_
						"AND d.department_discipline_id = b.department_discipline_id " &_
							"WHERE b.department_guide_main_id IS NULL AND d.department_discipline_id = 3 " &_
								"GROUP BY  d.department_discipline_id, d.discipline_title, a.section_name " )%> 

 <h2>Add new specialization for Psychology</h2>       

<form action="default_action3.asp" method="POST">
    <input type="hidden" name="department_discipline_id" value="<%=iKey%>" /><br />                       
    <input type="hidden" name="gen_ed" value="0" /><br />                       
    <select name="guide_title">
       
      <%if not rsThis.eof then 
            do while not rsThis.eof%> 
           
           
           
            <option><%=rsThis("section_name")%></option> 

                
                
                
                <%rsThis.MoveNext
                loop%> 

        <%else
                
        response.Write("No Matches")
                
        end if 
                
                
        rsThis.Close
        Set rsThis = Nothing
    
         %>
         
         </select>
        
       <br /> 
        <br />  
  
    <input type="submit" value="Continue" name="action" />

</form>      


<%END Select%>

</body>
</HTML>

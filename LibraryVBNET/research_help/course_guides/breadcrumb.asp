<%Function BreadCrumb(dbElrc, deptId)

if deptId = 0 then 

    BreadCrumb = response.Write("<a href=""/library/research_help/course_guides/default.asp"">Course Guide Index</a>")
      
    'BreadCrumb = response.Write(deptId)
       
    else if deptId > 0 then 
    
    Set rsThis = dbElrc.Execute("Select guide_title, department_guide_main_id, department_discipline_id from department_guides_main where department_guide_main_id=" & deptId ) 
        
        if not rsThis.eof then
        
        Select case Cint(rsThis("department_discipline_id")) 
        
        case 1 
        
         sUrl = "bus_template.asp?department_guide_main_id=" & rsThis("department_guide_main_id")
         
        case 2
       
        sUrl = "ed_template.asp?department_guide_main_id=" & rsThis("department_guide_main_id")
        
        case 3
       
        sUrl = "psy_template.asp?department_guide_main_id=" & rsThis("department_guide_main_id")
        
        end Select 
    
        BreadCrumb = response.Write("<a href=""/library/research_help/course_guides/default.asp"">Course Guide Index</a> > &nbsp;") > response.Write("<a href="""& sUrl & """>" & rsThis("guide_title") & "</a>")
              
            end if 
     
      end if 
     
  end if 
  
  End Function
  
%>      




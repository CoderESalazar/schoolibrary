Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class submitted
    Inherits System.Web.UI.Page
    Dim dl As New NCUDataLayer("elrc")
    Dim dl1 As New NCUDataLayer("elrc")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim course_search = Session("search_course")
        Dim cat_search = Session("search_course")
        Dim f_date = Session("first_date")
        Dim s_date = Session("second_date")

        If Len(course_search) And Len(f_date) > 0 Then

            dl.SqlSelect("Select quest_lib.lib_userid, quest_lib.q_id, quest_lib.lib_date_time, quest_lib.email_sent, " & _
                            "quest_lib.file_upload, first_name, last_name, quest_lib.lib_cat, quest_lib.q_status, quest_lib.new_cat, quest_lib.u_last_name, quest_lib.q_type," & _
                                "quest_lib.deg_prog, quest_tb.date_time, course_num FROM quest_lib " & _
                                    "INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id INNER JOIN quest_tb ON quest_lib.q_id = quest_tb.q_id " & _
                                        "WHERE course_num LIKE '%" & course_search & "%' AND lib_date_time between '" & f_date & "' AND '" & s_date & "' ORDER BY lib_date_time DESC, quest_tb.date_time")

            Dim dt As DataTable = dl._DT
            If dt.Rows.Count > 0 Then

                rowCount.Text = dt.Rows.Count
                GridView1.DataSource = dt
                GridView1.DataBind()

            Else

                Response.Write("Sorry, no results were found or be sure you entered dates.")

            End If

        Else

            'Displays courses having the most reference questions.  

            dl1.SqlSelect("Select count(course_num) as TotalNumQuestions, Upper(course_num) As CourseNumber from quest_tb WHERE date_time between '" & f_date & "' AND '" & s_date & "' group by course_num order by TotalNumQuestions DESC")


            Dim dt1 As DataTable = dl1._DT
            If dt1.Rows.Count > 0 Then

                rowCount.Text = dt1.Rows.Count
                GridView2.DataSource = dt1
                GridView2.DataBind()

            Else

                Response.Write("Sorry, no results found.")


            End If


        End If

        'Response.Write("Please enter something into the search box.")


    End Sub

End Class
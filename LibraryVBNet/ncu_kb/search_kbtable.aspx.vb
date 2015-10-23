Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class search_kbtable
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        'Dim sSql As String
        'Dim search_l_name As String
        'Dim search_q_id As Integer

        'passing a session variable here to begin search

        prevLink.NavigateUrl = "/ncu_kb/kb_table.aspx"
        Dim search_q_id = Session("search_q_id")
        Dim search_l_name = Replace(Session("search_l_name"), "*", "")

        'Dim search_l_name = Session("search_l_name")

        If Len(search_l_name) > 0 Then

            'Response.Write(search_l_name)
            'Response.End()


            'dl.SqlSelect("SELECT quest_tb.q_id, quest_tb.u_last_name, u_first_name, date_time, lib_userid FROM quest_tb INNER JOIN quest_lib ON quest_tb.q_id = quest_lib.q_id where quest_tb.u_last_name LIKE '%" & Session("search_l_name") & "%' ORDER BY date_time DESC")
            dl.SqlSelect("SELECT ql.q_id, lib_date_time, last_name, ql.u_last_name, new_cat, email_sent, course_num, ql.deg_prog, ql.q_type FROM quest_lib ql " & _
                            "INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id " & _
                               "INNER JOIN quest_tb qt ON qt.q_id = ql.q_id " & _
                                 "WHERE ql.u_last_name LIKE '%" & search_l_name & "%' ORDER BY lib_date_time DESC")

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR


            'Response.Write(sSql)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)

                'SearchResults.Text = "Search Results for: " & Session("search")

                GridView1.DataSource = dt
                GridView1.DataBind()

                'dl.SetDBNAME(Nothing)

            Else

                Response.Write("Nothing found. Please try again.")


            End If

        ElseIf Len(Session("search_q_id")) > 0 Then

            'ElseIf search_q_id > 0 Then

            'dl.SqlSelect("SELECT quest_tb.q_id, quest_tb.u_last_name, u_first_name, date_time, lib_userid FROM quest_tb INNER JOIN quest_lib ON quest_tb.q_id = quest_lib.q_id where quest_tb.q_id = '" & Session("search_q_id") & "' ORDER BY date_time DESC")

            dl.SqlSelect("Select ql.q_id, lib_date_time, last_name, ql.u_last_name, new_cat, email_sent, course_num, ql.deg_prog, ql.q_type FROM quest_lib ql " & _
                            "INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id " & _
                                "INNER JOIN quest_tb qt ON qt.q_id = ql.q_id " & _
                                    "WHERE ql.q_id LIKE  '%" & search_q_id & "%' OR ql.q_id = '" & search_q_id & "' ORDER BY lib_date_time DESC")





            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR
            'Response.Write(search_q_id)
            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)

                'SearchResults.Text = "Search Results for: " & Session("search")

                GridView1.DataSource = dt
                GridView1.DataBind()

                'dl.SetDBNAME(Nothing)


            Else

                Response.Write("Nothing found. Please try again.")


            End If

        Else

            Response.Write("Please type something into the search box.")

        End If


        'Else

        'NothingEntered.Text = "Please enter something into the search box."


    End Sub

End Class
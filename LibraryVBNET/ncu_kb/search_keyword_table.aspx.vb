Imports NCUDataLayer
Imports NCUSecurity

Partial Class ncu_kb_search_keyword_table
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim search_key_1 = Replace(Session("search_key_1"), "*", "")
        Dim search_key_2 = Replace(Session("search_key_2"), "*", "")
        Dim bool = Session("search_bool")
        prevLink.NavigateUrl = "/ncu_kb/kb_table.aspx"
        'we have several conditions to satisfy
        'first we need to handle a phrase(meaning only one box is filled
        'second then we need to handle how both boxes are filled
        'however this will depend on what bool word is used. 
        Select Case bool

            Case "AND"

                'need to ensure that search for phrase is done.
                If Len(search_key_1) > 0 And Len(search_key_2) > 0 Then

                    'qt.lib_response searches phone reference
                    dl.SqlSelect("SELECT ql.q_id, lib_date_time, last_name, ql.u_last_name, new_cat, email_sent, ql.deg_prog, course_num, ql.q_type " & _
                                    "FROM quest_lib ql INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id " & _
                                        "INNER JOIN quest_tb qt ON qt.q_id = ql.q_id " & _
                                             "WHERE ql.lib_response LIKE '%" & search_key_1 & "%' AND " & _
                                                "ql.lib_response LIKE '%" & search_key_2 & "%' OR qt.q_detail LIKE '%" & search_key_1 & "%' " & _
                                                    "AND qt.lib_response LIKE '%" & search_key_2 & "%' ORDER BY lib_date_time DESC")

                    Dim dt As DataTable = dl._DT
                    Dim dr As DataRow = dl._DR

                    If dt.Rows.Count > 0 Then


                        'SearchResults.Text = "Search Results for: " & Session("search")

                        GridView1.DataSource = dt
                        GridView1.DataBind()

                    Else

                        Response.Write("Nothing found. Please try again.")

                    End If

                ElseIf Len(search_key_1) > 0 Then

                    dl.SqlSelect("SELECT ql.q_id, lib_date_time, last_name, ql.u_last_name, new_cat, email_sent, ql.deg_prog, course_num, ql.q_type " & _
                                    "FROM quest_lib ql INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id " & _
                                        "INNER JOIN quest_tb qt ON qt.q_id = ql.q_id " & _
                                            "WHERE ql.lib_response LIKE '%" & search_key_1 & "%' " & _
                                                "OR qt.q_detail LIKE '%" & search_key_1 & "%' " & _
                                                    "OR qt.lib_response LIKE '%" & search_key_1 & "%' ORDER BY lib_date_time DESC")


                    Dim dt As DataTable = dl._DT
                    Dim dr As DataRow = dl._DR
                    If dt.Rows.Count > 0 Then
                        dr = dt.Rows(0)

                        GridView1.DataSource = dt
                        GridView1.DataBind()

                    Else

                        Response.Write("Nothing found. Please try again.")

                    End If


                ElseIf Len(search_key_2) > 0 Then

                    'Response.Write(search_key_2)
                    'Response.End()
                    dl.SqlSelect("SELECT ql.q_id, lib_date_time, last_name, ql.u_last_name, new_cat, email_sent, ql.deg_prog, course_num, ql.q_type " & _
                                    "FROM quest_lib ql INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id " & _
                                        "INNER JOIN quest_tb qt ON qt.q_id = ql.q_id " & _
                                            "WHERE ql.lib_response LIKE '%" & search_key_2 & "%' " & _
                                                "OR qt.q_detail LIKE '%" & search_key_2 & "%' " & _
                                                    "OR qt.lib_response LIKE '%" & search_key_2 & "%' ORDER BY lib_date_time DESC")


                    Dim dt As DataTable = dl._DT
                    Dim dr As DataRow = dl._DR


                    If dt.Rows.Count > 0 Then
                        dr = dt.Rows(0)

                        'SearchResults.Text = "Search Results for: " & Session("search")

                        GridView1.DataSource = dt
                        GridView1.DataBind()

                        'dl.SetDBNAME(Nothing)

                    Else

                        Response.Write("Nothing found. Please try again.")

                    End If



                End If

            Case "OR"

                'sqlstmt that search either instance of the word

                dl.SqlSelect("SELECT ql.q_id, lib_date_time, last_name, ql.u_last_name, new_cat, email_sent, ql.deg_prog, course_num, ql.q_type " & _
                                "FROM quest_lib ql INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id " & _
                                    "INNER JOIN quest_tb qt ON qt.q_id = ql.q_id " & _
                                        "WHERE  ql.lib_response LIKE '%" & search_key_1 & "%' OR " & _
                                            "ql.lib_response LIKE '%" & search_key_2 & "%' OR " & _
                                                "qt.q_detail LIKE '%" & search_key_1 & "%' OR " & _
                                                    "qt.q_detail LIKE '%" & search_key_2 & "%' ORDER BY lib_date_time DESC")


                Dim dt As DataTable = dl._DT
                Dim dr As DataRow = dl._DR
                'just a grid here 
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)

                    'SearchResults.Text = "Search Results for: " & Session("search")

                    GridView1.DataSource = dt
                    GridView1.DataBind()

                    'dl.SetDBNAME(Nothing)

                Else

                    Response.Write("Nothing found. Please try again.")

                End If

            Case "NOT"

                
                dl.SqlSelect("SELECT ql.q_id, lib_date_time, last_name, ql.u_last_name, new_cat, email_sent, ql.deg_prog, course_num, ql.q_type " & _
                                "FROM quest_lib ql INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id " & _
                                    "INNER JOIN quest_tb qt ON qt.q_id = ql.q_id " & _
                                        "WHERE ql.lib_response LIKE '%" & search_key_1 & "%' AND ql.lib_response NOT LIKE '%" & search_key_2 & "%' " & _
                                            "OR qt.q_detail LIKE '%" & search_key_1 & "%' AND qt.q_detail NOT LIKE '%" & search_key_2 & "%' " & _
                                                "ORDER BY lib_date_time DESC")


                Dim dt As DataTable = dl._DT
                Dim dr As DataRow = dl._DR
                'just a grid here 
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)

                    'SearchResults.Text = "Search Results for: " & Session("search")

                    GridView1.DataSource = dt
                    GridView1.DataBind()

                    'dl.SetDBNAME(Nothing)

                Else

                    Response.Write("Nothing found. Please try again.")

                End If


        End Select




    End Sub
End Class

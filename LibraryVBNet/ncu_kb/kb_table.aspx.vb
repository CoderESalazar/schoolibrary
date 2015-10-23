Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class kb_table
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dlNcu As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not UserHasAccessToApplication(dlNcu, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Response.Write("Invalid Access")

            Response.End()

        Else

            dl.SqlSelect("Select q_id, date_time, u_first_name, u_last_name, q_status, cat_desc, q_type FROM quest_tb WHERE q_status is NULL AND q_type is NULL Order by date_time DESC")
            Dim dt As DataTable = dl._DT

            dl.SqlSelect("Select quest_lib.lib_userid, quest_lib.q_id, quest_lib.lib_date_time, quest_lib.email_sent, quest_lib.file_upload, first_name, last_name, quest_lib.lib_cat, quest_lib.q_status, quest_lib.new_cat, quest_lib.u_last_name, quest_lib.q_type, quest_lib.deg_prog, quest_tb.date_time, course_num from quest_lib INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id INNER JOIN quest_tb ON quest_lib.q_id = quest_tb.q_id where quest_lib.q_status = 'Submitted to KB' ORDER BY lib_date_time DESC, quest_tb.date_time")
            Dim dt1 As DataTable = dl._DT

            dl.SqlSelect("Select lib_userid, q_id, lib_date_time, first_name, last_name, lib_cat, q_status, new_cat, u_last_name from quest_lib INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id where q_status = 'Partial' ORDER BY lib_date_time DESC")
            Dim dt2 As DataTable = dl._DT

            dl.SqlSelect("Select quest_lib.lib_userid, quest_lib.q_id, quest_lib.lib_date_time, quest_lib.email_sent, quest_lib.file_upload, first_name, last_name, quest_lib.lib_cat, quest_lib.q_status, quest_lib.new_cat, quest_lib.u_last_name, quest_lib.q_type, quest_lib.deg_prog, quest_tb.date_time, course_num from quest_lib INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id INNER JOIN quest_tb ON quest_lib.q_id = quest_tb.q_id where quest_lib.q_status = 'Not Submitted to KB' AND datediff(d, lib_date_time, getdate()) < 45 ORDER BY lib_date_time DESC, quest_tb.date_time")
            Dim dt3 As DataTable = dl._DT

            dl.SqlSelect("Select q_id, date_time, u_first_name, u_last_name, q_status, cat_desc, q_type, lib_last_name FROM quest_tb WHERE (q_status is NULL OR q_status = 'Partial') AND (q_type is not NULL OR q_type = 'Phone') Order by date_time DESC")
            Dim dt4 As DataTable = dl._DT


            GridView1.DataSource = dt
            GridView1.DataBind()

            GridView2.DataSource = dt1
            GridView2.DataBind()

            GridView3.DataSource = dt2
            GridView3.DataBind()

            GridView4.DataSource = dt3
            GridView4.DataBind()

            GridView5.DataSource = dt4
            GridView5.DataBind()

        End If

    End Sub

    Protected Sub grdView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        'GridView1.DataSource = SortDataTable(GridView1.DataSource, True)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()

    End Sub


    Protected Sub grdView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging

        'GridView2.DataSource = SortDataTable(GridView2.DataSource, True)
        GridView2.PageIndex = e.NewPageIndex
        GridView2.DataBind()

    End Sub

    Protected Sub grdView3_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView3.PageIndexChanging
        'GridView3.DataSource = SortDataTable(GridView3.DataSource, True)
        GridView3.PageIndex = e.NewPageIndex
        GridView3.DataBind()

    End Sub


    Protected Sub grdView4_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView4.PageIndexChanging
        'GridView4.DataSource = SortDataTable(GridView4.DataSource, True)
        GridView4.PageIndex = e.NewPageIndex
        GridView4.DataBind()

    End Sub

    Private Property GridViewSortDirection() As String

        Get
            Return IIf(ViewState("SortDirection") = Nothing, "ASC", ViewState("SortDirection"))

        End Get

        Set(ByVal value As String)

            ViewState("SortDirection") = value

        End Set

    End Property

    Private Property GridViewSortExpression() As String

        Get
            Return IIf(ViewState("SortExpression") = Nothing, String.Empty, ViewState("SortExpression"))

        End Get

        Set(ByVal value As String)

            ViewState("SortExpression") = value

        End Set

    End Property

    Private Function GetSortDirection() As String

        Select Case GridViewSortDirection

            Case "ASC"

                GridViewSortDirection = "DESC"

            Case "DESC"

                GridViewSortDirection = "ASC"

        End Select

        Return GridViewSortDirection

    End Function

    Protected Function SortDataTable(ByVal dataTable As DataTable, ByVal isPageIndexChanging As Boolean) As DataView

        If Not dataTable Is Nothing Then

            Dim dataView As New DataView(dataTable)

            If GridViewSortExpression <> String.Empty Then

                If isPageIndexChanging Then

                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GridViewSortDirection)

                Else

                    dataView.Sort = String.Format("{0} {1}", GridViewSortExpression, GetSortDirection())

                End If

            End If

            Return dataView

        Else

            Return New DataView()

        End If

    End Function

    Protected Sub GridView3_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GridView3.PageIndex
        GridView3.DataSource = SortDataTable(GridView3.DataSource, False)
        GridView3.DataBind()
        GridView3.PageIndex = pageIndex


    End Sub

    Protected Sub GridView4_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GridView4.PageIndex
        GridView4.DataSource = SortDataTable(GridView4.DataSource, False)
        GridView4.DataBind()
        GridView4.PageIndex = pageIndex


    End Sub

    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GridView2.PageIndex
        GridView2.DataSource = SortDataTable(GridView2.DataSource, False)
        GridView2.DataBind()
        GridView2.PageIndex = pageIndex


    End Sub


    Private Sub search_qlib_table_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles search_qlib_table.Click

        Dim search_q_id As String
        Dim search_l_name As String

        search_l_name = l_name_search.Text
        search_q_id = q_id_search.Text

        Session("search_l_name") = search_l_name
        Session("search_q_id") = search_q_id

        Response.Redirect("search_kbtable.aspx")

    End Sub


    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReset.Click

        Me.Server.Transfer("kb_table.aspx")

    End Sub


    Protected Sub searchBoolbutt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles searchBoolbutt.Click


        Dim search_key_1 As String = searchText1.Text
        Dim search_key_2 As String = searchText2.Text
        Dim bool = boolSearch.SelectedValue

        Session("search_key_1") = search_key_1
        Session("search_key_2") = search_key_2
        Session("search_bool") = bool

        Response.Redirect("search_keyword_table.aspx")

    End Sub

    Protected Sub course_search_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles course_search.Click

        Dim course_search, first_date, second_date As String

        course_search = search_course.Text
        first_date = f_date.Text
        second_date = s_date.Text

        Session("search_course") = course_search
        Session("first_date") = first_date
        Session("second_date") = second_date

        Response.Redirect("submitted.aspx")

    End Sub
End Class
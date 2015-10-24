Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class _default
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            dl.SqlSelect("SELECT count(*) as Enrollees, ci.course_code, ci.course_name, ecr.guide_id, company_department_name, display_id, last_name " & _
                            "FROM ncu.dbo.course_info ci LEFT JOIN elrc_cr_guides ecr ON ci.course_code = ecr.course_code " & _
                                "INNER Join ncu.dbo.learner_courses lc ON ci.course_code = lc.course_code LEFT JOIN ncu.dbo.staff_info si ON staff_id = ecr.update_by " & _
                                    "WHERE LEN(ci.company_department_name) > 0 GROUP BY ci.course_code, ci.course_name, ecr.guide_id, company_department_name, display_id, si.last_name ORDER BY ci.course_code")

            Dim dt As DataTable = dl._DT
            GridView1.DataSource = dt
            GridView1.DataBind()

        Else

            Response.Write("Sorry, you cannot view this page")

        End If


    End Sub

    Protected Sub grdView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        'GridView1.DataSource = SortDataTable(GridView1.DataSource, True)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()

    End Sub



    Private Property GridViewSortDirection() As String

        Get
            'If (ViewState("SortDirection") Is Nothing) Then ViewState("SortDirection") = String.Empty

            'Return ViewState("SortDirection").ToString()

            Return IIf(ViewState("SortDirection") = Nothing, "ASC", ViewState("SortDirection"))

        End Get

        Set(ByVal value As String)

            ViewState("SortDirection") = value

        End Set

    End Property

    Private Property GridViewSortExpression() As String

        Get
            Return IIf(ViewState("SortExpression") = Nothing, "ASC", ViewState("SortExpression"))
            'If (ViewState("SortExpression") Is Nothing) Then ViewState("SortExpression") = String.Empty

            'Return ViewState("SortExpression").ToString()


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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GridView1.PageIndex
        GridView1.DataSource = SortDataTable(GridView1.DataSource, False)
        GridView1.DataBind()
        GridView1.PageIndex = pageIndex


    End Sub

    Private Sub guide_search_button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles guide_search_button.Click

        Dim search_stuff As String

        search_stuff = course_guide_search.Text

        Session("search") = search_stuff

        Response.Redirect("search.aspx")


    End Sub
End Class
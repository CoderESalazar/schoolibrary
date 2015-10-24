Imports compass
Imports compass.Security

Partial Public Class course_enrollees
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Dim dt As DataTable

            dl.SetDBNAME("ncu")

            Dim sSql As String

            sSql = "Select count(course_code) as Num_Learners, course_code from learner_courses where completed_date is null group by course_code order by course_code"

            dt = dl.SqlSelect(sSql)

            GridView1.DataSource = dt
            GridView1.DataBind()

            dl.SetDBNAME(Nothing)

        Else

            Response.Write("Sorry, you cannot view this file")


        End If


    End Sub

    Protected Sub grdView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        GridView1.DataSource = SortDataTable(GridView1.DataSource, True)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()

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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As GridViewSortEventArgs)

        GridViewSortExpression = e.SortExpression
        Dim pageIndex As Integer = GridView1.PageIndex
        GridView1.DataSource = SortDataTable(GridView1.DataSource, False)
        GridView1.DataBind()
        GridView1.PageIndex = pageIndex


    End Sub

End Class
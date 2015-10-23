Imports compass
Imports compass.Security

Partial Public Class _default1
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dl.SetDBNAME("ncu")

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            dl.SetDBNAME("elrc")

            Dim dt As New DataTable
            Dim dt1 As New DataTable

            dt = dl.SqlSelect("Select count(lr.event_id) as Registerees, event_date, lc.event_id, event_details, total_attendees, s_i.last_name " & _
            "FROM lib_calendar lc LEFT JOIN lib_registerees lr on lc.event_id = lr.event_id INNER JOIN ncu.dbo.staff_info s_i ON lib_instructor_id = staff_id " & _
            "group by lr.event_id, event_date, lc.event_id, event_details, total_attendees, lib_instructor_id, s_i.last_name " & _
            "ORDER BY event_date DESC")



            'Response.Write(dl.resultStatus.Message)
            'Response.End()

            GridView1.DataSource = dt
            GridView1.DataBind()

            'GridView2.DataSource = dt1
            'GridView2.DataBind()

            'dl.SetDBNAME(Nothing)

            'End If

        End If


    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

        'GridView1.DataSource = SortDataTable(GridView1.DataSource, True)
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
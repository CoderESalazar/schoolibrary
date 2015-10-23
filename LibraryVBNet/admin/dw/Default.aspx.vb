Imports NCUDataLayer, NCUSecurity

Partial Class admin_dw_Default
    Inherits System.Web.UI.Page


    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            dl.SqlSelect("SELECT key_id, title_dw FROM elrc_dw_info")

            Dim dt As DataTable = dl._DT

            GridView1.DataSource = dt
            GridView1.DataBind()

        End If

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
End Class

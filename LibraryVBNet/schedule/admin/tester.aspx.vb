Imports compass
Imports compass.Security
Partial Public Class tester
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dl As New compass.DataLayer
        dl.SetDBNAME("elrc")
        Dim dt As DataTable
        Dim sSql As String


        sSql = "Select event_id, lib_event from lib_calendar"

        dt = dl.SqlSelect(sSql)

        If dt.Rows.Count > 0 Then

            Grid1.DataSource = dt
            Grid1.DataBind()
        End If

    End Sub


    Protected Sub Grid1_UpdateCommand(ByVal sender As Object, ByVal e As Obout.Grid.GridRecordEventArgs) Handles Grid1.UpdateCommand
        'Throw New Exception("test")
        'Response.Write("test")
        Dim dl As New compass.DataLayer

        dl.SetDBNAME("elrc")
        Dim sSql As String

        sSql = "Update lib_calendar Set "
        sSql = sSql & "lib_event = '" & e.Record("lib_event") & "', "
        sSql = sSql & "Where event_id = '" & e.Record("event_id")

        dl.SqlExecute("sSql")
    End Sub
End Class
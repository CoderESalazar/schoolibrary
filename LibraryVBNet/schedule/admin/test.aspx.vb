Imports compass
Imports compass.Security

Partial Public Class test2
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dl As New compass.DataLayer
        'Dim sSQL As String
        dl.SetDBNAME("elrc")

        Dim dtLog As New DataTable

        'If Not Page.IsPostBack Then
        'sSQL = "SELECT event_date, lib_event, event_id, event_details, attend_details from lib_calendar"
        'dtLog = dl.SqlSelect(sSQL)


        dtLog = dl.SqlSelect("SELECT event_id, event_date, lib_event, event_details, attend_details from lib_calendar")

        Grid1.DataSource = dtLog

        Grid1.DataBind()

        dl.SetDBNAME(Nothing)


        'End If

    End Sub


    Protected Sub Grid1_UpdateCommand(ByVal sender As Object, ByVal e As Obout.Grid.GridRecordEventArgs) Handles Grid1.UpdateCommand

        Dim sSql As String = ""
        Dim dl As New compass.DataLayer
        'Dim dt As New DataTable
        Label1.Text = "hello"
        dl.SetDBNAME("elrc")

        sSql = ("Update lib_calendar Set lib_event = '" & e.Record("lib_event") & "' WHERE event_id = '" & e.Record("event_id"))
        'Response.Write(sSql)
        'Response.End()


        dl.SqlExecute(sSql)


    End Sub


End Class
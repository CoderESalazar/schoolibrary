Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class edit
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then     ' only do it the first time


            dl.SqlSelect("Select event_id, lib_home, event_date, event_details, display_home, total_attendees FROM lib_calendar WHERE event_id = " & Request.QueryString("event_id"))

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            Try

                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)
                    events_id.Text = dr("event_id") & ""
                    event_date.Text = dr("event_date") & ""
                    lib_home.Text = dr("lib_home") & ""
                    event_details.Content = dr("event_details") & ""
                    attendees.Text = dr("total_attendees") & ""
                    'Call CheckBox(dr("display_home"))

                End If
            Catch ex As Exception

            End Try

        Else

        End If
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim arFields(3) As String
        Dim arValues(3) As String
        Dim sKeyId As String
        Dim strUpdate As String

        sKeyId = Request.QueryString("event_id")

        arFields(0) = "event_date"
        arFields(1) = "event_details"
        'arFields(2) = "display_home"
        arFields(2) = "lib_home"
        arFields(3) = "total_attendees"

        arValues(0) = event_date.Text
        arValues(1) = event_details.Content
        'arValues(2) = HomeDisplay.Checked
        arValues(2) = lib_home.Text
        arValues(3) = attendees.Text

        strUpdate = dl.SqlUpdate("lib_calendar", "event_id", sKeyId, arFields, arValues)

        Response.Redirect("default.aspx")

    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim strDelete As String
        Dim strKeyId As String
        strKeyId = Request.QueryString("event_id")

        strDelete = dl.SqlDelete("lib_calendar", "event_id", strKeyId)

        Response.Redirect("default.aspx")

    End Sub


    'Protected Sub CheckBox(ByRef libWorkshop As String)

    'If libWorkshop = "True" Then

    'HomeDisplay.Checked = 1

    'Else

    'HomeDisplay.Checked = 0

    'End If

    'End Sub
End Class
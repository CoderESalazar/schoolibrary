Imports compass
Imports compass.Security

Partial Public Class registerees
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            dl.SetDBNAME("elrc")
            Dim sEventId = Request.QueryString("event_id")
            If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

                Dim dt As DataTable = dl.SqlSelect("Select key_id, (first_name + last_name) As Name,email_address, date_time from lib_registerees where event_id=" & sEventId)

                AddAttendee.NavigateUrl = "add_registeree.aspx?event_id=" & sEventId
                GridView1.DataSource = dt
                GridView1.DataBind()

            End If

        End If
    End Sub

End Class
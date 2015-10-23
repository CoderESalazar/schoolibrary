Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class add_registeree
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Response.Write("Invalid Access")

            Response.End()

        End If

    End Sub

    Private Sub Submit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Submit.Click

        Dim sEventId = Request.QueryString("event_id")
        'dl.SetDBNAME("elrc")

        Dim sFields() As String = {"first_name", "last_name", "email_address", "event_id", "date_time"}
        Dim sValues() As String = {first_name.Text, last_name.Text, email_address.Text, Request.QueryString("event_id"), _
                                    DateAndTime.Now}

        dl.SqlInsert("lib_registerees", sFields, sValues)

        Response.Redirect("registerees.aspx?event_id=" & sEventId)


    End Sub
End Class
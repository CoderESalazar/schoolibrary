Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class add
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Response.Write("Invalid Access")
            Response.End()

        Else

            Dim dlStaff As New NCUDataLayer()

            dlStaff.SqlSelect("SELECT first_name, last_name from staff_info WHERE staff_id = '" & CurrentLetmeinUserID() & "'")

            Dim dt As DataTable = dlStaff._DT
            Dim dr As DataRow = dlStaff._DR

            Response.Write("Hello " & dr("first_name") & " " & dr("last_name"))

        End If

    End Sub



    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click


        Dim sFields() As String = {"event_date", "lib_instructor_id", "date_time"}
        Dim sValues() As String = {event_date.Text, CurrentLetmeinUserID(), DateAndTime.Now.ToString("M/d/yyyy hh:mm tt")}

        dl.SqlInsert("lib_calendar", sFields, sValues)

        'Response.Write(dl.resultStatus.Message & " " & dl.resultStatus.SqlStatement)
        'Response.End()





        dl.SqlSelect("SELECT event_id from lib_calendar WHERE date_time = '" & DateAndTime.Now.ToString("M/d/yyyy hh:mm tt") & "'")


        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR


        Dim sEventId = (dr("event_id"))


        Response.Redirect("edit.aspx?event_id=" & sEventId)




    End Sub
End Class
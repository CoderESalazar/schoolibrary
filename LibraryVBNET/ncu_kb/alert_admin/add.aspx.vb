Imports NCUDataLayer
Imports NCUSecurity

Partial Class ncu_kb_alert_admin_add
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sFields() As String = {"alert_title", "alert_mess", "date_time"}
        Dim sValues() As String = {alert_title.Text, Editor1.Content, DateAndTime.Now}

        dl.SqlInsert("alert_box", sFields, sValues)

        Response.Redirect("/ncu_kb/alert_mess.aspx")


    End Sub
End Class

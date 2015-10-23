Imports NCUDataLayer
Imports NCUSecurity

Partial Class request_forms_cmts_vwr
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dl.SqlSelect("SELECT u_name, notes_comments, email_address, deg_prog, date_time, user_id FROM feed_back ORDER BY date_time DESC")
        Dim dt As DataTable = dl._DT

        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub
End Class

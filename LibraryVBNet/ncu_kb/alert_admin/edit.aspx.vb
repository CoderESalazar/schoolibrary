Imports NCUDataLayer
Imports NCUSecurity

Partial Class ncu_kb_alert_admin_edit
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim sKeyId = Request.QueryString("key_id")

            dl.SqlSelect("SELECT alert_title, alert_mess, alert_bit FROM alert_box WHERE key_id = " & sKeyId)

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            If dt.Rows.Count > 0 Then
                Dim sCheck = dr("alert_bit")

                alert_title.Text = dr("alert_title") & ""
                alert_mess.Content = dr("alert_mess") & ""

                If sCheck = "True" Then

                    alert_bit.Checked = True

                Else

                    alert_bit.Checked = False

                End If

            End If

        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sKeyId = Request.QueryString("key_id")

        Dim sFields() As String = {"alert_title", "alert_mess", "alert_bit"}
        Dim sValues() As String = {alert_title.Text, alert_mess.Content, alert_bit.Checked}

        dl.SqlUpdate("alert_box", "key_id", sKeyId, sFields, sValues)

        Response.Redirect("/ncu_kb/alert_mess.aspx")

    End Sub
End Class

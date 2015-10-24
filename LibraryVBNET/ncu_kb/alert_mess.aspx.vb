Imports NCUDataLayer
Imports NCUSecurity

Partial Class ncu_kb_alert_mess
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            dl.SqlSelect("SELECT key_id, alert_title, alert_bit, date_time FROM alert_box ORDER BY date_time")

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            If dt.Rows.Count > 0 Then

                GridView1.DataSource = dt
                GridView1.DataBind()

            End If

        Else

            Response.Write(CurrentLetmeinUserID())

            Dim bPublic = False

            If Len(CurrentLetmeinUserID()) = 0 Then bPublic = True

            If bPublic = True Then

                Dim iDomain As String = Request.ServerVariables("SERVER_NAME")

                ValidationCheck("LibraryAdmin", iDomain)


            End If

        End If
    End Sub
End Class

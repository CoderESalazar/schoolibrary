Imports NCUDataLayer
Imports NCUSecurity

Partial Class schedule_cancel_workshop

    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Len(CurrentLetmeinUserID()) = 0 Then


            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")


            ValidationCheck("UNIVPEOPLE", iDomain)

        Else
            dl.SqlSelect("SELECT first_name + ' ' + last_name as Name, l_r.event_id, event_date, event_details, l_r.key_id FROM lib_registerees l_r INNER JOIN lib_calendar l_c ON l_c.event_id = l_r.event_id WHERE event_date > current_timestamp AND user_id = '" & CurrentLetmeinUserID() & "' GROUP BY first_name, last_name, l_r.event_id, event_date, event_details, l_r.key_id")

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            If dt.Rows.Count > 0 Then

                GridView1.DataSource = dt
                GridView1.DataBind()

                'Response.Write(dr("key_id"))

            Else

                Response.Write("You are not currently registered for any workshops.")
                Response.End()


            End If
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        Dim key_id As Integer
        key_id = GridView1.DataKeys(e.RowIndex).Value

        dl.SqlDelete("lib_registerees", "key_id", key_id)

        GridView1.EditIndex = -1
        Response.Redirect("cancel_workshop.aspx")

    End Sub
End Class

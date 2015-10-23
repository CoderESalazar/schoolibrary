Imports NCUDataLayer
Imports NCUSecurity
Partial Public Class test
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Page.IsPostBack Then

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then


            Panel1.Visible = True

            dl.SqlSelect("Select lib_id, start_time, end_time, lib_chat, user_id from chat WHERE datediff(d, start_time, getdate()) < 15 ORDER BY start_time DESC")

            Dim dt As DataTable = dl._DT

            GridView1.DataSource = dt
            GridView1.DataBind()

        Else

            Response.Write("Sorry, you don't have access.")


        End If

        'End If

    End Sub

End Class
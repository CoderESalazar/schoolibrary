Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class add
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Page.IsPostBack Then

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Panel1.Visible = True

            Response.Write(CurrentLetmeinUserID())

        Else

            Response.Write("Sorry, you do not have access to the application.")

        End If

        'End If

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim sFields() As String = {"start_time", "user_id", "lib_chat"}
        Dim sValues() As String = {DateAndTime.Now, CurrentLetmeinUserID(), CheckBox1.Checked}

        dl.SqlInsert("chat", sFields, sValues)

        Response.Redirect("/chat_admin/log.aspx")

    End Sub
End Class
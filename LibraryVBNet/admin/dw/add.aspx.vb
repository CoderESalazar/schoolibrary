Imports NCUDataLayer, NCUSecurity

Partial Class admin_dw_add
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UserHasAccessToApplication(dl, CurrentLetmeinUserID, "LibraryAdmin")

    End Sub

    Protected Sub SubBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubBtn.Click

        Dim sFields() As String = {"title_dw", "text_dw"}
        Dim sValues() As String = {AddDWTitle.Text, Server.HtmlDecode(dw_body.Content)}

        dl.SqlInsert("elrc_dw_info", sFields, sValues)

        Response.Redirect("/admin/dw/")

    End Sub
End Class

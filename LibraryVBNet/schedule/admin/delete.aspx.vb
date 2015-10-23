Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class delete
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call deleteSub()

    End Sub


    Protected Sub deleteSub()

        Dim sKeyID = Request.QueryString("key_id")
        dl.SqlDelete("lib_registerees", "key_id", sKeyID)

        Response.Redirect("/schedule/admin/default.aspx")

    End Sub

End Class
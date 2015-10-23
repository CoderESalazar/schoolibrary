Imports compass
Imports compass.security

Partial Public Class add_cats
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub



    Private Sub btnCatCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCatCreate.Click

        Dim arFields(1) As String
        Dim arValues(1) As String

        Dim strAdd As String

        dl.SetDBNAME("elrc")


        If Len("cat_created") > 0 Then

            arFields(0) = "cat_name"
            arFields(1) = "q_id"

            arValues(0) = cat_created.Text
            arValues(1) = Session("query")

            strAdd = dl.SqlInsert("quest_cat", arFields, arValues)

            Response.Redirect("default.aspx?q_id=" & Session("query"))

        Else

            Response.Write("Please enter a value for a category.")

        End If

    End Sub
End Class
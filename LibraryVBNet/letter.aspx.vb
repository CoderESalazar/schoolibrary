Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class mess_frm_dir
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sEntryId = Request.QueryString("entry_id")

        dl.SqlSelect("SELECT letter_title, letter_content FROM letters_tb where entry_id=" & sEntryId)

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR

        dr = dt.Rows(0)

        LetterTitle.Text = dr("letter_title") & ""
        LetterView.DataSource = dt
        LetterView.DataBind()

    End Sub

End Class
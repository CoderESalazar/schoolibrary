Imports compass
Imports compass.security

Partial Public Class test_download
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim dt As DataTable
        Dim dr As DataRow
        Dim sSql As String
        dl.SetDBNAME("elrc")

        Dim BlobData() As Byte

        sSql = "Select attachment_file, attachment_file_name from file_uploads WHERE q_id=" & Request.QueryString("q_id")

        dt = dl.SqlSelect(sSql)

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            BlobData = dr("attachment_file")
            Response.Clear()
            Response.Buffer = True
            Response.AddHeader("content-disposition", "attachment;filename=" & dr("attachment_file_name"))
            Response.ContentType = "application/octet-stream"
            Response.BinaryWrite(BlobData)
            Response.End()

        End If


    End Sub

End Class
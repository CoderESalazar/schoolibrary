Imports compass
Imports compass.security

Partial Public Class upload
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        If Len(FileUpload1.FileName) > 1 Then

            Dim sFields(2) As String
            Dim sValues(2) As String
            dl.SetDBNAME("ncu_elrc")

            sFields(0) = "upload_id"  ' this will be unique because I need to create table that can hold attachments
            sFields(1) = "attachment_file_name"
            sFields(2) = "attachment_file_type"

            sValues(0) = FileUpload1.ToString
            sValues(1) = FileUpload1.FileName
            sValues(2) = Replace(System.IO.Path.GetExtension(FileUpload1.FileName), ".", "")


            Dim sKey As String = dl.SqlInsert("file_uploads", sFields, sValues)

        End If


        Response.Redirect("../kb_table.aspx")



    End Sub
End Class
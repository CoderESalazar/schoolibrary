Imports compass
Imports compass.Security

Partial Public Class test_add
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Response.Write("Sorry, Charlie")

        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        'File Upload functions
        If Len(FileUpload1.FileName) > 1 Then

            Dim sFields(2) As String
            Dim sValues(2) As String
            Dim sKey As String
            Dim SendMessageBlob As String
            'Dim sQid As String

            'sQid = Request.QueryString("q_id")

            dl.SetDBNAME("elrc")

            sFields(0) = "q_id"  ' this will be unique because I need to create table that can hold attachments
            sFields(1) = "attachment_file_name"
            sFields(2) = "attachment_file_type"

            sValues(0) = Request.QueryString("q_id")
            sValues(1) = FileUpload1.FileName
            sValues(2) = Replace(System.IO.Path.GetExtension(FileUpload1.FileName), ".", "")


            sKey = dl.SqlInsert("file_uploads", sFields, sValues)


            'attach blog to the db

            SendMessageBlob = dl.SqlBlob("file_uploads", "upload_id", sKey, "attachment_file", FileUpload1.PostedFile)

            Session("sKey") = sKey
            Response.Redirect("kb_table.aspx")

        Else

            Response.Write("Nothing was attached")


        End If

    End Sub
End Class
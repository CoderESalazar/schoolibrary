Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class login
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim bPublic = False
        If Len(Trim(CurrentLetmeinUserId())) = 0 Then bPublic = True
        If bPublic Then

            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            ValidationCheck("UnivPeople", iDomain)
            'Response.Write("This is a password protected page.")

        Else

            Dim BlobData() As Byte

            dl.SqlSelect("SELECT * FROM dissertation_checklist WHERE dissertation_id=" & Request.QueryString("dissertation_id"))

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow

            If dt.Rows.Count > 0 Then

                dr = dt.Rows(0)

                BlobData = dr("dissertation_file")
                Response.Clear()
                Response.Buffer = True
                Dim sFileName As String = dr("dissertation_file_name")
                sFileName.Replace(", ", "_")
                Response.AddHeader("content-disposition", "attachment;filename=" & sFileName)
                Response.ContentType = "application/octet-stream"
                Response.BinaryWrite(BlobData)
                Response.End()

            End If
        End If

    End Sub

End Class
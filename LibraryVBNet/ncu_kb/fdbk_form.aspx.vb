Imports NCUDataLayer
Imports NCUSecurity
Partial Public Class fdbk_form
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Len(CurrentLetmeinUserID()) = 0 Then

            Response.Redirect("/")

        End If

    End Sub


    Private Sub fdbkBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fdbkBtn.Click

        Dim sQid As String


        sQid = (Session("query"))

        If Len(fdbk_desc.Value) > 0 Then

            Try
                Dim objmail As New System.Net.Mail.MailMessage()
                objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
                objmail.To.Add("library@ncu.edu")
                objmail.Subject = "Feedback - Knowledge Base"
                objmail.Body = "QID:" & sQid & " UserID:" & CurrentLetmeinUserID() & " Feedback:" & fdbk_desc.Value
                Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
                objSMTP.Send(objmail)

            Catch ex As Exception


            End Try

            Response.Redirect("/library/ncu_kb/fdbk_confirm.aspx")

        Else

            Response.Write("*Please enter something in the box or go to the <a href=/library/>Library</a>")

        End If

    End Sub
End Class
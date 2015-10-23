Imports NCUSecurity
Imports NCUDataLayer

Partial Public Class fdbk_form1
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Len(CurrentLetmeinUserID()) = 0 Then

            Response.Redirect("/")

        End If


    End Sub


    Private Sub fdbkBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fdbkBtn.Click

        Dim q_id As String
        Dim email_address As String

        q_id = Request.QueryString("q_id")

        dl.SqlSelect("Select lib_userid, staff_id, email_address from quest_lib INNER JOIN ncu.dbo.staff_info ON lib_userid = staff_id where q_id= " & Request.QueryString("q_id"))

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR

        If Len(fdbk_desc.Value) > 0 Then

            If dt.Rows.Count > 0 Then


                email_address = dr("email_address")

                Dim objmail As New System.Net.Mail.MailMessage()
                objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
                objmail.To.Add(email_address)
                objmail.Subject = "Feedback - Knowledge Base"
                objmail.Body = "Q_ID: " & q_id & " Feedback: " & fdbk_desc.Value
                Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
                objSMTP.Send(objmail)

                Response.Redirect("/ncu_kb/user/user_confirm.aspx")

            End If


        Else

            Response.Write("Please provide feedback or go to the <a href=/library/>Library</a>")

        End If

    End Sub

End Class
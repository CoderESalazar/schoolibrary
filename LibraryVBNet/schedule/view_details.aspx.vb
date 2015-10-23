Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class register
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dlNcu As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sEventId = Request.QueryString("event_id")
        Dim sUserId = CurrentLetmeinUserID()
        Dim sUrl = Request.ServerVariables("REFERER")

        dl.SqlSelect("SELECT event_date, event_details FROM lib_calendar where event_id = " & sEventId)

        Dim dtEventDate As DataTable = dl._DT
        Dim drEventDate As DataRow = dl._DR

        Dim sEventDate = drEventDate("event_date")
        Dim sEventDetails = drEventDate("event_details")

        'Doing a Learner Check

        dlNcu.SqlSelect("Select first_name, last_name, email_address_1 from learner_info where learner_id = '" & CurrentLetmeinUserID() & "'")

        Dim dtLearner As DataTable = dlNcu._DT
        Dim drLearner As DataRow = dlNcu._DR

        If dtLearner.Rows.Count = 0 Then

            dl.SqlSelect("Select first_name, last_name, email_address_public from mentor_info where mentor_id = '" & CurrentLetmeinUserID() & "' AND date_end IS NULL")

            Dim dtMentors As DataTable = dlNcu._DT
            Dim drMentors As DataRow = dlNcu._DR

            'Doing Mentor Check
            If dtMentors.Rows.Count = 0 Then

                dlNcu.SqlSelect("Select first_name, last_name, email_address from staff_info where staff_id = '" & CurrentLetmeinUserID() & "' AND end_date IS NULL")

                'Doing Staff Check
                Dim dtStaff As DataTable = dlNcu._DT
                Dim drStaff As DataRow = dlNcu._DR

                If dtStaff.Rows.Count = 0 Then

                    Response.Write("Invalid Access!")

                Else

                    dl.SqlSelect("SELECT event_id from lib_registerees WHERE event_id = " & sEventId & " AND user_id = '" & sUserId & "'")

                    Dim dtCheck As DataTable = dl._DT
                    If dtCheck.Rows.Count = 0 Then

                        first_name_invite.Text = drStaff("first_name")
                        last_name_invite.Text = drStaff("last_name")
                        email_address.Text = drStaff("email_address")
                        first_name.Text = drStaff("first_name")
                        last_name.Text = drStaff("last_name")
                        Dim objmail As New System.Net.Mail.MailMessage()
                        objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
                        objmail.To.Add(drStaff("email_address"))
                        objmail.Subject = "Northcentral University Library Workshop"
                        objmail.Body = "This is an email reminder that you have registered for a Library Workshop scheduled " & sEventDate & " Arizona time. You will receive an email closer to the scheduled workshop date with access instructions and a workshop outline. If you have any problems or questions, call 888-327-2877."
                        Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
                        objSMTP.Send(objmail)

                        email_sent.Text = "Thank you for registering. An email has been sent to your email address on record. If you do not receive an email, please phone us at 888-327-2877. Return to previous <a href=" & sUrl & ">page</a>."

                        Call PageInsert()

                    Else

                        Response.Write("You are currently registered for this course.")

                    End If

                End If

            Else


                dl.SqlSelect("SELECT event_id from lib_registerees WHERE event_id = " & sEventId & " AND user_id = '" & sUserId & "'")

                Dim dtCheck As DataTable = dl._DT

                If dtCheck.Rows.Count = 0 Then

                    first_name_invite.Text = drMentors("first_name")
                    last_name_invite.Text = drMentors("last_name")
                    email_address.Text = drMentors("email_address_public")
                    first_name.Text = drMentors("first_name")
                    last_name.Text = drMentors("last_name")
                    Dim objmail As New System.Net.Mail.MailMessage()
                    objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
                    objmail.To.Add(drMentors("email_address_public"))
                    objmail.Subject = "NCU Library Workshop"
                    objmail.Body = "This is an email reminder that you have registered for a Library Workshop scheduled " & sEventDate & " Arizona time. You will receive an email closer to the scheduled workshop date with access instructions and a workshop outline. If you have any problems or questions, call 888-327-2877."
                    Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
                    objSMTP.Send(objmail)

                    email_sent.Text = "Thank you for registering. An email has been sent to your email address on record. If you do not receive an email, please phone us at 888-327-2877. Return to previous <a href=" & sUrl & ">page</a>."

                    Call PageInsert()

                Else

                    Response.Write("You are currently registered for this course.")

                End If

            End If

        Else

            dl.SqlSelect("SELECT event_id from lib_registerees WHERE event_id = " & sEventId & " AND user_id = '" & sUserId & "'")

            Dim dtCheck As DataTable = dl._DT

            If dtCheck.Rows.Count = 0 Then

                first_name_invite.Text = drLearner("first_name")
                last_name_invite.Text = drLearner("last_name")
                first_name.Text = drLearner("first_name")
                last_name.Text = drLearner("last_name")
                email_address.Text = drLearner("email_address_1")
                Dim objmail As New System.Net.Mail.MailMessage()
                objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
                objmail.To.Add(drLearner("email_address_1"))
                objmail.Subject = "NCU Library Workshop"
                objmail.Body = "This is an email reminder that you have registered for a Library Workshop scheduled " & sEventDate & " Arizona time. You will receive an email closer to the scheduled workshop date with access instructions and a workshop outline. If you have any problems or questions, call 888-327-2877."
                Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
                objSMTP.Send(objmail)

                email_sent.Text = "Thank you for registering. An email has been sent to your email address on record. If you do not receive an email, please phone the Library at 888-327-2877. Return to previous <a href=" & sUrl & ">page</a>."

                Call PageInsert()

            Else

                Response.Write("You are currently registered for this course.")

            End If

        End If

    End Sub

    Protected Sub PageInsert()

        Dim arFields(5) As String
        Dim arValues(5) As String

        arFields(0) = "first_name"
        arFields(1) = "last_name"
        arFields(2) = "event_id"
        arFields(3) = "date_time"
        arFields(4) = "email_address"
        arFields(5) = "user_id"

        arValues(0) = first_name.Text
        arValues(1) = last_name.Text
        arValues(2) = Request.QueryString("event_id")
        arValues(3) = DateTime.Now
        arValues(4) = email_address.Text
        arValues(5) = CurrentLetmeinUserID()

        dl.SqlInsert("lib_registerees", arFields, arValues)


    End Sub

End Class
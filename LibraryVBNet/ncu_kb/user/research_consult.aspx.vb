Imports NCUDataLayer
Imports NCUSecurity

Partial Class ncu_kb_research_consult
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dlNCU As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Response.Write("This is a test!")

        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        Dim bPublic = False

        If Len(CurrentLetmeinUserID()) = 0 Then bPublic = True

        If bPublic = True Then

            not_logged_in.Visible = "True"
            research_consult.Visible = "False"

            'Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            'ValidationCheck("UnivPeople", iDomain)


        End If

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "Staff") Then

            'courseNum.Focus()

            dlNCU.SqlSelect("Select first_name, last_name, email_address from staff_info WHERE staff_id = '" & CurrentLetmeinUserID() & "'")

            'Response.Write(dlNCU.Severity & " , " & dlNCU.SqlStatement & " , " & dlNCU.Results)
            'Response.End()
            Dim dt As DataTable = dlNCU._DT
            Dim dr As DataRow = dlNCU._DR

            If dt.Rows.Count > 0 Then

                first_names.Text = dr("first_name") & ""
                first_names.Text = dr("first_name")
                last_name.Text = dr("last_name") & ""
                email_address.Text = dr("email_address") & ""
                current_user_id.Text = CurrentLetmeinUserID()

            End If

        ElseIf UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "Mentor") Then

            dlNCU.SqlSelect("Select first_name, last_name, email_address_public from mentor_info WHERE mentor_id = '" & CurrentLetmeinUserID() & "'")

            Dim dt As DataTable = dlNCU._DT
            Dim dr As DataRow = dlNCU._DR

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)

                first_names.Text = dr("first_name") & ""
                first_names.Text = dr("first_name") & ""
                last_name.Text = dr("last_name") & ""
                email_address.Text = dr("email_address_public") & ""
                current_user_id.Text = CurrentLetmeinUserID()

            End If

        ElseIf UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "Learner") Then


            dlNCU.SqlSelect("Select learner_info.learner_id, first_name, last_name, email_address_1, degree_program_code from learner_info INNER JOIN learner_programs ON learner_info.learner_id = learner_programs.learner_id WHERE learner_info.learner_id = '" & CurrentLetmeinUserID() & "' AND degree_program_code <> 'PROFDEV'")

            Dim dt As DataTable = dlNCU._DT
            Dim dr As DataRow = dlNCU._DR

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)

                first_names.Text = dr("first_name") & ""
                last_name.Text = dr("last_name") & ""
                email_address.Text = dr("email_address_1") & ""
                current_user_id.Text = CurrentLetmeinUserID()
                deg_prog.Text = dr("degree_program_code") & ""

            End If

        End If

    End Sub


    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        research_consult.Visible = "false"

        Dim objmail As New System.Net.Mail.MailMessage()
        objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
        objmail.To.Add("library@ncu.edu")
        objmail.Subject = "Research Consultation"
        objmail.Body = "First Name: " & first_names.Text & vbCr & "Last Name: " & last_name.Text & vbCr & _
        "Email address: " & email_address.Text & vbCr & "ID #" & current_user_id.Text & vbCr & _
        "Degree Prog: " & deg_prog.Text & vbCr & "Question Desc: " & desc_quest.Value & vbCr & _
        "Steps Taken: " & steps_taken.Value & vbCr & "Difficulties: " & diff_encount.Value & vbCr & _
        "Assistance Req: " & req_assist.Value & vbCr & "Desired Time of Day: " & best_time.SelectedValue & ""

        Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
        objSMTP.Send(objmail)

        'Response.Redirect("/ncu_kb/user/user_confirm.aspx")

        consult_message.Visible = "True"
        consult_mess.Text = "Thank you for your consultation request. We will contact you promptly to schedule your appointment. To return to the Library, please click <a href=http://library.ncu.edu> NCU Library</a>."

    End Sub
End Class

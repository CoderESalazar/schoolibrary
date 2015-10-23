Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class user_page
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dlNCU As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Call CatSelect()

        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        Dim bPublic = False

        If Len(CurrentLetmeinUserID()) = 0 Then bPublic = True

        If bPublic = True Then

            not_logged_in.Visible = "true"
            ask_a_librarian.Visible = "false"

            'Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            'ValidationCheck("UnivPeople", iDomain)

        End If


        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "Staff") Then

            courseNum.Focus()

            dlNCU.SqlSelect("Select first_name, last_name, email_address from staff_info WHERE staff_id = '" & CurrentLetmeinUserID() & "'")

            'Response.Write(dlNCU.Severity & " , " & dlNCU.SqlStatement & " , " & dlNCU.Results)
            'Response.End()
            Dim dt As DataTable = dlNCU._DT
            Dim dr As DataRow = dlNCU._DR

            If dt.Rows.Count > 0 Then

                first_name_invite.Text = dr("first_name") & ""
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

                first_name_invite.Text = dr("first_name") & ""
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

                first_name_invite.Text = dr("first_name") & ""
                first_names.Text = dr("first_name") & ""
                last_name.Text = dr("last_name") & ""
                email_address.Text = dr("email_address_1") & ""
                current_user_id.Text = CurrentLetmeinUserID()
                deg_prog.Text = dr("degree_program_code") & ""

            End If

        End If

    End Sub


    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        If (Page.IsValid) Then

            Dim arFields(9) As String
            Dim arValues(9) As String

            Dim strAdd As String

            arFields(0) = "u_first_name"
            arFields(1) = "u_last_name"
            arFields(2) = "cat_desc"
            arFields(3) = "course_num"
            arFields(4) = "assign_num"
            arFields(5) = "q_detail"
            arFields(6) = "email_address"
            arFields(7) = "user_id"
            arFields(8) = "date_time"
            arFields(9) = "deg_prog"

            arValues(0) = first_names.Text
            arValues(1) = last_name.Text
            arValues(2) = cat_drop.SelectedValue
            arValues(3) = courseNum.Text
            arValues(4) = courseAssign.Text
            arValues(5) = comments_box.Value
            arValues(6) = email_address.Text
            arValues(7) = current_user_id.Text
            arValues(8) = DateTime.Now
            arValues(9) = deg_prog.Text

            dl.SqlInsert("quest_tb", arFields, arValues)

            strAdd = dl.Identity

            Session("strAdd") = strAdd

            Response.Redirect("user_confirm.aspx")

        Else

            Label1.Text = "INVALID SUBMISSION. Please select Category and type in Question below."

        End If

        'QSubmit.Text = "Thank you for submitting your e-reference question. We will try to respond to your question as quickly as possible. Thank you."


    End Sub


    Protected Sub CatSelect()

        'this will bind the dropdown menu items as opposed to using a FOR loop

        'Dim dl As New compass.Compass_BusinessLayer
        dl.SqlSelect("Select cat_id, cat_name from quest_cat order by cat_name")

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR
        Dim i As Integer
        Dim newItem As ListItem

        cat_drop.Items.Insert(0, New ListItem("Please Select", " "))
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            newItem = New ListItem
            newItem.Text = dr("cat_name")
            newItem.Value = dr("cat_id")
            cat_drop.Items.Add(newItem)
        Next
    End Sub


End Class
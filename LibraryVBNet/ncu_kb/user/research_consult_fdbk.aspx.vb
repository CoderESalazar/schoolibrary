Imports NCUDataLayer
Imports NCUSecurity
Imports LibraryFunctions

Partial Class ncu_kb_user_research_consult_fdbk
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mainNav As UserControls_wucNavBar = Master.NavBar
        mainNav.BuildLibraryMenu()

        Dim bPublic = False
        If Len(Trim(CurrentLetmeinUserID())) = 0 Then bPublic = True
        If bPublic = True Then

            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            ValidationCheck("UnivPeople", iDomain)

        Else

            'dl.SqlSelect("SELECT lib_name FROM lib_admin_people")

            'Dim dt As DataTable = dl._DT
            'Dim dr As DataRow = dl._DR
            'Dim i As Integer
            'Dim newItem As ListItem

            'LibList.Items.Insert(0, New ListItem("Please Select", " "))
            'For i = 0 To dt.Rows.Count - 1
            'dr = dt.Rows(i)
            'newItem = New ListItem
            'newItem.Text = dr("lib_name")
            'LibList.Items.Add(newItem)
            'Next

        End If

        info.Text = UserCreds(CurrentLetmeinUserID())
        'last_name.Text = UserCreds("last_name")
        'email_address.Text = UserCreds("email_address")
        'current_user_id.Text = CurrentLetmeinUserID()
        'deg_prog.Text = UserCreds("deg_prog")

    End Sub

    Protected Sub Sbmt_bttn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Sbmt_bttn.Click

        research_consult_fdbk.Visible = False

        Dim objmail As New System.Net.Mail.MailMessage()
        objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
        objmail.To.Add("library@ncu.edu")
        objmail.Subject = "Research Consultation Feedback"
        objmail.Body = "Info: " & info.Text & vbCr & _
        "PrimaryRole:" & primary_role.SelectedValue & vbCr & _
        "ConsultTimes: " & first_research_consult.SelectedValue & vbCr & "NeedsMet: " & needs_met.SelectedValue & vbCr & _
        "LibrarianPrep: " & librarian_preparation.SelectedValue & vbCr & "LibrarianKnow: " & librarian_knowledge.SelectedValue & vbCr & _
        "RecommendConsult: " & recommend_consult.SelectedValue & vbCr & "TechnologyUsed: " & technology_used.SelectedValue & vbCr & _
        "Comments: " & comments_box.Value & ""

        Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
        objSMTP.Send(objmail)

        research_consult_message.Visible = True
        consult_mess.Text = "Thank you for your feedback. To return to the Library, please click <a href=http://library.ncu.edu> NCU Library</a>."
    End Sub
End Class

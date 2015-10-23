Imports NCUSecurity

Partial Class Search
    Inherits System.Web.UI.MasterPage

    Dim _sql As String = String.Empty
    Dim _dl As New NCUDataLayer
    Dim _ncuDataPersist As New NCUDataPersist
    Dim _ncuNotifications As New NCUNotifications


    Public ReadOnly Property NavBar() As UserControls_wucNavBar
        Get
            Return wucNavBar
        End Get

    End Property

    Dim dLib As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'If Not Request.Cookies("X-Ncu-Sso-UserId") Is Nothing Then

        '    Response.Write(Request.Cookies("X-Ncu-Sso-UserId").Value)

        'End If

        Dim sDomain = Request.ServerVariables("SERVER_NAME")

        Select Case sDomain

            Case "ed-library.ncu.edu"

                my_ncu.NavigateUrl = "http://dev7-my.ncu.edu/account/logon"
                learner_link.NavigateUrl = "http://ed-learners.ncu.edu/"
                mentor_link.NavigateUrl = "http://ed-mentors.ncu.edu/"
                'staff_link.NavigateUrl = "http://ed-admin.ncu.edu/"
            Case "beta-library.ncu.edu"

                my_ncu.NavigateUrl = "http://beta7-my.ncu.edu/"
                learner_link.NavigateUrl = "http://beta-learners.ncu.edu/"
                mentor_link.NavigateUrl = "http://beta-mentors.ncu.edu/"
                'staff_link.NavigateUrl = "http://beta-admin.ncu.edu/"

            Case "library02.ncu.edu"
                my_ncu.NavigateUrl = "http://my.ncu.edu/"
                learner_link.NavigateUrl = "http://learners02.ncu.edu/"
                mentor_link.NavigateUrl = "http://mentors02.ncu.edu/"

            Case "library.ncu.edu"

                my_ncu.NavigateUrl = "http://my.ncu.edu/"
                learner_link.NavigateUrl = "http://learners.ncu.edu/"
                mentor_link.NavigateUrl = "http://mentors.ncu.edu/"
                'staff_link.NavigateUrl = "http://admin.ncu.edu/"

        End Select

        'Response.Write(Request.ServerVariables("QUERY_STRING") & " " & Request.ServerVariables("SCRIPT_NAME") & " " & Request.ServerVariables("SERVER_NAME"))


        lblUserName.Text = UserName(CurrentLetmeinUserID())

        If Len(CurrentLetmeinUserID()) > 0 Then

            ibtnLogin.ImageUrl = "~/temp/Images/padlock_closed.gif"
            ibtnLogin.ToolTip = "Logout"
            ibtnLogin.AlternateText = "Logout"

        End If

        'chat script 

        dLib.SqlSelect("SELECT lib_chat from chat")

        Dim dtChat As DataTable = dLib._DT

        For Each drChat As DataRow In dtChat.Rows
            If drChat("lib_chat") = "1" Then

                chat_link.Visible = True
                chat_link.NavigateUrl = "skype:library-ncu?chat"
                'RoadRun.Visible = True
            Else

                chat_link.Visible = False
                'RoadRun.Visible = False

            End If

        Next

        If UserHasAccessToApplication(dLib, CurrentLetmeinUserID(), "LibraryAdmin") Then

            LibraryAdminArea.Visible = True

        End If

        Call AlertMess()
        Call homePageStats()
        Call ViewedMessages()
        'End If
    End Sub

    Protected Sub ibtnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnLogin.Click

        If ibtnLogin.AlternateText = "Logout" Then


            NCUSecurity.SignOut()


        ElseIf ibtnLogin.AlternateText = "Login" Then

            Response.Redirect("/DrawBridge/Login.aspx")

            'Response.Redirect("http://beta7-my.ncu.edu/Account/LogOn")

        End If

    End Sub

    Protected Sub AlertMess()

        Dim _dlElrc As New NCUDataLayer("elrc")

        _dlElrc.SqlSelect("SELECT alert_title, alert_mess FROM alert_box WHERE alert_bit = 1")

        Dim dt As DataTable = _dlElrc._DT
        Dim dr As DataRow = _dlElrc._DR

        If dt.Rows.Count > 0 Then

            LabelTitle.Text = dr("alert_title") & ""
            LabelContent.Text = dr("alert_mess") & ""

            PnlTitle.Visible = True
            PnlContent.Visible = True
        Else

            LabelTitle.Visible = False
            LabelContent.Visible = False
            Label1.Visible = False
            PnlTitle.Visible = False
            PnlContent.Visible = False

        End If

    End Sub

    Protected Sub homePageStats()

        If Len(CurrentLetmeinUserID()) > 0 Then

            Dim sDomain = Request.ServerVariables("SERVER_NAME")

            Dim sFields() As String = {"user_id", "site_id"}
            Dim sValues() As String = {CurrentLetmeinUserID(), sDomain}

            dLib.SqlInsert("stats_id_elrc", sFields, sValues)

        End If


    End Sub

    Protected Sub ViewedMessages()

        dLib.SqlSelect("SELECT COUNT(qt.user_id) As the_count" & _
                            " FROM quest_lib ql INNER JOIN quest_tb qt ON ql.q_id = qt.q_id" & _
                                " WHERE viewed_mess = 0 And ql.q_status Is Not NULL And ql.q_type Is NULL And ql.q_status" & _
                                    " LIKE '%Submitted to KB%' AND user_id = '" & CurrentLetmeinUserID() & "'")

        Dim dt As DataTable = dLib._DT
        'Dim dr As DataRow = dLib._DR

        If dt.Rows.Count > 0 Then

            Dim dr = dt.Rows(0)

            messages.Text = "You have <a href=/ncu_kb/user/user_area.aspx>" & dr("the_count") & "</a> unread messages."

        ElseIf dt.Rows.Count = 0 Then

            messages.Text = "You have <a href=/ncu_kb/user/user_area.aspx>0</a> unread messages."

        End If

    End Sub
End Class


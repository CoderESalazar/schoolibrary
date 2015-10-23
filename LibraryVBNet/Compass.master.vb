Imports NCUSecurity
#Region "History"
' Creation - JCA - 24 February 2010
#End Region
Partial Class Compass
    Inherits System.Web.UI.MasterPage
#Region "Class Storage"
    Dim _sql As String = String.Empty
    Dim _dl As New NCUDataLayer
#End Region
#Region "Public Properties Events and Methods"
    Public ReadOnly Property NavBar() As UserControls_wucNavBar
        Get
            Return wucNavBar
        End Get
    End Property
#End Region

    Dim dLib As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lblUserName.Text = UserName(CurrentLetmeinUserID())
        Dim sDomain = Request.ServerVariables("SERVER_NAME")
        'Dim sDomain = Request.Url.PathAndQuery
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

        If Len(CurrentLetmeinUserID()) > 0 Then

            ibtnLogin.ImageUrl = "~/temp/Images/padlock_closed.gif"
            ibtnLogin.ToolTip = "Logout"
            ibtnLogin.AlternateText = "Logout"

        End If

        'Chat script 

        dLib.SqlSelect("SELECT lib_chat from chat")

        Dim dtChat As DataTable = dLib._DT

        For Each drChat As DataRow In dtChat.Rows
            If drChat("lib_chat") = "1" Then

                chat_link.Visible = True
                chat_link.NavigateUrl = "skype:library-ncu?chat"
                'chat_link.NavigateUrl = "lib_chat.aspx"
                'RoadRun.Visible = True
            Else

                chat_link.Visible = False
                'RoadRun.Visible = False

            End If

        Next

        If UserHasAccessToApplication(dLib, CurrentLetmeinUserID(), "LibraryAdmin") Then

            LibraryAdminArea.Visible = True

        End If
        Call ViewedMessages()
        Call homePageStats()

    End Sub

    Protected Sub ibtnLogin_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ibtnLogin.Click
        If ibtnLogin.AlternateText = "Logout" Then

            NCUSecurity.SignOut()

        ElseIf ibtnLogin.AlternateText = "Login" Then

            Response.Redirect("/DrawBridge/Login.aspx")

        End If
    End Sub

    Protected Sub ViewedMessages()
        Dim dLib As New NCUDataLayer("elrc")
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

    Protected Sub homePageStats()

        If Len(CurrentLetmeinUserID()) > 0 Then

            'Dim pageID As String = Request.Url.PathAndQuery
            Dim pageID As String = Request.RawUrl
            'Dim pageID As String = "FOOBAR"

            Dim sFields() As String = {"user_id", "site_id"}
            Dim sValues() As String = {CurrentLetmeinUserID(), pageID}

            dLib.SqlInsert("stats_id_elrc", sFields, sValues)

        End If

    End Sub

End Class




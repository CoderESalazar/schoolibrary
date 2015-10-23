Imports compass
Imports compass.Security

Partial Public Class ncu_kb
    Inherits System.Web.UI.MasterPage
    Dim dl As New compass.DataLayer
    Dim dlBread As New BreadCrumb
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sQuery As String
        Dim sKeyId As String
        sQuery = Request.QueryString("lib_cat")
        sKeyId = Request.QueryString("q_id")
        Session("lib_cat") = sQuery

        If Len(sQuery) > 0 Then

            Label1.Visible = True
            BreadLinks.CssClass = "links1"
            BreadLinks.Text = "<a style=color:white href=/ncu_kb/browse.aspx?lib_cat=" & sQuery & ">" & dlBread.Bread(dl, sQuery) & "</a>"

        ElseIf Len(sKeyId) > 0 Then

            Label1.Visible = True
            BreadLinks.CssClass = "links1"
            BreadLinks.Text = "<a style=color:white href=/ncu_kb/browse.aspx?lib_cat=" & dlBread.CatId(dl, sKeyId) & ">" & dlBread.BreadQId(dl, sKeyId) & "</a>"

        End If

        Dim sDomain = Request.ServerVariables("SERVER_NAME")

        Select Case sDomain

            Case "ed-library.ncu.edu"

                LearnerPortal.NavigateUrl = "https://ed-learners.ncu.edu/"
                MentorsPortal.NavigateUrl = "https://ed-mentors.ncu.edu/"
                StaffPortal.NavigateUrl = "https://ed-admin.ncu.edu/"

            Case "beta-library.ncu.edu"

                LearnerPortal.NavigateUrl = "https://beta-learners.ncu.edu/"
                MentorsPortal.NavigateUrl = "https://beta-mentors.ncu.edu/"
                StaffPortal.NavigateUrl = "https://beta-admin.ncu.edu/"


            Case "library.ncu.edu"

                LearnerPortal.NavigateUrl = "https://learners.ncu.edu/"
                MentorsPortal.NavigateUrl = "https://mentors.ncu.edu/"
                StaffPortal.NavigateUrl = "https://admin.ncu.edu/"

        End Select

        Call UserName()

    End Sub

    Public Sub UserName()

        dl.setDBName("ncu")
        Dim strId = CurrentLetmeinUserID()

        If Len(CurrentLetmeinUserID()) > 0 Then

            Dim dtL As DataTable = dl.SqlSelect("Select first_name, last_name from learner_info where learner_id = '" & strId & "'")

            If dtL.Rows.Count = 0 Then

                Dim dtM As DataTable = dl.SqlSelect("Select first_name, last_name from mentor_info where mentor_id = '" & strId & "'")

                If dtM.Rows.Count = 0 Then

                    Dim dtS As DataTable = dl.SqlSelect("Select first_name, last_name from staff_info where staff_id = '" & strId & "'")

                    If dtS.Rows.Count = 0 Then

                        user_name.Text = "Not Logged In"

                    Else

                        Dim drS As DataRow = dtS.Rows(0)

                        user_name.Text = drS("first_name") & " " & drS("last_name")

                    End If

                Else

                    Dim drM As DataRow = dtM.Rows(0)

                    user_name.Text = drM("first_name") & " " & drM("last_name")

                End If

            Else

                Dim drL As DataRow = dtL.Rows(0)

                user_name.Text = drL("first_name") & " " & drL("last_name")

            End If


        Else

            user_name.Text = "Not Logged In"

        End If


    End Sub

End Class
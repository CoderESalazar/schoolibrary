Imports compass
Imports compass.Security

Partial Class research_help_guides
    Inherits System.Web.UI.UserControl

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim sDomain = Request.ServerVariables("SERVER_NAME")
        LibCrumbs.Text = "<a class=LibCrumbs href=/default.aspx />Library</a> > <a class=LibCrumbs href=/research_help/default.aspx />Library Guides</a>"
        user_name.Text = LibraryFunctions.UserName(CurrentLetmeinUserID())
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

        dl.setDBName("elrc")
  

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

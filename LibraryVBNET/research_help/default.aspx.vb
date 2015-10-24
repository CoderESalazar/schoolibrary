Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class default1
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")
    'Dim dlNcu As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'Bread.NavigateUrl = "/library"
            UnSecureThisPage()
            Dim mainNav As UserControls_wucNavBar = Master.NavBar

            mainNav.BuildLibraryMenu()

            Dim sSubDomain = LCase(Split(Request.ServerVariables("SERVER_NAME"), ".")(0))


            'dl.SqlExecute("Insert into stats_id_course_guides (user_id, site_id) Values ('" & CurrentLetmeinUserID() & "','" & sSubDomain & "')")

            dl.SqlSelect("SELECT guide_title, department_discipline_id, department_guide_main_id, display_id FROM concspec_list_v WHERE display_id = 'True' ORDER BY guide_title")

            Dim dt As DataTable = dl._DT
            Dim newItem As ListItem
            'SpecialDrop.Items.Insert(0, New ListItem("Please Select", ""))

            SpecialDrop.Items.Insert(0, New ListItem("Please Select", ""))
            For Each dr As DataRow In dt.Rows

                newItem = New ListItem
                newItem.Text = dr("guide_title").ToString
                newItem.Value = dr("department_guide_main_id").ToString
                SpecialDrop.Items.Add(newItem)
            Next

            dl.SqlSelect("SELECT ci.course_code, ecr.guide_id, ci.company_department_name from ncu.dbo.course_info ci INNER JOIN elrc_cr_guides ecr ON ci.course_code = ecr.course_code where ci.course_end_date is NULL and ecr.guide_id is not NULL and display_id = 1 order by ecr.course_code")
            Dim dtCourses As DataTable = dl._DT
            Dim newItemSub As ListItem

            CoursesDrop.Items.Insert(0, New ListItem("Please Select", ""))

            'Response.Write(dl.Severity & " , " & dl.Results & " , " & dl.SqlStatement)
            'Response.End()

            For Each drSub As DataRow In dtCourses.Rows

                newItemSub = New ListItem
                newItemSub.Text = drSub("course_code") & ""
                newItemSub.Value = drSub("guide_id") & ""
                CoursesDrop.Items.Add(newItemSub)

            Next

            'Response.Write(dl.Results & " , " & dl.Severity & " , " & dlNcu.SqlStatement)
            'Response.End()

        End If

    End Sub


    Protected Sub SpecButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpecButton.Click

        If SpecialDrop.SelectedValue <> "" Then

            Response.Redirect("/research_help/spec_guide.aspx?department_guide_main_id=" & SpecialDrop.SelectedValue)

        Else

            Lbl_SpecialDrop.Text = "<font color=red><strong>Please make selection.<strong></font>"

        End If

    End Sub

    Private Sub CourseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CourseButton.Click

        If CoursesDrop.SelectedValue <> "" Then

            Response.Redirect("/research_help/guide.aspx?guide_id=" & CoursesDrop.SelectedValue)

        Else

            Lbl_CoursesDrop.Text = "<font color=red><strong>Please make selection.<strong></font>"

        End If


    End Sub

End Class
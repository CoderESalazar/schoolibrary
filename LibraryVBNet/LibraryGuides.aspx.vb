Imports NCUDataLayer
Imports NCUSecurity
Partial Class LibraryGuides
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            dl.SqlSelect("SELECT guide_title, department_discipline_id, department_guide_main_id, display_id FROM concspec_list_v WHERE display_id = 'True' ORDER BY guide_title")

            Dim dt As DataTable = dl._DT
            'SpecialDrop.Items.Insert(0, New ListItem("Please Select", ""))
            SpecialDrop.Items.Insert(0, New ListItem("Please Select", ""))
            For Each dr As DataRow In dt.Rows

                Dim newItem As ListItem
                newItem = New ListItem
                newItem.Text = dr("guide_title").ToString
                newItem.Value = dr("department_guide_main_id").ToString
                SpecialDrop.Items.Add(newItem)
            Next

            'Dim dlNcu As New NCUDataLayer()

            dl.SqlSelect("SELECT ci.course_code, ecr.guide_id, ci.company_department_name from ncu.dbo.course_info ci INNER JOIN elrc_cr_guides ecr ON ci.course_code = ecr.course_code where ci.course_end_date is NULL and ecr.guide_id is not NULL and display_id = 1 order by ecr.course_code")
            Dim dtCourses As DataTable = dl._DT
            Dim newItemSub As ListItem
            CoursesDrop.Items.Insert(0, New ListItem("Please Select", ""))
            For Each drSub As DataRow In dtCourses.Rows
                newItemSub = New ListItem
                newItemSub.Text = drSub("course_code") & ""
                newItemSub.Value = drSub("guide_id") & ""
                CoursesDrop.Items.Add(newItemSub)

            Next
        End If

    End Sub


    Protected Sub SpecButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SpecButton.Click

        If SpecialDrop.SelectedValue <> "" Then

            ResponseHelper.Redirect("/research_help/spec_guide.aspx?department_guide_main_id=" & SpecialDrop.SelectedValue, "_top", "")

        Else

            lblSpecDrop.Text = "<font color=red><strong>Please make selection.<strong></font>"
            'Response.Write("<font color=darkred><strong>Please make selection.</strong></font>")

        End If

    End Sub


    Protected Sub CourseButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CourseButton.Click
        If (Page.IsValid) Then

            If CoursesDrop.SelectedValue <> "" Then

                ResponseHelper.Redirect("/research_help/guide.aspx?guide_id=" & CoursesDrop.SelectedValue, "_top", "")

            Else

                lblCourseDrop.Text = "<font color=red><strong>Please make selection.<strong></font>"

            End If

        End If


    End Sub

    Public NotInheritable Class ResponseHelper

        Private Sub New()

        End Sub

        Public Shared Sub Redirect(ByVal url As String, ByVal target As String, ByVal windowFeatures As String)

            Dim context As HttpContext = HttpContext.Current

            If ([String].IsNullOrEmpty(target) OrElse target.Equals("_self", StringComparison.OrdinalIgnoreCase)) AndAlso [String].IsNullOrEmpty(windowFeatures) Then
                context.Response.Redirect(url)

            Else

                Dim page As Page = DirectCast(context.Handler, Page)

                If page Is Nothing Then

                    Throw New InvalidOperationException("Cannot redirect to new window outside Page context.")

                End If
                url = page.ResolveClientUrl(url)
                Dim script As String
                If Not [String].IsNullOrEmpty(windowFeatures) Then
                    script = "window.open(""{0}"", ""{1}"", ""{2}"");"

                Else
                    script = "window.open(""{0}"", ""{1}"");"

                End If
                script = [String].Format(script, url, target, windowFeatures)

                ScriptManager.RegisterStartupScript(page, GetType(Page), "Redirect", script, True)

            End If

        End Sub

    End Class
End Class

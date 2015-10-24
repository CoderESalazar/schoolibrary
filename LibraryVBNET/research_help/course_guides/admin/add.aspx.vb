Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class add
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")
    'Dim dlN As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'dl.setDBName("elrc")
            'dl.SetServerEnvironment(Request.ServerVariables("SERVER_NAME"))
            dl.SqlSelect("SELECT ci.course_code, ci.course_code + ' - ' + ci.course_name as course_name, ecr.guide_id, company_department_name from ncu.dbo.course_info ci LEFT JOIN elrc_cr_guides ecr ON ci.course_code = ecr.course_code where LEN(ci.company_department_name) > 0 and ecr.guide_id is NULL and LEN(ci.course_code) > 0 ORDER BY ci.course_code")
            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR
            Dim i As Integer
            Dim newItem As ListItem

            CourseDropDown.Items.Insert(0, New ListItem("Please Select", ""))

            For i = 0 To dt.Rows.Count - 1
                dr = dt.Rows(i)
                newItem = New ListItem
                newItem.Text = dr("course_code").ToString
                newItem.Value = dr("course_name").ToString
                CourseDropDown.Items.Add(newItem)
            Next

        End If
    End Sub

    Private Sub Continue_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles [Continue].Click

        course_code.Text = CourseDropDown.SelectedItem.ToString
        course_name.Text = CourseDropDown.SelectedValue.ToString

    End Sub

    Private Sub AddLibGuide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddLibGuide.Click

        Dim sFields(4) As String
        Dim sValues(4) As String
        'Dim sTest As String
        'Dim strAdd As String

        sFields(0) = "course_code"
        sFields(1) = "guide_title"
        sFields(2) = "guide_body"
        sFields(3) = "update_datetime"
        sFields(4) = "update_by"

        sValues(0) = course_code.Text
        sValues(1) = course_name.Text
        sValues(2) = Server.HtmlDecode(guide_body.Content)
        sValues(3) = DateAndTime.Now
        sValues(4) = CurrentLetmeinUserID()

        'dl.SetServerEnvironment(Request.ServerVariables("SERVER_NAME"))
        'dl.SqlInsertEnv("elrc_cr_guides", sFields, sValues, "elrc")
        dl.SqlInsert("elrc_cr_guides", sFields, sValues)

        'Response.Write(dl.resultStatus.SqlStatement & " , " & dl.resultStatus.Message & dl.GetSrvName)
        'Response.End()
        Response.Redirect("/research_help/course_guides/admin/default.aspx")


    End Sub
End Class
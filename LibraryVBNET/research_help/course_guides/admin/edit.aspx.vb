Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class edit
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")
    'Dim dlE As New NCUDataLayer("elrc")
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim iGuideId = CInt(Trim(Request.QueryString("guide_id")))
            Dim iHeaderId = False
            'dl.setDBName("elrc")
            'Dim objRegex As New Regex("(amp)\?*")
            'Check to see if a header_id is passed thru
            If CInt(Len(Request.QueryString("header_id"))) > 0 Then

                iHeaderId = True

            End If

            'dl.SetServerEnvironment(Request.ServerVariables("SERVER_NAME"))
            Select Case iHeaderId

                Case True

                    CreatorButt.Visible = False
                    'Dim dt As DataTable = dl.SqlSelect("Select ecr.course_code, ecr.guide_id, ecr.guide_body, ci.course_code + ' - ' + ci.course_name as course_name, display_id from ncuelrc.dbo.elrc_cr_guides ecr INNER JOIN course_info ci on ecr.course_code = ci.course_code where guide_id = " & iGuideId)

                    dl.SqlSelect("Select ecr.course_code, ecr.guide_id, ecr.guide_body, ci.course_code + ' - ' + ci.course_name as course_name, display_id from elrc_cr_guides ecr INNER JOIN ncu.dbo.course_info ci on ecr.course_code = ci.course_code where guide_id = " & iGuideId)
                    Dim dt As DataTable = dl._DT
                    Dim dr As DataRow = dl._DR

                    If dt.Rows.Count > 0 Then

                        dr = dt.Rows(0)

                        'GuideTitle.Text = dr("course_name") & ""
                        'CourseCode.Text = dr("course_code") & ""

                        GuideTitle.Visible = False
                        CourseCode.Visible = False
                        createtab.Visible = False
                        AddTab2.Visible = False
                        TabDropList.Visible = False
                        AddTab.Visible = False
                        GuideTitleLabel.Visible = True
                        CourseCodeLabel.Visible = True
                        GuideTitleLabel.Text = dr("course_name") & ""
                        CourseCodeLabel.Text = dr("course_code") & ""

                        If dr("display_id") = True Then

                            DisplayCheckBox.Checked = True

                        Else

                            DisplayCheckBox.Checked = False

                        End If

                    End If


                    dl.SqlSelect("SELECT guide_title, header_body, header_title FROM elrc_cr_headers ech RIGHT JOIN elrc_cr_guides ecg ON ech.guide_id = ecg.guide_id WHERE header_id = " & Request.QueryString("header_id") & " AND ech.guide_id = " & Request.QueryString("guide_id"))


                    Dim dtSection As DataTable = dl._DT
                    Dim drSection As DataRow = dl._DR

                    Response.Write("<font color=red><strong>***You are on the " & drSection("header_title") & " tab. If you click you delete button below, you will delete the " & drSection("header_title") & " tab only.***</font></strong>")
                    drSection = dtSection.Rows(0)

                    If dtSection.Rows.Count > 0 Then

                        GuideTitle.Text = drSection("guide_title") & ""
                        Editor1.Content = drSection("header_body") & ""

                    End If

                    dl.SqlSelect("SELECT tab_name FROM elrc_cr_tabs")
                    Dim dtDropList As DataTable = dl._DT
                    Dim drDropList As DataRow = dl._DR

                    'drDropList = dtDropList.Rows(0)
                    TabDropList.Items.Insert(0, New ListItem("Please Select", ""))
                    Dim i As Integer
                    Dim newItem As ListItem

                    For i = 0 To dtDropList.Rows.Count - 1
                        drDropList = dtDropList.Rows(i)
                        newItem = New ListItem
                        newItem.Text = drDropList("tab_name")
                        newItem.Value = drDropList("tab_name")
                        TabDropList.Items.Add(newItem)
                    Next

                    Call TabFunction()

                Case Else
                    Response.Write("<font color=red><strong>***You are on the homepage of this guide. If you click delete, you will delete the entire guide.***</strong></font>")

                    dl.SqlSelect("Select ecr.course_code, ecr.guide_id, ecr.guide_body, ci.course_code + ' - ' + ci.course_name as course_name, display_id from elrc_cr_guides ecr INNER JOIN ncu.dbo.course_info ci on ecr.course_code = ci.course_code where guide_id = " & iGuideId)
                    Dim dt As DataTable = dl._DT
                    Dim dr As DataRow = dl._DR

                    If dt.Rows.Count > 0 Then

                        dr = dt.Rows(0)

                        GuideTitle.Text = dr("course_name") & ""
                        CourseCode.Text = dr("course_code") & ""
                        Editor1.Content = dr("guide_body") & ""

                        If dr("display_id") = True Then

                            DisplayCheckBox.Checked = True

                        Else

                            DisplayCheckBox.Checked = False

                        End If

                        dl.SqlSelect("SELECT tab_name, tab_id FROM elrc_cr_tabs")
                        Dim dtDropList As DataTable = dl._DT

                        Dim drDropList As DataRow = dl._DR

                        'drDropList = dtDropList.Rows(0)
                        TabDropList.Items.Insert(0, New ListItem("Please Select", ""))
                        Dim i As Integer
                        Dim newItem As ListItem

                        For i = 0 To dtDropList.Rows.Count - 1
                            drDropList = dtDropList.Rows(i)
                            newItem = New ListItem
                            newItem.Text = drDropList("tab_name")
                            newItem.Value = drDropList("tab_id")
                            TabDropList.Items.Add(newItem)
                        Next

                    End If

                    Call TabFunction()

            End Select
        End If
    End Sub

    Private Sub AddTab_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddTab.Click

        If createtab.Text <> "" Then

            Dim sFields() As String = {"tab_name"}
            Dim sValues() As String = {createtab.Text}

            dl.SqlInsert("elrc_cr_tabs", sFields, sValues)

        End If

        Response.Redirect("/research_help/course_guides/admin/edit.aspx?guide_id=" & Request.QueryString("guide_id"))


        'If TabDropList.SelectedValue <> "" Then


    End Sub

    Protected Sub TabFunction()

        Dim iGuideId = CInt(Trim(Request.QueryString("guide_id")))
        'dl.SetServerEnvironment(Request.ServerVariables("SERVER_NAME"))
        dl.SqlSelect("Select header_title, header_id, ecr.guide_id, display_order, guide_body FROM elrc_cr_guides ecr RIGHT JOIN elrc_cr_headers ech ON ecr.guide_id = ech.guide_id where ecr.guide_id = " & iGuideId & "ORDER BY display_order")

        Dim dtTabs As DataTable = dl._DT

        If dtTabs.Rows.Count > 0 Then

            TabsLabel.Visible = True
            Dim tb As New Table
            Dim tr As New TableRow
            'tb.HorizontalAlign = HorizontalAlign.Center
            tb.CssClass = "nav"
            For Each drTabs As DataRow In dtTabs.Rows

                Dim tc As New TableCell

                If drTabs("header_title") = "Home" Then

                    tc.Text = "<u><li><a href=edit.aspx?guide_id=" & drTabs("guide_id") & ">" & drTabs("header_title") & "</a></li></ul>"
                    tr.Cells.Add(tc)

                Else

                    tc.Text = "<u><li><a href=edit.aspx?guide_id=" & iGuideId & "&header_id=" & drTabs("header_id") & ">" & drTabs("header_title") & "</a></li></ul>"
                    tr.Cells.Add(tc)

                End If

            Next

            tb.Rows.Add(tr)

            Tabs.Controls.Add(tb)

        End If


    End Sub

    Private Sub deleteGuide_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteGuide.Click

        Dim iHeaderId = Trim(Request.QueryString("header_id"))
        Dim iGuideId = Trim(Request.QueryString("guide_id"))

        'dl.SetServerEnvironment(Request.ServerVariables("SERVER_NAME"))

        If Len(iHeaderId) > 0 Then

            Dim strDelete As String

            strDelete = dl.SqlDelete("elrc_cr_headers", "header_id", iHeaderId)

            Response.Write("Tab Deleted. Return to <a href=/research_help/course_guides/admin/edit.aspx?guide_id=" & iGuideId & ">Guide</a>")
            Response.End()

        Else

            Dim strDelete As String

            strDelete = dl.SqlDelete("elrc_cr_guides", "guide_id", iGuideId)
            'strDelete = dl.SqlDelete("elrc_cr_guides", "guide_id", iGuideId)

            Response.Write("Guide Deleted. Return to <a href=/research_help/course_guides/admin/default.aspx>Library Guides area.</a>")
            Response.End()


        End If


    End Sub

    Private Sub UpdateButt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButt.Click

        Dim sGuideId As String = Trim(Request.QueryString("guide_id"))

        Dim sHeaderId As Integer = 0

        If Request.QueryString("header_id") <> Nothing Then

            sHeaderId = Trim(Request.QueryString("header_id"))
            
        End If

        'dl.SetServerEnvironment(Request.ServerVariables("SERVER_NAME"))
        Dim strUpdate As String

        If sHeaderId > 0 Then

            Dim sFields() As String = {"header_body"}
            Dim sValues() As String = {Server.HtmlDecode(Editor1.Content)}

            'strUpdate = dl.SqlUpdateEnv("elrc_cr_headers", "header_id", sHeaderId, sFields, sValues, "elrc")
            strUpdate = dl.SqlUpdate("elrc_cr_headers", "header_id", sHeaderId, sFields, sValues)

            Response.Write("Guide Edited. Return to <a href=/research_help/course_guides/admin/edit.aspx?guide_id=" & sGuideId & ">Guide</a>")
            Response.End()

        Else
            Dim sFields() As String = {"guide_title", "course_code", "guide_body", "display_id", "update_datetime"}
            Dim sValues() As String = {GuideTitle.Text, CourseCode.Text, Server.HtmlDecode(Editor1.Content), DisplayCheckBox.Checked, DateAndTime.Now.ToString}

            strUpdate = dl.SqlUpdate("elrc_cr_guides", "guide_id", sGuideId, sFields, sValues)
            Response.Write("Guide Edited. Return to <a href=/research_help/course_guides/admin/edit.aspx?guide_id=" & sGuideId & ">Guide</a>")
            Response.End()
        End If

    End Sub

    Private Sub CreatorButt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CreatorButt.Click

        Dim sGuideId As String = Trim(Request.QueryString("guide_id"))
        'Dim strUpdate As String
        'dl.SetServerEnvironment(Request.ServerVariables("SERVER_NAME"))

        Dim sFields() As String = {"update_by"}
        Dim sValues() As String = {CurrentLetmeinUserID()}

        dl.SqlUpdate("elrc_cr_guides", "guide_id", sGuideId, sFields, sValues)
        'Response.Write("Creator Updated. Return to <a href=/research_help/course_guides/admin/edit.aspx?guide_id=" & sGuideId & ">Guide</a>")
        Response.Write("Creator Updated. " & dl.Results & " , " & dl.SqlStatement)
        Response.End()

    End Sub

    Protected Sub AddTab2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddTab2.Click

        If TabDropList.SelectedValue <> "" Then

            Dim sFields(2) As String
            Dim sValues(2) As String
            'Dim sTest As String
            'Dim strAdd As String

            sFields(0) = "header_title"
            sFields(1) = "guide_id"
            sFields(2) = "display_order"
            'sFields(3) = "update_datetime"

            sValues(0) = TabDropList.SelectedItem.ToString
            sValues(1) = Request.QueryString("guide_id")
            sValues(2) = TabDropList.SelectedValue.ToString
            'sValues(3) = DateAndTime.Now

            dl.SqlInsert("elrc_cr_headers", sFields, sValues)

            Response.Redirect("/research_help/course_guides/admin/edit.aspx?guide_id=" & Request.QueryString("guide_id"))

        Else

            Lbl_DropList.Text = "<font color=red><strong>Please select value.</strong></font>"

        End If


    End Sub
End Class
Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()
        'searchme.Focus()

        If Len(Request.QueryString("dept_name")) = 0 Then

            DissText.Text = "<br/>To get started, please click any of the links below to browse dissertations by program or use the search box to locate a specific title or author. Dissertations are ordered by date."

        End If

        'DissText.CssClass = "DissText"

        dl.SqlSelect("Select DISTINCT(department_name) FROM dissertation_checklist_report WHERE dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (20,22,31,34,8) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY department_name")
        Dim dtMenu As DataTable = dl._DT
        'Creating menu below
        Dim tbMenu As New Table
        tbMenu.CssClass = "tbMenu"
        Dim trMenu As New TableRow

        For Each drMenu As DataRow In dtMenu.Rows
            Dim tcMenu As New TableCell

            'tcMenu.Text = "<a class=page_links href=#" & drMenu("department_name") & ">" & drMenu("department_name") & "</a>&nbsp;&nbsp;"
            tcMenu.Text = "<a class=page_links href=/ncu_diss/default.aspx?dept_name=" & drMenu("department_name") & ">" & drMenu("department_name") & "</a>&nbsp;&nbsp;"

            trMenu.Cells.Add(tcMenu)

        Next
        tbMenu.Rows.Add(trMenu)
        PlaceHolder2.Controls.Add(tbMenu)

        'End of Menu section

        'Looping through and grabbing department names. 

        If Not Page.IsPostBack Then

            Dim sDeptName = Request.QueryString("dept_name")


            Select Case sDeptName
                '17 = DBA
                '20 = PHD BA
                '22 = PHD PSY
                '31 = EDD
                '32 = PHD ED
                '34 = PHD MFT
                '8 = Technology

                Case "Business"

                    BusLabel.Text = "<h2 class=sectionTitle>Business and Technology Management</h2>"

                    dl.SqlSelect("SELECT department_name, learner_first_name, learner_last_name, stat_date, learner_middle_name, dissertation_id, i899a_title_of_diss, UPPER(degree_program_code) as DegreeProgramCode FROM dissertation_checklist_report WHERE department_name LIKE 'Business%' AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (17,20) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY stat_date DESC")
                    Dim dt As DataTable = dl._DT

                    Dim tb As New Table

                    For Each dr As DataRow In dt.Rows


                        Dim tr As New TableRow
                        Dim tc As New TableCell
                        If dr("stat_date").ToString <> "" Then
                            tc.Text = dr("learner_last_name") & ", " & dr("learner_first_name") & "&nbsp;" & dr("learner_middle_name") & ", " & dr("DegreeProgramCode") & " - " & MonthName(Month(dr("stat_date"))) & ", " & Year(dr("stat_date"))

                        End If

                        tr.Cells.Add(tc)
                        tb.Rows.Add(tr)

                        Dim trSub As New TableRow
                        Dim tcSub As New TableCell

                        tcSub.Text = "<a class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                        trSub.Cells.Add(tcSub)
                        tb.Rows.Add(trSub)
                    Next

                    PlaceHolder1.Controls.Add(tb)
                Case "Education"

                    EdLabel.Text = "<h2 class=sectionTitle>Education</h2>"


                    dl.SqlSelect("SELECT department_name, learner_first_name, learner_last_name, stat_date, learner_middle_name, dissertation_id, i899a_title_of_diss, UPPER(degree_program_code) as DegreeProgramCode FROM dissertation_checklist_report WHERE department_name = 'Education' AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (31,32) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY stat_date DESC")
                    Dim dt As DataTable = dl._DT

                    Dim tb As New Table

                    For Each dr As DataRow In dt.Rows

                        Dim tr As New TableRow
                        Dim tc As New TableCell
                        If dr("stat_date").ToString <> "" Then
                            tc.Text = dr("learner_last_name") & ", " & dr("learner_first_name") & "&nbsp;" & dr("learner_middle_name") & ", " & dr("DegreeProgramCode") & " - " & MonthName(Month(dr("stat_date"))) & ", " & Year(dr("stat_date"))

                        End If

                        tr.Cells.Add(tc)
                        tb.Rows.Add(tr)

                        Dim trSub As New TableRow
                        Dim tcSub As New TableCell

                        tcSub.Text = "<a class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                        trSub.Cells.Add(tcSub)
                        tb.Rows.Add(trSub)

                    Next

                    PlaceHolder1.Controls.Add(tb)

                Case "Psychology"

                    PsyLabel.Text = "<h2 class=sectionTitle>Psychology</h2>"


                    dl.SqlSelect("SELECT department_name, learner_first_name, learner_last_name, stat_date, learner_middle_name, dissertation_id, i899a_title_of_diss, UPPER(degree_program_code) as DegreeProgramCode FROM dissertation_checklist_report WHERE department_name LIKE 'Psychology' AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (22) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY stat_date DESC")
                    Dim dt As DataTable = dl._DT

                    Dim tb As New Table

                    For Each dr As DataRow In dt.Rows

                        Dim tr As New TableRow
                        Dim tc As New TableCell
                        If dr("stat_date").ToString <> "" Then
                            tc.Text = dr("learner_last_name") & ", " & dr("learner_first_name") & "&nbsp;" & dr("learner_middle_name") & ", " & dr("DegreeProgramCode") & " - " & MonthName(Month(dr("stat_date"))) & ", " & Year(dr("stat_date"))

                        End If

                        tr.Cells.Add(tc)
                        tb.Rows.Add(tr)

                        Dim trSub As New TableRow
                        Dim tcSub As New TableCell

                        tcSub.Text = "<a class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                        trSub.Cells.Add(tcSub)
                        tb.Rows.Add(trSub)

                    Next

                    PlaceHolder1.Controls.Add(tb)

                Case "Marriage"

                    PsyLabel.Text = "<h2 class=sectionTitle>Marriage and Family Sciences</h2>"

                    dl.SqlSelect("SELECT department_name, learner_first_name, learner_last_name, stat_date,learner_middle_name, dissertation_id, i899a_title_of_diss, UPPER(degree_program_code) as DegreeProgramCode FROM dissertation_checklist_report WHERE department_name = 'Marriage and Family Sciences' AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (34) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY stat_date DESC")
                    Dim dt As DataTable = dl._DT

                    Dim tb As New Table
                    For Each dr As DataRow In dt.Rows

                        Dim tr As New TableRow
                        Dim tc As New TableCell
                        If dr("stat_date").ToString <> "" Then
                            tc.Text = dr("learner_last_name") & ", " & dr("learner_first_name") & "&nbsp;" & dr("learner_middle_name") & ", " & dr("DegreeProgramCode") & " - " & MonthName(Month(dr("stat_date"))) & ", " & Year(dr("stat_date"))

                        End If

                        tr.Cells.Add(tc)
                        tb.Rows.Add(tr)

                        Dim trSub As New TableRow
                        Dim tcSub As New TableCell

                        tcSub.Text = "<a class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                        trSub.Cells.Add(tcSub)
                        tb.Rows.Add(trSub)
                    Next

                    PlaceHolder1.Controls.Add(tb)

                Case "Technology"

                    PsyLabel.Text = "<h2 class=sectionTitle>Technology</h2>"

                    dl.SqlSelect("SELECT department_name, learner_first_name, learner_last_name, stat_date,learner_middle_name, dissertation_id, i899a_title_of_diss, UPPER(degree_program_code) as DegreeProgramCode FROM dissertation_checklist_report WHERE department_name = 'Technology' AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (8) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY stat_date DESC")
                    Dim dt As DataTable = dl._DT

                    Dim tb As New Table
                    For Each dr As DataRow In dt.Rows

                        Dim tr As New TableRow
                        Dim tc As New TableCell
                        If dr("stat_date").ToString <> "" Then
                            tc.Text = dr("learner_last_name") & ", " & dr("learner_first_name") & "&nbsp;" & dr("learner_middle_name") & ", " & dr("DegreeProgramCode") & " - " & MonthName(Month(dr("stat_date"))) & ", " & Year(dr("stat_date"))

                        End If

                        tr.Cells.Add(tc)
                        tb.Rows.Add(tr)

                        Dim trSub As New TableRow
                        Dim tcSub As New TableCell

                        tcSub.Text = "<a class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                        trSub.Cells.Add(tcSub)
                        tb.Rows.Add(trSub)
                    Next

                    PlaceHolder1.Controls.Add(tb)
            End Select


        End If

    End Sub

    Private Sub SearchButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click

        Dim search_stuff As String
        Dim dropListStuff As String

        search_stuff = searchme.Text
        dropListStuff = SearchSelectDrop.SelectedValue

        Session("search") = search_stuff
        Session("search_drop") = dropListStuff

        If Session("search") <> "" Then

            Response.Redirect("search.aspx")

        Else

            Response.Redirect("/ncu_diss/default.aspx")

        End If


    End Sub

End Class
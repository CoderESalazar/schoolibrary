Imports NCUSecurity
Imports NCUDataLayer

Partial Public Class search
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Dim dt As DataTable

        'Response.Write(Session("search_drop") & " " & Session("search"))

        If Not Page.IsPostBack Then

            If Len(Session("search_drop")) And Len(Session("search")) > 0 Then

                Select Session("search_drop")
                    Case "Title"

                        dl.SqlSelect("SELECT department_name,learner_first_name,learner_last_name,stat_date,learner_middle_name,dissertation_id,i899a_title_of_diss FROM dissertation_checklist_report WHERE i899a_title_of_diss LIKE '%" & (Session("search")) & "%' AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (8,17,20,22,23,31,32,34) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY department_name, learner_last_name")
                        Dim dt As DataTable = dl._DT

                        Dim tb As New Table

                        If dt.Rows.Count > 0 Then

                            For Each dr As DataRow In dt.Rows

                                Dim tr As New TableRow
                                Dim tc As New TableCell
                                If dr("stat_date").ToString <> "" Then
                                    tc.Text = dr("learner_last_name") & " , " & dr("learner_first_name") & "&nbsp;" & dr("learner_middle_name") & " - " & MonthName(Month(dr("stat_date"))) & " , " & Year(dr("stat_date"))

                                End If

                                tr.Cells.Add(tc)
                                tb.Rows.Add(tr)

                                Dim trSub As New TableRow
                                Dim tcSub As New TableCell

                                tcSub.Text = "<a target=_blank class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                                trSub.Cells.Add(tcSub)
                                tb.Rows.Add(trSub)

                            Next

                            PlaceHolder1.Controls.Add(tb)
                        Else

                            Response.Write("Sorry, no results found. Please try your search again or check spelling.")
                            '    Response.End()

                        End If
                    Case "Author"

                        Dim sSearcString = Replace(Session("search"), ",", "")

                        Dim sArray As String() = Nothing
                        sArray = sSearcString.Split(" ")
                        Dim the_word As String

                        For Each the_word In sArray
                            Dim oneName = sArray(0)
                            Session("UseThis") = oneName

                        Next

                        dl.SqlSelect("SELECT (learner_last_name + ', ' + learner_first_name) as Author,learner_middle_name,department_name,stat_date,dissertation_id,i899a_title_of_diss FROM dissertation_checklist_report WHERE (learner_first_name + ' ' + learner_last_name  Like '%" & Session("UseThis") & "%' OR learner_last_name + ' ' + learner_first_name Like '%" & Session("UseThis") & "%') AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (8,17,20,22,23,31,32,34) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY department_name, learner_last_name")
                        Dim dt As DataTable = dl._DT


                        Dim tb As New Table
                        If dt.Rows.Count > 0 Then

                            For Each dr As DataRow In dt.Rows

                                Dim tr As New TableRow
                                Dim tc As New TableCell
                                If dr("stat_date").ToString <> "" Then
                                    tc.Text = dr("Author") & "&nbsp;" & dr("learner_middle_name") & " - " & MonthName(Month(dr("stat_date"))) & " , " & Year(dr("stat_date"))

                                End If

                                tr.Cells.Add(tc)
                                tb.Rows.Add(tr)

                                Dim trSub As New TableRow
                                Dim tcSub As New TableCell

                                tcSub.Text = "<a target=_blank class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                                trSub.Cells.Add(tcSub)
                                tb.Rows.Add(trSub)

                            Next

                            PlaceHolder1.Controls.Add(tb)
                        Else

                            Response.Write("Sorry, no results found. Please try your search again or check spelling.")
                            Response.End()

                        End If



                    Case "Abstract"

                        dl.SqlSelect("SELECT department_name,learner_first_name,dissertation_abstract,learner_last_name,stat_date,learner_middle_name,dissertation_id,i899a_title_of_diss FROM dissertation_checklist_report WHERE dissertation_abstract LIKE '%" & (Session("search")) & "%' AND dissertation_abstract_display = 1 AND dissertation_abstract <> '' AND degree_program_id IN (8,17,20,22,23,31,32,34) AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY department_name, learner_last_name")
                        Dim dt As DataTable = dl._DT

                        Dim tb As New Table
                        If dt.Rows.Count > 0 Then
                            For Each dr As DataRow In dt.Rows

                                Dim tr As New TableRow
                                Dim tc As New TableCell
                                If dr("stat_date").ToString <> "" Then
                                    tc.Text = dr("learner_last_name") & " , " & dr("learner_first_name") & "&nbsp;" & dr("learner_middle_name") & " - " & MonthName(Month(dr("stat_date"))) & " , " & Year(dr("stat_date"))

                                End If

                                tr.Cells.Add(tc)
                                tb.Rows.Add(tr)

                                Dim trSub As New TableRow
                                Dim tcSub As New TableCell

                                tcSub.Text = "<a target=_blank class=page_links href=display_abstract.aspx?dissertation_id=" & dr("dissertation_id") & ">" & dr("i899a_title_of_diss") & "</a><br/><br/>"

                                trSub.Cells.Add(tcSub)
                                tb.Rows.Add(trSub)

                            Next

                            PlaceHolder1.Controls.Add(tb)
                        Else

                            Response.Write("Sorry, no results found. Please try your search again or check spelling.")
                            Response.End()

                        End If


                End Select

            Else

                Response.Write("Please enter something into the search box")
                Response.End()

            End If

        End If


    End Sub

   


End Class
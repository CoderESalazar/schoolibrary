Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class user_area1
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try

            'Response.Write(dl.ServerName & " " & dl.DatabaseName)
            UnSecureThisPage()
            Dim mainNav As UserControls_wucNavBar = Master.NavBar

            mainNav.BuildLibraryMenu()
            Dim bPublic = False
            If Len(Trim(CurrentLetmeinUserID())) = 0 Then bPublic = True
            If bPublic = True Then

                Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
                ValidationCheck("UnivPeople", iDomain)

            Else

                'Counting learner submissions to Ask a Librarian. If no questions then we need to let the learner know about it. 
                Dim dlElrc As New NCUDataLayer("elrc")

                dlElrc.SqlSelect("Select count(u_last_name) As the_count from quest_tb WHERE q_status is not NULL AND q_type IS NULL AND q_status LIKE '%Submitted to KB%' AND user_id = '" & CurrentLetmeinUserID() & "'")
                Dim dtRefCount As DataTable = dlElrc._DT

                If dtRefCount.Rows.Count > 0 Then

                    'Retrieving variables to be used

                    dlElrc.SqlSelect("Select qt.q_id, qt.u_first_name, qt.u_last_name, user_id, qt.date_time, q_detail, ql.lib_response, ql.viewed_mess " & _
                        "from quest_tb qt INNER JOIN quest_lib ql ON qt.q_id = ql.q_id where qt.q_type IS NULL AND qt.user_id = '" & CurrentLetmeinUserID() & "'" & _
                            " AND ql.q_status LIKE '%Submitted to KB%' ORDER BY qt.date_time DESC")

                    'Response.Write(dlElrc.Severity & " , " & dlElrc.SqlStatement & " , " & dlElrc.DatabaseName & " , " & dlElrc.ServerName & " , " & dlElrc.Results)

                    Dim dtLearner As DataTable = dlElrc._DT

                    If dtLearner.Rows.Count > 0 Then

                        Dim drLearner = dtLearner.Rows(0)

                        Dim tb As New Table
                        Dim tr As New TableRow
                        Dim tc As New TableCell
                        'Dim tcNext As New TableCell
                        tc.Text = "Hello, " & drLearner("u_first_name") & " " & drLearner("u_last_name") & ". This is your My e-Reference area where all your reference questions are answered and made available. To view the Librarian's response to your Ask a Librarian question(s), click on the View Response link below."
                        'tcNext.Text = "Need help with an assignment or course? Check out available Library Guide(s): " & dlBread.LibGuides(dl, CurrentLetmeinUserID())

                        tr.Cells.Add(tc)
                        'tr.Cells.Add(tcNext)

                        tb.Rows.Add(tr)

                        PlaceHolder1.Controls.Add(tb)

                        Dim tbRef As New Table
                        Dim objRegex As New Regex("<(.|\n)+?'>")
                        'Dim lQuestion As String = drLearner("q_detail").Remove("""", String.Empty)
                        'For Each drRefQuest As DataRow In dtLearner.Rows

                        For Each drLearner In dtLearner.Rows

                            Dim trRef As New TableRow
                            Dim tcRef As New TableCell
                            Dim tcRef1 As New TableCell

                            If drLearner("viewed_mess") = "False" Then
                                tcRef1.Text = "<a style=color:darkblue;font-weight:bold; href=/ncu_kb/user/view.aspx?q_id=" & drLearner("q_id") & ">View Response</a> Date Question Submitted:" & drLearner("date_time") & " Arizona Time."
                            Else
                                tcRef1.Text = "<a style=color:#445577 href=/ncu_kb/user/view.aspx?q_id=" & drLearner("q_id") & ">View Response</a> Date Question Submitted:" & drLearner("date_time") & " Arizona Time."
                            End If

                            tcRef.Text = "&nbsp"

                            trRef.Cells.Add(tcRef1)
                            trRef.Cells.Add(tcRef)
                            tbRef.Rows.Add(trRef)

                            Dim trRef1 As New TableRow
                            Dim tcRef2 As New TableCell
                            Dim tcRef3 As New TableCell
                            'trRef1.CssClass = "test"

                            'This bit of code appears to be throwing an error. 
                            'tcRef2.Text = "Question Detail: " & objRegex.Replace(Mid(lQuestion & "", 1, 80), "").ToString & "..."
                            tcRef2.Text = "Question Detail: " & objRegex.Replace(Mid(drLearner("q_detail") & "", 1, 80), "").ToString & "..."
                            tcRef3.Text = "&nbsp"

                            trRef1.Cells.Add(tcRef2)
                            trRef1.Cells.Add(tcRef3)
                            tbRef.Rows.Add(trRef1)


                            Dim trRef2 As New TableRow
                            Dim tcRef4 As New TableCell
                            Dim tcRef5 As New TableCell

                            tcRef4.Text = "&nbsp"
                            tcRef5.Text = "&nbsp"

                            trRef2.Cells.Add(tcRef4)
                            trRef2.Cells.Add(tcRef5)
                            tbRef.Rows.Add(trRef2)


                        Next
                        PlaceHolder2.Controls.Add(tbRef)

                        LibGuides.Text = "Need help with a course or specific assignment? Then see the Library Guides: " & LibraryFunctions.LibGuides(CurrentLetmeinUserID())
                    Else

                        NoQs.Text = "Welcome to your My e-Reference Area, the place where all your reference questions are answered. Sorry, no reference question(s) have been submitted or they are being answered. If you need assistance with any of the Library resources and services, please contact us by clicking <a style=font-family: Verdana; color: #445577; href=/ncu_kb/user/user_page.aspx>Ask a Librarian</a>."

                        'Response.End()


                    End If

                End If

            End If

        Catch ex As Exception


        End Try
    End Sub





End Class
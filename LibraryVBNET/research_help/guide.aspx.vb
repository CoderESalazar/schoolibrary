Imports NCUDataLayer
Imports NCUSecurity
Imports BreadCrumb

Partial Public Class guide
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dLib As New BreadCrumb
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        'If Request.QueryString("strid") <> "" Then

        'Dim strUserName As String = Request.QueryString("strid")
        'Dim strServName As String = Request.ServerVariables("server_name")

        'DropCookie(strUserName, strServName)
        'End If

        Dim bPublic = False
        If Len(Trim(CurrentLetmeinUserID())) = 0 Then bPublic = True

        If bPublic = True Then
            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            ValidationCheck("UnivPeople", iDomain)

        Else
            Dim iGuideId = Request.QueryString("guide_id")

            LibGuideString.Text = dLib.LibGuideLinks(iGuideId)
            If iGuideId = "" Then
                Response.Redirect("/research_help/default.aspx")
            End If

            Dim iHeaderId = False

            If CInt(Len(Request.QueryString("header_id"))) > 0 Then

                iHeaderId = True

            End If

            Select Case iHeaderId


                Case True
                    'This displays the tabs 

                    dl.SqlSelect("Select header_title, header_id, ech.guide_id, display_order, guide_body FROM elrc_cr_headers ech RIGHT JOIN elrc_cr_guides ecr ON ecr.guide_id = ech.guide_id where ech.guide_id = " & iGuideId & "ORDER BY display_order")
                    Dim dtHeaderTitle As DataTable = dl._DT

                    If dtHeaderTitle.Rows.Count > 0 Then
                        Dim tb As New Table
                        'tb.HorizontalAlign = HorizontalAlign.Center
                        tb.CellPadding = 5
                        Dim tr As New TableRow
                        For Each drHeader As DataRow In dtHeaderTitle.Rows

                            Dim tc As New TableCell
                            tc.CssClass = "color"

                            If drHeader("header_title") = "Home" Then
                                'tc.Text = "<a class=" & drHeader("header_title") & " href=guide.aspx?guide_id=" & drHeader("guide_id") & ">" & drHeader("header_title") & "</a>"
                                tc.Text = "<a class=tabs href=guide.aspx?guide_id=" & drHeader("guide_id") & ">" & drHeader("header_title") & "</a>"
                                tr.Cells.Add(tc)

                            Else
                                tc.Text = "<a class=tabs href=guide.aspx?header_id=" & drHeader("header_id") & "&guide_id=" & drHeader("guide_id") & ">" & drHeader("header_title") & "</a>"
                                tr.Cells.Add(tc)

                            End If


                        Next
                        tb.Rows.Add(tr)
                        tabs.Controls.Add(tb)

                    End If
                    'Body gets produced here. 
                    dl.SqlSelect("SELECT guide_title, header_body FROM elrc_cr_headers ech RIGHT JOIN elrc_cr_guides ecg ON ech.guide_id = ecg.guide_id WHERE header_id = " & Request.QueryString("header_id") & " AND ech.guide_id = " & Request.QueryString("guide_id"))

                    Dim dtSection As DataTable = dl._DT

                    Dim drSection As DataRow

                    drSection = dtSection.Rows(0)

                    If dtSection.Rows.Count > 0 Then
                        GuideTitle.Text = drSection("guide_title") & ""
                        GuideBody.Text = drSection("header_body") & ""

                    End If


                Case Else

                    Dim dtGuideTitle As DataTable
                    Dim drTitle As DataRow
                    Dim drBody As DataRow

                    dl.SqlSelect("SELECT guide_id, guide_title, guide_body, update_datetime FROM elrc_cr_guides WHERE guide_id = " & Request.QueryString("guide_id"))

                    dtGuideTitle = dl._DT

                    If dtGuideTitle.Rows.Count > 0 Then

                        drTitle = dtGuideTitle.Rows(0)
                        drBody = dtGuideTitle.Rows(0)
                        GuideTitle.Text = drTitle("guide_title") & ""
                        GuideBody.Text = drBody("guide_body") & ""

                    End If

                    'Display Tabs 

                    dl.SqlSelect("Select header_title, header_id, ech.guide_id, display_order, guide_body FROM elrc_cr_headers ech RIGHT JOIN elrc_cr_guides ecr ON ecr.guide_id = ech.guide_id where ech.guide_id = " & iGuideId & "ORDER BY display_order")
                    Dim dtHeaderTitle As DataTable = dl._DT

                    If dtHeaderTitle.Rows.Count > 0 Then
                        Dim tb As New Table
                        'tb.CellPadding = 10

                        Dim tr As New TableRow
                        For Each drHeader As DataRow In dtHeaderTitle.Rows

                            Dim tc As New TableCell
                            tc.CssClass = "color"
                            If drHeader("header_title") = "Home" Then
                                'tc.Text = "<a class=" & drHeader("header_title") & " href=guide.aspx?guide_id=" & drHeader("guide_id") & ">" & drHeader("header_title") & "</a>"
                                tc.Text = "<a class=tabs href=guide.aspx?guide_id=" & drHeader("guide_id") & ">" & drHeader("header_title") & "</a>"

                                tr.Cells.Add(tc)

                            Else
                                'tc.Text = "<a class=" & drHeader("header_title") & " href=guide.aspx?header_id=" & drHeader("header_id") & "&guide_id=" & drHeader("guide_id") & ">" & drHeader("header_title") & "</a>"
                                tc.Text = "<a class=tabs href=guide.aspx?header_id=" & drHeader("header_id") & "&guide_id=" & drHeader("guide_id") & ">" & drHeader("header_title") & "</a>"

                                tr.Cells.Add(tc)

                            End If
                        Next
                        tb.Rows.Add(tr)
                        tabs.Controls.Add(tb)

                    End If
            End Select

            Call GuideStat()

        End If

    End Sub

    Protected Sub GuideStat()

        Dim sHeaderID = Len(Request.QueryString("header_id"))

        If sHeaderID = 0 Then

            Dim sGuideId = Request.QueryString("guide_id")

            Dim sFields() As String = {"user_id", "guide_id"}
            Dim sValues() As String = {CurrentLetmeinUserID(), sGuideId}

            dl.SqlInsert("stats_id_course_guides", sFields, sValues)

        End If


    End Sub

End Class
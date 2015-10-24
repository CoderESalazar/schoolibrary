Imports NCUDataLayer
Imports NCUSecurity

Partial Class research_help_spec_guide
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        Dim iParentId = Request.QueryString("department_guide_main_id")

        If Len(iParentId) = 0 Then

            Response.Write("Please return to previous page and select guide.")
            Response.End()

        End If

        SpecLinks.Text = "<a href=/>Library Home</a> > <a href=/research_help/default.aspx>Library Guides</a>"

        dl.SqlSelect("SELECT guide_title FROM concspec_list_v WHERE department_guide_main_id=" & iParentId)
        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dt.Rows(0)

        title_page.Text = dr("guide_title") & ""

        'LibraryFunctions.UserName(CurrentLetmeinUserID())

        dl.SqlSelect("SELECT guide_header_info_id, head_title, department_discipline_id, display_order FROM guide_headers_info WHERE department_discipline_id = " & iParentId & " ORDER BY display_order")

        Dim dtHead As DataTable = dl._DT

        If iParentId = "" Then
            Response.Write("Please return and make selection.")
            Response.End()
        End If

        Dim tb As New Table

        For Each drHead As DataRow In dtHead.Rows
            Dim tr As New TableRow
            Dim tc As New TableCell
            tc.CssClass = "tdImageHeader1"

            tc.Text = "<div class=sections >" & drHead("head_title") & "" & "</div><br/>"

            tr.Cells.Add(tc)
            tb.Rows.Add(tr)

            dl.SqlSelect("SELECT guide_resource_id, guide_header_info_id, resource_title, url_resource, desc_resource, display_order FROM guide_resources WHERE guide_header_info_id = " & drHead("guide_header_info_id") & " ORDER BY display_order")

            Dim dtLinks As DataTable = dl._DT

            For Each drLinks As DataRow In dtLinks.Rows

                Dim trSub As New TableRow
                Dim tcSub As New TableCell

                tcSub.CssClass = "text"
                If drLinks("desc_resource") = "" Then
                    tcSub.Text = "<a class=links target=_blank href=" & drLinks("url_resource") & ">" & drLinks("resource_title") & "</a><br/>"

                Else

                    tcSub.Text = "<div class=link_desc><a class=links target=_blank href=" & drLinks("url_resource") & ">" & drLinks("resource_title") & "</a> - " & drLinks("desc_resource") & "</div><br/>"

                End If
                trSub.Cells.Add(tcSub)
                tb.Rows.Add(trSub)

            Next


        Next

        Spec_Guide.Controls.Add(tb)


    End Sub

   
End Class

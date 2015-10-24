Imports NCUDataLayer
Imports NCUSecurity
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports System
Imports System.Drawing
Imports System.Net
Imports System.Web.UI
Imports System.IO
Imports System.Data
Imports System.Web.UI.CssStyleCollection


Partial Class wl
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UnSecureThisPage()

        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        Try
            Dim iKeyId As String
            Dim LinkData As String

            iKeyId = Trim(Request.QueryString("parent_id"))

            bread_label.Text = LibraryFunctions.BreadCrumb(iKeyId)
            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")

            If iKeyId = 152 Then

                'ValidationCheck("UnivPeople", iDomain)
                Label2.Text = "*To view Flash movies you will need to download <a target=_blank href=http://www.adobe.com/shockwave/download/download.cgi?P1_Prod_Version=ShockwaveFlash />Adobe Flash Player</a>"

            End If

            dl.SqlSelect("Select title_name, link_data, public_view FROM elrc_structure WHERE high_id = " & iKeyId)
            Dim dtWlTitle As DataTable = dl._DT

            Dim drTitle As DataRow
            drTitle = dtWlTitle.Rows(0)

            wl_title.Text = drTitle("title_name")

            LinkData = drTitle("link_data")

            'Menu System

            dl.SqlSelect("Select COUNT(cat_id) as the_count FROM elrc_wl_cat WHERE parent_id = " & LinkData)
            Dim dtMenuCount As DataTable = dl._DT
            Dim drMenuCount As DataRow

            drMenuCount = dtMenuCount.Rows(0)
            Dim sCount = drMenuCount("the_count")


            dl.SqlSelect("Select cat_id, key_id FROM elrc_wl_cat WHERE parent_id = " & LinkData & " ORDER by order_id")
            Dim dtMenu As DataTable = dl._DT

            For Each drMenu As DataRow In dtMenu.Rows
                Dim sMenuLinks As New HyperLink
                Dim iRow As Integer

                iRow = iRow + 1

                If iRow < sCount Then

                    sMenuLinks.Text = "<a class=links3 href=#" & drMenu("cat_id") & ">" & drMenu("cat_id") & "</a> | "

                Else

                    sMenuLinks.Text = "<a class=links3 href=#" & drMenu("cat_id") & ">" & drMenu("cat_id") & "</a> "

                End If


                MenuItems.Controls.Add(sMenuLinks)

            Next

            dl.SqlSelect("Select cat_id, key_id FROM elrc_wl_cat WHERE parent_id = " & LinkData & " ORDER by order_id")
            Dim dtWlCategories As DataTable = dl._DT


            If dtWlCategories.Rows.Count > 0 Then

                For iCats As Integer = 0 To dtWlCategories.Rows.Count - 1

                    Dim drCat As DataRow = dtWlCategories.Rows(iCats)
                    'Lets add a link

                    Dim aLink As New HyperLink


                    Dim dtTableCat As New Table

                    'dtTableCat.Width = 100%
                    dtTableCat.CssClass = "dtTableCat"

                    Dim trTableTr As New TableRow
                    Dim trTableTrSub As New TableRow
                    Dim tc As New TableCell
                    Dim tcSub1 As New TableCell

                    tc.VerticalAlign = VerticalAlign.Top
                    tc.CssClass = "wl_background"
                    tc.Text = "<strong><div id=" & drCat("cat_id") & ">" & drCat("cat_id") & "</div></strong>"
                    trTableTr.Cells.Add(tc)
                    dtTableCat.Rows.Add(trTableTr)


                    'Grabbing Links

                    dl.SqlSelect("Select title_id, url_id, desc_id, key_id From elrc_wl_detail Where parent_id = " & drCat("key_id") & " ORDER BY display_order, title_id ASC")
                    Dim dtWlLinks As DataTable = dl._DT

                    For Each drWlLinks As DataRow In dtWlLinks.Rows

                        Dim trTbLinksRows As New TableRow
                        Dim tcSub As New TableCell
                        tcSub.CssClass = Color.AliceBlue.ToString
                        tcSub.CssClass = "link_desc"
                        'If Len(CurrentLetmeinUserID()) = 0 And drWlLinks("protect_from_public") = 0 Then

                        If drWlLinks("desc_id").ToString = "" Then

                            tcSub.Text = "<a class=links target=_blank href=" & drWlLinks("url_id") & ">" & drWlLinks("title_id") & "</a><br/>"

                        Else

                            tcSub.Text = "<div class=links_desc><a class=links target=_blank href=" & drWlLinks("url_id") & ">" & drWlLinks("title_id") & "</a>" & " - " & drWlLinks("desc_id") & "</div>"

                        End If

                        trTbLinksRows.Cells.Add(tcSub)
                        dtTableCat.Rows.Add(trTbLinksRows)
                        trTbLinksRows.Cells.Add(tcSub)
                        dtTableCat.Rows.Add(trTbLinksRows)

                    Next
                    tcSub1.Width = 800%
                    'tcSub1.BorderWidth = 10
                    tcSub1.HorizontalAlign = HorizontalAlign.Right
                    tcSub1.Text = "<a href=#top>Top</a>"
                    trTableTrSub.Cells.Add(tcSub1)
                    dtTableCat.Rows.Add(trTableTrSub)
                    PlaceHolder1.Controls.Add(dtTableCat)



                Next

            End If
        Catch

            Response.Redirect("http://library.ncu.edu/wl_template.aspx?parent_id=" & Request.QueryString("parent_id"))

        End Try

    End Sub

End Class
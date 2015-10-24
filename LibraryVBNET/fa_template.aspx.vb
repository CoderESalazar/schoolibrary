Imports NCUDataLayer
Imports NCUSecurity

Partial Class fa
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar
        mainNav.BuildLibraryMenu()
        Dim iParentId As String
        iParentId = Request.QueryString("parent_id")
        bread_label.Text = LibraryFunctions.BreadCrumb(iParentId)
        dl.SqlSelect("Select * from elrc_structure where high_id = " & iParentId)
        Dim dtTitle As DataTable = dl._DT
        Dim drTitle As DataRow
        drTitle = dtTitle.Rows(0)

        fa_title.Text = drTitle("title_name")
        dl.SqlSelect("SELECT prog_title, dbTitle, dbDesc, dbUrl From find_article_prog fap INNER JOIN find_article fa ON fap.prog_num = fa.dbProg Where parent_id = " & iParentId & " ORDER BY fa.dbTitle")
        Dim dt As DataTable = dl._DT

        Dim tbFaPage As New Table
        For Each dr As DataRow In dt.Rows

            Dim trFaPage As New TableRow
            Dim tcFaPage As New TableCell

            tcFaPage.Text = "<a class=links2 target=_blank href=" & dr("dbUrl") & ">" & dr("dbTitle") & "</a>" & " - " & dr("dbDesc") & "<br/><br/>"

            trFaPage.Cells.Add(tcFaPage)
            tbFaPage.Rows.Add(trFaPage)
        Next

        PlaceHolder1.Controls.Add(tbFaPage)


        dl.SqlSelect("Select link_data, title_name, public_view from elrc_structure where high_id = " & iParentId)

        Dim dtSub As DataTable = dl._DT
        Dim drSub As DataRow
        drSub = dtSub.Rows(0)


    End Sub

End Class
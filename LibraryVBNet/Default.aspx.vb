Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim _dlLib As New NCUDataLayer("elrc")
    Dim _dl As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mainNav As UserControls_wucNavBar = Master.navbar

        'Dim mainNav As UserControls_wucNavBar = MasterPage.navbar
        mainNav.BuildLibraryMenu()
        Dim sDomain = Request.ServerVariables("SERVER_NAME")

        'Director's mess
        'this is a test. 

        _dlLib.SqlSelect("Select entry_id, letter_title from letters_tb where display_letter_id = 1")
        Dim dtDirMess As DataTable = _dlLib._DT
        Dim drDirMess As DataRow = _dlLib._DR

        If dtDirMess.Rows.Count > 0 Then

            dirs_mess.Text = "Director's Message: <a target=_blank href=/letter.aspx?entry_id=" & drDirMess("entry_id") & ">" & drDirMess("letter_title") & "</a>"

        End If

        'Latest Blog Entry
        _dl.SqlSelect("Select top(3) blog_header.header_title, blog_header.blog_header_id from blog_arenas INNER JOIN blog_categories ON blog_arenas.blog_arena_id = blog_categories.blog_arena_id INNER JOIN blog_header ON blog_categories.blog_cat_id = blog_header.blog_cat_id WHERE blog_arenas.blog_arena_id = 2 ORDER by blog_header.update_datetime DESC")

        Dim dtBlog As DataTable = _dl._DT
        'Dim drBlog As DataRow = _dl._DR

        Dim tb As New Table

        For Each drBlog As DataRow In dtBlog.Rows

            Dim tr As New TableRow
            Dim tc As New TableCell

            tc.Text = "<div style=margin-left:8px;><a target=_blank href=/blog/?blog_arena_id=2 >" & drBlog("header_title") & "</a></div><br/>"

            tr.Cells.Add(tc)
            tb.Rows.Add(tr)
        Next


        PlaceHolder1.Controls.Add(tb)

        'Resource of the Month
        _dlLib.SqlSelect("Select entry_id, resource_title from resources_tb where display_resource_id = 1")
        Dim dtResMnth As DataTable = _dlLib._DT
        Dim drResMnth As DataRow = _dlLib._DR

        If dtResMnth.Rows.Count > 0 Then

            res_month.Text = "Resource of the Month: <a target=_blank href=/res_month.aspx?entry_id=" & drResMnth("entry_id") & ">" & drResMnth("resource_title") & "</a>"

        End If



    End Sub

End Class
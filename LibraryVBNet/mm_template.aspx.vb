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

Partial Class mm
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar
        mainNav.BuildLibraryMenu()

        Dim iParentId = CInt(Trim(Request.QueryString("parent_id")))
        bread_label.Text = LibraryFunctions.BreadCrumb(iParentId)
        dl.SqlSelect("SELECT * FROM elrc_structure WHERE high_id = " & iParentId & " ORDER BY display_order, title_name")

        Dim dt As DataTable = dl._DT
        Dim drTitle As DataRow = dl._DR
        drTitle = dt.Rows(0)
        mm_title.Text = drTitle("title_name")

        dl.SqlSelect("SELECT * FROM elrc_structure WHERE parent_id = " & iParentId & " ORDER BY display_order, title_name")
        Dim dtSubLinks As DataTable = dl._DT
        Dim dtMainMenu As New Table

        If dt.Rows.Count > 0 Then
            Dim sUrl As String
            For iMainMenu As Integer = 0 To dtSubLinks.Rows.Count - 1
                Dim dr As DataRow = dtSubLinks.Rows(iMainMenu)

                Select Case LCase(dr("type_page"))
                    Case "mm"
                        sUrl = "mm_template.aspx?parent_id=" & dr("high_id")
                    Case "dw"
                        sUrl = "dw_template.aspx?parent_id=" & dr("high_id")
                    Case "wl"
                        sUrl = "wl_template.aspx?parent_id=" & dr("high_id")
                    Case "fa"
                        sUrl = "fa_template.aspx?parent_id=" & dr("high_id")
                    Case Else
                        sUrl = dr("link_data")
                End Select

                Dim tr As New TableRow

                Dim tc1 As New TableCell
                tc1.Wrap = False

                tc1.Text = "<a href=" & sUrl & " > " & dr("title_name") & "</a><br/>"
                tr.Cells.Add(tc1)
                dtMainMenu.Rows.Add(tr)

            Next


        End If

        PlaceHolder1.Controls.Add(dtMainMenu)

    End Sub

End Class
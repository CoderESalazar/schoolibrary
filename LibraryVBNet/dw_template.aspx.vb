Imports NCUDataLayer
Imports NCUSecurity

Partial Class dw_template
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UnSecureThisPage()

        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        Dim iParentId As String

        iParentId = Request.QueryString("parent_id")
        bread_label.Text = LibraryFunctions.BreadCrumb(iParentId)

        dl.SqlSelect("Select link_data, title_name from elrc_structure where high_id = " & iParentId)


        Dim dtKeyId As DataTable = dl._DT

        If dtKeyId.Rows.Count > 0 Then
            Dim drKeyId As DataRow = dl._DR

            drKeyId = dtKeyId.Rows(0)

            'the line below is throwing the error
            Dim ikeyId = drKeyId("link_data")

            dl.SqlSelect("SELECT title_dw, text_dw FROM elrc_dw_info WHERE key_id = " & ikeyId)
            'wtf
            'i need this changed. 
            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            dr = dt.Rows(0)

            'dw_title.CssClass = "arc"
            dw_title.Text = dr("title_dw")
            GridView1.DataSource = dt
            'GridView1.CssClass = "test"
            GridView1.DataBind()

        End If


    End Sub
End Class

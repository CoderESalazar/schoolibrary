Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class browse
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        If Len(Request.QueryString("lib_cat")) = 0 Then

            Response.Write("Please go back and select a category.")
            Response.End()

        End If

        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        Dim sSql As String

        sSql = "Select quest_lib.q_id, quest_lib.lib_q_edit, quest_cat.cat_name from quest_lib INNER JOIN quest_cat ON quest_lib.lib_cat = quest_cat.cat_id where quest_lib.lib_cat = " & Request.QueryString("lib_cat") & " AND q_status = 'Submitted to KB' AND quest_lib.cat_id = 1 order by lib_date_time DESC"

        If Not Page.IsPostBack Then

            dl.SqlSelect(sSql)
            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            If dt.Rows.Count > 0 Then

                dr = dt.Rows(0)

                bread_crumb.Text = "<a href=/>Library Home</a> > <a href=/ncu_kb/default.aspx>Library FAQs</a>"
                cat_name.Text = dr("cat_name")

                GridView1.DataSource = dt
                GridView1.DataBind()

            Else

                no_q_found.Text = "Sorry, no questions available for this category."


            End If

        End If


    End Sub

End Class
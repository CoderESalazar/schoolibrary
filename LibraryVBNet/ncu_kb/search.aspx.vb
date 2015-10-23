Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class search

    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()
        Dim sSql As String


        'If Page.IsPostBack Then

        If Len(Session("search")) > 0 Then

            sSql = "SELECT q_id, lib_q_edit, cat_id  FROM quest_lib where lib_q_edit LIKE '%" & (Session("search")) & "%' AND q_status = 'Submitted to KB' AND cat_id <> 0"

            dl.SqlSelect(sSql)
            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            If dt.Rows.Count > 0 Then
                dr = dt.Rows(0)


                bread_crumb.Text = "<a href=/>Library Home</a> > <a href=/ncu_kb/default.aspx>Library FAQs</a>"
                SearchResults.Text = "Search Results for: " & Session("search")

                GridView1.DataSource = dt
                GridView1.DataBind()


            Else

                NoResults.Text = "Sorry, no results found. Please try again or browse by category. You are also free to contact the Library at library@ncu.edu."

            End If

        Else

            NothingEntered.Text = "Please enter something into the search box."

        End If

        'End If

    End Sub

End Class
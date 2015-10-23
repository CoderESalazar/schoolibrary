Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        UnSecureThisPage()

        Dim mainNav As UserControls_wucNavBar = Master.navbar

        mainNav.BuildLibraryMenu()

        TextBox1.Focus()
        If Request.QueryString("strid") <> "" Then

            Dim strUserName As String = Request.QueryString("strid")
            Dim strServName As String = Request.ServerVariables("server_name")

            DropCookie(strUserName, strServName)
        End If

        If Not Page.IsPostBack Then

            dl.SqlSelect("SELECT DISTINCT quest_cat.cat_name, quest_cat.cat_id from quest_cat INNER JOIN quest_lib ON quest_cat.cat_id = quest_lib.lib_cat where q_status = 'Submitted to KB' AND quest_lib.cat_id = 1 ORDER by cat_name")

            Dim dt As DataTable = dl._DT


            GridView1.DataSource = dt
            GridView1.DataBind()

        End If

        Call KbStats()
    End Sub



    Private Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim search_stuff As String

        search_stuff = TextBox1.Text
        Session("search") = search_stuff


        If Session("search") <> "" Then

            search_stuff = TextBox1.Text
            Session("search") = search_stuff

            Response.Redirect("search.aspx")

        Else

            lblSearch.Text = "<font color=red><strong>Please enter search terms.<strong></font>"

        End If

    End Sub

    Protected Sub KbStats()

        Dim sSubDomain As String = LCase(Split(Request.ServerVariables("SERVER_NAME"), ".")(0))
        Dim sFields() As String = {"user_id", "site_id"}
        Dim sValues() As String = {CurrentLetmeinUserID(), sSubDomain}

        dl.SqlInsert("stats_id_kb", sFields, sValues)

    End Sub

End Class
Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class search
    Inherits System.Web.UI.Page

    Dim dl, dl1 As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Len(Session("search")) > 0 Then

                dl.SqlSelect("Select guide_id, course_code, guide_title, last_name from elrc_cr_guides INNER JOIN ncu.dbo.staff_info ON update_by = staff_id WHERE course_code LIKE '%" & (Session("search")) & "%' ORDER BY course_code")
                'sSql = "Select guide_id, course_code, guide_title from elrc_cr_guides where course_code LIKE 'BUS3000' ORDER BY course_code"

                Dim dt As DataTable = dl._DT
                Dim dr As DataRow = dl._DR
                If dt.Rows.Count > 0 Then
                    dr = dt.Rows(0)

                    GridView1.DataSource = dt
                    GridView1.DataBind()

                Else
                    dl1.SqlSelect("SELECT guide_id, course_code, guide_title, last_name from elrc_cr_guides INNER JOIN ncu.dbo.staff_info ON update_by = staff_id WHERE last_name LIKE '%" & (Session("search")) & "%' ORDER BY course_code")

                    Dim dt1 As DataTable = dl1._DT
                    Dim dr1 As DataRow = dl1._DR
                    If dt1.Rows.Count > 0 Then
                        dr1 = dt1.Rows(0)

                        GridView1.DataSource = dt1
                        GridView1.DataBind()


                        'NoResults.Text = "Sorry, no results found. Please try again."

                    End If

                End If

            Else

                NothingEntered.Text = "Please enter something into the search box or nothing found."

            End If


        End If









    End Sub

    Private Sub guide_search_button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles guide_search_button.Click

        Dim search_stuff As String

        search_stuff = course_guide_search.Text

        Session("search") = search_stuff

        Response.Redirect("search.aspx")


    End Sub


End Class
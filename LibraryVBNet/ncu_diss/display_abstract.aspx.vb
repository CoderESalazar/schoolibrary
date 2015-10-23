Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class display_abstract
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim sQueryString = Request.QueryString("dissertation_id")

        Try
            dl.SqlSelect("SELECT dissertation_id, learner_first_name, learner_middle_name, learner_last_name, dissertation_abstract, i899a_title_of_diss, UPPER(degree_program_code) as DegreeProgramCode, degree_program_status, chair_mentor_first_name, chair_mentor_middle_name, chair_mentor_last_name FROM dissertation_checklist_report " & _
                            "WHERE dissertation_id=" & sQueryString & " AND degree_program_code IN ('phd-ba', 'edd', 'phd-psy', 'phd-mft', 'phd-ed', 'dba') AND stat_date IS NOT NULL AND degree_program_status IN ('Graduate', 'Pending Grad') ORDER BY stat_date DESC")

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            dr = dt.Rows(0)

            a_last_name.Text = dr("learner_last_name") & ""
            a_first_name.Text = dr("learner_first_name") & ""
            a_middle_name.Text = dr("learner_middle_name") & ""

            diss_title.Text = dr("i899a_title_of_diss") & ""
            docDegree.Text = dr("DegreeProgramCode") & ""
            cm_first_name.Text = dr("chair_mentor_first_name") & ""
            cm_mid_name.Text = dr("chair_mentor_middle_name") & ""
            cm_last_name.Text = dr("chair_mentor_last_name") & ""

            diss_download.Text = "<a href=download.aspx?dissertation_id=" & dr("dissertation_id") & ">here</a>"
            GridView1.DataSource = dt
            GridView1.DataBind()

        Catch

            Response.Write("An error has occurred. Please return to the previous page.")
            Response.End()

        End Try

    End Sub

End Class
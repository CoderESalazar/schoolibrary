Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class assign_form
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dlNcu As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Write("Hello Librarian " & CurrentLetmeinUserID())


        If Not Page.IsPostBack Then

            If UserHasAccessToApplication(dlNcu, CurrentLetmeinUserID(), "LibraryAdmin") Then

                'Need to write check method to ensure that this question hasn't already been assigned. 

                Dim sCheckId As String = Request.QueryString("q_id")
                dl.SqlSelect("SELECT q_status FROM quest_lib WHERE q_id = " & sCheckId)

                Dim dtCheck As DataTable = dl._DT
                Dim drCheck As DataRow = dl._DR

                If dtCheck.Rows.Count = 0 Then

                    'lets go ahead and do the following info below. 
                    Dim sSql As String
                    Dim sSql1 As String
                    Dim sSql2 As String

                    Dim sKeyId As String
                    sKeyId = Request.QueryString("q_id")
                    Session("query") = sKeyId

                    Dim ds As String = ""

                    sSql = "Select q_id, q_detail, q_status, date_time, cat_desc, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, lib_response, q_type, user_id, address_street, address_city, address_state, address_postal_code, phone_1 " & _
                                "FROM quest_tb INNER Join [iosqlwh001\iosqlwh001].ncu.dbo.staff_info ON user_id = staff_id WHERE q_id=" & Request.QueryString("q_id")

                    sSql1 = "Select q_id, q_detail, q_status, date_time, cat_desc, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, lib_response, q_type, user_id, address_street, address_city, address_state, address_postal_code, address_country, phone_1, deg_prog " & _
                                "FROM quest_tb INNER Join [iosqlwh001\iosqlwh001].ncu.dbo.learner_info ON user_id = learner_id WHERE q_id=" & Request.QueryString("q_id")

                    sSql2 = "Select q_id, q_detail, q_status, date_time, cat_desc, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, lib_response, q_type, user_id, address_street, address_city, address_state, address_postal_code, phone_1 FROM quest_tb " & _
                                "INNER Join [iosqlwh001\iosqlwh001].ncu.dbo.mentor_info ON user_id = mentor_id WHERE q_id=" & Request.QueryString("q_id")

                    'Try

                    dl.SqlSelect(sSql)
                    Dim dt As DataTable = dl._DT

                    dl.SqlSelect(sSql1)
                    Dim dt1 As DataTable = dl._DT

                    dl.SqlSelect(sSql2)
                    Dim dt2 As DataTable = dl._DT

                    Dim dr As DataRow = dl._DR

                    If dt.Rows.Count > 0 Then

                        dr = dt.Rows(0)
                        u_f_name.Text = dr("u_first_name") & ""
                        u_l_name.Text = dr("u_last_name") & ""
                        email.Text = dr("email_address") & ""
                        u_id.Text = dr("user_id") & ""
                        address_street.Text = dr("address_street") & ""
                        address_city.Text = dr("address_city") & ""
                        address_state.Text = dr("address_state") & ""
                        address_postal_code.Text = dr("address_postal_code") & ""
                        phone.Text = dr("phone_1") & ""
                        date_time.Text = dr("date_time") & ""
                        'cat_u.Text = dr("cat_desc") & ""
                        c_num.Text = dr("course_num") & ""
                        c_assign.Text = dr("assign_num") & ""
                        q_detail.Text = dr("q_detail") & ""

                        Call ContentSelect()

                    ElseIf dt1.Rows.Count > 0 Then

                        dr = dt1.Rows(0)
                        u_f_name.Text = dr("u_first_name") & ""
                        u_l_name.Text = dr("u_last_name") & ""
                        email.Text = dr("email_address") & ""
                        u_id.Text = dr("user_id") & ""
                        address_street.Text = dr("address_street") & ""
                        address_city.Text = dr("address_city") & ""
                        address_state.Text = dr("address_state") & ""
                        address_postal_code.Text = dr("address_postal_code") & ""
                        address_country.Text = dr("address_country") & ""
                        phone.Text = dr("phone_1") & ""
                        date_time.Text = dr("date_time") & ""
                        'cat_u.Text = dr("cat_desc") & ""
                        c_num.Text = dr("course_num") & ""
                        c_assign.Text = dr("assign_num") & ""
                        q_detail.Text = dr("q_detail") & ""
                        deg_prog.Text = dr("deg_prog") & ""

                        Call ContentSelect()

                    ElseIf dt2.Rows.Count > 0 Then

                        dr = dt2.Rows(0)
                        u_f_name.Text = dr("u_first_name") & ""
                        u_l_name.Text = dr("u_last_name") & ""
                        email.Text = dr("email_address") & ""
                        u_id.Text = dr("user_id") & ""
                        address_street.Text = dr("address_street") & ""
                        address_city.Text = dr("address_city") & ""
                        address_state.Text = dr("address_state") & ""
                        address_postal_code.Text = dr("address_postal_code") & ""
                        phone.Text = dr("phone_1") & ""
                        date_time.Text = dr("date_time") & ""
                        'cat_u.Text = dr("cat_desc") & ""
                        c_num.Text = dr("course_num") & ""
                        c_assign.Text = dr("assign_num") & ""
                        q_detail.Text = dr("q_detail") & ""

                        Call ContentSelect()

                    Else

                        Response.Write("ERROR. Not found in database.")

                    End If

                    'Catch ex As Exception


                    'End Try

                Else

                    Response.Write("This question is currently being worked on. Please go back.")
                    Response.End()

                End If


            End If


            End If


    End Sub

    Protected Sub ContentSelect()


        If Not Page.IsPostBack Then

            dl.SqlSelect("Select cat_name from quest_cat INNER Join quest_tb ON quest_cat.cat_id = quest_tb.cat_desc where quest_tb.q_id=" & Request.QueryString("q_id"))
            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            If dt.Rows.Count > 0 Then

                dr = dt.Rows(0)

                cat_u_name.Text = dr("cat_name") & ""

            End If


        End If

    End Sub

    Private Sub btnKb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKb.Click

        'I need to loop through and see if partial status in quest_lib then I need to see if q_id in quest_tb exists before I do the update below. 

        Dim sCheckId As String = Request.QueryString("q_id")
        dl.SqlSelect("SELECT q_status FROM quest_lib WHERE q_id = " & sCheckId)

        Dim dtCheck As DataTable = dl._DT
        Dim drCheck As DataRow = dl._DR

        If dtCheck.Rows.Count = 0 Then

            'We can proceed with method below. 

            dl.SqlSelect("Select cat_desc FROM quest_tb WHERE q_id=" & Request.QueryString("q_id"))

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            Dim sStatus As String
            sStatus = "Partial"
            Dim sKeyId = Request.QueryString("q_id")
            Dim sUserId = CurrentLetmeinUserID()

            Dim sFields() As String = {"lib_userid", "lib_date_time", "q_id", "lib_q_edit", "lib_cat", "q_status", "u_last_name", "cat_id", "deg_prog"}
            Dim sValues() As String = {sUserId, DateAndTime.Now, sKeyId, q_detail.Text, dr("cat_desc"), sStatus, u_l_name.Text, CheckBox1.Checked, deg_prog.Text}

            dl.SqlInsert("quest_lib", sFields, sValues)

            Response.Redirect("/ncu_kb/kb_table.aspx")

        Else

            Response.Write("This question is currently being worked on. Please go back.")
            Response.End()

        End If

    End Sub


End Class
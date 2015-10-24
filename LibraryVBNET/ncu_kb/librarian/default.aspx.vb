Imports NCUSecurity
Imports NCUDataLayer

Partial Public Class _default1
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Response.Write("Hello Librarian " & CurrentLetmeinUserID())


        If Not Page.IsPostBack Then

            If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then


                Dim sKeyId As String
                sKeyId = Request.QueryString("q_id")
                Session("query") = sKeyId

                Dim ds As String = ""

                Dim sSql, sSql1, sSql2, sSql3 As String

                'this sql statement is used for staff
                sSql = "Select quest_tb.q_id, q_detail, q_status, quest_tb.date_time, cat_name, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, lib_response, q_type, user_id, address_street, address_city, address_state, address_postal_code, phone_1 FROM quest_tb " & _
                        "INNER Join ncu.dbo.staff_info ON user_id = staff_id INNER JOIN quest_cat ON quest_cat.cat_id = quest_tb.cat_desc WHERE quest_tb.q_id=" & Request.QueryString("q_id")

                'this sql statement is used for learners
                sSql1 = "Select quest_tb.q_id, q_detail, q_status, quest_tb.date_time, cat_name, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, lib_response, q_type, user_id, address_street, address_city, address_state, address_postal_code, address_country, phone_1 FROM quest_tb " & _
                         "INNER Join ncu.dbo.learner_info ON user_id = learner_id INNER JOIN quest_cat ON quest_cat.cat_id = quest_tb.cat_desc WHERE quest_tb.q_id = " & Request.QueryString("q_id")

                'This sql statement is used for mentors
                sSql2 = "Select quest_tb.q_id, q_detail, q_status, quest_tb.date_time, cat_name, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, lib_response, q_type, user_id, address_street, address_city, address_state, address_postal_code, phone_1 FROM quest_tb " & _
                        "INNER Join ncu.dbo.mentor_info ON user_id = mentor_id INNER JOIN quest_cat ON quest_cat.cat_id = quest_tb.cat_desc WHERE quest_tb.q_id = " & Request.QueryString("q_id")

                'This sql statement is used for phone reference
                sSql3 = "Select quest_tb.q_id, q_detail, q_status, quest_tb.date_time, cat_name, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, lib_response, q_type, user_id FROM quest_tb " & _
                        "INNER JOIN quest_cat ON quest_cat.cat_id = quest_tb.cat_desc WHERE quest_tb.q_id = " & Request.QueryString("q_id")

                Try

                    dl.SqlSelect(sSql)
                    Dim dt As DataTable = dl._DT

                    dl.SqlSelect(sSql1)
                    Dim dt1 As DataTable = dl._DT

                    dl.SqlSelect(sSql2)
                    Dim dt2 As DataTable = dl._DT

                    dl.SqlSelect(sSql3)
                    Dim dt3 As DataTable = dl._DT

                    Dim dr As DataRow = dl._DR
                    If dt.Rows.Count > 0 Then

                        dr = dt.Rows(0)
                        ds = dr("q_type") & ""
                        q_type.Text = dr("q_type") & ""
                        q_status.Text = dr("q_status") & ""
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
                        cat_u_name.Text = dr("cat_name") & ""
                        c_num.Text = dr("course_num") & ""
                        c_assign.Text = dr("assign_num") & ""
                        q_detail.Content = dr("q_detail") & ""
                        lib_response.Content = dr("lib_response") & ""

                        'Response.Write(dl.Severity & ", " & dl.ServerName & ", " & dl.SqlStatement)
                        Call CatSelect()

                    ElseIf dt1.Rows.Count > 0 Then

                        dr = dt1.Rows(0)
                        ds = dr("q_type") & ""
                        q_type.Text = dr("q_type") & ""
                        q_status.Text = dr("q_status") & ""
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
                        cat_u_name.Text = dr("cat_name") & ""
                        c_num.Text = dr("course_num") & ""
                        c_assign.Text = dr("assign_num") & ""
                        q_detail.Content = dr("q_detail") & ""
                        lib_response.Content = dr("lib_response") & ""

                        'Response.Write(dl.Severity & ", " & dl.ServerName & ", " & dl.SqlStatement)
                        Call CatSelect()

                    ElseIf dt2.Rows.Count > 0 Then

                        dr = dt2.Rows(0)
                        ds = dr("q_type") & ""
                        q_type.Text = dr("q_type") & ""
                        q_status.Text = dr("q_status") & ""
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
                        c_num.Text = dr("course_num") & ""
                        c_assign.Text = dr("assign_num") & ""
                        cat_u_name.Text = dr("cat_name") & ""
                        q_detail.Content = dr("q_detail") & ""
                        lib_response.Content = dr("lib_response") & ""

                        'Response.Write(dl.Severity & ", " & dl.ServerName & ", " & dl.SqlStatement)

                        Call CatSelect()

                    ElseIf dt3.Rows.Count > 0 Then

                        dr = dt3.Rows(0)
                        ds = dr("q_type") & ""
                        q_type.Text = dr("q_type") & ""
                        q_status.Text = dr("q_status") & ""
                        u_f_name.Text = dr("u_first_name") & ""
                        u_l_name.Text = dr("u_last_name") & ""
                        email.Text = dr("email_address") & ""
                        u_id.Text = dr("user_id") & ""
                        date_time.Text = dr("date_time") & ""
                        c_num.Text = dr("course_num") & ""
                        cat_u_name.Text = dr("cat_name") & ""
                        c_assign.Text = dr("assign_num") & ""
                        q_detail.Content = dr("q_detail") & ""
                        lib_response.Content = dr("lib_response") & ""

                        'Response.Write(dl.Severity & ", " & dl.ServerName & ", " & dl.SqlStatement)
                        Call CatSelect()

                    Else

                        Response.Write("ERROR. Not found in database.")

                    End If

                Catch ex As Exception


                End Try

            End If


        End If
    End Sub

    Protected Sub CatSelect()

        Dim sSql = "Select cat_id, cat_name from quest_cat order by cat_name"

        dl.SqlSelect(sSql)
  
        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR
        Dim i As Integer
        Dim newItem As ListItem

        dr = dt.Rows(0)
        cat_drop.Items.Insert(0, New ListItem("Please Select", " "))
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            newItem = New ListItem
            newItem.Text = dr("cat_name")
            newItem.Value = dr("cat_id")
            cat_drop.Items.Add(newItem)
        Next

    End Sub


    Private Sub btnKb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnKb.Click

        Dim sFields() As String = {"lib_userid", "lib_date_time", "q_id", "q_status", "lib_cat", "lib_q_edit", "lib_response", _
        "u_last_name", "cat_id", "q_type"}
        Dim sValues() As String = {CurrentLetmeinUserID(), DateTime.Now, Request.QueryString("q_id"), lib_q_status.SelectedValue, _
        cat_drop.SelectedValue, q_detail.Content, lib_response.Content, u_l_name.Text, checkBox.Checked, q_type.Text}
       
        dl.SqlInsert("quest_lib", sFields, sValues)

        Response.Redirect("/ncu_kb/kb_table.aspx")


    End Sub

    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        If lib_q_status.SelectedValue = "Partial" Then

            Dim sFields(3) As String
            Dim sValues(3) As String

            Dim sKeyId As String

            sKeyId = Request.QueryString("q_id")

            sFields(0) = "q_detail"
            sFields(1) = "lib_response"
            sFields(2) = "cat_desc"
            sFields(3) = "q_status"

            sValues(0) = q_detail.Content
            sValues(1) = lib_response.Content
            sValues(2) = cat_drop.SelectedValue
            sValues(3) = lib_q_status.SelectedValue

            dl.SqlUpdate("quest_tb", "q_id", sKeyId, sFields, sValues)

            Response.Redirect("/ncu_kb/kb_table.aspx")

        Else

            Dim arFields(9) As String
            Dim arValues(9) As String

            arFields(0) = "lib_userid"
            arFields(1) = "lib_date_time"
            arFields(2) = "q_id"
            arFields(3) = "q_status"
            arFields(4) = "lib_cat"
            arFields(5) = "lib_q_edit"
            arFields(6) = "lib_response"
            arFields(7) = "u_last_name"
            arFields(8) = "cat_id"
            arFields(9) = "q_type"

            arValues(0) = CurrentLetmeinUserID()
            arValues(1) = DateTime.Now
            arValues(2) = Request.QueryString("q_id")
            arValues(3) = lib_q_status.SelectedValue
            arValues(4) = cat_drop.SelectedValue
            arValues(5) = q_detail.Content
            arValues(6) = lib_response.Content
            arValues(7) = u_l_name.Text
            arValues(8) = checkBox.Checked
            arValues(9) = q_type.Text

            dl.SqlInsert("quest_lib", arFields, arValues)

            Response.Redirect("/ncu_kb/kb_table.aspx")

        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim strKeyId As String = Request.QueryString("q_id")

        dl.SqlDelete("quest_tb", "q_id", strKeyId)

        Response.Redirect("/ncu_kb/kb_table.aspx")

    End Sub
End Class
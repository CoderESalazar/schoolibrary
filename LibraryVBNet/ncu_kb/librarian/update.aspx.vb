Imports NCUSecurity
Imports ResultStatus
Imports compass

Partial Public Class update
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Response.Write("Hello Librarian, " & CurrentLetmeinUserID())

        If Not Page.IsPostBack Then


            If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then


                searchLink.NavigateUrl = Request.ServerVariables("HTTP_REFERER")

                'Try
                'dl.DLConnect()

                Dim sKeyId As String = Request.QueryString("q_id")

                Dim sSql, sSql1, sSql2, sSql3 As String

                sSql = "Select q_id, q_detail, q_status, date_time, cat_desc, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, user_id, address_street, address_city, address_state, address_postal_code, phone_1 FROM quest_tb INNER Join ncu.dbo.staff_info ON user_id = staff_id WHERE q_id=" & Request.QueryString("q_id")

                sSql1 = "Select q_id, q_status, q_detail, date_time, cat_desc, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, user_id, address_street, address_city, address_state, address_postal_code, address_country, phone_1 FROM quest_tb INNER Join ncu.dbo.learner_info ON user_id = learner_id WHERE q_id=" & Request.QueryString("q_id")

                sSql2 = "Select q_id, q_status, q_detail, date_time, cat_desc, u_first_name, u_last_name, course_num, assign_num, quest_tb.email_address, user_id, address_street, address_city, address_state, address_postal_code, phone_1 FROM quest_tb INNER Join ncu.dbo.mentor_info ON user_id = mentor_id WHERE q_id=" & Request.QueryString("q_id")

                sSql3 = "Select quest_tb.q_id, quest_tb.q_detail, quest_tb.q_status, quest_tb.date_time, quest_tb.cat_desc, quest_tb.u_first_name, quest_tb.u_last_name, quest_tb.course_num, quest_tb.assign_num, quest_tb.email_address, quest_tb.lib_response, quest_tb.q_type, quest_tb.user_id, quest_tb.q_edit, quest_lib.new_cat FROM quest_tb INNER JOIN quest_lib ON quest_tb.q_id = quest_lib.q_id WHERE quest_lib.q_id = " & Request.QueryString("q_id")

                dl.SqlSelect(sSql)
                Dim dt As DataTable = dl._DT
                dl.SqlSelect(sSql1)
                Dim dt1 As DataTable = dl._DT
                dl.SqlSelect(sSql2)
                Dim dt2 As DataTable = dl._DT
                dl.SqlSelect(sSql3)
                Dim dt3 As DataTable = dl._DT

                Dim dr As DataRow = dl._DR

                Session("query") = sKeyId
                Dim ds As String = ""

                If dt.Rows.Count > 0 Then

                    dr = dt.Rows(0)
                    ds = dr("q_status") & ""
                    u_f_name.Text = dr("u_first_name") & ""
                    u_f_name.Text = dr("u_first_name") & ""
                    u_l_name.Text = dr("u_last_name") & ""
                    u_id.Text = dr("user_id") & ""
                    address_street.Text = dr("address_street") & ""
                    address_city.Text = dr("address_city") & ""
                    address_state.Text = dr("address_state") & ""
                    address_postal_code.Text = dr("address_postal_code") & ""
                    phone.Text = dr("phone_1") & ""
                    date_time.Text = dr("date_time") & ""
                    cat_u_name.Text = dr("cat_desc") & ""
                    c_num.Text = dr("course_num") & ""
                    c_assign.Text = dr("assign_num") & ""
                    e_mail.Text = dr("email_address") & ""

                    If ds.Contains("Not") Then

                        remove_kb.Visible = "False"

                    Else

                        checkBox.Visible = "true"
                        remove_kb.Visible = "true"

                    End If

                    If ds.Contains("Partial") Then
                        checkBox.Visible = "False"
                        remove_kb.Visible = "False"
                        lib_q_status.Visible = "True"
                        q_status.Visible = "True"
                        cat_create.Visible = "True"
                        reassign.Visible = "True"
                        FileUpload1.Visible = "True"
                        file_upload_text.Visible = "True"

                    End If

                    Call CatSelect()
                    Call ContentSelect()
                    Call checkbox1()

                ElseIf dt1.Rows.Count > 0 Then

                    dr = dt1.Rows(0)
                    ds = dr("q_status") & ""
                    u_f_name.Text = dr("u_first_name") & ""
                    u_l_name.Text = dr("u_last_name") & ""
                    u_id.Text = dr("user_id") & ""
                    address_street.Text = dr("address_street") & ""
                    address_city.Text = dr("address_city") & ""
                    address_state.Text = dr("address_state") & ""
                    address_postal_code.Text = dr("address_postal_code") & ""
                    address_country.Text = dr("address_country") & ""
                    phone.Text = dr("phone_1") & ""
                    date_time.Text = dr("date_time") & ""
                    cat_u_name.Text = dr("cat_desc") & ""
                    c_num.Text = dr("course_num") & ""
                    c_assign.Text = dr("assign_num") & ""
                    e_mail.Text = dr("email_address") & ""

                    If ds.Contains("Not") Then

                        remove_kb.Visible = "False"

                    Else

                        checkBox.Visible = "true"
                        remove_kb.Visible = "true"

                    End If

                    If ds.Contains("Partial") Then
                        checkBox.Visible = "False"
                        remove_kb.Visible = "False"
                        lib_q_status.Visible = "True"
                        q_status.Visible = "True"
                        cat_create.Visible = "True"
                        reassign.Visible = "True"
                        FileUpload1.Visible = "True"
                        file_upload_text.Visible = "True"

                    End If

                    Call CatSelect()
                    Call ContentSelect()
                    Call checkbox1()

                ElseIf dt2.Rows.Count > 0 Then

                    dr = dt2.Rows(0)
                    ds = dr("q_status") & ""
                    u_f_name.Text = dr("u_first_name") & ""
                    u_l_name.Text = dr("u_last_name") & ""
                    u_id.Text = dr("user_id") & ""
                    address_street.Text = dr("address_street") & ""
                    address_city.Text = dr("address_city") & ""
                    address_state.Text = dr("address_state") & ""
                    address_postal_code.Text = dr("address_postal_code") & ""
                    phone.Text = dr("phone_1") & ""
                    date_time.Text = dr("date_time") & ""
                    cat_u_name.Text = dr("cat_desc") & ""
                    c_num.Text = dr("course_num") & ""
                    c_assign.Text = dr("assign_num") & ""
                    e_mail.Text = dr("email_address") & ""

                    If ds.Contains("Not") Then

                        remove_kb.Visible = "False"

                    Else
                        checkBox.Visible = "true"
                        remove_kb.Visible = "true"

                    End If

                    If ds.Contains("Partial") Then
                        checkBox.Visible = "False"
                        remove_kb.Visible = "False"
                        lib_q_status.Visible = "True"
                        q_status.Visible = "True"
                        cat_create.Visible = "True"
                        reassign.Visible = "True"
                        FileUpload1.Visible = "True"
                        file_upload_text.Visible = "True"

                    End If

                    Call CatSelect()
                    Call ContentSelect()
                    Call checkbox1()

                ElseIf dt3.Rows.Count > 0 Then

                    dr = dt3.Rows(0)
                    ds = dr("q_status") & ""

                    u_f_name.Text = dr("u_first_name") & ""
                    u_l_name.Text = dr("u_last_name") & ""
                    e_mail.Text = dr("email_address") & ""
                    date_time.Text = dr("date_time") & ""
                    cat_u_name.Text = dr("new_cat") & ""
                    q_detail.Content = dr("q_detail") & ""
                    lib_response.Content = dr("lib_response") & ""

                    If ds.Contains("Not") Then

                        remove_kb.Visible = "False"

                    Else

                        checkBox.Visible = "true"
                        remove_kb.Visible = "true"

                    End If

                    Call CatSelect()
                    Call ContentSelect()
                    Call checkbox1()

                Else

                    Response.Write("ERROR. Not found in database.")

                End If

                'Catch ex As Exception

                'Finally

                'dl.DLTerminate()

                'End Try

            End If

        End If

    End Sub

    Protected Sub CatSelect()

        Dim sSql As String
        sSql = "Select cat_id, cat_name from quest_cat order by cat_name"
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


    Protected Sub ContentSelect()

        If Not Page.IsPostBack Then

            Dim sSql As String
            sSql = "Select lib_response, lib_q_edit, q_status, cat_name from quest_lib INNER JOIN quest_cat ON lib_cat = quest_cat.cat_id where quest_lib.q_id=" & Request.QueryString("q_id")
            dl.SqlSelect(sSql)

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow

            If dt.Rows.Count > 0 Then

                dr = dt.Rows(0)

                lib_response.Content = dr("lib_response") & ""
                q_detail.Content = dr("lib_q_edit") & ""
                cat_u_name.Text = dr("cat_name") & ""

            End If


        End If
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        Dim sSql As String
        sSql = "Select q_status from quest_lib where q_id = " & Request.QueryString("q_id")

        dl.SqlSelect(sSql)
        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR
        Dim ds As String = ""

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            ds = dr("q_status") & ""

        End If

        If ds.Contains("Partial") Then

            Dim arFields(4) As String
            Dim arValues(4) As String
            Dim strUpdate As String
            Dim sKeyId As String

            sKeyId = Request.QueryString("q_id")

            arFields(0) = "lib_cat"
            arFields(1) = "q_status"
            arFields(2) = "lib_q_edit"
            arFields(3) = "lib_response"
            arFields(4) = "cat_id"

            arValues(0) = cat_drop.SelectedValue
            arValues(1) = lib_q_status.SelectedValue
            arValues(2) = q_detail.Content
            arValues(3) = lib_response.Content
            arValues(4) = checkBox.Checked

            strUpdate = dl.SqlUpdate("quest_lib", "q_id", sKeyId, arFields, arValues)

            If lib_q_status.SelectedValue = "Submitted to KB" Or lib_q_status.SelectedValue = "Not Submitted to KB" Then

                Call SendEmail()

            End If

            Response.Redirect("../kb_table.aspx")
        Else

            Dim arFields(3) As String
            Dim arValues(3) As String
            Dim strUpdate As String
            Dim sKeyId As String

            sKeyId = Request.QueryString("q_id")

            arFields(0) = "lib_cat"
            arFields(1) = "lib_q_edit"
            arFields(2) = "lib_response"
            arFields(3) = "cat_id"

            arValues(0) = cat_drop.SelectedValue
            arValues(1) = q_detail.Content
            arValues(2) = lib_response.Content
            arValues(3) = checkBox.Checked

            strUpdate = dl.SqlUpdate("quest_lib", "q_id", sKeyId, arFields, arValues)

            Response.Redirect("../kb_table.aspx")

        End If

    End Sub


    Protected Sub EmailUpdate()

        Dim arFields(3) As String
        Dim arValues(3) As String
        Dim sKeyId As String

        sKeyId = Request.QueryString("q_id")

        arFields(0) = "lib_cat"
        arFields(1) = "lib_q_edit"
        arFields(2) = "lib_response"
        arFields(3) = "email_sent"


        arValues(0) = cat_drop.SelectedValue
        arValues(1) = q_detail.Content
        arValues(2) = lib_response.Content
        arValues(3) = DateAndTime.Now

        dl.SqlUpdate("quest_lib", "q_id", sKeyId, arFields, arValues)

        'Response.Write(dl.Severity & " ," & dl.Results & " ," & dl.SqlStatement)

        Call FileUpload()

    End Sub

    Protected Sub UploadFile()


        Dim sSql As String = "Select attachment_file_name from file_uploads where q_id = " & Request.QueryString("q_id")
        dl.SqlSelect(sSql)

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR
        Dim ds As String = ""

        dr = dt.Rows(0)

        If dt.Rows.Count > 0 Then

            'Try

            dl.SqlSelect(sSql)
            If dt.Rows.Count > 0 Then

                ds = dr("attachment_file_name")

            End If
            'Catch ex As Exception

            'End Try

        Else

        End If

        Dim arFields(0) As String
        Dim arValues(0) As String
        Dim strUpdate As String
        Dim sKeyId As String

        sKeyId = Request.QueryString("q_id")

        arFields(0) = "file_upload"

        arValues(0) = ds

        strUpdate = dl.SqlUpdate("quest_lib", "q_id", sKeyId, arFields, arValues)

        Response.Redirect("../kb_table.aspx")

    End Sub

    Protected Sub SendEmail()


        dl.SqlSelect("Select q_id, q_detail, date_time, u_first_name, u_last_name, email_address FROM quest_tb WHERE q_id=" & Request.QueryString("q_id"))

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow

        Dim q_id, q_details, date_times, u_first_name, u_last_name, email_addresses As String

       
        If dt.Rows.Count > 0 Then
            dr = dt.Rows(0)

            q_id = dr("q_id") & ""
            q_details = dr("q_detail") & ""
            date_times = dr("date_time") & ""
            u_first_name = dr("u_first_name") & ""
            u_last_name = dr("u_last_name") & ""
            email_addresses = dr("email_address") & ""

            Dim objmail As New System.Net.Mail.MailMessage()
            objmail.From = New System.Net.Mail.MailAddress("library@ncu.edu")
            objmail.To.Add(email_addresses)
            objmail.Subject = "Ask a Librarian Response"
            objmail.Body = "Hello " & u_first_name & ", there is now a response to your question submitted " & date_times & ". Please click the following link to view the Librarian's response http://library.ncu.edu/asklib in the My e-Reference Area."
            Dim objSMTP As New System.Net.Mail.SmtpClient("smtp.ncu.edu")
            objSMTP.Send(objmail)

            Call EmailUpdate()

        End If

    End Sub

    Protected Sub FileUpload()


        If Len(FileUpload1.FileName) > 1 Then

            Dim sFields(2) As String
            Dim sValues(2) As String


            Dim SendMessageBlob As String

            sFields(0) = "q_id"  ' this will be unique because I need to create table that can hold attachments
            sFields(1) = "attachment_file_name"
            sFields(2) = "attachment_file_type"

            sValues(0) = Request.QueryString("q_id")
            sValues(1) = FileUpload1.FileName
            sValues(2) = Replace(System.IO.Path.GetExtension(FileUpload1.FileName), ".", "")


            dl.SqlInsert("file_uploads", sFields, sValues)

            Dim sKey = dl.Identity

            If dl.Severity > -1 Then

                SendMessageBlob = dl.SqlBlob("file_uploads", "upload_id", sKey, "attachment_file", FileUpload1.FileBytes)
                dl.SqlBlob("file_uploads", "upload_id", sKey, "attachment_file", FileUpload1.FileBytes)

                If dl.Severity > -1 Then
                    'Response.Write(sKey & " , " & dl.Severity & " , " & dl.SqlStatement & " , " & dl.Results)
                    'Response.End()

                    Call UploadFile()

                End If

            Else

                Response.Write(dl.Results)
                Response.End()

            End If

        Else

            Response.Redirect("../kb_table.aspx")

        End If

    End Sub

    Protected Sub checkbox1()
        Dim iKeyId = Request.QueryString("q_id")

        dl.SqlSelect("Select cat_id from quest_lib where q_id = " & iKeyId)

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            If checkBox.Checked Then

                checkBox.Checked = dr("cat_id")
            Else
                checkBox.Checked = True

            End If

        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim strDelete As String
        Dim strKeyId As String
        strKeyId = Request.QueryString("q_id")

        strDelete = dl.SqlDelete("quest_lib", "q_id", strKeyId)

        Response.Redirect("/ncu_kb/kb_table.aspx")

    End Sub
End Class
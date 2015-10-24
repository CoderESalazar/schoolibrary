Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class phone_ref
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dlNcu As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Response.Write("Hello Librarian: " & CurrentLetmeinUserID())

            If UserHasAccessToApplication(dlNcu, CurrentLetmeinUserID(), "LibraryAdmin") Then

                dl.SqlSelect("Select cat_id, cat_name from quest_cat order by cat_name")

                Dim dt As DataTable = dl._DT
                Dim dr As DataRow = dl._DR
                Dim i As Integer
                Dim newitem As ListItem

                dr = dt.Rows(0)

                cat_drop.Items.Insert(0, New ListItem("Please Select", " "))

                For i = 0 To dt.Rows.Count - 1
                    dr = dt.Rows(i)
                    newitem = New ListItem
                    newitem.Text = dr("cat_name")
                    newitem.Value = dr("cat_id")
                    cat_drop.Items.Add(newitem)
                Next


                Call StaffName()

            End If
        End If
    End Sub


    Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If Me.IsValid Then


            Dim sFields() As String = {"user_id", "u_first_name", "u_last_name", "email_address", "date_time", "q_type", "cat_desc", "course_num", _
                                         "assign_num", "q_detail", "lib_response", "lib_last_name"}
            Dim sValues() As String = {user_id.Text, f_name.Text, l_name.Text, email_add.Text, DateAndTime.Now, q_type.SelectedValue, _
                                       cat_drop.SelectedValue, c_numb.Text, assign_numb.Text, quest_desc.Value, lib_response.Value, staff_name.Text}

            dl.SqlInsert("quest_tb", sFields, sValues)
            'Response.Write(dl.resultStatus.Message & " <br/><br/> " & dl.resultStatus.SqlStatement)
            'Response.End()
            Response.Redirect("kb_table.aspx")

        End If

    End Sub


    Protected Sub StaffName()

        Dim dl As New NCUDataLayer("mainline")
        dl.SqlSelect("Select last_name from staff_info where staff_id= '" & CurrentLetmeinUserID() & "'")

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            staff_name.Text = dr("last_name")

        End If

    End Sub

    Protected Sub IDSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles IDSearch.Click

        dlNcu.SqlSelect("SELECT first_name, last_name, email_address_1 FROM learner_info WHERE learner_id = '" & user_id.Text & "'")

        Dim dt As DataTable = dlNcu._DT
        Dim dr As DataRow = dlNcu._DR

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            f_name.Text = dr("first_name") & ""
            l_name.Text = dr("last_name") & ""
            email_add.Text = dr("email_address_1") & ""


        End If

    End Sub

    Protected Sub MIDSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MIDSearch.Click

        dlNcu.SqlSelect("SELECT first_name, last_name, email_address_public FROM mentor_info WHERE mentor_id = '" & user_id.Text & "'")

        Dim dt As DataTable = dlNcu._DT
        Dim dr As DataRow = dlNcu._DR

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            f_name.Text = dr("first_name") & ""
            l_name.Text = dr("last_name") & ""
            email_add.Text = dr("email_address_public") & ""


        End If

    End Sub
End Class
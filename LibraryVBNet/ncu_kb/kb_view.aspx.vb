Imports NCUDataLayer
Imports NCUSecurity
Imports BreadCrumb

Partial Public Class kb_view

    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dBre As New BreadCrumb

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        'If Request.QueryString("strid") <> "" Then

        'Dim strUserName As String = Request.QueryString("strid")
        'Dim strServName As String = Request.ServerVariables("server_name")


        'DropCookie(strUserName, strServName)

        'End If

        Dim bPublic = False
        If Len(Trim(CurrentLetmeinUserID())) = 0 Then bPublic = True
        If bPublic = True Then

            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            ValidationCheck("UnivPeople", iDomain)

        Else
            Dim qId = Request.QueryString("q_id")

            bread_crumb.Text = dBre.BreadQId(qId)

            dl.SqlSelect("Select quest_lib.lib_response, quest_lib.lib_cat, quest_lib.lib_q_edit, quest_tb.date_time from quest_lib INNER JOIN quest_tb ON quest_lib.q_id = quest_tb.q_id WHERE quest_lib.q_id= " & Request.QueryString("q_id"))

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            Try

                If dt.Rows.Count > 0 Then

                    dr = dt.Rows(0)

                    date_time.Text = dr("date_time") & ""
                    'cat_desc.Text = dr("lib_cat") & ""
                    lib_q_edit.Text = dr("lib_q_edit") & ""
                    lib_response.Text = dr("lib_response") & ""
                    Call CatSelect()

                End If

            Catch ex As Exception

            End Try

        End If



    End Sub

    Protected Sub CatSelect()

        dl.SqlSelect("Select quest_lib.lib_cat, quest_cat.cat_name from quest_lib INNER JOIN quest_cat ON quest_lib.lib_cat = quest_cat.cat_id WHERE quest_lib.q_id= " & Request.QueryString("q_id"))

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR

        Try

            If dt.Rows.Count > 0 Then

                dr = dt.Rows(0)

                cat_desc.Text = dr("cat_name") & ""

            End If

        Catch ex As Exception

            Call CatSelect()

        End Try

    End Sub

    Private Sub btnAsk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAsk.Click

        Response.Redirect("/ncu_kb/user/user_page.aspx")

    End Sub

    Private Sub btnYes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnYes.Click

        Dim arFields(3) As String
        Dim arValues(3) As String
        Dim strAdd As String

        arFields(0) = "fdbk"
        arFields(1) = "fdbk_user_id"
        arFields(2) = "q_id"
        arFields(3) = "date_time"

        arValues(0) = btnYes_true.Text
        arValues(1) = CurrentLetmeinUserID()
        arValues(2) = Request.QueryString("q_id")
        arValues(3) = DateTime.Now

        strAdd = dl.SqlInsert("quest_fdbk", arFields, arValues)

        Vwfdbk.Visible = "True"

    End Sub

    Private Sub btnNo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNo.Click

        Dim arFields(3) As String
        Dim arValues(3) As String
        Dim strAdd As String

        arFields(0) = "fdbk"
        arFields(1) = "fdbk_user_id"
        arFields(2) = "q_id"
        arFields(3) = "date_time"

        arValues(0) = btnNo_false.Text
        arValues(1) = CurrentLetmeinUserID()
        arValues(2) = Request.QueryString("q_id")
        arValues(3) = DateTime.Now

        strAdd = dl.SqlInsert("quest_fdbk", arFields, arValues)

        Vwfdbk.Visible = "True"

    End Sub

    Private Sub fdbk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles fdbk.Click

        Dim sKeyId As String

        sKeyId = Request.QueryString("q_id")

        Session("query") = sKeyId

        Response.Redirect("/ncu_kb/fdbk_form.aspx")

    End Sub
End Class
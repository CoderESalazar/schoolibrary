Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class user_area
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Request.QueryString("strid") <> "" Then

            Dim strUserName As String = Request.QueryString("strid")
            Dim strServName As String = Request.ServerVariables("server_name")

            DropCookie(strUserName, strServName)

        End If

        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        Dim bPublic = False
        If Len(Trim(CurrentLetmeinUserID())) = 0 Then bPublic = True
        If bPublic = True Then
            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            ValidationCheck("UnivPeople", iDomain)
        Else


            dl.SqlSelect("Select lib_response from quest_lib where q_id = " & Request.QueryString("q_id"))
            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            Try

                If dt.Rows.Count > 0 Then

                    dr = dt.Rows(0)

                    'date_time.Text = dr("date_time") & ""
                    'cat_desc.Text = dr("lib_cat") & ""
                    'lib_q_edit.Text = dr("lib_q_edit") & ""
                    lib_response.Text = dr("lib_response") & ""
                    'Call CatSelect()

                End If

            Catch ex As Exception

            End Try

            dl.SqlSelect("Select attachment_file_name, q_id from file_uploads where q_id = " & Request.QueryString("q_id"))
            Dim dt1 As DataTable = dl._DT

            dl.SqlSelect("Select q_detail from quest_tb where q_id = " & Request.QueryString("q_id"))
            Dim dt2 As DataTable = dl._DT

            GridView1.DataSource = dt
            GridView1.DataBind()

            GridView2.DataSource = dt1
            GridView2.DataBind()

            GridView3.DataSource = dt2
            GridView3.DataBind()

            quest_id.Text = Request.QueryString("q_id")

            Call ViewedMessages()

        End If

    End Sub

    Private Sub btnFdbk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFdbk.Click

        Response.Redirect("/ncu_kb/user/fdbk_form.aspx?q_id=" & Request.QueryString("q_id"))

    End Sub

    Protected Sub ViewedMessages()

        dl.SqlSelect("SELECT viewed_mess FROM quest_lib WHERE q_id = " & Request.QueryString("q_id"))

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR

        If dr("viewed_mess") = False Then

            Dim arFields(0) As String
            Dim arValues(0) As String
            Dim sKeyId As String

            sKeyId = Request.QueryString("q_id")

            arFields(0) = "viewed_mess"

            arValues(0) = True

            dl.SqlUpdate("quest_lib", "q_id", sKeyId, arFields, arValues)

        End If

    End Sub

End Class
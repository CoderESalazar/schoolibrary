Imports NCUSecurity
Imports NCUDataLayer


Partial Public Class update
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc", "admin")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

                Dim sSql As String
                Dim sKeyId As String


                sKeyId = Request.QueryString("lib_id")

                sSql = "Select chat_transcript from chat where lib_id = " & sKeyId

                dl.SqlSelect(sSql)
                Dim dt As DataTable = dl._DT
                Dim dr As DataRow = dl._DR

                If dt.Rows.Count > 0 Then

                    dr = dt.Rows(0)

                    Editor1.Content = dr("chat_transcript") & ""

                End If


                Call CheckBox()

            Else

                Response.Write("Sorry, you don't have access.")

            End If

        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim arFields(2) As String
        Dim arValues(2) As String
        Dim sKeyId As String
        Dim strUpdate As String

        sKeyId = Request.QueryString("lib_id")

        arFields(0) = "lib_chat"
        arFields(1) = "end_time"
        arFields(2) = "chat_transcript"

        arValues(0) = CheckBox1.Checked
        arValues(1) = DateAndTime.Now
        arValues(2) = Editor1.Content

        strUpdate = dl.SqlUpdate("chat", "lib_id", sKeyId, arFields, arValues)

        Response.Redirect("/chat_admin/log.aspx")

    End Sub

    Protected Sub CheckBox()

        Dim sSql As String

        sSql = "Select lib_chat from chat where lib_id = " & Request.QueryString("lib_id")
        dl.SqlSelect(sSql)

        Dim dt As DataTable = dl._DT
        Dim dr As DataRow = dl._DR

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            If CheckBox1.Checked Then

                CheckBox1.Checked = dr("lib_chat")
            Else

                CheckBox1.Checked = True

            End If

        End If


    End Sub

End Class
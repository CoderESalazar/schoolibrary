Imports compass
Imports compass.Security
Imports compass.Util


Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If UserHasAccessToApplication(dl, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Panel1.Visible = True

            Response.Write(Request.QueryString("lib_id"))

            'Call CheckBox()
        Else

            Response.Write("Sorry, you don't have access.")


        End If

    End Sub

    Private Sub chat_button_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chat_button.Click

        Dim arFields(1)
        Dim arValues(1)
        Dim strUpdate As String
        Dim sKeyId As String

        sKeyId = ADOFields.ADOStringField(Request.QueryString("lib_id"))
        'dl.SetDBNAME("elrc")


        'arFields(0) = "lib_chat"
        arFields(0) = "test_id"
        'arFields(2) = "lib_date_out"

        'arValues(0) = 
        arValues(0) = TextBox1.Text
        'arValues(2) = DateAndTime.Now

        strUpdate = dl.SqlUpdate("chat", "lib_id", ADOFields.ADOStringField("sKeyId"), arFields, arValues)

        Response.Redirect("/default.asp")

    End Sub

    Protected Sub CheckBox()

        Dim dt As DataTable
        Dim dr As DataRow

        Dim sSql As String

        sSql = "Select lib_chat, lib_id from chat where lib_id = 1"

        dl.setDBName("elrc")

        dt = dl.SqlSelect(sSql)

        If dt.Rows.Count > 0 Then

            dr = dt.Rows(0)

            If lib_checkBox.Checked Then

                lib_checkBox.Checked = dr("lib_id")

            Else
                lib_checkBox.Checked = True

            End If

        End If


    End Sub

End Class
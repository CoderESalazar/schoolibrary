Imports compass
Imports compass.security

Partial Public Class reassign
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Response.Write(Session("query"))
        If Not Page.IsPostBack Then

            Dim dt As DataTable
            Dim dr As DataRow
            Dim sSql As String
            Dim iQid As String

            dl.SetDBNAME("elrc")
            iQid = Session("query")
            q_ids.Text = Session("query")

            sSql = "Select q_detail from quest_tb where q_id=" & iQid

            dt = dl.SqlSelect(sSql)


            If dt.Rows.Count > 0 Then

                dr = dt.Rows(0)

                q_detail.Text = dr("q_detail") & ""
                'q_detail.Text = dr("q_detail") & ""


            End If


            Call reassign()

        End If

    End Sub


    Protected Sub reassign()

        Dim dt As DataTable
        Dim dr As DataRow
        Dim i As Integer
        Dim newItem As ListItem

        Dim sSql1 As String

        dl.SetDBNAME("elrc")

        sSql1 = "Select lib_name, lib_string_id from lib_admin_people order by lib_name"
        dt = dl.SqlSelect(sSql1)
        dr = dt.Rows(0)
        'Response.Write("test")

        lib_drop.Items.Insert(0, New ListItem("Please Select", " "))
        For i = 0 To dt.Rows.Count - 1
            dr = dt.Rows(i)
            newItem = New ListItem
            newItem.Text = dr("lib_name")
            newItem.Value = dr("lib_string_id")
            lib_drop.Items.Add(newItem)
        Next

    End Sub


    Protected Sub btnReassign_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReassign.Click

        Dim arFields(0) As String
        Dim arValues(0) As String

        Dim strUpdate As String

        Dim sKeyId As String

        dl.SetDBNAME("elrc")

        sKeyId = Session("query")

        arFields(0) = "lib_userid"

        arValues(0) = lib_drop.SelectedValue

        strUpdate = dl.SqlUpdate("quest_lib", "q_id", sKeyId, arFields, arValues)

        Session("sReassign") = strUpdate

        Response.Redirect("/ncu_kb/kb_table.aspx?" & strUpdate)


    End Sub
End Class
Imports NCUDataLayer, NCUSecurity

Partial Class admin_dw_edit
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            Dim iDW As String = CInt(Trim(Request.QueryString("key_id")))
            dl.SqlSelect("SELECT title_dw, text_dw FROM elrc_dw_info WHERE key_id = " & iDW)

            Dim dt As DataTable = dl._DT
            Dim dr As DataRow = dl._DR

            If dt.Rows.Count > 0 Then

                title_dw.Text = dr("title_dw") & ""
                Editor1.Content = dr("text_dw") & ""

            End If

        End If
    End Sub

    Protected Sub SubBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SubBtn.Click

        Dim iDW As String = CInt(Trim(Request.QueryString("key_id")))
        Dim sFields() As String = {"title_dw", "text_dw"}
        Dim sValues() As String = {title_dw.Text, Server.HtmlDecode(Editor1.Content)}

        dl.SqlUpdate("elrc_dw_info", "key_id", iDW, sFields, sValues)

        Response.Write("Page Edited. Return to <a href=/admin/dw/ >DW Table</a>")
        Response.End()

    End Sub

    Protected Sub deleteDW_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles deleteDW.Click

        Dim iDW As String = CInt(Trim(Request.QueryString("key_id")))
        dl.SqlDelete("elrc_dw_info", "key_id", iDW)

        Response.Write("Page Deleted. Return to <a href=/admin/dw/ >DW Table</a>")
        Response.End()

    End Sub
End Class

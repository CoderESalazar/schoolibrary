Imports NCUDataLayer
Imports NCUSecurity

Partial Public Class db_index
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        dl.SqlSelect("SELECT db_title, url_id, full_text,cover_id, scholary_id, identify_id, desc_resource, display_id FROM db_index WHERE display_id = '" & True & "' ORDER BY db_title")

        Dim dt As DataTable = dl._DT

        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub

End Class
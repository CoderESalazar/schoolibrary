Imports compass
Imports System.Data.SqlClient
Imports System.Data
Imports compass.Security

Partial Public Class test
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        dl.SetDBNAME("elrc")

        Dim dt As New DataTable

        If Not Page.IsPostBack Then

            dt = dl.SqlSelect("Select lib_event, event_date, event_id from lib_calendar")

            DataGrid1.DataSource = dt
            DataGrid1.DataBind()

            dl.SetDBNAME(Nothing)

        End If
    End Sub



    Private Sub DataGrid1_CancelCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.CancelCommand
        DataGrid1.EditItemIndex = -1
        DataBind()

    End Sub


    Private Sub DataGrid1_DeleteCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.DeleteCommand

        Dim id As Integer = DataGrid1.DataKeys(e.Item.ItemIndex)
        'Dim cn As New SqlConnection
        'cn.ConnectionString = "server=owtserver;database=northwind;uid=sa"
        'cn.Open()
        'Dim cmd As New SqlCommand
        'cmd.CommandText = "delete from products where productid=" & id
        'cmd.Connection = cn
        'cmd.ExecuteNonQuery()
        'cn.Close()
        DataBind()

    End Sub


    Private Sub DataGrid1_EditCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.EditCommand
        DataGrid1.EditItemIndex = e.Item.ItemIndex
        DataBind()
    End Sub

    Private Sub DataGrid1_UpdateCommand(ByVal source As Object, ByVal e As System.Web.UI.WebControls.DataGridCommandEventArgs) Handles DataGrid1.UpdateCommand

        'Dim name As String = CType(e.Item.FindControl("t1"), TextBox).Text
        'Dim id As Integer = DataGrid1.DataKeys(e.Item.ItemIndex)
        'Dim cn As New SqlConnection
        'cn.ConnectionString = "server=owtserver;database=northwind;uid=sa"
        'cn.Open()
        'Dim cmd As New SqlCommand
        'cmd.CommandText = "update products set productname='" & name & "' where productid=" & id
        'cmd.Connection = cn
        'cmd.ExecuteNonQuery()
        'cn.Close()
        'DataGrid1.EditItemIndex = -1
        DataBind()

    End Sub
End Class
Imports compass
Imports compass.security

Partial Public Class event_id
    Inherits System.Web.UI.Page

    Dim dl As New compass.DataLayer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim sSubDomain = (LCase(Split(Request.ServerVariables("SERVER_NAME"), ".")(0)))
        Dim sSql As String = ""
        Dim dt As DataTable
        Dim dr As DataRow
        Dim ds As String = ""


        dl.SetDBNAME("elrc")

        sSql = "Select event_date from lib_calendar where event_id = 1"

        dt = dl.SqlSelect(sSql)

        dr = dt.Rows(0)

        If dt.Rows.Count > 0 Then

            Try

                dt = dl.SqlSelect(sSql)
                If dt.Rows.Count > 0 Then

                    ds = dr("event_date")


                End If
             Catch ex As Exception

                        End Try

             Else
            ds = "sorry charlie"
        End If


        Response.Write(ds)

    End Sub

End Class
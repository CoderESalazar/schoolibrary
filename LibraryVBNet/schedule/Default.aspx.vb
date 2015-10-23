Imports NCUDataLayer
Imports NCUSecurity


Partial Public Class _Default
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        UnSecureThisPage()
        Dim mainNav As UserControls_wucNavBar = Master.NavBar

        mainNav.BuildLibraryMenu()

        If Request.QueryString("strid") <> "" Then

            Dim strUserName As String = Request.QueryString("strid")
            Dim strServName As String = Request.ServerVariables("server_name")

            DropCookie(strUserName, strServName)
        End If

        Dim bPublic = False
        If Len(Trim(CurrentLetmeinUserID())) = 0 Then bPublic = True

        If bPublic = True Then
            Dim iDomain As String = Request.ServerVariables("SERVER_NAME")
            ValidationCheck("UnivPeople", iDomain)

        Else

            If Not Page.IsPostBack Then
                dl.SqlSelect("Select count(lr.event_id) As the_count, lc.event_id, event_date, event_details, " & _
                "attend_details from lib_calendar lc LEFT JOIN lib_registerees lr ON lc.event_id = lr.event_id WHERE event_date > current_timestamp " & _
                "GROUP BY lr.event_id, lc.event_id, lib_event, event_date, event_details, attend_details " & _
                "Having Count(lr.event_id) < 24 order by event_date ASC")

                Dim dt As DataTable = dl._DT
                Dim dr As DataRow = dl._DR

                If dt.Rows.Count = 0 Then

                    Label1.Visible = True
                    Label1.Text = "<font color: red><strong>Sorry! There are no workshops available at this time. Please check again soon. Thank you.</strong></font>"

                Else

                    GridView1.DataSource = dt
                    GridView1.DataBind()

                End If

            End If

        End If
    End Sub
End Class
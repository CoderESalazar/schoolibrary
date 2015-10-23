Imports NCUDataLayer
Imports NCUSecurity


Partial Class admin_Default
    Inherits System.Web.UI.Page

    Dim dl As New NCUDataLayer("elrc")
    Dim dlNcu As New NCUDataLayer()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Dim bPublic = False
        Dim iDomain As String = Request.ServerVariables("SERVER_NAME")

        If UserHasAccessToApplication(dlNcu, CurrentLetmeinUserID(), "LibraryAdmin") Then

            Panel1.Visible = True

        Else

            ValidationCheck("LibraryAdmin", iDomain)

        End If

    End Sub

End Class

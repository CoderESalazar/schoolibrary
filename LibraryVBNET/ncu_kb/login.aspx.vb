Public Partial Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Len((Request.Cookies("letmein"))) > 0 Then

            Response.Redirect("login_check.asp?app=" & Request.QueryString("app") & "&redir=" & Request.QueryString("redir") & "&email=" & Request.Cookies("letmein")("email") & "&password=" & Request.Cookies("letmein")("password"))

        End If

    End Sub

End Class
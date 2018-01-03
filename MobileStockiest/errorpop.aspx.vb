Partial Class MobileStockiest_errorpop
    Inherits System.Web.UI.Page
    Protected mesej As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mesej = Session("popout")
        Session("popout") = ""
    End Sub
End Class

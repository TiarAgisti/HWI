Partial Class MobileStockiest_error1
    Inherits System.Web.UI.Page
    Public error1 As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        error1 = Session("error")
        Session("error") = ""
    End Sub
End Class

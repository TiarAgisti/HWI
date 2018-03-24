
Partial Class MobileStockiest_akt_failed
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Protected manuk, error1 As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        manuk = Request("id")
        If manuk = "" Then
            Response.Redirect("mistake.aspx?message=Kesalahan prosedur")
        End If
        error1 = Request("message")
    End Sub
End Class

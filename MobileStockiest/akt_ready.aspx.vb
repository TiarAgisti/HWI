
Imports System.Data
Partial Class MobileStockiest_akt_ready
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Protected manuk, email, telp, noktp, nma As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        manuk = Request("id")
        If manuk = "" Then
            Response.Redirect("mistake.aspx?message=Kesalahan prosedur")
        End If


        mlSQL = "SELECT emel,kta,telp,ktp,uid FROM member where kta like '" & manuk & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            Response.Redirect("mistake.aspx?message=Session Login anda sudah expired, silahkan melakukan login kembali")
        Else
            email = mlREADER("emel")
            telp = mlREADER("telp")
            noktp = mlREADER("ktp")
            nma = mlREADER("uid")
        End If
        mlREADER.Close()
    End Sub
End Class

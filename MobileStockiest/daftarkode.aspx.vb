Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_daftarkode
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlOBJGF As New IASClass.ucmGeneralFunction
    Protected mlREADER As OleDb.OleDbDataReader
    Protected mlSQL As String
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDATATABLE As DataTable

    Protected tpe, tpi, tpd As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        tpe = Request("tipe")

        If tpe = "AKT" Then
            tpi = "UPG"
            tpd = "REN"
        End If
    End Sub
End Class

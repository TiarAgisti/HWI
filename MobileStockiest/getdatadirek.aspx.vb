Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_getdatadirek
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As New DataTable
    Dim mlDATATABLEDETAIL As New DataTable

    Dim kodedr, namab, telp, hp, tipene, upme As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        Response.ContentType = "text/xml"

        kodedr = Trim(Request.QueryString.Item(1))
        mlSQL = "SELECT kta,uid,telp,hp,tipene_kartu,upme FROM member WHERE kta like '" & kodedr & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            namab = "NOT FOUND"
            telp = "-"
            hp = "-"
            upme = ""
            tipene = ""
        Else
            namab = mlREADER("uid")
            telp = mlREADER("telp")
            hp = mlREADER("hp")
            upme = mlREADER("upme")
            tipene = mlREADER("tipene_kartu")
        End If
        mlREADER.Close()


        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kodedr & "</data>")
        Response.Write("<data>" & namab & "</data>")
        Response.Write("<data>" & hp & "</data>")
        Response.Write("<data>" & upme & "</data>")
        Response.Write("<data>" & tipene & "</data>")
        Response.Write("</xmlresponse>")
    End Sub
End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_getdataup
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim kode, namab, telp, upme, tipene As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.ContentType = "text/xml"

        kode = Trim(Request.QueryString.Item(1))
        mlSQL = "SELECT kta,uid,telp,hp,tipene_kartu,upme FROM member WHERE kta like '" & kode & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namab = "NOT FOUND"
            telp = "-"
            upme = ""
            tipene = ""
        Else
            namab = mlREADER("uid")
            telp = mlREADER("telp")
            upme = mlREADER("upme")
            tipene = mlREADER("tipene_kartu")
        End If
        mlREADER.Close()

        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kode & "</data>")
        Response.Write("<data>" & namab & "</data>")
        Response.Write("<data>" & upme & "</data>")
        Response.Write("<data>" & tipene & "</data>")
        Response.Write("</xmlresponse>")
    End Sub
End Class

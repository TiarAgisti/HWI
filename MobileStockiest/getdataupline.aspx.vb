Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_getdataupline
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim kode, namab, telp, hp As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        Response.ContentType = "text/xml"

        kode = Trim(Request.QueryString.Item(1))

        mlSQL = "SELECT kta,uid,telp,hp FROM member WHERE kta like '" & kode & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            namab = "NOT FOUND"
            telp = "-"
            hp = "-"
        Else
            namab = mlREADER("uid")
            telp = mlREADER("telp")
            hp = mlREADER("hp")
        End If
        mlREADER.Close()

        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kode & "</data>")
        Response.Write("<data>" & namab & "</data>")
        Response.Write("<data>" & hp & "</data>")
        Response.Write("</xmlresponse>")
    End Sub
End Class

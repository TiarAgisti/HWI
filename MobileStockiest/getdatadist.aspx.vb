Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class getdatadist
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim kode, namab As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        Response.ContentType = "text/xml"

        kode = Trim(Request.QueryString.Item(1))
        mlSQL = "SELECT kta,uid FROM member WHERE kta like '" & kode & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namab = "NOT FOUND"
        Else
            namab = mlREADER("uid")
        End If
        mlREADER.Close()

        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kode & "</data>")
        Response.Write("<data>" & namab & "</data>")
        Response.Write("</xmlresponse>")
    End Sub

End Class

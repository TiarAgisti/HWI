Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_getdatamc_perdana
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

    Dim kodedr As String
    Dim sss, namab, alamatb, kotab, kodeposb, propinsib, telpb, hpb, emelb As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.ContentType = "text/xml"
        kodedr = Trim(Request.QueryString.Item(1))
        sss = "T"
        mlSQL = "SELECT kta,uid,telp,hp,alamat,emel,kota,propinsi,negara,kodepos FROM member WHERE kta like '" & kodedr & "' and sta like '" & sss & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            namab = "NOT FOUND"
            Session("namadis_mc") = ""
            Session("nokode_mc") = ""
        Else
            namab = mlREADER("uid")
            Session("namadis_mc") = namab
            Session("nokode_mc") = kodedr
        End If
        mlREADER.Close()

        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kodedr & "</data>")
        Response.Write("<data>" & namab & "</data>")
        Response.Write("<data>" & alamatb & "</data>")
        Response.Write("<data>" & kotab & "</data>")
        Response.Write("<data>" & kodeposb & "</data>")
        Response.Write("<data>" & propinsib & "</data>")
        Response.Write("<data>" & telpb & "</data>")
        Response.Write("<data>" & hpb & "</data>")
        Response.Write("<data>" & emelb & "</data>")
        Response.Write("</xmlresponse>")
    End Sub
End Class

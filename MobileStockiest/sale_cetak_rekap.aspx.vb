Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_cetak_rekap
    Inherits System.Web.UI.Page
    Dim mlOBJGF As New IASClass.ucmGeneralFunction
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Dim pos_area, mypos, loguser, tg1, tpe As String
    Dim g1, g2, g3 As Integer
    Dim jumbayarakt, totcek As Double
    Dim jumbayarprd As Double

    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, tgl1 As String
    Protected totjualakt, tottunai, kembaliakt, totdebit, totcc, totvouc, totjualprd, tottunaiprd, totdebitprd, totccprd, totvoucprd, kembaliprd As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        tgl1 = Request("tgl1")

        If tgl1 = "" Then
            tgl1 = Now.Date
        Else
            tgl1 = tgl1
        End If

        If tgl1 <> "" Then

            g1 = Day(tgl1)
            If Len(g1) = 1 Then
                g1 = "0" + CStr(g1)
            Else
                g1 = g1
            End If
            g2 = Month(tgl1)
            If Len(g2) = 1 Then
                g2 = "0" + CStr(g2)
            Else
                g2 = g2
            End If
            g3 = Year(tgl1)
            tg1 = CStr(g3) + "-" + CStr(g2) + "-" + CStr(g1)

        End If
        PrepareData()
    End Sub

    Sub PrepareData()
        tpe = "AKT"
        mlSQL = "SELECT * FROM rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totjualakt = 0
            tottunai = 0
            totdebit = 0
            totcc = 0
            totcek = 0
            jumbayarakt = 0
            kembaliakt = 0
            totvouc = 0
        Else
            totjualakt = mlREADER("totjual")
            tottunai = mlREADER("tunai")
            totdebit = mlREADER("debit")
            totcc = mlREADER("cc")
            totvouc = mlREADER("cek")
            jumbayarakt = mlREADER("jumbayar")
            kembaliakt = mlREADER("kembalian")
        End If
        mlREADER.Close()

        tpe = "PRD"
        mlSQL = "SELECT * FROM rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totjualprd = 0
            tottunaiprd = 0
            totdebitprd = 0
            totccprd = 0
            totvoucprd = 0
            jumbayarprd = 0
            kembaliprd = 0
        Else
            totjualprd = mlREADER("totjual")
            tottunaiprd = mlREADER("tunai")
            totdebitprd = mlREADER("debit")
            totccprd = mlREADER("cc")
            totvoucprd = mlREADER("cek")
            jumbayarprd = mlREADER("jumbayar")
            kembaliprd = mlREADER("kembalian")
        End If
        mlREADER.Close()
    End Sub
End Class

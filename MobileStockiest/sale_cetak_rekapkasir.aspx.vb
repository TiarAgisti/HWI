Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_cetak_rekapkasir
    Inherits System.Web.UI.Page
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String

    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlQuery, mlQuery2 As String
    Protected mlDR, mlDR2 As OleDb.OleDbDataReader
    Protected mlDT As DataTable

    Dim pos_area, loguser, tipe, noinvo, namadist, nodist, lanjut, nopos, namakon, nokon, kta, noslip, namakasir, tgl1 As String
    Dim tglnya, tgl As Date
    Dim subtot, PV, bv, debit, cc, cek, jumbayar, kembalian As Double
    Protected g1, g2, g3 As Integer

    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, tg1, mypos, kasir As String
    Protected raono, tpe1, tpe2 As String
    Protected gtotdaftar, gtotprd, gtote, gtottunai, gtotdebit, gtotcc, gtoto, gtotvouc, totjualprd, totjualakt, tottunai, totdebit, totcc, totvouc, totkembali, tunai As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        tipe = Request("tipe")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If
        noinvo = Request("noinvoice")

        PrepareData()
    End Sub

    Sub PrepareData()
        mlSQL = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' and noinvoice like '" & noinvo & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjut = "F"
        Else
            lanjut = "T"
            nopos = mlREADER("nopos")
            namakon = mlREADER("namadist")
            nokon = mlREADER("nodist")
            namadist = mlREADER("namadist")
            nodist = mlREADER("nodist")
            kta = mlREADER("kta")
            tgl = mlREADER("tgl")
            noslip = mlREADER("noinvoice")
            subtot = mlREADER("subtot")
            PV = mlREADER("totpv")
            bv = mlREADER("totbv")
            tunai = mlREADER("tunai")
            debit = mlREADER("debit")
            cc = mlREADER("cc")
            cek = mlREADER("cek")
            jumbayar = mlREADER("jumbayar")
            kembalian = mlREADER("kembalian")
            namakasir = mlREADER("kta")
            tglnya = mlREADER("tgl")
        End If
        mlREADER.Close()

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
    End Sub
End Class

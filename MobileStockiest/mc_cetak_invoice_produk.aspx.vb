Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_cetak_invoice_produk
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Dim pos_area, mypos, loguser, kelasdc, indukdc, indukmc, idstk2, namaperus, alamatperus, kotaperus, kodeposperus, telpperus, asalnye As String

    Dim tglnya As Date
    Dim lanjut, nopos, nomce, nokode, nama, noslip, jumdisk As String
    Dim no11, kdbr11, namabr11, no12, kdbr12, namabr12, no13, kdbr13, namabr13, no14, kdbr14, namabr14 As String
    Dim subtot, gtot, PV, bv, diskon, jumbr1 As Double
    Dim bv1, jumbr2, bv2, jumbr3, bv3, jumbr4, bv4, jumbr5, bv5, jumbr6, bv6 As Double
    Dim jumbr7, bv7, jumbr8, bv8, jumbr9, bv9, jumbr10, bv10, jumbr11, harga11, pv11, bv11, subtot11 As Double
    Dim jumbr12, harga12, pv12, bv12, subtot12, jumbr13, harga13, pv13, bv13, subtot13, jumbr14, harga14, pv14, bv14, subtot14 As Double
    Dim totpv11, totpv12, totpv13, totpv14 As Double
    Dim totbv, totbv1, totbv2, totbv3, totbv4, totbv5, totbv6, totbv7, totbv8, totbv9, totbv10, totbv11, totbv12, totbv13, totbv14 As Double
    Dim jume, harga As Double
    Dim pir, kepiro As Integer

    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, asale, nopajak, noinvo, nomc, namamc, namauser, namakasir As String
    Protected no1, kdbr1, namabr1, no2, kdbr2, namabr2, no3, kdbr3, namabr3, no4, kdbr4, namabr4, no5, kdbr5, namabr5, no6, kdbr6, namabr6, no7, kdbr7, namabr7, no8, kdbr8, namabr8, no9, kdbr9, namabr9, no10, kdbr10, namabr10 As String
    Protected tgl As Date
    Protected jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10 As Double
    Protected harga1, harga2, harga3, harga4, harga5, harga6, harga7, harga8, harga9, harga10 As Double
    Protected subtot1, subtot2, subtot3, subtot4, subtot5, subtot6, subtot7, subtot8, subtot9, subtot10 As Double
    Protected pv1, pv2, pv3, pv4, pv5, pv6, pv7, pv8, pv9, pv10 As Double
    Protected totpv1, totpv2, totpv3, totpv4, totpv5, totpv6, totpv7, totpv8, totpv9, totpv10 As Double
    Protected totjum, totpv, stot, tunai, debit, cc, vouc, jumbayar, kembalian As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        'idstk2 = "B-000"
        idstk2 = indukdc
        mlSQL = "SELECT * FROM tabdesc_stockist where nopos like  '" & idstk2 & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namaperus = ""
            alamatperus = ""
            kotaperus = ""
            Session("pop") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            namaperus = mlREADER("nama")
            alamatperus = mlREADER("alamat")
            kotaperus = mlREADER("kota")
            kodeposperus = mlREADER("kodepos")
            telpperus = mlREADER("telp")
        End If
        mlREADER.Close()

        noinvo = Request("noinvoice")
        asale = Session("asalnye")
        asalnye = Request("asal")

        If asalnye <> "" Then
            asale = asalnye
        Else
            asale = asale
        End If

        PrepareData()
    End Sub

    Sub PrepareData()
        mlSQL = "SELECT * FROM fax_order_mc_head where nomc like '" & mypos & "' and noinvo like '" & noinvo & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjut = "F"
        Else
            lanjut = "T"
            nopos = mlREADER("nopos")
            nomc = mlREADER("nomc")
            tgl = mlREADER("tgl")
            noslip = mlREADER("noinvo")
            subtot = mlREADER("subtot")
            stot = mlREADER("subtot")
            gtot = mlREADER("gtot")
            PV = mlREADER("totpv")
            bv = 0
            jumdisk = mlREADER("diskonamt")
            tunai = mlREADER("tunai")
            debit = mlREADER("debit")
            cc = mlREADER("cc")
            vouc = mlREADER("cek")
            jumbayar = mlREADER("jumbayar")
            kembalian = mlREADER("kembalian")
            namakasir = mlREADER("kta")
            tglnya = mlREADER("tgl")
            nopajak = mlREADER("nopajak")
            diskon = mlREADER("diskon")
        End If
        mlREADER.Close()

        pir = Len(nomc)
        If pir = 10 Then
            nomce = Right(nomc, 7)
        Else
            nomce = Right(nomc, 8)
        End If

        mlSQL = "SELECT uid FROM member where kta like '" & nomce & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namamc = "-"
        Else
            namamc = mlREADER("uid")
        End If
        mlREADER.Close()

        mlSQL = "SELECT kta FROM tabdesc_stockist_user where nopos like '" & nomc & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namauser = "-"
        Else
            namauser = mlREADER("kta")
        End If
        mlREADER.Close()

        kepiro = 0

        no1 = ""
        kdbr1 = ""
        namabr1 = ""
        jumbr1 = 0
        harga1 = 0
        pv1 = 0
        bv1 = 0
        subtot1 = 0
        no2 = ""
        kdbr2 = ""
        namabr2 = ""
        jumbr2 = 0
        harga2 = 0
        pv2 = 0
        bv2 = 0
        subtot2 = 0
        no3 = ""
        kdbr3 = ""
        namabr3 = ""
        jumbr3 = 0
        harga3 = 0
        pv3 = 0
        bv3 = 0
        subtot3 = 0
        no4 = ""
        kdbr4 = ""
        namabr4 = ""
        jumbr4 = 0
        harga4 = 0
        pv4 = 0
        bv4 = 0
        subtot4 = 0
        no5 = ""
        kdbr5 = ""
        namabr5 = ""
        jumbr5 = 0
        harga5 = 0
        pv5 = 0
        bv5 = 0
        subtot5 = 0
        no6 = ""
        kdbr6 = ""
        namabr6 = ""
        jumbr6 = 0
        harga6 = 0
        pv6 = 0
        bv6 = 0
        subtot6 = 0
        no7 = ""
        kdbr7 = ""
        namabr7 = ""
        jumbr7 = 0
        harga7 = 0
        pv7 = 0
        bv7 = 0
        subtot7 = 0
        no8 = ""
        kdbr8 = ""
        namabr8 = ""
        jumbr8 = 0
        harga8 = 0
        pv8 = 0
        bv8 = 0
        subtot8 = 0
        no9 = ""
        kdbr9 = ""
        namabr9 = ""
        jumbr9 = 0
        harga9 = 0
        pv9 = 0
        bv9 = 0
        subtot9 = 0
        no10 = ""
        kdbr10 = ""
        namabr10 = ""
        jumbr10 = 0
        harga10 = 0
        pv10 = 0
        bv10 = 0
        subtot10 = 0
        no11 = ""
        kdbr11 = ""
        namabr11 = ""
        jumbr11 = 0
        harga11 = 0
        pv11 = 0
        bv11 = 0
        subtot11 = 0
        no12 = ""
        kdbr12 = ""
        namabr12 = ""
        jumbr12 = 0
        harga12 = 0
        pv12 = 0
        bv12 = 0
        subtot12 = 0
        no13 = ""
        kdbr13 = ""
        namabr13 = ""
        jumbr13 = 0
        harga13 = 0
        pv13 = 0
        bv13 = 0
        subtot13 = 0
        no14 = ""
        kdbr14 = ""
        namabr14 = ""
        jumbr14 = 0
        harga14 = 0
        pv14 = 0
        bv14 = 0
        subtot14 = 0

        totpv1 = 0
        totbv1 = 0
        totpv2 = 0
        totbv2 = 0
        totpv3 = 0
        totbv3 = 0
        totpv4 = 0
        totbv4 = 0
        totpv5 = 0
        totbv5 = 0
        totpv6 = 0
        totbv6 = 0
        totpv7 = 0
        totbv7 = 0
        totpv8 = 0
        totbv8 = 0
        totpv9 = 0
        totbv9 = 0
        totpv10 = 0
        totbv10 = 0
        totpv11 = 0
        totbv11 = 0
        totpv12 = 0
        totbv12 = 0
        totpv13 = 0
        totbv13 = 0
        totpv14 = 0
        totbv14 = 0

        mlSQL = "SELECT * FROM fx_order_mc_det where noinvo like '" & noinvo & "' and nomc like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlDATATABLE = New DataTable
            mlDATATABLE.Load(mlREADER)
            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                kepiro = kepiro + 1
                nokode = mlDATATABLE.Rows(aaaeqSSS)("kode")
                jume = mlDATATABLE.Rows(aaaeqSSS)("jumlah")
                nama = mlDATATABLE.Rows(aaaeqSSS)("nama")
                harga = mlDATATABLE.Rows(aaaeqSSS)("harga")
                PV = mlDATATABLE.Rows(aaaeqSSS)("pv")
                bv = 0
                subtot = mlDATATABLE.Rows(aaaeqSSS)("subtot")

                If kepiro = 1 Then
                    no1 = "1."
                    kdbr1 = nokode
                    namabr1 = nama
                    jumlah1 = jume
                    harga1 = harga
                    pv1 = PV
                    bv1 = bv
                    subtot1 = subtot
                    totpv1 = pv1 * jumlah1
                    totbv1 = bv1 * jumlah1
                End If

                If kepiro = 2 Then
                    no2 = "2."
                    kdbr2 = nokode
                    namabr2 = nama
                    jumlah2 = jume
                    harga2 = harga
                    pv2 = PV
                    bv2 = bv
                    subtot2 = subtot
                    totpv2 = pv2 * jumlah2
                    totbv2 = bv2 * jumlah2
                End If

                If kepiro = 3 Then
                    no3 = "3."
                    kdbr3 = nokode
                    namabr3 = nama
                    jumlah3 = jume
                    harga3 = harga
                    pv3 = PV
                    bv3 = bv
                    subtot3 = subtot
                    totpv3 = pv3 * jumlah3
                    totbv3 = bv3 * jumlah3
                End If

                If kepiro = 4 Then
                    no4 = "4."
                    kdbr4 = nokode
                    namabr4 = nama
                    jumlah4 = jume
                    harga4 = harga
                    pv4 = PV
                    bv4 = bv
                    subtot4 = subtot
                    totpv4 = pv4 * jumlah4
                    totbv4 = bv4 * jumlah4
                End If

                If kepiro = 5 Then
                    no5 = "5."
                    kdbr5 = nokode
                    namabr5 = nama
                    jumlah5 = jume
                    harga5 = harga
                    pv5 = PV
                    bv5 = bv
                    subtot5 = subtot
                    totpv5 = pv5 * jumlah5
                    totbv5 = bv5 * jumlah5
                End If

                If kepiro = 6 Then
                    no6 = "6."
                    kdbr6 = nokode
                    namabr6 = nama
                    jumlah6 = jume
                    harga6 = harga
                    pv6 = PV
                    bv6 = bv
                    subtot6 = subtot
                    totpv6 = pv6 * jumlah6
                    totbv6 = bv6 * jumlah6
                End If

                If kepiro = 7 Then
                    no7 = "7."
                    kdbr7 = nokode
                    namabr7 = nama
                    jumlah7 = jume
                    harga7 = harga
                    pv7 = PV
                    bv7 = bv
                    subtot7 = subtot
                    totpv7 = pv7 * jumlah7
                    totbv7 = bv7 * jumlah7
                End If

                If kepiro = 8 Then
                    no8 = "8."
                    kdbr8 = nokode
                    namabr8 = nama
                    jumlah8 = jume
                    harga8 = harga
                    pv8 = PV
                    bv8 = bv
                    subtot8 = subtot
                    totpv8 = pv8 * jumlah8
                    totbv8 = bv8 * jumlah8
                End If

                If kepiro = 9 Then
                    no9 = "9."
                    kdbr9 = nokode
                    namabr9 = nama
                    jumlah9 = jume
                    harga9 = harga
                    pv9 = PV
                    bv9 = bv
                    subtot9 = subtot
                    totpv9 = pv9 * jumlah9
                    totbv9 = bv9 * jumlah9
                End If

                If kepiro = 10 Then
                    no10 = "10."
                    kdbr10 = nokode
                    namabr10 = nama
                    jumlah10 = jume
                    harga10 = harga
                    pv10 = PV
                    bv10 = bv
                    subtot10 = subtot
                    totpv10 = pv10 * jumlah10
                    totbv10 = bv10 * jumlah10
                End If
            Next
        End If
        mlREADER.Close()

        totpv = totpv1 + totpv2 + totpv3 + totpv4 + totpv5 + totpv6 + totpv7 + totpv8 + totpv9 + totpv10
        totbv = totbv1 + totbv2 + totbv3 + totbv4 + totbv5 + totbv6 + totbv7 + totbv8 + totbv9 + totbv10
        totjum = jumlah1 + jumlah2 + jumlah3 + jumlah4 + jumlah5 + jumlah6 + jumlah7 + jumlah8 + jumlah9 + jumlah10
        'gtot = subtot1+subtot2+subtot3+subtot4+subtot5+subtot6+subtot7+subtot8+subtot9+subtot10

    End Sub
End Class


Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_cetak_invoice_prd_autosave
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Dim pos_area, mypos, loguser, tipe, noinvo, namadist, namadist1, namakasir, nodist, nodist1, periodelama, lanjut, nopos, namakon, nokon, nokon1, tpe As String
    Dim kta, noslip, nopajak, judul, noalok, namalok, autoupgrade, nokode, nama, adanomor, adanomortg As String
    Dim tglnya, tgl As Date
    Dim efekbulan, efektahun, pvbulanan, efekbulan2, efektahun2, subtot, PV, bv, tunai, debit, cc, vouc, jumbayar, kembalian, alokbulan, aloktahun, kepiro, jume, harga, noke As Double
    Dim no1, no2, no3, no4, no5, no6, no7, kdbr1, kdbr2, kdbr3, kdbr4, kdbr5, kdbr6, kdbr7, namabr1, namabr2, namabr3, namabr4, namabr5, namabr6, namabr7 As String
    Dim jumbr1, jumbr2, jumbr3, jumbr4, jumbr5, jumbr6, jumbr7, harga1, harga2, harga3, harga4, harga5, harga6, harga7 As Double
    Dim pv1, pv2, pv3, pv4, pv5, pv6, pv7, bv1, bv2, bv3, bv4, bv5, bv6, bv7, gtot, subtot1, subtot2, subtot3, subtot4, subtot5, subtot6, subtot7 As Double
    Dim totpv, totpv1, totpv2, totpv3, totpv4, totpv5, totpv6, totpv7, totbv, totbv1, totbv2, totbv3, totbv4, totbv5, totbv6, totbv7 As Double
    Dim totjum, jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7 As Double
    Dim noundi1, noundi2, noundi3, noundi4, noundi5, noundi6, noundi7, noundi8, noundi9, noundi10, noundi11, noundi12, noundi13, noundi14, noundi15, noundi16, noundi17, noundi18, noundi19, noundi20 As Long
    Dim noundi21, noundi22, noundi23, noundi24, noundi25, noundi26, noundi27, noundi28, noundi29, noundi30, noundi31, noundi32, noundi33, noundi34, noundi35, noundi36, noundi37, noundi38, noundi39, noundi40 As Long
    Dim noundi41, noundi42, noundi43, noundi44, noundi45, noundi46, noundi47, noundi48, noundi49, noundi50, noundi51, noundi52, noundi53, noundi54, noundi55, noundi56, noundi57, noundi58, noundi59, noundi60 As Long
    Dim noundi61, noundi62, noundi63, noundi64, noundi65, noundi66, noundi67, noundi68, noundi69, noundi70, noundi71, noundi72, noundi73, noundi74, noundi75, noundi76, noundi77, noundi78, noundi79, noundi80, noundi81 As Long
    Dim tgundi1, tgundi2, tgundi3, tgundi4, tgundi5, tgundi6, tgundi7, tgundi8, tgundi9, tgundi10, tgundi11, tgundi12, tgundi13, tgundi14, tgundi15, tgundi16, tgundi17, tgundi18, tgundi19, tgundi20 As Long
    Dim tgundi21, tgundi22, tgundi23, tgundi24, tgundi25, tgundi26, tgundi27, tgundi28, tgundi29, tgundi30, tgundi31, tgundi32, tgundi33, tgundi34, tgundi35, tgundi36, tgundi37, tgundi38, tgundi39, tgundi40 As Long
    Dim tgundi41, tgundi42, tgundi43, tgundi44, tgundi45, tgundi46, tgundi47, tgundi48, tgundi49, tgundi50, tgundi51, tgundi52, tgundi53, tgundi54, tgundi55, tgundi56, tgundi57, tgundi58, tgundi59, tgundi60 As Long
    Dim tgundi61, tgundi62, tgundi63, tgundi64, tgundi65, tgundi66, tgundi67, tgundi68, tgundi69, tgundi70, tgundi71, tgundi72, tgundi73, tgundi74, tgundi75, tgundi76, tgundi77, tgundi78, tgundi79, tgundi80, tgundi81 As Long

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
        NomerUndianCMP()
        NomerUndianTopG2()
    End Sub

    Sub PrepareData()
        mlSQL = "SELECT TOP 1 * FROM bns_depositdana where nopos like '" & mypos & "' and noinvo like '" & noinvo & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            efekbulan = mlREADER("bulan")
            efektahun = mlREADER("tahun")
            periodelama = mlREADER("periode")
            pvbulanan = mlREADER("pv")
        End If
        mlREADER.Close()

        mlSQL = "SELECT TOP 1 * FROM bns_depositdana where nopos like '" & mypos & "' and noinvo like '" & noinvo & "' order by id desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            efekbulan2 = mlREADER("bulan")
            efektahun2 = mlREADER("tahun")
        End If
        mlREADER.Close()

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
            tpe = mlREADER("tipe")
            nokon1 = mlREADER("tupokta")
            namadist1 = mlREADER("tuponama")
            nodist1 = mlREADER("tupokta")
            kta = mlREADER("kta")
            tgl = mlREADER("tgl")
            noslip = mlREADER("noinvoice")
            subtot = mlREADER("subtot")
            PV = mlREADER("totpv")
            bv = mlREADER("totbv")
            tunai = mlREADER("tunai")
            debit = mlREADER("debit")
            cc = mlREADER("cc")
            vouc = mlREADER("cek")
            jumbayar = mlREADER("jumbayar")
            kembalian = mlREADER("kembalian")
            namakasir = mlREADER("kta")
            tglnya = mlREADER("tgl")
            nopajak = mlREADER("nopajak")
            alokbulan = mlREADER("alokbulan")
            aloktahun = mlREADER("aloktahun")
        End If
        mlREADER.Close()

        judul = "INVOICE PENJUALAN DEPOSIT POINT"
        nodist = nodist
        namadist = namadist
        nokon = nokon
        namakon = namadist
        noalok = ""
        namalok = ""

        mlSQL = "SELECT * FROM autoupgrade where kta like '" & nokon & "' and noinvo like '" & noinvo & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            autoupgrade = "F"
        Else
            autoupgrade = "T"
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

        mlSQL = "SELECT * FROM st_sale_prd_det where noinvoice like '" & noinvo & "' and nopos like '" & mypos & "'"
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
                bv = mlDATATABLE.Rows(aaaeqSSS)("bv")
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
            Next
        End If
        mlREADER.Close()

        totpv = totpv1 + totpv2 + totpv3 + totpv4 + totpv5 + totpv6 + totpv7
        totbv = totbv1 + totbv2 + totbv3 + totbv4 + totbv5 + totbv6 + totbv7
        totjum = jumlah1 + jumlah2 + jumlah3 + jumlah4 + jumlah5 + jumlah6 + jumlah7
        gtot = subtot1 + subtot2 + subtot3 + subtot4 + subtot5 + subtot6 + subtot7
    End Sub

    Sub NomerUndianCMP()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' NOMOR UNDIAN CMP
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        noke = 0
        noundi1 = ""
        noundi2 = ""
        noundi3 = ""
        noundi4 = ""
        noundi5 = ""
        noundi6 = ""
        noundi7 = ""
        noundi8 = ""
        noundi9 = ""
        noundi10 = ""
        noundi11 = ""
        noundi12 = ""
        noundi13 = ""
        noundi14 = ""
        noundi15 = ""
        noundi16 = ""
        noundi17 = ""
        noundi18 = ""
        noundi19 = ""
        noundi20 = ""
        noundi21 = ""
        noundi22 = ""
        noundi23 = ""
        noundi24 = ""
        noundi25 = ""
        noundi26 = ""
        noundi27 = ""
        noundi28 = ""
        noundi29 = ""
        noundi30 = ""
        noundi31 = ""
        noundi32 = ""
        noundi33 = ""
        noundi34 = ""
        noundi35 = ""
        noundi36 = ""
        noundi37 = ""
        noundi38 = ""
        noundi39 = ""
        noundi40 = ""
        noundi41 = ""
        noundi42 = ""
        noundi43 = ""
        noundi44 = ""
        noundi45 = ""
        noundi46 = ""
        noundi47 = ""
        noundi48 = ""
        noundi49 = ""
        noundi50 = ""
        noundi51 = ""
        noundi52 = ""
        noundi53 = ""
        noundi54 = ""
        noundi55 = ""
        noundi56 = ""
        noundi57 = ""
        noundi58 = ""
        noundi59 = ""
        noundi60 = ""
        noundi61 = ""
        noundi62 = ""
        noundi63 = ""
        noundi64 = ""
        noundi65 = ""
        noundi66 = ""
        noundi67 = ""
        noundi68 = ""
        noundi69 = ""
        noundi70 = ""
        noundi71 = ""
        noundi72 = ""
        noundi73 = ""
        noundi74 = ""
        noundi75 = ""
        noundi76 = ""
        noundi77 = ""
        noundi78 = ""
        noundi79 = ""
        noundi80 = ""
        adanomor = "F"
        rsALL.Open "SELECT * FROM undi_cmp where kta like '" & nokon&"' and noinvo like '"&noslip&"'", connALL, 3, 3

    If rsALL.eof <> True Then
            If goneqkmf <> 0 Then
                For aaeeqkmf = 1 To goneqkmf
                    If rsALL.eof = True Then Exit For
                    rsALL.movenext
                Next
            Else
            End If

            For aaaeqkmf = 1 To 500
                If rsALL.eof = True Then Exit For

                If noke = 0 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi1 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 1 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi2 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 2 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi3 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 3 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi4 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 4 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi5 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 5 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi6 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 6 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi7 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 7 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi8 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 8 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi9 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 9 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi10 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 10 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi11 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 11 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi12 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 12 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi13 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 13 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi14 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 14 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi15 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 15 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi16 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 16 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi17 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 17 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi18 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 18 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi19 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 19 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi20 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 20 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi21 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 21 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi22 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 22 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi23 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 23 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi24 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 24 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi25 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 25 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi26 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 26 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi27 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 27 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi28 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 28 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi29 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 29 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi30 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 30 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi31 = rsALL("id") + 100000
                    rsALL.update
                    adanomor = "T"
                End If
                If noke = 31 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi32 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 32 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi33 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 33 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi34 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 34 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi35 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 35 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi36 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 36 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi37 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 37 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi38 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 38 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi39 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 39 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi40 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 40 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi41 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 41 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi42 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 42 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi43 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 43 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi44 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 44 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi45 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 45 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi46 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 46 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi47 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 47 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi48 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 48 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi49 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 49 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi50 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 50 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi51 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 51 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi52 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 52 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi53 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 53 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi54 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 54 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi55 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 55 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi56 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 56 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi57 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 57 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi58 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 58 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi59 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 59 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi60 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 60 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi61 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 61 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi62 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 62 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi63 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 63 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi64 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 64 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi65 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 65 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi66 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 66 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi67 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 67 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi68 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 68 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi69 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 69 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi70 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 70 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi71 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 71 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi72 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 72 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi73 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 73 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi74 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 74 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi75 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 75 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi76 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 76 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi77 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 77 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi78 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 78 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi79 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 79 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi80 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 80 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    noundi81 = rsALL("id") + 100000
                    rsALL.update
                End If
                rsALL.movenext
                noke = noke + 1
            Next
        End If
        If rsALL.eof = True Then
            aaaaqkmf = 1
        End If
        rsALL.Close
    End Sub

    Sub NomerUndianTopG2()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' NOMOR UNDIAN TOP G2
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        noke = 0
        tgundi1 = ""
        tgundi2 = ""
        tgundi3 = ""
        tgundi4 = ""
        tgundi5 = ""
        tgundi6 = ""
        tgundi7 = ""
        tgundi8 = ""
        tgundi9 = ""
        tgundi10 = ""
        tgundi11 = ""
        tgundi12 = ""
        tgundi13 = ""
        tgundi14 = ""
        tgundi15 = ""
        tgundi16 = ""
        tgundi17 = ""
        tgundi18 = ""
        tgundi19 = ""
        tgundi20 = ""
        tgundi21 = ""
        tgundi22 = ""
        tgundi23 = ""
        tgundi24 = ""
        tgundi25 = ""
        tgundi26 = ""
        tgundi27 = ""
        tgundi28 = ""
        tgundi29 = ""
        tgundi30 = ""
        tgundi31 = ""
        tgundi32 = ""
        tgundi33 = ""
        tgundi34 = ""
        tgundi35 = ""
        tgundi36 = ""
        tgundi37 = ""
        tgundi38 = ""
        tgundi39 = ""
        tgundi40 = ""
        tgundi41 = ""
        tgundi42 = ""
        tgundi43 = ""
        tgundi44 = ""
        tgundi45 = ""
        tgundi46 = ""
        tgundi47 = ""
        tgundi48 = ""
        tgundi49 = ""
        tgundi50 = ""
        tgundi51 = ""
        tgundi52 = ""
        tgundi53 = ""
        tgundi54 = ""
        tgundi55 = ""
        tgundi56 = ""
        tgundi57 = ""
        tgundi58 = ""
        tgundi59 = ""
        tgundi60 = ""
        tgundi61 = ""
        tgundi62 = ""
        tgundi63 = ""
        tgundi64 = ""
        tgundi65 = ""
        tgundi66 = ""
        tgundi67 = ""
        tgundi68 = ""
        tgundi69 = ""
        tgundi70 = ""
        tgundi71 = ""
        tgundi72 = ""
        tgundi73 = ""
        tgundi74 = ""
        tgundi75 = ""
        tgundi76 = ""
        tgundi77 = ""
        tgundi78 = ""
        tgundi79 = ""
        tgundi80 = ""
        adanomortg = "F"
        rsALL.Open "SELECT * FROM undi_topg where kta like '" & nokon&"' and noinvo like '"&noslip&"'", connALL, 3, 3

    If rsALL.eof <> True Then
            If goneqkmf <> 0 Then
                For aaeeqkmf = 1 To goneqkmf
                    If rsALL.eof = True Then Exit For
                    rsALL.movenext
                Next
            Else
            End If

            For aaaeqkmf = 1 To 500
                If rsALL.eof = True Then Exit For

                If noke = 0 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi1 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 1 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi2 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 2 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi3 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 3 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi4 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 4 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi5 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 5 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi6 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 6 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi7 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 7 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi8 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 8 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi9 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 9 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi10 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 10 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi11 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 11 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi12 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 12 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi13 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 13 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi14 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 14 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi15 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 15 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi16 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 16 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi17 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 17 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi18 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 18 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi19 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 19 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi20 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 20 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi21 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 21 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi22 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 22 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi23 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 23 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi24 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 24 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi25 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 25 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi26 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 26 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi27 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 27 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi28 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 28 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi29 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 29 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi30 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 30 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi31 = rsALL("id") + 100000
                    rsALL.update
                    adanomortg = "T"
                End If
                If noke = 31 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi32 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 32 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi33 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 33 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi34 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 34 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi35 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 35 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi36 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 36 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi37 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 37 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi38 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 38 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi39 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 39 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi40 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 40 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi41 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 41 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi42 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 42 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi43 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 43 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi44 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 44 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi45 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 45 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi46 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 46 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi47 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 47 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi48 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 48 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi49 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 49 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi50 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 50 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi51 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 51 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi52 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 52 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi53 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 53 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi54 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 54 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi55 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 55 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi56 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 56 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi57 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 57 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi58 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 58 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi59 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 59 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi60 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 60 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi61 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 61 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi62 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 62 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi63 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 63 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi64 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 64 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi65 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 65 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi66 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 66 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi67 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 67 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi68 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 68 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi69 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 69 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi70 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 70 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi71 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 71 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi72 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 72 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi73 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 73 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi74 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 74 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi75 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 75 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi76 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 76 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi77 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 77 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi78 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 78 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi79 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 79 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi80 = rsALL("id") + 100000
                    rsALL.update
                End If
                If noke = 80 Then
                    rsALL.update
                    rsALL("nomornya") = rsALL("id") + 100000
                    tgundi81 = rsALL("id") + 100000
                    rsALL.update
                End If
                rsALL.movenext
                noke = noke + 1
            Next
        End If
        If rsALL.eof = True Then
            aaaaqkmf = 1
        End If
        rsALL.Close
    End Sub
End Class

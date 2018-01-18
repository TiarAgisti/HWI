Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_prd_dist_inv
    Inherits System.Web.UI.Page
    Dim mlOBJGF As New IASClass.ucmGeneralFunction
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Dim pos_area, mypos, loguser, tipe, kelasdc, indukdc, indukmc, mupis, novi, autoupe, namadist, nodist, nokode, nama As String

    Dim lanjut, nopos, nokon1, namadist1, nodist1, kta, noslip, judul, kdd1, kdd2, undi, ss As String
    Dim subtot, PV, bv, totbruto, kepiro As Double
    Dim jumbr1, jumbr2, jumbr3, jumbr4, jumbr5, jumbr6, jumbr7 As Double
    Dim bv1, bv2, bv3, bv4, bv5, bv6, bv7 As Double
    Dim totbv1, totbv2, totbv3, totbv4, totbv5, totbv6, totbv7 As Double
    Dim jume, harga, totbv, mbahpv As Double
    Dim noke, xcs, ke As Double

    Protected noundi0, noundi1, noundi2, noundi3, noundi4, noundi5, noundi6, noundi7, noundi8, noundi9, noundi10, noundi11, noundi12, noundi13, noundi14, noundi15, noundi16, noundi17, noundi18, noundi19, noundi20 As Long
    Protected noundi21, noundi22, noundi23, noundi24, noundi25, noundi26, noundi27, noundi28, noundi29, noundi30, noundi31, noundi32, noundi33, noundi34, noundi35, noundi36, noundi37, noundi38, noundi39, noundi40 As Long
    Protected noundi41, noundi42, noundi43, noundi44, noundi45, noundi46, noundi47, noundi48, noundi49, noundi50, noundi51, noundi52, noundi53, noundi54, noundi55, noundi56, noundi57, noundi58, noundi59, noundi60 As Long
    Protected noundi61, noundi62, noundi63, noundi64, noundi65, noundi66, noundi67, noundi68, noundi69, noundi70, noundi71, noundi72, noundi73, noundi74, noundi75, noundi76, noundi77, noundi78, noundi79, noundi80, noundi81 As Long
    Protected tgundi1, tgundi2, tgundi3, tgundi4, tgundi5, tgundi6, tgundi7, tgundi8, tgundi9, tgundi10, tgundi11, tgundi12, tgundi13, tgundi14, tgundi15, tgundi16, tgundi17, tgundi18, tgundi19, tgundi20 As Long
    Protected tgundi21, tgundi22, tgundi23, tgundi24, tgundi25, tgundi26, tgundi27, tgundi28, tgundi29, tgundi30, tgundi31, tgundi32, tgundi33, tgundi34, tgundi35, tgundi36, tgundi37, tgundi38, tgundi39, tgundi40 As Long
    Protected tgundi41, tgundi42, tgundi43, tgundi44, tgundi45, tgundi46, tgundi47, tgundi48, tgundi49, tgundi50, tgundi51, tgundi52, tgundi53, tgundi54, tgundi55, tgundi56, tgundi57, tgundi58, tgundi59, tgundi60 As Long
    Protected tgundi61, tgundi62, tgundi63, tgundi64, tgundi65, tgundi66, tgundi67, tgundi68, tgundi69, tgundi70, tgundi71, tgundi72, tgundi73, tgundi74, tgundi75, tgundi76, tgundi77, tgundi78, tgundi79, tgundi80, tgundi81 As Long

    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, nopajak, noinvo, nokon, namakon, noalok, namalok, tpe, namakasir, ketxtra, autoupgrade, adanomor, adanomortg As String
    Protected alokbulan, aloktahun, totjum, totpv, pvmbah, gtot, jumdisk, tunai, debit, cc, vouc, jumbayar, kembalian, subtote As Double
    Protected tglnya, tgl As Date
    Protected no1, no2, no3, no4, no5, no6, no7 As String
    Protected kdbr1, kdbr2, kdbr3, kdbr4, kdbr5, kdbr6, kdbr7, namabr1, namabr2, namabr3, namabr4, namabr5, namabr6, namabr7 As String
    Protected jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, pv1, pv2, pv3, pv4, pv5, pv6, pv7 As Double
    Protected totpv1, totpv2, totpv3, totpv4, totpv5, totpv6, totpv7, harga1, harga2, harga3, harga4, harga5, harga6, harga7, subtot1, subtot2, subtot3, subtot4, subtot5, subtot6, subtot7 As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        tipe = Request("tipe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        indukmc = Session.Contents("indukmc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session.Contents("indukmc") = indukmc
        End If


        Session("nosesi") = ""
        noinvo = Session("noinvoice")
        mupis = Session("mypus")
        novi = Session("noinvoice")
        Session("noinvoice") = noinvo
        autoupe = Session("autoupe")
        Session("autoupe") = ""

        PrepareData()
        KeteranganExtraPV()
        NomorUndian()
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
            jumdisk = mlREADER("diskon")
            totbruto = mlREADER("totbruto")
            subtote = mlREADER("subtot")
        End If
        mlREADER.Close()

        If UCase(tpe) = "TOPUP" Then
            judul = "INVOICE PENJUALAN PRODUK TOP UP"
            noalok = nokon
            namalok = namakon
            nodist = nodist1
            namadist = namadist1
            nokon = nokon1
            namakon = namadist1
        Else
            judul = "INVOICE PENJUALAN PRODUK"
            nodist = nodist
            namadist = namadist
            nokon = nokon
            namakon = namadist
            noalok = ""
            namalok = ""
        End If

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

    Sub KeteranganExtraPV()
        If ((alokbulan = 11 And aloktahun = 2010) Or (alokbulan = 12 And aloktahun = 2010)) Then
            kdd1 = "MU"
            kdd2 = "PG"
            ketxtra = ""
            mbahpv = 0
            pvmbah = 0

            mlSQL = "SELECT sum(jumlah) as vjumlah FROM st_sale_prd_det where noinvoice like '" & noinvo & "' and nopos like '" & mypos & "' and (kode like '" & kdd1 & "' or kode like '" & kdd2 & "')"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                ketxtra = ""
                mbahpv = 0
                pvmbah = 0
            Else
                mbahpv = 0
                pvmbah = mlREADER("vjumlah")
            End If
            mlREADER.Close()
        Else
            mbahpv = 0
            pvmbah = 0
            ketxtra = ""
        End If

        If IsDBNull(pvmbah) = False Then
            pvmbah = pvmbah * 10
            mbahpv = FormatNumber(pvmbah, 2)
            ketxtra = "Selamat ! anda memperoleh X-TRA PV sebesar " & mbahpv
        Else
            mbahpv = 0
            pvmbah = 0
            ketxtra = ""
        End If
    End Sub

    Sub NomorUndian()
        undi = "" ' aktifkan ini saat ada undian lagi
        adanomor = "F"
        If undi = "ADA" Then
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' NOMOR UNDIAN CMP
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            noke = 0
            noundi1 = 0
            noundi2 = 0
            noundi3 = 0
            noundi4 = 0
            noundi5 = 0
            noundi6 = 0
            noundi7 = 0
            noundi8 = 0
            noundi9 = 0
            noundi10 = 0
            noundi11 = 0
            noundi12 = 0
            noundi13 = 0
            noundi14 = 0
            noundi15 = 0
            noundi16 = 0
            noundi17 = 0
            noundi18 = 0
            noundi19 = 0
            noundi20 = 0
            noundi21 = 0
            noundi22 = 0
            noundi23 = 0
            noundi24 = 0
            noundi25 = 0
            noundi26 = 0
            noundi27 = 0
            noundi28 = 0
            noundi29 = 0
            noundi30 = 0
            noundi31 = 0
            noundi32 = 0
            noundi33 = 0
            noundi34 = 0
            noundi35 = 0
            noundi36 = 0
            noundi37 = 0
            noundi38 = 0
            noundi39 = 0
            noundi40 = 0
            noundi41 = 0
            noundi42 = 0
            noundi43 = 0
            noundi44 = 0
            noundi45 = 0
            noundi46 = 0
            noundi47 = 0
            noundi48 = 0
            noundi49 = 0
            noundi50 = 0
            noundi51 = 0
            noundi52 = 0
            noundi53 = 0
            noundi54 = 0
            noundi55 = 0
            noundi56 = 0
            noundi57 = 0
            noundi58 = 0
            noundi59 = 0
            noundi60 = 0
            noundi61 = 0
            noundi62 = 0
            noundi63 = 0
            noundi64 = 0
            noundi65 = 0
            noundi66 = 0
            noundi67 = 0
            noundi68 = 0
            noundi69 = 0
            noundi70 = 0
            noundi71 = 0
            noundi72 = 0
            noundi73 = 0
            noundi74 = 0
            noundi75 = 0
            noundi76 = 0
            noundi77 = 0
            noundi78 = 0
            noundi79 = 0
            noundi80 = 0
            adanomor = "F"

            mlSQL = "SELECT * FROM undi_cmp where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If mlREADER.HasRows Then
                mlDATATABLE = New DataTable
                mlDATATABLE.Load(mlREADER)
                For aaaeqkmf = 1 To mlDATATABLE.Rows.Count - 1
                    If noke = 0 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi1 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 1 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi2 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 2 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi3 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 3 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi4 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 4 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi5 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 5 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi6 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 6 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi7 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 7 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi8 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 8 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi9 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 9 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi10 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 10 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi11 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 11 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi12 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 12 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi13 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 13 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi14 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 14 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi15 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 15 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi16 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 16 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi17 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 17 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi18 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 18 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi19 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 19 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi20 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 20 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi21 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 21 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi22 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 22 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi23 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 23 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi24 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 24 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi25 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 25 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi26 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 26 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi27 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 27 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi28 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 28 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi29 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 29 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi30 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 30 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi31 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 31 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi32 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 32 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi33 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 33 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi34 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 34 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi35 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 35 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi36 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 36 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi37 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 37 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi38 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 38 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi39 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 39 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi40 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 40 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi41 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 41 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi42 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 42 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi43 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 43 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi44 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 44 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi45 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 45 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi46 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 46 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi47 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 47 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi48 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 48 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi49 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 49 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi50 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 50 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi51 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 51 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi52 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 52 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi53 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 53 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi54 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 54 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi55 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 55 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi56 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 56 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi57 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 57 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi58 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 58 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi59 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 59 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi60 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 60 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi61 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 61 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi62 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 62 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi63 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 63 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi64 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 64 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi65 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 65 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi66 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 66 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi67 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 67 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi68 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 68 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi69 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 69 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi70 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 70 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi71 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 71 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi72 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 72 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi73 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 73 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi74 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 74 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi75 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 75 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi76 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 76 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi77 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 77 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi78 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 78 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi79 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 79 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi80 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    If noke = 80 Then
                        mlSQL2 = "update undi_cmp set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        noundi81 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        adanomor = "T"
                    End If
                    noke = noke + 1
                Next
            End If
            mlREADER.Close()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' NOMOR UNDIAN TOP G2
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            noke = 0
            tgundi1 = 0
            tgundi2 = 0
            tgundi3 = 0
            tgundi4 = 0
            tgundi5 = 0
            tgundi6 = 0
            tgundi7 = 0
            tgundi8 = 0
            tgundi9 = 0
            tgundi10 = 0
            tgundi11 = 0
            tgundi12 = 0
            tgundi13 = 0
            tgundi14 = 0
            tgundi15 = 0
            tgundi16 = 0
            tgundi17 = 0
            tgundi18 = 0
            tgundi19 = 0
            tgundi20 = 0
            tgundi21 = 0
            tgundi22 = 0
            tgundi23 = 0
            tgundi24 = 0
            tgundi25 = 0
            tgundi26 = 0
            tgundi27 = 0
            tgundi28 = 0
            tgundi29 = 0
            tgundi30 = 0
            tgundi31 = 0
            tgundi32 = 0
            tgundi33 = 0
            tgundi34 = 0
            tgundi35 = 0
            tgundi36 = 0
            tgundi37 = 0
            tgundi38 = 0
            tgundi39 = 0
            tgundi40 = 0
            tgundi41 = 0
            tgundi42 = 0
            tgundi43 = 0
            tgundi44 = 0
            tgundi45 = 0
            tgundi46 = 0
            tgundi47 = 0
            tgundi48 = 0
            tgundi49 = 0
            tgundi50 = 0
            tgundi51 = 0
            tgundi52 = 0
            tgundi53 = 0
            tgundi54 = 0
            tgundi55 = 0
            tgundi56 = 0
            tgundi57 = 0
            tgundi58 = 0
            tgundi59 = 0
            tgundi60 = 0
            tgundi61 = 0
            tgundi62 = 0
            tgundi63 = 0
            tgundi64 = 0
            tgundi65 = 0
            tgundi66 = 0
            tgundi67 = 0
            tgundi68 = 0
            tgundi69 = 0
            tgundi70 = 0
            tgundi71 = 0
            tgundi72 = 0
            tgundi73 = 0
            tgundi74 = 0
            tgundi75 = 0
            tgundi76 = 0
            tgundi77 = 0
            tgundi78 = 0
            tgundi79 = 0
            tgundi80 = 0
            adanomortg = "F"

            mlSQL = "SELECT * FROM undi_topg where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If mlREADER.HasRows Then
                mlDATATABLE = New DataTable
                mlDATATABLE.Load(mlREADER)
                For aaaeqkmf = 1 To mlDATATABLE.Rows.Count - 1
                    If noke = 0 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi1 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 1 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi2 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 2 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi3 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 3 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi4 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 4 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi5 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 5 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi6 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 6 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi7 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 7 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi8 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 8 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi9 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 9 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi10 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 10 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi11 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 11 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi12 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 12 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi13 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 13 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi14 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 14 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi15 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 15 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi16 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 16 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi17 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 17 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi18 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 18 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi19 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 19 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi20 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 20 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi21 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 21 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi22 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 22 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi23 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 23 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi24 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 24 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi25 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 25 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi26 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 26 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi27 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 27 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi28 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 28 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi29 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 29 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi30 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 30 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi31 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 31 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi32 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 32 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi33 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 33 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi34 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 34 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi35 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 35 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi36 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 36 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi37 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 37 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi38 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 38 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi39 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 39 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi40 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 40 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi41 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 41 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi42 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 42 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi43 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 43 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi44 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 44 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi45 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 45 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi46 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 46 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi47 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 47 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi48 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 48 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi49 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 49 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi50 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 50 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi51 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 51 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi52 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 52 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi53 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 53 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi54 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 54 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi55 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 55 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi56 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 56 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi57 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 57 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi58 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 58 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi59 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 59 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi60 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 60 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi61 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 61 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi62 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 62 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi63 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 63 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi64 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 64 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi65 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 65 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi66 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 66 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi67 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 67 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi68 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 68 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi69 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 69 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi70 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 70 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi71 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 71 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi72 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 72 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi73 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 73 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi74 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 74 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi75 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 75 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi76 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 76 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi77 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 77 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi78 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 78 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi79 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 79 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi80 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    If noke = 80 Then
                        mlSQL2 = "update undi_topg set nomornya = " & mlDATATABLE.Rows(aaaeqkmf)("id") + 100000 & " where kta like '" & nokon & "' and noinvo like '" & noslip & "'"
                        tgundi81 = mlDATATABLE.Rows(aaaeqkmf)("id") + 100000
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        adanomortg = "T"
                    End If
                    noke = noke + 1
                Next
            End If
            mlREADER.Close()

        End If



        noundi0 = 0
        noundi1 = 0
        noundi2 = 0
        noundi3 = 0
        noundi4 = 0
        noundi5 = 0
        noundi6 = 0
        noundi7 = 0
        noundi8 = 0
        noundi9 = 0
        noundi10 = 0
        noundi11 = 0
        noundi12 = 0
        noundi13 = 0
        noundi14 = 0
        noundi15 = 0
        noundi16 = 0
        noundi17 = 0
        noundi18 = 0
        noundi19 = 0
        noundi20 = 0
        noundi21 = 0
        noundi22 = 0
        noundi23 = 0
        noundi24 = 0
        noundi25 = 0
        noundi26 = 0
        noundi27 = 0
        noundi28 = 0
        noundi29 = 0
        noundi30 = 0
        noundi31 = 0
        noundi32 = 0
        noundi33 = 0
        noundi34 = 0
        noundi35 = 0
        noundi36 = 0
        noundi37 = 0
        noundi38 = 0
        noundi39 = 0
        noundi40 = 0
        noundi41 = 0
        noundi42 = 0
        noundi43 = 0
        noundi44 = 0
        noundi45 = 0
        noundi46 = 0
        noundi47 = 0
        noundi48 = 0
        noundi49 = 0
        noundi50 = 0

        ss = "T"
        adanomor = "F"
        mlSQL = "SELECT count(id) as vid FROM undi_tiket where kta like '" & nokon & "' and sta like '" & ss & "' and noinvo like '" & noslip & "' group by sta"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            adanomor = "F"
            xcs = 0
        Else
            xcs = mlREADER("vid")
        End If
        mlREADER.Close()

        If IsDBNull(xcs) = False Then
            adanomor = "T"
        Else
            adanomor = "F"
        End If

        If adanomor = "T" Then
            ke = 0
            mlSQL = "SELECT * FROM undi_tiket where kta like '" & nokon & "' and sta like '" & ss & "' and noinvo like '" & noslip & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If mlREADER.HasRows Then
                mlDATATABLE = New DataTable
                mlDATATABLE.Load(mlREADER)
                For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                    If ke = 0 Then
                        noundi0 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 1 Then
                        noundi1 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 2 Then
                        noundi2 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 3 Then
                        noundi3 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 4 Then
                        noundi4 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 5 Then
                        noundi5 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 6 Then
                        noundi6 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 7 Then
                        noundi7 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 8 Then
                        noundi8 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 9 Then
                        noundi9 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 10 Then
                        noundi10 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 11 Then
                        noundi11 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 12 Then
                        noundi12 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 13 Then
                        noundi13 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 14 Then
                        noundi14 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 15 Then
                        noundi15 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 16 Then
                        noundi16 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 17 Then
                        noundi17 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 18 Then
                        noundi18 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 19 Then
                        noundi19 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 20 Then
                        noundi20 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 21 Then
                        noundi21 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 22 Then
                        noundi22 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 23 Then
                        noundi23 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 24 Then
                        noundi24 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 25 Then
                        noundi25 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 26 Then
                        noundi26 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 27 Then
                        noundi27 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 28 Then
                        noundi28 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 29 Then
                        noundi29 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 30 Then
                        noundi30 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 31 Then
                        noundi31 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 32 Then
                        noundi32 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 33 Then
                        noundi33 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 34 Then
                        noundi34 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 35 Then
                        noundi35 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 36 Then
                        noundi36 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 37 Then
                        noundi37 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 38 Then
                        noundi38 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 39 Then
                        noundi39 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 40 Then
                        noundi40 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 41 Then
                        noundi41 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 42 Then
                        noundi42 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 43 Then
                        noundi43 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 44 Then
                        noundi44 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 45 Then
                        noundi45 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 46 Then
                        noundi46 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 47 Then
                        noundi47 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 48 Then
                        noundi48 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 49 Then
                        noundi49 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    If ke = 50 Then
                        noundi50 = mlDATATABLE.Rows(aaaeqSSS)("nomornya")
                    End If
                    ke = ke + 1
                Next
            End If
            mlREADER.Close()
        End If
        adanomor = "F"
        adanomortg = "F"
    End Sub
End Class

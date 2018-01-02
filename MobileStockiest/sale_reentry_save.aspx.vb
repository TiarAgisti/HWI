Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_reentry_save
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable
    Dim mlFUNCT As FunctionHWI

    Dim hariakhir, dino, dinoe, tglnyaaa, noser, paket As Date
    Dim dcpusate, pos_area, mypos, loguser, kelasdc, indukdc, indukmc, namatabel, namatabel2, dcHO As String
    Dim harga, PV, bv, tunai, debit, credit, kkredit, bgcek, duite, jumbc, kop, jumpv, jumbv, nambahkiri, nambahkanan, sisa, sisastok As Double
    Dim l1a, l1, l3, l2, upe, tipnye, jeneng, direkmu, lanjutken, l4, l5, lanjutdodol, lanjutposting, lanjuken As String
    Dim menu_id As Integer

    Dim mypoc As String
    Dim jumstok As Double

    Dim kodeberi1, kodeberi2, kodeberi3, kodeberi4, kodeberi5, kodeberi6, kodeberi7, kodeberi8, kodeberi9, kodeberi10, kodeberi11, kodeberi12 As String
    Dim jumberi1, jumberi2, jumberi3, jumberi4, jumberi5, jumberi6, jumberi7, jumberi8, jumberi9, jumberi10, jumberi11, jumberi12, sisaku, sisastk As Double

    Dim skr As Date
    Dim wulan, nahun As String
    Dim bulanskr, tahunskr, noakhir, bulsks, jk, tahskr, nopajak As Integer
    Dim tamb, blne, taun, nipe, noinvo, kel, masterdc, k1, k2, nourutpjk As String
    Dim cekbg As Double

    Dim aloc, subalo, psa As String

    Dim jumak As Integer
    Dim awal, jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10, jumlah11, jumlah12 As Integer
    Dim kode_prd1, kode_prd2, kode_prd3, kode_prd4, kode_prd5, kode_prd6, kode_prd7, kode_prd8, kode_prd9, kode_prd10, kode_prd11, kode_prd12 As String
    Dim kodeprd1, kodeprd2, kodeprd3, kodeprd4, kodeprd5, kodeprd6, kodeprd7, kodeprd8, kodeprd9, kodeprd10, kodeprd11, kodeprd12 As String
    Dim jum1, jum2, jum3, jum4, jum5, jum6, jum7, jum8, jum9, jum10, jum11, jum12 As Double
    Dim upke, expra, sapa, direknya, sapa1, sapa2, noid As String
    Dim nambah As Integer
    Dim nilaipvnya, nilaibv, pvfull, nilaipv1, nilaipv2, nilaipv3, nilaipv, produp, postingup, pvnya, jume As Double
    Dim levnya As Integer
    Dim ncrd As String
    Dim proddepo, pvdepo, prodreg, pvprod, pvku, pvreg, jumpvki, jumpvka, jummurni As Double
    Dim ada, direk As String
    Dim tglku, tglbayar As Date
    Dim tglini, bulanini, bulanikis, tauniki, perik_promo, nahun_promo, wulan_promo, wulan_pajak, nahun_pajak, bonft1, bonft, p_one, p_tu, pred As Integer
    Dim sinten, kedua As Date
    Dim piro, mutere, levke, aaxd, aax As Integer
    Dim ent, posloc, spld, posef, dowo, staluup, opoupnye, uplu, okelahklo, al1, al2, uplinemu, jenengmu, poseupmu As String
    Dim kiri, kirifull, kanan, kananfull As Double
    Dim pvgrupkiri, pvgrupkanan, pvfull_kiri, pvfull_kanan As Double
    Dim strKta, strUpdt As String
    Dim intKiri, intKanan, intBulan, intTahun, intTupo As Integer
    Dim bulan, tahun, lastday1, expbln, expthn, lastday, totdirkiri, totdirkanan As Integer
    Dim tglskr, tglexpiredac As Date
    Dim alocnya As String
    Dim pvnow, pvnow2, pvnow3, prodada, nilaip, tambahan, produpkurang, nilaipvpri As Double
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        dcpusate = Session("dcpusate")

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' NOTE
        ' UPGRADE / EXPAND BC TIDAK MEMBUAT POINT BC BULAN INI ATAU SISA POINT DITAMBAHKAN PADA SAAT UPGRADE
        ' UPGRADE  / EXPAND BC AKAN DIANGGAP MULAI DARI NOL PADA SAAT EXPAND / UPGRADE DILAKUKAN
        ' JADI PADA SAAT EXPAND / UPGRADE, MAKA PADA SAAT ITU JUGA PV GRUP KIRI / KANAN BC NYA MENJADI 0 DAN MULAI DIAKUMULASIKAN
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
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


        If UCase(mypos) = dcHO Then
            namatabel = "st_barang"
            namatabel2 = "st_kartustock"
        Else
            namatabel = "st_barang_ms"
            namatabel2 = "st_kartustock_ms"
        End If

        PrepareSave()
        CekStockPaketPendaftaran()
        CekStokProdukUpgrade()
        CekValidSession()
        SimpanTransaksi()
    End Sub

    Sub PrepareSave()
        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        tglnyaaa = dino
        noser = Trim(Request("direk"))
        paket = UCase(Trim(Request("paket")))
        harga = Request("harga")
        PV = Request("pv")
        bv = Request("bv")
        tunai = Request("jumbayarcash")
        debit = Request("jumbayardb")
        kkredit = Request("jumbayarcc")
        bgcek = Request("jumbayarcek")
        duite = Request("jumbayar")

        If dinoe = "" Then

            l1a = "Mbuh"
            Session("errorpos") = "Tanggal transaksi tidak valid"
            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
        Else
            If Len(dinoe) >= 11 Then

                Session("errorpos") = "Tanggal transaksi tidak valid, maksimal 10 karakter"
                l1a = "Mbuh"
                Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
            Else
                If ((Len(dinoe) <= 11) And (dinoe <> "")) Then
                    l1a = "Ter1a"
                    Session("errorpos") = ""
                End If
            End If
        End If

        l1 = "Ter1"

        If paket = "" Then

            l3 = "Mbuh"
            Session("errorpos") = "Anda belum memilih paket re-entry fast track"
            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
        Else
            If Len(paket) >= 10 Then

                Session("errorpos") = "Anda belum memilih paket re-entry fast track"
                l3 = "Mbuh"
                Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
            Else
                If ((Len(paket) <= 10) And (paket <> "")) Then
                    If UCase(mypos) = dcHO Then
                        mlSQL = "SELECT id,jumbc,kop,pv,bv FROM " & namatabel & " where kode like '" & paket & "'"
                    Else
                        mlSQL = "SELECT id,jumbc,kop,pv,bv FROM " & namatabel & " where kode like '" & paket & "' and nopos like '" & mypos & "'"
                    End If
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorpos") = "Tipe Paket re-entry fast track tidak dikenal"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    Else
                        l3 = "Ter3"
                        Session("errorpos") = ""
                        jumbc = mlREADER("jumbc")
                        kop = UCase(mlREADER("kop"))
                        jumpv = mlREADER("pv")
                        jumbv = mlREADER("bv")
                        nambahkiri = jumbc
                        nambahkanan = jumbc
                    End If
                    mlREADER.Close()
                End If
            End If
        End If

        If noser = "" Then
            l2 = "Mbuh"
            Session("errorpos") = "Nomor distributor belum diisi"
            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
        Else
            If Len(noser) >= 11 Then
                Session("errorpos") = "Nomor distributor maksimal 10 karakter"
                l2 = "Mbuh"
                Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
            Else
                If ((Len(noser) <= 11) And (noser <> "")) Then
                    If IsNumeric(noser) = True Then
                        mlSQL = "SELECT id,tipene,upme,uid,direk FROM member where asli = '" & noser & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            Session("errorpos") = "Nomor distributor tidak ditemukan"
                            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                        Else

                            upe = mlREADER("upme")
                            tipnye = UCase(mlREADER("tipene"))
                            jeneng = mlREADER("uid")
                            direkmu = mlREADER("direk")

                            If tipnye = "S" Or tipnye = "P" Or tipnye = "I" Then
                                lanjutken = "F"
                                Session("errorpos") = "Distributor sudah bertipe Premium / Platinum, tidak diperlukan upgrade untuk mengikuti Fast Track Plan"
                                Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                            Else
                                If tipnye = "R" Then
                                    lanjuken = "T"
                                Else
                                    lanjutken = "F"
                                    Session("errorpos") = "Distributor tipe tidak diketahui, silahkan hubungi kantor pusat"
                                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                                End If
                            End If
                        End If
                        mlREADER.Close()
                    Else
                        Session("errorpos") = "Nomor distributor belum diisi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If


        If harga = "" Then
            l4 = "Mbuh"
            Session("errorpos") = "Anda belum memilih paket re-entry fast track"
            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(harga) = False Then
                l4 = "Mbuh"
                Session("errorpos") = "Anda belum memilih paket re-entry fast track"
                Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
            Else
                If ((harga <> "") And (IsNumeric(harga) = False)) Then
                    If harga > 0 Then
                        l4 = "Ter4"
                        Session("errorpos") = ""
                    Else
                        l4 = "Mbuh"
                        Session("errorpos") = "Anda belum memilih paket re-entry fast track"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If

        If tunai = "" Then
            tunai = 0
        Else
            If IsNumeric(tunai) = False Then
                tunai = 0
            Else
                If ((tunai <> "") And (IsNumeric(tunai) = False)) Then
                    If tunai < 0 Then
                        tunai = 0
                    Else
                        tunai = tunai
                    End If
                End If
            End If
        End If

        If debit = "" Then
            debit = 0
        Else
            If IsNumeric(debit) = False Then
                debit = 0
            Else
                If ((debit <> "") And (IsNumeric(debit) = False)) Then
                    If debit < 0 Then
                        debit = 0
                    Else
                        debit = debit
                    End If
                End If
            End If
        End If

        If kkredit = "" Then
            kkredit = 0
        Else
            If IsNumeric(kkredit) = False Then
                debit = 0
            Else
                If ((kkredit <> "") And (IsNumeric(kkredit) = False)) Then
                    If kkredit < 0 Then
                        kkredit = 0
                    Else
                        kkredit = kkredit
                    End If
                End If
            End If
        End If

        If bgcek = "" Then
            bgcek = 0
        Else
            If IsNumeric(bgcek) = False Then
                bgcek = 0
            Else
                If ((bgcek <> "") And (IsNumeric(bgcek) = False)) Then
                    If bgcek < 0 Then
                        bgcek = 0
                    Else
                        bgcek = bgcek
                    End If
                End If
            End If
        End If

        If tunai = 0 And debit = 0 And kkredit = 0 And bgcek = 0 Then
            duite = 0
        Else
            duite = duite
        End If


        If duite = "" Then
            l5 = "Mbuh"
            Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(duite) = False Then
                l5 = "Mbuh"
                Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
            Else
                If ((duite <> "") And (IsNumeric(duite) = False)) Then
                    If duite > 0 Then
                        sisa = duite - harga
                        If sisa = 0 Or sisa > 0 Then
                            l5 = "Ter5"
                            Session("errorpos") = ""
                        Else
                            l5 = "Mbuh"
                            Session("errorpos") = "Jumlah Pembayaran Anda tidak Mencukupi"
                            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                        End If
                    Else
                        l5 = "Mbuh"
                        Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If

        lanjutdodol = "F"
        lanjutposting = "F"
        sisastok = 0
    End Sub

    Sub CekStockPaketPendaftaran()
        '''''''''''''''''''''''''''''''''''''''''''''
        ' cek stok ketersediaan paket pendaftaran
        '''''''''''''''''''''''''''''''''''''''''''''

        If UCase(mypos) <> dcHO Then ' bila DC kantor pusat tidak ada paket upgrade
            If UCase(mypoc) <> dcHO Then
                mlSQL = "SELECT jumlah FROM " & namatabel & " where kode like '" & paket & "' and nopos like '" & mypos & "'"
            Else
                mlSQL = "SELECT jumlah FROM " & namatabel & " where kode like '" & paket & "' and nopos like '" & mypos & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                lanjutdodol = "F"
                Session("errorpos") = "Paket re-entry fast track Tidak Terdaftar"
                Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
            Else
                jumstok = mlREADER("jumlah")
                sisastok = jumstok - 1
                If sisastok = 0 Or sisastok >= 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"

                    Session("errorpos") = "Sisa stock tidak mencukupi untuk dilakukan transaksi ini"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                End If
            End If
            mlREADER.Close()
        Else
            lanjutdodol = "T"
            jumstok = 1
        End If

    End Sub

    Sub CekStokProdukUpgrade()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' cek stok ketersediaan produk pendukung paket upgrade
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        mlSQL = "SELECT * FROM st_tipe_paket where kode like '" & paket & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjutdodol = "F"
            Session("errorpos") = "Paket Upgrade tidak valid !"
            Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
        Else
            kodeberi1 = mlREADER("kode_prd1")
            jumberi1 = mlREADER("jumlah1") * jumstok
            kodeberi2 = mlREADER("kode_prd2")
            jumberi2 = mlREADER("jumlah2") * jumstok
            kodeberi3 = mlREADER("kode_prd3")
            jumberi3 = mlREADER("jumlah3") * jumstok
            kodeberi4 = mlREADER("kode_prd4")
            jumberi4 = mlREADER("jumlah4") * jumstok
            kodeberi5 = mlREADER("kode_prd5")
            jumberi5 = mlREADER("jumlah5") * jumstok
            kodeberi6 = mlREADER("kode_prd6")
            jumberi6 = mlREADER("jumlah6") * jumstok
            kodeberi7 = mlREADER("kode_prd7")
            jumberi7 = mlREADER("jumlah7") * jumstok
            kodeberi8 = mlREADER("kode_prd8")
            jumberi8 = mlREADER("jumlah8") * jumstok
            kodeberi9 = mlREADER("kode_prd9")
            jumberi9 = mlREADER("jumlah9") * jumstok
            kodeberi10 = mlREADER("kode_prd10")
            jumberi10 = mlREADER("jumlah10") * jumstok
            kodeberi11 = mlREADER("kode_prd11")
            jumberi11 = mlREADER("jumlah11") * jumstok
            kodeberi12 = mlREADER("kode_prd12")
            jumberi12 = mlREADER("jumlah12") * jumstok
        End If
        mlREADER.Close()

        If UCase(mypos) = "B-000" Then
            lanjutdodol = "T"
        Else

            If kodeberi1 <> "" And kodeberi1 <> "-" And IsDBNull(kodeberi1) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi1 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi1 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi1
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi1 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi2 <> "" And kodeberi2 <> "-" And IsDBNull(kodeberi2) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi2 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi2 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi2
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi2 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi3 <> "" And kodeberi3 <> "-" And IsDBNull(kodeberi3) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi3 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi3 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi3
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi3 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi4 <> "" And kodeberi4 <> "-" And IsDBNull(kodeberi4) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi4 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi4 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi4
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi4 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi5 <> "" And kodeberi5 <> "-" And IsDBNull(kodeberi5) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi5 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi5 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi5
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi5 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi6 <> "" And kodeberi6 <> "-" And IsDBNull(kodeberi6) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi6 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi6 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi6
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi6 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi7 <> "" And kodeberi7 <> "-" And IsDBNull(kodeberi7) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi7 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi7 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi7
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi7 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi8 <> "" And kodeberi8 <> "-" And IsDBNull(kodeberi8) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi8 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi8 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi8
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi8 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi9 <> "" And kodeberi9 <> "-" And IsDBNull(kodeberi9) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi9 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi9 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi9
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi9 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi10 <> "" And kodeberi10 <> "-" And IsDBNull(kodeberi10) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi10 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi10 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi10
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi10 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi11 <> "" And kodeberi11 <> "-" And IsDBNull(kodeberi11) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi11 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi11 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi11
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi11 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi12 <> "" And kodeberi12 <> "-" And IsDBNull(kodeberi12) = False Then
                sisaku = 0
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi12 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"
                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi12 & " yang menyertai produk paket re-entry fast track"
                    Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi12
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi12 & " yang menyertai produk Paket re-entry fast track tidak mencukupi"
                        Response.Redirect("sale_reentry.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

        End If
    End Sub

    Sub CekValidSession()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' CEK VALID SESSION
        ' CLOSE SESSION INPUT HANYA BISA DILAKUKAN MELALUI KANTOR PUSAT
        ' CLOSE SESSION TIAP AKHIR BULAN PADA TANGGAL 30/31 JAM 19:00:00 WIB
        ' BILA ADA TRANSAKSI PADA TANGGAL 30/31 LEWAT CLOSING TIME, MAKA DITOLAK DAN DIMINTA UNTUK MENGHUBUNGI KANTOR PUSAT
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        skr = Now()

        wulan = Session("wulpos")
        nahun = Session("nuhun")
        lanjutposting = "T"

        Dim str_Valid As String = ""
        If lanjutposting = "F" Then
            str_Valid += "<section Class='content'>" & vbCrLf
            str_Valid += "<div Class='box'>" & vbCrLf
            str_Valid += "<div Class='box-header with-border'>" & vbCrLf
            str_Valid += "<h3 Class='box-title'></h3>" & vbCrLf
            str_Valid += "<div Class='box-tools pull-right'>" & vbCrLf
            str_Valid += "<Button type = 'button' Class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
            str_Valid += "<i Class='fa fa-minus'></i></button>" & vbCrLf
            str_Valid += "<Button type = 'button' Class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
            str_Valid += "<i Class='fa fa-times'></i></button>" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "<div Class='box-body'>" & vbCrLf
            str_Valid += "<p align = 'center' >" & vbCrLf
            str_Valid += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
            str_Valid += "<br/>" & vbCrLf
            str_Valid += "<br/>" & vbCrLf
            str_Valid += "<p align='center'>" & vbCrLf
            str_Valid += "Maaf saat ini transaksi anda tidak dapat dilakukan karena sudah memasuki <font color='#FF0000'><b>closing period</b></font><br/>" & vbCrLf
            str_Valid += "Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup point bulanan<br/>" & vbCrLf
            str_Valid += "maka silahkan hubungi kantor pusat sesegera mungkin.<br/>" & vbCrLf
            str_Valid += "Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian anda.<br/>" & vbCrLf
            str_Valid += "&lt;-- <a href='sale_reentry.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a> --&gt;" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "</section>" & vbCrLf

            Div_Valid.InnerHtml = str_Valid
        End If
    End Sub

    Sub SimpanTransaksi()
        If lanjutposting = "T" And lanjutdodol = "T" Then
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ' simpan transaksi
            ' potong stock
            ' update kartu stock	
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            ' SIMPAN TRANSAKSI
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            dino = Now()
            bulanskr = CInt(Month(dino))
            tahunskr = CInt(Year(dino))
            mlSQL = "SELECT TOP 1 id,urut,tgl FROM st_sale_daftar where nopos like '" & mypos & "' AND month(tgl) = '" & bulanskr & "' AND year(tgl) = '" & tahunskr & "' order by urut DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                noakhir = 1
                bulsks = CInt(Month(dino))
            Else
                noakhir = mlREADER("urut") + 1
                bulsks = CInt(Month(mlREADER("tgl")))
            End If
            mlREADER.Close()

            If bulsks <> bulanskr Then
                noakhir = 1
            Else
                If bulsks = bulanskr Then
                    noakhir = noakhir
                End If
            End If

            jk = Len(noakhir)
            If jk = 1 Or jk = 0 Then
                tamb = "000"
            Else
                If jk = 2 Then
                    tamb = "00"
                Else
                    If jk = 3 Then
                        tamb = "0"
                    Else
                        tamb = ""
                    End If
                End If
            End If

            blne = CStr(Month(dino))
            taun = Right(CStr(Year(dino)), 2)
            nipe = CStr(noakhir)

            noinvo = mypos + "/" + tamb + nipe + "/FST-" + blne + "/" + taun

            'nahun = year(dino)
            ''''''''''''''''''''''''''''''
            ' bikin nomor invoice pajak
            ''''''''''''''''''''''''''''''
            tahskr = CInt(Year(dino))
            kel = "RET"
            'rs.Open "SELECT * FROM nourut where dcinduk like '"&indukdc&"' AND nopos like '"&mypos&"' and year(tgl)='"&tahskr&"' and kel like '"&kel&"' order by urut desc limit 1",conn	
            'rs.Open "SELECT * FROM nourut where dcinduk like '"&indukdc&"' AND nopos like '"&mypos&"' and year(tgl)='"&tahskr&"' order by urut desc limit 1",conn	
            If UCase(mypos) = "B-000" Then
                'rs.Open "SELECT urut FROM nourut where dcinduk like '"&indukdc&"' and year(tgl)='"&tahskr&"' order by urut desc limit 1",conn	
                masterdc = "B-000"
                k1 = "ODC"
                k2 = "RET"
                mlSQL = "SELECT TOP 1 urut FROM nourut where ((dcinduk like '" & masterdc & "' and kel like '" & k1 & "') or (nopos like '" & masterdc & "' AND kel like '" & k2 & "')) and year(tgl)='" & tahskr & "' order by nopajak desc"
            Else
                mlSQL = "SELECT TOP 1 urut FROM nourut where dcinduk like '" & indukdc & "' AND nopos like '" & mypos & "' and year(tgl)='" & tahskr & "' and kel like '" & kel & "' order by nopajak desc"
            End If

            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                nopajak = 1
            Else
                nopajak = mlREADER("urut") + 1
            End If
            mlREADER.Close()

            If nopajak <> "" Then
                jk = Len(nopajak)
                If jk = 1 Or jk = 0 Then
                    tamb = "0000000"
                Else
                    If jk = 2 Then
                        tamb = "000000"
                    Else
                        If jk = 3 Then
                            tamb = "00000"
                        Else
                            If jk = 4 Then
                                tamb = "0000"
                            Else
                                If jk = 5 Then
                                    tamb = "000"
                                Else
                                    If jk = 6 Then
                                        tamb = "00"
                                    Else
                                        If jk = 7 Then
                                            tamb = "0"
                                        Else
                                            tamb = ""
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            Else
                nopajak = ""
            End If
            nourutpjk = tamb + CStr(nopajak)


            mlSQL = "Insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)Values('" & nopajak & "','" & mypos & "','" & noinvo & "','" & dino & "','AKT','RET','" & indukdc & "','" & nourutpjk & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            ' SIMPAN DATA TRANSAKSI
            mlSQL = "Insert into st_sale_daftar(nopos,urut,kta,nama,tgl,noslip,nopajak,noseri,paket,harga,pv,bv,tunai,debit,cc,bg,jumbayar,kembalian,jumbc,suratjalan,alokbulan" & vbCrLf
            mlSQL += ",aloktahun,dcinduk,direk,idplc,subalo,kaki,pakai,tipe)Values('" & mypos & "','" & noakhir & "','" & loguser & "','" & jeneng & "','" & dino & "'" & vbCrLf
            mlSQL += ",'" & noinvo & "','" & nourutpjk & "','" & noser & "','" & paket & "','" & harga & "','" & jumpv & "','" & jumbv & "','" & tunai & "','" & debit & "'" & vbCrLf
            mlSQL += ",'" & kkredit & "','" & cekbg & "','" & duite & "','" & duite - harga & "','" & jumbc & "','-','" & wulan & "','" & nahun & "','" & indukdc & "'" & vbCrLf
            mlSQL += ",'" & direkmu & "','" & aloc & "','" & subalo & "','" & psa & "','T','normal')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)


            ' STOCK AKTUAL Paket Upgrade DC
            If UCase(mypos) <> dcHO Then ' bila DC kantor pusat tidak ada paket pendaftaran
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - 1 & "' Where nopos like '" & mypos & "' and kode like '" & paket & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()
            Else
                jumak = 1
            End If

            If jumak <= 0 Then
                jumak = 1
            Else
                jumak = jumak
            End If


            ' KARTU STOCK PAKET PENDAFTARAN
            mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by tgl DESC, id DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "'" & vbCrLf
                mlSQL2 += ",'" & dino & "','" & jumak & "',0,1,'" & jumak - 1 & "','" & noinvo & "','Penjualan FastTrack')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - 1
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "'" & vbCrLf
                mlSQL2 += ",'" & dino & "','" & awal & "',0,1,'" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            ' UPDATE PRODUK Paket Upgrade UNTUK SEJARAH SAJA
            mlSQL = "SELECT TOP 1 * FROM st_tipe_paket where kode like '" & paket & "' order by kode DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                kode_prd1 = "-"
                jumlah1 = 0
                kode_prd2 = "-"
                jumlah2 = 0
                kode_prd3 = "-"
                jumlah3 = 0
                kode_prd4 = "-"
                jumlah4 = 0
                kode_prd5 = "-"
                jumlah5 = 0
                kode_prd6 = "-"
                jumlah6 = 0
                kode_prd7 = "-"
                jumlah7 = 0
                kode_prd8 = "-"
                jumlah8 = 0
                kode_prd9 = "-"
                jumlah9 = 0
                kode_prd10 = "-"
                jumlah10 = 0
                kode_prd11 = "-"
                jumlah11 = 0
                kode_prd12 = "-"
                jumlah12 = 0
            Else
                kode_prd1 = mlREADER("kode_prd1")
                jumlah1 = mlREADER("jumlah1")
                kode_prd2 = mlREADER("kode_prd2")
                jumlah2 = mlREADER("jumlah2")
                kode_prd3 = mlREADER("kode_prd3")
                jumlah3 = mlREADER("jumlah3")
                kode_prd4 = mlREADER("kode_prd4")
                jumlah4 = mlREADER("jumlah4")
                kode_prd5 = mlREADER("kode_prd5")
                jumlah5 = mlREADER("jumlah5")
                kode_prd6 = mlREADER("kode_prd6")
                jumlah6 = mlREADER("jumlah6")
                kode_prd7 = mlREADER("kode_prd7")
                jumlah7 = mlREADER("jumlah7")
                kode_prd8 = mlREADER("kode_prd8")
                jumlah8 = mlREADER("jumlah8")
                kode_prd9 = mlREADER("kode_prd9")
                jumlah9 = mlREADER("jumlah9")
                kode_prd10 = mlREADER("kode_prd10")
                jumlah10 = mlREADER("jumlah10")
                kode_prd11 = mlREADER("kode_prd11")
                jumlah11 = mlREADER("jumlah11")
                kode_prd12 = mlREADER("kode_prd12")
                jumlah12 = mlREADER("jumlah12")
            End If
            mlREADER.Close()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' UPDATE STOCK AKTUAL DC SESUAI Paket Upgrade PENDUKUNGNYA
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah1 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah1
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd1 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah1 & "','" & jumak - jumlah1 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah1
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd1 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah1 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd1 & "'" & vbCrLf
                mlSQL += ",'" & jumlah1 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd2 <> "" Or kode_prd2 <> "-" Or IsDBNull(kode_prd2) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd2 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah2 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd2 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah2
                Else
                    jumak = jumak
                End If


                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd2 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd2 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah2 & "','" & jumak - jumlah2 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah2
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd2 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah2 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()


                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd2 & "'" & vbCrLf
                mlSQL += ",'" & jumlah2 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd3 <> "" Or kode_prd3 <> "-" Or IsDBNull(kode_prd3) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd3 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah3 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd3 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah3
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd3 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd3 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah3 & "','" & jumak - jumlah3 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah3
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd3 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah3 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd3 & "'" & vbCrLf
                mlSQL += ",'" & jumlah3 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd4 <> "" Or kode_prd4 <> "-" Or IsDBNull(kode_prd4) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd4 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah4 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd4 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah4
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd4 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd4 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah4 & "','" & jumak - jumlah4 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah4
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd4 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah4 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd4 & "'" & vbCrLf
                mlSQL += ",'" & jumlah4 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd5 <> "" Or kode_prd5 <> "-" Or IsDBNull(kode_prd5) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd5 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah5 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd5 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah5
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd5 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd5 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah5 & "','" & jumak - jumlah5 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah5
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd5 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah5 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd5 & "'" & vbCrLf
                mlSQL += ",'" & jumlah5 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd6 <> "" Or kode_prd6 <> "-" Or IsDBNull(kode_prd6) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd6 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah6 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd6 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah6
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd6 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd6 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah6 & "','" & jumak - jumlah6 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah6
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd6 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah6 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd6 & "'" & vbCrLf
                mlSQL += ",'" & jumlah6 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd7 <> "" Or kode_prd7 <> "-" Or IsDBNull(kode_prd7) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd7 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah7 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd7 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah7
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd7 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd7 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah7 & "','" & jumak - jumlah7 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah7
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd7 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah7 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd7 & "'" & vbCrLf
                mlSQL += ",'" & jumlah7 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd8 <> "" Or kode_prd8 <> "-" Or IsDBNull(kode_prd8) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd8 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah8 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd8 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah8
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd8 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd8 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah8 & "','" & jumak - jumlah8 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah8
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd8 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah8 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd8 & "'" & vbCrLf
                mlSQL += ",'" & jumlah8 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd9 <> "" Or kode_prd9 <> "-" Or IsDBNull(kode_prd9) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd9 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah9 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd9 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah9
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd9 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd9 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah9 & "','" & jumak - jumlah9 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah9
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd9 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah9 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd9 & "'" & vbCrLf
                mlSQL += ",'" & jumlah9 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd10 <> "" Or kode_prd10 <> "-" Or IsDBNull(kode_prd10) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd10 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah10 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd10 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah10
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd10 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd10 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah10 & "','" & jumak - jumlah10 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah10
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd10 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah10 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd10 & "'" & vbCrLf
                mlSQL += ",'" & jumlah10 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd11 <> "" Or kode_prd11 <> "-" Or IsDBNull(kode_prd11) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd11 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah11 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd11 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()
                If jumak <= 0 Then
                    jumak = jumlah11
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd11 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd11 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah11 & "','" & jumak - jumlah11 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah11
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd11 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah11 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd11 & "'" & vbCrLf
                mlSQL += ",'" & jumlah11 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            If kode_prd12 <> "" Or kode_prd12 <> "-" Or IsDBNull(kode_prd12) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd12 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah12 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd12 & "' order by kode DESC"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                If jumak <= 0 Then
                    jumak = jumlah12
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd12 & "' order by tgl DESC, id DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd12 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & jumak & "',0,'" & jumlah12 & "','" & jumak - jumlah12 & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah12
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If

                    mlSQL2 = "Insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd12 & "','" & mypos & "'" & vbCrLf
                    mlSQL2 += ",'" & dino & "','" & awal & "',0,'" & jumlah12 & "','" & sisastok & "','" & noinvo & "','Penjualan FastTrack')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                ' simpan produk rekap harian
                mlSQL = "Insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)Values('" & dino & "','" & mypos & "','" & kode_prd12 & "'" & vbCrLf
                mlSQL += ",'" & jumlah12 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If


            mlSQL = "SELECT * FROM st_sale_daftar_prd where noslip like '" & noinvo & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()


            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                kodeprd1 = kode_prd1
                jum1 = jumlah1
            Else
                kodeprd1 = "-"
                jum1 = 0
            End If

            If kode_prd2 <> "" Or kode_prd2 <> "-" Or IsDBNull(kode_prd2) = False Then
                kodeprd2 = kode_prd2
                jum2 = jumlah2
            Else
                kodeprd2 = "-"
                jum2 = 0
            End If

            If kode_prd3 <> "" Or kode_prd3 <> "-" Or IsDBNull(kode_prd3) = False Then
                kodeprd3 = kode_prd3
                jum3 = jumlah3
            Else
                kodeprd3 = "-"
                jum3 = 0
            End If

            If kode_prd4 <> "" Or kode_prd4 <> "-" Or IsDBNull(kode_prd4) = False Then
                kodeprd4 = kode_prd4
                jum4 = jumlah4
            Else
                kodeprd4 = "-"
                jum4 = 0
            End If

            If kode_prd5 <> "" Or kode_prd5 <> "-" Or IsDBNull(kode_prd5) = False Then
                kodeprd5 = kode_prd5
                jum5 = jumlah5
            Else
                kodeprd5 = "-"
                jum5 = 0
            End If

            If kode_prd6 <> "" Or kode_prd6 <> "-" Or IsDBNull(kode_prd6) = False Then
                kodeprd6 = kode_prd6
                jum6 = jumlah6
            Else
                kodeprd6 = "-"
                jum6 = 0
            End If

            If kode_prd7 <> "" Or kode_prd7 <> "-" Or IsDBNull(kode_prd7) = False Then
                kodeprd7 = kode_prd7
                jum7 = jumlah7
            Else
                kodeprd7 = "-"
                jum7 = 0
            End If

            If kode_prd8 <> "" Or kode_prd8 <> "-" Or IsDBNull(kode_prd8) = False Then
                kodeprd8 = kode_prd8
                jum8 = jumlah8
            Else
                kodeprd8 = "-"
                jum8 = 0
            End If

            If kode_prd9 <> "" Or kode_prd9 <> "-" Or IsDBNull(kode_prd9) = False Then
                kodeprd9 = kode_prd9
                jum9 = jumlah9
            Else
                kodeprd9 = "-"
                jum9 = 0
            End If

            If kode_prd10 <> "" Or kode_prd10 <> "-" Or IsDBNull(kode_prd10) = False Then
                kodeprd10 = kode_prd10
                jum10 = jumlah10
            Else
                kodeprd10 = "-"
                jum10 = 0
            End If

            If kode_prd11 <> "" Or kode_prd11 <> "-" Or IsDBNull(kode_prd11) = False Then
                kodeprd11 = kode_prd11
                jum11 = jumlah11
            Else
                kodeprd11 = "-"
                jum11 = 0
            End If

            If kode_prd12 <> "" Or kode_prd12 <> "-" Or IsDBNull(kode_prd12) = False Then
                kodeprd12 = kode_prd12
                jum12 = jumlah12
            Else
                kodeprd12 = "-"
                jum12 = 0
            End If

            If Not mlREADER.HasRows Then
                mlSQL2 = "Insert into st_sale_daftar_prd(noslip,tgl,nopajak,kode1,jumlah1,kode2,jumlah2,kode3,jumlah3,kode4,jumlah4,kode5,jumlah5,kode6,jumlah6,kode7,jumlah7,kode8,jumlah8" & vbCrLf
                mlSQL2 += ",kode9,jumlah9,kode10,jumlah10,kode11,jumlah11,kode12,jumlah12,dcinduk)Values('" & noinvo & "','" & dino & "','" & nourutpjk & "','" & kodeprd1 & "',,'" & jum1 & "'" & vbCrLf
                mlSQL2 += ",'" & kodeprd2 & "',,'" & jum2 & "','" & kodeprd3 & "',,'" & jum3 & "','" & kodeprd4 & "',,'" & jum4 & "','" & kodeprd5 & "',,'" & jum5 & "','" & kodeprd6 & "',,'" & jum6 & "'" & vbCrLf
                mlSQL2 += ",'" & kodeprd7 & "',,'" & jum7 & "','" & kodeprd8 & "',,'" & jum8 & "','" & kodeprd9 & "',,'" & jum9 & "','" & kodeprd10 & "',,'" & jum10 & "','" & kodeprd11 & "',,'" & jum11 & "'" & vbCrLf
                mlSQL2 += ",'" & kodeprd12 & "',,'" & jum12 & "','" & indukdc & "')"
            Else
                'rsALL.update
                'rsALL("nopajak") = nourutpjk
                mlSQL2 = "Update st_sale_daftar_prd set nopajak = '" & nourutpjk & "',kode1 = '" & kodeprd1 & "',jumlah1 = '" & jum1 & "',kode2 = '" & kodeprd2 & "',jumlah2 = '" & jum2 & "'" & vbCrLf
                mlSQL2 += ",kode3 = '" & kodeprd3 & "',jumlah3 = '" & jum3 & "',kode4 = '" & kodeprd4 & "',jumlah4 = '" & jum4 & "',kode5 = '" & kodeprd5 & "',jumlah5 = '" & jum5 & "'" & vbCrLf
                mlSQL2 += ",kode6 = '" & kodeprd6 & "',jumlah6 = '" & jum6 & "',kode7 = '" & kodeprd7 & "',jumlah7 = '" & jum7 & "',kode8 = '" & kodeprd8 & "',jumlah8 = '" & jum8 & "'" & vbCrLf
                mlSQL2 += ",kode9 = '" & kodeprd9 & "',jumlah9 = '" & jum9 & "',kode10 = '" & kodeprd10 & "',jumlah10 = '" & jum10 & "',kode11 = '" & kodeprd11 & "',jumlah11 = '" & jum11 & "'" & vbCrLf
                mlSQL2 += ",kode12 = '" & kodeprd12 & "',jumlah12 = '" & jum12 & "' where noslip like '" & noinvo & "'"
                'rsALL.update
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()


            If kop = "P" Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' UPDATE PV PRIBADI DAN UPLINENYA
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''
                ' UPDATE STATUS DISTRIBUTOR 
                '''''''''''''''''''''''''''''''''''''''''''''''''
                If jumbc = 3 Then
                    upke = "T"
                    expra = "T"
                    nambah = 2
                Else
                    upke = "F"
                    expra = "F"
                    nambah = 0
                End If

                sapa = noser
                nilaipvnya = jumpv
                nilaibv = 0
                pvfull = jumpv

                mlSQL = "SELECT * FROM member where kta Like '" & sapa & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If mlREADER.HasRows Then
                    mlSQL2 = "Update member set tipene_kartu = '" & kop & "',tipene = '" & kop & "' Where kta Like '" & sapa & "'"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                    direknya = mlREADER("direk")
                    sapa1 = mlREADER("pal1")
                    sapa2 = mlREADER("pal2")
                End If
                mlREADER.Close()


                nilaipv1 = 0
                nilaipv2 = 0
                nilaipv3 = 0
                nilaipv = 0
                produp = 0
                postingup = 0
                noid = noser
                pvnya = jumpv

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' CEK SI BELANJA APA LEVELNYA ?
                ' JIKA YG BELANJA RANKNYA DISTRIBUTOR
                '   200 PV = 25 PROD, 175 QP
                '   200 S/D 299 = QP SEMUA
                '   > 300 S/D 399 = QP SEMUA + VOUCHER 50.000
                '   = 400 = QP SEMUA + VOUCHER 100.000
                '   > 400 = SPLIT 50% : 50%
                ' JIKA YG BELANJA RANKNYA SAPPHIER
                '   200 PV = 0 PROD, 200 QP --> BEDA DISINI SAJA DENGAN DISTIRBUTOR
                '   200 S/D 299 = QP SEMUA
                '   > 300 S/D 399 = QP SEMUA + VOUCHER 50.000
                '   = 400 = QP SEMUA + VOUCHER 100.000
                '   > 400 = SPLIT 50% : 50%
                ' JIKA YG BELANJA RANKNYA RUBY KEATAS
                '   0 S/D 400 PV = QP SEMUA
                '   > 400 = SPLIT 50%:50%
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                mlSQL = "SELECT grdlevel FROM jenjang where kta like '" & noid & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    levnya = 1
                Else
                    levnya = CInt(mlREADER("grdlevel"))
                End If
                mlREADER.Close()

                nilaipv1 = 0
                nilaipv2 = 0
                nilaipv3 = 0
                nilaipv = 0
                produp = 0
                postingup = 0
                noid = ncrd
                pvnya = nilaipvnya
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' CEK SI BELANJA APA LEVELNYA ?
                ' JIKA YG BELANJA RANKNYA DISTRIBUTOR, MAKA PEMOTONGNYA ADALAH 150
                ' JIKA YG BELANJA RANKNYA SAPHIER KEATAS, PEMOTONGANYA ADALAH 200
                ' semua pemotongan productivity dimulai saat pv sekarang atau pv belanja >= 200 pv
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                mlSQL = "SELECT grdlevel FROM jenjang where kta like '" & noid & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    levnya = 1
                Else
                    levnya = CInt(mlREADER("grdlevel"))
                End If
                mlREADER.Close()

                '''''''''''''''''''''''''''''''''''''''''''''	
                ' JIKA YG BELANJA RANKNYA DISTRIBUTOR
                '   200 PV = 25 PROD, 175 QP
                '   200 S/D 299 = QP SEMUA
                '   > 300 S/D 399 = QP SEMUA + VOUCHER 50.000
                '   = 400 = QP SEMUA + VOUCHER 100.000
                '   > 400 = SPLIT 50% : 50%
                '''''''''''''''''''''''''''''''''''''''''''''
                If levnya = 1 Or levnya = 2 Or levnya = 3 Then
                    produpkurang = 0
                    mlSQL = "SELECT pvpribadi,produp FROM bns_mypv_current where ((kta like '" & noid & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        pvnow = pvnya
                        pvnow2 = 0
                        pvnow3 = 0
                        nilaibv = 0
                        prodada = 0
                    Else
                        pvnow = (mlREADER("pvpribadi") + mlREADER("produp")) + pvnya
                        pvnow2 = mlREADER("pvpribadi") + mlREADER("produp")
                        pvnow3 = mlREADER("pvpribadi") + pvnya
                        prodada = mlREADER("produp")
                        nilaibv = 0
                    End If
                    mlREADER.Close()

                    If pvnow > 0 And pvnow < 200 Then
                        nilaipv = pvnya
                        nilaibv = 0
                        produp = 0
                        postingup = pvnya
                    Else
                        If pvnow >= 200 And pvnow < 400 Then
                            ' ambil productivity bonusnya dulu
                            If prodada = 0 Then
                                produp = 25
                            Else
                                produp = 0
                            End If
                            nilaipv = (pvnow - produp) - pvnow2
                            postingup = nilaipv
                        Else
                            If pvnow2 >= 400 Then
                                nilaipv = pvnya / 2
                                produp = nilaip
                                postingup = nilaipv
                            Else
                                If pvnow2 + pvnya >= 400 Then
                                    If prodada > 0 Then
                                        nilaipv1 = 400
                                        nilaipv2 = pvnow - nilaipv1
                                        nilaipv3 = nilaipv2 / 2
                                        nilaipv = (pvnya - nilaipv3)
                                        produp = nilaipv3
                                        postingup = (pvnya - nilaipv3)
                                    Else
                                        tambahan = (pvnow - 400) / 2
                                        produp = 25 + tambahan
                                        postingup = pvnow - produp
                                        nilaipv = pvnow - produp
                                    End If
                                Else
                                    nilaipv = pvnya
                                    nilaibv = 0
                                    produp = 0
                                    postingup = pvnya
                                End If
                            End If
                        End If
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''''''	
                ' JIKA YG BELANJA RANKNYA RUBY KEATAS
                '   0 S/D 400 PV = QP SEMUA
                '   > 400 = SPLIT 50%:50%
                '''''''''''''''''''''''''''''''''''''''''''''
                If levnya >= 4 Then
                    pvnow = 0
                    mlSQL = "SELECT pvpribadi,produp FROM bns_mypv_current where ((kta like '" & noid & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        pvnow = pvnya
                        nilaibv = 0
                    Else
                        pvnow = (mlREADER("pvpribadi") + mlREADER("produp"))
                        nilaibv = 0
                    End If
                    mlREADER.Close()

                    If pvnow >= 400 Then
                        nilaipv = pvnya / 2
                        produp = nilaipv
                        postingup = nilaipv
                    Else
                        If pvnow + pvnya >= 400 Then
                            nilaipv1 = 400
                            nilaipv2 = (pvnya + pvnow) - nilaipv1
                            nilaipv3 = nilaipv2 / 2
                            nilaipv = (nilaipv1 + nilaipv3) - pvnow
                            produp = nilaipv3
                            postingup = (nilaipv1 + nilaipv3) - pvnow
                        Else
                            nilaipv = pvnya
                            nilaibv = 0
                            produp = 0
                            postingup = pvnya
                        End If
                    End If
                End If

                nilaipvpri = nilaipv


                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia


                ''''''''''''''''''''''''''''''''''''
                ' cari pv register sebelum upgrade
                ''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' PV DEPOSIT RELEASE BERASAL DARI BNS_DEPOSITDANA YANG DIRELEASE PADA SAAT CLOSING PERIODE
                ' KEDALAM TABLE BNS_DEPOSITRELEASE SESUAI SPLIT POINT YANG BERLAKU KUALIFIKASINYA
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                proddepo = 0
                pvdepo = 0
                mlSQL = "SELECT * FROM bns_depositrelease where ((kta like '" & sapa & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    proddepo = 0
                    pvdepo = 0
                Else
                    proddepo = mlREADER("pvprod")
                    pvdepo = mlREADER("pvpri")
                End If
                mlREADER.Close()

                prodreg = 0
                mlSQL = "SELECT sum(produp) FROM bns_mypv_prod_reg where ((kta like '" & sapa & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    prodreg = 0
                Else
                    prodreg = mlREADER("sum(produp)")
                End If
                mlREADER.Close()

                If IsDBNull(prodreg) = False Then
                    prodreg = prodreg
                Else
                    prodreg = 0
                End If

                pvprod = 0
                mlSQL = "SELECT sum(produp),sum(postingup) FROM st_sale_prd_head where ((nodist like '" & sapa & "') and (alokbulan = '" & wulan & "') and (aloktahun = '" & nahun & "'))"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    pvprod = 0
                    pvku = 0
                Else
                    pvprod = mlREADER("sum(produp)")
                    pvku = mlREADER("sum(postingup)")
                End If
                mlREADER.Close()

                If IsDBNull(pvprod) = False Then
                    pvprod = pvprod + prodreg + produp + proddepo
                Else
                    pvprod = produp + prodreg + proddepo
                End If

                pvreg = 0
                mlSQL = "SELECT sum(pvpri) FROM st_sale_daftar where ((noseri like '" & sapa & "') and (alokbulan = '" & wulan & "') and (aloktahun = '" & nahun & "'))"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    pvreg = 0
                Else
                    pvreg = mlREADER("sum(pvpri)")
                End If
                mlREADER.Close()

                If IsDBNull(pvreg) = False Then
                    pvreg = pvreg
                Else
                    pvreg = 0
                End If

                If IsDBNull(pvku) = False Then
                    pvku = pvku + pvreg + nilaipv + pvdepo
                Else
                    pvku = 0 + pvreg + nilaipv + pvdepo
                End If

                mlSQL = "SELECT * FROM bns_mypv_current where ((kta like '" & sapa & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumpvki = 0
                    jumpvka = 0
                    ada = "F"
                    jummurni = 0
                Else
                    ada = "T"
                    jumpvki = mlREADER("pvgrupkiri")
                    jumpvka = mlREADER("pvgrupkanan")
                    jummurni = mlREADER("pvmurni") + pvnya
                End If
                mlREADER.Close()

                If IsDBNull(jummurni) Then
                    jummurni = pvnya
                Else
                    jummurni = jummurni
                End If

                If ada = "F" Then
                    mlSQL = "Insert into bns_mypv_current(kta,bulan,tahun,pvpribadi,produp,pvmurni,pvgrupkiri,pvgrupkanan)Values('" & sapa & "','" & wulan & "'" & vbCrLf
                    mlSQL += ",'" & nahun & "','" & pvku & "','" & pvprod & "','" & pvnya & "','" & jumpvki & "','" & jumpvka & "')"
                Else
                    mlSQL = "UPDATE bns_mypv_current SET produp = '" & pvprod & "', pvpribadi= '" & pvku & "' , pvmurni= '" & jummurni & "' WHERE (((bulan = " & wulan & ") and (tahun = " & nahun & ")) and (kta like '" & sapa & "'))"
                End If
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                ''''''''''''''''''''''''''''''''''''''''''
                ' update 
                ' add pv reg upgarde
                ' jangan dibalik, karena bisa double pv
                ''''''''''''''''''''''''''''''''''''''''''
                mlSQL = "Insert into bns_mypv_prod_reg(kta,bulan,tahun,produp)Values('" & sapa & "','" & wulan & "','" & nahun & "','" & produp & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                mlSQL = "Update st_sale_daftar set pvpri = '" & nilaipvpri & "',alokbulan = '" & wulan & "',aloktahun = '" & nahun & "',tipe = 'normal'" & vbCrLf
                mlSQL += "where nopos Like '" & mypos & "' and noseri like '" & sapa & "' and noslip like '" & noinvo & "'"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                nilaipv = postingup
                jume = postingup
                direk = direknya
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' sesi upgrade sponsor
                ' DIRECT SPONSOR UPDATE TABLE
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''                                                     
                mlSQL = "SELECT * FROM bns_mybonref where ((kta like '" & direknya & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    mlSQL2 = "insert into bns_mybonref(kta,bulan,tahun,premium,regular,spot,promo,nppr,npp1,nreg,upg,titan,regpromo,premiumsp,platinumsp,prempromo)" & vbCrLf
                    mlSQL2 += "Values('" & direknya & "','" & wulan & "','" & nahun & "',0,0,0,0,0,0,0,0,0,0,0,0,1)"
                Else
                    mlSQL2 = "Update bns_mybonref set prempromo = '" & mlREADER("prempromo") + 1 & "' where ((kta like '" & direknya & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                End If
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER.Close()

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' FAST TRACK PLAN
                ' GANTI dan TAMBAH KODE PAKET BILA ADA LEBIH DARI 2 PAKET
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If UCase(paket) = "UFT1" Or UCase(paket) = "UFT2" Or UCase(paket) = "UFT3" Or UCase(paket) = "UFT4" Or UCase(paket) = "UFT5" Or UCase(paket) = "UFT6" Or UCase(paket) = "UFT7" Or UCase(paket) = "UFT8" Or UCase(paket) = "UFT2-14" Or UCase(paket) = "UFT1-14" Then
                    tglku = Now.Date
                    tglini = Day(tglku)
                    bulanini = Month(tglku)
                    bulanikis = Month(tglku)
                    tauniki = Year(tglku)

                    mlSQL = "SELECT * FROM kapan where (((day(awal) = '" & tglini & "') and (month(awal) = '" & bulanini & "') and (year(awal) = '" & tauniki & "'))" & vbCrLf
                    mlSQL += "Or ((day(t2) = '" & tglini & "') and (month(t2) = '" & bulanini & "') and (year(t2) = '" & tauniki & "')) or ((day(t3) = '" & tglini & "')" & vbCrLf
                    mlSQL += "And (month(t3) = '" & bulanini & "') and (year(t3) = '" & tauniki & "')) or ((day(t4) = '" & tglini & "') and (month(t4) = '" & bulanini & "')" & vbCrLf
                    mlSQL += "And (year(t4) = '" & tauniki & "')) or ((day(t5) = '" & tglini & "') and (month(t5) = '" & bulanini & "') and (year(t5) = '" & tauniki & "'))" & vbCrLf
                    mlSQL += "Or ((day(t6) = '" & tglini & "') and (month(t6) = '" & bulanini & "') and (year(t6) = '" & tauniki & "')) or ((day(akhir) = '" & tglini & "') and (month(akhir) = '" & bulanini & "') and (year(akhir) = '" & tauniki & "')))"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        tglbayar = Date.Now.AddDays(4).ToShortDateString()
                        perik_promo = DatePart("ww", Now.Date)
                        nahun_promo = Year(tglku)
                        wulan_promo = Month(tglku)
                        wulan_pajak = Month(tglbayar)
                        nahun_pajak = Year(tglbayar) ' untuk menentukan masuk pembayaran pajak pada bulan / tahun apa	
                    Else
                        tglbayar = CDate(mlREADER("akhir")).AddDays(4)
                        perik_promo = mlREADER("minggu")
                        nahun_promo = Year(mlREADER("awal"))
                        wulan_promo = Month(mlREADER("awal"))
                        wulan_pajak = Month(tglbayar)
                        nahun_pajak = Year(tglbayar) ' untuk menentukan masuk pembayaran pajak pada bulan / tahun apa
                    End If
                    mlREADER.Close()

                    bonft1 = 0
                    mlSQL = "SELECT * FROM bns_kurs"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        bonft1 = 0
                    Else
                        bonft1 = mlREADER("fsbuft1")
                    End If
                    mlREADER.Close()

                    bonft = 0
                    If UCase(paket) = "UFT1" Or UCase(paket) = "UFT2" Or UCase(paket) = "UFT3" Or UCase(paket) = "UFT4" Or UCase(paket) = "UFT5" Or UCase(paket) = "UFT6" Or UCase(paket) = "UFT7" Or UCase(paket) = "UFT8" Or UCase(paket) = "UFT9" Or UCase(paket) = "UFT10" Then
                        bonft = bonft1
                    Else
                        bonft = 0
                    End If

                    p_one = 0
                    p_tu = 1
                    pred = 0
                    If UCase(paket) = "UFT1" Then
                        bonft = bonft
                        pred = p_tu
                    Else
                        If UCase(paket) = "UFT2" Then
                            bonft = 120000
                            pred = 1
                        Else
                            If UCase(paket) = "UFT3" Then
                                bonft = 120000
                                pred = p_one
                            Else
                                If UCase(paket) = "UFT4" Then
                                    bonft = 120000
                                    pred = p_one
                                Else
                                    If UCase(paket) = "UFT5" Then
                                        bonft = bonft
                                        pred = p_one
                                    Else
                                        If UCase(paket) = "UFT6" Then
                                            bonft = bonft
                                            pred = p_one
                                        Else
                                            If UCase(paket) = "UFT7" Then
                                                bonft = bonft
                                                pred = p_one
                                            Else
                                                If UCase(paket) = "UFT8" Then
                                                    bonft = bonft
                                                    pred = p_one
                                                Else
                                                    If UCase(paket) = "UFT2-14" Then
                                                        bonft = 120000
                                                        pred = 1
                                                    Else
                                                        If UCase(paket) = "UFT1-14" Then
                                                            bonft = 120000
                                                            pred = 1
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If


                    mlSQL = "SELECT * FROM minggu_fsb where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        mlSQL2 = "Insert into minggu_fsb(minggu,tahun,bulan_pajak,tahun_pajak,kta,amt,jumdir)values('" & perik_promo & "','" & nahun_promo & "','" & wulan_pajak & "','" & nahun_pajak & "','" & direk & "','" & bonft & "',1)"
                    Else
                        mlSQL2 = "Update minggu_fsb set amt = '" & mlREADER("amt") + bonft & "',jumdir = '" & mlREADER("jumdir") + 1 & "' where where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
                    End If
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                    mlREADER.Close()
                End If


                sinten = noser
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' update table temporary untuk dieksekusi waktu muncul invoice
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                mlSQL = "Insert into temp_belum(nopos,noinvo,bulan,tahun,kta,postingup,pred,nambahkiri,nambahkanan,sta,asal,tipe,tgl,hendel,pvfull)" & vbCrLf
                mlSQL += "values('" & mypos & "','" & noinvo & "','" & wulan & "','" & nahun & "','" & sinten & "','" & jume & "','" & pred & "'" & vbCrLf
                mlSQL += ",'" & nambahkiri & "','" & nambahkanan & "','B','UFT','REG','" & tglnyaaa & "','F','" & pvfull & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                'if ucasE(paket) = "REG" then
                '	pred = 0
                '	nambahkiri = 1
                '	nambahkanan = 1
                'else
                pred = CLng(pred)
                nambahkiri = CLng(nambahkiri)
                nambahkanan = CLng(nambahkanan)
                'end if	

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' START HERE FOR LOOPING UPLINE PVGRUP UPDATE
                ' BIKIN TABEL SASARAN UPDATE PARA UPLINENYA
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                piro = 0
                kedua = sinten
                mutere = 0
                jume = postingup
                levke = 0
                For aaxds = 1 To 200000
                    mlSQL = "SELECT * FROM mylevel WHERE kta Like '" & kedua & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        aaxd = 200020
                        Exit For
                    Else
                        If mlREADER("ktaloc") = "A" Then
                            aax = 200020
                            ent = "F"
                            Exit For
                        Else
                            ent = "F"
                            piro = piro + 1
                            levke = levke + 1
                            kedua = mlREADER("ktaloc")
                            posloc = mlREADER("posloc")
                            spld = mlREADER("ktaloc")
                            posef = mlREADER("posloc")
                            dowo = Len(spld)

                            '	Call OpenDBG()
                            '	strSQLG = "INSERT INTO mydistri_power (kta,ktadir,pose,level,upline,poseupline,namadir) VALUES ('"&kedua&"','"&sinten&"','"&posef&"',"&levke&",'"&uplinemu&"','"&poseupmu&"','"&jenengmu&"')"
                            '	Set rsG =  dBConnG.Execute(strSQLG)
                            '	Call CloseDBG()

                            staluup = UCase(mlREADER("sta"))

                            opoupnye = Right(spld, 2)
                            If (opoupnye = "-2" Or opoupnye = "-3") Or (staluup = "F") Then
                                uplu = "F"
                                okelahklo = "T" ' biar bisa di recover setiap saat bila ada yang kelewat kena suspend
                            Else
                                uplu = "T"
                                okelahklo = "T"
                            End If


                            If uplu = "T" Then
                                mlSQL2 = "SELECT * FROM bns_mypv_current WHERE ((kta LIKE '" & spld & "') and (bulan='" & wulan & "' and tahun = '" & nahun & "'))"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                mlREADER2.Read()
                                If Not mlREADER2.HasRows Then
                                    If posef = "L" Then
                                        pvgrupkiri = jume
                                        pvgrupkanan = 0
                                        pvfull_kiri = pvfull
                                        pvfull_kanan = 0
                                    Else
                                        pvgrupkiri = 0
                                        pvgrupkanan = jume
                                        pvfull_kiri = 0
                                        pvfull_kanan = pvfull
                                    End If
                                    'rsALL.update
                                    mlSQL3 = "insert into bns_mypv_current(kta,bulan,tahun,pvpribadi,produp,pvmurni,pvgrupkiri,pvgrupkanan,pvfull_kiri,pvfull_kanan)" & vbCrLf
                                    mlSQL3 += "values('" & spld & "','" & wulan & "','" & nahun & "',0,0,0,'" & pvgrupkiri & "','" & pvgrupkanan & "','" & pvfull_kiri & "','" & pvfull_kanan & "')"
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                Else
                                    If posef = "L" Then
                                        kiri = mlREADER2("pvgrupkiri") + jume
                                        kirifull = mlREADER2("pvfull_kiri") + pvfull
                                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia	
                                        mlSQL3 = "UPDATE bns_mypv_current SET pvgrupkiri = '" & kiri & "',pvfull_kiri = '" & kirifull & "' WHERE (((bulan = " & wulan & ") and (tahun = " & nahun & ")) and (kta like '" & spld & "'))"
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)


                                        mlSQL3 = "UPDATE bonpas SET totkiri=totkiri+" & nambahkiri & " WHERE kta like '" & spld & "'"
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                    Else
                                        If posef = "R" Then
                                            kanan = mlREADER2("pvgrupkanan") + jume
                                            kananfull = mlREADER2("pvfull_kanan") + pvfull
                                            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia						

                                            mlSQL3 = "UPDATE bns_mypv_current SET pvgrupkanan = '" & kanan & "',pvfull_kanan = '" & kananfull & "' WHERE (((bulan = " & wulan & ") and (tahun = " & nahun & ")) and (kta like '" & spld & "'))"
                                            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                            mlSQL3 = "UPDATE bonpas SET totkanan=totkanan+" & nambahkanan & " WHERE kta like '" & spld & "'"
                                            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                        End If
                                    End If
                                End If
                                mlREADER2.Close()


                                If pred > 0 And (dowo = 7 Or dowo = 8) Then
                                    mlSQL2 = "SELECT * FROM bns_titirews where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                    mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                    mlREADER2.Read()
                                    If Not mlREADER2.HasRows Then
                                        'rsALL.addnew
                                        If posef = "L" Then
                                            strKta = spld
                                            intKiri = pred
                                            intKanan = 0
                                            intBulan = wulan
                                            intTahun = nahun
                                            intTupo = 0
                                        Else
                                            If posef = "R" Then
                                                strKta = spld
                                                intKiri = 0
                                                intKanan = pred
                                                intBulan = wulan
                                                intTahun = nahun
                                                intTupo = 0
                                                strUpdt = "F"
                                            End If
                                        End If
                                        mlSQL3 = "insert into bns_titirews(kta,kiri,kanan,bulan,tahun,tupo,updt)values('" & strKta & "','" & intKiri & "','" & intKanan & "','" & intBulan & "'" & vbCrLf
                                        mlSQL3 += ",'" & intTahun & "','" & intTupo & "','" & strUpdt & "')"
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                        'rsALL.update
                                    Else
                                        'rsALL.update
                                        If posef = "L" Then
                                            intKiri = mlREADER2("kiri") + pred
                                            mlSQL3 = "Update bns_titirews set kiri = '" & intKiri & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                        Else
                                            If posef = "R" Then
                                                intKanan = mlREADER2("kanan") + pred
                                                mlSQL3 = "Update bns_titirews set kanan = '" & intKanan & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                            End If
                                        End If
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                    End If
                                    mlREADER2.Close()
                                End If
                            End If

                            If okelahklo = "T" Then
                                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								
                                mlSQL2 = "INSERT INTO temp_all_trans (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull)" & vbCrLf
                                mlSQL2 += "VALUES('" & mypos & "'," & wulan & "," & nahun & ",'" & sinten & "','" & spld & "'," & jume & ",'" & posef & "','UFT','B','" & noinvo & "'" & vbCrLf
                                mlSQL2 += ",'REG','T'," & pred & "," & nambahkiri & "," & nambahkanan & "," & pvfull & ")"
                                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                            End If
                        End If
                    End If
                    mlREADER.Close()
                    aaxds = aaxds + 1
                    If aaxds > 200000 Then
                        Exit For
                    End If
                Next
                'rs.close
                mutere = piro * 2

                al1 = CStr(sinten) + "-2"
                al2 = CStr(sinten) + "-3"
                If jumbc = 3 Then
                    piro = 0
                    kedua = al1
                    mutere = 0
                    levke = 0
                    For aaxds = 1 To 200000
                        mlSQL = "SELECT * FROM mylevel WHERE kta LIKE '" & kedua & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            aaxd = 200020
                            Exit For
                        Else
                            If mlREADER("ktaloc") = "A" Then
                                aax = 200020
                                ent = "F"
                                Exit For
                            Else
                                ent = "F"
                                piro = piro + 1
                                levke = levke + 1
                                kedua = mlREADER("ktaloc")
                                'posloc = rs("posloc")
                                'spld = rs("ktaloc")
                                posef = mlREADER("posloc")

                                mlSQL2 = "INSERT INTO mydistri_power (kta,ktadir,pose,level,upline,poseupline,namadir) VALUES ('" & kedua & "','" & sinten & "','" & posef & "'," & levke & ",'" & uplinemu & "','" & poseupmu & "','" & jenengmu & "')"
                                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                            End If
                        End If
                        mlREADER.Close()

                        aaxds = aaxds + 1
                        If aaxds > 200000 Then
                            Exit For
                        End If
                    Next
                    'rs.close
                    mutere = piro * 2
                    piro = 0
                    kedua = al2
                    mutere = 0
                    levke = 0
                    For aaxds = 1 To 200000
                        mlSQL = "SELECT * FROM mylevel WHERE kta LIKE '" & kedua & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            aaxd = 200020
                            Exit For
                        Else
                            If mlREADER("ktaloc") = "A" Then
                                aax = 200020
                                ent = "F"
                                Exit For
                            Else
                                ent = "F"
                                piro = piro + 1
                                levke = levke + 1
                                kedua = mlREADER("ktaloc")
                                'posloc = rs("posloc")
                                'spld = rs("ktaloc")
                                posef = mlREADER("posloc")

                                mlSQL2 = "INSERT INTO mydistri_power (kta,ktadir,pose,level,upline,poseupline,namadir) VALUES ('" & kedua & "','" & sinten & "','" & posef & "'," & levke & ",'" & uplinemu & "','" & poseupmu & "','" & jenengmu & "')"
                                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                            End If
                        End If
                        mlREADER.Close()
                        aaxds = aaxds + 1
                        If aaxds > 200000 Then
                            Exit For
                        End If
                    Next
                    'rs.close
                    mutere = piro * 2
                End If

                Dim keo, oek As String
                keo = "S"
                oek = "T"

                mlSQL = "UPDATE temp_belum SET hendel = '" & oek & "',sta = '" & keo & "' WHERE bulan = " & wulan & " and tahun = " & nahun & " and nopos like '" & mypos & "' and noinvo like '" & noinvo & "'"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If ' akhir lanjut



            bulan = wulan
            tahun = nahun
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' BIKIN UPDATEAN TANGGAL EXPIRED BERDASARKAN BULAN UPGRADE ACCOUNT
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If bulan = 4 Or bulan = 6 Or bulan = 9 Or bulan = 11 Then
                lastday1 = 30
            Else
                If bulan = 1 Or bulan = 3 Or bulan = 5 Or bulan = 7 Or bulan = 8 Or bulan = 10 Or bulan = 12 Then
                    lastday1 = 31
                Else
                    If bulan = 2 Then
                        'if  ((cint(tahun) mod 4 = 0  and cint(tahun) mod 100 <> 0) or ( cint(tahun) mod 400 = 0)) then
                        lastday1 = 28
                        'else
                        '	lastday1 = 29
                        'end if	
                    End If
                End If
            End If
            tglskr = CDate(CStr(tahun) + "-" + CStr(bulan) + "-" + CStr(lastday1))

            expbln = Month(DateAdd("m", 12, tglskr))
            expthn = Year(DateAdd("m", 12, tglskr))
            If expbln = 4 Or expbln = 6 Or expbln = 9 Or expbln = 11 Then
                lastday = 30
            Else
                If expbln = 1 Or expbln = 3 Or expbln = 5 Or expbln = 7 Or expbln = 8 Or expbln = 10 Or expbln = 12 Then
                    lastday = 31
                Else
                    If expbln = 2 Then
                        'if  ((cint(expthn) mod 4 = 0  and cint(expthn) mod 100 <> 0) or ( cint(expthn) mod 400 = 0)) then
                        lastday = 28
                        'else
                        '	lastday = 29
                        'end if	
                    End If
                End If
            End If
            tglexpiredac = CDate(CStr(expthn) + "-" + CStr(expbln) + "-" + CStr(lastday))

            '''''''''''''''''''''''''''''''''''''''
            ' UPDATE INFORMASI LAST TUTUP POINT
            '''''''''''''''''''''''''''''''''''''''
            mlSQL = "SELECT TOP 1 * FROM bonpas where kta like '" & noser & "' order by id desc"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                totdirkiri = 0
                totdirkanan = 0
            Else
                totdirkiri = mlREADER("totkiri")
                totdirkanan = mlREADER("totkanan")
            End If
            mlREADER.Close()

            mlSQL = "SELECT direk,alok FROM member WHERE kta like '" & noser & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                direknya = "-"
                alocnya = "-"
            Else
                direknya = mlREADER("direk")
                alocnya = mlREADER("alok")
            End If
            mlREADER.Close()

            mlSQL = "SELECT * FROM bns_expired_member where kta like '" & noser & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "Insert into bns_expired_member(kta,last_tupo_bulan,last_tupo_tahun,re_entry,tglexpired,direk,alok,kiri,kanan)" & vbCrLf
                mlSQL2 += "values('" & noser & "','" & bulan & "','" & tahun & "','T','" & tglexpiredac & "','" & direknya & "','" & alocnya & "','" & totdirkiri & "','" & totdirkanan & "')"
            Else
                mlSQL2 = "update bns_expired_member set last_tupo_bulan = '" & bulan & "',last_tupo_tahun = '" & tahun & "',re_entry = 'T',tglexpired = '" & tglexpiredac & "'" & vbCrLf
                mlSQL2 += "where kta like '" & noser & "'"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()



            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia		
            Session("noinvo_ft") = noinvo
            Response.Redirect("sale_reentry_inv.aspx?menu_id=" & noser)
            'response.redirect "akt_form.asp?menu_id="&menu_id
        Else
            Dim error1 As String = "", error2 As String = "", error3 As String = "", error4 As String = ""
            Dim strResponsive2 As String = ""

            strResponsive2 += " <section Class='content'>" & vbCrLf
            strResponsive2 += "<div Class='box'>" & vbCrLf
            strResponsive2 += "<div Class='box-header with-border'>" & vbCrLf
            strResponsive2 += "<h3 Class='box-title'></h3>" & vbCrLf
            strResponsive2 += "<div Class='box-tools pull-right'>" & vbCrLf
            strResponsive2 += "<Button type='button' Class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
            strResponsive2 += "<i Class='fa fa-minus'></i></button>" & vbCrLf
            strResponsive2 += "<Button type='button' Class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
            strResponsive2 += "<i Class='fa fa-times'></i></button>" & vbCrLf
            strResponsive2 += "</div>" & vbCrLf
            strResponsive2 += "</div>" & vbCrLf
            strResponsive2 += "<div Class='box-body'>" & vbCrLf
            strResponsive2 += "<p align='center'>" & vbCrLf
            strResponsive2 += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
            strResponsive2 += "<br/>" & vbCrLf
            strResponsive2 += "<br/>" & vbCrLf

            strResponsive2 += "<p align='center'>" & vbCrLf
            strResponsive2 += "ada kesalahan dalam proses pendaftaran, silahkan perbaiki kesalahan seperti yang tertulis dibawah ini.<br/>" & vbCrLf
            If error1 <> "" Then
                strResponsive2 += "" & error1 & " " & vbCrLf
            End If
            If error2 <> "" Then
                strResponsive2 += "" & error2 & "" & vbCrLf
            End If
            If error3 <> "" Then
                strResponsive2 += "" & error3 & " " & vbCrLf
            End If
            If error4 <> "" Then
                strResponsive2 += "" & error4 & " " & vbCrLf
            End If
            strResponsive2 += " < br /> " & vbCrLf
            strResponsive2 += " & lt;-- <a href='sale_reentry.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a> --&gt;</font>" & vbCrLf
            strResponsive2 += "</div>" & vbCrLf
            strResponsive2 += "  </div>" & vbCrLf
            strResponsive2 += "</section>" & vbCrLf

            Div_Responsive.InnerHtml = strResponsive2
        End If
    End Sub

End Class

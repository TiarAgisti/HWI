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
    Dim wulan, wulpos, nahun, nuhun As Integer
    Dim bulanskr, tahunskr, noakhir, bulsks, jk, tahskr, nopajak As Integer
    Dim tamb, blne, taun, nipe, noinvo, kel, masterdc, k1, k2, nourutpjk As String
    Dim cekbg As Double

    Dim aloc, subalo, psa As String
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

        wulan = wulpos
        nahun = nuhun
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

            Dim jumak As Integer
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

            Dim awal, jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10, jumlah11, jumlah12 As Integer
            Dim kode_prd1, kode_prd2, kode_prd3, kode_prd4, kode_prd5, kode_prd6, kode_prd7, kode_prd8, kode_prd9, kode_prd10, kode_prd11, kode_prd12 As String
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
                    mlSQL2 = "Update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - 1 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by kode DESC"
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
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd2&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah2
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah2
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd2&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd2
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah2
                    rsALL("akhir") = jumak - jumlah2
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah2
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd2
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah2
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd2
                rsALL("jumlah") = jumlah2
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd3 <> "" Or kode_prd3 <> "-" Or isnull(kode_prd3) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd3&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah3
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah3
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd3&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd3
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah3
                    rsALL("akhir") = jumak - jumlah3
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah3
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd3
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah3
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd3
                rsALL("jumlah") = jumlah3
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd4 <> "" Or kode_prd4 <> "-" Or isnull(kode_prd4) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd4&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah4
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah4
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd4&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd4
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah4
                    rsALL("akhir") = jumak - jumlah4
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah4
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd4
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah4
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd4
                rsALL("jumlah") = jumlah4
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd5 <> "" Or kode_prd5 <> "-" Or isnull(kode_prd5) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd5&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah5
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah5
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd5&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd5
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah5
                    rsALL("akhir") = jumak - jumlah5
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah5
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd5
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah5
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd5
                rsALL("jumlah") = jumlah5
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd6 <> "" Or kode_prd6 <> "-" Or isnull(kode_prd6) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd6&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah6
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah6
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd6&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd6
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah6
                    rsALL("akhir") = jumak - jumlah6
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah6
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd6
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah6
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd6
                rsALL("jumlah") = jumlah6
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd7 <> "" Or kode_prd7 <> "-" Or isnull(kode_prd7) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd7&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah7
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah7
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd7&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd7
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah7
                    rsALL("akhir") = jumak - jumlah7
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah7
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd7
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah7
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by nopos DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd7
                rsALL("jumlah") = jumlah7
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd8 <> "" Or kode_prd8 <> "-" Or isnull(kode_prd8) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd8&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah8
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah8
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd8&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd8
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah8
                    rsALL("akhir") = jumak - jumlah8
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah8
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd8
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah8
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by nopos DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd8
                rsALL("jumlah") = jumlah8
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd9 <> "" Or kode_prd9 <> "-" Or isnull(kode_prd9) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd9&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah9
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah9
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd9&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd9
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah9
                    rsALL("akhir") = jumak - jumlah9
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah9
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd9
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah9
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by nopos DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd9
                rsALL("jumlah") = jumlah9
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd10 <> "" Or kode_prd10 <> "-" Or isnull(kode_prd10) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd10&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah10
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah10
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd10&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd10
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah10
                    rsALL("akhir") = jumak - jumlah10
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah10
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd10
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah10
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd10
                rsALL("jumlah") = jumlah10
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd11 <> "" Or kode_prd11 <> "-" Or isnull(kode_prd11) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd11&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah11
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah11
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd11&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd11
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah11
                    rsALL("akhir") = jumak - jumlah11
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah11
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd11
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah11
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd11
                rsALL("jumlah") = jumlah11
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If

            If kode_prd12 <> "" Or kode_prd12 <> "-" Or isnull(kode_prd12) = False Then
                rsALL.Open "SELECT * FROM " & namatabel&" where nopos like '"&mypos&"' and kode like '"&kode_prd12&"' order by kode DESC LIMIT 1", connALL, 3, 3
        If rsALL.bof Then
                    jumak = 0
                Else
                    jumak = rsALL("jumlah")
                    rsALL.update
                    rsALL("jumlah") = rsALL("jumlah") - jumlah12
                    rsALL.update
                End If
                rsALL.close

                If jumak <= 0 Then
                    jumak = jumlah12
                Else
                    jumak = jumak
                End If

                ' KARTU STOCK
                rsALL.Open "SELECT * FROM " & namatabel2&" where nopos like '"&mypos&"' and kode like '"&kode_prd12&"' order by tgl DESC, id DESC LIMIT 3", connALL, 3, 3
        If rsALL.bof Then
                    rsALL.addnew
                    rsALL("kode") = kode_prd12
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = jumak
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah12
                    rsALL("akhir") = jumak - jumlah12
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                Else
                    awal = rsALL("akhir")
                    sisastok = awal - jumlah12
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    rsALL.addnew
                    rsALL("kode") = kode_prd12
                    rsALL("nopos") = mypos
                    rsALL("tgl") = dino
                    rsALL("awal") = awal
                    rsALL("masuk") = 0
                    rsALL("keluar") = jumlah12
                    rsALL("akhir") = sisastok
                    rsALL("referensi") = noinvo
                    rsALL("keterangan") = "Produk Penjualan FastTrack"
                    rsALL.update
                End If
                rsALL.close

                ' simpan produk rekap harian
                rsALL.Open "SELECT * FROM st_sale_daftar_rekap order by id DESC LIMIT 1", connALL, 3, 3
        rsALL.addnew
                rsALL("tgl") = dino
                rsALL("nopos") = mypos
                rsALL("kode") = kode_prd12
                rsALL("jumlah") = jumlah12
                rsALL("noslip") = noinvo
                rsALL("dcinduk") = indukdc
                rsALL("nopajak") = nourutpjk
                rsALL.update
                rsALL.close
            End If


            rsALL.Open "SELECT * FROM st_sale_daftar_prd where noslip like '" & noinvo&"'", connALL, 3, 3
    If rsALL.bof Then
                rsALL.addnew
                rsALL("noslip") = noinvo
                rsALL("tgl") = dino
                rsALL("nopajak") = nourutpjk
                If kode_prd1 <> "" Or kode_prd1 <> "-" Or isnull(kode_prd1) = False Then
                    rsALL("kode1") = kode_prd1
                    rsALL("jumlah1") = jumlah1
                Else
                    rsALL("kode1") = "-"
                    rsALL("jumlah1") = 0
                End If
                If kode_prd2 <> "" Or kode_prd2 <> "-" Or isnull(kode_prd2) = False Then
                    rsALL("kode2") = kode_prd2
                    rsALL("jumlah2") = jumlah2
                Else
                    rsALL("kode2") = "-"
                    rsALL("jumlah2") = 0
                End If
                If kode_prd3 <> "" Or kode_prd3 <> "-" Or isnull(kode_prd3) = False Then
                    rsALL("kode3") = kode_prd3
                    rsALL("jumlah3") = jumlah3
                Else
                    rsALL("kode3") = "-"
                    rsALL("jumlah3") = 0
                End If
                If kode_prd4 <> "" Or kode_prd4 <> "-" Or isnull(kode_prd4) = False Then
                    rsALL("kode4") = kode_prd4
                    rsALL("jumlah4") = jumlah4
                Else
                    rsALL("kode4") = "-"
                    rsALL("jumlah4") = 0
                End If
                If kode_prd5 <> "" Or kode_prd5 <> "-" Or isnull(kode_prd5) = False Then
                    rsALL("kode5") = kode_prd5
                    rsALL("jumlah5") = jumlah5
                Else
                    rsALL("kode5") = "-"
                    rsALL("jumlah5") = 0
                End If
                If kode_prd6 <> "" Or kode_prd6 <> "-" Or isnull(kode_prd6) = False Then
                    rsALL("kode6") = kode_prd6
                    rsALL("jumlah6") = jumlah6
                Else
                    rsALL("kode6") = "-"
                    rsALL("jumlah6") = 0
                End If
                If kode_prd7 <> "" Or kode_prd7 <> "-" Or isnull(kode_prd7) = False Then
                    rsALL("kode7") = kode_prd7
                    rsALL("jumlah7") = jumlah7
                Else
                    rsALL("kode7") = "-"
                    rsALL("jumlah7") = 0
                End If
                If kode_prd8 <> "" Or kode_prd8 <> "-" Or isnull(kode_prd8) = False Then
                    rsALL("kode8") = kode_prd8
                    rsALL("jumlah8") = jumlah8
                Else
                    rsALL("kode8") = "-"
                    rsALL("jumlah8") = 0
                End If
                If kode_prd9 <> "" Or kode_prd9 <> "-" Or isnull(kode_prd9) = False Then
                    rsALL("kode9") = kode_prd9
                    rsALL("jumlah9") = jumlah9
                Else
                    rsALL("kode9") = "-"
                    rsALL("jumlah9") = 0
                End If
                If kode_prd10 <> "" Or kode_prd10 <> "-" Or isnull(kode_prd10) = False Then
                    rsALL("kode10") = kode_prd10
                    rsALL("jumlah10") = jumlah10
                Else
                    rsALL("kode10") = "-"
                    rsALL("jumlah10") = 0
                End If
                If kode_prd11 <> "" Or kode_prd11 <> "-" Or isnull(kode_prd11) = False Then
                    rsALL("kode11") = kode_prd11
                    rsALL("jumlah11") = jumlah11
                Else
                    rsALL("kode11") = "-"
                    rsALL("jumlah11") = 0
                End If
                If kode_prd12 <> "" Or kode_prd12 <> "-" Or isnull(kode_prd12) = False Then
                    rsALL("kode12") = kode_prd12
                    rsALL("jumlah12") = jumlah12
                Else
                    rsALL("kode12") = "-"
                    rsALL("jumlah12") = 0
                End If
                rsALL("dcinduk") = indukdc
                rsALL.update
            Else
                rsALL.update
                rsALL("nopajak") = nourutpjk
                If kode_prd1 <> "" Or kode_prd1 <> "-" Or isnull(kode_prd1) = False Then
                    rsALL("kode1") = kode_prd1
                    rsALL("jumlah1") = jumlah1
                Else
                    rsALL("kode1") = "-"
                    rsALL("jumlah1") = 0
                End If
                If kode_prd2 <> "" Or kode_prd2 <> "-" Or isnull(kode_prd2) = False Then
                    rsALL("kode2") = kode_prd2
                    rsALL("jumlah2") = jumlah2
                Else
                    rsALL("kode2") = "-"
                    rsALL("jumlah2") = 0
                End If
                If kode_prd3 <> "" Or kode_prd3 <> "-" Or isnull(kode_prd3) = False Then
                    rsALL("kode3") = kode_prd3
                    rsALL("jumlah3") = jumlah3
                Else
                    rsALL("kode3") = "-"
                    rsALL("jumlah3") = 0
                End If
                If kode_prd4 <> "" Or kode_prd4 <> "-" Or isnull(kode_prd4) = False Then
                    rsALL("kode4") = kode_prd4
                    rsALL("jumlah4") = jumlah4
                Else
                    rsALL("kode4") = "-"
                    rsALL("jumlah4") = 0
                End If
                If kode_prd5 <> "" Or kode_prd5 <> "-" Or isnull(kode_prd5) = False Then
                    rsALL("kode5") = kode_prd5
                    rsALL("jumlah5") = jumlah5
                Else
                    rsALL("kode5") = "-"
                    rsALL("jumlah5") = 0
                End If
                If kode_prd6 <> "" Or kode_prd6 <> "-" Or isnull(kode_prd6) = False Then
                    rsALL("kode6") = kode_prd6
                    rsALL("jumlah6") = jumlah6
                Else
                    rsALL("kode6") = "-"
                    rsALL("jumlah6") = 0
                End If
                If kode_prd7 <> "" Or kode_prd7 <> "-" Or isnull(kode_prd7) = False Then
                    rsALL("kode7") = kode_prd7
                    rsALL("jumlah7") = jumlah7
                Else
                    rsALL("kode7") = "-"
                    rsALL("jumlah7") = 0
                End If
                If kode_prd8 <> "" Or kode_prd8 <> "-" Or isnull(kode_prd8) = False Then
                    rsALL("kode8") = kode_prd8
                    rsALL("jumlah8") = jumlah8
                Else
                    rsALL("kode8") = "-"
                    rsALL("jumlah8") = 0
                End If
                If kode_prd9 <> "" Or kode_prd9 <> "-" Or isnull(kode_prd9) = False Then
                    rsALL("kode9") = kode_prd9
                    rsALL("jumlah9") = jumlah9
                Else
                    rsALL("kode9") = "-"
                    rsALL("jumlah9") = 0
                End If
                If kode_prd10 <> "" Or kode_prd10 <> "-" Or isnull(kode_prd10) = False Then
                    rsALL("kode10") = kode_prd10
                    rsALL("jumlah10") = jumlah10
                Else
                    rsALL("kode10") = "-"
                    rsALL("jumlah10") = 0
                End If
                If kode_prd11 <> "" Or kode_prd11 <> "-" Or isnull(kode_prd11) = False Then
                    rsALL("kode11") = kode_prd11
                    rsALL("jumlah11") = jumlah11
                Else
                    rsALL("kode11") = "-"
                    rsALL("jumlah11") = 0
                End If
                If kode_prd12 <> "" Or kode_prd12 <> "-" Or isnull(kode_prd12) = False Then
                    rsALL("kode12") = kode_prd12
                    rsALL("jumlah12") = jumlah12
                Else
                    rsALL("kode12") = "-"
                    rsALL("jumlah12") = 0
                End If
                rsALL.update
            End If
            rsALL.close

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

                rs.Open "SELECT * FROM member where kta LIKE '" & sapa&"'", conn, 1, 3
    If rs.bof Then
                Else
                    rs.update
                    rs("tipene_kartu") = kop
                    rs("tipene") = kop
                    'rs("upme") = upke
                    rs.update
                    direknya = rs("direk")
                    sapa1 = rs("pal1")
                    sapa2 = rs("pal2")
                End If
                rs.close


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
                rs.Open "SELECT grdlevel FROM jenjang where kta like '" & noid&"'", conn
    If rs.bof Then
                    levnya = 1
                Else
                    levnya = CInt(rs("grdlevel"))
                End If
                rs.close

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
                rs.Open "SELECT grdlevel FROM jenjang where kta like '" & noid&"'", conn
    If rs.bof Then
                    levnya = 1
                Else
                    levnya = CInt(rs("grdlevel"))
                End If
                rs.close

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
                    rs.Open "SELECT pvpribadi,produp FROM bns_mypv_current where ((kta like '" & noid&"') and (bulan = '"&wulan&"') and (tahun = '"&nahun&"'))", conn, 3, 3
        If rs.bof Then
                        pvnow = pvnya
                        pvnow2 = 0
                        pvnow3 = 0
                        nilaibv = 0
                        prodada = 0
                    Else
                        pvnow = (rs("pvpribadi") + rs("produp")) + pvnya
                        pvnow2 = rs("pvpribadi") + rs("produp")
                        pvnow3 = rS("pvpribadi") + pvnya
                        prodada = rs("produp")
                        nilaibv = 0
                    End If
                    rs.close

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
                    rs.Open "SELECT pvpribadi,produp FROM bns_mypv_current where ((kta like '" & noid&"') and (bulan = '"&wulan&"') and (tahun = '"&nahun&"'))", conn, 3, 3
        If rs.bof Then
                        pvnow = pvnya
                        nilaibv = 0
                    Else
                        pvnow = (rs("pvpribadi") + rs("produp"))
                        nilaibv = 0
                    End If
                    rs.close

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

%>
<!--#Include File=../dbcon/calldbG.asp-->
<%
Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia


                ''''''''''''''''''''''''''''''''''''
                ' cari pv register sebelum upgrade
                ''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' PV DEPOSIT RELEASE BERASAL DARI BNS_DEPOSITDANA YANG DIRELEASE PADA SAAT CLOSING PERIODE
                ' KEDALAM TABLE BNS_DEPOSITRELEASE SESUAI SPLIT POINT YANG BERLAKU KUALIFIKASINYA
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                proddepo = 0
                pvdepo = 0
                rs.Open "SELECT * FROM bns_depositrelease where ((kta like '" & sapa&"') and (bulan = '"&wulan&"') and (tahun = '"&nahun&"'))", conn
    If rs.bof Then
                    proddepo = 0
                    pvdepo = 0
                Else
                    proddepo = rs("pvprod")
                    pvdepo = rs("pvpri")
                End If
                rs.close

                prodreg = 0
                rs.Open "SELECT sum(produp) FROM bns_mypv_prod_reg where ((kta like '" & sapa&"') and (bulan = '"&wulan&"') and (tahun = '"&nahun&"'))", conn
    If rs.bof Then
                    prodreg = 0
                Else
                    prodreg = rs("sum(produp)")
                End If
                rs.close
                If isnull(prodreg) = False Then
                    prodreg = prodreg
                Else
                    prodreg = 0
                End If

                pvprod = 0
                rs.Open "SELECT sum(produp),sum(postingup) FROM st_sale_prd_head where ((nodist like '" & sapa&"') and (alokbulan = '"&wulan&"') and (aloktahun = '"&nahun&"'))", conn, 3, 3
    If rs.bof Then
                    pvprod = 0
                    pvku = 0
                Else
                    pvprod = rs("sum(produp)")
                    pvku = rs("sum(postingup)")
                End If
                rs.close
                If isnull(pvprod) = False Then
                    pvprod = pvprod + prodreg + produp + proddepo
                Else
                    pvprod = produp + prodreg + proddepo
                End If

                pvreg = 0
                rs.Open "SELECT sum(pvpri) FROM st_sale_daftar where ((noseri like '" & sapa&"') and (alokbulan = '"&wulan&"') and (aloktahun = '"&nahun&"'))", conn
    If rs.bof Then
                    pvreg = 0
                Else
                    pvreg = rs("sum(pvpri)")
                End If
                rs.close
                If isnull(pvreg) = False Then
                    pvreg = pvreg
                Else
                    pvreg = 0
                End If

                If isnull(pvku) = False Then
                    pvku = pvku + pvreg + nilaipv + pvdepo
                Else
                    pvku = 0 + pvreg + nilaipv + pvdepo
                End If

                rs.Open "SELECT * FROM bns_mypv_current where ((kta like '" & sapa&"') and (bulan = '"&wulan&"') and (tahun = '"&nahun&"'))", conn, 3, 3
    If rs.bof Then
                    jumpvki = 0
                    jumpvka = 0
                    ada = "F"
                    jummurni = 0
                Else
                    ada = "T"
                    jumpvki = rs("pvgrupkiri")
                    jumpvka = rs("pvgrupkanan")
                    jummurni = rs("pvmurni") + pvnya
                End If
                rs.close
                If isnull(jummurni) Then
                    jummurni = pvnya
                Else
                    jummurni = jummurni
                End If

                If ada = "F" Then
                    rs.Open "SELECT * FROM bns_mypv_current", conn, 3, 3
        rs.addnew
                    rs("kta") = sapa
                    rs("bulan") = wulan
                    rs("tahun") = nahun
                    rs("pvpribadi") = pvku
                    rs("produp") = pvprod
                    rs("pvmurni") = pvnya
                    rs("pvgrupkiri") = jumpvki
                    rs("pvgrupkanan") = jumpvka

                    rs.update
                    rs.close
                Else
                    Call OpenDBG()
                    'strSQLG = "UPDATE bns_mypv_current SET produp = '"&pvprod&"', pvpribadi= '"&pvku&"' WHERE (((bulan = "&wulan&") and (tahun = "&nahun&")) and (kta like '"&sapa&"'))"
                    strSQLG = "UPDATE bns_mypv_current SET produp = '" & pvprod&"', pvpribadi= '"&pvku&"' , pvmurni= '"&jummurni&"' WHERE (((bulan = "&wulan&") and (tahun = "&nahun&")) and (kta like '"&sapa&"'))"
	Set rsG =  dBConnG.Execute(strSQLG)
	Call CloseDBG()
                End If

                ''''''''''''''''''''''''''''''''''''''''''
                ' update 
                ' add pv reg upgarde
                ' jangan dibalik, karena bisa double pv
                ''''''''''''''''''''''''''''''''''''''''''
                rs.Open "SELECT * FROM bns_mypv_prod_reg order by id desc LIMIT 1", conn, 3, 3
    rs.addnew
                rs("kta") = sapa
                rs("bulan") = wulan
                rs("tahun") = nahun
                rs("produp") = produp
                rs.update
                rs.close

                rs.Open "SELECT * FROM st_sale_daftar where nopos like '" & mypos&"' and noseri like '"&sapa&"' and noslip like '"&noinvo&"'", conn, 1, 3
    rs.update
                rs("pvpri") = nilaipvpri
                rs("alokbulan") = wulan
                rs("aloktahun") = nahun
                rs("tipe") = "normal"
                rs.update
                'end if	
                rs.close

                nilaipv = postingup
                jume = postingup
                direk = direknya
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' sesi upgrade sponsor
                ' DIRECT SPONSOR UPDATE TABLE
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''                                                     
                rs.Open "SELECT * FROM bns_mybonref where ((kta like '" & direknya&"') and (bulan = '"&wulan&"') and (tahun = '"&nahun&"'))", conn, 3, 3
    If rs.bof Then
                    rs.addnew
                    rs("kta") = direknya
                    rs("bulan") = wulan
                    rs("tahun") = nahun
                    rs("premium") = 0
                    rs("regular") = 0
                    rs("spot") = 0
                    rs("promo") = 0
                    rs("nppr") = 0
                    rs("nppl") = 0
                    rs("nreg") = 0
                    rs("upg") = 0
                    rs("titan") = 0
                    rs("regpromo") = 0
                    rs("premiumsp") = 0
                    rs("platinumsp") = 0
                    rs("prempromo") = 1
                    rs.update
                Else
                    rs.update
                    rs("prempromo") = rs("prempromo") + 1
                    rs.update
                End If
                rs.close

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' FAST TRACK PLAN
                ' GANTI dan TAMBAH KODE PAKET BILA ADA LEBIH DARI 2 PAKET
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If UCase(paket) = "UFT1" Or UCase(paket) = "UFT2" Or UCase(paket) = "UFT3" Or UCase(paket) = "UFT4" Or UCase(paket) = "UFT5" Or UCase(paket) = "UFT6" Or UCase(paket) = "UFT7" Or UCase(paket) = "UFT8" Or UCase(paket) = "UFT2-14" Or UCase(paket) = "UFT1-14" Then
                    tglku = Date()
                    tglini = Day(tglku)
                    bulanini = Month(tglku)
                    bulanikis = Month(tglku)
                    tauniki = Year(tglku)

                    rs.Open "SELECT * FROM kapan where (((day(awal) = '" & tglini&"') and (month(awal) = '"&bulanini&"') and (year(awal) = '"&tauniki&"')) or ((day(t2) = '"&tglini&"') and (month(t2) = '"&bulanini&"') and (year(t2) = '"&tauniki&"')) or ((day(t3) = '"&tglini&"') and (month(t3) = '"&bulanini&"') and (year(t3) = '"&tauniki&"')) or ((day(t4) = '"&tglini&"') and (month(t4) = '"&bulanini&"') and (year(t4) = '"&tauniki&"')) or ((day(t5) = '"&tglini&"') and (month(t5) = '"&bulanini&"') and (year(t5) = '"&tauniki&"')) or ((day(t6) = '"&tglini&"') and (month(t6) = '"&bulanini&"') and (year(t6) = '"&tauniki&"')) or ((day(akhir) = '"&tglini&"') and (month(akhir) = '"&bulanini&"') and (year(akhir) = '"&tauniki&"')))", conn
                If rs.bof Then
                        tglbayar = Date() + 4
                        perik_promo = DatePart("ww", Date())
                        nahun_promo = Year(tglku)
                        wulan_promo = Month(tglku)
                        wulan_pajak = Month(tglbayar)
                        nahun_pajak = Year(tglbayar) ' untuk menentukan masuk pembayaran pajak pada bulan / tahun apa	
                    Else
                        tglbayar = CDate(rs("akhir")) + 4
                        perik_promo = rs("minggu")
                        nahun_promo = Year(rs("awal"))
                        wulan_promo = Month(rs("awal"))
                        wulan_pajak = Month(tglbayar)
                        nahun_pajak = Year(tglbayar) ' untuk menentukan masuk pembayaran pajak pada bulan / tahun apa
                    End If
                    rs.close

                    bonft1 = 0
                    rs.Open "SELECT * FROM bns_kurs", conn
                If rs.bof Then
                        bonft1 = 0
                    Else
                        bonft1 = rs("fsbuft1")
                    End If
                    rs.close

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

                    rs.Open "SELECT * FROM minggu_fsb where minggu='" & perik_promo&"' and tahun='"&nahun_promo&"' and kta like '"&direk&"'", conn, 3, 3
                If rs.bof Then
                        rs.addnew
                        rs("minggu") = perik_promo
                        rs("tahun") = nahun_promo
                        rs("bulan_pajak") = wulan_pajak
                        rs("tahun_pajak") = nahun_pajak
                        rs("kta") = direk
                        rs("amt") = bonft
                        rs("jumdir") = 1
                        rs.update
                    Else
                        rs.update
                        rs("amt") = rs("amt") + bonft
                        rs("jumdir") = rs("jumdir") + 1
                        rs.update
                    End If
                    rs.close
                End If

                sinten = noser
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' update table temporary untuk dieksekusi waktu muncul invoice
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                rs.Open "SELECT * FROM temp_belum order by id desc limit 1", conn, 3, 3
    rs.addnew
                rs("nopos") = mypos
                rs("noinvo") = noinvo
                rs("bulan") = wulan
                rs("tahun") = nahun
                rs("kta") = sinten
                rs("postingup") = jume
                rs("pred") = pred
                rs("nambahkiri") = nambahkiri
                rs("nambahkanan") = nambahkanan
                rs("sta") = "B"
                rs("asal") = "UFT"
                rs("tipe") = "REG"
                rs("tgl") = tglnyaaa
                rs("hendel") = "F"
                rs("pvfull") = pvfull
                rs.update
                rs.close

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
                    rs.Open "SELECT * FROM mylevel WHERE kta LIKE '" & kedua&"'", conn
    If rs.bof Then
                        aaxd = 200020
                        Exit For
                    Else
                        If rs("ktaloc") = "A" Then
                            aax = 200020
                            ent = "F"
                            Exit For
                        Else
                            ent = "F"
                            piro = piro + 1
                            levke = levke + 1
                            kedua = rs("ktaloc")
                            posloc = rs("posloc")
                            spld = rs("ktaloc")
                            posef = rs("posloc")
                            dowo = Len(spld)

                            '	Call OpenDBG()
                            '	strSQLG = "INSERT INTO mydistri_power (kta,ktadir,pose,level,upline,poseupline,namadir) VALUES ('"&kedua&"','"&sinten&"','"&posef&"',"&levke&",'"&uplinemu&"','"&poseupmu&"','"&jenengmu&"')"
                            '	Set rsG =  dBConnG.Execute(strSQLG)
                            '	Call CloseDBG()

                            staluup = UCase(rs("sta"))

                            opoupnye = Right(spld, 2)
                            If (opoupnye = "-2" Or opoupnye = "-3") Or (staluup = "F") Then
                                uplu = "F"
                                okelahklo = "T" ' biar bisa di recover setiap saat bila ada yang kelewat kena suspend
                            Else
                                uplu = "T"
                                okelahklo = "T"
                            End If

                            If uplu = "T" Then
                                rsALL.Open "SELECT * FROM bns_mypv_current WHERE ((kta LIKE '" & spld&"') and (bulan='"&wulan&"' and tahun = '"&nahun&"'))", connALL, 3, 3
                    If rsALL.bof Then
                                    rsALL.addnew
                                    rsALL("kta") = spld
                                    rsALL("bulan") = wulan
                                    rsALL("tahun") = nahun
                                    rsALL("pvpribadi") = 0
                                    rsALL("produp") = 0
                                    rsALL("pvmurni") = 0
                                    If posef = "L" Then
                                        rsALL("pvgrupkiri") = jume
                                        rsALL("pvgrupkanan") = 0
                                        rsALL("pvfull_kiri") = pvfull
                                        rsALL("pvfull_kanan") = 0
                                    Else
                                        rsALL("pvgrupkiri") = 0
                                        rsALL("pvgrupkanan") = jume
                                        rsALL("pvfull_kiri") = 0
                                        rsALL("pvfull_kanan") = pvfull
                                    End If
                                    rsALL.update
                                Else
                                    If posef = "L" Then
                                        kiri = rsALL("pvgrupkiri") + jume
                                        kirifull = rsALL("pvfull_kiri") + pvfull
                                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia	
                                        Call OpenDBG()
                                        strSQLG = "UPDATE bns_mypv_current SET pvgrupkiri = '" & kiri&"',pvfull_kiri = '"&kirifull&"' WHERE (((bulan = "&wulan&") and (tahun = "&nahun&")) and (kta like '"&spld&"'))"
								Set rsG =  dBConnG.Execute(strSQLG)
								Call CloseDBG()

                                        Call OpenDBG()
                                        strSQLG = "UPDATE bonpas SET totkiri=totkiri+" & nambahkiri&" WHERE kta like '"&spld&"'"
								Set rsG =  dBConnG.Execute(strSQLG)
								Call CloseDBG()
                                        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                    Else
                                        If posef = "R" Then
                                            kanan = rsALL("pvgrupkanan") + jume
                                            kananfull = rsALL("pvfull_kanan") + pvfull
                                            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                            intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia						
                                            Call OpenDBG()
                                            strSQLG = "UPDATE bns_mypv_current SET pvgrupkanan = '" & kanan&"',pvfull_kanan = '"&kananfull&"' WHERE (((bulan = "&wulan&") and (tahun = "&nahun&")) and (kta like '"&spld&"'))"
								Set rsG =  dBConnG.Execute(strSQLG)
								Call CloseDBG()

                                            strSQLG = "UPDATE bonpas SET totkanan=totkanan+" & nambahkanan&" WHERE kta like '"&spld&"'"
								Set rsG =  dBConnG.Execute(strSQLG)
								Call CloseDBG()
                                            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                            intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                        End If
                                    End If
                                End If
                                rsALL.close

                                If pred > 0 And (dowo = 7 Or dowo = 8) Then
                                    rsALL.Open "SELECT * FROM bns_titirews where kta like '" & spld&"' and bulan='"&wulan&"' and tahun = '"&nahun&"'", connALL, 3, 3
                        If rsALL.bof Then
                                        rsALL.addnew
                                        If posef = "L" Then
                                            rsALL("kta") = spld
                                            rsALL("kiri") = pred
                                            rsALL("kanan") = 0
                                            rsALL("bulan") = wulan
                                            rsALL("tahun") = nahun
                                            rsALL("tupo") = 0
                                            rsALL("updt") = "F"
                                        Else
                                            If posef = "R" Then
                                                rsALL("kta") = spld
                                                rsALL("kiri") = 0
                                                rsALL("kanan") = pred
                                                rsALL("bulan") = wulan
                                                rsALL("tahun") = nahun
                                                rsALL("tupo") = 0
                                                rsALL("updt") = "F"
                                            End If
                                        End If
                                        rsALL.update
                                    Else
                                        rsALL.update
                                        If posef = "L" Then
                                            rsALL("kiri") = rsALL("kiri") + pred
                                        Else
                                            If posef = "R" Then
                                                rsALL("kanan") = rsALL("kanan") + pred
                                            End If
                                        End If
                                        rsALL.update
                                    End If
                                    rsALL.close
                                End If
                            End If

                            If okelahklo = "T" Then
                                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								
                                Call OpenDBG()
                                strSQLG = "INSERT INTO temp_all_trans (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull) VALUES ('" & mypos&"',"&wulan&","&nahun&",'"&sinten&"','"&spld&"',"&jume&",'"&posef&"','UFT','B','"&noinvo&"','REG','T',"&pred&","&nambahkiri&","&nambahkanan&","&pvfull&")"
					Set rsG =  dBConnG.Execute(strSQLG)
					Call CloseDBG()
                            End If
                        End If
                    End If
                    rs.close
                    aaxds = aaxds + 1
                    If aaxds > 200000 Then
                        Exit For
                    End If
                Next
                rs.close
                mutere = piro * 2

                al1 = CStr(sinten) + "-2"
                al2 = CStr(sinten) + "-3"
                If jumbc = 3 Then
                    piro = 0
                    kedua = al1
                    mutere = 0
                    levke = 0
                    For aaxds = 1 To 200000
                        rs.Open "SELECT * FROM mylevel WHERE kta LIKE '" & kedua&"'", conn
        If rs.bof Then
                            aaxd = 200020
                            Exit For
                        Else
                            If rs("ktaloc") = "A" Then
                                aax = 200020
                                ent = "F"
                                Exit For
                            Else
                                ent = "F"
                                piro = piro + 1
                                levke = levke + 1
                                kedua = rs("ktaloc")
                                'posloc = rs("posloc")
                                'spld = rs("ktaloc")
                                posef = rs("posloc")

                                Call OpenDBG()
                                strSQLG = "INSERT INTO mydistri_power (kta,ktadir,pose,level,upline,poseupline,namadir) VALUES ('" & kedua&"','"&sinten&"','"&posef&"',"&levke&",'"&uplinemu&"','"&poseupmu&"','"&jenengmu&"')"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
                            End If
                        End If
                        rs.close
                        aaxds = aaxds + 1
                        If aaxds > 200000 Then
                            Exit For
                        End If
                    Next
                    rs.close
                    mutere = piro * 2


                    piro = 0
                    kedua = al2
                    mutere = 0
                    levke = 0
                    For aaxds = 1 To 200000
                        rs.Open "SELECT * FROM mylevel WHERE kta LIKE '" & kedua&"'", conn
        If rs.bof Then
                            aaxd = 200020
                            Exit For
                        Else
                            If rs("ktaloc") = "A" Then
                                aax = 200020
                                ent = "F"
                                Exit For
                            Else
                                ent = "F"
                                piro = piro + 1
                                levke = levke + 1
                                kedua = rs("ktaloc")
                                'posloc = rs("posloc")
                                'spld = rs("ktaloc")
                                posef = rs("posloc")

                                Call OpenDBG()
                                strSQLG = "INSERT INTO mydistri_power (kta,ktadir,pose,level,upline,poseupline,namadir) VALUES ('" & kedua&"','"&sinten&"','"&posef&"',"&levke&",'"&uplinemu&"','"&poseupmu&"','"&jenengmu&"')"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
                            End If
                        End If
                        rs.close
                        aaxds = aaxds + 1
                        If aaxds > 200000 Then
                            Exit For
                        End If
                    Next
                    rs.close
                    mutere = piro * 2

                End If

                keo = "S"
                oek = "T"
                Call OpenDBG()
                strSQLG = "UPDATE temp_belum SET hendel = '"&oek&"',sta = '"&keo&"' WHERE bulan = "&wulan&" and tahun = "&nahun&" and nopos like '"&mypos&"' and noinvo like '"&noinvo&"'"
Set rsG =  dBConnG.Execute(strSQLG)
Call CloseDBG()

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
            rsALL.Open "SELECT * FROM bonpas where kta like '" & noser&"' order by id desc limit 1", connALL
        If rsALL.bof Then
                totdirkiri = 0
                totdirkanan = 0
            Else
                totdirkiri = rsALL("totkiri")
                totdirkanan = rsALL("totkanan")
            End If
            rsALL.Close
            rsALL.Open "SELECT direk,alok FROM member WHERE kta like '" & noser&"'", connALL
        If rsALL.bof Then
                direknya = "-"
                alocnya = "-"
            Else
                direknya = rsALL("direk")
                alocnya = rsALL("alok")
            End If
            rsALL.close

            rsALL.Open "SELECT * FROM bns_expired_member where kta like '" & noser&"'", connALL, 3, 3
        If rsALL.bof Then
                rsALL.addnew
                rsALL("kta") = noser
                rsALL("last_tupo_bulan") = bulan
                rsALL("last_tupo_tahun") = tahun
                rsALL("re_entry") = "T"
                rsALL("tglexpired") = tglexpiredac
                rsALL("direk") = direknya
                rsALL("alok") = alocnya
                rsALL("kiri") = totdirkiri
                rsALL("kanan") = totdirkanan
                'rsALL("tuponya") = tupoku	
                'rsALL("baru") = "T"
                rsALL.update
            Else
                rsALL.update
                rsALL("last_tupo_bulan") = bulan
                rsALL("last_tupo_tahun") = tahun
                rsALL("re_entry") = "T"
                rsALL("tglexpired") = tglexpiredac
                'rsALL("tuponya") = tupoku	
                'rsALL("baru") = "T"
                rsALL.update
            End If
            rsALL.Close



            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
            intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia		
            Session("noinvo_ft") = noinvo
            Response.Redirect "sale_reentry_inv.asp?menu_id=" & noser
'response.redirect "akt_form.asp?menu_id="&menu_id
        Else
            '%>
            '<table border = "0" cellpadding="0" cellspacing="0" width="100%">
            '	<tr>
            '		<td>
            '		<p align = "center" >
            '        <img border="0" src="../images/health-wealthlogo.jpg" width="186" height="125"></td>
            '            	</tr>
            '	<tr>
            '		<td>&nbsp;</td>
            '	</tr>
            '	<tr>
            '		<td>
            '		<p align = "center" <> font face="Verdana">
            '		Ada kesalahan dalam proses pendaftaran, silahkan perbaiki kesalahan seperti yang tertulis dibawah ini.
            '		<%if error1 <> "" then %>
            '		<br><%= erro1% >
            '        <%end if%>
            '            <%if error2 <> "" then %>
            '		<br><%= error2% >
            '        <%end if%>
            '            <%if error3 <> "" then %>
            '		<br><%= error3% >
            '        <%end if%>
            '            <%if error4 <> "" then %>
            '		<br><%= error4% >
            '        <%end if%><br>				
            '		&lt;-- <a href="sale_reentry.asp?menu_id=<%=session(" menu_id")%>">Kembali</a> 
            '		--&gt;</font></td>
            '    </tr>
            '                </table>
            '                <%
        End If
        'end if
        '%>
    End Sub

End Class

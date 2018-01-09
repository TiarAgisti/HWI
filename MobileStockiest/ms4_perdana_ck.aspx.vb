Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_ms4_perdana_ck
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable

    Dim kemana, kdposna, namamu, alamat, kota, propinsi, kodepos, notelp, nofax, nohape, emel, diskon, zona, tunai, debit, kkredit, bgcek, duite, kembalinye As String
    Dim mypos, loguser, kelasdc, indukdc, kti, piyesetuju, pos_area, nosesifaxmc_pdn, nodc, asale, bulanfee, tahunfee, dc_asal, kdpos, namadis, dcpusat As String
    Dim dino, tglku, tglbayar, bulan As Date
    Dim pvnow, nilaibv, tglini, bulanini, bulanikis, tauniki, levnya, pvreg As Integer
    Dim produpkurang, pvnow2, pvnow3, prodada, nahun_promo, wulan_promo, wulan_pajak, nahun_pajak, perik_promo, nilaipv, produp As Integer
    Dim awal, sisastok, nilaipv1, nilaipv2, nilaipv3, tambahan, postingup As Double
    Dim nosesi, namadist, lanjutke, nopos As String
    Dim menu_id, redir, jumtot, PV, pvnya, poinms, ulan, ahun, tanggalnateh, taundari As Integer
    Dim wulan, wulpos, nahun, nuhun, sponsor, kedua, paket As String
    Dim piro, mutere, levke, pred, tatanggalan, wulandari, nilairp, jumdir_ft, bonrefreg, jumdir_reg As Integer
    Dim bonft1, bonft2, bonft3, bonft4, bonft5, bonft6, bonft7, bonft8, bonft9, bonft10, bonft11, bonft12, bonft88, bonft13, bonft14, bonft15 As String
    Dim bonft16, bonft17, bonft18, bonft19, bonft20, bonftnpr, bonft99, bonft100, bonft101, bonft102, bonft103, bonft104, bonft105, bonft106, bonft107 As String
    Dim l3a, l1, l5, noid, ket, modepost, bonft108, bonft109, bonft110, bonms500u, direk As String

    Dim tahskr, belek, tauk, belekan, tauge As Integer
    Dim kel, masterdc, k1, k2, nopajak, nopakhir, nourutpjk, nokode As String
    Dim sgg, bv, nama, hd1, hk1, hd2, hk2, hd3, hk3, kop, jumbc, grp, kus1, kus2, kus3, kusrd1, kusrd2, kusrd3, kussd1, kussd2, kussd3, kusmc1, kusmc2, kusmc3 As String
    Dim promo1, promo2, promo3, kgrp, hk4, hd4, kus4, kusrd4, kussd4, kusmc4, promo4, hk5, hd5, kus5, kusrd5, kussd5, kusmc5, promo5 As String
    Dim sisakembalian, jume, jumakhir, dk, sbt, jumdisk, totpv, pot, gtot As Double
    Dim nodce, tamb, blne, taun, nipe, noinvo, noinvomc As String
    Dim bulanskr, tahunskr, noakhir, bulsks, jk, nourmc, stses As Integer
    Dim lanjutgo, l2, nodcs, boleh, area, dcHO, namatabel, namatabel2, ggg, l3, l4, l6, l7, l8, l9, l10, l11, l12, eml As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")
        mypos = UCase(Session("motok"))
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        kti = Session("kti")
        piyesetuju = UCase(Request("setuju"))
        If Session("motok") = "" Or Session("kowe") = "" Or Session("kti") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        Dim strHTML As String = ""
        If piyesetuju <> "AGREE" Then
            strHTML = "<p align='center'>" & vbCrLf
            strHTML += "<img border='0' src='../images/logohwi.jpg' width='155' height='100'>" & vbCrLf
            strHTML += "</p>" & vbCrLf
            strHTML += "<p align='center'>" & vbCrLf
            strHTML += "<font size='4' face='Verdana'>" & vbCrLf
            strHTML += "Anda belum meng-click perjanjian dan persetujuan kode etik sebagai<br>" & vbCrLf
            strHTML += "mobile stockiest PT. Health Wealth International<br>" & vbCrLf
            strHTML += "</font>" & vbCrLf
            strHTML += "<font face='Verdana' size='2'>" & vbCrLf
            strHTML += "<a href='javascript:history.back( )'>" & vbCrLf
            strHTML += "<-- KEMBALI -->" & vbCrLf
            strHTML += "</a></font></p>" & vbCrLf
        End If

        contentWeb.InnerHtml = strHTML


        dcpusat = ""
        pos_area = Session("pos_area")
        nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
        nodc = UCase(Session("motok"))
        Session("dcpusate") = dcpusat
        asale = Request("asal")
        dino = Now()
        bulanfee = Month(dino)
        tahunfee = Year(dino)

        dc_asal = Request("dc_asal")
        kdpos = Request("kdpos")
        namadis = Request("namadis")

        If asale = "" Then
            asale = "perdana"
        Else
            asale = asale
        End If


        If asale = "normal" Then
            redir = 1
            kemana = "ms_order_produk.aspx?menu_id=" & menu_id
        Else
            redir = 2
            kemana = "ms4_perdana.aspx?menu_id=" & menu_id
        End If


        If asale <> "normal" Then
            kdposna = Request("kdpos")
            namamu = Request("nama_user")
            alamat = Request("alamatdis")
            kota = Request("kotadis")
            propinsi = Request("propinsidis")
            kodepos = Request("kodeposdis")
            notelp = Request("telpdis")
            nofax = Request("faxdis")
            nohape = Request("hapedis")
            emel = Request("emaildis")
            diskon = Request("diskondis")
            zona = Request("zona")
        End If


        jumtot = Int(Request("jumtote"))
        tunai = Trim(Request("jumbayarcash"))
        debit = Trim(Request("jumbayardb"))
        kkredit = Trim(Request("jumbayarcc"))
        bgcek = Trim(Request("jumbayarcek"))
        duite = Int(Request("jumbayar"))
        kembalinye = Trim(Request("kembalian"))

        If duite = 0 Then
            Session("errorfax") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect(kemana)
        End If

        If kembalinye < 0 Then
            Session("errorfax") = "Jumlah pembayaran anda tidak mencukupi"
            Response.Redirect(kemana)
        End If

        If asale <> "normal" Then
            If namamu = "" Then
                l3a = "Mbuh"
                Session("errorfax") = "Anda belum mengisikan user name mobile center"
                Response.Redirect(kemana)
            Else
                If Len(namamu) >= 16 Then
                    Session("errorfax") = "User name mobile center 15 karakter"
                    l3a = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(namamu) <= 16) And (namamu <> "")) Then
                        l3a = "Ter3a"
                        Session("errorfax") = ""
                    End If
                End If
            End If
        End If

        If jumtot <= 1 Then
            l1 = "Mbuh"
            Session("errorfax") = "Anda belum menentukan Zona Pengiriman"
            Response.Redirect(kemana)
        End If

        If jumtot = "" Then
            l1 = "Mbuh"
            Session("errorfax") = "Anda belum berbelanja"
            Response.Redirect(kemana)
        Else
            If IsNumeric(jumtot) = False Then
                l1 = "Mbuh"
                Session("errorfax") = "Anda belum berbelanja"
                Response.Redirect(kemana)
            Else
                If ((jumtot <> "") And (IsNumeric(jumtot) = True)) Then
                    If jumtot < 0 Then
                        l1 = "Mbuh"
                        Session("errorfax") = "Anda belum berbelanja"
                        Response.Redirect(kemana)
                    Else
                        jumtot = jumtot
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
                If ((tunai <> "") And (IsNumeric(tunai) = True)) Then
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
                If ((debit <> "") And (IsNumeric(debit) = True)) Then
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
                If ((kkredit <> "") And (IsNumeric(kkredit) = True)) Then
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
                If ((bgcek <> "") And (IsNumeric(bgcek) = True)) Then
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

        If tunai + debit + kkredit + bgcek <= 0 Then
            l5 = "Mbuh"
            Session("errorfax") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect(kemana)
        End If

        If duite = "" Then
            l5 = "Mbuh"
            Session("errorfax") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect(kemana)
        Else
            If IsNumeric(duite) = False Then
                l5 = "Mbuh"
                Session("errorfax") = "Anda belum mengisikan jumlah pembayaran"
                Response.Redirect(kemana)
            Else
                If ((duite <> "") And (IsNumeric(duite) = True)) Then
                    If duite > 0 Then
                        sisakembalian = duite - jumtot
                        If sisakembalian = 0 Or sisakembalian > 0 Then
                            l5 = "Ter5"
                            Session("errorpos") = ""
                        Else
                            l5 = "Mbuh"
                            Session("errorfax") = "Jumlah Pembayaran Anda tidak Mencukupi"
                            Response.Redirect(kemana)
                        End If
                    Else
                        l5 = "Mbuh"
                        Session("errorfax") = "Anda belum mengisikan jumlah pembayaran"
                        Response.Redirect(kemana)
                    End If
                End If
            End If
        End If

        If dc_asal = "" Then
            l1 = "Mbuh"
            Session("errorfax") = "Anda belum mengisikan nomor id. DC Asal"
            Response.Redirect(kemana)
        Else
            If Len(dc_asal) >= 16 Then
                Session("errorfax") = "Nomor id. DC asal maksimal 15 karakter"
                l1 = "Mbuh"
                Response.Redirect(kemana)
            Else
                If ((Len(dc_asal) <= 16) And (dc_asal <> "")) Then
                    mlSQL = "SELECT nopos,sta FROM tabdesc_stockist WHERE ucase(nopos) LIKE '" & dc_asal & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()

                    If Not mlREADER.HasRows Then
                        Session("errorfax") = "Nomor id. DC asal tidak ditemukan"
                        l1 = "Mbuh"
                        Response.Redirect(kemana)
                    Else
                        If mlREADER("sta") = "T" Then
                            l1 = "Ter1"
                            Session("errorfax") = ""
                        Else
                            Session("errorfax") = "DC asal dalam status disable !"
                            l1 = "Mbuh"
                            Response.Redirect(kemana)
                        End If
                    End If
                    mlREADER.Close()
                End If
            End If
        End If

        '''''''' lihat sudah beli ms400
        mlSQL = "SELECT * FROM healthwealthint_com_hwi.st_sale_daftar  WHERE noseri LIKE '" & kdpos & "' and paket like 'MS%' and pakai like 'T'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            lanjutgo = "T"
        Else
            lanjutgo = "F"
        End If
        mlREADER.Close()

        If lanjutgo = "T" Then
        Else
            Session("errorfax") = "Nomor id. Sudah membeli paket MS400."
            l2 = "Mbuh"
            Response.Redirect(kemana)
        End If

        mlSQL = "SELECT * FROM healthwealthint_com_hwi.fx_order_mc_det where kode like 'MS%' and nomc like 'MS-" & kdpos & "' and kat like 'PDN' and (status = 9 or status = 7)"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjutgo = "T"
        Else
            lanjutgo = "F"
        End If
        mlREADER.Close()

        If lanjutgo = "T" Then
        Else
            Session("errorfax") = "Nomor id. Sudah membeli paket MS400."
            l2 = "Mbuh"
            Response.Redirect(kemana)
        End If

        mlSQL = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "' and kode like 'MS%'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjutgo = "F"
        Else
            lanjutgo = "T"
        End If
        mlREADER.Close()

        If lanjutgo = "T" Then
        Else
            Session("errorfax") = "Anda belum memilih paket MS."
            l2 = "Mbuh"
            Response.Redirect(kemana)
        End If

        If kdpos = "" Then
            l2 = "Mbuh"
            Session("errorfax") = "Anda belum mengisikan nomor id. Distributor yang menjadi mobile center"
            Response.Redirect(kemana)
        Else
            If Len(kdpos) >= 16 Then
                Session("errorfax") = "Nomor id. Distributor maksimal 15 karakter"
                l2 = "Mbuh"
                Response.Redirect(kemana)
            Else
                If ((Len(kdpos) <= 16) And (kdpos <> "")) Then
                    mlSQL = "SELECT kta,sta FROM member WHERE kta LIKE '" & kdpos & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorfax") = "Nomor id. Distributor tidak ditemukan."
                        l2 = "Mbuh"
                        Response.Redirect(kemana)
                    Else
                        If mlREADER("sta") = "T" Then
                            l2 = "Ter2"
                            Session("errorfax") = ""
                        Else
                            Session("errorfax") = "Nomor id. Distributor dalam status disable"
                            l2 = "Mbuh"
                            Response.Redirect(kemana)
                        End If
                    End If
                    mlREADER.Close()

                    If asale = "perdana" Then
                        mlSQL = "SELECT kta,sta FROM member WHERE kta LIKE '" & kdpos & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            Session("errorfax") = "Nomor id. Distributor tidak ditemukan."
                            l2 = "Mbuh"
                            Response.Redirect(kemana)
                        Else
                            If mlREADER("sta") = "T" Then
                                l2 = "Ter2"
                                Session("errorfax") = ""
                            Else
                                Session("errorfax") = "Nomor id. Distributor dalam status disable"
                                l2 = "Mbuh"
                                Response.Redirect(kemana)
                            End If
                        End If
                        mlREADER.Close()
                    End If

                    If asale <> "perdana" Then
                        mlSQL = "SELECT kta,nopos,sta FROM tabdesc_stockist WHERE kta LIKE '" & kdpos & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            l2 = "Mbuh"
                            Session("errorfax") = "Mobile Center Id tidak ditemukan"
                            Response.Redirect(kemana)
                        Else
                            If mlREADER("sta") = "T" Then
                                Session("errorfax") = ""
                                l2 = "Ter2"
                            Else
                                Session("errorfax") = "Mobile Center dalam status disable"
                                l2 = "Mbuh"
                                Response.Redirect(kemana)
                            End If
                        End If
                        mlREADER.Close()
                    End If
                End If
            End If
        End If

        If namadis = "" Then
            l3 = "Mbuh"
            Session("errorfax") = "Anda belum mengisikan nama distributor yang menjadi mobile center"
            Response.Redirect(kemana)
        Else
            If Len(namadis) >= 81 Then
                Session("errorfax") = "Nama distributor yang menjadi mobile center maksimal 80 karakter"
                l3 = "Mbuh"
                Response.Redirect(kemana)
            Else
                If ((Len(namadis) <= 81) And (namadis <> "")) Then
                    l3 = "Ter3"
                    Session("errorfax") = ""
                End If
            End If
        End If

        If asale <> "normal" Then
            If ((alamat = "") And (alamat <> "-")) Then
                l4 = "Mbuh"
                Session("errorfax") = "Silahkan isikan alamat kontak anda"
                Response.Redirect(kemana)
            Else
                If Len(alamat) >= 221 Then
                    Session("errorfax") = "Alamat kontak maksimal 220 karakter"
                    l4 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(alamat) <= 221) And (alamat <> "")) Then
                        l4 = "Ter4"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If kota = "" Then
                l5 = "Mbuh"
                Session("errorfax") = "Kota alamat belum anda isi"
                Response.Redirect(kemana)
            Else
                If Len(kota) >= 51 Then
                    Session("errorfax") = "Kota alamat maksimal 50 karakter"
                    l5 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(kota) <= 51) And (kota <> "")) Then
                        l5 = "Ter5"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If kodepos = "" Then
                l6 = "Mbuh"
                Session("errorfax") = "Silahkan isikan kodepos anda"
                Response.Redirect(kemana)
            Else
                If Len(kodepos) >= 11 Then
                    Session("errorfax") = "Kodepos maksimal 10 karakter"
                    l6 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(kodepos) <= 11) And (kodepos <> "")) Then
                        l6 = "Ter6"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If propinsi = "" Then
                l7 = "Mbuh"
                Session("errorfax") = "Silahkan pilih propinsi anda"
                Response.Redirect(kemana)
            Else
                If Len(propinsi) >= 81 Then
                    Session("errorfax") = "Propinsi maksimal 80 karakter"
                    l7 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(propinsi) <= 81) And (propinsi <> "")) Then
                        l7 = "Ter7"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If notelp = "" Then
                l8 = "Mbuh"
                Session("errorfax") = "Silahkan isikan nomor telepon"
                Response.Redirect(kemana)
            Else
                If Len(notelp) >= 51 Then
                    Session("errorfax") = "Nomor telepon maksimal 50 karakter"
                    l8 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(notelp) <= 51) And (notelp <> "")) Then
                        l8 = "Ter8"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If nofax = "" Then
                l9 = "Ter9"
                Session("errorfax") = ""
                nofax = "-"
            Else
                If Len(nofax) >= 51 Then
                    Session("errorfax") = "Nomor fax maksimal 50 karakter"
                    l9 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(nofax) <= 51) And (nofax <> "")) Then
                        l9 = "Ter9"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If nohape = "" Then
                l10 = "Ter10"
                Session("errorfax") = ""
            Else
                If Len(nohape) >= 26 Then
                    Session("errorfax") = "Nomor handphone maksimal 25 karakter"
                    l10 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(nohape) <= 26) And (nohape <> "")) Then
                        l10 = "Ter10"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If emel = "" Then
                l11 = "Ter11"
                Session("errorfax") = ""
                eml = "-"
            Else
                If Len(emel) >= 151 Then
                    Session("errorfax") = "Alamat email maksimal 150 karakter"
                    l11 = "Mbuh"
                    Response.Redirect(kemana)
                    eml = emel
                Else
                    If ((Len(emel) <= 151) And (emel <> "")) Then
                        l11 = "Ter11"
                        Session("errorfax") = ""
                        eml = emel
                    End If
                End If
            End If

            If zona = "" Then
                l12 = "Mbuh"
                Session("errorfax") = "Silahkan pilih zona Mobile Center"
                Response.Redirect(kemana)
            Else
                If Len(zona) >= 151 Then
                    Session("errorfax") = "Zona Mobile Center maksimal 150 karakter"
                    l12 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(zona) <= 151) And (zona <> "")) Then
                        ggg = "zno"
                        mlSQL = "SELECT * FROM tabdesc WHERE deskripsi LIKE '" & zona & "' and grp like '" & ggg & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            l12 = "Ter12"
                            Session("errorfax") = ""
                            area = 1
                        Else
                            l12 = "Ter12"
                            Session("errorfax") = ""
                            area = mlREADER("ket")
                        End If
                        mlREADER.Close()
                    End If
                End If
            End If
        End If

        dcHO = ""
        If mypos = dcHO Then
            namatabel = "st_kartustock"
            namatabel2 = "st_barang"
            stses = 7
        Else
            namatabel = "st_kartustock_ms"
            namatabel2 = "st_barang_ms"
            stses = 9
        End If

        If nodc = "" Or nosesifaxmc_pdn = "" Then
            Response.Redirect(kemana)
        End If

        nodcs = "MS-" + CStr(kdpos)
        If asale <> "normal" Then
            mlSQL = "SELECT id,indukmc FROM tabdesc_stockist where ucase(nopos) like '" & nodcs & "' and nama like 'PT. HEALTH WEALTH INTERNATIONAL MS'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                boleh = "T"
            Else
                '''' boleh beli ms 400 bagi yang belum beli..
                boleh = "T"
            End If
            mlREADER.Close()

            mlSQL = "SELECT TOP 1 nourut FROM tabdesc_stockist order by nourut desc"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                nourmc = 1
            Else
                nourmc = mlREADER("nourut") + 1
            End If
            mlREADER.Close()

            area = ""
            mlSQL = "SELECT * FROM tabdesc_stockist WHERE ucase(nopos) LIKE '" & nodcs & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then

                mlSQL2 = "Insert into tabdesc_stockist(nopos,kta,kelas,nourut,cperson,alamat,kota,kodepos,propinsi,namadc,negara,telp,fax,emel,website,joindt,sta,level,area,lastlog" & vbCrLf
                mlSQL2 += ",lastip,logindt,loginip,logke,diskon,bonus,induk,indukmc,nama)Values('" & nodcs & "','" & kdpos & "','N','" & nourmc & "','" & UCase(namadis) & "','" & alamat & "'" & vbCrLf
                mlSQL2 += ",'" & kota & "','" & kodepos & "','" & propinsi & "','" & UCase(namadis) & "','Indonesia','" & notelp & "','" & nofax & "','" & emel & "','-','" & dino & "'" & vbCrLf
                mlSQL2 += ",'T',1,'" & area & "','" & Now & "','" & Request.ServerVariables("remote_addr") & "','" & Now & "','" & Request.ServerVariables("remote_addr") & "',1,4,0" & vbCrLf
                mlSQL2 += ",'" & indukdc & "','" & mypos & "','PT. HEALTH WEALTH INTERNATIONAL MS')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia	
                mlSQL2 = "UPDATE tabdesc_stockist SET nama='PT. HEALTH WEALTH INTERNATIONAL MS' WHERE nopos like '" & nodcs & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
            End If
            mlREADER.Close()

            Dim kenalan, namaasli As String
            namaasli = ""
            mlSQL = "SELECT kta,thekey,uid FROM member WHERE kta LIKE '" & kdpos & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                kenalan = "1234567890123456"
            Else
                kenalan = mlREADER("thekey")
                namaasli = UCase(mlREADER("uid"))
            End If
            mlREADER.Close()

            mlSQL = "SELECT * FROM tabdesc_stockist_user WHERE ucase(nopos) LIKE '" & nodcs & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "Insert into tabdesc_stockist_user(nopos,kta,gembok,lastlog,lastip,logindt,loginip,logke,nama,kat,foto)Values('" & nodcs & "'" & vbCrLf
                mlSQL2 += ",'" & UCase(namamu) & "','" & kenalan & "','" & Now & "','" & Request.ServerVariables("remote_addr") & "','" & Now & "'" & vbCrLf
                mlSQL2 += ",'" & Request.ServerVariables("remote_addr") & "',0,'" & namaasli & "','mc','images/dc/blank.gif')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()
        End If

        bulanskr = CInt(Month(dino))
        tahunskr = CInt(Year(dino))
        mlSQL = "SELECT TOP 1 id,urut,tgl FROM fax_order_mc_head where nopos like '" & mypos & "' AND month(tgl)='" & bulanskr & "' AND year(tgl) = '" & tahunskr & "' order by urut DESC"
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

        noinvo = mypos + "/" + tamb + nipe + "/PMC-" + blne + "/" + taun
        noinvomc = noinvo

        ''''''''''''''''''''''''''''''
        ' bikin nomor invoice pajak
        ''''''''''''''''''''''''''''''

        tahskr = CInt(Year(dino))
        kel = "RET"
        If UCase(mypos) = "B-000" Then
            'rs.Open "SELECT urut FROM nourut where dcinduk like '"&indukdc&"' and year(tgl)='"&tahskr&"' order by urut desc limit 1",conn	
            masterdc = "B-000"
            k1 = "ODC"
            k2 = "RET"
            belek = CInt(Month(dino))
            tauk = CInt(Year(dino))
            belekan = 9
            tauge = 2011
            If belek >= 9 And tauk = 2011 Then
                mlSQL = "SELECT TOP 1 urut FROM nourut where ((dcinduk like '" & masterdc & "' and kel like '" & k1 & "')" & vbCrLf
                mlSQL += "Or (nopos Like '" & masterdc & "' AND kel like '" & k2 & "')) and month(tgl)>='" & belekan & "' and year(tgl)='" & tauge & "' order by nopajak desc"
            Else
                mlSQL = "SELECT TOP 1 urut FROM nourut where ((dcinduk like '" & masterdc & "' and kel like '" & k1 & "')" & vbCrLf
                mlSQL += "Or (nopos Like '" & masterdc & "' AND kel like '" & k2 & "')) and year(tgl)='" & tahskr & "' and (nopajak like '002%' or nopajak like '001%') order by nopajak desc"
            End If
        Else
            mlSQL = "SELECT TOP 1 urut FROM nourut where dcinduk like '" & indukdc & "' AND nopos like '" & mypos & "'" & vbCrLf
            mlSQL += "And year(tgl)='" & tahskr & "' and kel like '" & kel & "' order by nopajak desc"
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

        nopakhir = ""
        mlSQL = "SELECT TOP 1 * FROM nourut where (nopajak like '002%' or nopajak like '001%') order by nopajak desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
        Else
            nopakhir = mlREADER("nopajak")
        End If
        mlREADER.Close()


        If mypos = "B-000" Then
            If nopakhir = "001-14.18737127" Then
                nourutpjk = "002.14.52557683"
                nopajak = 52557683
            ElseIf nopakhir > "002.14.52557682" Then
                nourutpjk = "002.14." + CStr(nopajak)
            Else
                nourutpjk = "001-14." + CStr(nopajak)
            End If
            'End If
        Else
            nourutpjk = tamb + CStr(nopajak)
        End If

        mlSQL = "Insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)Values('" & nopajak & "','" & mypos & "','" & noinvo & "'" & vbCrLf
        mlSQL += ",'" & dino & "','PMC','RET','" & indukdc & "','" & nourutpjk & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "SELECT * FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
        If mlREADER.HasRows Then
            dk = mlREADER("diskon")
            sbt = mlREADER("subtot")
            jumdisk = mlREADER("diskonamt")
            totpv = mlREADER("totpv")
            'pot = (totbv*dk)/100
            pot = 0
            'gtot = sbt - pot
            gtot = sbt - pot - jumdisk
            'noinvo = rs("noinvo")
            nodce = mlREADER("nopos")

            If totpv > 0 Then
                dk = dk
            Else
                dk = 0
            End If

            mlSQL2 = "Update fax_order_mc_head set urut = '" & noakhir & "',diskon = '" & dk & "',status = '" & stses & "',gtot = '" & gtot & "'" & vbCrLf
            mlSQL2 += ",potongan = '" & pot & "',tgl = '" & dino & "',noinvo = '" & noinvo & "',nopajak = '" & nourutpjk & "',nomc = '" & nodcs & "'" & vbCrLf
            mlSQL2 += ",tunai = '" & tunai & "',debit = '" & debit & "',cc = '" & kkredit & "',cek = '" & bgcek & "',jumbayar = '" & duite & "'" & vbCrLf
            mlSQL2 += ",kembalian = '" & duite - gtot & "',kta = '" & loguser & "',suratjalan = '-',totbruto = '" & sbt & "'" & vbCrLf
            mlSQL2 += "where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()

        mlSQL = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlDATATABLE = New DataTable()
            mlDATATABLE.Load(mlREADER)
            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                mlSQL2 = "Update fx_order_mc_det set status = '" & stses & "',tglorder = '" & stses & "',noinvo = '" & noinvo & "',nopajak = '" & nourutpjk & "'" & vbCrLf
                mlSQL2 += ",nomc = '" & nodcs & "' where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                nokode = mlDATATABLE.Rows(aaaeqSSS)("kode")
                jume = mlDATATABLE.Rows(aaaeqSSS)("jumlah")
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' update jumlah stock aktual kantor pusat barang / DC INDUK ''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If mypos = dcHO Then
                    mlSQL2 = "SELECT * FROM " & namatabel2 & " where kode like '" & nokode & "'"
                Else
                    mlSQL2 = "SELECT * FROM " & namatabel2 & " where kode like '" & nokode & "' and nopos like '" & mypos & "'"
                End If
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()

                If Not mlREADER2.HasRows Then
                    jumakhir = 0
                Else
                    jumakhir = mlREADER2("jumlah")
                    mlSQL3 = "Update " & namatabel2 & " set jumlah = '" & mlREADER2("jumlah") - jume & "'" & vbCrLf
                    If mypos = dcHO Then
                        mlSQL3 += "where kode like '" & nokode & "'"
                    Else
                        mlSQL3 += "where kode like '" & nokode & "' and nopos like '" & mypos & "'"
                    End If
                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                    sgg = mlREADER2("sta")
                    PV = mlREADER2("pv")
                    bv = mlREADER2("bv")
                    nama = mlREADER2("nama")
                    hd1 = mlREADER2("hd1")
                    hk1 = mlREADER2("hk1")
                    hd2 = mlREADER2("hd2")
                    hk2 = mlREADER2("hk2")
                    hd3 = mlREADER2("hd3")
                    hk3 = mlREADER2("hk3")
                    kop = mlREADER2("kop")
                    jumbc = mlREADER2("jumbc")
                    grp = mlREADER2("grp")
                    kus1 = mlREADER2("khusus1")
                    kus2 = mlREADER2("khusus2")
                    kus3 = mlREADER2("khusus3")
                    kusrd1 = mlREADER2("khususrd1")
                    kusrd2 = mlREADER2("khususrd2")
                    kusrd3 = mlREADER2("khususrd3")
                    kussd1 = mlREADER2("khusussd1")
                    kussd2 = mlREADER2("khusussd2")
                    kussd3 = mlREADER2("khusussd3")
                    kusmc1 = mlREADER2("khususmc1")
                    kusmc2 = mlREADER2("khususmc2")
                    kusmc3 = mlREADER2("khususmc3")
                    promo1 = mlREADER2("promo1")
                    promo2 = mlREADER2("promo2")
                    promo3 = mlREADER2("promo3")
                    kgrp = mlREADER2("kgrp")
                    hk4 = mlREADER2("hk4")
                    hd4 = mlREADER2("hd4")
                    kus4 = mlREADER2("khusus4")
                    kusrd4 = mlREADER2("khususrd4")
                    kussd4 = mlREADER2("khusussd4")
                    kusmc4 = mlREADER2("khususmc4")
                    promo4 = mlREADER2("promo4")
                    hk5 = mlREADER2("hk5")
                    hd5 = mlREADER2("hd5")
                    kus5 = mlREADER2("khusus5")
                    kusrd5 = mlREADER2("khususrd5")
                    kussd5 = mlREADER2("khusussd5")
                    kusmc5 = mlREADER2("khususmc5")
                    promo5 = mlREADER2("promo5")
                End If
                mlREADER2.Close()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' update kartu stock untuk booked kantor pusat / dc induk mc
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If mypos = dcHO Then
                    mlSQL2 = "SELECT TOP 3 * FROM " & namatabel & " where kode like '" & nokode & "' order by tgl desc, id desc"
                Else
                    mlSQL2 = "SELECT TOP 3 * FROM " & namatabel & " where kode like '" & nokode & "' and nopos like '" & mypos & "' order by tgl desc, id desc"
                End If
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    Dim ket As String
                    If asale = "perdana" Then
                        ket = "Penjualan Perdana MC : " & nodcs
                    Else
                        ket = "Penjualan Produk MS : " & nodcs
                    End If
                    mlSQL3 = "Insert into  " & namatabel & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)Values('" & nokode & "','" & mypos & "'" & vbCrLf
                    mlSQL3 += ",'" & dino & "','" & jumakhir & "',0,'" & jume & "','" & jumakhir - jume & "','" & noinvo & "', '" & ket & "')"
                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                Else
                    If asale = "perdana" Then
                        ket = "Penjualan Perdana MC : " & nodcs
                    Else
                        ket = "Penjualan Produk MS : " & nodcs
                    End If
                    awal = mlREADER2("akhir")
                    sisastok = awal - jume

                    mlSQL3 = "Insert into  " & namatabel & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)Values('" & nokode & "','" & mypos & "'" & vbCrLf
                    mlSQL3 += ",'" & dino & "','" & awal & "',0,'" & jume & "','" & sisastok & "','" & noinvo & "','" & ket & "')"
                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER2.Close()
            Next
        End If
        mlREADER.Close()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''FASTRACK 7 Generasi
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        tglku = Now()
        tglini = Day(tglku)
        bulanini = Month(tglku)
        bulanikis = Month(tglku)
        tauniki = Year(tglku)
        'end

        mlSQL = "SELECT * FROM kapan where (((day(awal) = '" & tglini & "') and (month(awal) = '" & bulanini & "')" & vbCrLf
        mlSQL += "And (year(awal) = '" & tauniki & "')) or ((day(t2) = '" & tglini & "') and (month(t2) = '" & bulanini & "')" & vbCrLf
        mlSQL += "And (year(t2) = '" & tauniki & "')) or ((day(t3) = '" & tglini & "') and (month(t3) = '" & bulanini & "')" & vbCrLf
        mlSQL += "And (year(t3) = '" & tauniki & "')) or ((day(t4) = '" & tglini & "') and (month(t4) = '" & bulanini & "')" & vbCrLf
        mlSQL += "And (year(t4) = '" & tauniki & "')) or ((day(t5) = '" & tglini & "') and (month(t5) = '" & bulanini & "')" & vbCrLf
        mlSQL += "And (year(t5) = '" & tauniki & "')) or ((day(t6) = '" & tglini & "') and (month(t6) = '" & bulanini & "')" & vbCrLf
        mlSQL += "And (year(t6) = '" & tauniki & "')) or ((day(akhir) = '" & tglini & "') and (month(akhir) = '" & bulanini & "') and (year(akhir) = '" & tauniki & "')))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            tglbayar = Now.AddDays(4)
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

        mlSQL = "SELECT kta,direk FROM member where kta LIKE '" & kdposna & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            direk = "-"
        Else
            direk = mlREADER("direk")
        End If
        mlREADER.Close()

        mlSQL = "SELECT * FROM bns_kurs"
        If Not mlREADER.HasRows Then
            bonft1 = 0
            bonft2 = 0
            bonft3 = 0
            bonft4 = 0
            bonft5 = 0
            bonft6 = 0
            bonft7 = 0
            bonft8 = 0
            bonft9 = 0
            bonft10 = 0
            bonft11 = 0
            bonft12 = 0
            bonft88 = 0
            bonft13 = 0
            bonft14 = 0
            bonft15 = 0
            bonft16 = 0
            bonft17 = 0
            bonft18 = 0
            bonft19 = 0
            bonft20 = 0
            bonftnpr = 0
            bonft99 = 0
            bonft100 = 0
            bonft101 = 0
            bonft102 = 0
            bonft103 = 0
            bonft104 = 0
            bonft105 = 0
            bonft106 = 0
            bonft107 = 0
            bonft108 = 0
            bonft109 = 0
            bonft110 = 0
            bonms500u = 0
        Else
            bonms500u = mlREADER("fsbms500u")
        End If
        mlREADER.Close()

        jumdir_ft = 1
        bonrefreg = 0
        jumdir_reg = 0

        mlSQL = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "' and kode like 'MS%'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            paket = "MS"
        Else
            paket = mlREADER("kode")
        End If
        mlREADER.Close()

        If paket = "MS200MU-14" Or paket = "MS200KU-14" Then
            jumdir_ft = 0
            bonrefreg = bonms500u
            jumdir_reg = 1
            bonms500u = 0
        End If

        mlSQL = "SELECT * FROM minggu_fsb where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "Insert into minggu_fsb(minggu,tahun,bulan_pajak,tahun_pajak,kta,amt,jumdir,amt_reg,jumdir_reg)Values('" & perik_promo & "','" & nahun_promo & "'" & vbCrLf
            mlSQL2 += ",'" & wulan_pajak & "','" & nahun_pajak & "','" & direk & "','" & bonms500u & "','" & jumdir_ft & "','" & bonrefreg & "','" & jumdir_reg & "')"
        Else
            mlSQL2 = "Update minggu_fsb set amt = '" & mlREADER("amt") + bonms500u & "',jumdir = '" & mlREADER("jumdir") + jumdir_ft & "'" & vbCrLf
            mlSQL2 += ",amt_reg = '" & mlREADER("amt_reg") + bonrefreg & "',jumdir_reg = '" & mlREADER("jumdir_reg") + jumdir_reg & "'" & vbCrLf
            mlSQL2 += "where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' redempetion point
        ' tambah paket bila ada paket baru yang memberikan point redempetion
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        nilairp = 8
        If nilairp > 0 Then
            mlSQL = "Insert into tab_rp_sponsor(kta,direk,paket,point,tgl)Values('" & direk & "','" & kdposna & "','" & paket & "','" & nilairp & "', '" & Now & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' START HERE FOR LOOPING UPLINE POINT REWARDS
        ' BIKIN TABEL SASARAN UPDATE PARA UPLINENYA
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        wulpos = ""
        nuhun = ""
        wulan = wulpos
        nahun = nuhun
        bulan = Now()
        sponsor = direk
        piro = 0
        kedua = kdposna
        mutere = 0
        jume = postingup
        levke = 0


        pred = 0
        If paket = "MS400U-14" Then
            pred = 2
        End If

        If paket = "MS200TG272U-14" Or paket = "MS200HU-14" Or paket = "MS200KU-14" Or paket = "MS200MU-14" Or paket = "MS200BU-14" Or paket = "MS200U-14" Or paket = "MS200VUS-14" Or paket = "MS200VU-14" Then
            pred = 1
        End If

        If paket = "MS200AU-14" Then
            pred = 1
        End If

        '''' poin 2 atau 2.5
        tatanggalan = Day(Now.Date())
        If Len(tatanggalan) = 1 Then
            tatanggalan = "0" + CStr(tatanggalan)
        Else
            tatanggalan = tatanggalan
        End If

        wulandari = Month(Now.Date())
        If Len(wulandari) = 1 Then
            wulandari = "0" + CStr(wulandari)
        Else
            wulandari = wulandari
        End If

        taundari = Year(Now.Date())

        tanggalnateh = CStr(taundari) + CStr(wulandari) + CStr(tatanggalan)
        tanggalnateh = CLng(tanggalnateh)

        poinms = 0
        'if tanggalnateh >= 20150701 and tanggalnateh <= 20150732 then
        If paket = "MS200MU-14" Or paket = "MS200KU-14" Then
            poinms = 2
        End If

        tglku = Now()
        ulan = Month(tglku)
        ahun = Year(tglku)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        mlSQL = "SELECT TOP 1 kta,tipene,tipene_kartu FROM member where kta like '" & kdposna & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            mlSQL2 = "Update member set tipene = 'P',tipene_kartu = 'P' Where kta like '" & kdposna & "'"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()

        lanjutke = "T"
        dino = Now()
        wulan = wulpos
        nahun = nuhun
        nopos = nodcs
        PV = 0
        pvnya = 0
        mlSQL = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
        mlSQL += "And nopos Like '" & mypos & "' and dcinduk like '" & indukdc & "' and kode like 'MS%'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            paket = "MS4"
        Else
            paket = mlREADER("kode")
            PV = mlREADER("totpv")
            pvnya = mlREADER("totpv")
        End If
        mlREADER.Close()

        noid = kdposna
        mlSQL = "SELECT pvpribadi,produp FROM bns_mypv_current where ((kta like '" & noid & "')" & vbCrLf
        mlSQL += "And (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            pvnow = 0
            nilaibv = 0
        Else
            pvnow = (mlREADER("pvpribadi") + mlREADER("produp"))
            nilaibv = 0
        End If
        mlREADER.Close()

        indukdc = "B-000"
        modepost = "Q" '' QUADRO atau NORMAL

        If modepost = "N" Then
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

            '''''''''''''''''''''''''''''''''''''''''''''	
            ' JIKA YG BELANJA RANKNYA DISTRIBUTOR
            '   200 PV = 25 PROD, 175 QP
            '   200 S/D 299 = QP SEMUA
            '   > 300 S/D 399 = QP SEMUA + VOUCHER 50.000
            '   = 400 = QP SEMUA + VOUCHER 100.000
            '   > 400 = SPLIT 50% : 50%
            '''''''''''''''''''''''''''''''''''''''''''''

            If levnya = 1 Or levnya = 2 Or levnya = 3 Then
                mlSQL2 = "SELECT sum(pvpri) FROM st_sale_daftar where ((noseri like '" & noid & "') and (alokbulan = '" & wulan & "') and (aloktahun = '" & nahun & "'))"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    pvreg = 0
                Else
                    pvreg = mlREADER2("sum(pvpri)")
                End If
                mlREADER2.Close()

                If IsDBNull(pvreg) = False Then
                    pvreg = CLng(pvreg)
                Else
                    pvreg = 0
                End If



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
                    'pvnow = (rs("pvpribadi")+rs("produp"))+pvnya
                    'pvnow2 = rs("pvpribadi")+rs("produp")
                    'pvnow3 = rS("pvpribadi")+pvnya
                    pvnow = ((mlREADER("pvpribadi") + mlREADER("produp")) + pvnya) - pvreg
                    pvnow2 = (mlREADER("pvpribadi") + mlREADER("produp")) - pvreg
                    pvnow3 = (mlREADER("pvpribadi") + pvnya) - pvreg
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
                            produp = produp
                        End If
                        nilaipv = (pvnow - produp) - pvnow2
                        'nilaipv = pvnow - produp
                        postingup = nilaipv
                    Else
                        If pvnow2 >= 400 Then
                            nilaipv = pvnya / 2
                            produp = nilaipv
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
                                    postingup = pvnya - produp
                                    nilaipv = pvnya - produp
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
                    pvnow = 0
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
            '''''''''''''''' akhir pilih ranking
        Else
            postingup = pvnya
            produp = 0
        End If '' MODE

        '''''buat nopajak
        bulanskr = CInt(Month(Now))
        tahunskr = CInt(Year(Now))

        noakhir = 1
        bulsks = CInt(Month(dino))

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

        blne = CStr(Now.Month)
        taun = Right(CStr(Now.Year), 2)
        nipe = CStr(noakhir)

        noinvo = nopos + "/" + tamb + nipe + "/PRD-" + blne + "/" + taun

        ''''''''''''''''''''''''''''''
        ' bikin nomor invoice pajak
        ''''''''''''''''''''''''''''''
        tahskr = CInt(Now.Year)
        kel = "RET"
        'rs.Open "SELECT * FROM nourut where dcinduk like '"&indukdc&"' AND nopos like '"&mypos&"' and year(tgl)='"&tahskr&"' and kel like '"&kel&"' order by urut desc limit 1",conn	
        If UCase(mypos) = "B-000" Then
            'rs.Open "SELECT urut FROM nourut where dcinduk like '"&indukdc&"' and year(tgl)='"&tahskr&"' order by urut desc limit 1",conn	
            masterdc = "B-000"
            k1 = "ODC"
            k2 = "RET"
            mlSQL = "SELECT TOP 1 urut FROM nourut where ((dcinduk like '" & masterdc & "' and kel like '" & k1 & "')" & vbCrLf
            mlSQL += "Or (nopos Like '" & masterdc & "' AND kel like '" & k2 & "')) and year(tgl)='" & tahskr & "' order by nopajak desc"
        Else
            mlSQL = "SELECT TOP 1 urut FROM nourut where dcinduk like '" & indukdc & "' AND nopos like '" & nopos & "'" & vbCrLf
            mlSQL += "And year(tgl)='" & tahskr & "' and kel like '" & kel & "' order by nopajak desc"
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
        mlSQL = "insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values('" & nopajak & "','" & mypos & "','" & noinvo & "'" & vbCrLf
        mlSQL += ",'" & Now.Date & "','PRD','RET','" & indukdc & "','" & nourutpjk & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "SELECT TOP 1 nosesi FROM st_sale_prd_head where nopos Like '" & nopos & "' order by nosesi desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            nosesi = 1
        Else
            nosesi = mlREADER("nosesi") + 1
        End If
        mlREADER.Close()

        mlSQL = "SELECT TOP 1 uid FROM member where kta like '" & noid & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namadist = "-"
        Else
            namadist = mlREADER("uid")
        End If
        mlREADER.Close()

        mlSQL = "SELECT * FROM st_sale_prd_head where nosesi like '" & nosesi & "' and nopos like '" & nopos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into st_sale_prd_head(postingup, produp, nopos, nosesi, urut, noinvoice, nopajak, kta, tglbayar" & vbCrLf
            mlSQL2 += ", totpv, totbv, subtot, diskon, totbruto, nodist, namadist, tunai, debit, cc, cek, jumbayar, kembalian," & vbCrLf
            mlsql2 += "suratjalan, alokbulan,aloktahun,tipe,dcinduk,modepost)Values('" & postingup & "','" & produp & "','" & nopos & "','" & nosesi & "'" & vbCrLf
            mlSQL2 += ",'" & noakhir & "','" & noinvo & "','" & nourutpjk & "','NEW MS','" & Now.Date & "','" & pvnya & "',0,0,0,0,'" & noid & "'" & vbCrLf
            mlSQL2 += ",'" & namadist & "',0,0,0,0,0,0,'-','" & wulan & "','" & nahun & "','TUPO','" & indukdc & "','" & modepost & "')"
        Else
            mlSQL2 = "insert into st_sale_prd_head(postingup, produp, nopos, nosesi, urut, noinvoice, nopajak, kta, tglbayar" & vbCrLf
            mlSQL2 += ", totpv, totbv, subtot, diskon, totbruto, nodist, namadist, tunai, debit, cc, cek, jumbayar, kembalian," & vbCrLf
            mlSQL2 += "suratjalan, alokbulan,aloktahun,tipe,dcinduk,modepost)Values('" & postingup & "','" & produp & "','" & nopos & "','" & nosesi & "'" & vbCrLf
            mlSQL2 += ",'" & noakhir & "','" & noinvo & "','" & nourutpjk & "','NEW MS','" & Now.Date & "','" & pvnya & "',0,0,0,0,'" & noid & "'" & vbCrLf
            mlSQL2 += ",'" & namadist & "',0,0,0,0,0,0,'-','" & wulan & "','" & nahun & "','TUPO','" & indukdc & "','" & modepost & "')"
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()
    End Sub
End Class

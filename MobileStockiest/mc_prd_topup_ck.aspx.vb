Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_prd_topup_ck
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2, mlREADER3 As OleDb.OleDbDataReader
    Dim mlSQL2, mlSQL3 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Protected mlDATATABLE As DataTable
    Protected mlDATATABLE2 As DataTable

    Dim menu_id, pos_area, mypos, loguser, nosesi, kelasdc, indukdc, indukmc, kdse, lanjutken, namatabel, namatabel2, dcHO, lanjutkena, noinvoice, namadist As String
    Dim hariakhir, skritu, tupoawal, tupoakhir, dino, dinoe As Date
    Dim mintupo, pred, wulan, nahun, wultupo, nuhuntupo As Integer

    Dim muter, aax As Integer
    Dim terusane, kedua As String
    Dim sisakembalian As Double

    Dim tgl, tglgabungnya As Date
    Dim noid, noidtopup, piyeup, l1, katpos, namatupo, l5 As String
    Dim jumtot, tunai, debit, kkredit, bgcek, duite, jumtotnet, jumdisk, belonjone, wesbelonjo As Double

    Dim kepiro, jume, juma, jume1, juma1, jume2, juma2, jume3, juma3, jume4, juma4, jume5, juma5, jume6, juma6, jume7, juma7, jumakhir As Integer
    Dim lanjutdodol1, lanjutdodol2, lanjutdodol3, lanjutdodol4, lanjutdodol5, lanjutdodol6, lanjutdodol7, nokode, ggg, ggg1 As String
    Dim kode1, mesej, namabr, mesej1, namabr1, nokode1, mesej2, namabr2, nokode2, mesej3, namabr3, nokode3, mesej4, namabr4, nokode4, mesej5, namabr5, nokode5, mesej6, namabr6, nokode6, mesej7, namabr7, nokode7 As String
    Dim jumlah1 As Double
    Dim jumakt, jumpaket, jumlahalokakt As Double

    Dim skr As Date
    Dim lanjutposting, tamb, blne, taun, nipe, noinvo, kel, masterdc, k1, k2, nourutpjk, kdd1, kdd2 As String
    Dim bulanskr, tahunskr, noakhir, bulsks, jk, tahskr, nopajak As Integer
    Dim tambahanpv As Double
    Dim noinvonye, lanjut, langsungposting As String
    Dim sapa, idygdapat, muterku As Integer
    Dim proddepo, pvdepo, prodreg, pvku, pvreg, pvprod, jummurni As Double
    Dim jammulai As Date



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")

        wulan = wultupo
        nahun = nuhuntupo
        mintupo = 200

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        nosesi = Session("nosesi")
        Session("nosesi") = nosesi
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        indukmc = Session.Contents("indukmc")
        skritu = Now()

        ''''''''''''''''''''''''''''''''
        ' cari produk ber point reward
        ''''''''''''''''''''''''''''''''
        kdse = "PTU"
        pred = 0
        mlSQL = "SELECT count(id) FROM st_sale_prd_det_tmp where nosesi like '" & nosesi & "' and nopos like '" & mypos & "' and ucase(kode) like '" & kdse & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            pred = 0
        Else
            pred = 1
        End If
        mlREADER.Close()

        lanjutken = "F"
        If UCase(loguser) = "HWIHQ" Then
            lanjutken = "T"
        Else
            If tupoawal < skritu And tupoakhir > skritu Then
                lanjutken = "T"
            Else
                lanjutken = "F"

                Session("errorpos") = "Kesempatan top up sudah berakhir, proses dibatalkan"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            End If
        End If

        If Session("motok") = "" Or Session("kowe") = "" Then

            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("sotok") = mypos
            Session("anda") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        If UCase(mypos) = dcHO Then
            namatabel = "st_barang"
            namatabel2 = "st_kartustock"
        Else
            namatabel = "st_barang_ms"
            namatabel2 = "st_kartustock_ms"
        End If

        CekValidSession()
        CekStokActual()

    End Sub

    Sub CekValidSession()
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' CEK APAKAH NO SESI SUDAH ADA DI TABLE REAL
        ' AGAR TIDAK TERJADI DUPLIKASI DATA
        ''''''''''''''''''''''''''''''''''''''''''''''''
        lanjutkena = "F"
        mlSQL = "SELECT noinvoice FROM st_sale_prd_head where nopos like '" & mypos & "' and nosesi like '" & nosesi & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjutkena = "T"
        Else
            lanjutkena = "F"

            Session("nosesi") = ""
            Session("noinvoice") = noinvoice
            Response.Redirect("sale_prd_dist_inv.aspx?menu_id=" & menu_id)
        End If
        mlREADER.Close()


        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        tgl = CDate(Request("tgl"))
        noid = Trim(Request("kdpos"))
        noidtopup = Trim(Request("kdtopup"))
        jumtot = Trim(Request("jumtot"))
        tunai = Trim(Request("jumbayarcash"))
        debit = Trim(Request("jumbayardb"))
        kkredit = Trim(Request("jumbayarcc"))
        bgcek = Trim(Request("jumbayarcek"))
        duite = Trim(Request("jumbayar"))

        jumtotnet = Trim(Request("jumtotnet"))
        jumdisk = Trim(Request("jumdisk"))

        belonjone = 0
        piyeup = "R"

        If tgl = "" Then
            Session("errorpos") = "Invalid Tanggal Transaski"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            If tgl < dinoe Then
                Session("errorpos") = "Invalid Tanggal Transaski"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            End If
        End If

        If noid = "" Then
            l1 = "Mbuh"
            Session("errorpos") = "Nomor id. distributor penerima alokasi top up belum diisi"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        Else
            If Len(noid) >= 16 Then
                Session("errorpos") = "Nomor id. distributor penerima alokasi top up belum diisi"
                l1 = "Mbuh"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            Else
                If ((Len(noid) <= 16) And (noid <> "")) Then
                    mlSQL = "SELECT kta,uid,sta,joindt,upme,tipene_kartu FROM member where kta like '" & noid & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorpos") = "Nomor id. distributor penerima alokasi top up tidak ditemukan"
                        l1 = "Mbuh"
                        Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                    Else
                        If mlREADER("sta") = "T" Then
                            namadist = mlREADER("uid")
                            tglgabungnya = mlREADER("joindt")
                            'piyeup = rsALL("upme")
                            piyeup = UCase(mlREADER("tipene_kartu"))
                            l1 = "Ter1"
                            Session("errorpos") = ""
                        Else

                            namadist = ""
                            l1 = "Mbuh"
                            Session("errorpos") = "Nomor id. distributor penerima alokasi top up dalam status SUSPEND. Silahkan batalkan transaksi ini dan hubungi kantor pusat"
                            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
                        End If
                    End If
                    mlREADER.Close()
                End If
            End If
        End If

        If noidtopup = "" Then

            l1 = "Mbuh"
            Session("errorpos") = "Nomor id. distributor yang melakukan top up belum diisi"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        Else
            If Len(noidtopup) >= 16 Then

                Session("errorpos") = "Nomor id. distributor yang melakukan top up belum diisi"
                l1 = "Mbuh"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            Else
                If ((Len(noidtopup) <= 16) And (noidtopup <> "")) Then
                    mlSQL = "SELECT kta,uid,sta FROM member where kta like '" & noidtopup & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorpos") = "Nomor id. distributor yang melakukan top up tidak ditemukan"
                        l1 = "Mbuh"
                        Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                    Else
                        If mlREADER("sta") = "T" Then
                            mlSQL2 = "SELECT pvpribadi,produp FROM bns_mypv_current where kta like '" & noidtopup & "' and bulan like '" & wulan & "' and tahun='" & nahun & "'"
                            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Read()
                            If Not mlREADER2.HasRows Then
                                wesbelonjo = 0
                            Else
                                wesbelonjo = CInt(mlREADER2("pvpribadi") + mlREADER2("produp"))
                            End If
                            mlREADER2.Close()

                            If UCase(katpos) <> "PST" Then
                                If wesbelonjo >= mintupo Then
                                    namatupo = mlREADER("uid")
                                    l1 = "Ter1"
                                    Session("errorpos") = ""
                                Else

                                    namatupo = ""
                                    l1 = "Mbuh"
                                    Session("errorpos") = "Distributor pelaku top up belum melakukan tutup point"
                                    Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                                End If
                            Else
                                namatupo = mlREADER("uid")
                                l1 = "Ter1"
                                Session("errorpos") = ""
                            End If
                        Else
                            namatupo = ""
                            l1 = "Mbuh"
                            Session("errorpos") = "Nomor id. distributor yang melakukan top up dalam status SUSPEND. Silahkan batalkan transaksi ini dan hubungi kantor pusat"
                            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
                        End If
                    End If
                    mlREADER.Close()
                End If
            End If
        End If

        If jumtotnet = "" Then
            l1 = "Mbuh"
            Session("errorpos") = "Anda belum berbelanja"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(jumtotnet) = False Then
                l1 = "Mbuh"
                Session("errorpos") = "Anda belum berbelanja"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            Else
                If ((jumtotnet <> "") And (IsNumeric(jumtotnet) = True)) Then
                    If jumtotnet < 0 Then

                        l1 = "Mbuh"
                        Session("errorpos") = "Anda belum berbelanja"
                        Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                    Else
                        jumtotnet = jumtotnet
                    End If
                End If
            End If
        End If

        If jumtot = "" Then
            l1 = "Mbuh"
            Session("errorpos") = "Anda belum berbelanja"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(jumtot) = False Then
                l1 = "Mbuh"
                Session("errorpos") = "Anda belum berbelanja"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            Else
                If ((jumtot <> "") And (IsNumeric(jumtot) = True)) Then
                    If jumtot < 0 Then
                        l1 = "Mbuh"
                        Session("errorpos") = "Anda belum berbelanja"
                        Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
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

        If tunai + debit + kkredit + bgcek <= 0 Then

            l5 = "Mbuh"
            Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        End If

        '''''''''''''''''''''''''
        ' cegah lintas jaringan '
        ''''''''''''''''''''''''
        mlSQL = "SELECT TOP 1 id FROM mylevel order by id DESC"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            muter = 1000
        Else
            muter = mlREADER("id")
        End If
        mlREADER.Close()

        If noidtopup = noid Then
            terusane = "R4ki50lah"
            Session("errorpos") = "Distributor tidak bisa melakukan top up untuk dirinya sendiri."
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        Else
            terusane = "R4ki50lah"
            kedua = noid
            For aaxd = 1 To muter
                mlSQL = "SELECT kta,ktaloc FROM mylevel WHERE kta LIKE '" & kedua & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    aaxd = muter + 10
                    Exit For
                Else
                    If mlREADER("ktaloc") = noidtopup Then
                        terusane = "LulusUj1Klinis"
                        aax = muter + 10
                        Exit For
                    Else
                        kedua = mlREADER("ktaloc")
                    End If
                End If
                mlREADER.Close()
                aaxd = aaxd + 1
                If aaxd = muter Then
                    Exit For
                End If
            Next
            mlREADER.Close()
        End If

        If terusane <> "LulusUj1Klinis" Then
            terusane = "R4ki50lah"
            Session("errorpos") = "Top up tidak bisa crossline"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        End If

        If tunai = 0 And debit = 0 And kkredit = 0 And bgcek = 0 Then
            duite = 0
        Else
            duite = duite
        End If

        If duite = "" Then
            l5 = "Mbuh"
            Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(duite) = False Then
                l5 = "Mbuh"
                Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            Else
                If ((duite <> "") And (IsNumeric(duite) = False)) Then
                    If duite > 0 Then
                        sisakembalian = duite - jumtot
                        If sisakembalian = 0 Or sisakembalian > 0 Then
                            l5 = "Ter5"
                            Session("errorpos") = ""
                        Else
                            l5 = "Mbuh"
                            Session("errorpos") = "Jumlah Pembayaran Anda tidak Mencukupi"
                            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                        End If
                    Else
                        l5 = "Mbuh"
                        Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                        Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If

    End Sub

    Sub CekStokActual()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' CEK STOCK AKTUAL
        '''''''''''''''''''''''''''''''''''''''''''''''''''''
        kepiro = 0
        lanjutdodol1 = "T"
        lanjutdodol2 = "T"
        lanjutdodol3 = "T"
        lanjutdodol4 = "T"
        lanjutdodol5 = "T"
        lanjutdodol6 = "T"
        lanjutdodol7 = "T"
        mlSQL = "SELECT * FROM st_sale_prd_det_tmp where nosesi like '" & nosesi & "' and nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlDATATABLE = New DataTable
            mlDATATABLE.Load(mlREADER)
            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                kepiro = kepiro + 1
                nokode = UCase(mlDATATABLE.Rows(aaaeqSSS)("kode"))
                jume = CInt(mlDATATABLE.Rows(aaaeqSSS)("jumlah"))
                ''''''''''''''''''''''''''''''''''''''
                ' CEK STOCK ALOKASI UNTUK STARTERKIT
                ''''''''''''''''''''''''''''''''''''''
                ggg = "AKT"
                ggg1 = "UPG"
                jumlahalokakt = 0
                mlSQL2 = "SELECT kode,jumlah FROM " & namatabel & " where nopos like '" & mypos & "' and (grp like '" & ggg & "' or grp like '" & ggg1 & "' or grp like '" & ggg2 & "')"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                If mlREADER2.HasRows Then
                    mlDATATABLE2 = New DataTable
                    mlDATATABLE2.Load(mlREADER2)
                    For aaaeqSSSK = 1 To mlDATATABLE2.Rows.Count - 1
                        kode1 = mlDATATABLE.Rows(aaaeqSSSK)("kode")
                        jumlah1 = mlDATATABLE.Rows(aaaeqSSSK)("jumlah")
                        mlSQL3 = "SELECT * FROM st_tipe_paket_jumlah where paket like '" & kode1 & "' and kode like '" & nokode & "'"
                        mlREADER3 = mlOBJGS.DbRecordset(mlSQL3, mpMODULEID, mlCOMPANYID)
                        mlREADER3.Read()
                        If Not mlREADER3.HasRows Then
                            jumakt = 0
                        Else
                            jumakt = mlREADER3("jumlah")
                        End If
                        mlREADER3.Close()

                        jumpaket = (jumlah1 * jumakt)

                        jumlahalokakt = jumlahalokakt + jumpaket
                    Next
                End If
                mlREADER2.Close()

                mlSQL2 = "SELECT kode,jumlah,nama FROM " & namatabel & " where ucase(kode) like '" & nokode & "' and nopos like '" & mypos & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    If kepiro = 1 Then
                        lanjutdodol1 = "F"
                    ElseIf kepiro = 2 Then
                        lanjutdodol2 = "F"
                    ElseIf kepiro = 3 Then
                        lanjutdodol3 = "F"
                    ElseIf kepiro = 4 Then
                        lanjutdodol4 = "F"
                    ElseIf kepiro = 5 Then
                        lanjutdodol5 = "F"
                    ElseIf kepiro = 6 Then
                        lanjutdodol6 = "F"
                    ElseIf kepiro = 7 Then
                        lanjutdodol7 = "F"
                    End If
                    mesej = "Stock barang berikut ini tidak mencukupi untuk dilakukan transaski. Stock barang : " & nokode
                Else
                    juma = Int(mlREADER2("jumlah"))
                    namabr = mlREADER2("nama")
                    If kepiro = 1 Then
                        If UCase(mypos) = "B-000" Then
                            lanjutdodol1 = "T"
                        Else
                            If (juma - (jume + jumlahalokakt)) >= 0 Then
                                lanjutdodol1 = "T"
                                mesej1 = ""
                                namabr1 = ""
                                jume1 = 0
                                juma1 = 0
                            Else
                                lanjutdodol1 = "F"
                                mesej1 = "-"
                                nokode1 = nokode
                                namabr1 = namabr
                                jume1 = jume
                                juma1 = juma
                            End If
                        End If
                    End If

                    If kepiro = 2 Then
                        If UCase(mypos) = "B-000" Then
                            lanjutdodol2 = "T"
                        Else
                            If (juma - (jume + jumlahalokakt)) >= 0 Then
                                lanjutdodol2 = "T"
                                mesej2 = ""
                            Else
                                lanjutdodol2 = "F"
                                mesej2 = "-"
                                nokode2 = nokode
                                namabr2 = namabr
                                jume2 = jume
                                juma2 = juma
                            End If
                        End If
                    End If

                    If kepiro = 3 Then
                        If UCase(mypos) = "B-000" Then
                            lanjutdodol3 = "T"
                        Else
                            If (juma - (jume + jumlahalokakt)) >= 0 Then
                                lanjutdodol3 = "T"
                                mesej3 = ""
                            Else
                                lanjutdodol3 = "F"
                                mesej3 = "-"
                                nokode3 = nokode
                                namabr3 = namabr
                                jume3 = jume
                                juma3 = juma
                            End If
                        End If
                    End If

                    If kepiro = 4 Then
                        If UCase(mypos) = "B-000" Then
                            lanjutdodol4 = "T"
                        Else
                            If (juma - (jume + jumlahalokakt)) >= 0 Then
                                lanjutdodol4 = "T"
                                mesej4 = ""
                            Else
                                lanjutdodol4 = "F"
                                mesej4 = "-"
                                nokode4 = nokode
                                namabr4 = namabr
                                jume4 = jume
                                juma4 = juma
                            End If
                        End If
                    End If

                    If kepiro = 5 Then
                        If UCase(mypos) = "B-000" Then
                            lanjutdodol5 = "T"
                        Else
                            If (juma - (jume + jumlahalokakt)) >= 0 Then
                                lanjutdodol5 = "T"
                                mesej5 = ""
                            Else
                                lanjutdodol5 = "F"
                                mesej5 = "-"
                                nokode5 = nokode
                                namabr5 = namabr
                                jume5 = jume
                                juma5 = juma
                            End If
                        End If
                    End If

                    If kepiro = 6 Then
                        If UCase(mypos) = "B-000" Then
                            lanjutdodol6 = "T"
                        Else
                            If (juma - (jume + jumlahalokakt)) >= 0 Then
                                lanjutdodol6 = "T"
                                mesej6 = ""
                            Else
                                lanjutdodol6 = "F"
                                mesej6 = "-"
                                nokode6 = nokode
                                namabr6 = namabr
                                jume6 = jume
                                juma6 = juma
                            End If
                        End If
                    End If

                    If kepiro = 7 Then
                        If UCase(mypos) = "B-000" Then
                            lanjutdodol7 = "T"
                        Else
                            If (juma - (jume + jumlahalokakt)) >= 0 Then
                                lanjutdodol7 = "T"
                                mesej7 = ""
                            Else
                                lanjutdodol7 = "F"
                                mesej7 = "-"
                                nokode7 = nokode
                                namabr7 = namabr
                                jume7 = jume
                                juma7 = juma
                            End If
                        End If
                    End If
                End If
                mlREADER2.Close()
            Next
        End If
        mlREADER.Close()

        If lanjutdodol1 = "F" Or lanjutdodol2 = "F" Or lanjutdodol3 = "F" Or lanjutdodol4 = "F" Or lanjutdodol5 = "F" Or lanjutdodol6 = "F" Or lanjutdodol7 = "F" Or lanjutken = "F" Then
            Dim str_Lanjutan As String = ""
            str_Lanjutan += "<section Class='content'>" & vbCrLf
            str_Lanjutan += "<div Class='box'>" & vbCrLf
            str_Lanjutan += "<div Class='box-header with-border'>" & vbCrLf
            str_Lanjutan += "<h3 Class='box-title'></h3>" & vbCrLf
            str_Lanjutan += "<div Class='box-tools pull-right'>" & vbCrLf
            str_Lanjutan += "<Button type = 'button' Class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
            str_Lanjutan += "<i Class='fa fa-minus'></i></button>" & vbCrLf
            str_Lanjutan += "<Button type = 'button' Class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
            str_Lanjutan += "<i Class='fa fa-times'></i></button>" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "<div Class='box-body'>" & vbCrLf
            str_Lanjutan += "<p align = 'center' >" & vbCrLf
            str_Lanjutan += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
            str_Lanjutan += "<br/>" & vbCrLf
            str_Lanjutan += "<br/>" & vbCrLf
            str_Lanjutan += "<p align='center'>" & vbCrLf

            If mesej1 <> "" Then
                str_Lanjutan += "Item produk <b>" & nokode1 & " :  " & namabr1 & "</b> tidak mencukupi untuk dilakukan transaksi ini.<br/>" & vbCrLf
                str_Lanjutan += "Silahkan perbaiki pengisian jumlah barang yang diorder terlebih dulu.<br/>" & vbCrLf
                str_Lanjutan += "Jumlah stock aktual yang tersedia saat ini adalah sebanyak <b>" & FormatNumber(juma1, 0) & "</b>, sedangkan orderan anda sebanyak <b>" & FormatNumber(jume1, 0) & "</b><br/><br/>" & vbCrLf
            End If
            If mesej2 <> "" Then
                str_Lanjutan += "Item produk <b>" & nokode2 & " :  " & namabr2 & "</b> tidak mencukupi untuk dilakukan transaksi ini.<br/>" & vbCrLf
                str_Lanjutan += "Silahkan perbaiki pengisian jumlah barang yang diorder terlebih dulu.<br/>" & vbCrLf
                str_Lanjutan += "Jumlah stock aktual yang tersedia saat ini adalah sebanyak <b>" & FormatNumber(juma2, 0) & "</b>, sedangkan orderan anda sebanyak <b>" & FormatNumber(jume2, 0) & "</b><br/><br/>" & vbCrLf
            End If
            If mesej3 <> "" Then
                str_Lanjutan += "Item produk <b>" & nokode3 & " :  " & namabr3 & "</b> tidak mencukupi untuk dilakukan transaksi ini.<br/>" & vbCrLf
                str_Lanjutan += "Silahkan perbaiki pengisian jumlah barang yang diorder terlebih dulu.<br/>" & vbCrLf
                str_Lanjutan += "Jumlah stock aktual yang tersedia saat ini adalah sebanyak <b>" & FormatNumber(juma3, 0) & "</b>, sedangkan orderan anda sebanyak <b>" & FormatNumber(jume3, 0) & "</b><br/><br/>" & vbCrLf
            End If
            If mesej4 <> "" Then
                str_Lanjutan += "Item produk <b>" & nokode4 & " :  " & namabr4 & "</b> tidak mencukupi untuk dilakukan transaksi ini.<br/>" & vbCrLf
                str_Lanjutan += "Silahkan perbaiki pengisian jumlah barang yang diorder terlebih dulu.<br/>" & vbCrLf
                str_Lanjutan += "Jumlah stock aktual yang tersedia saat ini adalah sebanyak <b>" & FormatNumber(juma4, 0) & "</b>, sedangkan orderan anda sebanyak <b>" & FormatNumber(jume4, 0) & "</b><br/><br/>" & vbCrLf
            End If
            If mesej5 <> "" Then
                str_Lanjutan += "Item produk <b>" & nokode5 & " :  " & namabr5 & "</b> tidak mencukupi untuk dilakukan transaksi ini.<br/>" & vbCrLf
                str_Lanjutan += "Silahkan perbaiki pengisian jumlah barang yang diorder terlebih dulu.<br/>" & vbCrLf
                str_Lanjutan += "Jumlah stock aktual yang tersedia saat ini adalah sebanyak <b>" & FormatNumber(juma5, 0) & "</b>, sedangkan orderan anda sebanyak <b>" & FormatNumber(jume5, 0) & "</b><br/><br/>" & vbCrLf
            End If
            If mesej6 <> "" Then
                str_Lanjutan += "Item produk <b>" & nokode6 & " :  " & namabr6 & "</b> tidak mencukupi untuk dilakukan transaksi ini.<br/>" & vbCrLf
                str_Lanjutan += "Silahkan perbaiki pengisian jumlah barang yang diorder terlebih dulu.<br/>" & vbCrLf
                str_Lanjutan += "Jumlah stock aktual yang tersedia saat ini adalah sebanyak <b>" & FormatNumber(juma6, 0) & "</b>, sedangkan orderan anda sebanyak <b>" & FormatNumber(jume6, 0) & "</b><br/><br/>" & vbCrLf
            End If
            If mesej7 <> "" Then
                str_Lanjutan += "Item produk <b>" & nokode7 & " :  " & namabr7 & "</b> tidak mencukupi untuk dilakukan transaksi ini.<br/>" & vbCrLf
                str_Lanjutan += "Silahkan perbaiki pengisian jumlah barang yang diorder terlebih dulu.<br/>" & vbCrLf
                str_Lanjutan += "Jumlah stock aktual yang tersedia saat ini adalah sebanyak <b>" & FormatNumber(juma7, 0) & "</b>, sedangkan orderan anda sebanyak <b>" & FormatNumber(jume7, 0) & "</b><br/><br/>" & vbCrLf
            End If


            str_Lanjutan += "&lt;-- <a href='mc_prd_topup.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a>  --&gt;" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "</section>" & vbCrLf

            Div_mc_ck.InnerHtml = str_Lanjutan
        Else
            If lanjutdodol1 = "T" And lanjutdodol2 = "T" And lanjutdodol3 = "T" And lanjutdodol4 = "T" And lanjutdodol5 = "T" And lanjutdodol6 = "T" And lanjutdodol7 = "T" And lanjutken = "T" Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' CEK VALID SESSION
                ' CLOSE SESSION INPUT HANYA BISA DILAKUKAN MELALUI KANTOR PUSAT
                ' CLOSE SESSION TIAP AKHIR BULAN PADA TANGGAL 30/31 JAM 19:00:00 WIB
                ' BILA ADA TRANSAKSI PADA TANGGAL 30/31 LEWAT CLOSING TIME, MAKA DITOLAK DAN DIMINTA UNTUK MENGHUBUNGI KANTOR PUSAT
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                skr = Now()
                lanjutposting = "T"
                If lanjutposting = "T" And lanjutken = "T" Then
                    dino = Now()
                    bulanskr = CInt(Month(dino))
                    tahunskr = CInt(Year(dino))
                    mlSQL = "SELECT TOP 1 id,urut,tgl FROM st_sale_prd_head where nopos like '" & mypos & "' AND month(tgl)='" & bulanskr & "' AND year(tgl) = '" & tahunskr & "' order by urut DESC"
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

                    noinvo = mypos + "/" + tamb + nipe + "/PRD-" + blne + "/" + taun

                    tahskr = CInt(Year(dino))
                    kel = "RET"
                    'rs.Open "SELECT * FROM nourut where dcinduk like '"&indukdc&"' AND nopos like '"&mypos&"' and year(tgl)='"&tahskr&"' and kel like '"&kel&"' order by urut desc limit 1",conn	
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

                    mlSQL = "insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values('" & nopajak & "','" & mypos & "','" & noinvo & "','" & dino & "','PRD','RET','" & indukdc & "','" & nourutpjk & "')"
                    mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                    wulan = wultupo
                    nahun = nuhuntupo

                    ''''''''''''''''''''''''''''''''''''''''''''
                    ' PROMO EXTRA PV UNTUK PEMBELIAN MU DAN PG
                    ' 1 MU / PG  = FREE XTRA PV 10 PV
                    ' KHUSUS BULAN 11 DAN 12 2010
                    ''''''''''''''''''''''''''''''''''''''''''''
                    If ((wulan = 11 And nahun = 2010) Or (wulan = 12 And nahun = 2010)) Then
                        kdd1 = "MU"
                        kdd2 = "PG"
                        tambahanpv = 0
                        rs.Open "SELECT sum(jumlah) FROM st_sale_prd_det_tmp where nopos like '" & mypos&"' and nosesi like '"&nosesi&"' and (kode like '"&kdd1&"' or kode like '"&kdd2&"')", conn
                If rs.bof Then
                            tambahanpv = 0
                        Else
                            tambahanpv = rs("sum(jumlah)")
                        End If
                        rs.close
                    Else
                        tambahanpv = 0
                    End If
                    If isnull(tambahanpv) = False Then
                        tambahanpv = tambahanpv * 10
                    Else
                        tambahanpv = 0
                    End If

                    Dim nilaipv, nilaibv, pvnya, bvnya, subtotnya, pvfull, jumtot, jumdisk, tunai, debit, kkredit, bgcek, duite, pvne, bvne, hargane, subtote, awal, sisastok As Double
                    Dim noid, noidtopup, entuk, mutermaneh, urut, aaxdx As Integer
                    Dim namatupo, namabrg As String

                    rs.Open "SELECT * FROM st_sale_prd_head_tmp where nopos like '" & mypos&"' and nosesi like '"&nosesi&"'", conn
            If rs.bof Then
                        pvnya = 0
                        bvnya = 0
                        subtotnya = 0
                    Else
                        pvnya = rs("totpv") + tambahanpv
                        bvnya = rs("totbv") + tambahanpv
                        subtotnya = rs("subtot")
                    End If
                    rs.close
                    nilaipv = pvnya
                    nilaibv = bvnya
                    pvfull = pvnya

                    rs.Open "SELECT * FROM st_sale_prd_head where nosesi like '" & nosesi&"' and nopos like '"&mypos&"'", conn, 3, 3
            If rs.bof Then
                        rs.addnew
                        rs("postingup") = nilaipv
                        rs("produp") = 0
                        rs("nopos") = mypos
                        rs("nosesi") = nosesi
                        rs("urut") = noakhir
                        rs("noinvoice") = noinvo
                        rs("nopajak") = nourutpjk
                        rs("kta") = loguser
                        rs("tgl") = dino
                        rs("totpv") = pvnya
                        rs("totbv") = 0

                        rs("subtot") = jumtot
                        rs("diskon") = jumdisk
                        rs("totbruto") = subtotnya

                        rs("nodist") = noid
                        rs("namadist") = namadist
                        rs("tunai") = tunai
                        rs("debit") = debit
                        rs("cc") = kkredit
                        rs("cek") = bgcek
                        rs("jumbayar") = duite
                        rs("kembalian") = duite - subtotnya
                        rs("suratjalan") = "-"
                        rs("alokbulan") = wulan
                        rs("aloktahun") = nahun
                        rs("tipe") = "topup"
                        rs("tupokta") = noidtopup
                        rs("tuponama") = namatupo
                        rs("dcinduk") = indukdc
                        rs("modepost") = "Q"
                        rs.update
                    Else
                    End If
                    rs.close

                    '''''''''''''''''''''''''''''''''''''''''
                    ' REPLACE SATU PERSATU KE TABLE REAL
                    ' POTONG STOCK
                    ' UPDATE PV UPLINE
                    '''''''''''''''''''''''''''''''''''''''''
                    rs.Open "SELECT * FROM st_sale_prd_det_tmp where nosesi like '" & nosesi&"' and nopos like '"&mypos&"'", conn    
            If rs.eof <> True Then

                        If goneqSS <> 0 Then
                            For aaeeqSS = 1 To goneqSS
                                If rs.eof = True Then Exit For
                                rs.movenext
                            Next
                        Else
                        End If
                        For aaaeqSSS = 1 To 14
                            If rs.eof = True Then Exit For

                            nokode = rs("kode")
                            jume = rs("jumlah")
                            pvne = rs("pv")
                            bvne = rs("bv")
                            hargane = rs("harga")
                            namabrg = rs("nama")
                            subtote = rs("subtot")
                            entuk = 0

                            If ((wulan >= 4 And wulan <= 8) And nahun = 2013) Then

                                If nokode = "PRQQGPB" Then
                                    mutermaneh = jume * 2
                                    For aaxdz = 1 To mutermaneh

                                        rsALL.Open "SELECT * FROM promo_qq13 order by urut desc limit 1", connALL, 3, 3
                    If rsALL.bof Then
                                            rsALL.addnew
                                            rsALL("no_undian") = 100001
                                            rsALL("urut") = 1
                                            rsALL("kta") = noid
                                            rsALL("noinvoice") = noinvo
                                            rsALL("tgl") = Now()
                                            rsALL("dc") = mypos
                                            rsALL.update
                                        Else
                                            urut = CLng(rsALL("urut")) + 1
                                            rsALL.addnew
                                            rsALL("urut") = urut
                                            rsALL("no_undian") = urut + 100000
                                            rsALL("kta") = noid
                                            rsALL("noinvoice") = noinvo
                                            rsALL("tgl") = Now()
                                            rsALL("dc") = mypos
                                            rsALL.update
                                        End If
                                        rsALL.Close

                                        aaxdz = aaxdz + 1
                                        If aaxdz >= mutermaneh And aaxdx >= entuk Then
                                            Exit For
                                        End If
                                    Next
                                    entuk = entuk + 1
                                End If
                            End If

                            rsALL.Open "SELECT * FROM " & namatabel&" where kode like '"&nokode&"' and nopos like '"&mypos&"'", connALL, 3, 3
                If rsALL.bof Then
                                jumakhir = 0
                            Else
                                jumakhir = rsALL("jumlah")
                                rsALL.update
                                rsALL("jumlah") = rsALL("jumlah") - jume
                                rsALL.update
                            End If
                            rsALL.Close

                            If jumakhir <= 0 Then
                                jumakhir = jume
                            Else
                                jumakhir = jumakhir
                            End If

                            rsALL.Open "SELECT * FROM st_sale_prd_det where nosesi like '" & nosesi&"' and nopos like '"&mypos&"'", connALL, 3, 3
                rsALL.addnew
                            rsALL("nopos") = mypos
                            rsALL("kta") = noid
                            rsALL("nosesi") = nosesi
                            rsALL("kode") = nokode
                            rsALL("nama") = namabrg
                            rsALL("jumlah") = jume
                            rsALL("harga") = hargane
                            rsALL("pv") = pvne
                            rsALL("bv") = bvne
                            rsALL("subtot") = subtote
                            rsALL("noinvoice") = noinvo
                            rsALL("nopajak") = nourutpjk
                            rsALL("tgl") = dino
                            rsALL("dcinduk") = indukdc
                            rsALL("alokbulan") = wulan
                            rsALL("aloktahun") = nahun
                            rsALL("namadist") = namadist
                            rsALL.update
                            rsALL.Close

                            rsALL.Open "SELECT * FROM " & namatabel2&" where kode like '"&nokode&"' and nopos like '"&mypos&"' order by tgl desc, id desc LIMIT 3", connALL, 3, 3
                If rsALL.bof Then
                                rsALL.addnew
                                rsALL("kode") = nokode
                                rsALL("nopos") = mypos
                                rsALL("tgl") = dino
                                rsALL("awal") = 0
                                rsALL("masuk") = 0
                                rsALL("keluar") = jume
                                rsALL("akhir") = 0 - jume
                                rsALL("referensi") = noinvo
                                rsALL("keterangan") = "Penjualan Produk"
                                rsALL.update
                            Else
                                awal = rsALL("akhir")
                                sisastok = awal - jume
                                'if sisastok < 0 then
                                '	sisastok = 0
                                'else
                                '	sisastok = sisastok
                                'end if		
                                rsALL.addnew
                                rsALL("kode") = nokode
                                rsALL("nopos") = mypos
                                rsALL("tgl") = dino
                                rsALL("awal") = awal
                                rsALL("masuk") = 0
                                rsALL("keluar") = jume
                                rsALL("akhir") = sisastok
                                rsALL("referensi") = noinvo
                                rsALL("keterangan") = "Penjualan Produk"
                                rsALL.update
                            End If
                            rsALL.Close

                            rs.movenext
                        Next
                    End If
                    If rs.eof = True Then
                    End If
                    rs.Close


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' BIKIN NOMOR UNDIAN UNTUK PRODUK CMP, CMP8, CPO dan TG2
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    noinvonye = noinvo
                    idygdapat = noidtopup

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' START HERE FOR LOOPING
                    ' UPDATE PV PRIBADI DAN UPLINENYA
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    sapa = noid
                    jume = nilaipv
                    bvne = 0
                    Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                    'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

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
                    pvku = 0
                    pvreg = 0
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
                        pvprod = pvprod + prodreg + proddepo
                    Else
                        pvprod = 0 + prodreg + proddepo
                    End If

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
                        pvku = pvku + pvreg + pvdepo
                    Else
                        pvku = 0 + pvreg + pvdepo
                    End If

                    jummurni = 0
                    lanjut = "F"
                    rs.Open "SELECT * FROM bns_mypv_current where ((kta like '" & sapa&"') and (bulan = '"&wulan&"') and (tahun = '"&nahun&"'))", conn, 3, 3
            If rs.bof Then
                        rs.addnew
                        rs("kta") = sapa
                        rs("bulan") = wulan
                        rs("tahun") = nahun
                        rs("pvpribadi") = pvku
                        rs("produp") = pvprod
                        rs("pvmurni") = 0
                        rs("pvgrupkiri") = 0
                        rs("pvgrupkanan") = 0
                        rs.update
                        lanjut = "F"
                        jummurni = 0
                    Else
                        lanjut = "T"
                        jummurni = rs("pvmurni")
                    End If
                    rs.close
                    If isnull(jummurni) Then
                        jummurni = 0
                    Else
                        jummurni = jummurni
                    End If

                    If lanjut = "T" Then

                        strSQLG = "UPDATE bns_mypv_current SET produp = '" & pvprod&"', pvpribadi= '"&pvku&"', pvmurni= '"&jummurni&"' WHERE (((bulan = "&wulan&") and (tahun = "&nahun&")) and (kta like '"&sapa&"'))"

                            End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' update table temporary untuk dieksekusi waktu muncul invoice
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    rs.Open "SELECT * FROM temp_belum order by id desc limit 1", conn, 3, 3
            rs.addnew
                    rs("nopos") = mypos
                    rs("noinvo") = noinvo
                    rs("bulan") = wulan
                    rs("tahun") = nahun
                    rs("kta") = sapa
                    rs("postingup") = jume
                    rs("pred") = 0
                    rs("nambahkiri") = 0
                    rs("nambahkanan") = 0
                    rs("sta") = "B"
                    rs("asal") = "TOPUP"
                    rs("tipe") = "PRODUK"
                    rs("tgl") = dino
                    rs("hendel") = "F"
                    rs("pvfull") = pvfull
                    rs.update
                    rs.close

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
                    ' bila diperlukan karena proses querry banyak dan membuat proses lemot, maka
                    ' ubah langsungposting menjadi F
                    ' langsungposting = F, artinya tidak langsung dipostingkan pointya
                    ' point dipostingkan melalui script processing/postingpv.asp yang harus dirunning schedulle
                    ' 
                    ' ubah langsungposting menjadi T
                    ' langsungposting = T, artinya langsung dipostingkan pointya
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 

                    langsungposting = "F"
                    If langsungposting = "T" Then ' bila langsungposting di setting T, maka point langsung dipostingkan
                        muterku = 200000

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ' START HERE FOR LOOPING UPLINE PVGRUP UPDATE
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        jammulai = Now()
                        kedua = sapa
                        For aaxds = 1 To muterku

                            rs.Open "SELECT * FROM mylevel WHERE kta LIKE '" & kedua&"'", conn
            If rs.bof Then
                                rs.close
                                muterku = muterku + 10
                                Exit For
                            Else
                                If rs("ktaloc") = "A" Then
                                    muterku = muterku + 10
                                    rs.close
                                    ent = "F"
                                    Exit For
                                Else
                                    upnya = rs("ktaloc")
                                    posef = UCase(rs("posloc"))
                                    kedua = rs("ktaloc")

                                    staluup = UCase(rs("sta"))

                                    opoupnye = Right(upnya, 2)
                                    If (opoupnye = "-2" Or opoupnye = "-3") Or (staluup = "F") Then
                                        uplu = "F"
                                        okelahklo = "T" ' biar bisa di recover setiap saat bila ada yang kelewat kena suspend
                                    Else
                                        uplu = "T"
                                        okelahklo = "T"
                                    End If

                                    If uplu = "T" Then
                                        rsALL.Open "SELECT * FROM bns_mypv_current WHERE ((kta LIKE '" & upnya&"') and (bulan='"&wulan&"' and tahun = '"&nahun&"'))", connALL, 3, 3
                            If rsALL.bof Then
                                            rsALL.addnew
                                            rsALL("kta") = upnya
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
                                                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia	

                                                strSQLG = "UPDATE bns_mypv_current SET pvgrupkiri = '" & kiri&"',pvfull_kiri = '"&kirifull&"' WHERE (((bulan = "&wulan&") and (tahun = "&nahun&")) and (kta like '"&upnya&"'))"

                                                        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                                'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                            Else
                                                If posef = "R" Then
                                                    kanan = rsALL("pvgrupkanan") + jume
                                                    kananfull = rsALL("pvfull_kanan") + pvfull
                                                    Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                                    'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia						

                                                    strSQLG = "UPDATE bns_mypv_current SET pvgrupkanan = '" & kanan&"',pvfull_kanan = '"&kananfull&"' WHERE (((bulan = "&wulan&") and (tahun = "&nahun&")) and (kta like '"&upnya&"'))"

                                                            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                                    intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                                End If
                                            End If
                                        End If
                                        rsALL.close
                                    End If

                                    If okelahklo = "T" And opoupnye <> "-2" And opoupnye <> "-3" Then
                                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia			

                                        strSQLG = "INSERT INTO temp_all_trans (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull) VALUES ('" & mypos&"',"&wulan&","&nahun&",'"&sapa&"','"&upnya&"',"&jume&",'"&posef&"','TOPUP','B','"&noinvo&"','PRODUK','T',0,0,0,"&pvfull&")"

                                            End If
                                End If
                            End If
                            rs.close

                            aaxds = aaxds + 1
                            If aaxds > muterku Then
                                Exit For
                            End If
                        Next
                        'rs.close 
                        If langsungposting = "T" Then ' bila langsungposting di setting T, maka point langsung dipostingkan
                            keo = "S"
                            oek = "T"

                            strSQLG = "UPDATE temp_belum SET hendel = '"&oek&"',sta = '"&keo&"' WHERE bulan = "&wulan&" and tahun = "&nahun&" and nopos like '"&mypos&"' and noinvo like '"&noinvo&"'"

                                End If
                    Else

                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia			

                        strSQLG = "INSERT INTO temp_putus (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull) VALUES ('" & mypos&"',"&wulan&","&nahun&",'"&sapa&"','"&sapa&"',"&jume&",'"&posef&"','TOPUP','B','"&noinvo&"','PRODUK','T',0,0,0,"&pvfull&")"

                            End If

                    postingup = jume
                    Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                    'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' AUTO UPGRADE 3 BC JIKA BELANJA AKUMULASI MENCAPAI 400 PV PER BULAN
                    ' MAKSIMAL 3 BULAN SEJAK JOINDTAE
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    tgval1 = "1"
                    tgval2 = "3"
                    tgval3 = "2010"
                    belonjone = 0
                    belonjone2 = 0
                    pak = "T"
                    tgvale = CDate(CStr(tgval1) + "/" + CStr(tgval2) + "/" + CStr(tgval3) + " " + "00:00:00")
                    If tglgabungnya <= tgvale Then
                        tglgabungnya = tgvale
                    Else
                        tglgabungnya = tglgabungnya
                    End If

                    If Now() >= tgvale And piyeup = "R" Then
                        lamajoin = DateDiff("d", tglgabungnya, Now())
                        'if lamajoin <= 90 and piyeup="R" then
                        If piyeup = "R" Then
                            rs.Open "SELECT sum(totpv) FROM st_sale_prd_head where nodist like '" & noid&"' AND (alokbulan='"&wulan&"' and aloktahun='"&nahun&"')", conn
                    If rs.bof Then
                                belonjone = 0
                            Else
                                belonjone = rs("sum(totpv)")
                            End If
                            rs.close
                            If isnull(belonjone) = False Then
                                belonjone = belonjone
                            Else
                                belonjone = 0
                            End If

                            rs.Open "SELECT sum(pv) FROM st_sale_daftar where noseri like '" & noid&"' AND (alokbulan='"&wulan&"' and aloktahun='"&nahun&"') and pakai like '"&pak&"'", conn
                    If rs.bof Then
                                belonjone2 = 0
                            Else
                                belonjone2 = rs("sum(pv)")
                            End If
                            rs.close
                            If isnull(belonjone2) = False Then
                                belonjone2 = belonjone2
                            Else
                                belonjone2 = 0
                            End If

                            If (belonjone + belonjone2) >= 400 Then
                                ugd = "F"
                                tpk = "P"
                                noid1 = CStr(noid) + "-2"
                                noid2 = CStr(noid) + "-3"

                                strSQLG = "UPDATE member SET tipene_kartu='" & tpk&"',tipene='"&tpk&"'  WHERE kta like '"&noid&"'"

                                        rs.Open "SELECT * FROM autoupgrade where kta like '" & noid&"'", conn, 3, 3
                        If rs.bof Then
                                    rs.addnew
                                    rs("kta") = noid
                                    rs("tgl") = Now()
                                    rs("noinvo") = noinvo
                                    rs.update
                                Else
                                End If
                                rs.close
                            End If
                        End If
                    End If

                    Session("nosesi") = ""
                    Session("noinvoice") = noinvo
                    Session("mypus") = mypos
                    Response.Redirect("sale_prd_dist_inv.aspx?menu_id=" & menu_id)


                Else
                    '<table border = "0" cellpadding="0" cellspacing="0" width="100%">
                    '	<tr>
                    '		<td>
                    '		<p align = "center" >
                    '        <img border="0" src="../images/health-wealthlogo.jpg" width="186" height="125"></td>
                    '                                        	</tr>
                    '	<tr>
                    '		<td>&nbsp;
                    '		</td>
                    '	</tr>
                    '	<tr>
                    '		<td>
                    '		<p align = "center" <> font face="Verdana">Maaf saat ini transaksi anda 
                    '		tidak dapat dilakukan karena sudah memasuki <font color="#FF0000"><b>closing 
                    '        period</b></font><br>
                    '		Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup 
                    '        point bulanan < br >
                    '        maka silahkan hubungi kantor pusat sesegera mungkin.<br>
                    '        Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian 
                    '        anda.<br>
                    '                                        		&lt;-- <a href="mc_prd_topup.asp?menu_id=<%=session("menu_id")%>">Kembali</a> 
                    '		--&gt;</font>
                    '		<br>
                    '		<%= lanjutken% <> br >
                    '                    <%= lanjutposting% >

                    '		</td>
                    '	</tr>
                    '</table>
                End If 'akhir lanjutposting
            End If 'akhir lanjut dodol
        End If 'akhir lanjut dodol
    End Sub
End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_prd_dist_ck
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

    Dim menu_id, pos_area, mypos, loguser, nosesi, kelasdc, indukdc, indukmc, namatabel, namatabel2, noinvoice As String
    Dim hariakhir, skritu As Date

    Dim lanjutkena, noid, lanjutke As String
    Dim dino, dinoe, tgl As Date
    Dim jumtot, tunai, debit, kkredit, bgcek, duite, bulanskr, jumtotnet, jumdisk, tipepos As Double
    Dim wulan, wulpos, nahun, nuhun As Integer

    Dim tglgabungnya As Date
    Dim belonjone, sisakembalian As Double
    Dim piyeup, l1, namadist, l5, pak As String

    Dim kepiro, jume, jumlahalokakt, juma, jume1, juma1, levnya, tahunskr As Integer
    Dim lanjutdodol1, lanjutdodol2, lanjutdodol3, lanjutdodol4, lanjutdodol5, lanjutdodol6, lanjutdodol7, nokode, ggg, ggg1, ggg2, kode1, namabr, mesej1, namabr1, nokode1 As String
    Dim jumlah1, jumakt, jumpaket, tambahanpv As Double
    Dim mesej, mesej2, namabr2, nokode2, mesej3, namabr3, nokode3, mesej4, namabr4, nokode4, mesej5, namabr5, nokode5, mesej6, namabr6, nokode6, mesej7, namabr7, nokode7 As String
    Dim jume2, juma2, jume3, juma3, jume4, juma4, jume5, juma5, jume6, juma6, jume7, juma7 As Integer
    Dim lanjutposting, kdd1, kdd2, modepost As String
    Dim skr, tutup1, tutup2 As Date
    Dim nilaipv, nilaibv, postingup, produp, pvnya, bvnya, subtotnya, nilaipv1, nilaipv2, nilaipv3, pvfull, pvreg, produpkurang, pvnow, pvnow2, pvnow3, prodada, tambahan, producti, sisa, totalprodup As Double
    Dim pvne, bvne, hargane, namabrg, subtote, entuk, mutermaneh, jumakhir, awal, sisastok, aaxdx As Double
    Dim urut As Long

    Dim belonjone2, lamajoin As Integer
    Dim tgval1, tgval2, tgval3, ugd, tpk, noid1, noid2 As String
    Dim tgvale As Date

    Dim noakhir, bulsks, jk, tahskr, nopajak As Integer
    Dim tamb, blne, taun, nipe, noinvo, kel, masterdc, k1, k2, nourutpjk As String

    Dim noinvonye, idygdapat, sapa, lanjut, kedua As String
    Dim proddepo, pvdepo, prodreg, pvku, pvprod, jummurni, piro, pvpri As Double

    Dim langsungposting, ent, upnya, posef, staluup, opoupnye, uplu, okelahklo, keo, oek As String
    Dim muterku As Integer
    Dim jammulai As Date
    Dim kiri, kirifull, kanan, kananfull As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")


        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        nosesi = Session("nosesi")
        Session("nosesi") = nosesi
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        indukmc = Session.Contents("indukmc")
        If nosesi = "" Then
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        End If

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

        skritu = Now()

        namatabel = "st_barang_ms"
        namatabel2 = "st_kartustock_ms"

        CekValidSession()
        CariProdukPerPointReward()
        CekStockAktual()
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

        mlSQL = "SELECT * FROM st_sale_prd_det_tmp where nosesi like '" & nosesi & "' and nopos like '" & mypos & "' and kode like 'MS200%'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            Session("errorpos") = "Penjualan MS UPGRADE hanya bisa dilakukan dari menu UPGRADE MS"
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        End If
        mlREADER.Close()

        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        tgl = Request("tgl")
        noid = Trim(Request("kdpos"))
        jumtot = Trim(Request("jumtot"))
        tunai = Trim(Request("jumbayarcash"))
        debit = Trim(Request("jumbayardb"))
        kkredit = Trim(Request("jumbayarcc"))
        bgcek = Trim(Request("jumbayarcek"))
        duite = Trim(Request("jumbayar"))
        bulanskr = CInt(Month(dino))
        jumtotnet = Trim(Request("jumtotnet"))
        jumdisk = Trim(Request("jumdisk"))
        tipepos = Trim(Request("tipe_post"))

        wulan = wulpos
        nahun = nuhun
        lanjutke = "T"
    End Sub

    Sub CariProdukPerPointReward()
        ''''''''''''''''''''''''''''''''
        ' cari produk ber point reward
        ''''''''''''''''''''''''''''''''
        'kdse = "PTU"
        'pred = 0
        'rs.Open "SELECT count(id) FROM st_sale_prd_det_tmp where nosesi like '"&nosesi&"' and nopos like '"&mypos&"' and ucase(kode) like '"&kdse&"'",conn	
        '	if rs.bof then
        '		pred = 0
        '	else
        '		pred = 1
        '	end if
        'rs.Close

        belonjone = 0
        piyeup = "R"
        If tipepos = "" Then
            Session("errorpos") = "Anda belum memilih tipe posting point (normal atau full quadroplan)"
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        Else
            tipepos = CInt(tipepos)
            If tipepos <> 1 And tipepos <> 2 Then
                Session("errorpos") = "Anda belum memilih tipe posting point (normal atau full quadroplan)"
                Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
            End If
        End If

        If tgl = "" Then
            Session("errorpos") = "Invalid Tanggal Transaski"
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
            If tgl < dinoe Then
                Session("errorpos") = "Invalid Tanggal Transaski"
                Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
            End If
        End If

        If noid = "" Then

            l1 = "Mbuh"
            Session("errorpos") = "Nomor id. distributor belum diisi"
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        Else
            If Len(noid) >= 16 Then
                Session("errorpos") = "Nomor id. distributor belum diisi"
                l1 = "Mbuh"
                Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
            Else
                If ((Len(noid) <= 16) And (noid <> "")) Then
                    mlSQL = "SELECT kta,uid,sta,joindt,upme,tipene_kartu FROM member where kta like '" & noid & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorpos") = "Nomor id. distributor tidak ditemukan"
                        l1 = "Mbuh"
                        Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
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
                            Session("errorpos") = "Nomor id. distributor dalam status SUSPEND. Silahkan batalkan transaksi ini dan hubungi kantor pusat"
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
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(jumtotnet) = False Then
                l1 = "Mbuh"
                Session("errorpos") = "Anda belum berbelanja"
                Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
            Else
                If ((jumtotnet <> "") And (IsNumeric(jumtotnet) = True)) Then
                    If jumtotnet < 0 Then
                        l1 = "Mbuh"
                        Session("errorpos") = "Anda belum berbelanja"
                        Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
                    Else
                        jumtotnet = jumtotnet
                    End If
                End If
            End If
        End If

        If jumtot = "" Then
            l1 = "Mbuh"
            Session("errorpos") = "Anda belum berbelanja"
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(jumtot) = False Then
                l1 = "Mbuh"
                Session("errorpos") = "Anda belum berbelanja"
                Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
            Else
                If ((jumtot <> "") And (IsNumeric(jumtot) = True)) Then
                    If jumtot < 0 Then
                        l1 = "Mbuh"
                        Session("errorpos") = "Anda belum berbelanja"
                        Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
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
            Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        End If

        If duite = "" Then
            l5 = "Mbuh"
            Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(duite) = False Then
                l5 = "Mbuh"
                Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
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
                            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
                        End If
                    Else
                        Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                        Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If
    End Sub

    Sub CekStockAktual()
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
                    mlDATATABLE2.Load(mlREADER)
                    For aaaeqSSSK = 1 To mlDATATABLE2.Rows.Count - 1
                        kode1 = mlDATATABLE2.Rows(aaaeqSSS)("kode")
                        jumlah1 = mlDATATABLE2.Rows(aaaeqSSS)("jumlah")

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
                    Else
                        If kepiro = 2 Then
                            lanjutdodol2 = "F"
                        Else
                            If kepiro = 3 Then
                                lanjutdodol3 = "F"
                            Else
                                If kepiro = 4 Then
                                    lanjutdodol4 = "F"
                                Else
                                    If kepiro = 5 Then
                                        lanjutdodol5 = "F"
                                    Else
                                        If kepiro = 6 Then
                                            lanjutdodol6 = "F"
                                        Else
                                            If kepiro = 7 Then
                                                lanjutdodol7 = "F"
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
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

        Dim str_Lanjutan As String = ""
        If lanjutdodol1 = "F" Or lanjutdodol2 = "F" Or lanjutdodol3 = "F" Or lanjutdodol4 = "F" Or lanjutdodol5 = "F" Or lanjutdodol6 = "F" Or lanjutdodol7 = "F" Then
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
           

            str_Lanjutan += "&lt;-- <a href='sale_prd_dist.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a>  --&gt;" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "</section>" & vbCrLf

            Div_sale_ck.InnerHtml = str_Lanjutan
        Else
            If lanjutdodol1 = "T" And lanjutdodol2 = "T" And lanjutdodol3 = "T" And lanjutdodol4 = "T" And lanjutdodol5 = "T" And lanjutdodol6 = "T" And lanjutdodol7 = "T" Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ' CEK VALID SESSION
                ' CLOSE SESSION INPUT HANYA BISA DILAKUKAN MELALUI KANTOR PUSAT
                ' CLOSE SESSION TIAP AKHIR BULAN PADA TANGGAL 30/31 JAM 19:00:00 WIB
                ' BILA ADA TRANSAKSI PADA TANGGAL 30/31 LEWAT CLOSING TIME, MAKA DITOLAK DAN DIMINTA UNTUK MENGHUBUNGI KANTOR PUSAT
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lanjutposting = "F"
                skr = Now()
                If tutup1 < skr And tutup2 > skr Then
                    lanjutposting = "F"
                Else
                    lanjutposting = "T"
                End If

                If lanjutposting = "T" Then
                    dino = Now()

                    ''''''''''''''''''''''''''''''''''''''''''''
                    ' PROMO EXTRA PV UNTUK PEMBELIAN MU DAN PG
                    ' 1 MU / PG  = FREE XTRA PV 10 PV
                    ' KHUSUS BULAN 11 DAN 12 2010
                    ''''''''''''''''''''''''''''''''''''''''''''
                    If ((wulan = 11 And nahun = 2010) Or (wulan = 12 And nahun = 2010)) Then
                        kdd1 = "MU"
                        kdd2 = "PG"
                        tambahanpv = 0
                        mlSQL = "SELECT sum(jumlah) FROM st_sale_prd_det_tmp where nopos like '" & mypos & "' and nosesi like '" & nosesi & "' and (kode like '" & kdd1 & "' or kode like '" & kdd2 & "')"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            tambahanpv = 0
                        Else
                            tambahanpv = mlREADER("sum(jumlah)")
                        End If
                        mlREADER.Close()
                    Else
                        tambahanpv = 0
                    End If
                    If IsDBNull(tambahanpv) = False Then
                        tambahanpv = tambahanpv * 10
                    Else
                        tambahanpv = 0
                    End If

                    mlSQL = "SELECT * FROM st_sale_prd_head_tmp where nopos like '" & mypos & "' and nosesi like '" & nosesi & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        pvnya = 0
                        bvnya = 0
                        subtotnya = 0
                    Else
                        pvnya = mlREADER("totpv") + tambahanpv
                        bvnya = mlREADER("totbv") + tambahanpv
                        subtotnya = mlREADER("subtot")
                    End If
                    mlREADER.Close()

                    nilaipv1 = 0
                    nilaipv2 = 0
                    nilaipv3 = 0
                    nilaipv = 0
                    produp = 0
                    postingup = 0
                    pvfull = pvnya

                    If tipepos = 1 Or tipepos = "1" And pvnya > 0 Then ' posting normal apa adanya (productivity bonus berlaku)
                        modepost = "N"
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
                            '	rsALL.Open "SELECT sum(pvpri) FROM st_sale_daftar where ((noseri like '"&noid&"') and (alokbulan = '"&wulan&"') and (aloktahun = '"&nahun&"'))",connALL
                            '		if rsALL.bof then
                            pvreg = 0
                            '		else
                            '			pvreg = rsALL("sum(pvpri)")
                            '		end if		
                            '	rsALL.close
                            '	if isnull(pvreg) = false then
                            '		pvreg = clng(pvreg)
                            '	else
                            '		pvreg = 0
                            '	end if

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

                        mlSQL = "SELECT produp FROM bns_mypv_current where ((kta like '" & noid & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            producti = 0
                        Else
                            producti = mlREADER("produp")
                        End If
                        mlREADER.Close()

                        totalprodup = producti + produp
                        If totalprodup > 1075 Then
                            sisa = 1075 - producti
                            produp = sisa
                            postingup = pvfull - produp
                        End If


                    Else ' bila tipe posting full quadroplan
                        modepost = "Q"
                        nilaipv = pvnya
                        nilaibv = 0
                        produp = 0
                        postingup = pvnya
                    End If



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

                    BikinNomerInvoicePajak()
                    UpdatePVUpline()
                    BuatNomerUndian()
                    UpdateTableTemporary()



                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' AUTO UPGRADE 3 BC JIKA BELANJA AKUMULASI MENCAPAI 400 PV PER BULAN
                    ' MAKSIMAL 3 BULAN SEJAK JOINDTAE
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


                    belonjone = 0
                    belonjone2 = 0
                    tgval1 = "1"
                    tgval2 = "3"
                    tgval3 = "2010"
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
                            mlSQL = "SELECT sum(totpv) FROM st_sale_prd_head where nodist like '" & noid & "' AND (alokbulan='" & wulan & "' and aloktahun='" & nahun & "')"
                            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                            mlREADER.Read()
                            If Not mlREADER.HasRows Then
                                belonjone = 0
                            Else
                                belonjone = mlREADER("sum(totpv)")
                            End If
                            mlREADER.Close()

                            If IsDBNull(belonjone) = False Then
                                belonjone = belonjone
                            Else
                                belonjone = 0
                            End If

                            pak = "T"
                            mlSQL = "SELECT sum(pv) FROM st_sale_daftar where noseri like '" & noid & "' AND (alokbulan='" & wulan & "' and aloktahun='" & nahun & "') and pakai like '" & pak & "'"
                            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                            mlREADER.Read()
                            If Not mlREADER.HasRows Then
                                belonjone2 = 0
                            Else
                                belonjone2 = mlREADER("sum(pv)")
                            End If
                            mlREADER.Close()

                            If IsDBNull(belonjone2) = False Then
                                belonjone2 = belonjone2
                            Else
                                belonjone2 = 0
                            End If

                            If (belonjone + belonjone2) >= 400 Then
                                ugd = "F"
                                tpk = "P"
                                noid1 = CStr(noid) + "-2"
                                noid2 = CStr(noid) + "-3"

                                mlSQL = "UPDATE member SET tipene_kartu='" & tpk & "',tipene='" & tpk & "'  WHERE kta like '" & noid & "'"
                                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                                mlSQL = "SELECT * FROM autoupgrade where kta like '" & noid & "'"
                                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                                mlREADER.Read()
                                If Not mlREADER.HasRows Then
                                    mlSQL2 = "insert into autoupgrade(kta,tgl,noinvo)values('" & noid & "','" & Now & "','" & noinvo & "')"
                                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                                End If
                                mlREADER.Close()
                            End If
                        End If
                    End If


                    Session("nosesi") = ""
                    Session("noinvoice") = noinvo
                    Session("mypus") = mypos
                    Session("autoupe") = "T"
                    Response.Redirect("sale_prd_dist_inv.aspx?menu_id=" & menu_id)


                Else
                    Dim Str_Lanjut2 As String = ""

                    Str_Lanjut2 += "<section Class='content'>" & vbCrLf
                    Str_Lanjut2 += "<div Class='box'>" & vbCrLf
                    Str_Lanjut2 += "<div Class='box-header with-border'>" & vbCrLf
                    Str_Lanjut2 += "<h3 Class='box-title'></h3>" & vbCrLf
                    Str_Lanjut2 += "<div Class='box-tools pull-right'>" & vbCrLf
                    Str_Lanjut2 += "<Button type = 'button' Class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
                    Str_Lanjut2 += "<i Class='fa fa-minus'></i></button>" & vbCrLf
                    Str_Lanjut2 += "<Button type = 'button' Class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
                    Str_Lanjut2 += "<i Class='fa fa-times'></i></button>" & vbCrLf
                    Str_Lanjut2 += "</div>" & vbCrLf
                    Str_Lanjut2 += "</div>" & vbCrLf
                    Str_Lanjut2 += "<div Class='box-body'>" & vbCrLf
                    Str_Lanjut2 += "<p align = 'center' >" & vbCrLf
                    Str_Lanjut2 += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
                    Str_Lanjut2 += "<br/>" & vbCrLf
                    Str_Lanjut2 += "<br/>" & vbCrLf
                    Str_Lanjut2 += "<p align='center'>" & vbCrLf
                    Str_Lanjut2 += "Maaf saat ini transaksi anda tidak dapat dilakukan karena sudah memasuki <font color='#FF0000'><b>closing  period</b></font><br/>" & vbCrLf
                    Str_Lanjut2 += "Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup point bulanan<br/>" & vbCrLf
                    Str_Lanjut2 += "maka silahkan hubungi kantor pusat sesegera mungkin.<br/>" & vbCrLf
                    Str_Lanjut2 += "Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian anda.<br/>" & vbCrLf
                    Str_Lanjut2 += "&lt;-- <a href='sale_prd_dist.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a> --&gt;" & vbCrLf
                    Str_Lanjut2 += "</div>" & vbCrLf
                    Str_Lanjut2 += "</div>" & vbCrLf
                    Str_Lanjut2 += "</section>" & vbCrLf

                    Div_sale_ck2.InnerHtml = Str_Lanjut2
                End If 'akhir lanjutposting
            End If 'akhir lanjut dodol
        End If 'akhir lanjut dodol
    End Sub

    Sub BikinNomerInvoicePajak()

        ''''''''''''''''''''''''''''''
        ' bikin nomor invoice pajak
        ''''''''''''''''''''''''''''''
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

        mlSQL = "insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values('" & nopajak & "','" & mypos & "','" & noinvo & "','" & skr & "','PRD','RET','" & indukdc & "','" & nourutpjk & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)


        mlSQL = "SELECT * FROM st_sale_prd_head where nosesi like '" & nosesi & "' and nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into st_sale_prd_head(postingup,produp,nopos,nosesi,urut,noinvoice,nopajak,kta,tgl,totpv,totbv,subtot,diskon,totbruto,nodist,namadist,tunai,debit,cc,cek,jumbayar,kembalian,suratjalan,alokbulan,tipe,dcinduk,modepost)" & vbCrLf
            mlSQL2 += "values('" & postingup & "','" & produp & "','" & mypos & "','" & nosesi & "','" & noakhir & "','" & noinvo & "','" & nourutpjk & "','" & loguser & "','" & dino & "','" & pvnya & "','" & bvnya & "'" & vbCrLf
            mlSQL2 += ",'" & jumtot & "','" & jumdisk & "','" & subtotnya & "','" & noid & "','" & namadist & "','" & tunai & "','" & debit & "','" & kkredit & "','" & bgcek & "','" & duite & "','" & duite - subtotnya & "'" & vbCrLf
            mlSQL2 += ",'-','" & wulan & "','" & nahun & "','BELANJA','" & indukdc & "','" & modepost & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
    End Sub

    Sub UpdatePVUpline()
        '''''''''''''''''''''''''''''''''''''''''
        ' REPLACE SATU PERSATU KE TABLE REAL
        ' POTONG STOCK
        ' UPDATE PV UPLINE
        '''''''''''''''''''''''''''''''''''''''''
        mlSQL = "SELECT * FROM st_sale_prd_det_tmp where nosesi Like '" & nosesi & "' and nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlDATATABLE = New DataTable
            mlDATATABLE.Load(mlREADER)

            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                nokode = mlDATATABLE.Rows(aaaeqSSS)("kode")
                jume = mlDATATABLE.Rows(aaaeqSSS)("jumlah")
                pvne = mlDATATABLE.Rows(aaaeqSSS)("pv")
                bvne = mlDATATABLE.Rows(aaaeqSSS)("bv")
                hargane = mlDATATABLE.Rows(aaaeqSSS)("harga")
                namabrg = mlDATATABLE.Rows(aaaeqSSS)("nama")
                subtote = mlDATATABLE.Rows(aaaeqSSS)("subtot")
                entuk = 0

                If ((wulan >= 4 And wulan <= 8) And nahun = 2013) Then

                    If nokode = "PRQQGPB" Then
                        mutermaneh = jume * 2
                        For aaxdz = 1 To mutermaneh
                            mlSQL2 = "SELECT TOP 1 * FROM promo_qq13 order by urut desc"
                            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Read()
                            If Not mlREADER2.HasRows Then
                                mlSQL3 = "insert into promo_qq13(no_undian,urut,kta,noinvoice,tgl,dc)values('100001','1','" & noid & "','" & noinvo & "', ,'" & Now & "','" & mypos & "')"
                            Else
                                urut = CLng(mlREADER3("urut")) + 1
                                mlSQL3 = "insert into promo_qq13(urut,no_undian,kta,noinvoice,tgl,dc)values('" & urut & "','" & urut + 100000 & "','" & noid & "','" & noinvo & "', ,'" & Now & "','" & mypos & "')"
                            End If
                            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Close()

                            aaxdz = aaxdz + 1
                            If aaxdz >= mutermaneh And aaxdx >= entuk Then
                                Exit For
                            End If
                        Next
                        entuk = entuk + 1
                    End If
                End If

                mlSQL2 = "SELECT * FROM " & namatabel & " where kode like '" & nokode & "' and nopos like '" & mypos & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    jumakhir = 0
                Else
                    jumakhir = mlREADER2("jumlah")

                    mlSQL3 = "update " & namatabel & " set jumlah = '" & mlREADER2("jumlah") - jume & "' where kode like '" & nokode & "' and nopos like '" & mypos & "'"
                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER2.Close()

                If jumakhir <= 0 Then
                    jumakhir = jume
                Else
                    jumakhir = jumakhir
                End If

                mlSQL2 = "insert into st_sale_prd_det(nopos,kta,nosesi,kode,nama,jumlah,harga,pv,bv,subtot,noinvoice,tgl,dcinduk,nopajak,alokbulan,aloktahun,namadist)values('" & mypos & "','" & noid & "','" & nosesi & "'" & vbCrLf
                mlSQL2 += ",'" & nokode & "','" & namabrg & "','" & jume & "','" & hargane & "','" & pvne & "','" & bvne & "','" & subtote & "','" & noinvo & "','" & dino & "','" & indukdc & "','" & nourutpjk & "','" & wulan & "'" & vbCrLf
                mlSQL2 += ",'" & nahun & "','" & namadist & "')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                mlSQL2 = "SELECT TOP 3 * FROM " & namatabel2 & " where kode like '" & nokode & "' and nopos like '" & mypos & "' order by tgl desc, id desc"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    mlSQL3 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & nokode & "','" & mypos & "','" & dino & "',0,0,'" & jume & "','" & 0 - jume & "'" & vbCrLf
                    mlSQL3 += ",'" & noinvo & "','Penjualan Produk')"
                Else
                    awal = mlREADER2("akhir")
                    sisastok = awal - jume
                    'if sisastok < 0 then
                    '	sisastok = 0
                    'else
                    '	sisastok = sisastok
                    'end if
                    mlSQL3 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & nokode & "','" & mypos & "','" & dino & "','" & awal & "',0,'" & jume & "','" & sisastok & "'" & vbCrLf
                    mlSQL3 += ",'" & noinvo & "','Penjualan Produk')"
                End If
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                mlREADER2.Close()
            Next
        End If
        mlREADER.Close()
    End Sub

    Sub BuatNomerUndian()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' BIKIN NOMOR UNDIAN UNTUK PRODUK CMP, CMP8, CPO dan TG2
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        noinvonye = noinvo
        idygdapat = noid
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' UPDATE PV PRIBADI
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        sapa = noid
        jume = postingup
        bvne = 0
        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' PV DEPOSIT RELEASE BERASAL DARI BNS_DEPOSITDANA YANG DIRELEASE PADA SAAT CLOSING PERIODE
        ' KEDALAM TABLE BNS_DEPOSITRELEASE SESUAI SPLIT POINT YANG BERLAKU KUALIFIKASINYA
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        proddepo = 0
        pvdepo = 0
        mlSQL = "SELECT * FROM bns_depositrelease where ((kta Like '" & sapa & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
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
        pvku = 0
        pvreg = 0
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

        mlSQL = "SELECT sum(produp),sum(postingup) FROM st_sale_prd_head where ((nodist like '" & sapa & "') and (alokbulan = '" & wulan & "') and (aloktahun = '" & nahun & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            pvprod = produp
            pvku = 0
        Else
            pvprod = mlREADER("sum(produp)")
            pvku = mlREADER("sum(postingup)")
        End If
        mlREADER.Close()

        If IsDBNull(pvprod) = False Then
            pvprod = pvprod + prodreg + proddepo
        Else
            pvprod = produp + prodreg + proddepo
        End If

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
            pvku = pvku + pvreg + pvdepo
        Else
            pvku = 0 + pvreg + pvdepo
        End If

        lanjut = "F"

        mlSQL = "SELECT * FROM bns_mypv_current where ((kta like '" & sapa & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into bns_mypv_current(kta,bulan,tahun,pvpribadi,produp,pvmurni,pvgrupkiri,pvgrupkanan)values('" & sapa & "','" & wulan & "','" & nahun & "'" & vbCrLf
            mlSQL2 += ",'" & pvku & "','" & pvprod & "','" & pvku + pvprod & "',0,0)"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            lanjut = "F"
            jummurni = 0
        Else
            lanjut = "T"
            jummurni = pvku + pvprod
        End If
        mlREADER.Close()

        pvpri = pvku
        If IsDBNull(jummurni) Then
            jummurni = pvku + pvprod
        Else
            jummurni = jummurni
        End If

        If lanjut = "T" Then
            mlSQL = "UPDATE bns_mypv_current SET produp = '" & pvprod & "', pvpribadi= '" & pvpri & "', pvmurni= '" & jummurni & "' WHERE (((bulan = " & wulan & ") and (tahun = " & nahun & ")) and (kta like '" & sapa & "'))"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If

        piro = 0
        kedua = sapa
    End Sub

    Sub UpdateTableTemporary()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' update table temporary untuk dieksekusi waktu muncul invoice
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        mlSQL = "insert into temp_belum(nopos,noinvo,bulan,tahun,kta,postingup,pred,nambahkiri,nambahkanan,sta,asal,tipe,tgl,hendel,pvfull)values('" & mypos & "','" & noinvo & "','" & wulan & "'" & vbCrLf
        mlSQL += ",'" & nahun & "','" & sapa & "','" & jume & "',0,0,0,'B','BELANJA','PRODUK','" & dino & "','F','" & pvfull & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 
        ' bila diperlukan karena proses querry banyak dan membuat proses lemot, maka
        ' ubah langsungposting menjadi F
        ' langsungposting = F, artinya tidak langsung dipostingkan pointya
        ' point dipostingkan melalui script processing/postingpv.asp yang harus dirunning schedulle
        ' 
        ' ubah langsungposting menjadi T
        ' langsungposting = T, artinya langsung dipostingkan pointya
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 

        langsungposting = "T"

        If langsungposting = "T" Then ' bila langsungposting di setting T, maka point langsung dipostingkan
            muterku = 200000
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' START HERE FOR LOOPING UPLINE PVGRUP UPDATE
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            jammulai = Now()
            kedua = sapa
            For aaxds = 1 To muterku
                mlSQL = "SELECT * FROM mylevel WHERE kta Like '" & kedua & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    muterku = muterku + 10
                    Exit For
                Else
                    If mlREADER("ktaloc") = "A" Then
                        muterku = muterku + 10
                        ent = "F"
                        Exit For
                    Else
                        upnya = mlREADER("ktaloc")
                        posef = UCase(mlREADER("posloc"))
                        kedua = mlREADER("ktaloc")

                        staluup = UCase(mlREADER("sta"))

                        opoupnye = Right(upnya, 2)
                        If (opoupnye = "-2" Or opoupnye = "-3") Or (staluup = "F") Then
                            uplu = "F"
                            okelahklo = "T" ' biar bisa di recover setiap saat bila ada yang kelewat kena suspend
                        Else
                            uplu = "T"
                            okelahklo = "T"
                        End If

                        If uplu = "T" Then
                            mlSQL2 = "SELECT * FROM bns_mypv_current WHERE ((kta LIKE '" & upnya & "') and (bulan='" & wulan & "' and tahun = '" & nahun & "'))"
                            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Read()
                            Dim pvgrupkiri, pvgrupkanan As Integer
                            Dim pvfull_kiri, pvfull_kanan As Double
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
                                mlSQL3 = "insert into bns_mypv_current(kta,bulan,tahun,pvpribadi,produp,pvmurni,pvgrupkiri,pvgrupkanan,pvfull_kiri,pvfull_kanan)" & vbCrLf
                                mlSQL3 += "values('" & upnya & "','" & wulan & "','" & nahun & "',0,0,0,'" & pvgrupkiri & "','" & pvgrupkanan & "','" & pvfull_kiri & "','" & pvfull_kanan & "')"
                                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                            Else
                                If posef = "L" Then
                                    kiri = mlREADER2("pvgrupkiri") + jume
                                    kirifull = mlREADER2("pvfull_kiri") + pvfull
                                    Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                    'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia	
                                    mlSQL3 = "UPDATE bns_mypv_current SET pvgrupkiri = '" & kiri & "',pvfull_kiri = '" & kirifull & "' WHERE (((bulan = " & wulan & ") and (tahun = " & nahun & ")) and (kta like '" & upnya & "'))"
                                    Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                    'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                Else
                                    If posef = "R" Then
                                        kanan = mlREADER2("pvgrupkanan") + jume
                                        kananfull = mlREADER2("pvfull_kanan") + pvfull
                                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia						
                                        mlSQL3 = "UPDATE bns_mypv_current SET pvgrupkanan = '" & kanan & "',pvfull_kanan = '" & kananfull & "' WHERE (((bulan = " & wulan & ") and (tahun = " & nahun & ")) and (kta like '" & upnya & "'))"
                                        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                    End If
                                End If
                            End If
                            mlREADER2.Close()
                        End If

                        If okelahklo = "T" And opoupnye <> "-2" And opoupnye <> "-3" Then
                            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia					
                            mlSQL2 = "INSERT INTO temp_all_trans (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull)" & vbCrLf
                            mlSQL2 += "VALUES('" & mypos & "'," & wulan & "," & nahun & ",'" & sapa & "','" & upnya & "'," & jume & ",'" & posef & "','BELANJA','B','" & noinvo & "','PRODUK','T',0,0,0," & pvfull & ")"
                            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                        End If
                    End If
                End If
                mlREADER.Close()
            Next
            'rs.close 
            If langsungposting = "T" Then ' bila langsungposting di setting T, maka point langsung dipostingkan
                keo = "S"
                oek = "T"

                mlSQL = "UPDATE temp_belum SET hendel = '" & oek & "',sta = '" & keo & "' WHERE bulan = " & wulan & " and tahun = " & nahun & " and nopos like '" & mypos & "' and noinvo like '" & noinvo & "'"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
            End If
        Else
            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								
            mlSQL = "INSERT INTO temp_putus (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull)" & vbCrLf
            mlSQL += "VALUES('" & mypos & "'," & wulan & "," & nahun & ",'" & sapa & "','" & sapa & "'," & jume & ",'" & posef & "','BELANJA','B','" & noinvo & "','PRODUK','T',0,0,0," & pvfull & ")"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
        End If
    End Sub

End Class

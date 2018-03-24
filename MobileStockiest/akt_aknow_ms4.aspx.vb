Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_akt_aknow_ms4
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlFUNCT As FunctionHWI
    Dim mlREADER, mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mlDATATABLE As DataTable
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim dino, skr, lahirnya, tglaktif, tglnyaaa, expirednya, tglku, tglbayar As Date

    Dim bulanfee, tahunfee, x, jumbc, muter, tahun, wulan, wulpos, nahun, nuhun, wultupo, nuhuntupo, produp, jumnoseri, tahskr, belek, tauk, belekan, tauge, jk, nopajak As Integer
    Dim jumak, expbln, expthn, lastday, pvprod, pvpri, bvne, bonft, p_one, p_tu, pred, p_tok, jumdir_ft, bonrefreg, jumdir_reg As Integer
    Dim tglini, bulanini, bulanikis, tauniki, perik_promo, nahun_promo, wulan_promo, wulan_pajak, nahun_pajak As Integer
    Dim bonft1, bonft2, bonft3, bonft4, bonft5, bonft6, bonft7, bonft8, bonft9, bonft10, bonft11, bonft12, bonft13, bonft14, bonft15, bonft16, bonft17, bonft18, bonft19, bonft20 As Integer
    Dim bonft88, bonftnpr, bonft99, bonft100, bonft101, bonft102, bonft103, bonft104, bonft105, bonft106, bonft107, bonft108, bonft109, bonft110, bonft111, bonft112, bonft113, bonftms500, bonftms50014, bonftnpr2 As Integer
    Dim piro, mutere, ulan, levke, ahun, loopnya, aaxd, aax, bulanskr, tahunskr, tatanggalan, wulandari, taundari, nilairp, bulan As Integer

    Dim akhir, pvnya, pvbulanan, pvfull, nilaipv, postingup, nilaipvpri, akhire, jume As Long

    Dim nilaibv, nilaipvnya, nambahkiri, nambahkanan, feedc, hargabrg, kusus1, kusus2, kusus3, kusus4, kusus5, hargadc, awal, sisastok As Double
    Dim jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10, jumlah11, jumlah12 As Double
    Dim kiri, poinms, kirifull, kanan, kananfull, jumtot, kkredit, tunai, debit, bgcek, duite, kembalinye, menu_id, stses, nourmc As Double

    Dim sort, pos_area, mypos, loguser, kelasdc, indukdc, namatabel, namatabel2, dcHO, ubahnoseri, novo As String
    Dim ncrd, paket, pase, konfi, jenengmu, nktp, kelamin, tgllahir, bulanlahir, tahunlahir, alamat, kota, propinsi, kodepos, npwp, surat, kotasurat, propinsisurat, kodepossurat As String
    Dim notelp, nohape, pasangan, ahliwaris, hubwaris, emel, noinvo, bnk, nrk, namarek, direk, aloc, subalo, psa As String
    Dim lanjot1, lanjot2, gis, l1, error1, dcpusat, kop, expra, tpe, pase1, pase2, pose, skl, kel, masterdc, k1, k2, tamb, nopakhir, nourutpjk As String
    Dim l2, error2, nama_direk, eml_direk, telp_direk, hp_direk, notelp_direk, l3, error3, l4, error4 As String
    Dim uprane, nama_aloc, alokmu, eml_aloc, telp_aloc, hp_aloc, notelp_aloc, terusane, kedua, l5, error5, sapa, sinten As String
    Dim kode_prd1, kode_prd2, kode_prd3, kode_prd4, kode_prd5, kode_prd6, kode_prd7, kode_prd8, kode_prd9, kode_prd10, kode_prd11, kode_prd12 As String
    Dim nocross, aloce, sopokui, l6, kiwil, sba, kiki, al1, al2, uplinemu, poseupmu, uda, sta, keo, oek, area, tanggalnateh As String
    Dim kdposna, kdpos, sponsor, langsungposting, ent, upnya, posloc, spld, posef, dowo, mburi, staluup, opoupnye, uplu, okelahklo As String
    Dim nosesifaxmc_pdn, nodc, asale, namadis, dc_asal, namamu, nofax, diskon, zona, ggg, l12, kemana, nodcs, kenalan, namaasli, noinvomc As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")

        dino = Now()
        bulanfee = Month(dino)
        tahunfee = Year(dino)
        skr = dino
        sort = Request("sort")
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
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

        Server.ScriptTimeout = 9000000
        Session.Timeout = 120
        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
        'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia

        PrepareData()
        PrepareDisplay()
        CekValidasiDirectSponsor()
        CekValidasiUplinePlacement()
        CekKetersediaanBC()
        CegahLintasJaringan()
        CekPosisiDirectUpline()
    End Sub

    Sub PrepareData()
        x = 0
        ncrd = Trim(Request("noseri"))
        paket = Trim(UCase(Request("paket")))
        'jumbc = request("jumbc")
        jumbc = 1
        pase = Request("password")
        konfi = Request("konfirmasi")
        jenengmu = mlFUNCT.SafeSQL(Trim(UCase(Request("nama"))))
        nktp = mlFUNCT.SafeSQL(Trim(Request("ktp")))
        kelamin = Trim(Request("kelamin"))
        tgllahir = Trim(Request("tgllahir"))
        bulanlahir = Trim(Request("bulanlahir"))
        tahunlahir = Trim(Request("tahunlahir"))
        alamat = mlFUNCT.SafeSQL(Trim(UCase(Request("alamat"))))
        kota = mlFUNCT.SafeSQL(UCase(Trim(Request("kota"))))
        propinsi = mlFUNCT.SafeSQL(UCase(Request("propinsi")))
        kodepos = mlFUNCT.SafeSQL(Trim(UCase(Request("kodepos"))))
        npwp = Trim(Request("npwp"))

        lahirnya = CDate(CStr(tahunlahir) + "-" + CStr(bulanlahir) + "-" + CStr(tgllahir))

        surat = mlFUNCT.SafeSQL(Trim(UCase(Request("surat"))))
        kotasurat = mlFUNCT.SafeSQL(Trim(UCase(Request("kotasurat"))))
        propinsisurat = mlFUNCT.SafeSQL(UCase(Trim(Request("propinsisurat"))))
        kodepossurat = mlFUNCT.SafeSQL(Trim(UCase(Request("kodepossurat"))))

        notelp = mlFUNCT.SafeSQL(UCase(Trim(Request("notelp"))))
        nohape = mlFUNCT.SafeSQL(UCase(Trim(Request("nohape"))))
        pasangan = mlFUNCT.SafeSQL(UCase(Trim(Request("pasangan"))))
        ahliwaris = mlFUNCT.SafeSQL(UCase(Trim(Request("ahliwaris"))))
        hubwaris = mlFUNCT.SafeSQL(UCase(Trim(Request("hubwaris"))))
        emel = mlFUNCT.SafeSQL(UCase(Trim(Request("email"))))
        noinvo = Trim(Request("noinvo"))

        bnk = LTrim(Request("namabank"))
        nrk = mlFUNCT.SafeSQL(LTrim(Request("norek")))
        namarek = mlFUNCT.SafeSQL(LTrim(Request("namarek")))

        direk = LTrim(Request("direk"))
        aloc = LTrim(Request("alo"))
        'subalo = ltrim(request("subalo"))
        subalo = "1"
        psa = LTrim(Request("pos"))
    End Sub

    Sub PrepareDisplay()
        mlSQL = "SELECT id FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjot1 = "F"
            Response.Redirect("akt_failed.aspx?message=Invalid variable !")
        Else
            lanjot1 = "T"
        End If
        mlREADER.Close()

        gis = "AKT"
        paket = UCase(paket)
        If UCase(mypos) <> dcpusat Then
            mlSQL = "SELECT jumlah FROM st_barang_ms where ((grp LIKE '" & gis & "') and (kode LIKE '" & paket & "') and (nopos like '" & mypos & "'))"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                lanjot2 = "F"
                Response.Redirect("akt_failed.aspx?message=Invalid variable (kode paket pendaftaran tidak ditemukan) !")
            Else
                akhir = CLng(mlREADER("jumlah")) - 1
                If akhir >= 0 Then
                    lanjot2 = "T"
                Else
                    lanjot2 = "F"
                    Response.Redirect("akt_failed.aspx?message=Invalid variable (Stock paket pendaftaran tidak mencukupi) !")
                End If
            End If
            mlREADER.Close()
        Else
            lanjot2 = "T"
        End If


        If ncrd = "" Then
            l1 = "Mbuh"
            Response.Redirect("akt_failed.aspx?message=Nomor seri pendaftaran / nomor distributor belum anda isikan")
        Else
            l1 = "Ter1"
            error1 = ""
        End If
    End Sub

    Sub CekValidasiDirectSponsor()
        '''''''''''''''''''''''''''''''''
        ' CEK KEVALIDAN DIRECT SPONSOR
        '''''''''''''''''''''''''''''''''
        If ncrd = direk Then
            Response.Redirect("akt_failed.aspx?message=Anda tidak dapat mensponsori diri sendiri")
        End If

        mlSQL = "SELECT kta,uid,upme,emel,telp,hp FROM member WHERE kta LIKE '" & direk & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            l2 = "Mbuh"
            nama_direk = "-"
            Response.Redirect("akt_failed.aspx?message=Nomor id distributor sponsor tidak ditemukan !")
        Else
            l2 = "Ter2"
            error2 = ""
            nama_direk = mlREADER("uid")
            eml_direk = mlREADER("emel")
            telp_direk = mlREADER("telp")
            hp_direk = mlREADER("hp")
            notelp_direk = telp_direk + " / " + hp_direk
        End If
        mlREADER.Close()
    End Sub

    Sub CekValidasiUplinePlacement()
        '''''''''''''''''''''''''''''''''''''
        ' CEK KEVALIDAN UPLINE PLACEMENT
        '''''''''''''''''''''''''''''''''''''
        mlSQL = "SELECT kta,uid,upme,emel,telp,hp FROM member WHERE kta LIKE '" & aloc & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            l3 = "Mbuh"
            uprane = "F"
            Response.Redirect("akt_failed.aspx?message=Nomor id distributor upline placement tidak ditemukan !")
        Else
            l3 = "Ter3"
            error3 = ""
            'uprane = rs("upme")	
            uprane = "F"
            nama_aloc = mlREADER("uid")
            alokmu = mlREADER("kta")
            eml_aloc = mlREADER("emel")
            telp_aloc = mlREADER("telp")
            hp_aloc = mlREADER("hp")
            notelp_aloc = telp_aloc + " / " + hp_aloc
        End If
        mlREADER.Close()
    End Sub

    Sub CekKetersediaanBC()
        '''''''''''''''''''''''''''''''''''''''''''
        ' CEK KETERSEDIAAN BC
        '''''''''''''''''''''''''''''''''''''''''''
        If uprane = "F" Then
            If subalo = "2" Then
                If psa = "L" Then
                    l4 = "Mbuh"
                    Response.Redirect("akt_failed.aspx?message=Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-2 kaki KIRI upline yang tidak memiliki 3 BC")
                Else
                    If psa = "R" Then
                        l4 = "Mbuh"
                        Response.Redirect("akt_failed.aspx?message=Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-2 kaki KANAN upline yang tidak memiliki 3 BC")
                    End If
                End If
            Else
                If subalo = "3" Then
                    If psa = "L" Then
                        l4 = "Mbuh"
                        Response.Redirect("akt_failed.aspx?message=Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-3 kaki KIRI upline yang tidak memiliki 3 BC")
                    Else
                        If psa = "R" Then
                            l4 = "Mbuh"
                            Response.Redirect("akt_failed.aspx?message=Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-3 kaki KANAN upline yang tidak memiliki 3 BC")
                        End If
                    End If
                Else
                    If subalo = "1" Then
                        error4 = ""
                        l4 = "Ter4"
                    End If
                End If
            End If
        Else
            If uprane = "T" Then
                error4 = ""
                l4 = "Ter4"
            Else
                error4 = "Kesalahan Penempatan"
                l4 = "Mbuh"
            End If
        End If

    End Sub

    Sub CegahLintasJaringan()
        '''''''''''''''''''''''''
        ' cegah lintas jaringan '
        '''''''''''''''''''''''''

        mlSQL = "SELECT TOP 1 id FROM mylevel order by id DESC"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            muter = 1000
        Else
            muter = mlREADER("id")
        End If
        mlREADER.Close()

        If direk = aloc Then
            terusane = "LulusUj1Klinis"
        Else
            terusane = "R4ki50lah"
            kedua = aloc
            For aaxd = 1 To muter
                mlSQL = "SELECT kta,ktaloc FROM mylevel WHERE kta LIKE '" & kedua & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    aaxd = muter + 10
                    Exit For
                Else
                    If mlREADER("ktaloc") = direk Then
                        terusane = "LulusUj1Klinis"
                        aaxd = muter + 10
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
        End If

        If terusane <> "LulusUj1Klinis" Then
            l5 = "Mbuh"
            Response.Redirect("akt_failed.aspx?message=Maaf, sponsor dan upline penempatan tidak berada dalam satu jaringan - (CROSSLINE TIDAK DIIJINKAN)")
        Else
            l5 = "Ter5"
            error5 = ""
        End If
    End Sub

    Sub CekTipeKartu()
        gis = "AKT"
        paket = UCase(paket)
        mlSQL = "SELECT * FROM st_barang where ((grp LIKE '" & gis & "') and (kode LIKE '" & paket & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            kop = "M"
            nilaibv = 0
            nilaipvnya = 0
            expra = "F"
            jumbc = 1
            nambahkiri = 1
            nambahkanan = 1
        Else
            kop = mlREADER("kop")
            nilaibv = 0
            If paket = "TITANIUMSP" Then
                nilaipvnya = mlREADER("pv") / 6
            Else
                nilaipvnya = mlREADER("pv")
            End If
            expra = "F"
            jumbc = 1
            nambahkiri = 1
            nambahkanan = 1
            feedc = 0
            If pos_area = "1" Then
                hargabrg = mlREADER("hd1")
                kusus1 = mlREADER("khusus1")
                If UCase(kelasdc) = "D" And kusus1 <> 0 Then
                    hargadc = kusus1
                Else
                    hargadc = hargabrg
                End If
                feedc = hargabrg - hargadc
            Else
                If pos_area = "2" Then
                    hargabrg = mlREADER("hd2")
                    kusus2 = mlREADER("khusus2")
                    If UCase(kelasdc) = "D" And kusus2 <> 0 Then
                        hargadc = kusus2
                    Else
                        hargadc = hargabrg
                    End If
                    feedc = hargabrg - hargadc
                Else
                    If pos_area = "3" Then
                        hargabrg = mlREADER("hd3")
                        kusus3 = mlREADER("khusus3")
                        If UCase(kelasdc) = "D" And kusus3 <> 0 Then
                            hargadc = kusus3
                        Else
                            hargadc = hargabrg
                        End If
                        feedc = hargabrg - hargadc
                    Else
                        If pos_area = "4" Then
                            hargabrg = mlREADER("hd4")
                            kusus4 = mlREADER("khusus4")
                            If UCase(kelasdc) = "D" And kusus4 <> 0 Then
                                hargadc = kusus4
                            Else
                                hargadc = hargabrg
                            End If
                            feedc = hargabrg - hargadc
                        Else
                            If pos_area = "5" Then
                                hargabrg = mlREADER("hd5")
                                kusus5 = mlREADER("khusus5")
                                If UCase(kelasdc) = "D" And kusus5 <> 0 Then
                                    hargadc = kusus5
                                Else
                                    hargadc = hargabrg
                                End If
                                feedc = hargabrg - hargadc
                            End If
                        End If
                    End If
                End If
            End If


        End If
        mlREADER.Close()

        If kop = "P" Or kop = "I" Then
            tpe = "P"
        Else
            If kop = "S" Then
                tpe = "S"
            Else
                If kop = "F" Then
                    tpe = "F"
                Else
                    If kop = "M" Then
                        tpe = "M"
                    Else
                        tpe = "R"
                    End If
                End If
            End If
        End If

        tglaktif = Now()
        tglnyaaa = tglaktif
        bulan = Month(tglaktif)
        tahun = Year(tglaktif)

        wulan = wulpos
        nahun = nuhun
        wultupo = wulpos
        nuhuntupo = nuhun

        pvnya = CLng(nilaipvnya)
        pvbulanan = CLng(nilaipvnya)
        pvfull = pvnya

        If pvnya >= 200 Then ' dapat productivity
            nilaipv = pvnya
            nilaibv = 0
            produp = 0
            postingup = pvnya
            nilaipvpri = pvnya
        Else
            nilaipv = pvnya
            nilaibv = 0
            produp = 0
            postingup = pvnya
            nilaipvpri = pvnya
        End If

        pase1 = Right(nktp, 3)
        pase2 = Trim(Left(UCase(jenengmu), 3))
        pase = pase1 + pase2

        mlSQL = "SELECT TOP 1 * FROM noseritemp order by noseri"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            akhir = 1889104
            mlSQL2 = "Insert into noseritemp(noseri,noslip,nopos,tgl,kode,nama,direk,alok,subalo,kaki)values('" & akhir & "','" & noinvo & "','" & mypos & "'" & vbCrLf
            mlSQL2 += ",'" & tglaktif & "','" & paket & "','" & jenengmu & "','" & direk & "','" & aloc & "','" & pose & "','" & skl & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
            akhire = CLng(mlREADER("noseri")) + 1
            If akhire = 1888899 Or akhire = 2202443 Or akhire = 4600108 Or akhire = 7371056 Then
                akhir = akhire + 1
            Else
                akhir = akhire
            End If

            mlSQL2 = "Insert into noseritemp(noseri,noslip,nopos,tgl,kode,nama,direk,alok,subalo,kaki)values('" & akhir & "','" & noinvo & "','" & mypos & "'" & vbCrLf
            mlSQL2 += ",'" & tglaktif & "','" & paket & "','" & jenengmu & "','" & direk & "','" & aloc & "','" & pose & "','" & skl & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
    End Sub

    Sub CheckNoSeri()
        For ceknoseri = 1 To 10
            ubahnoseri = "F"
            mlSQL = "SELECT count(id) as vid FROM noseritemp where noseri like '" & akhir & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlREADER.Close()
                Exit For
            Else
                jumnoseri = mlREADER("vid")
                jumnoseri = CDbl(jumnoseri)
                If jumnoseri > 1 Then
                    mlSQL2 = "SELECT TOP 1 * FROM noseritemp where noseri like '" & akhir & "' order by id desc"
                    mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                    mlREADER2.Read()
                    If mlREADER2.HasRows Then
                        novo = mlREADER2("noslip")
                        If novo = noinvo Then
                            ubahnoseri = "T"
                        End If
                    End If
                    mlREADER2.Close()
                Else
                    mlREADER.Close()
                    Exit For
                End If
            End If
            mlREADER.Close()

            If ubahnoseri = "T" Then
                mlSQL = "SELECT TOP 1 * FROM noseritemp order by noseri desc"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If mlREADER.HasRows Then
                    akhire = CLng(mlREADER("noseri")) + 1
                    If akhire = 1888899 Or akhire = 2202443 Or akhire = 4600108 Or akhire = 7371056 Then
                        akhir = akhire + 1
                    Else
                        akhir = akhire
                    End If
                    Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                    'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								
                    mlSQL2 = "update noseritemp set noseri = '" & akhir & "' where noslip = '" & noinvo & "'"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()
                Exit For
            End If
        Next
    End Sub

    Sub CreateExpired()
        expbln = Month(DateAdd("m", 12, tglaktif))
        expthn = Year(DateAdd("m", 12, tglaktif))
        If expbln > 6 Then
            expbln = expbln - 6
            expthn = expthn
        Else
            expbln = expbln + 6
            expthn = expthn - 1
        End If

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
        expirednya = CDate(CStr(expthn) + "-" + CStr(expbln) + "-" + CStr(lastday))

        mlSQL = "insert into bns_expired_member(kta,last_tupo_bulan,last_tupo_tahun,re_entry,tglexpired,direk,alok,kiri,kanan)values('" & akhir & "','" & Month(tglaktif) & "','" & Year(tglaktif) & "','T'" & vbCrLf
        mlSQL += ",'" & expirednya & "','" & direk & "','" & aloc & "',0,0)"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
    End Sub

    Sub UpdateTableTransaksi()
        mlSQL = "SELECT dcinduk FROM st_sale_daftar where nopos Like '" & mypos & "' and noslip like '" & noinvo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            indukdc = "B-000"
        Else
            indukdc = mlREADER("dcinduk")
        End If
        mlREADER.Close()
    End Sub

    Sub CreateNomorInvoicePajak()
        tahskr = CInt(Year(skr))
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
                mlSQL = "SELECT TOP 1 urut FROM nourut where ((dcinduk like '" & masterdc & "' and kel like '" & k1 & "') or (nopos like '" & masterdc & "' AND kel like '" & k2 & "'))" & vbCrLf
                mlSQL += "And month(tgl)>='" & belekan & "' and year(tgl)='" & tauge & "' order by nopajak desc"
            Else
                mlSQL = "SELECT TOP 1 urut FROM nourut where ((dcinduk like '" & masterdc & "' and kel like '" & k1 & "') or (nopos like '" & masterdc & "' AND kel like '" & k2 & "'))" & vbCrLf
                mlSQL += "And year(tgl)='" & tahskr & "' and (nopajak like '002%' or nopajak like '001%') order by nopajak desc"
            End If
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
            nopajak = "0"
        End If

        mlSQL = "SELECT TOP 1 * FROM nourut where (nopajak like '002%' or nopajak like '001%') order by nopajak desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
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
        End If

        nourutpjk = tamb + CStr(nopajak)

        mlSQL = "insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values('" & nopajak & "','" & mypos & "','" & noinvo & "','" & skr & "','AKT','RET','" & indukdc & "','" & nourutpjk & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            mlSQL2 = "insert into st_sale_daftar(noseri,nopajak,pakai,pvpri,alokbulan,aloktahun,tipe)values('" & akhir & "','" & nourutpjk & "','T','" & nilaipvpri & "','" & wultupo & "','" & nuhuntupo & "','normal')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
    End Sub

    Sub StockAktualPaketPendaftaranDC()
        If UCase(mypos) <> dcpusat Then ' bila DC kantor pusat tidak ada paket pendaftaran
            mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by kode DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                jumak = 0
            Else
                jumak = mlREADER("jumlah")

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - 1 & "' where nopos like '" & mypos & "' and kode like '" & paket & "'"
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
    End Sub

    Sub KartuStockPaketPendaftaran()
        mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by tgl DESC, id DESC"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "'" & vbCrLf
            mlSQL2 += ",'" & jumak & "',0,1,'" & jumak - 1 & "','" & noinvo & "','Penjualan Pendaftaran DC')"
        Else
            awal = mlREADER("akhir")
            sisastok = awal - 1
            If sisastok < 0 Then
                sisastok = 0
            Else
                sisastok = sisastok
            End If

            mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "'" & vbCrLf
            mlSQL2 += ",'" & awal & "',0,1,'" & sisastok & "','" & noinvo & "','Penjualan Pendaftaran DC')"
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()
    End Sub

    Sub UpdateProdukPaketPendaftaran()
        mlSQL = "SELECT TOP 1 * FROM st_tipe_paket where kode Like '" & paket & "' order by kode DESC"
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
    End Sub

    Sub UpdateStockAktualDC()
        If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
            mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by kode DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                jumak = 0
            Else
                jumak = mlREADER("jumlah")

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah1 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd1 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah1 & "','" & jumak - jumlah1 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah1
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd1 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah1 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd1 & "','" & jumlah1 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah2 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd2 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd2 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah2 & "','" & jumak - jumlah2 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah2
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd2 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah2 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd2 & "','" & jumlah2 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah3 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd3 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd3 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah3 & "','" & jumak - jumlah3 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah3
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd3 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah3 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd3 & "','" & jumlah3 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah4 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd4 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd4 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah4 & "','" & jumak - jumlah4 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah4
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd4 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah4 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd4 & "','" & jumlah4 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah5 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd5 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd5 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah5 & "','" & jumak - jumlah5 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah5
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd5 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah5 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd5 & "','" & jumlah5 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah6 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd6 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd6 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah6 & "','" & jumak - jumlah6 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah6
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd6 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah6 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd6 & "','" & jumlah6 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah7 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd7 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd7 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah7 & "','" & jumak - jumlah7 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah7
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd7 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah7 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd7 & "','" & jumlah7 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah8 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd8 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd8 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah8 & "','" & jumak - jumlah8 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah8
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd8 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah8 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd8 & "','" & jumlah8 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah9 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd9 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd9 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah9 & "','" & jumak - jumlah9 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah9
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd9 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah9 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd9 & "','" & jumlah9 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah10 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd10 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd10 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah10 & "','" & jumak - jumlah10 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah10
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd10 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah10 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd10 & "','" & jumlah10 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah11 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd11 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd11 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah11 & "','" & jumak - jumlah11 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah11
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd11 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah11 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd11 & "','" & jumlah11 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
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

                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah12 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd12 & "'"
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
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd12 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah12 & "','" & jumak - jumlah12 & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah12
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd12 & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah12 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran DC')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd12 & "','" & jumlah12 & "','" & noinvo & "'" & vbCrLf
            mlSQL += ",'" & indukdc & "','" & nourutpjk & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If


        mlSQL = "SELECT * FROM st_sale_daftar_prd where noslip like '" & noinvo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into st_sale_daftar_prd(noslip,tgl,nopajak,kode1,jumlah1,kode2,jumlah2,kode3,jumlah3,kode4,jumlah4,kode5,jumlah5,kode6,jumlah6,kode7,jumlah7,kode8,jumlah8,kode9,jumlah9" & vbCrLf
            mlSQL2 += ",kode10,jumlah10,kode11,jumlah11,kode12,jumlah12,dcinduk)values('" & noinvo & "','" & dino & "','" & nourutpjk & "'" & vbCrLf
            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                mlSQL2 += ",'" & kode_prd1 & "','" & jumlah1 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd2 <> "" Or kode_prd2 <> "-" Or IsDBNull(kode_prd2) = False Then
                mlSQL2 += ",'" & kode_prd2 & "','" & jumlah2 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd3 <> "" Or kode_prd3 <> "-" Or IsDBNull(kode_prd3) = False Then
                mlSQL2 += ",'" & kode_prd3 & "','" & jumlah3 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd4 <> "" Or kode_prd4 <> "-" Or IsDBNull(kode_prd4) = False Then
                mlSQL2 += ",'" & kode_prd4 & "','" & jumlah4 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd5 <> "" Or kode_prd5 <> "-" Or IsDBNull(kode_prd5) = False Then
                mlSQL2 += ",'" & kode_prd5 & "','" & jumlah5 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd6 <> "" Or kode_prd6 <> "-" Or IsDBNull(kode_prd6) = False Then
                mlSQL2 += ",'" & kode_prd6 & "','" & jumlah6 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd7 <> "" Or kode_prd7 <> "-" Or IsDBNull(kode_prd7) = False Then
                mlSQL2 += ",'" & kode_prd7 & "','" & jumlah7 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd8 <> "" Or kode_prd8 <> "-" Or IsDBNull(kode_prd8) = False Then
                mlSQL2 += ",'" & kode_prd8 & "','" & jumlah8 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd9 <> "" Or kode_prd9 <> "-" Or IsDBNull(kode_prd9) = False Then
                mlSQL2 += ",'" & kode_prd9 & "','" & jumlah9 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd10 <> "" Or kode_prd10 <> "-" Or IsDBNull(kode_prd10) = False Then
                mlSQL2 += ",'" & kode_prd10 & "','" & jumlah10 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd11 <> "" Or kode_prd11 <> "-" Or IsDBNull(kode_prd11) = False Then
                mlSQL2 += ",'" & kode_prd11 & "','" & jumlah11 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            If kode_prd12 <> "" Or kode_prd12 <> "-" Or IsDBNull(kode_prd12) = False Then
                mlSQL2 += ",'" & kode_prd12 & "','" & jumlah12 & "'" & vbCrLf
            Else
                mlSQL2 += ",'-',0" & vbCrLf
            End If

            mlSQL2 += ",'" & indukdc & "')"
        Else
            mlSQL2 = "update st_sale_daftar_prd set " & vbCrLf
            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                mlSQL2 += "kode1 = '" & kode_prd1 & "',jumlah1 = '" & jumlah1 & "'" & vbCrLf
            Else
                mlSQL2 += "kode1 = '-',jumlah1 = 0" & vbCrLf
            End If

            If kode_prd2 <> "" Or kode_prd2 <> "-" Or IsDBNull(kode_prd2) = False Then
                mlSQL2 += ",kode2 = '" & kode_prd2 & "',jumlah2 = '" & jumlah2 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode2 = '-',jumlah2 = 0" & vbCrLf
            End If

            If kode_prd3 <> "" Or kode_prd3 <> "-" Or IsDBNull(kode_prd3) = False Then
                mlSQL2 += ",kode3 = '" & kode_prd3 & "',jumlah3 = '" & jumlah3 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode3 = '-',jumlah3 = 0" & vbCrLf
            End If

            If kode_prd4 <> "" Or kode_prd4 <> "-" Or IsDBNull(kode_prd4) = False Then
                mlSQL2 += ",kode4 = '" & kode_prd4 & "',jumlah4 = '" & jumlah4 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode4 = '-',jumlah4 = 0" & vbCrLf
            End If

            If kode_prd5 <> "" Or kode_prd5 <> "-" Or IsDBNull(kode_prd5) = False Then
                mlSQL2 += ",kode5 = '" & kode_prd5 & "',jumlah5 = '" & jumlah5 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode5 = '-',jumlah5 = 0" & vbCrLf
            End If

            If kode_prd6 <> "" Or kode_prd6 <> "-" Or IsDBNull(kode_prd6) = False Then
                mlSQL2 += ",kode6 = '" & kode_prd6 & "',jumlah6 = '" & jumlah6 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode6 = '-',jumlah6 = 0" & vbCrLf
            End If

            If kode_prd7 <> "" Or kode_prd7 <> "-" Or IsDBNull(kode_prd7) = False Then
                mlSQL2 += ",kode7 = '" & kode_prd7 & "',jumlah7 = '" & jumlah7 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode7 = '-',jumlah7 = 0" & vbCrLf
            End If

            If kode_prd8 <> "" Or kode_prd8 <> "-" Or IsDBNull(kode_prd8) = False Then
                mlSQL2 += ",kode8 = '" & kode_prd8 & "',jumlah8 = '" & jumlah8 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode8 = '-',jumlah8 = 0" & vbCrLf
            End If

            If kode_prd9 <> "" Or kode_prd9 <> "-" Or IsDBNull(kode_prd9) = False Then
                mlSQL2 += ",kode9 = '" & kode_prd9 & "',jumlah9 = '" & jumlah9 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode9 = '-',jumlah9 = 0" & vbCrLf
            End If

            If kode_prd10 <> "" Or kode_prd10 <> "-" Or IsDBNull(kode_prd10) = False Then
                mlSQL2 += ",kode10 = '" & kode_prd10 & "',jumlah10 = '" & jumlah10 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode10 = '-',jumlah10 = 0" & vbCrLf
            End If

            If kode_prd11 <> "" Or kode_prd11 <> "-" Or IsDBNull(kode_prd11) = False Then
                mlSQL2 += ",kode11 = '" & kode_prd11 & "',jumlah11 = '" & jumlah11 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode11 = '-',jumlah11 = 0" & vbCrLf
            End If

            If kode_prd12 <> "" Or kode_prd12 <> "-" Or IsDBNull(kode_prd12) = False Then
                mlSQL2 += ",kode12 = '" & kode_prd12 & "',jumlah12 = '" & jumlah12 & "'" & vbCrLf
            Else
                mlSQL2 += ",kode12 = '-',jumlah12 = 0" & vbCrLf
            End If

            mlSQL2 += ",nopajak = '" & nourutpjk & "' where noslip like '" & noinvo & "'"
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()
    End Sub

    Sub UpdatePVPribadi()
        sapa = sinten
        jume = postingup
        bvne = 0
        pvprod = produp
        pvpri = nilaipv

        mlSQL = "INSERT INTO bns_mypv_prod_reg (kta,bulan,tahun,produp) VALUES ('" & sapa & "'," & wulan & "," & nahun & "," & pvprod & ")"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "INSERT INTO bns_mypv_current (kta,bulan,tahun,pvpribadi,produp,pvgrupkiri,pvgrupkanan,pvmurni) VALUES ('" & sapa & "'," & wulan & "," & nahun & "," & pvpri & "," & pvprod & ",0,0," & pvnya & ")"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
    End Sub

    Sub DirectSponsorUpdateTable()
        Dim vnpr, vpremium, vregular, vspot, vpromo, vnppr, vnppl, vnreg, vupg, vtitan, vregpromo, vpremiumsp, vplatinumsp, vprempromo As Integer

        mlSQL = "SELECT * FROM bns_mybonref where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            If paket = "PPL" Then
                vnpr = 0
                vpremium = 0
                vregular = 0
                vspot = 1
                vpromo = 0
                vnppr = 0
                vnppl = 0
                vnreg = 0
                vupg = 0
                vtitan = 0
                vregpromo = 0
                vpremiumsp = 0
                vplatinumsp = 0
                vprempromo = 0
            Else
                If paket = "PPR" Then
                    vnpr = 0
                    vpremium = 1
                    vregular = 0
                    vspot = 0
                    vpromo = 0
                    vnppr = 0
                    vnppl = 0
                    vnreg = 0
                    vupg = 0
                    vtitan = 0
                    vregpromo = 0
                    vpremiumsp = 0
                    vplatinumsp = 0
                    vprempromo = 0
                Else
                    If paket = "PRG" Or paket = "REG" Then
                        vnpr = 0
                        vpremium = 0
                        vregular = 1
                        vspot = 0
                        vpromo = 0
                        vnppr = 0
                        vnppl = 0
                        vnreg = 0
                        vupg = 0
                        vtitan = 0
                        vregpromo = 0
                        vpremiumsp = 0
                        vplatinumsp = 0
                        vprempromo = 0
                    Else
                        If paket = "NPPR" Then
                            vnpr = 0
                            vpremium = 0
                            vregular = 0
                            vspot = 0
                            vpromo = 0
                            vnppr = 1
                            vnppl = 0
                            vnreg = 0
                            vupg = 0
                            vtitan = 0
                            vregpromo = 0
                            vpremiumsp = 0
                            vplatinumsp = 0
                            vprempromo = 0
                        Else
                            If paket = "NPPL" Then
                                vnpr = 0
                                vpremium = 0
                                vregular = 0
                                vspot = 0
                                vpromo = 0
                                vnppr = 0
                                vnppl = 1
                                vnreg = 0
                                vupg = 0
                                vtitan = 0
                                vregpromo = 0
                                vpremiumsp = 0
                                vplatinumsp = 0
                                vprempromo = 0
                            Else
                                If paket = "NPRG" Then
                                    vnpr = 0
                                    vpremium = 0
                                    vregular = 0
                                    vspot = 0
                                    vpromo = 0
                                    vnppr = 0
                                    vnppl = 0
                                    vnreg = 1
                                    vupg = 0
                                    vtitan = 0
                                    vregpromo = 0
                                    vpremiumsp = 0
                                    vplatinumsp = 0
                                    vprempromo = 0
                                Else
                                    If paket = "UPG" Then
                                        vnpr = 0
                                        vpremium = 0
                                        vregular = 0
                                        vspot = 0
                                        vpromo = 0
                                        vnppr = 0
                                        vnppl = 0
                                        vnreg = 0
                                        vupg = 1
                                        vtitan = 0
                                        vregpromo = 0
                                        vpremiumsp = 0
                                        vplatinumsp = 0
                                        vprempromo = 0
                                    Else
                                        If paket = "TITANIUMSP" Then
                                            vnpr = 0
                                            vpremium = 0
                                            vregular = 0
                                            vspot = 0
                                            vpromo = 0
                                            vnppr = 0
                                            vnppl = 0
                                            vnreg = 0
                                            vupg = 0
                                            vtitan = 1
                                            vregpromo = 0
                                            vpremiumsp = 0
                                            vplatinumsp = 0
                                            vprempromo = 0
                                        Else
                                            If paket = "PPRG" Then
                                                vnpr = 0
                                                vpremium = 0
                                                vregular = 0
                                                vspot = 0
                                                vpromo = 0
                                                vnppr = 0
                                                vnppl = 0
                                                vnreg = 0
                                                vupg = 0
                                                vtitan = 0
                                                vregpromo = 1
                                                vpremiumsp = 0
                                                vplatinumsp = 0
                                                vprempromo = 0
                                            Else
                                                If paket = "PREMIUMSP" Then
                                                    vnpr = 0
                                                    vpremium = 0
                                                    vregular = 0
                                                    vspot = 0
                                                    vpromo = 0
                                                    vnppr = 0
                                                    vnppl = 0
                                                    vnreg = 0
                                                    vupg = 0
                                                    vtitan = 0
                                                    vregpromo = 0
                                                    vpremiumsp = 1
                                                    vplatinumsp = 0
                                                    vprempromo = 0
                                                Else
                                                    If paket = "PLATINUMSP" Then
                                                        vnpr = 0
                                                        vpremium = 0
                                                        vregular = 0
                                                        vspot = 0
                                                        vpromo = 0
                                                        vnppr = 0
                                                        vnppl = 0
                                                        vnreg = 0
                                                        vupg = 0
                                                        vtitan = 0
                                                        vregpromo = 0
                                                        vpremiumsp = 0
                                                        vplatinumsp = 1
                                                        vprempromo = 0
                                                    Else
                                                        If paket = "SUPERPROMO" Then
                                                            vnpr = 0
                                                            vprempromo = 1
                                                            vpremium = 0
                                                            vregular = 0
                                                            vspot = 0
                                                            vpromo = 0
                                                            vnppr = 0
                                                            vnppl = 0
                                                            vnreg = 0
                                                            vupg = 0
                                                            vtitan = 0
                                                            vregpromo = 0
                                                            vpremiumsp = 0
                                                            vplatinumsp = 0
                                                        Else
                                                            vprempromo = 0
                                                            vnpr = 0
                                                            vpremium = 0
                                                            vregular = 0
                                                            vspot = 0
                                                            vpromo = 0
                                                            vnppr = 0
                                                            vnppl = 0
                                                            vnreg = 0
                                                            vupg = 0
                                                            vtitan = 0
                                                            vregpromo = 0
                                                            vpremiumsp = 0
                                                            vplatinumsp = 0
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
                End If
            End If
            mlSQL2 = "insert into bns_mybonref(kta,bulan,tahun,npr,premium,regular,spot,promo,nppr,nppl,nreg,upg,titan,regpromo,premiumsp,platinumsp,prempromo)values('" & direk & "','" & wulan & "','" & nahun & "'" & vbCrLf
            mlSQL2 += ",'" & vnpr & "','" & vpremium & "','" & vregular & "','" & vspot & "','" & vpromo & "','" & vnppr & "','" & vnppl & "','" & vnreg & "','" & vupg & "','" & vtitan & "','" & vregpromo & "'" & vbCrLf
            mlSQL2 += ",'" & vpremiumsp & "','" & vplatinumsp & "','" & vprempromo & "')"
            'rs.update
        Else
            mlSQL2 = "update bns_mybonref set " & vbCrLf
            If paket = "SUPERPROMO" Then
                mlSQL2 += "prempromo = '" & mlREADER("prempromo") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
            Else
                If paket = "PPL" Then
                    mlSQL2 += "spot = '" & mlREADER("spot") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                Else
                    If paket = "PPR" Then
                        mlSQL2 += "premium = '" & mlREADER("premium") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                    Else
                        If paket = "PRG" Or paket = "REG" Then
                            mlSQL2 += "regular = '" & mlREADER("regular") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                        Else
                            If paket = "NPPR" Then
                                mlSQL2 += "nppr = '" & mlREADER("nppr") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                            Else
                                If paket = "NPPL" Then
                                    mlSQL2 += "nppl = '" & mlREADER("nppl") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                                Else
                                    If paket = "NPRG" Then
                                        mlSQL2 += "nreg = '" & mlREADER("nreg") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                                    Else
                                        If paket = "UPG" Then
                                            mlSQL2 += "upg = '" & mlREADER("upg") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                                        Else
                                            If paket = "TITANIUMSP" Then
                                                mlSQL2 += "titan = '" & mlREADER("titan") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                                            Else
                                                If paket = "PPRG" Then
                                                    mlSQL2 += "regpromo = '" & mlREADER("regpromo") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                                                Else
                                                    If paket = "PREMIUMSP" Then
                                                        mlSQL2 += "premiumsp = '" & mlREADER("premiumsp") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
                                                    Else
                                                        If paket = "PLATINUMSP" Then
                                                            mlSQL2 += "platinumsp = '" & mlREADER("platinumsp") + 1 & "' where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
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
                End If
            End If
            'rs.update
        End If
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()
    End Sub

    Sub FastTrackPlan()
        If UCase(paket) = "MS200H-14" Or UCase(paket) = "MS200B-14" Or UCase(paket) = "MS200V-14" Or UCase(paket) = "MS200VS-14" Or UCase(paket) = "MS400-14" Or UCase(paket) = "MS200A-14" _
                Or UCase(paket) = "MS200-14" Or UCase(paket) = "MS500-14" Or UCase(paket) = "MS500" Or UCase(paket) = "NPR2" Or UCase(paket) = "FT101" Or UCase(paket) = "FT102" Or UCase(paket) = "FT103" _
                Or UCase(paket) = "FT104" Or UCase(paket) = "FT105" Or UCase(paket) = "FT106" Or UCase(paket) = "FT107" Or UCase(paket) = "FT108" Or UCase(paket) = "FT109" Or UCase(paket) = "FT110" _
                Or UCase(paket) = "FT111" Or UCase(paket) = "NPR" Or UCase(paket) = "FT99" Or UCase(paket) = "FT100" Or UCase(paket) = "FT13" Or UCase(paket) = "FT14" Or UCase(paket) = "FT15" Or UCase(paket) = "FT1" _
                Or UCase(paket) = "FT7" Or UCase(paket) = "FT8" Or UCase(paket) = "FT11" Or UCase(paket) = "FT12" Or UCase(paket) = "FT88" Or UCase(paket) = "FT2" Or UCase(paket) = "FT3" Or UCase(paket) = "FT4" _
                Or UCase(paket) = "FT5" Or UCase(paket) = "FT6" Or UCase(paket) = "FT9" Or UCase(paket) = "FT10" Or UCase(paket) = "FT16" Or UCase(paket) = "FT17" Or UCase(paket) = "FT18" Or UCase(paket) = "FT19" Or UCase(paket) = "FT20" Then
            tglku = Now.Date
            tglini = Day(tglku)
            bulanini = Month(tglku)
            bulanikis = Month(tglku)
            tauniki = Year(tglku)

            mlSQL = "Select * FROM kapan where (((day(awal) = '" & tglini & "') and (month(awal) = '" & bulanini & "') and (year(awal) = '" & tauniki & "')) or ((day(t2) = '" & tglini & "')" & vbCrLf
            mlSQL += "And (month(t2) = '" & bulanini & "') and (year(t2) = '" & tauniki & "')) or ((day(t3) = '" & tglini & "') and (month(t3) = '" & bulanini & "') and (year(t3) = '" & tauniki & "'))" & vbCrLf
            mlSQL += "Or ((day(t4) = '" & tglini & "') and (month(t4) = '" & bulanini & "') and (year(t4) = '" & tauniki & "')) or ((day(t5) = '" & tglini & "') and (month(t5) = '" & bulanini & "')" & vbCrLf
            mlSQL += "And (year(t5) = '" & tauniki & "')) or ((day(t6) = '" & tglini & "') and (month(t6) = '" & bulanini & "') and (year(t6) = '" & tauniki & "')) or ((day(akhir) = '" & tglini & "')" & vbCrLf
            mlSQL += "And (month(akhir) = '" & bulanini & "') and (year(akhir) = '" & tauniki & "')))"

            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                tglbayar = Now.AddDays(+4)
                perik_promo = DatePart("ww", Now.Date)
                nahun_promo = Year(tglku)
                wulan_promo = Month(tglku)
                wulan_pajak = Month(tglbayar)
                nahun_pajak = Year(tglbayar) ' untuk menentukan masuk pembayaran pajak pada bulan / tahun apa	
            Else
                tglbayar = CDate(mlREADER("akhir")).AddDays(+4)
                perik_promo = mlREADER("minggu")
                nahun_promo = Year(mlREADER("awal"))
                wulan_promo = Month(mlREADER("awal"))
                wulan_pajak = Month(tglbayar)
                nahun_pajak = Year(tglbayar) ' untuk menentukan masuk pembayaran pajak pada bulan / tahun apa
            End If
            mlREADER.Close()

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
            bonft111 = 0
            bonft112 = 0
            bonft113 = 0

            mlSQL = "SELECT * FROM bns_kurs"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
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
                bonftms500 = 0
                bonftms50014 = 0
                bonftnpr2 = 0
            Else
                bonft100 = mlREADER("fsbft100")
                bonft101 = mlREADER("fsbft101")
                bonft102 = mlREADER("fsbft102")
                bonft103 = mlREADER("fsbft103")
                bonft104 = mlREADER("fsbft104")
                bonft105 = mlREADER("fsbft105")
                bonft106 = mlREADER("fsbft106")
                bonft107 = mlREADER("fsbft107")
                bonft108 = mlREADER("fsbft108")
                bonft109 = mlREADER("fsbft109")
                bonft110 = mlREADER("fsbft110")
                bonft99 = mlREADER("fsbft99")
                bonft1 = mlREADER("fsbft1")
                bonft2 = mlREADER("fsbft2")
                bonft3 = mlREADER("fsbft3")
                bonft4 = mlREADER("fsbft4")
                bonft5 = mlREADER("fsbft5")
                bonft6 = mlREADER("fsbft6")
                bonft7 = mlREADER("fsbft7")
                bonft8 = mlREADER("fsbft8")
                bonft9 = mlREADER("fsbft9")
                bonft10 = mlREADER("fsbft10")
                bonft11 = mlREADER("fsbft11")
                bonft12 = mlREADER("fsbft12")
                bonft88 = mlREADER("fsbft88")
                bonft13 = mlREADER("fsbft13")
                bonft14 = mlREADER("fsbft14")
                bonft15 = mlREADER("fsbft15")
                bonft16 = mlREADER("fsbft16")
                bonft17 = mlREADER("fsbft17")
                bonft18 = mlREADER("fsbft18")
                bonft19 = mlREADER("fsbft19")
                bonft20 = mlREADER("fsbft20")
                bonftnpr = mlREADER("fsbnpr")
                bonftnpr2 = mlREADER("fsbnpr")
                bonftms500 = mlREADER("fsbms500")
                bonftms50014 = mlREADER("fsbms500-14")
            End If
            mlREADER.Close()

            bonft = 0
            p_one = 0
            p_tu = 1
            pred = 0
            p_tok = 2
            jumdir_ft = 0
            bonrefreg = 0
            jumdir_reg = 0
            If UCase(paket) = "NPR" Then
                bonft = 0
                pred = p_tu
                jumdir_ft = 0
                bonrefreg = bonftnpr
                jumdir_reg = 1
            Else
                If UCase(paket) = "NPR2" Then
                    bonft = 0
                    pred = p_tu
                    jumdir_ft = 0
                    bonrefreg = bonftnpr
                    jumdir_reg = 1
                Else
                    If UCase(paket) = "MS400-14" Then
                        bonft = bonftms50014
                        pred = p_tu
                        jumdir_ft = 1
                        bonrefreg = 0
                        jumdir_reg = 0
                    Else
                        If UCase(paket) = "MS200H-14" Or UCase(paket) = "MS200B-14" Or UCase(paket) = "MS200V-14" Or UCase(paket) = "MS200VS-14" Or UCase(paket) = "MS200-14" Or UCase(paket) = "MS200A-14" Then
                            bonft = bonftms50014
                            pred = p_tu
                            jumdir_ft = 1
                            bonrefreg = 0
                            jumdir_reg = 0
                        Else
                            If UCase(paket) = "MS500" Then
                                bonft = bonftms500
                                pred = p_tu
                                jumdir_ft = 1
                                bonrefreg = 0
                                jumdir_reg = 0
                            Else
                                If UCase(paket) = "MS500V-14" Then
                                    bonft = bonftms50014
                                    pred = p_tu
                                    jumdir_ft = 1
                                    bonrefreg = 0
                                    jumdir_reg = 0
                                Else
                                    If UCase(paket) = "FT7" Then
                                        bonft = bonft7
                                        pred = p_tu
                                        jumdir_ft = 1
                                        bonrefreg = 0
                                        jumdir_reg = 0
                                    Else
                                        If UCase(paket) = "FT8" Then
                                            bonft = bonft8
                                            pred = p_tu
                                            jumdir_ft = 1
                                            bonrefreg = 0
                                            jumdir_reg = 0
                                        Else
                                            If UCase(paket) = "FT11" Then
                                                bonft = bonft11
                                                pred = p_tu
                                                jumdir_ft = 1
                                                bonrefreg = 0
                                                jumdir_reg = 0
                                            Else
                                                If UCase(paket) = "FT12" Then
                                                    bonft = bonft12
                                                    pred = p_tu
                                                    jumdir_ft = 1
                                                    bonrefreg = 0
                                                    jumdir_reg = 0
                                                Else
                                                    If UCase(paket) = "FT88" Then
                                                        bonft = bonft88
                                                        pred = p_tu
                                                        jumdir_ft = 1
                                                        bonrefreg = 0
                                                        jumdir_reg = 0
                                                    Else
                                                        If UCase(paket) = "FT2" Then
                                                            bonft = bonft2
                                                            pred = p_one
                                                            jumdir_ft = 1
                                                            bonrefreg = 0
                                                            jumdir_reg = 0
                                                        Else
                                                            If UCase(paket) = "FT3" Then
                                                                bonft = bonft3
                                                                pred = p_one
                                                                jumdir_ft = 1
                                                                bonrefreg = 0
                                                                jumdir_reg = 0
                                                            Else
                                                                If UCase(paket) = "FT4" Then
                                                                    bonft = bonft4
                                                                    pred = p_one
                                                                    jumdir_ft = 1
                                                                    bonrefreg = 0
                                                                    jumdir_reg = 0
                                                                Else
                                                                    If UCase(paket) = "FT5" Then
                                                                        bonft = bonft5
                                                                        pred = p_one
                                                                        jumdir_ft = 1
                                                                        bonrefreg = 0
                                                                        jumdir_reg = 0
                                                                    Else
                                                                        If UCase(paket) = "FT6" Then
                                                                            bonft = bonft6
                                                                            pred = p_one
                                                                            jumdir_ft = 1
                                                                            bonrefreg = 0
                                                                            jumdir_reg = 0
                                                                        Else
                                                                            If UCase(paket) = "FT9" Then
                                                                                bonft = bonft9
                                                                                pred = p_one
                                                                                jumdir_ft = 1
                                                                                bonrefreg = 0
                                                                                jumdir_reg = 0
                                                                            Else
                                                                                If UCase(paket) = "FT10" Then
                                                                                    bonft = bonft10
                                                                                    pred = p_one
                                                                                    jumdir_ft = 1
                                                                                    bonrefreg = 0
                                                                                    jumdir_reg = 0
                                                                                Else
                                                                                    If UCase(paket) = "FT13" Then
                                                                                        bonft = bonft13
                                                                                        pred = p_tu
                                                                                        jumdir_ft = 1
                                                                                        bonrefreg = 0
                                                                                        jumdir_reg = 0
                                                                                    Else
                                                                                        If UCase(paket) = "FT14" Then
                                                                                            bonft = bonft14
                                                                                            pred = p_tu
                                                                                            jumdir_ft = 1
                                                                                            bonrefreg = 0
                                                                                            jumdir_reg = 0
                                                                                        Else
                                                                                            If UCase(paket) = "FT15" Then
                                                                                                bonft = bonft15
                                                                                                pred = p_tok
                                                                                                jumdir_ft = 1
                                                                                                bonrefreg = 0
                                                                                                jumdir_reg = 0
                                                                                            Else
                                                                                                If UCase(paket) = "FT16" Then
                                                                                                    bonft = bonft16
                                                                                                    pred = p_tok
                                                                                                    jumdir_ft = 1
                                                                                                    bonrefreg = 0
                                                                                                    jumdir_reg = 0
                                                                                                Else
                                                                                                    If UCase(paket) = "FT17" Then
                                                                                                        bonft = bonft17
                                                                                                        pred = p_tok
                                                                                                        jumdir_ft = 1
                                                                                                        bonrefreg = 0
                                                                                                        jumdir_reg = 0
                                                                                                    Else
                                                                                                        If UCase(paket) = "FT18" Then
                                                                                                            bonft = bonft18
                                                                                                            pred = p_tok
                                                                                                            jumdir_ft = 1
                                                                                                            bonrefreg = 0
                                                                                                            jumdir_reg = 0
                                                                                                        Else
                                                                                                            If UCase(paket) = "FT19" Then
                                                                                                                bonft = bonft19
                                                                                                                pred = p_tok
                                                                                                                jumdir_ft = 1
                                                                                                                bonrefreg = 0
                                                                                                                jumdir_reg = 0
                                                                                                            Else
                                                                                                                If UCase(paket) = "FT20" Then
                                                                                                                    bonft = bonft20
                                                                                                                    pred = p_tok
                                                                                                                    jumdir_ft = 1
                                                                                                                    bonrefreg = 0
                                                                                                                    jumdir_reg = 0
                                                                                                                Else
                                                                                                                    If UCase(paket) = "FT99" Then
                                                                                                                        bonft = bonft99
                                                                                                                        pred = p_tok
                                                                                                                        jumdir_ft = 1
                                                                                                                        bonrefreg = 0
                                                                                                                        jumdir_reg = 0
                                                                                                                    Else
                                                                                                                        If UCase(paket) = "FT100" Then
                                                                                                                            bonft = bonft100
                                                                                                                            pred = p_tu
                                                                                                                            jumdir_ft = 1
                                                                                                                            bonrefreg = 0
                                                                                                                            jumdir_reg = 0
                                                                                                                        Else
                                                                                                                            If UCase(paket) = "FT101" Then
                                                                                                                                bonft = bonft101
                                                                                                                                pred = p_tu
                                                                                                                                jumdir_ft = 1
                                                                                                                                bonrefreg = 0
                                                                                                                                jumdir_reg = 0
                                                                                                                            Else
                                                                                                                                If UCase(paket) = "FT102" Then
                                                                                                                                    bonft = bonft102
                                                                                                                                    pred = p_tu
                                                                                                                                    jumdir_ft = 1
                                                                                                                                    bonrefreg = 0
                                                                                                                                    jumdir_reg = 0
                                                                                                                                Else
                                                                                                                                    If UCase(paket) = "FT103" Then
                                                                                                                                        bonft = bonft103
                                                                                                                                        pred = p_tu
                                                                                                                                        jumdir_ft = 1
                                                                                                                                        bonrefreg = 0
                                                                                                                                        jumdir_reg = 0
                                                                                                                                    Else
                                                                                                                                        If UCase(paket) = "FT104" Then
                                                                                                                                            bonft = bonft104
                                                                                                                                            pred = p_tu
                                                                                                                                            jumdir_ft = 1
                                                                                                                                            bonrefreg = 0
                                                                                                                                            jumdir_reg = 0
                                                                                                                                        Else
                                                                                                                                            If UCase(paket) = "FT105" Then
                                                                                                                                                bonft = bonft105
                                                                                                                                                pred = p_tu
                                                                                                                                                jumdir_ft = 1
                                                                                                                                                bonrefreg = 0
                                                                                                                                                jumdir_reg = 0
                                                                                                                                            Else
                                                                                                                                                If UCase(paket) = "FT106" Then
                                                                                                                                                    bonft = bonft106
                                                                                                                                                    pred = p_tu
                                                                                                                                                    jumdir_ft = 1
                                                                                                                                                    bonrefreg = 0
                                                                                                                                                    jumdir_reg = 0
                                                                                                                                                Else
                                                                                                                                                    If UCase(paket) = "FT107" Then
                                                                                                                                                        bonft = bonft107
                                                                                                                                                        pred = p_tu
                                                                                                                                                        jumdir_ft = 1
                                                                                                                                                        bonrefreg = 0
                                                                                                                                                        jumdir_reg = 0
                                                                                                                                                    Else
                                                                                                                                                        If UCase(paket) = "FT108" Then
                                                                                                                                                            bonft = bonft108
                                                                                                                                                            pred = p_tu
                                                                                                                                                            jumdir_ft = 1
                                                                                                                                                            bonrefreg = 0
                                                                                                                                                            jumdir_reg = 0
                                                                                                                                                        Else
                                                                                                                                                            If UCase(paket) = "FT109" Then
                                                                                                                                                                bonft = bonft109
                                                                                                                                                                pred = p_tu
                                                                                                                                                                jumdir_ft = 1
                                                                                                                                                                bonrefreg = 0
                                                                                                                                                                jumdir_reg = 0
                                                                                                                                                            Else
                                                                                                                                                                If UCase(paket) = "FT110" Then
                                                                                                                                                                    bonft = bonft110
                                                                                                                                                                    pred = p_tu
                                                                                                                                                                    jumdir_ft = 1
                                                                                                                                                                    bonrefreg = 0
                                                                                                                                                                    jumdir_reg = 0
                                                                                                                                                                Else
                                                                                                                                                                    bonft = 0
                                                                                                                                                                    pred = 0
                                                                                                                                                                    jumdir_ft = 0
                                                                                                                                                                    bonrefreg = 0
                                                                                                                                                                    jumdir_reg = 0
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
                mlSQL2 = "insert into minggu_fsb(minggu,tahun,bulan_pajak,tahun_pajak,kta,amt,jumdir,amt_reg,jumdir_reg)values('" & perik_promo & "','" & nahun_promo & "','" & wulan_pajak & "','" & nahun_pajak & "','" & direk & "'" & vbCrLf
                mlSQL2 += ",'" & bonft & "','" & jumdir_ft & "','" & bonrefreg & "','" & jumdir_reg & "')"
            Else
                mlSQL2 = "update minggu_fsb set amt = '" & mlREADER("amt") + bonft & "',jumdir = '" & mlREADER("jumdir") + jumdir_ft & "',amt_reg = '" & mlREADER("amt_reg") + bonrefreg & "'" & vbCrLf
                mlSQL2 += ",jumdir_reg = '" & mlREADER("jumdir_reg") + jumdir_reg & "' where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()
        End If
    End Sub

    Sub RedempetionPoint()
        nilairp = 0
        If UCase(paket) = "MS200H-14" Or UCase(paket) = "MS200B-14" Or UCase(paket) = "MS200V-14" Or UCase(paket) = "MS200VS-14" Or UCase(paket) = "MS500" Or UCase(paket) = "MS200A-14" _
            Or UCase(paket) = "MS200-14" Or UCase(paket) = "MS500V-14" Or UCase(paket) = "MS400-14" Then
            nilairp = 8
        End If

        If nilairp > 0 Then
            mlSQL = "insert into tab_rp_sponsor(kta,direk,paket,point,tgl)values('" & direk & "','" & sinten & "','" & paket & "','" & nilairp & "','" & Format(Now, "yyyy-MM-dd") & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If
    End Sub

    Sub UpdateTableTemporary()
        tatanggalan = Day(Now.Date)
        If Len(tatanggalan) = 1 Then
            tatanggalan = "0" + CStr(tatanggalan)
        Else
            tatanggalan = tatanggalan
        End If

        wulandari = Month(Now.Date)
        If Len(wulandari) = 1 Then
            wulandari = "0" + CStr(wulandari)
        Else
            wulandari = wulandari
        End If

        taundari = Year(Now.Date)

        tanggalnateh = CStr(taundari) + CStr(wulandari) + CStr(tatanggalan)
        tanggalnateh = CLng(tanggalnateh)

        If tanggalnateh >= 20150701 And tanggalnateh <= 20150732 Then
            'if ucase(paket) = "MS200H-14" then
            poinms = 0
        Else
            poinms = 0
        End If

        mlSQL = "insert into temp_belum(nopos,noinvo,bulan,tahun,kta,postingup,pred,nambahkiri,nambahkanan,sta,asal,tipe,tgl,hendel,pvfull,mstour)values('" & mypos & "','" & noinvo & "','" & wulan & "','" & nahun & "'" & vbCrLf
        mlSQL += ",'" & sinten & "','" & jume & "','" & pred & "','" & nambahkiri & "','" & nambahkanan & "','B','REGN','REG','" & tglnyaaa & "','F','" & pvfull & "','" & poinms & "')"
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
    End Sub

    Sub CekPosisiDirectUpline()
        '''''''''''''''''''''''''''''''''''''''''''''''''
        ' cek apakah posisi direct upline sudah terisi
        '''''''''''''''''''''''''''''''''''''''''''''''''	
        nocross = "in1cr0sline"
        If subalo = "1" Then
            If psa = "L" Then
                aloce = aloc + "-2"
                pose = "L"
                aloc = aloce
                skl = 1
            Else
                If psa = "R" Then
                    aloce = aloc + "-3"
                    pose = "R"
                    aloc = aloce
                    skl = 2
                End If
            End If
        Else
            If subalo = "2" Then
                aloce = aloc + "-2"
                pose = psa
                aloc = aloce
                If psa = "L" Then
                    skl = 1
                Else
                    skl = 2
                End If
            Else
                If subalo = "3" Then
                    aloce = aloc + "-3"
                    pose = psa
                    aloc = aloce
                    If psa = "L" Then
                        skl = 1
                    Else
                        skl = 2
                    End If
                End If
            End If
        End If

        mlSQL = "Select ktaloc,posloc,kta FROM mylevel where ((ktaloc Like '" & aloce & "') and (posloc LIKE '" & pose & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            nocross = "0r4kokm45"
        Else
            nocross = "in1cr0sline"
            sopokui = mlREADER("kta")
        End If
        mlREADER.Close()

        If nocross = "in1cr0sline" Then
            l6 = "Mbuh"
            Response.Redirect("akt_failed.aspx?message=Maaf, penempatan yang dituju sudah terisi oleh distributor lain, yaitu nomor id :" & sopokui)
        Else
            l6 = "Ter6"
        End If

        If l1 = "Ter1" And l2 = "Ter2" And l3 = "Ter3" And l4 = "Ter4" And l5 = "Ter5" And l6 = "Ter6" Then
            kiwil = Right(aloc, 1)
            If uprane = "F" Then
                sba = "Bussines Center-1"
            Else
                If kiwil = "1" Then
                    sba = "Bussines Center-2"
                Else
                    If kiwil = "2" Then
                        sba = "Bussines Center-3"
                    End If
                End If
            End If

            If pose = "L" Then
                kiki = "Kaki Kiri"
            Else
                kiki = "Kaki Kanan"
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' cek tipe kartu dan konsekuensinya
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CekTipeKartu()


            '''''' CEK NOSERI ''''''
            CheckNoSeri()

            '''''''''''' END CEK NOSERI


            sinten = akhir
            al1 = CStr(sinten) + "-2"
            al2 = CStr(sinten) + "-3"

            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
            mlSQL = "INSERT INTO jenjang (kta,grdlevel,posakhir) VALUES ('" & sinten & "',1,0)"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            mlSQL = "SELECT * FROM member where asli like '" & akhir & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "Insert into member(kta,asli,pal1,pal2,uid,upme,tipene_kartu,tipene,thekey,joindt,direk,alok,pose,kaki,emel,telp,hp,ktp,tgllahir,kelamin,alamat,kota,propinsi,negara,kodepos,surat" & vbCrLf
                mlSQL2 += ",kotasurat,propinsisurat,negarasurat,kodepossurat,pasangan,ahliwaris,hubwaris,norekbank,namarek,bank,sta,unitbri,cabang,dc_asal,dc_registered,nonpwp,logke,regip,lastip,loginip,lastlog" & vbCrLf
                mlSQL2 += ",logindt,noinvo,foto,entry,ptkp)values('" & akhir & "','" & akhir & "','" & al1 & "','" & al2 & "','" & jenengmu & "','" & expra & "','" & kop & "','" & kop & "','" & pase & "'" & vbCrLf
                mlSQL2 += ",'" & tglaktif & "','" & direk & "','" & aloc & "','" & pose & "','" & skl & "','" & emel & "','" & notelp & "','" & nohape & "','" & nktp & "','" & lahirnya & "','" & kelamin & "'" & vbCrLf
                mlSQL2 += ",'" & alamat & "','" & kota & "','" & propinsi & "','Indonesia','" & kodepos & "','" & surat & "','" & kotasurat & "','" & propinsisurat & "','Indonesia','" & kodepossurat & "','" & pasangan & "'" & vbCrLf
                mlSQL2 += ",'" & ahliwaris & "','" & hubwaris & "','" & nrk & "','" & namarek & "','" & bnk & "','T','-','-','" & mypos & "','" & mypos & "','" & npwp & "',0" & vbCrLf
                mlSQL2 += ",'" & Request.ServerVariables("remote_addr") & "','" & Request.ServerVariables("remote_addr") & "','" & Request.ServerVariables("remote_addr") & "','" & tglaktif & "'" & vbCrLf
                mlSQL2 += ",'" & tglaktif & "','" & noinvo & "','-','" & loguser & "','F')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                Response.Redirect("akt_ready.aspx?id=" & akhir)
            End If
            mlREADER.Close()

            uplinemu = aloc
            poseupmu = pose
            uda = "F"
            sta = "T"

            mlSQL = "INSERT INTO mylevel (kta,ktaloc,posloc,sikil,ke) VALUES ('" & sinten & "','" & aloc & "','" & pose & "'," & skl & ",1)"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            mlSQL = "INSERT INTO mylevel (kta,ktaloc,posloc,sikil,ke) VALUES ('" & al1 & "','" & sinten & "','L',1,1)"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            mlSQL = "INSERT INTO mylevel (kta,ktaloc,posloc,sikil,ke) VALUES ('" & al2 & "','" & sinten & "','R',2,1)"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            If expra = "T" Then
                mlSQL = "INSERT INTO bonpas (kta,totkiri,totkanan) VALUES ('" & sinten & "',1,1)"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            Else
                mlSQL = "INSERT INTO bonpas (kta,totkiri,totkanan) VALUES ('" & sinten & "',0,0)"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
            End If

            ''''''''''''''''''''''''''''''
            ' BIKIN EXPIRED
            ''''''''''''''''''''''''''''''				 		 
            CreateExpired()


            '''''''''''''''''''''''''''
            ' update table transaksi
            '''''''''''''''''''''''''''
            UpdateTableTransaksi()


            ''''''''''''''''''''''''''''''
            ' bikin nomor invoice pajak
            ''''''''''''''''''''''''''''''
            CreateNomorInvoicePajak()


            ' STOCK AKTUAL PAKET PENDAFTARAN DC
            StockAktualPaketPendaftaranDC()


            ' KARTU STOCK PAKET PENDAFTARAN
            KartuStockPaketPendaftaran()

            ' UPDATE PRODUK PAKET PENDAFTARAN UNTUK SEJARAH SAJA
            UpdateProdukPaketPendaftaran()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' UPDATE STOCK AKTUAL DC SESUAI PAKET PENDAFTARAN PENDUKUNGNYA
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            UpdateStockAktualDC()




            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' UPDATE PV PRIBADI
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            UpdatePVPribadi()


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' sesi upgrade sponsor
            ' DIRECT SPONSOR UPDATE TABLE
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
            DirectSponsorUpdateTable()



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' FAST TRACK PLAN
            ' GANTI dan TAMBAH KODE PAKET BILA ADA LEBIH DARI 2 PAKET
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            FastTrackPlan()



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' redempetion point
            ' tambah paket bila ada paket baru yang memberikan point redempetion
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            RedempetionPoint()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' update table temporary untuk dieksekusi waktu muncul invoice
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''' poin 2 atau 2.5
            UpdateTableTemporary()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' START HERE FOR LOOPING UPLINE PVGRUP UPDATE
            ' BIKIN TABEL SASARAN UPDATE PARA UPLINENYA
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            piro = 0
            kedua = sinten
            mutere = 0
            jume = postingup
            levke = 0
            ulan = Month(tglku)
            ahun = Year(tglku)
            kdposna = kedua
            kdpos = akhir
            wulan = wulpos
            nahun = nuhun
            mlSQL = "SELECT direk FROM member WHERE kta LIKE '" & kdposna & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                sponsor = "-"
            Else
                sponsor = mlREADER("direk")
            End If
            mlREADER.Close()

            bulan = CInt(Date.Now.Month)
            piro = 0
            mutere = 0
            jume = postingup
            levke = 0


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

            If langsungposting = "T" Then ' bila langsungposting di setting T, maka hanya sampai upline langsung saja
                loopnya = 200000

                For aaxds = 1 To loopnya
                    mlSQL = "SELECT * FROM mylevel WHERE kta LIKE '" & kedua & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        aaxd = 200020
                        mlREADER.Close()
                        Exit For
                    Else
                        If mlREADER("ktaloc") = "A" Then
                            aax = 200020
                            ent = "F"
                            mlREADER.Close()
                            Exit For
                        Else
                            ent = "F"
                            piro = piro + 1
                            levke = levke + 1
                            kedua = mlREADER("ktaloc")
                            upnya = mlREADER("ktaloc")
                            posloc = mlREADER("posloc")
                            spld = mlREADER("ktaloc")
                            posef = mlREADER("posloc")
                            dowo = Len(spld)
                            mburi = Right(spld, 2)

                            staluup = UCase(mlREADER("sta"))

                            opoupnye = Right(upnya, 2)
                            If (opoupnye = "-2" Or opoupnye = "-3") Or (staluup = "F") Then
                                uplu = "F"
                                okelahklo = "T" ' biar bisa di recover setiap saat bila ada yang kelewat kena suspend
                            Else
                                uplu = "T"
                                okelahklo = "T"
                            End If


                            mlSQL2 = "INSERT INTO zmsbinary2014 (kta,upline,pose,bulan,tahun) VALUES ('" & kdposna & "','" & kedua & "','" & posef & "','" & ulan & "','" & ahun & "')"
                            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                            If spld = sponsor Then
                                mlSQL2 = "SELECT TOP 1 * FROM zmssponsor"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                mlREADER2.Read()
                                If Not mlREADER2.HasRows Then
                                    mlSQL3 = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)values" & vbCrLf
                                    If posef = "L" Then
                                        mlSQL3 += "('" & spld & "',1,0,'" & kdposna & "','" & sponsor & "','" & bulan & "')"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 += "('" & spld & "',0,1,'" & kdposna & "','" & sponsor & "','" & bulan & "')"
                                        End If
                                    End If
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                Else
                                    mlSQL3 = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)values" & vbCrLf
                                    If posef = "L" Then
                                        mlSQL3 += "('" & spld & "',1,0,'" & kdposna & "','" & sponsor & "','" & bulan & "')"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 += "('" & spld & "',0,1,'" & kdposna & "','" & sponsor & "','" & bulan & "')"
                                        End If
                                    End If
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                End If
                                mlREADER2.Close()
                            End If

                            mlSQL2 = "INSERT INTO zmemberbinary2014 (kta,upline,pose,bulan,tahun) VALUES ('" & sinten & "','" & kedua & "','" & posef & "','" & ulan & "','" & ahun & "')"
                            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                            If uplu = "T" Then
                                mlSQL2 = "SELECT * FROM temp_mstour where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                mlREADER2.Read()
                                If Not mlREADER2.HasRows Then
                                    mlSQL3 = "insert into temp_mstour(kta,kiri,kanan,bulan,tahun)values" & vbCrLf
                                    If posef = "L" Then
                                        mlSQL3 += "('" & spld & "','" & poinms & "',0,'" & wulan & "','" & nahun & "')"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 += "('" & spld & "',0,'" & poinms & ",'" & wulan & "','" & nahun & "')"
                                        End If
                                    End If
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                Else
                                    mlSQL3 = "update temp_mstour set"
                                    If posef = "L" Then
                                        mlSQL3 += "kiri = '" & mlREADER2("kiri") + poinms & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 += "kanan = '" & mlREADER2("kanan") + poinms & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                        End If
                                    End If
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                End If
                                mlREADER2.Close()


                                mlSQL2 = "SELECT * FROM bns_mypv_current WHERE ((kta LIKE '" & spld & "') and (bulan='" & wulan & "' and tahun = '" & nahun & "'))"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                mlREADER2.Read()
                                If Not mlREADER2.HasRows Then
                                    mlSQL3 = "insert into bns_mypv_current(kta,bulan,tahun,pvpribadi,produp,pvmurni,pvgrupkiri,pvgrupkanan,pvfull_kiri,pvfull_kanan)values" & vbCrLf
                                    mlSQL3 += "('" & spld & "','" & wulan & "','" & nahun & "',0,0,0" & vbCrLf
                                    If posef = "L" Then
                                        mlSQL3 = ",'" & jume & "',0,'" & pvfull & "',0)"
                                    Else
                                        mlSQL3 = ",0,'" & jume & "',0,'" & pvfull & "')"
                                    End If
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                Else
                                    If posef = "L" Then
                                        kiri = mlREADER2("pvgrupkiri") + jume
                                        kirifull = mlREADER2("pvfull_kiri") + pvfull
                                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
                                        mlSQL3 = "UPDATE bns_mypv_current SET pvgrupkiri = '" & kiri & "',pvfull_kiri = '" & kirifull & "'" & vbCrLf
                                        mlSQL3 += "WHERE(((bulan = " & wulan & ") And (tahun = " & nahun & ")) And (kta Like '" & spld & "'))"
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                        mlSQL3 = "UPDATE bonpas SET totkiri=totkiri+" & nambahkiri & "  WHERE kta like '" & spld & "'"
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                        'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                    Else
                                        If posef = "R" Then
                                            kanan = mlREADER2("pvgrupkanan") + jume
                                            kananfull = mlREADER2("pvfull_kanan") + pvfull
                                            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
                                            mlSQL3 = "UPDATE bns_mypv_current SET pvgrupkanan = '" & kanan & "',pvfull_kanan = '" & kananfull & "'" & vbCrLf
                                            mlSQL3 += "WHERE(((bulan = " & wulan & ") And (tahun = " & nahun & ")) And (kta Like '" & spld & "'))"
                                            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                            mlSQL3 = "UPDATE bonpas SET totkanan=totkanan+" & nambahkanan & " WHERE kta like '" & spld & "'"
                                            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                                        End If
                                    End If
                                End If
                                mlREADER2.Close()

                                If pred > 0 And (dowo = 7 Or dowo = 8) And opoupnye <> "-2" And opoupnye <> "-3" Then
                                    mlSQL2 = "SELECT * FROM bns_titirews2 where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                    mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                    mlREADER2.Read()
                                    If Not mlREADER2.HasRows Then
                                        mlSQL3 = "insert into bns_titirews2(kta,kiri,kanan,bulan,tahun,tupo,updt)values" & vbCrLf
                                        'rsALL.addnew
                                        If posef = "L" Then
                                            mlSQL3 += "('" & spld & "','" & pred & "',0,'" & wulan & "','" & nahun & "',0,'F')"
                                        Else
                                            If posef = "R" Then
                                                mlSQL3 += "('" & spld & "',0,'" & pred & "','" & wulan & "','" & nahun & "',0,'F')"
                                            End If
                                        End If
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                    Else
                                        mlSQL3 = "update bns_titirews2 set" & vbCrLf
                                        If posef = "L" Then
                                            mlSQL3 += "kiri = '" & mlREADER2("kiri") + pred & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                        Else
                                            If posef = "R" Then
                                                mlSQL3 += "kanan = '" & mlREADER2("kanan") + pred & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                            End If
                                        End If
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                    End If
                                    mlREADER2.Close()
                                End If
                            End If

                            If okelahklo = "T" And opoupnye <> "-2" And opoupnye <> "-3" Then
                                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
                                mlSQL2 = "INSERT INTO temp_all_trans (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull)" & vbCrLf
                                mlSQL2 += "VALUES('" & mypos & "'," & wulan & "," & nahun & ",'" & sinten & "','" & spld & "'," & jume & ",'" & posef & "','REG','B','" & noinvo & "'" & vbCrLf
                                mlSQL2 += ",'REGN','T'," & pred & "," & nambahkiri & "," & nambahkanan & "," & pvfull & ")"
                                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                            End If
                        End If
                    End If
                    mlREADER.Close()
                    aaxds = aaxds + 1
                    If aaxds > loopnya Then
                        Exit For
                    End If
                Next



                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								
                mlSQL = "DELETE from zmemberbinary2014 where upline like '%-%'"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                If langsungposting = "T" Then ' bila langsungposting di setting T, maka hanya sampai upline langsung saja
                    keo = "S"
                    oek = "T"
                    mlSQL = "UPDATE temp_belum SET hendel = '" & oek & "',sta = '" & keo & "' WHERE bulan = " & wulan & " and tahun = " & nahun & " and nopos like '" & mypos & "' and noinvo like '" & noinvo & "'"
                    mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                End If
                Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
            Else

                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
                mlSQL = "INSERT INTO temp_putus(nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull,mstour)VALUES" & vbCrLf
                mlSQL += "('" & mypos & "'," & wulan & "," & nahun & ",'" & sinten & "','" & sinten & "'," & jume & ",'" & posef & "','REG','B','" & noinvo & "','REGN','T'," & pred & "" & vbCrLf
                mlSQL += "," & nambahkiri & "," & nambahkanan & "," & pvfull & "," & poinms & ")"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia

            End If

            dino = Now()


            ''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''' akhir pendaftaran MS500 ''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''

            'ambil session pembelian 500 PV

            area = Session("pos_area")
            nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
            nodc = UCase(Session("motok"))
            Session("dcpusate") = dcpusat
            asale = Request("asal")
            dino = Now()
            kdpos = akhir
            namadis = jenengmu
            dc_asal = Session("dc_asal")

            namamu = Session("namamu")
            alamat = Session("alamat")
            kota = Session("kota")
            propinsi = Session("propinsi")
            kodepos = Session("kodepos")
            notelp = Session("notelp")
            nofax = Session("nofax")
            nohape = Session("nohape")
            emel = Session("emel")
            diskon = Session("diskon")
            zona = Session("zona")
            ggg = "zno"
            mlSQL = "SELECT *FROM tabdesc WHERE deskripsi Like '" & zona & "' and grp like '" & ggg & "'"
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

            jumtot = Session("jumtot")
            kkredit = Session("kkredit")
            tunai = Session("tunai")
            debit = Session("debit")
            bgcek = Session("bgcek")
            duite = Session("duite")
            kembalinye = Session("kembalinye")
            kemana = "mb4_perdana.aspx?menu_id=" & menu_id


            If mypos = dcHO Then
                namatabel = "st_kartustock"
                namatabel2 = "st_barang"
                stses = 7
            Else
                namatabel = "st_kartustock_ms"
                namatabel2 = "st_barang_ms"
                stses = 9
            End If

            nodcs = "MS-" + CStr(kdpos)
            mlSQL = "SELECT TOP 1 nourut FROM tabdesc_stockist order by nourut desc"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                nourmc = 1
            Else
                nourmc = mlREADER("nourut") + 1
            End If
            mlREADER.Close()

            mlSQL = "SELECT * FROM tabdesc_stockist WHERE ucase(nopos) LIKE '" & nodcs & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "insert into tabdesc_stockist(nopos,kta,kelas,nourut,cperson,alamat,kota,kodepos,propinsi,namadc,negara,telp,fax,emel" & vbCrLf
                mlSQL2 += ",website,joindt,sta,level,area,lastlog,lastip,logindt,loginip,logke,diskon,bonus,induk,indukmc,nama)values('" & nodcs & "'" & vbCrLf
                mlSQL2 += ",'" & kdpos & "','N','" & nourmc & "','" & UCase(namadis) & "','" & alamat & "','" & kota & "','" & kodepos & "','" & propinsi & "'" & vbCrLf
                mlSQL2 += ",'" & UCase(namadis) & "','Indonesia','" & notelp & "','" & nofax & "','" & emel & "','-','" & dino & "','T',1,'" & area & "'" & vbCrLf
                mlSQL2 += ",'" & Format(Now, "yyyy-MM-dd") & "','" & Request.ServerVariables("remote_addr") & "','" & Format(Now, "yyyy-MM-dd") & "'" & vbCrLf
                mlSQL2 += ", '" & Request.ServerVariables("remote_addr") & "',1,4,0,'" & indukdc & "','" & mypos & "','PT. HEALTH WEALTH INTERNATIONAL MS')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            mlSQL = "SELECT kta,thekey,uid FROM member WHERE kta Like '" & kdpos & "'"
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
                mlSQL2 = "insert into tabdesc_stockist_user(nopos,kta,gembok,lastlog,lastip,logindt,loginip,logke,nama,kat,foto)values('" & nodcs & "','" & UCase(namamu) & "'" & vbCrLf
                mlSQL2 += ",'" & kenalan & "','" & Format(Now, "yyyy-MM-dd") & "','" & Request.ServerVariables("remote_addr") & "','" & Format(Now, "yyyy-MM-dd") & "'" & vbCrLf
                mlSQL2 += ",'" & Request.ServerVariables("remote_addr") & "',0,'" & namaasli & "','mc','images/dc/blank.gif')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            bulanskr = CInt(Month(dino))
            tahunskr = CInt(Year(dino))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' START HERE FOR LOOPING UPLINE TOUR THAILAND
            ' BIKIN TABEL SASARAN UPDATE PARA UPLINENYA
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            mlSQL = "SELECT TOP 1 kta,tipene,tipene_kartu FROM member where kta Like '" & kdposna & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                mlSQL2 = "update member set tipene = 'p',tipene_kartu = 'p' where kta Like '" & kdposna & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()



            Session("namadis_mc") = ""
            Session("nokode_mc") = ""
            Session("area_mc") = ""

            Session("nosesifaxmc_pdn") = ""
            Session("noinvo") = noinvomc
            Session("asalnye") = asale
            Response.Redirect("sale_stater_inv.aspx?menu_id=" & menu_id)

        Else
            Session("sukses") = ""
            Session("noinvo_akt") = ""
            Session("nopos_akt") = ""
            Session("error") = "Terjadi kesalahan proses aktivasi, silahkan ulangi lagi"
            Response.Redirect("error1.aspx")
        End If
    End Sub
End Class

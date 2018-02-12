Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_akt_aknow_new
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlFUNCT As FunctionHWI
    Dim mlREADER, mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mlDATATABLE As DataTable
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim sort, pos_area, mypos, loguser, kelasdc, indukdc, namatabel, namatabel2, dcHO As String
    Dim dino, skr, lahirnya, tglaktif, tglnyaaa, expirednya, tglku, tglbayar As Date
    Dim bulanfee, tahunfee, x, jumbc, menu_id, muter As Double

    Dim tipekartu, ncrd, paket, pase, konfi, jenengmu, nktp, kelamin, tgllahir, bulanlahir, tahunlahir, alamat, kota, propinsi, kodepos, npwp, surat, kotasurat, propinsisurat As String
    Dim kodepossurat, notelp, nohape, pasangan, ahliwaris, hubwaris, emel, noinvo, bnk, nrk, namarek, direk, aloc, subalo, psa, lanjot1, lanjot2, gis, l1, l3, go, error1, dcpusat As String
    Dim akhir As Long

    Dim l2, nama_direk, error2, eml_direk, telp_direk, hp_direk, notelp_direk As String
    Dim uprane, error3, nama_aloc, alokmu, eml_aloc, telp_aloc, hp_aloc, notelp_aloc, l4, error4 As String

    Dim terusane, kedua, l5, error5, nocross, aloce, pose, sopokui, l6, kiwil, sba, kop, expra, kiki, tpe, pase1, pase2, ubahnoseri As String
    Dim skl, nilaibv, nilaipvnya, nambahkiri, nambahkanan As Double
    Dim totalpvna, feedc, hargabrg, kusus1, hargadc, kusus2, kusus3, kusus4, kusus5, produp, jumnoseri As Double
    Dim bulan, tahun, wulan, wulpos, nahun, nuhun, wultupo, nuhuntupo, CekNoSeri As Integer
    Dim pvnya, pvbulanan, pvfull, nilaipv, postingup, nilaipvpri, akhire, sinten, sapa, jume, bvne, pvpri, kdpos, stses, nourmc As Long
    Dim novo, al1, al2, kel, masterdc, k1, k2, tamb, nourutpjk, tipenya, sponsor, langsungposting, ent As String

    Dim tahskr, belek, tauk, belekan, tauge, nopajak, jk As Integer
    Dim nopa, expbln, expthn, lastday, jumak, awal, sisastok, pvprod, kiri, kirifull, kanan, kananfull As Double

    Dim npr, premium, regular, spot, promo, nppr, nppl, nreg, upg, titan, regpromo, premiumsp, platinumsp, prempromo As Double
    Dim tglini, bulanini, bulanikis, tauniki, perik_promo, nahun_promo, wulan_promo, wulan_pajak, nahun_pajak, bonft, pred, jumdir_ft, bonrefreg, jumdir_reg As Integer

    Dim tatanggalan, wulandari, taundari, tanggalnateh, nilairp, poinms, piro, mutere, levke, ulan, ahun, kdposna, loopnya, aaxd, aax As Double

    Dim vkta, vsponsorna As String
    Dim vkiri, vkanan, vmsna, vbulan, vtahun As Double

    Dim upnya, posloc, spld, posef, dowo, mburi, staluup, opoupnye, uplu, okelahklo, keo, oek, uplinemu, poseupmu, uda, sta As String

    Dim area, nosesifaxmc_pdn, nodc, asale, namadis, dc_asal, namamu, nofax, ggg, zona, l12, kemana, mskah, nodcs, kenalan, namaasli, noinvomc As String
    Dim diskon, jumtot, kkredit, tunai, debit, bgcek, duite, kembalinye As Double


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
        CekValidasiDirectSponsor()
        CekValidasiUplinePlacement()
        CekKetersediaanBC()
        CegahLintasJaringan()
    End Sub

    Sub PrepareData()
        tipekartu = "R"
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

        gis = "PRD"
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

        If paket = "" Then

            l3 = "Mbuh"
            Session("errorpos") = "Anda belum memilih paket pendaftaran"
            Response.Redirect("sale_stater_new.aspx?menu_id=" & menu_id)
        Else
            If Len(paket) >= 16 Then

                Session("errorpos") = "Anda belum memilih paket pendaftaran"
                l3 = "Mbuh"
                Response.Redirect("sale_stater_new.aspx?menu_id=" & menu_id)
            Else
                If ((Len(paket) <= 16) And (paket <> "")) Then
                    mlSQL = "SELECT * FROM st_tipe_paket_new where kode like '" & paket & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        go = "F"
                    Else
                        go = "T"
                    End If
                    mlREADER.Close()

                    If go = "F" Then
                        Session("errorpos") = "Paket ini bukan Paket pendaftaran baru"
                        l3 = "Mbuh"
                        Response.Redirect("sale_stater_new.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If


        'awalnye = left(ncrd,1)
        'if awalnye = 0 or awalnye = "0" then
        '	l1 = "Mbuh"
        '	response.redirect "akt_failed.asp?message=Nomor seri pendaftaran / nomor distributor belum anda isikan"
        'end if

        If ncrd = "" Then
            l1 = "Mbuh"
            Response.Redirect("akt_failed.aspx?message=Nomor seri pendaftaran / nomor distributor belum anda isikan")
        Else
            '	if isnumeric(ncrd)= False then
            '		l1 = "Mbuh"
            '		response.redirect "akt_failed.asp?message=Nomor seri pendaftaran / nomor distributor belum anda isikan"
            '	else
            '	if ((ncrd<>"") and (isnumeric(ncrd)= True)) then
            '		if len(ncrd) >= 8 then
            '			l1 = "Mbuh"	
            '			response.redirect "akt_failed.asp?message=Nomor seri pendaftaran / nomor distributor maksimal 7 karakter"	
            '		else
            '		if len(ncrd) <= 6 then
            '			l1 = "Mbuh"	
            '			response.redirect "akt_failed.asp?message=Nomor seri pendaftaran / nomor distributor minimal 7 karakter"	
            '		else		
            '			rs.Open "SELECT kta,uid FROM member WHERE asli = '"&ncrd&"'",conn
            '				If rs.bof Then 
            l1 = "Ter1"
            error1 = ""
            '				else
            '					l1 = "Mbuh"
            '					akhir = rs("kta")
            '					set rs=nothing
            '					Conn.Close
            '					set conn=nothing
            '					response.redirect "akt_ready.asp?id="&akhir						
            '				end if
            '			rs.close 
            '		end if
            '		end if
            '	else
            '		l1 = "Mbuh"
            '		response.redirect "akt_failed.asp?message=Nomor seri pendaftaran / nomor distributor belum anda isikan"			 
            '	end	if		
            '	end if
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

    Sub CekPosisiDirectUpline()
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

        mlSQL = "SELECT ktaloc,posloc,kta FROM mylevel where ((ktaloc LIKE '" & aloce & "') and (posloc LIKE '" & pose & "'))"
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
    End Sub

    Sub CekTipeKartuDanKonsekuensinya()
        gis = "PRD"
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
            totalpvna = mlREADER("pv")
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
            '	jumbc = clng(rs("jumbc")) ' 3BC di tiadakan
            '	if jumbc = 1 then
            '		expra = "F"
            '		nambahkiri = 1
            '		nambahkanan = 1
            '	else
            '	if jumbc = 3 then
            '		expra = "T"
            '		nambahkiri = 3
            '		nambahkanan = 3
            '	else
            '		expra = "F"
            '		nambahkiri = 1
            '		nambahkanan = 1					
            '	end if
            '	end if		
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

        '		akhir = ncrd
        '		sinten = akhir
        '		al1 = cstr(sinten)+"-2"
        '		al2 = cstr(sinten)+"-3"                                              

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

        mlSQL = "SELECT TOP 1 * FROM noseritemp order by noseri desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            akhir = 1889104
            mlSQL2 = "insert into noseritemp(noseri,noslip,nopos,tgl,kode,nama,direk,alok,subalo,kaki)values('" & akhir & "','" & noinvo & "','" & mypos & "'" & vbCrLf
            mlSQL2 += ",'" & tglaktif & "','" & paket & "','" & jenengmu & "','" & direk & "','" & aloc & "','" & pose & "','" & skl & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
            akhire = CLng(mlREADER("noseri")) + 1
            If akhire = 1888899 Or akhire = 2202443 Or akhire = 4600108 Or akhire = 7371056 Then
                akhir = akhire + 1
            Else
                akhir = akhire
            End If
            mlSQL2 = "insert into noseritemp(noseri,noslip,nopos,tgl,kode,nama,direk,alok,subalo,kaki)values('" & akhir & "','" & noinvo & "','" & mypos & "'" & vbCrLf
            mlSQL2 += ",'" & tglaktif & "','" & paket & "','" & jenengmu & "','" & direk & "','" & aloc & "','" & pose & "','" & skl & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
    End Sub

    Sub CekSeri()
        For CekNoSeri = 1 To 10
            ubahnoseri = "F"
            mlSQL = "SELECT count(id) as vid FROM noseritemp where noseri like '" & akhir & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
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

    Sub BikinExpired()

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

        mlSQL = "insert into bns_expired_member(kta,last_tupo_bulan,last_tupo_tahun,re_entry,tglexpired,direk,alok,kiri,kanan)values('" & akhir & "','" & Month(tglaktif) & "'" & vbCrLf
        mlSQL += ",'" & Year(tglaktif) & "','T','" & expirednya & "','" & direk & "','" & aloc & "',0,0)"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
    End Sub

    Sub NomorInvoicePajak()
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
                mlSQL += "And year(tgl)='" & tahskr & "' and (nopajak like '003.15%' or nopajak like '004.15%') order by nopajak desc"
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
            nopajak = ""
        End If

        nourutpjk = tamb + CStr(nopajak)

        mlSQL = "insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values('" & nopajak & "','" & mypos & "','" & noinvo & "','" & skr & "','AKT','RET','" & indukdc & "','" & nourutpjk & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        If mypos = "B-000" Then
            mlSQL = "insert into nourutkantor(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values(0,'" & mypos & "','" & noinvo & "','" & skr & "','" & tipenya & "','ODC','" & indukdc & "','000.16')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            mlSQL = "SELECT * FROM nourutkantor where noref like '" & noinvo & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                nourutpjk = "-"
            Else
                nopa = mlREADER("id")
                If nopa > 878409 Then
                    nopajak = nopa + 986089
                    nourutpjk = "031.16.0" + CStr(nopajak)
                Else
                    nopajak = nopa + 99029871
                    nourutpjk = "000.16." + CStr(nopajak)
                End If

                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

                mlSQL2 = "update nourutkantor SET urut = " & nopajak & ",nopajak = '" & nourutpjk & "' WHERE noref like '" & noinvo & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

        End If

        mlSQL = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            mlSQL2 = "update st_sale_daftar set noseri = '" & akhir & "',nopajak = '" & nourutpjk & "',pakai = 'T',pvpri = '" & nilaipvpri & "',alokbulan = '" & wultupo & "'" & vbCrLf
            mlSQL2 += ",aloktahun = '" & nuhuntupo & "',tipe = 'normal' where nopos like '" & mypos & "' and noslip like '" & noinvo & "'"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
        dino = Now()
    End Sub

    Sub StockAktualPaketPendaftaranDC()
        mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by kode DESC"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            jumak = 0
        Else
            jumak = mlREADER("jumlah")
            mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - 1 & "' where nopos like '" & mypos & "' and kode like '" & paket & "' order by kode DESC"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
    End Sub

    Sub KartuStockPaketPendaftaran()
        mlSQL = "SELECT TOP 3 * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by tgl DESC, id DESC"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
            mlSQL2 += ",0,1,'" & jumak - 1 & "','" & noinvo & "','Penjualan Pendaftaran DC')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
            awal = mlREADER("akhir")
            sisastok = awal - 1
            mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
            mlSQL2 += ",0,1,'" & sisastok & "','" & noinvo & "','Penjualan Pendaftaran DC')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
    End Sub
    Sub UpdatePVPribadi()
        sapa = sinten
        jume = postingup
        bvne = 0
        pvprod = produp
        pvpri = nilaipv

        mlSQL = "INSERT INTO bns_mypv_prod_reg (kta,bulan,tahun,produp)VALUES('" & sapa & "'," & wulan & "," & nahun & "," & pvprod & ")"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "INSERT INTO bns_mypv_current (kta,bulan,tahun,pvpribadi,produp,pvgrupkiri,pvgrupkanan,pvmurni) VALUES ('" & sapa & "'," & wulan & "," & nahun & "," & pvpri & "," & pvprod & ",0,0," & pvnya & ")"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
    End Sub

    Sub UpgradeSponsor()
        mlSQL = "SELECT * FROM bns_mybonref where ((kta like '" & direk & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            If paket = "PPL" Then
                npr = 0
                premium = 0
                regular = 0
                spot = 1
                promo = 0
                nppr = 0
                nppl = 0
                nreg = 0
                upg = 0
                titan = 0
                regpromo = 0
                premiumsp = 0
                platinumsp = 0
                prempromo = 0
            Else
                If paket = "PPR" Then
                    npr = 0
                    premium = 1
                    regular = 0
                    spot = 0
                    promo = 0
                    nppr = 0
                    nppl = 0
                    nreg = 0
                    upg = 0
                    titan = 0
                    regpromo = 0
                    premiumsp = 0
                    platinumsp = 0
                    prempromo = 0
                Else
                    If paket = "PRG" Or paket = "REG" Then
                        npr = 0
                        premium = 0
                        regular = 1
                        spot = 0
                        promo = 0
                        nppr = 0
                        nppl = 0
                        nreg = 0
                        upg = 0
                        titan = 0
                        regpromo = 0
                        premiumsp = 0
                        platinumsp = 0
                        prempromo = 0
                    Else
                        If paket = "NPPR" Then
                            npr = 0
                            premium = 0
                            regular = 0
                            spot = 0
                            promo = 0
                            nppr = 1
                            nppl = 0
                            nreg = 0
                            upg = 0
                            titan = 0
                            regpromo = 0
                            premiumsp = 0
                            platinumsp = 0
                            prempromo = 0
                        Else
                            If paket = "NPPL" Then
                                npr = 0
                                premium = 0
                                regular = 0
                                spot = 0
                                promo = 0
                                nppr = 0
                                nppl = 1
                                nreg = 0
                                upg = 0
                                titan = 0
                                regpromo = 0
                                premiumsp = 0
                                platinumsp = 0
                                prempromo = 0
                            Else
                                If paket = "NPRG" Then
                                    npr = 0
                                    premium = 0
                                    regular = 0
                                    spot = 0
                                    promo = 0
                                    nppr = 0
                                    nppl = 0
                                    nreg = 1
                                    upg = 0
                                    titan = 0
                                    regpromo = 0
                                    premiumsp = 0
                                    platinumsp = 0
                                    prempromo = 0
                                Else
                                    If paket = "UPG" Then
                                        npr = 0
                                        premium = 0
                                        regular = 0
                                        spot = 0
                                        promo = 0
                                        nppr = 0
                                        nppl = 0
                                        nreg = 0
                                        upg = 1
                                        titan = 0
                                        regpromo = 0
                                        premiumsp = 0
                                        platinumsp = 0
                                        prempromo = 0
                                    Else
                                        If paket = "TITANIUMSP" Then
                                            npr = 0
                                            premium = 0
                                            regular = 0
                                            spot = 0
                                            promo = 0
                                            nppr = 0
                                            nppl = 0
                                            nreg = 0
                                            upg = 0
                                            titan = 1
                                            regpromo = 0
                                            premiumsp = 0
                                            platinumsp = 0
                                            prempromo = 0
                                        Else
                                            If paket = "PPRG" Then
                                                npr = 0
                                                premium = 0
                                                regular = 0
                                                spot = 0
                                                promo = 0
                                                nppr = 0
                                                nppl = 0
                                                nreg = 0
                                                upg = 0
                                                titan = 0
                                                regpromo = 1
                                                premiumsp = 0
                                                platinumsp = 0
                                                prempromo = 0
                                            Else
                                                If paket = "PREMIUMSP" Then
                                                    npr = 0
                                                    premium = 0
                                                    regular = 0
                                                    spot = 0
                                                    promo = 0
                                                    nppr = 0
                                                    nppl = 0
                                                    nreg = 0
                                                    upg = 0
                                                    titan = 0
                                                    regpromo = 0
                                                    premiumsp = 1
                                                    platinumsp = 0
                                                    prempromo = 0
                                                Else
                                                    If paket = "PLATINUMSP" Then
                                                        npr = 0
                                                        premium = 0
                                                        regular = 0
                                                        spot = 0
                                                        promo = 0
                                                        nppr = 0
                                                        nppl = 0
                                                        nreg = 0
                                                        upg = 0
                                                        titan = 0
                                                        regpromo = 0
                                                        premiumsp = 0
                                                        platinumsp = 1
                                                        prempromo = 0
                                                    Else
                                                        If paket = "SUPERPROMO" Then
                                                            npr = 0
                                                            prempromo = 1
                                                            premium = 0
                                                            regular = 0
                                                            spot = 0
                                                            promo = 0
                                                            nppr = 0
                                                            nppl = 0
                                                            nreg = 0
                                                            upg = 0
                                                            titan = 0
                                                            regpromo = 0
                                                            premiumsp = 0
                                                            platinumsp = 0
                                                        Else
                                                            prempromo = 0
                                                            npr = 0
                                                            premium = 0
                                                            regular = 0
                                                            spot = 0
                                                            promo = 0
                                                            nppr = 0
                                                            nppl = 0
                                                            nreg = 0
                                                            upg = 0
                                                            titan = 0
                                                            regpromo = 0
                                                            premiumsp = 0
                                                            platinumsp = 0
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

            mlSQL2 = "insert into bns_mybonref(kta,bulan,tahun,npr,premium,regular,spot,promo,nppr,nppl,nreg,upg,titan,regpromo,premiumsp,platinumsp,prempromo)" & vbCrLf
            mlSQL2 += "values('" & direk & "','" & wulan & "','" & nahun & "','" & npr & "','" & premium & "','" & regular & "','" & spot & "','" & promo & "','" & nppr & "'" & vbCrLf
            mlSQL2 += ",'" & nppl & "','" & nreg & "','" & upg & "','" & titan & "','" & regpromo & "','" & premiumsp & "','" & platinumsp & "','" & prempromo & "')"
        Else
            'rs.update
            mlSQL2 = "update bns_mybonref set" & vbCrLf
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
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()
    End Sub

    Sub FastTrackPlan()
        If paket <> "" Then
            tglku = Now.Date
            tglini = Day(tglku)
            bulanini = Month(tglku)
            bulanikis = Month(tglku)
            tauniki = Year(tglku)

            mlSQL = "Select * FROM kapan where (((day(awal) = '" & tglini & "') and (month(awal) = '" & bulanini & "') and (year(awal) = '" & tauniki & "'))" & vbCrLf
            mlSQL += "Or ((day(t2) = '" & tglini & "') and (month(t2) = '" & bulanini & "') and (year(t2) = '" & tauniki & "')) or ((day(t3) = '" & tglini & "')" & vbCrLf
            mlSQL += "And (month(t3) = '" & bulanini & "') and (year(t3) = '" & tauniki & "')) or ((day(t4) = '" & tglini & "') and (month(t4) = '" & bulanini & "')" & vbCrLf
            mlSQL += "And (year(t4) = '" & tauniki & "')) or ((day(t5) = '" & tglini & "') and (month(t5) = '" & bulanini & "') and (year(t5) = '" & tauniki & "'))" & vbCrLf
            mlSQL += "Or ((day(t6) = '" & tglini & "') and (month(t6) = '" & bulanini & "') and (year(t6) = '" & tauniki & "')) or ((day(akhir) = '" & tglini & "')" & vbCrLf
            mlSQL += "And (month(akhir) = '" & bulanini & "') and (year(akhir) = '" & tauniki & "')))"
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

            bonft = 0
            pred = 0
            jumdir_ft = 0
            bonrefreg = 0
            jumdir_reg = 0

            Dim tip, mskah As String
            Dim fsb, nilairp, poinms As Integer

            mlSQL = "SELECT * FROM st_tipe_paket_new where kode like '" & paket & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                tip = "-"
                pred = 0
                fsb = 0
                nilairp = 0
                poinms = 0
            Else
                nilairp = mlREADER("bnsred")
                poinms = mlREADER("bnstour")
                tip = mlREADER("tipe")
                pred = mlREADER("bnspr")
                fsb = mlREADER("fsb")
            End If
            mlREADER.Close()

            If tip = "reg" Then
                bonft = 0
                pred = pred
                jumdir_ft = 0
                bonrefreg = fsb
                jumdir_reg = 1
                mskah = "F"
                tipekartu = "R"
            Else
                If tip = "newms" Then
                    bonft = 0
                    pred = pred
                    jumdir_ft = 0
                    bonrefreg = fsb
                    jumdir_reg = 1
                    mskah = "T"
                    tipekartu = "P"
                Else
                    If tip = "ms" Then
                        bonft = fsb
                        pred = pred
                        jumdir_ft = 1
                        bonrefreg = 0
                        jumdir_reg = 0
                        mskah = "T"
                        tipekartu = "P"
                    End If
                End If
            End If

            mlSQL = "SELECT * FROM minggu_fsb where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "insert into minggu_fsb(minggu,tahun,bulan_pajak,tahun_pajak,kta,amt,jumdir,amt_reg,jumdir_reg)values('" & perik_promo & "'" & vbCrLf
                mlSQL2 += ",'" & nahun_promo & "','" & wulan_pajak & "','" & nahun_pajak & "','" & direk & "','" & bonft & "','" & jumdir_ft & "','" & bonrefreg & "','" & jumdir_reg & "')"
            Else
                mlSQL2 = "update minggu_fsb set amt = '" & mlREADER("amt") + bonft & "',jumdir = '" & mlREADER("jumdir") + jumdir_ft & "',amt_reg = '" & mlREADER("amt_reg") + bonrefreg & "'" & vbCrLf
                mlSQL2 += ",jumdir_reg = '" & mlREADER("jumdir_reg") + jumdir_reg & "' where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()
        End If
    End Sub

    Sub RedemptionPoint()

        nilairp = 0
        mlSQL = "SELECT * FROM st_tipe_paket_new where kode like '" & paket & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            nilairp = 0
            poinms = 0
        Else
            nilairp = mlREADER("bnsred")
            poinms = mlREADER("bnstour")
        End If
        mlREADER.Close()

        If nilairp > 0 Then
            mlSQL = "insert into tab_rp_sponsor(kta,direk,paket,point,tgl)values('" & direk & "','" & sinten & "','" & paket & "','" & nilairp & "','" & Now & "')"
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
            poinms = poinms
        Else
            poinms = poinms
        End If

        mlSQL = "insert into temp_belum_order(nopos,noinvo,bulan,tahun,kta,postingup,pred,nambahkiri,nambahkanan,sta,asal,tipe,tgl,hendel,pvfull,mstour)values('" & mypos & "','" & noinvo & "'" & vbCrLf
        mlSQL += ",'" & wulan & "','" & nahun & "','" & sinten & "','" & jume & "','" & pred & "','" & nambahkiri & "','" & nambahkanan & "','B','REGN','REG','" & tglnyaaa & "'" & vbCrLf
        mlSQL += ",'F','" & pvfull & "','" & poinms & "')"
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

    Sub UpdateParaUpline()


        piro = 0
        kedua = sinten
        mutere = 0
        jume = postingup
        levke = 0
        tglku = Now()
        ulan = Month(tglku)
        ahun = Year(tglku)
        wulan = wulpos
        kdposna = akhir
        nahun = nuhun

        mlSQL = "SELECT direk FROM member WHERE kta Like '" & kdposna & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            sponsor = "-"
        Else
            sponsor = mlREADER("direk")
        End If
        mlREADER.Close()

        bulan = CInt(Now.Month)
        kedua = kdposna
        jume = postingup

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
                        opoupnye = Right(spld, 2)

                        If (opoupnye = "-2" Or opoupnye = "-3") Or (staluup = "F") Then
                            uplu = "F"
                            okelahklo = "T" ' biar bisa di recover setiap saat bila ada yang kelewat kena suspend
                        Else
                            uplu = "T"
                            okelahklo = "T"
                        End If


                        If spld = sponsor Then
                            mlSQL2 = "SELECT TOP 1 * FROM zmssponsor"
                            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Read()
                            If Not mlREADER2.HasRows Then
                                If posef = "L" Then
                                    vkta = spld
                                    vkiri = 1
                                    vkanan = 0
                                    vmsna = kdposna
                                    vsponsorna = sponsor
                                    vbulan = bulan
                                Else
                                    If posef = "R" Then
                                        vkta = spld
                                        vkiri = 0
                                        vkanan = 1
                                        vmsna = kdposna
                                        vsponsorna = sponsor
                                        vbulan = bulan
                                    End If
                                End If
                                mlSQL3 = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)values('" & vkta & "','" & vkiri & "','" & vkanan & "','" & vmsna & "','" & vsponsorna & "','" & vbulan & "')"
                                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                            Else
                                If posef = "L" Then
                                    vkta = spld
                                    vkiri = 1
                                    vkanan = 0
                                    vmsna = kdposna
                                    vsponsorna = sponsor
                                    vbulan = bulan
                                Else
                                    If posef = "R" Then
                                        vkta = spld
                                        vkiri = 0
                                        vkanan = 1
                                        vmsna = kdposna
                                        vsponsorna = sponsor
                                        vbulan = bulan
                                    End If
                                End If
                                mlSQL3 = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)values('" & vkta & "','" & vkiri & "','" & vkanan & "','" & vmsna & "','" & vsponsorna & "','" & vbulan & "')"
                                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                            End If
                            mlREADER2.Close()
                        End If



                        If uplu = "T" Then
                            mlSQL2 = "SELECT * FROM temp_mstour where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Read()
                            If Not mlREADER2.HasRows Then
                                If posef = "L" Then
                                    vkta = spld
                                    vkiri = poinms
                                    vkanan = 0
                                    vbulan = wulan
                                    vtahun = nahun
                                Else
                                    If posef = "R" Then
                                        vkta = spld
                                        vkiri = 0
                                        vkanan = poinms
                                        vbulan = wulan
                                        vtahun = nahun
                                    End If
                                End If
                                mlSQL3 = "insert into temp_mstour(kta,kiri,kanan,bulan,tahun)values('" & vkta & "','" & vkiri & "','" & vkanan & "','" & vbulan & "','" & vtahun & "')"
                                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                            Else
                                If posef = "L" Then
                                    mlSQL3 = "update temp_mstour set kiri = '" & mlREADER2("kiri") + poinms & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                Else
                                    If posef = "R" Then
                                        mlSQL3 = "update temp_mstour set kanan = '" & mlREADER2("kanan") + poinms & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                        mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                    End If
                                End If
                            End If
                            mlREADER2.Close()

                            mlSQL2 = "INSERT INTO zmsbinary2014 (kta,upline,pose,bulan,tahun) VALUES ('" & kdposna & "','" & kedua & "','" & posef & "','" & ulan & "','" & ahun & "')"
                            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                            mlSQL2 = "INSERT INTO zmemberbinary2014 (kta,upline,pose,bulan,tahun) VALUES ('" & sinten & "','" & kedua & "','" & posef & "','" & ulan & "','" & ahun & "')"
                            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)



                            mlSQL2 = "SELECT * FROM bns_mypv_current WHERE ((kta LIKE '" & spld & "') and (bulan='" & wulan & "' and tahun = '" & nahun & "'))"
                            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Read()
                            If Not mlREADER2.HasRows Then
                                mlSQL3 = "insert into bns_mypv_current(kta,bulan,tahun,pvpribadi,produp,pvmurni,pvgrupkiri,pvgrupkanan,pvfull_kiri,pvfull_kanan)values('" & spld & "','" & wulan & "'" & vbCrLf
                                mlSQL3 += ",'" & wulan & "','" & nahun & "',0,0,0" & vbCrLf
                                If posef = "L" Then
                                    mlSQL3 += ",'" & jume & "',0,'" & pvfull & "',0)"
                                Else
                                    mlSQL3 += ",0,'" & jume & "',0,'" & pvfull & "')"
                                End If
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

                            If pred > 0 And (dowo = 7 Or dowo = 8) And opoupnye <> "-2" And opoupnye <> "-3" Then
                                mlSQL2 = "SELECT * FROM bns_titirews2 where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                If Not mlREADER2.HasRows Then
                                    If posef = "L" Then
                                        mlSQL3 = "insert into bns_titirews2(kta,kiri,kanan,bulan,tahun,tupo,updt)values('" & spld & "','" & pred & "',0,'" & wulan & "','" & nahun & "',0,'F')"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 = "insert into bns_titirews2(kta,kiri,kanan,bulan,tahun,tupo,updt)values('" & spld & "',0,'" & pred & "','" & wulan & "','" & nahun & "',0,'F')"
                                        End If
                                    End If
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                Else
                                    If posef = "L" Then
                                        mlSQL3 = "update bns_titirews2 set kiri = '" & mlREADER2("kiri") + pred & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 = "update bns_titirews2 set kanan = '" & mlREADER2("kanan") + pred & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
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

                            mlSQL2 = "INSERT INTO temp_all_trans (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull) VALUES ('" & mypos & "'," & wulan & "" & vbCrLf
                            mlSQL2 += "," & nahun & ",'" & sinten & "','" & spld & "'," & jume & ",'" & posef & "','REG','B','" & noinvo & "','REGN','T'," & pred & "," & nambahkiri & "," & nambahkanan & "," & pvfull & ")"
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
            'rs.close 



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

        Else ' Kalo tidak posting langsung

            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

            mlSQL = "INSERT INTO temp_putus (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull,mstour) VALUES ('" & mypos & "'," & wulan & "" & vbCrLf
            mlSQL += "," & nahun & ",'" & sinten & "','" & sinten & "'," & jume & ",'" & posef & "','REG','B','" & noinvo & "','REGN','T'," & pred & "," & nambahkiri & "," & nambahkanan & "," & pvfull & "," & poinms & ")"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If
    End Sub

    Sub CegahLintasJaringan()

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

        '''''''''''''''''''''''''''''''''''''''''''''''''
        ' cek apakah posisi direct upline sudah terisi
        '''''''''''''''''''''''''''''''''''''''''''''''''	
        CekPosisiDirectUpline()

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
            CekTipeKartuDanKonsekuensinya()

            '''''' CEK NOSERI ''''''

            CekSeri()

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
                mlSQL2 = "insert into member(kta,asli,pal1,pal2,uid,upme,tipene_kartu,tipene,thekey,joindt,direk,alok,pose,kaki,emel,telp,hp,ktp,tgllahir,kelamin,alamat,kota,propinsi,negara,kodepos,surat,kotasurat" & vbCrLf
                mlSQL2 += ",propinsisurat,negarasurat,kodepossurat,pasangan,ahliwaris,hubwaris,norekbank,namarek,bank,sta,unitbri,cabang,dc_asal,dc_registered,nonpwp,logke,regip,lastip,loginip,lastlog,logindt,noinvo,foto,entry,ptkp)" & vbCrLf
                mlSQL2 += "values('" & akhir & "','" & akhir & "','" & al1 & "','" & al2 & "','" & jenengmu & "','" & expra & "','" & kop & "','" & kop & "','" & pase & "','" & tglaktif & "','" & direk & "','" & aloc & "','" & pose & "'" & vbCrLf
                mlSQL2 += ",'" & skl & "','" & emel & "','" & notelp & "','" & nohape & "','" & nktp & "','" & lahirnya & "','" & kelamin & "','" & alamat & "','" & kota & "','" & propinsi & "','Indonesia','" & kodepos & "','" & surat & "'" & vbCrLf
                mlSQL2 += ",'" & kotasurat & "','" & propinsisurat & "','Indonesia','" & kodepossurat & "','" & pasangan & "','" & ahliwaris & "','" & hubwaris & "','" & nrk & "','" & namarek & "','" & bnk & "','T','-','-'" & vbCrLf
                mlSQL2 += ",'" & mypos & "','" & mypos & "','" & npwp & "',0,'" & Request.ServerVariables("remote_addr") & "','" & Request.ServerVariables("remote_addr") & "','" & Request.ServerVariables("remote_addr") & "'" & vbCrLf
                mlSQL2 += ",'" & tglaktif & "','" & tglaktif & "','" & noinvo & "','-','" & loguser & "','F')"
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

                '		Call OpenDBG()
                '		strSQLG = "INSERT INTO bonpas (kta,totkiri,totkanan) VALUES ('"&al1&"',0,0)"
                '		Set rsG =  dBConnG.Execute(strSQLG)
                '		Call CloseDBG()

                '		Call OpenDBG()
                '		strSQLG = "INSERT INTO bonpas (kta,totkiri,totkanan) VALUES ('"&al2&"',0,0)"
                '		Set rsG =  dBConnG.Execute(strSQLG)
                '		Call CloseDBG()
            Else
                mlSQL = "INSERT INTO bonpas (kta,totkiri,totkanan) VALUES ('" & sinten & "',0,0)"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                '		Call OpenDBG()
                '		strSQLG = "INSERT INTO bonpas (kta,totkiri,totkanan) VALUES ('"&al1&"',0,0)"
                '		Set rsG =  dBConnG.Execute(strSQLG)
                '		Call CloseDBG()

                '		Call OpenDBG()
                '		strSQLG = "INSERT INTO bonpas (kta,totkiri,totkanan) VALUES ('"&al2&"',0,0)"
                '		Set rsG =  dBConnG.Execute(strSQLG)
                '		Call CloseDBG()	
            End If

            ''''''''''''''''''''''''''''''
            ' BIKIN EXPIRED
            ''''''''''''''''''''''''''''''				 		 
            BikinExpired()


            '''''''''''''''''''''''''''
            ' update table transaksi
            '''''''''''''''''''''''''''
            mlSQL = "SELECT dcinduk FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                indukdc = "B-000"
            Else
                indukdc = mlREADER("dcinduk")
            End If
            mlREADER.Close()


            ''''''''''''''''''''''''''''''
            ' bikin nomor invoice pajak
            ''''''''''''''''''''''''''''''
            NomorInvoicePajak()

            '''''' NO FEE DC dan MS (sudah keluar saat belanja ke DC)

            ' STOCK AKTUAL PAKET PENDAFTARAN DC
            StockAktualPaketPendaftaranDC()

            ' KARTU STOCK PAKET PENDAFTARAN
            KartuStockPaketPendaftaran()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' UPDATE PV PRIBADI
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            UpdatePVPribadi()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' sesi upgrade sponsor
            ' DIRECT SPONSOR UPDATE TABLE
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''                                                     
            UpgradeSponsor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' FAST TRACK PLAN
            ' GANTI dan TAMBAH KODE PAKET BILA ADA LEBIH DARI 2 PAKET
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            FastTrackPlan()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' redempetion point
            ' tambah paket bila ada paket baru yang memberikan point redempetion
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            RedemptionPoint()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' update table temporary untuk dieksekusi waktu muncul invoice
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''' poin 2 atau 2.5
            UpdateTableTemporary()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' START HERE FOR LOOPING UPLINE PVGRUP UPDATE
            ' BIKIN TABEL SASARAN UPDATE PARA UPLINENYA
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            UpdateParaUpline()


            ''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''' akhir pendaftaran MS500 ''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''

            ' ambil session pembelian 500 PV


            area = Session("pos_area")
            nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
            nodc = UCase(Session("motok"))
            Session("dcpusate") = dcpusat
            asale = Request("asal")
            dino = Now()
            kdpos = akhir
            namadis = jenengmu
            dc_asal = Session("dc_asal")
            kdposna = akhir
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


            mlSQL = "SELECT *FROM tabdesc WHERE deskripsi LIKE '" & zona & "' and grp like '" & ggg & "'"
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

            If mskah = "T" Then ' Apakah pendaftaran MS ?

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
                    mlSQL2 = "insert into tabdesc_stockist(nopos,kta,kelas,nourut,cperson,alamat,kota,kodepos,propinsi,namadc,negara,telp,fax,emel,website,joindt,sta,level,area,lastlog,lastip,logindt,loginip,logke,diskon,bonus,induk,indukmc,nama)" & vbCrLf
                    mlSQL2 += "values('" & nodcs & "','" & kdpos & "','N','" & nourmc & "','" & UCase(namadis) & "','" & alamat & "','" & kota & "','" & kodepos & "','" & propinsi & "','" & UCase(namadis) & "','Indonesia','" & notelp & "'" & vbCrLf
                    mlSQL2 += ",'" & nofax & "','" & emel & "','-','" & dino & "','T',1,'" & area & "','" & Now & "','" & Request.ServerVariables("remote_addr") & "','" & Now & "','" & Request.ServerVariables("remote_addr") & "'" & vbCrLf
                    mlSQL2 += ",1,4,0,'" & indukdc & "','" & mypos & "','PT. HEALTH WEALTH INTERNATIONAL MS')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

                mlSQL = "Select kta,thekey,uid FROM member WHERE kta Like '" & kdpos & "'"
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
                    mlSQL2 = "insert into tabdesc_stockist_user(nopos,kta,gembok,lastlog,lastip,logindt,loginip,logke,nama,kat,foto)values('" & nodcs & "','" & namamu & "','" & kenalan & "','" & Now & "'" & vbCrLf
                    mlSQL2 += ",'" & Request.ServerVariables("remote_addr") & "','" & Now & "','" & Request.ServerVariables("remote_addr") & "',0,'" & namaasli & "','mc','images/dc/blank.gif')"
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER.Close()

            End If ' END DAFTAR MSKAH

            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								

            mlSQL = "DELETE from zmsbinary2014 where upline Like '%-%'"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            mlSQL = "SELECT TOP 1 kta,tipene,tipene_kartu FROM member where kta like '" & kdposna & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                mlSQL2 = "update member set tipene = '" & tipekartu & "',tipene_kartu = '" & tipekartu & "' where kta like '" & kdposna & "'"
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

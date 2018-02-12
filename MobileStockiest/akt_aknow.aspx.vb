Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_akt_aknow
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
    Dim bulan, tahun, wulan, wulpos, nahun, nuhun, wultupo, nuhuntupo, CekNoSeri, tahunefek As Integer
    Dim pvnya, pvbulanan, pvfull, nilaipv, postingup, nilaipvpri, akhire, sinten, sapa, jume, bvne, pvpri, kdpos, stses, nourmc, jummurni As Long
    Dim novo, al1, al2, kel, masterdc, k1, k2, tamb, nourutpjk, tipenya, sponsor, langsungposting, ent, periodelama As String

    Dim tahskr, belek, tauk, belekan, tauge, nopajak, jk, bulanefek As Integer
    Dim nopa, expbln, expthn, lastday, jumak, awal, sisastok, pvprod, kiri, kirifull, kanan, kananfull As Double

    Dim npr, premium, regular, spot, promo, nppr, nppl, nreg, upg, titan, regpromo, premiumsp, platinumsp, prempromo As Double
    Dim tglini, bulanini, bulanikis, tauniki, perik_promo, nahun_promo, wulan_promo, wulan_pajak, nahun_pajak, bonft, pred, jumdir_ft, bonrefreg, jumdir_reg As Integer

    Dim tatanggalan, wulandari, taundari, tanggalnateh, nilairp, poinms, piro, mutere, levke, ulan, ahun, kdposna, loopnya, aaxd, aax As Double

    Dim vkta, vsponsorna, indukmc, vupdt As String
    Dim vkiri, vkanan, vmsna, vbulan, vtahun, vtupo As Double

    Dim upnya, posloc, spld, posef, dowo, mburi, staluup, opoupnye, uplu, okelahklo, keo, oek, uplinemu, poseupmu, uda, sta As String

    Dim area, nosesifaxmc_pdn, nodc, asale, namadis, dc_asal, namamu, nofax, ggg, zona, l12, kemana, mskah, nodcs, kenalan, namaasli, noinvomc As String
    Dim diskon, jumtot, kkredit, tunai, debit, bgcek, duite, kembalinye As Double

    Dim kode_prd1, kode_prd2, kode_prd3, kode_prd4, kode_prd5, kode_prd6, kode_prd7, kode_prd8, kode_prd9, kode_prd10, kode_prd11, kode_prd12 As String
    Dim jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10, jumlah11, jumlah12 As Double

    Dim vkode1, vkode2, vkode3, vkode4, vkode5, vkode6, vkode7, vkode8, vkode9, vkode10, vkode11, vkode12 As String
    Dim vjumlah1, vjumlah2, vjumlah3, vjumlah4, vjumlah5, vjumlah6, vjumlah7, vjumlah8, vjumlah9, vjumlah10, vjumlah11, vjumlah12 As Double

    Dim bonft1, bonft2, bonft3, bonft4, bonft5, bonft6, bonft7, bonft8, bonft9, bonft10, bonft11, bonft88, bonft12, bonft13, bonft14, bonft15, bonft16, bonft17, bonft18, bonft19, bonft20 As Double
    Dim bonftnpr, bonft99, bonft100, bonft101, bonft102, bonft103, bonft104, bonft105, bonft106, bonft107, bonft108, bonft109, bonft110, bonft111, bonft112, bonft113, bonftnpr2, bonftnpr3, bonftpr114, bonftpr214, bonft114, bonft214 As Double
    Dim p_one, p_tu, p_tok, mulai1, tahun1, noid, mulai2, tahun2, mulai3, tahun3, mulai4, tahun4, mulai5, tahun5, mulai6, tahun6, mulai7, tahun7 As Double

    Dim mailser, regips, strBody, eml, NoSeri, ipnya As String
    Dim gabung As Date
    Dim mail As Object

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
        skr = dino
        sort = Request("sort")
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

        namatabel = "st_barang_ms"
        namatabel2 = "st_kartustock_ms"

        Server.ScriptTimeout = 9000000
        Session.Timeout = 120
        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
        'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia

        PrepareData()
        CekValidasiDirekSponsor()
        CekValidasiUplinePlacement()
        CekKetersediaanBC()
        CegahLintasJaringan()
    End Sub

    Sub PrepareData()
        x = 0
        ncrd = Trim(Request("noseri"))
        paket = Trim(Request("paket"))
        'jumbc = trim(request("jumbc"))
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

        mlSQL = "SELECT id FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "' and noseri like '" & ncrd & "'"
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

    Sub CekValidasiDirekSponsor()
        '''''''''''''''''''''''''''''''''
        ' CEK KEVALIDAN DIRECT SPONSOR
        '''''''''''''''''''''''''''''''''
        'if ncrd = direk then
        '	response.redirect "akt_failed.asp?message=Anda tidak dapat mensponsori diri sendiri"
        'end if

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
                error4 = "Kesalahan penempatan"
                l4 = "Mbuh"
            End If
        End If
    End Sub

    Sub CekTipeKartu()
        gis = "AKT"
        paket = UCase(paket)
        mlSQL = "SELECT kode,kop,jumbc,bv,pv FROM st_barang where ((grp LIKE '" & gis & "') and (kode LIKE '" & paket & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            kop = "R"
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
            'jumbc = clng(rs("jumbc"))
            'if jumbc = 1 then
            '	expra = "F"
            '	nambahkiri = 1
            '	nambahkanan = 1
            'else
            'if jumbc = 3 then
            '	expra = "T"
            '	nambahkiri = 3
            '	nambahkanan = 3
            'else
            '	expra = "F"
            '	nambahkiri = 1
            '	nambahkanan = 1					
            'end if
            'end if		
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
                    tpe = "R"
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

        'if pvnya >= 200 then ' dapat productivity
        '	nilaipv = pvnya-25
        '	nilaibv = 0
        '	produp = 25
        '	postingup = pvnya-25
        '	nilaipvpri = pvnya-25
        'else
        nilaipv = pvnya
        nilaibv = 0
        produp = 0
        postingup = pvnya
        nilaipvpri = pvnya
        'end if

        pase1 = Right(nktp, 3)
        pase2 = Left(UCase(jenengmu), 3)
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

    Sub FunctionNoSeri()
        For CekNoSeri = 1 To 10
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
                    If mlREADER.HasRows Then
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

        '''''''''''' END CEK NOSERI


        sinten = akhir
        al1 = CStr(sinten) + "-2"
        al2 = CStr(sinten) + "-3"

        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

        mlSQL = "INSERT INTO jenjang (kta,grdlevel,posakhir) VALUES ('" & sinten & "',1,0)"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "SELECT * FROM member where asli = '" & akhir & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into member(kta,asli,pal1,pal2,uid,upme,tipene_kartu,tipene,thekey,joindt,direk,alok,pose,kaki,emel,telp,hp,ktp,tgllahir,kelamin,alamat,kota,propinsi,negara,kodepos,surat,kotasurat" & vbCrLf
            mlSQL2 += ",propinsisurat,negarasurat,kodepossurat,pasangan,ahliwaris,hubwaris,norekbank,namarek,bank,sta,unitbri,cabang,dc_asal,dc_registered,logke,regip,lastip,loginip,lastlog,logindt,noinvo,foto,entry,ptkp)" & vbCrLf
            mlSQL2 += "values('" & akhir & "','" & akhir & "','" & al1 & "','" & al2 & "','" & jenengmu & "','" & expra & "','" & kop & "','" & kop & "','" & pase & "','" & tglaktif & "','" & direk & "','" & aloc & "','" & pose & "'" & vbCrLf
            mlSQL2 += ",'" & skl & "','" & emel & "','" & notelp & "','" & nohape & "','" & nktp & "','" & lahirnya & "','" & kelamin & "','" & alamat & "','" & kota & "','" & propinsi & "','Indonesia','" & kodepos & "','" & surat & "'" & vbCrLf
            mlSQL2 += ",'" & kotasurat & "','" & propinsisurat & "','Indonesia','" & kodepossurat & "','" & pasangan & "','" & ahliwaris & "','" & hubwaris & "','" & nrk & "','" & namarek & "','" & bnk & "','T','-','-'" & vbCrLf
            mlSQL2 += ",'" & mypos & "','" & mypos & "',0,'" & Request.ServerVariables("remote_addr") & "','" & Request.ServerVariables("remote_addr") & "','" & Request.ServerVariables("remote_addr") & "'" & vbCrLf
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
    End Sub

    Sub UpdateTableTransaksi()
        mlSQL = "SELECT dcinduk FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            indukdc = "B-000"
        Else
            indukdc = mlREADER("dcinduk")
        End If
        mlREADER.Close()
    End Sub

    Sub NomorInvoicePajak()
        tahskr = CInt(Year(skr))
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

        mlSQL = "insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values('" & nopajak & "','" & mypos & "','" & noinvo & "','" & skr & "','AKT','RET','" & indukdc & "','" & nourutpjk & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

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
        If UCase(mypos) <> dcpusat Then ' bila DC kantor pusat tidak ada paket pendaftaran
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
            mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
            mlSQL2 += ",0,1,'" & jumak - 1 & "','" & noinvo & "','Penjualan Pendaftaran')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
            awal = mlREADER("akhir")
            sisastok = awal - 1
            If sisastok < 0 Then
                sisastok = 0
            Else
                sisastok = sisastok
            End If

            mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "','" & awal & "'" & vbCrLf
            mlSQL2 += ",0,1,'" & sisastok & "','" & noinvo & "','Penjualan Pendaftaran')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        End If
        mlREADER.Close()
    End Sub
    Sub UpdateProdukPaketPendaftaran()
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah1 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah1 & "','" & jumak - jumlah1 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah1
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd1 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah1 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd1 & "','" & jumlah1 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah2 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd2 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah2 & "','" & jumak - jumlah2 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah2
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd2 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah2 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd2 & "','" & jumlah2 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah3 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd3 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah3 & "','" & jumak - jumlah3 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah3
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd3 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah3 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd3 & "','" & jumlah3 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah4 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd4 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah4 & "','" & jumak - jumlah4 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah4
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd4 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah4 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd4 & "','" & jumlah4 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah5 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd5 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah5 & "','" & jumak - jumlah5 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah5
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd5 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah5 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd5 & "','" & jumlah5 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah6 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd6 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah6 & "','" & jumak - jumlah6 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah6
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd6 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah6 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd6 & "','" & jumlah6 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah7 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd7 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah7 & "','" & jumak - jumlah7 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah7
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd7 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah7 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd7 & "','" & jumlah7 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah8 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd8 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah8 & "','" & jumak - jumlah8 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah8
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd8 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah8 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd8 & "','" & jumlah8 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah9 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd9 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah9 & "','" & jumak - jumlah9 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah9
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd9 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah9 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd9 & "','" & jumlah9 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah10 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd10 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah10 & "','" & jumak - jumlah10 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah10
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd10 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah10 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd10 & "','" & jumlah10 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah11 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd11 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah11 & "','" & jumak - jumlah11 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah11
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd11 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah11 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd11 & "','" & jumlah11 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
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
                mlSQL2 = "update " & namatabel & " set jumlah = '" & mlREADER("jumlah") - jumlah12 & "' where nopos like '" & mypos & "' and kode like '" & kode_prd12 & "' order by kode DESC"
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
                mlSQL2 += ",0,'" & jumlah12 & "','" & jumak - jumlah12 & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Else
                awal = mlREADER("akhir")
                sisastok = awal - jumlah12
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If

                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd12 & "','" & mypos & "','" & dino & "','" & jumak & "'" & vbCrLf
                mlSQL2 += ",0,'" & jumlah12 & "','" & sisastok & "','" & noinvo & "','Produk Penjualan Pendaftaran')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()


            ' simpan produk rekap harian
            mlSQL = "insert into st_sale_daftar_rekap(tgl,nopos,kode,jumlah,noslip,dcinduk,nopajak)values('" & dino & "','" & mypos & "','" & kode_prd12 & "','" & jumlah12 & "','" & noinvo & "','" & indukdc & "','" & nourutpjk & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If


        mlSQL = "SELECT * FROM st_sale_daftar_prd where noslip like '" & noinvo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                vkode1 = kode_prd1
                vjumlah1 = jumlah1
            Else
                vkode1 = "-"
                vjumlah1 = 0
            End If
            If kode_prd2 <> "" Or kode_prd2 <> "-" Or IsDBNull(kode_prd2) = False Then
                vkode2 = kode_prd2
                vjumlah2 = jumlah2
            Else
                vkode2 = "-"
                vjumlah2 = 0
            End If
            If kode_prd3 <> "" Or kode_prd3 <> "-" Or IsDBNull(kode_prd3) = False Then
                vkode3 = kode_prd3
                vjumlah3 = jumlah3
            Else
                vkode3 = "-"
                vjumlah3 = 0
            End If
            If kode_prd4 <> "" Or kode_prd4 <> "-" Or IsDBNull(kode_prd4) = False Then
                vkode4 = kode_prd4
                vjumlah4 = jumlah4
            Else
                vkode4 = "-"
                vjumlah4 = 0
            End If
            If kode_prd5 <> "" Or kode_prd5 <> "-" Or IsDBNull(kode_prd5) = False Then
                vkode5 = kode_prd5
                vjumlah5 = jumlah5
            Else
                vkode5 = "-"
                vjumlah5 = 0
            End If
            If kode_prd6 <> "" Or kode_prd6 <> "-" Or IsDBNull(kode_prd6) = False Then
                vkode6 = kode_prd6
                vjumlah6 = jumlah6
            Else
                vkode6 = "-"
                vjumlah6 = 0
            End If
            If kode_prd7 <> "" Or kode_prd7 <> "-" Or IsDBNull(kode_prd7) = False Then
                vkode7 = kode_prd7
                vjumlah7 = jumlah7
            Else
                vkode7 = "-"
                vjumlah7 = 0
            End If
            If kode_prd8 <> "" Or kode_prd8 <> "-" Or IsDBNull(kode_prd8) = False Then
                vkode8 = kode_prd8
                vjumlah8 = jumlah8
            Else
                vkode8 = "-"
                vjumlah8 = 0
            End If
            If kode_prd9 <> "" Or kode_prd9 <> "-" Or IsDBNull(kode_prd9) = False Then
                vkode9 = kode_prd9
                vjumlah9 = jumlah9
            Else
                vkode9 = "-"
                vjumlah9 = 0
            End If
            If kode_prd10 <> "" Or kode_prd10 <> "-" Or IsDBNull(kode_prd10) = False Then
                vkode10 = kode_prd10
                vjumlah10 = jumlah10
            Else
                vkode10 = "-"
                vjumlah10 = 0
            End If
            If kode_prd11 <> "" Or kode_prd11 <> "-" Or IsDBNull(kode_prd11) = False Then
                vkode11 = kode_prd11
                vjumlah11 = jumlah11
            Else
                vkode11 = "-"
                vjumlah11 = 0
            End If
            If kode_prd12 <> "" Or kode_prd12 <> "-" Or IsDBNull(kode_prd12) = False Then
                vkode12 = kode_prd12
                vjumlah12 = jumlah12
            Else
                vkode12 = "-"
                vjumlah12 = 0
            End If
            mlSQL2 = "insert into st_sale_daftar_prd(noslip,tgl,nopajak,kode1,jumlah1,kode2,jumlah2,kode3,jumlah3,kode4,jumlah4,kode5,jumlah5,kode6,jumlah6,kode7,jumlah7,kode8,jumlah8,kode9,jumlah9,kode10,jumlah10,kode11,jumlah11,kode12,jumlah12,dcinduk)" & vbCrLf
            mlSQL2 += "values('" & noinvo & "','" & dino & "','" & nourutpjk & "','" & vkode1 & "','" & vjumlah1 & "','" & vkode2 & "','" & vjumlah2 & "','" & vkode3 & "','" & vjumlah3 & "','" & vkode4 & "','" & vjumlah4 & "'" & vbCrLf
            mlSQL2 += ",'" & vkode5 & "','" & vjumlah5 & "','" & vkode6 & "','" & vjumlah6 & "','" & vkode7 & "','" & vjumlah7 & "','" & vkode8 & "','" & vjumlah8 & "','" & vkode9 & "','" & vjumlah9 & "','" & vkode10 & "'" & vbCrLf
            mlSQL2 += ",'" & vjumlah10 & "','" & vkode11 & "','" & vjumlah11 & "','" & vkode12 & "','" & vjumlah12 & "','" & indukdc & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                vkode1 = kode_prd1
                vjumlah1 = jumlah1
            Else
                vkode1 = "-"
                vjumlah1 = 0
            End If
            If kode_prd2 <> "" Or kode_prd2 <> "-" Or IsDBNull(kode_prd2) = False Then
                vkode2 = kode_prd2
                vjumlah2 = jumlah2
            Else
                vkode2 = "-"
                vjumlah2 = 0
            End If
            If kode_prd3 <> "" Or kode_prd3 <> "-" Or IsDBNull(kode_prd3) = False Then
                vkode3 = kode_prd3
                vjumlah3 = jumlah3
            Else
                vkode3 = "-"
                vjumlah3 = 0
            End If
            If kode_prd4 <> "" Or kode_prd4 <> "-" Or IsDBNull(kode_prd4) = False Then
                vkode4 = kode_prd4
                vjumlah4 = jumlah4
            Else
                vkode4 = "-"
                vjumlah4 = 0
            End If
            If kode_prd5 <> "" Or kode_prd5 <> "-" Or IsDBNull(kode_prd5) = False Then
                vkode5 = kode_prd5
                vjumlah5 = jumlah5
            Else
                vkode5 = "-"
                vjumlah5 = 0
            End If
            If kode_prd6 <> "" Or kode_prd6 <> "-" Or IsDBNull(kode_prd6) = False Then
                vkode6 = kode_prd6
                vjumlah6 = jumlah6
            Else
                vkode6 = "-"
                vjumlah6 = 0
            End If
            If kode_prd7 <> "" Or kode_prd7 <> "-" Or IsDBNull(kode_prd7) = False Then
                vkode7 = kode_prd7
                vjumlah7 = jumlah7
            Else
                vkode7 = "-"
                vjumlah7 = 0
            End If
            If kode_prd8 <> "" Or kode_prd8 <> "-" Or IsDBNull(kode_prd8) = False Then
                vkode8 = kode_prd8
                vjumlah8 = jumlah8
            Else
                vkode8 = "-"
                vjumlah8 = 0
            End If
            If kode_prd9 <> "" Or kode_prd9 <> "-" Or IsDBNull(kode_prd9) = False Then
                vkode9 = kode_prd9
                vjumlah9 = jumlah9
            Else
                vkode9 = "-"
                vjumlah9 = 0
            End If
            If kode_prd10 <> "" Or kode_prd10 <> "-" Or IsDBNull(kode_prd10) = False Then
                vkode10 = kode_prd10
                vjumlah10 = jumlah10
            Else
                vkode10 = "-"
                vjumlah10 = 0
            End If
            If kode_prd11 <> "" Or kode_prd11 <> "-" Or IsDBNull(kode_prd11) = False Then
                vkode11 = kode_prd11
                vjumlah11 = jumlah11
            Else
                vkode11 = "-"
                vjumlah11 = 0
            End If
            If kode_prd12 <> "" Or kode_prd12 <> "-" Or IsDBNull(kode_prd12) = False Then
                vkode12 = kode_prd12
                vjumlah12 = jumlah12
            Else
                vkode12 = "-"
                vjumlah12 = 0
            End If
            mlSQL2 = "update st_sale_daftar_prd set kode1 = '" & vkode1 & "',jumlah1 = '" & vjumlah1 & "',kode2 = '" & vkode2 & "',jumlah2 = '" & vjumlah2 & "',kode3 = '" & vkode3 & "',jumlah3 = '" & vjumlah3 & "'" & vbCrLf
            mlSQL2 += ",kode4 = '" & vkode4 & "',jumlah4 = '" & vjumlah4 & "',kode5 = '" & vkode5 & "',jumlah5 = '" & vjumlah5 & "',kode6 = '" & vkode6 & "',jumlah6 = '" & vjumlah6 & "',kode7 = '" & vkode7 & "',jumlah7 = '" & vjumlah7 & "'" & vbCrLf
            mlSQL2 += ",kode8 = '" & vkode8 & "',jumlah8 = '" & vjumlah8 & "',kode9 = '" & vkode9 & "',jumlah9 = '" & vjumlah9 & "',kode10 = '" & vkode10 & "',jumlah10 = '" & vjumlah10 & "',kode11 = '" & vkode11 & "',jumlah11 = '" & vjumlah11 & "'" & vbCrLf
            mlSQL2 += ",kode12 = '" & vkode12 & "',jumlah12 = '" & vjumlah12 & "',nopajak = '" & nopajak & "' where noslip like '" & noinvo & "'"
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
        jummurni = pvnya

        mlSQL = "INSERT INTO bns_mypv_prod_reg (kta, bulan, tahun, produp) VALUES ('" & sapa & "'," & wulan & "," & nahun & "," & pvprod & ")"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "INSERT INTO bns_mypv_current (kta,bulan,tahun,pvpribadi,produp,pvgrupkiri,pvgrupkanan,pvmurni) VALUES ('" & sapa & "'," & wulan & "," & nahun & "," & pvpri & "," & pvprod & ",0,0," & pvnya & ")"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
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

    Sub DirectSponsorUpdateTable()
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
        If UCase(paket) = "PRMS2-14" Or UCase(paket) = "PRMS1-14" Or UCase(paket) = "PR12-14" Or UCase(paket) = "PR11-14" Or UCase(paket) = "PR10-14" Or UCase(paket) = "PR9-14" Or UCase(paket) = "PR8-14" Or UCase(paket) = "PRMS2S-14" Or UCase(paket) = "PRMS1S-14" Or UCase(paket) = "PR9S-14" Or UCase(paket) = "PR8S-14" Or UCase(paket) = "PR7-14" Or UCase(paket) = "PR6-14" Or UCase(paket) = "PR5-14" Or UCase(paket) = "PR4-14" Or UCase(paket) = "PR3-14" Or UCase(paket) = "FT2-14" Or UCase(paket) = "FT1-14" Or UCase(paket) = "PR2-14" Or UCase(paket) = "PR1-14" Or UCase(paket) = "NPR3" Or UCase(paket) = "NPR2" Or UCase(paket) = "FT101" Or UCase(paket) = "FT102" Or UCase(paket) = "FT103" Or UCase(paket) = "FT104" Or UCase(paket) = "FT105" Or UCase(paket) = "FT106" Or UCase(paket) = "FT107" Or UCase(paket) = "FT108" Or UCase(paket) = "FT109" Or UCase(paket) = "FT110" Or UCase(paket) = "FT111" Or UCase(paket) = "NPR" Or UCase(paket) = "FT99" Or UCase(paket) = "FT100" Or UCase(paket) = "FT13" Or UCase(paket) = "FT14" Or UCase(paket) = "FT15" Or UCase(paket) = "FT1" Or UCase(paket) = "FT7" Or UCase(paket) = "FT8" Or UCase(paket) = "FT11" Or UCase(paket) = "FT12" Or UCase(paket) = "FT88" Or UCase(paket) = "FT2" Or UCase(paket) = "FT3" Or UCase(paket) = "FT4" Or UCase(paket) = "FT5" Or UCase(paket) = "FT6" Or UCase(paket) = "FT9" Or UCase(paket) = "FT10" Or UCase(paket) = "FT16" Or UCase(paket) = "FT17" Or UCase(paket) = "FT18" Or UCase(paket) = "FT19" Or UCase(paket) = "FT20" Then
            tglku = Now.Date
            tglini = Day(tglku)
            bulanini = Month(tglku)
            bulanikis = Month(tglku)
            tauniki = Year(tglku)

            mlSQL = "SELECT * FROM kapan where (((day(awal) = '" & tglini & "') and (month(awal) = '" & bulanini & "') and (year(awal) = '" & tauniki & "')) or ((day(t2) = '" & tglini & "') and (month(t2) = '" & bulanini & "')" & vbCrLf
            mlSQL += "And (year(t2) = '" & tauniki & "')) or ((day(t3) = '" & tglini & "') and (month(t3) = '" & bulanini & "') and (year(t3) = '" & tauniki & "')) or ((day(t4) = '" & tglini & "') and (month(t4) = '" & bulanini & "')" & vbCrLf
            mlSQL += "And (year(t4) = '" & tauniki & "')) or ((day(t5) = '" & tglini & "') and (month(t5) = '" & bulanini & "') and (year(t5) = '" & tauniki & "')) or ((day(t6) = '" & tglini & "') and (month(t6) = '" & bulanini & "')" & vbCrLf
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
            bonftnpr2 = 0
            bonftnpr3 = 0
            bonftpr114 = 0
            bonftpr214 = 0
            bonft114 = 0
            bonft214 = 0


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
                bonftnpr2 = 0
                bonftnpr3 = 0
            Else
                bonftpr114 = mlREADER("pr1-14")
                bonftpr214 = mlREADER("pr2-14")
                bonft114 = mlREADER("ft1-14")
                bonft214 = mlREADER("ft2-14")
                bonftnpr3 = mlREADER("fsbnpr3")
                bonftnpr2 = mlREADER("fsbnpr2")
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
            If UCase(paket) = "PRMS2S-14" Or UCase(paket) = "PRMS1S-14" Or UCase(paket) = "PR9S-14" Or UCase(paket) = "PR8S-14" Or UCase(paket) = "PR7-14" Or UCase(paket) = "PR6-14" Or UCase(paket) = "PR2-14" Or UCase(paket) = "PR3-14" Or UCase(paket) = "PR4-14" Or UCase(paket) = "PR5-14" Then
                bonft = 0
                pred = p_tu
                jumdir_ft = 0
                bonrefreg = bonftpr214
                jumdir_reg = 1
            Else
                If UCase(paket) = "PRMS2-14" Or UCase(paket) = "PRMS1-14" Or UCase(paket) = "PR12-14" Or UCase(paket) = "PR11-14" Or UCase(paket) = "PR10-14" Or UCase(paket) = "PR9-14" Or UCase(paket) = "PR8-14" Or UCase(paket) = "PR1-14" Then
                    bonft = 0
                    pred = p_tu
                    jumdir_ft = 0
                    bonrefreg = bonftpr114
                    jumdir_reg = 1
                Else
                    If UCase(paket) = "FT2-14" Then
                        bonft = bonft214
                        pred = p_tu
                        jumdir_ft = 1
                        bonrefreg = 0
                        jumdir_reg = 0
                    Else
                        If UCase(paket) = "FT1-14" Then
                            bonft = bonft114
                            pred = p_tu
                            jumdir_ft = 1
                            bonrefreg = 0
                            jumdir_reg = 0
                        Else
                            If UCase(paket) = "NPR3" Then
                                bonft = 0
                                pred = p_tu
                                jumdir_ft = 0
                                bonrefreg = bonftnpr3
                                jumdir_reg = 1
                            Else
                                If UCase(paket) = "NPR2" Then
                                    bonft = 0
                                    pred = p_tu
                                    jumdir_ft = 0
                                    bonrefreg = bonftnpr2
                                    jumdir_reg = 1
                                Else
                                    If UCase(paket) = "NPR" Then
                                        bonft = 0
                                        pred = p_tu
                                        jumdir_ft = 0
                                        bonrefreg = bonftnpr
                                        jumdir_reg = 1
                                    Else
                                        If UCase(paket) = "FT1" Then
                                            bonft = bonft1
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
                End If
            End If

            mlSQL = "SELECT * FROM minggu_fsb where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                'rs.addnew
                mlSQL2 = "insert into minggu_fsb(minggu,tahun,bulan_pajak,tahun_pajak,kta,amt,jumdir,amt_reg,jumdir_reg)values('" & perik_promo & "','" & nahun_promo & "','" & wulan_pajak & "','" & nahun_pajak & "','" & direk & "'" & vbCrLf
                mlSQL2 += ",'" & bonft & "','" & jumdir_ft & "','" & bonrefreg & "','" & jumdir_reg & "')"
            Else
                'rs.update
                mlSQL2 = "update minggu_fsb set amt = '" & mlREADER("amt") + bonft & "',jumdir = '" & mlREADER("jumdir") + jumdir_ft & "',amt_reg = '" & mlREADER("amt_reg") + bonrefreg & "',jumdir_reg = '" & mlREADER("jumdir_reg") + jumdir_reg & "'" & vbCrLf
                mlSQL2 += "where minggu='" & perik_promo & "' and tahun='" & nahun_promo & "' and kta like '" & direk & "'"
            End If
            mlREADER.Close()
        End If
    End Sub

    Sub RedempetionPoint()
        If UCase(paket) = "PRMS2S-14" Or UCase(paket) = "PRMS1S-14" Or UCase(paket) = "PR9S-14" Or UCase(paket) = "PR8S-14" Or UCase(paket) = "PR7-14" Or UCase(paket) = "PR6-14" Or UCase(paket) = "NPR2" Or UCase(paket) = "PR2-14" Or UCase(paket) = "PR1-14" Or UCase(paket) = "PR3-14" Or UCase(paket) = "PR4-14" Or UCase(paket) = "PR5-14" Then
            nilairp = 1
        Else
            If UCase(paket) = "PRMS2-14" Or UCase(paket) = "PRMS1-14" Or UCase(paket) = "PR12-14" Or UCase(paket) = "PR11-14" Or UCase(paket) = "PR10-14" Or UCase(paket) = "PR9-14" Or UCase(paket) = "PR8-14" Or UCase(paket) = "NPR3" Then
                nilairp = 1
            Else
                If UCase(paket) = "FT102" Or UCase(paket) = "FT2-14" Or UCase(paket) = "FT1-14" Then
                    nilairp = 2
                Else
                    nilairp = 0
                End If
            End If
        End If

        If nilairp > 0 Then
            mlSQL = "insert into tab_rp_sponsor(kta,direk,paket,point,tgl)values('" & direk & "','" & sinten & "','" & paket & "','" & nilairp & "','" & Now & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If
    End Sub

    Sub UpdateTableTemporary()
        Dim vmstour As Double
        poinms = 0
        vmstour = 0
        ' cek ada POIN TOUR MS
        If UCase(paket) = "PRMS2-14" Or UCase(paket) = "PRMS1-14" Or UCase(paket) = "PRMS2S-14" Or UCase(paket) = "PRMS1S-14" Then
            'rs("mstour") = 0.5
            vmstour = 0.5
            poinms = 0.5
        End If
        mlSQL = "insert into temp_belum(nopos,noinvo,bulan,tahun,kta,postingup,pred,nambahkiri,nambahkanan,sta,asal,tipe,tgl,hendel,pvfull,mstour)values('" & mypos & "','" & noinvo & "','" & wulan & "','" & nahun & "'" & vbCrLf
        mlSQL += ",'" & sinten & "','" & jume & "','" & pred & "','" & nambahkiri & "','" & nambahkanan & "','B','REGN','REG','" & tglnyaaa & "','F','" & pvfull & "','" & vmstour & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        ' cek end		

        'if ucasE(paket) = "REG" then
        '	pred = 0
        '	nambahkiri = 1
        '	nambahkanan = 1
        'else
        pred = CLng(pred)
        nambahkiri = CLng(nambahkiri)
        nambahkanan = CLng(nambahkanan)
        'end if	

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' START HERE FOR LOOPING UPLINE PVGRUP UPDATE
            ' BIKIN TABEL SASARAN UPDATE PARA UPLINENYA
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            piro = 0
            kedua = sinten
            mutere = 0
            jume = postingup
            levke = 0
            tglku = Now()
            ulan = Month(tglku)
            ahun = Year(tglku)
            For aaxds = 1 To loopnya
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

                        mlSQL2 = "INSERT INTO zmemberbinary2014 (kta,upline,pose,bulan,tahun) VALUES ('" & sinten & "','" & kedua & "','" & posef & "','" & ulan & "','" & ahun & "')"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                        staluup = UCase(mlREADER("sta"))

                        opoupnye = Right(spld, 2)
                        If (opoupnye = "-2" Or opoupnye = "-3") Or (staluup = "F") Then
                            uplu = "F"
                            okelahklo = "T" ' biar bisa di recover setiap saat bila ada yang kelewat kena suspend
                        Else
                            uplu = "T"
                            okelahklo = "T"
                        End If


                        If okelahklo = "T" And opoupnye <> "-2" And opoupnye <> "-3" Then
                            If UCase(paket) = "PRMS2-14" Or UCase(paket) = "PRMS1-14" Or UCase(paket) = "PRMS2S-14" Or UCase(paket) = "PRMS1S-14" Then
                                mlSQL2 = "SELECT * FROM temp_mstour where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                mlREADER2.Read()
                                If Not mlREADER2.HasRows Then
                                    'rsALL.addnew
                                    If posef = "L" Then
                                        vkta = spld
                                        vkiri = 0.5
                                        vkanan = 0
                                        vbulan = wulan
                                        vtahun = nahun

                                    Else
                                        If posef = "R" Then
                                            vkta = spld
                                            vkiri = 0
                                            vkanan = 0.5
                                            vbulan = wulan
                                            vtahun = nahun
                                        End If
                                    End If
                                    mlSQL3 = "insert into temp_mstour(kta,kiri,kanan,bulan,tahun)values('" & vkta & "','" & vkiri & "','" & vkanan & "','" & vbulan & "','" & vtahun & "')"
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                    'rsALL.update
                                Else
                                    'rsALL.update
                                    mlSQL3 = "update temp_mstour set" & vbCrLf
                                    If posef = "L" Then
                                        mlSQL3 += "kiri = '" & mlREADER2("kiri") + 0.5 & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 += "kanan = '" & mlREADER2("kanan") + 0.5 & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                        End If
                                    End If
                                    'rsALL.update
                                End If
                                mlREADER2.Close()
                            End If
                        End If

                        If uplu = "T" Then
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

                            If pred > 0 And uplu = "T" Then
                                mlSQL2 = "SELECT * FROM bns_titirews2 where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                mlREADER2.Read()
                                If Not mlREADER2.HasRows Then
                                    'rsALL.addnew
                                    If posef = "L" Then
                                        vkta = spld
                                        vkiri = pred
                                        vkanan = 0
                                        vbulan = wulan
                                        vtahun = nahun
                                        vtupo = 0
                                        vupdt = "F"
                                    Else
                                        If posef = "R" Then
                                            vkta = spld
                                            vkiri = 0
                                            vkanan = pred
                                            vbulan = wulan
                                            vtahun = nahun
                                            vtupo = 0
                                            vupdt = "F"
                                        End If
                                    End If
                                    mlSQL3 = "insert into bns_titirews2(kta,kiri,kanan,bulan,tahun,tupo,updt)values('" & vkta & "','" & vkiri & "','" & vkanan & "','" & vbulan & "','" & vtahun & "','" & vtupo & "','" & vupdt & "')"
                                    mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                    'rsALL.update
                                Else
                                    'rsALL.update
                                    If posef = "L" Then
                                        mlSQL3 = "update bns_titirews2 set kiri = '" & mlREADER2("kiri") + pred & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                    Else
                                        If posef = "R" Then
                                            mlSQL3 = "update bns_titirews2 set kanan = '" & mlREADER2("kanan") + pred & "' where kta like '" & spld & "' and bulan='" & wulan & "' and tahun = '" & nahun & "'"
                                        End If
                                    End If
                                    'rsALL.update
                                End If
                                mlREADER2.Close()
                            End If
                        End If

                        If okelahklo = "T" And opoupnye <> "-2" And opoupnye <> "-3" Then
                            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								
                            mlSQL2 = "INSERT INTO temp_all_trans (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull)VALUES('" & mypos & "'," & wulan & "," & nahun & ",'" & sinten & "'" & vbCrLf
                            mlSQL2 += ",'" & spld & "'," & jume & ",'" & posef & "','REG','B','" & noinvo & "','REGN','T'," & pred & "," & nambahkiri & "," & nambahkanan & "," & pvfull & ")"
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
            mutere = piro * 2

            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia								
            mlSQL = "DELETE from zmemberbinary2014 where upline like '%-%'"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' update table temporary untuk dieksekusi waktu muncul invoice
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If langsungposting = "T" Then ' bila langsungposting di setting T, maka hanya sampai upline langsung saja
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
            mlSQL = "INSERT INTO temp_putus (nopos,bulan,tahun,kta,upnya,postingup,pose,asal,sta,noinvo,tipe,upd,pred,nambahkiri,nambahkanan,pvfull,mstour)VALUES('" & mypos & "'," & wulan & "," & nahun & ",'" & sinten & "','" & sinten & "'" & vbCrLf
            mlSQL += "," & jume & ",'" & posef & "','REG','B','" & noinvo & "','REGN','T'," & pred & "," & nambahkiri & "," & nambahkanan & "," & pvfull & "," & poinms & ")"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
        End If
    End Sub
    Sub UpdateTabelBNS_DepositDana()
        mlSQL = "insert into bns_depositdana(bulan,tahun,kta,pv,sta,nopos,noinvo,nopajak,periode)values('" & mulai1 & "','" & tahun1 & "','" & noid & "','" & pvbulanan & "','T','" & mypos & "','" & noinvo & "','" & nourutpjk & "','" & periodelama & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "insert into bns_depositdana(bulan,tahun,kta,pv,sta,nopos,noinvo,nopajak,periode)values('" & mulai2 & "','" & tahun2 & "','" & noid & "','" & pvbulanan & "','F','" & mypos & "','" & noinvo & "','" & nourutpjk & "','" & periodelama & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "insert into bns_depositdana(bulan,tahun,kta,pv,sta,nopos,noinvo,nopajak,periode)values('" & mulai3 & "','" & tahun3 & "','" & noid & "','" & pvbulanan & "','F','" & mypos & "','" & noinvo & "','" & nourutpjk & "','" & periodelama & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "insert into bns_depositdana(bulan,tahun,kta,pv,sta,nopos,noinvo,nopajak,periode)values('" & mulai4 & "','" & tahun4 & "','" & noid & "','" & pvbulanan & "','F','" & mypos & "','" & noinvo & "','" & nourutpjk & "','" & periodelama & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "insert into bns_depositdana(bulan,tahun,kta,pv,sta,nopos,noinvo,nopajak,periode)values('" & mulai5 & "','" & tahun5 & "','" & noid & "','" & pvbulanan & "','F','" & mypos & "','" & noinvo & "','" & nourutpjk & "','" & periodelama & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "insert into bns_depositdana(bulan,tahun,kta,pv,sta,nopos,noinvo,nopajak,periode)values('" & mulai6 & "','" & tahun6 & "','" & noid & "','" & pvbulanan & "','F','" & mypos & "','" & noinvo & "','" & nourutpjk & "','" & periodelama & "')"
        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

        mlSQL = "SELECT * FROM bns_depositrelease where ((kta like '" & noid & "') and (bulan = '" & wulan & "') and (tahun = '" & nahun & "'))"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into bns_depositrelease(kta,bulan,tahun,pvpri,pvprod,noinvo)values('" & noid & "','" & wulan & "','" & nahun & "','" & postingup & "','" & produp & "','" & noinvo & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
        End If
        mlREADER.Close()
    End Sub

    Sub KirimEmail()
        mailser = "F"
        If mailser = "T" Then ' ubah ini
            '' if emel <> "-" then
            gabung = tglaktif
            regips = Request.ServerVariables("remote_addr")
            strBody = ""
            Mail = Server.CreateObject("JMail.Message")
            Mail.Logging = True
            Mail.silent = True
            Mail.From = "donotreply@healthwealthint.com"
            Mail.FromName = "Distributor baru : " & akhir & ""
            Mail.AddRecipient(eml)
            Mail.Subject = "Selamat Datang : " & jenengmu & ""
            strBody = strBody + "<table border=1 cellpadding=2 width=800 style=border-collapse: collapse bordercolor=#808080>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td valign=top>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td height=15>"
            strBody = strBody + "<p align=center></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td>"
            strBody = strBody + "<p align=center>"
            strBody = strBody + "<img border=0 src=http://www.healthwealthint.com/images/health-wealthlogo.jpg width=186 height=125></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td>&nbsp;</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "<div align=center>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td valign=top>"
            strBody = strBody + "<div align=center>"
            strBody = strBody + "<table border=1 cellpadding=2 width=780 style=border-collapse: collapse bordercolor=#808080>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td bgcolor=#ECF2BB valign=middle>"
            strBody = strBody + "<table border=0 cellpadding=4 cellspacing=4 width=780>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td><font face=Arial size=2>Selamat datang dan bergabung di PT. Health Wealth International, berikut ini adalah "
            strBody = strBody + "duplikat data pendaftaran yang telah anda masukan. Anda dapat login ke distributor control panel untuk "
            strBody = strBody + "melakukan perubahan data, melengkapi data yang belum anda masukan dan memperoleh informasi upto date serta "
            strBody = strBody + "aktual mengenai bonus dan perkembangan jaringan anda. <font color=#FF0000><b>Untuk keamanan anda sendiri, segera "
            strBody = strBody + "rubah password login anda dengan password login anda sendiri.</b></font></font></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "</div>"
            strBody = strBody + "</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "</div>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td>&nbsp;</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "<div align=center>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td valign=top>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td width=55>"
            strBody = strBody + "<img border=0 src=http://www.healthwealthint.com/images/key_icon.gif width=48 height=30></td>"
            strBody = strBody + "<td width=727><b><font face=Arial size=2>DISTRIBUTOR CONTROL PANEL</font></b></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td><hr color=#808080 size=1></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td valign=top>"
            strBody = strBody + "<table border=1 width=782 cellpadding=2 style=border-collapse: collapse bordercolor=#808080>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Id. Distributor</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & akhir & " " & "</font></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Password Login</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & pase & " " & "</font></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>"
            strBody = strBody + "Web Replika</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>"
            strBody = strBody + "<a href=http://www.healthwealthint.com/?ref=" & NoSeri & " " & ">http://www.healthwealthint.com/?ref=" & NoSeri & " " & "</a></font></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td>&nbsp;</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td width=40>"
            strBody = strBody + "<img border=0 src=http://www.healthwealthint.com/images/ico_pribadi.gif width=30 height=30></td>"
            strBody = strBody + "<td valign=bottom width=742><b>"
            strBody = strBody + "<font face=Arial size=2>DATA PRIBADI</font></b></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "</td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td><hr color=#808080 size=1></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td valign=top>"
            strBody = strBody + "<table border=1 width=782 cellpadding=2 style=border-collapse: collapse bordercolor=#808080>"
            strBody = strBody + "<tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB>"
            strBody = strBody + "<font face=Arial size=2>Nama Lengkap</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & jenengmu & " " & "</font></td></tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Identitas</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=213><font face=Arial size=2>" & nktp & " " & "</font></td>"
            strBody = strBody + "<td width=47 bgcolor=#ECF2BB><font face=Arial size=2>Kelamin</font></td>"
            strBody = strBody + "<td width=7 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=91><font face=Arial size=2>" & kelamin & " " & "</font></td>"
            strBody = strBody + "<td width=94 bgcolor=#ECF2BB><font face=Arial size=2>Tgl. Lahir</font></td>"
            strBody = strBody + "<td width=-6 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=116><font face=Arial size=2>" & lahirnya & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Alamat</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & alamat & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Kota</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & kota & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Propinsi</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & propinsi & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Alamat Surat</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & surat & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Kota</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & kotasurat & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Propinsi</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & propinsisurat & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Telepon</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=373 colspan=4><font face=Arial size=2>" & notelp & " " & "</font></td>"
            strBody = strBody + "<td width=94 bgcolor=#ECF2BB><font face=Arial size=2>No. Handphone</font></td>"
            strBody = strBody + "<td width=9 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=116><font face=Arial size=2>" & nohape & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Nama Suami/Istri</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & pasangan & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Nama Ahli Waris</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & ahliwaris & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Hubungan AhliWaris</font></td><td width=15 bgcolor=#ECF2BB>"
            strBody = strBody + "<font face=Arial size=2>:</font></td><td width=605 colspan=7>"
            strBody = strBody + "<font face=Arial size=2>" & hubwaris & " " & "</font></td>"
            strBody = strBody + "</tr><tr>"
            strBody = strBody + "<td width=146 bgcolor=#ECF2BB><font face=Arial size=2>Alamat E-mail</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=605 colspan=7><font face=Arial size=2>" & emel & " " & "</font></td>"
            strBody = strBody + "</tr>"
            strBody = strBody + "</table></td></tr><tr><td>&nbsp;</td></tr><tr><td>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr><td width=40><img border=0 src=http://www.healthwealthint.com/images/ico_upline.gif width=30 height=30></td>"
            strBody = strBody + "<td valign=bottom width=742><b><font face=Arial size=2>INFORMASI SPONSOR (DIRECT SPONSOR)</font></b></td>"
            strBody = strBody + "</tr></table></td></tr><tr><td><hr color=#808080 size=1></td></tr><tr><td valign=top>"
            strBody = strBody + "<table border=1 width=782 cellpadding=2 style=border-collapse: collapse bordercolor=#808080><tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Id. Sponsor</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & direk & " " & "</font></td></tr><tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nama Distributor</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & nama_direk & " " & "</font></td></tr><tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Telepon</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & notelp_direk & " " & "</font></td></tr>"
            strBody = strBody + "</table></td></tr><tr><td>&nbsp;</td></tr><tr><td>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782><tr><td width=40>"
            strBody = strBody + "<img border=0 src=http://www.healthwealthint.com/images/ico_direk.gif width=30 height=30></td>"
            strBody = strBody + "<td valign=bottom width=742><b><font face=Arial size=2>INFORMASI PENEMPATAN (UPLINE PENEMPATAN)</font></b></td>"
            strBody = strBody + "</tr></table></td></tr><tr><td><hr color=#808080 size=1></td></tr><tr>"
            strBody = strBody + "<td valign=top><table border=1 width=782 cellpadding=2 style=border-collapse: collapse bordercolor=#808080>"
            strBody = strBody + "<tr><td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Id. Upline</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & alokmu & " " & "</font></td></tr>"
            strBody = strBody + "<tr><td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nama Distributor</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & nama_aloc & " " & "</font></td></tr><tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Telepon</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & notelp_aloc & " " & "</font></td>"
            strBody = strBody + "</tr><tr><td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Business Center</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & sba & " " & "</font></td></tr><tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Posisi Kaki</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & kiki & " " & "</font></td></tr></table></td></tr>"
            strBody = strBody + "<tr><td valign=top><table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr><td>&nbsp;</td></tr><tr><td>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782><tr>"
            strBody = strBody + "<td width=40><img border=0 src=http://www.healthwealthint.com/images/ico_rekbank.gif width=30 height=30></td>"
            strBody = strBody + "<td valign=bottom width=742><b><font face=Arial size=2>DATA REKENING BANK</font></b></td>"
            strBody = strBody + "</tr></table></td></tr></table></td></tr><tr>"
            strBody = strBody + "<td><hr color=#808080 size=1></td></tr><tr>"
            strBody = strBody + "<td valign=top><table border=1 width=782 style=border-collapse: collapse bordercolor=#808080 cellpadding=2><tr>"
            strBody = strBody + "<td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nama Lengkap Nasabah</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & namarek & " " & "</font></td></tr>"
            strBody = strBody + "<tr><td width=150 bgcolor=#ECF2BB>"
            strBody = strBody + "<font face=Arial size=2>Nama Bank</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & bnk & " " & "</font></td></tr>"
            strBody = strBody + "<tr><td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Nomor Rekening</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & nrk & " " & "</font></td></tr>"
            strBody = strBody + "</table></td></tr><tr><td><table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr><td>&nbsp;</td></tr><tr><td>"
            strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=782>"
            strBody = strBody + "<tr><td width=40><img border=0 src=http://www.healthwealthint.com/images/ico_pc.gif width=30 height=30></td>"
            strBody = strBody + "<td valign=bottom width=742><b><font face=Arial size=2>INFORMASI PENDAFTARAN</font></b></td>"
            strBody = strBody + "</tr></table></td></tr></table></td></tr><tr><td><hr color=#808080 size=1></td>"
            strBody = strBody + "</tr><tr><td valign=top><table border=1 width=782 cellpadding=2 style=border-collapse: collapse bordercolor=#808080>"
            strBody = strBody + "<tr><td width=150 bgcolor=#ECF2BB><font face=Arial size=2>Tanggal Pendaftaran</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & tglaktif & " " & "</font></td></tr>"
            strBody = strBody + "<tr><td width=150 bgcolor=#ECF2BB><font face=Arial size=2>IP. Address</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & ipnya & " " & "</font></td>"
            strBody = strBody + "</tr><tr><td width=150 bgcolor=#ECF2BB><font face=Arial size=2>DC</font></td>"
            strBody = strBody + "<td width=15 bgcolor=#ECF2BB><font face=Arial size=2>:</font></td>"
            strBody = strBody + "<td width=617><font face=Arial size=2>" & mypos & " " & "</font></td>"
            strBody = strBody + "</tr></table></td></tr><tr><td>&nbsp;</td></tr><tr>"
            strBody = strBody + "<td><i><font size=2 face=Arial color=#808080>copyright @I.T HWI (" & FormatDateTime(Now(), 2) & " " & ")</font></i></td>"
            strBody = strBody + "</tr></table></td></tr></table></div></td></tr>"
            strBody = strBody + "</table>"
            strBody = strBody + "<br><br></font>"
            Mail.HTMLBody = strBody

            If Not Mail.Send("mail.healthwealthint.com") Then
                'session("sukses") = akhir
                'response.redirect "akt_sukses.asp"
                Session("noinvo_akt") = noinvo
                Session("nopos_akt") = mypos
                Response.Redirect("sale_stater_inv.aspx?menu_id=" & menu_id)
            Else
                'session("sukses") = akhir
                'response.redirect "akt_sukses.asp"
                Session("noinvo_akt") = noinvo
                Session("nopos_akt") = mypos
                Response.Redirect("sale_stater_inv.aspx?menu_id=" & menu_id)
            End If

        Else
            'session("sukses") = akhir
            'response.redirect "akt_sukses.asp"
            Session("noinvo_akt") = noinvo
            Session("nopos_akt") = mypos
            Response.Redirect("sale_stater_inv.aspx?menu_id=" & menu_id)
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
                    mlREADER.Close()
                    Exit For
                Else
                    If mlREADER("ktaloc") = direk Then
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
            FunctionNoSeri()




            '''''''''''''''''''''''''''
            ' update table transaksi
            '''''''''''''''''''''''''''
            UpdateTableTransaksi()


            ''''''''''''''''''''''''''''''
            ' bikin nomor invoice pajak
            ''''''''''''''''''''''''''''''
            NomorInvoicePajak()



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


            ''''''''''''''''''''''''''''''
            ' BIKIN EXPIRED
            ''''''''''''''''''''''''''''''
            BikinExpired()

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
            UpdateTableTemporary()




            '''''''''''''''''''''''''''''''
            ' JIKA PAKET = TITAN
            '''''''''''''''''''''''''''''''
            If paket = "TITANIUMSP" Then

                periodelama = 6
                bulanefek = wulan
                tahunefek = nahun
                pvbulanan = nilaipvnya

                If bulanefek >= 1 And bulanefek <= 7 Then
                    mulai1 = bulanefek
                    mulai2 = bulanefek + 1
                    mulai3 = mulai2 + 1
                    mulai4 = mulai3 + 1
                    mulai5 = mulai4 + 1
                    mulai6 = mulai5 + 1
                    tahun1 = tahunefek
                    tahun2 = tahunefek
                    tahun3 = tahunefek
                    tahun4 = tahunefek
                    tahun5 = tahunefek
                    tahun6 = tahunefek
                Else
                    If bulanefek = 8 Then
                        mulai1 = 8
                        mulai2 = 9
                        mulai3 = 10
                        mulai4 = 11
                        mulai5 = 12
                        mulai6 = 1
                        tahun1 = tahunefek
                        tahun2 = tahunefek
                        tahun3 = tahunefek
                        tahun4 = tahunefek
                        tahun5 = tahunefek
                        tahun6 = tahunefek + 1
                    Else
                        If bulanefek = 9 Then
                            mulai1 = 9
                            mulai2 = 10
                            mulai3 = 11
                            mulai4 = 12
                            mulai5 = 1
                            mulai6 = 2
                            tahun1 = tahunefek
                            tahun2 = tahunefek
                            tahun3 = tahunefek
                            tahun4 = tahunefek
                            tahun5 = tahunefek + 1
                            tahun6 = tahunefek + 1
                        Else
                            If bulanefek = 10 Then
                                mulai1 = 10
                                mulai2 = 11
                                mulai3 = 12
                                mulai4 = 1
                                mulai5 = 2
                                mulai6 = 3
                                tahun1 = tahunefek
                                tahun2 = tahunefek
                                tahun3 = tahunefek
                                tahun4 = tahunefek + 1
                                tahun5 = tahunefek + 1
                                tahun6 = tahunefek + 1
                            Else
                                If bulanefek = 11 Then
                                    mulai1 = 11
                                    mulai2 = 12
                                    mulai3 = 1
                                    mulai4 = 2
                                    mulai5 = 3
                                    mulai6 = 4
                                    tahun1 = tahunefek
                                    tahun2 = tahunefek
                                    tahun3 = tahunefek + 1
                                    tahun4 = tahunefek + 1
                                    tahun5 = tahunefek + 1
                                    tahun6 = tahunefek + 1
                                Else
                                    If bulanefek = 12 Then
                                        mulai1 = 12
                                        mulai2 = 1
                                        mulai3 = 2
                                        mulai4 = 3
                                        mulai5 = 4
                                        mulai6 = 5
                                        tahun1 = tahunefek
                                        tahun2 = tahunefek + 1
                                        tahun3 = tahunefek + 1
                                        tahun4 = tahunefek + 1
                                        tahun5 = tahunefek + 1
                                        tahun6 = tahunefek + 1
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If

                '''''''''''''''''''''''''''''''''''''''''
                ' UPDATE TABLE BNS_DEPOSITDANA
                ' 6 BULAN
                '''''''''''''''''''''''''''''''''''''''''
                UpdateTabelBNS_DepositDana()

            End If ' end titan
            ''''''''''''''''''''''''''''''''''''
            ' end split deposit pv titan
            ''''''''''''''''''''''''''''''''''''

            'set rs=nothing
            'Conn.Close
            'set conn=nothing	
            KirimEmail()




        Else
            Session("sukses") = ""
            Session("noinvo_akt") = ""
            Session("nopos_akt") = ""
            Session("error") = "Terjadi kesalahan proses aktivasi, silahkan ulangi lagi"
            Response.Redirect("error1.aspx")
        End If
    End Sub
End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_akt_verify_new
    Inherits System.Web.UI.Page
    Dim mlFUNCT As FunctionHWI
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2 As String
    Dim mlDATATABLE As DataTable

    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlQuery As String
    Protected mlDR As OleDb.OleDbDataReader
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"

    Protected sort, pos_area, mypos, loguser, ncrd, paket, pase, konfi, nama, nktp, kelamin, tgllahir, bulanlahir, dc_asal, pose, namaalo, piye, aloc, telpdirek As String
    Protected tahunlahir, alamat, kota, propinsi, kodepos, surat, kotasurat, propinsisurat, kodepossurat, notelp, nohape As String
    Protected pasangan, ahliwaris, hubwaris, eml, bnk, nrk, namarek, npwp, kdposna, namamu, nofax, emel, diskon, zona As String
    Protected l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16, l17, l18, l19, l20, l21, l22, l22a, l23, l24, l25, l26, l27, l28, l29, l30, l31, l32, l33 As String
    Dim jumbc, strDayes, bcdirek, bcupline, subalo, muter, aax As Double
    Protected direk, namadirek, notelpdirek, tempat, kakidirek, kakiupline, idupline, notelpalo, psa, uprane, terusane, kedua As String
    Dim nocross, aloce, sopokui As String

    Protected noinvo As String
    Protected error2, error3, error4, error5, error6, error7, error8, error9, error10, error11, error12, error13, error14, error15, error16, error17, error18, error19, error20 As String
    Protected error21, error22, error22a, error23, error24, error25, error26, error27, error28, error29, error30, error31, error32, error33 As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

        sort = Request("sort")
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        noinvo = Request("noinvo")
        ncrd = Request("noseri")
        paket = Request("paket")
        'jumbc = request("jumbc")
        jumbc = 1
        pase = Request("password")
        konfi = Request("konfirmasi")

        nama = mlFUNCT.SafeSQL(UCase(Request("nama")))
        nktp = mlFUNCT.SafeSQL(UCase(Trim(Request("ktp"))))
        kelamin = mlFUNCT.SafeSQL(UCase(Request("kelamin")))
        tgllahir = Request("tgllahir")
        bulanlahir = Request("bulanlahir")
        tahunlahir = Request("tahunlahir")
        alamat = mlFUNCT.SafeSQL(UCase(Trim(Request("alamat"))))
        kota = mlFUNCT.SafeSQL(UCase(Trim(Request("kota"))))
        propinsi = mlFUNCT.SafeSQL(UCase(Trim(Request("propinsi"))))
        kodepos = mlFUNCT.SafeSQL(UCase(Trim(Request("kodepos"))))

        surat = mlFUNCT.SafeSQL(UCase(Trim(Request("surat"))))
        kotasurat = mlFUNCT.SafeSQL(UCase(Trim(Request("kotasurat"))))
        propinsisurat = mlFUNCT.SafeSQL(UCase(Trim(Request("propinsisurat"))))
        kodepossurat = mlFUNCT.SafeSQL(UCase(Trim(Request("kodepossurat"))))

        notelp = mlFUNCT.SafeSQL(UCase(Trim(Request("notelp"))))
        nohape = mlFUNCT.SafeSQL(UCase(Trim(Request("nohape"))))
        pasangan = mlFUNCT.SafeSQL(UCase(Trim(Request("pasangan"))))
        ahliwaris = mlFUNCT.SafeSQL(UCase(Trim(Request("ahliwaris"))))
        hubwaris = mlFUNCT.SafeSQL(UCase(Trim(Request("hubwaris"))))
        eml = mlFUNCT.SafeSQL(UCase(Trim(Request("email"))))

        bnk = mlFUNCT.SafeSQL(UCase(Trim(Request("namabank"))))
        nrk = mlFUNCT.SafeSQL(UCase(Trim(Request("norek"))))
        namarek = mlFUNCT.SafeSQL(UCase(Trim(Request("namarek"))))
        npwp = mlFUNCT.SafeSQL(UCase(Trim(Request("npwp"))))

        PrepareData()
        CekKetersediaanBC()
        CegahLintasJaringan()
    End Sub

    Sub PrepareData()
        If paket = "" Then
            l2 = "Mbuh"
            error2 = "Anda belum memilih paket pendaftaran"
        Else
            If Len(paket) >= 51 Then
                error2 = "Paket pendaftaran maksimal 50 karakter"
                l2 = "Mbuh"
            Else
                If ((Len(paket) <= 51) And (paket <> "")) Then
                    l2 = "Ter2"
                    error2 = ""
                End If
            End If
        End If

        mlSQL = "SELECT * FROM st_tipe_paket_new where kode like '" & paket & "' and tipe like 'MS'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
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
            Session("kdposna") = kdposna
            Session("namamu") = namamu
            Session("alamat") = alamat
            Session("kota") = kota
            Session("propinsi") = propinsi
            Session("kodepos") = kodepos
            Session("notelp") = notelp
            Session("nofax") = nofax
            Session("nohape") = nohape
            Session("emel") = emel
            Session("diskon") = diskon
            Session("zona") = zona
        End If
        mlREADER.Close()

        If noinvo = "" Then
            l2 = "Mbuh"
            error2 = "Anda belum memilih paket pendaftaran (nomor invoice tidak ditemukan dalam database)"
        Else
            If Len(noinvo) >= 51 Then
                error2 = "Nomor invoice maksimal 50 karakter"
                l2 = "Mbuh"
            Else
                If ((Len(noinvo) <= 51) And (noinvo <> "")) Then
                    l2 = "Ter2"
                    error2 = ""
                End If
            End If
        End If

        If jumbc = "" Then
            l3 = "Mbuh"
            error3 = "Anda belum mengisi jumlah BC"
        Else
            If IsNumeric(jumbc) = False Then
                l3 = "Mbuh"
                error3 = "Anda belum mengisi jumlah BC"
            Else
                If ((jumbc <> "") And (IsNumeric(jumbc) = True)) Then
                    l3 = "Ter3"
                    error3 = ""
                End If
            End If
        End If

        l4 = "Ter4"
        error4 = ""

        l5 = "Ter5"
        error5 = ""

        If nama = "" Then
            l6 = "Mbuh"
            error6 = "Anda belum mengisi nama lengkap anda"
        Else
            If Len(nama) >= 51 Then
                error6 = "Nama lengkap maksimal 50 karakter"
                l6 = "Mbuh"
            Else
                If ((Len(nama) <= 51) And (nama <> "")) Then
                    l6 = "Ter6"
                    error6 = ""
                End If
            End If
        End If

        If nktp = "" Then
            l7 = "Mbuh"
            error7 = "Nomor KTP belum anda isikan"
        Else
            If Len(nktp) >= 31 Then
                error7 = "Nomor KTP maksimal 30 karakter"
                l7 = "Mbuh"
            Else
                If ((Len(nktp) <= 31) And (nktp <> "")) Then
                    mlSQL = "SELECT ktp,kta FROM member WHERE ktp LIKE '" & nktp & "' and sta like 'T'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        l7 = "Ter7"
                        error7 = ""
                    Else
                        error7 = "Nomor KTP sudah digunakan distributor lain, mohon gunakan KTP yang lainnya"
                        l7 = "Mbuh"
                    End If
                    mlREADER.Close()
                End If
            End If
        End If
        'if isnumeric(nktp) = false then
        '	l7 = "Mbuh"
        '	error7 = "Nomor KTP harus bertipe numerik, minimal 5 karakter"
        'end if	

        If Len(nktp) <= 6 Then
            l7 = "Mbuh"
            error7 = "Nomor KTP harus bertipe numerik, minimal 5 karakter"
        End If


        If kelamin = "" Then
            l8 = "Mbuh"
            error8 = "Anda belum memilih jenis kelamin"
        Else
            If Len(kelamin) >= 16 Then
                error8 = "Jenis kelamin maksimal 15 karakter"
                l8 = "Mbuh"
            Else
                If ((Len(kelamin) <= 16) And (kelamin <> "")) Then
                    l8 = "Ter8"
                    error8 = ""
                End If
            End If
        End If

        If bulanlahir = 1 Or bulanlahir = 3 Or bulanlahir = 5 Or bulanlahir = 7 Or bulanlahir = 8 Or bulanlahir = 10 Or bulanlahir = 12 Then
            strDayes = 31
            l9 = "Ter9"
            l10 = "Ter10"
            l11 = "Ter11"
        Else
            If bulanlahir = 4 Or bulanlahir = 6 Or bulanlahir = 9 Or bulanlahir = 11 Then
                If tgllahir > 30 Then
                    l9 = "Mbuh"
                    error9 = "Invalid Date"
                Else
                    l9 = "Ter9"
                    error9 = ""
                End If
            Else
                If ((CInt(tahunlahir) Mod 4 = 0 And CInt(tahunlahir) Mod 100 <> 0) Or (CInt(tahunlahir) Mod 400 = 0)) Then
                    If tgllahir > 29 Then
                        l9 = "Mbuh"
                        error9 = "Invalid Date"
                    Else
                        l9 = "Ter9"
                        error9 = ""
                    End If
                Else
                    If tgllahir > 28 Then
                        l9 = "Mbuh"
                        error9 = "Invalid Date"
                    Else
                        l9 = "Ter9"
                        error9 = ""
                    End If
                End If
            End If
        End If

        If ((alamat = "") And (alamat <> "-")) Then
            'l10 = "Mbuh"
            'error10 = "Silahkan isikan alamat kontak anda"
            l10 = "Ter10"
            error10 = ""
            alamat = "-"
        Else
            If Len(alamat) >= 221 Then
                error10 = "Alamat kontak maksimal 220 karakter"
                l10 = "Mbuh"
            Else
                If ((Len(alamat) <= 221) And (alamat <> "")) Then
                    l10 = "Ter10"
                    error10 = ""
                End If
            End If
        End If

        If kota = "" Then
            'l11 = "Mbuh"
            'error11 = "Kota alamat belum anda isi"
            l11 = "Ter11"
            error11 = ""
            kota = "-"
        Else
            If Len(kota) >= 51 Then
                error11 = "Kota alamat maksimal 50 karakter"
                l11 = "Mbuh"
            Else
                If ((Len(kota) <= 51) And (kota <> "")) Then
                    l11 = "Ter11"
                    error11 = ""
                End If
            End If
        End If

        If propinsi = "" Then
            'l12 = "Mbuh"
            'error12 = "Silahkan pilih propinsi anda"
            l12 = "Ter12"
            error12 = ""
            propinsi = "-"
        Else
            If Len(propinsi) >= 81 Then
                error12 = "Propinsi maksimal 80 karakter"
                l12 = "Mbuh"
            Else
                If ((Len(propinsi) <= 81) And (propinsi <> "")) Then
                    l12 = "Ter12"
                    error12 = ""
                End If
            End If
        End If

        If kodepos = "" Then
            l13 = "Ter13"
            error13 = ""
            kodepos = "-"
        Else
            If Len(kodepos) >= 11 Then
                error13 = "Kodepos maksimal 10 karakter"
                l13 = "Mbuh"
            Else
                If ((Len(kodepos) <= 11) And (kodepos <> "")) Then
                    l13 = "Ter13"
                    error13 = ""
                End If
            End If
        End If

        If ((surat = "") And (surat <> "-")) Then
            'l14 = "Mbuh"
            'error14 = "Silahkan isikan alamat surat menyurat anda"
            l14 = "Ter14"
            error14 = ""
            surat = "-"
        Else
            If Len(surat) >= 221 Then
                error14 = "Alamat surat menyurat maksimal 220 karakter"
                l14 = "Mbuh"
            Else
                If ((Len(surat) <= 221) And (surat <> "")) Then
                    l14 = "Ter14"
                    error14 = ""
                End If
            End If
        End If

        If kotasurat = "" Then
            'l15 = "Mbuh"
            'error15 = "Kota alamat surat menyurat belum anda isi"
            l15 = "Ter15"
            error15 = ""
            kotasurat = "-"
        Else
            If Len(kotasurat) >= 51 Then
                error15 = "Kota alamat surat menyurat maksimal 50 karakter"
                l15 = "Mbuh"
            Else
                If ((Len(kotasurat) <= 51) And (kotasurat <> "")) Then
                    l15 = "Ter15"
                    error15 = ""
                End If
            End If
        End If

        If propinsisurat = "" Then
            'l16 = "Mbuh"
            'error16 = "Silahkan pilih propinsi surat menyurat anda"
            l16 = "Ter16"
            error16 = ""
            propinsisurat = "-"
        Else
            If Len(propinsisurat) >= 81 Then
                error16 = "Propinsi surat menyurat maksimal 80 karakter"
                l16 = "Mbuh"
            Else
                If ((Len(propinsisurat) <= 81) And (propinsisurat <> "")) Then
                    l16 = "Ter16"
                    error16 = ""
                End If
            End If
        End If

        If kodepossurat = "" Then
            'l17 = "Mbuh"
            'error17 = "Silahkan isikan kodepos surat menyurat anda"
            l17 = "Ter17"
            error17 = ""
            kodepossurat = "-"
        Else
            If Len(kodepossurat) >= 11 Then
                error17 = "Kodepos surat menyurat maksimal 10 karakter"
                l17 = "Mbuh"
            Else
                If ((Len(kodepossurat) <= 11) And (kodepossurat <> "")) Then
                    l17 = "Ter17"
                    error17 = ""
                End If
            End If
        End If

        If notelp = "" Then
            'l18 = "Mbuh"
            'error18 = "Silahkan isikan nomor telepon kontak"
            l18 = "Ter18"
            error18 = ""
            notelp = "-"
        Else
            If Len(notelp) >= 16 Then
                error18 = "Nomor telepon kontak maksimal 15 karakter"
                l18 = "Mbuh"
            Else
                If ((Len(notelp) <= 16) And (notelp <> "")) Then
                    l18 = "Ter18"
                    error18 = ""
                End If
            End If
        End If

        If nohape = "" Then
            l19 = "Ter19"
            error19 = ""
            nohape = "-"
        Else
            If Len(nohape) >= 16 Then
                error19 = "Nomor handphone kontak maksimal 15 karakter"
                l19 = "Mbuh"
            Else
                If ((Len(nohape) <= 16) And (nohape <> "")) Then
                    l19 = "Ter19"
                    error19 = ""
                End If
            End If
        End If

        If pasangan = "" Then
            l20 = "Ter20"
            error20 = ""
            pasangan = "-"
        Else
            If Len(pasangan) >= 51 Then
                error20 = "Nama suami/istri maksimal 50 karakter"
                l20 = "Mbuh"
            Else
                If ((Len(pasangan) <= 51) And (pasangan <> "")) Then
                    l20 = "Ter20"
                    error20 = ""
                End If
            End If
        End If

        If ahliwaris = "" Then
            'l21 = "Mbuh"
            'error21 = "Silahkan isikan nama ahli waris anda"
            l21 = "Ter21"
            error21 = ""
            ahliwaris = "-"
        Else
            If Len(ahliwaris) >= 51 Then
                error21 = "Nama ahli waris maksimal 50 karakter"
                l21 = "Mbuh"
            Else
                If ((Len(ahliwaris) <= 51) And (ahliwaris <> "")) Then
                    l21 = "Ter21"
                    error21 = ""
                End If
            End If
        End If

        If hubwaris = "" Then
            'l22 = "Mbuh"
            'error22 = "Pilih hubungan dengan ahli waris"
            l22 = "Ter22"
            error22 = ""
            hubwaris = "-"
        Else
            If Len(hubwaris) >= 21 Then
                error22 = "Hubungan ahli waris maksimal 20 karakter"
                l22 = "Mbuh"
            Else
                If ((Len(hubwaris) <= 51) And (hubwaris <> "")) Then
                    l22 = "Ter22"
                    error22 = ""
                End If
            End If
        End If

        If eml = "" Then
            l22a = "Ter22a"
            error22a = ""
            emel = "-"
        Else
            If Len(eml) >= 151 Then
                error22a = "Alamat email maksimal 150 karakter"
                l22a = "Mbuh"
                emel = eml
            Else
                If ((Len(eml) <= 151) And (eml <> "")) Then
                    l22a = "Ter22a"
                    error22a = ""
                    emel = eml
                End If
            End If
        End If

        bnk = Request("namabank")
        nrk = Request("norek")
        namarek = Request("namarek")
        If namarek = "" Then
            'l30 = "Mbuh"
            'error30 = "Silahkan isi atas nama rekening bank anda"
            l30 = "Ter30"
            error30 = ""
            namarek = "-"
        Else
            If Len(namarek) >= 51 Then
                error30 = "Atas nama rekening maksimal 50 karakter"
                l30 = "Mbuh"
            Else
                If ((Len(namarek) <= 51) And (namarek <> "")) Then
                    l30 = "Ter30"
                    error30 = ""
                End If
            End If
        End If

        If bnk = "" Then
            'l31 = "Mbuh"
            'error31 = "Silahkan pilih bank anda"
            l31 = "Ter31"
            error31 = ""
            bnk = "-"
        Else
            If Len(bnk) >= 50 Then
                error31 = "Nama Bank maksimal 50 karakter"
                l31 = "Mbuh"
            Else
                If ((Len(bnk) <= 51) And (bnk <> "")) Then
                    l31 = "Ter31"
                    error31 = ""
                End If
            End If
        End If

        If nrk = "" Then
            'l32 = "Mbuh"
            'error32 = "Silahkan isikan nomor rekening bank anda"
            l32 = "Ter32"
            error32 = ""
            nrk = "-"
        Else
            If Len(nrk) >= 50 Then
                error32 = "Nomor rekening bank maksimal 50 karakter"
                l32 = "Mbuh"
            Else
                If ((Len(nrk) <= 51) And (nrk <> "")) Then
                    l32 = "Ter32"
                    error32 = ""
                End If
            End If
            If IsNumeric(nrk) = False Then
                error32 = "Nomor rekening bank harus angka saja (numerik)"
                l32 = "Mbuh"
            End If
        End If

        If npwp = "" Then
            l33 = "Ter33"
            error33 = ""
            npwp = "-"
        Else
            If Len(npwp) >= 16 Then
                error33 = "Nomor NPWP maksimal 15 karakter"
                l33 = "Mbuh"
            Else
                If ((Len(npwp) <= 51) And (npwp <> "")) Then
                    l33 = "Ter33"
                    error33 = ""
                End If
            End If
            If IsNumeric(npwp) = False Then
                error33 = "Nomor NPWP harus angka saja (numerik)"
                l33 = "Mbuh"
            End If
        End If

        direk = mlFUNCT.SafeSQL(Request("direk"))
        namadirek = Request("namadirek")
        notelpdirek = Request("telpdirek")

        tempat = Request("tempat")

        'bcdirek = request("bcdirek")
        bcdirek = "1"
        kakidirek = Request("kakidirek")

        'bcupline = request("bcupline")
        bcupline = "1"
        kakiupline = Request("kakiupline")
        idupline = Request("upline")

        If direk = "" Then
            l23 = "Mbuh"
            error23 = "Mohon isikan nomor id distributor sponsor"
        Else
            If Len(direk) >= 21 Then
                error23 = "Nomor id distributor sponsor maksimal 20 karakter"
                l23 = "Mbuh"
            Else
                If ((Len(direk) <= 21) And (direk <> "")) Then
                    mlSQL = "SELECT kta,uid,telp FROM member WHERE kta LIKE '" & direk & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        error23 = "Nomor id distributor sponsor tidak ditemukan"
                        l23 = "Mbuh"
                        namadirek = ""
                        notelpdirek = ""
                    Else
                        l23 = "Ter23"
                        error23 = ""
                        namadirek = mlREADER("uid")
                        notelpdirek = mlREADER("telp")
                    End If
                    mlREADER.Close()
                End If
            End If
        End If

        'if direk = ncrd then
        '	l23 = "Mbuh"
        '	error23 = "Mohon isikan nomor id distributor sponsor"
        'else
        l23 = l23
        error23 = error23
        'end if


        l24 = "Ter24"
        If tempat = "direk" Then
            piye = "Otomatis dibawah sponsor"
            mlSQL = "SELECT kta,uid,telp,upme FROM member WHERE kta LIKE '" & direk & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                error26 = "Nomor id distributor upline placement tidak ditemukan"
                l26 = "Mbuh"
                aloc = ""
                namaalo = ""
                notelpalo = ""
                subalo = ""
                psa = ""
                uprane = "F"
            Else
                l26 = "Ter26"
                error26 = ""
                aloc = mlREADER("kta")
                namaalo = mlREADER("uid")
                notelpalo = mlREADER("telp")
                subalo = bcdirek
                psa = kakidirek
                error25 = ""
                l25 = "Ter25"
                'uprane = rs("upme")	
                uprane = "F"
            End If
            mlREADER.Close()
        Else
            If tempat = "upline" Then
                piye = "Dibawah upline distributor berikut ini"
                mlSQL = "SELECT kta,uid,telp,upme FROM member WHERE kta LIKE '" & idupline & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    error26 = "Nomor id distributor upline placement tidak ditemukan"
                    l26 = "Mbuh"
                    aloc = ""
                    namaalo = ""
                    notelpalo = ""
                    subalo = ""
                    psa = ""
                    uprane = "F"
                Else
                    l26 = "Ter26"
                    error26 = ""
                    aloc = mlREADER("kta")
                    namaalo = mlREADER("uid")
                    notelpalo = mlREADER("telp")
                    subalo = bcupline
                    psa = kakiupline
                    error25 = ""
                    l25 = "Ter25"
                    'uprane = rs("upme")
                    uprane = "F"
                End If
                mlREADER.Close()
            Else
                piye = ""
                error25 = "Anda belum memilih mode penempatan"
                l25 = "Mbuh"
                aloc = ""
                namaalo = ""
                notelpalo = ""
                subalo = ""
                psa = ""
            End If
        End If
    End Sub

    Sub CekKetersediaanBC()
        '''''''''''''''''''''''''''''''''''''''''''
        ' CEK KETERSEDIAAN BC
        '''''''''''''''''''''''''''''''''''''''''''
        If uprane = "F" Then
            If subalo = "2" Then
                If psa = "L" Then
                    l27 = "Mbuh"
                    error27 = "-. Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-2 kaki KIRI upline yang tidak memiliki 3 BC"
                Else
                    If psa = "R" Then
                        l27 = "Mbuh"
                        error27 = "-. Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-2 kaki KANAN upline yang tidak memiliki 3 BC"
                    End If
                End If
            Else
                If subalo = "3" Then
                    If psa = "L" Then
                        l27 = "Mbuh"
                        error27 = "-. Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-3 kaki KIRI upline yang tidak memiliki 3 BC"
                    Else
                        If psa = "R" Then
                            l27 = "Mbuh"
                            error27 = "-. Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-3 kaki KANAN upline yang tidak memiliki 3 BC"
                        End If
                    End If
                Else
                    If subalo = "1" Then
                        error27 = ""
                        l27 = "Ter27"
                    End If
                End If
            End If
        Else
            If uprane = "T" Then
                error27 = ""
                l27 = "Ter27"
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
            l28 = "Mbuh"
            error28 = "-. Maaf, sponsor dan upline penempatan tidak berada dalam satu jaringan - (CROSSLINE TIDAK DIIJINKAN)"
        Else
            l28 = "Ter28"
            error28 = ""
        End If


        '''''''''''''''''''''''''''''''''''''''''''''''''
        ' cek apakah posisi direct upline sudah terisi
        '''''''''''''''''''''''''''''''''''''''''''''''''
        nocross = "in1cr0sline"

        If subalo = "1" Then
            If psa = "L" Then
                aloce = aloc + "-2"
                pose = "L"
            Else
                If psa = "R" Then
                    aloce = aloc + "-3"
                    pose = "R"
                End If
            End If
        Else
            If subalo = "2" Then
                aloce = aloc + "-2"
                pose = psa
            Else
                If subalo = "3" Then
                    aloce = aloc + "-3"
                    pose = psa
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
            l29 = "Mbuh"
            error29 = "-. Maaf, penempatan yang dituju sudah terisi oleh distributor lain, yaitu nomor id :" & sopokui
        Else
            l29 = "Ter29"
            error29 = ""
        End If
    End Sub
End Class

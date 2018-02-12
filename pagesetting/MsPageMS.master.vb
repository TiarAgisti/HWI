Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class pagesetting_MsPageMS
    Inherits System.Web.UI.MasterPage


    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADERALL As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlENCRYPTCODE As String
    Dim mlIPADDRINFO As String
    Dim mpP1 As String
    Dim mpP2 As String
    Dim mpTYPE As String
    Dim mlCOMPANYID As String = "ALL", mpMODULEID As String = "PB"

    Dim strTreeMenu As String, strTreeMenuDetail As String
    Dim mlDATATABLE As DataTable



    Public mypos As String = "", kelasdc As String = "", indukdc As String = "", ktana As String = "", go As String = "",
        loguser As String = "", dcpusat As String = "", lanjutken As String = "",
        dcHO As String = "", bagian As String = "", flg As String = "", kat_id As String = "", bole As String = "",
        atas As String, kiri As String, bgimage As String, katpos As String, disk_mc As String, posku As String,
        pengguna As String, namauser As String, stockist_id As String, perush_dc As String, nama_dc As String, no_dc As String,
        alamat_dc As String, alamat_dc2 As String, kota_dc As String, no_kta As String, telp_dc As String, web_dc As String,
        emel_dc As String, lastlog_dc As String, lastip_dc As String, lastlog_user As String, lastip_user As String, prop_dc As String,
        ss As String, stadc As String, kowe As String, menu_bagpos, indukmc As String

    Dim skritu As DateTime, tupoawal As DateTime, tupoakhir As DateTime
    Dim goneqSS As Integer, menu_id As Integer, intLocale As Integer


    Dim mlREADERK As OleDb.OleDbDataReader



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        pg_config()
        pg_CekUser()
        PrepareTreeMenu()
        TreeMenu()
        pg_closing()


    End Sub

    Protected Sub pg_config()

        atas = 4
        kiri = 4


        disk_mc = 4
        bgimage = "images/background4.jpg"

        dcHO = "B-000"
        dcpusat = Session.Contents("indukdc")
        Session("dcpusate") = dcpusat
        Session("dcHO") = dcHO


        posku = Session("motok")
        pengguna = Session("kowe")

        If Session("motok") = "" Then
        Else
            Session("motok") = posku
        End If

        If Session("kowe") = "" Then
        Else
            Session("kowe") = pengguna
        End If

        If Session("kelasdc") = "M" Then
            Session("error1") = "Mobile Id. merupakan Mobile CENTER"
            Response.Redirect("login.aspx")
        End If

        ss = "T"
        Session("ss") = ss

        mlSQL = "SELECT * FROM  tabdesc_stockist WHERE nopos like '" & posku & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        If Not mlREADER.HasRows Then
            Session("lanjutkanterus") = "F"
            Session("motok") = ""
            Session("kowe") = ""
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            mlREADER.Read()

            Session("lanjutkanterus") = "T"
            perush_dc = mlREADER("nama")
            nama_dc = mlREADER("namadc")
            prop_dc = mlREADER("propinsi")
            kota_dc = mlREADER("kota")
            no_dc = mlREADER("nopos")
            no_kta = mlREADER("kta")
            alamat_dc = mlREADER("alamat") + " " + mlREADER("kota") + " " + mlREADER("kodepos")
            alamat_dc2 = mlREADER("propinsi") + " " + mlREADER("negara")
            telp_dc = mlREADER("telp")
            emel_dc = mlREADER("emel")
            web_dc = mlREADER("website")
            lastlog_dc = mlREADER("lastlog")
            lastip_dc = mlREADER("lastip")
            Session("pos_area") = mlREADER("area")
            stadc = mlREADER("sta")
        End If
        mlREADER.Close()

        mlSQL = "SELECT nama,lastip,lastlog,kat FROM  tabdesc_stockist_user WHERE nopos like '" & posku & "' and kta like '" & pengguna & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If Not mlREADER.HasRows Then
            Session("lanjutkanterus") = "F"
            Session("motok") = ""
            Session("kowe") = ""
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            mlREADER.Read()

            kowe = UCase(mlREADER("kat"))
            katpos = UCase(mlREADER("kat"))
            If stadc = "T" Then
                Session("lanjutkanterus") = "T"
                namauser = mlREADER("nama")
                lastlog_user = mlREADER("lastlog")
                lastip_user = mlREADER("lastip")
            Else
                If stadc = "F" Then
                    If kowe = "PST" Then
                        Session("lanjutkanterus") = "T"
                        namauser = mlREADER("nama")
                        lastlog_user = mlREADER("lastlog")
                        lastip_user = mlREADER("lastip")
                    Else
                        mlREADER.Close()

                        Session("lanjutkanterus") = "F"
                        Session("motok") = ""
                        Session("kowe") = ""
                        Session("out") = "ACCOUNT DC SUSPEND, SILAHKAN HUBUNGI KANTOR PUSAT"
                        Response.Redirect("login.aspx")
                    End If
                End If
            End If
        End If
        Session("namauser") = namauser

        mlREADER.Close()

    End Sub

    Protected Sub pg_CekUser()
        mypos = Session("motok")
        loguser = Session("kowe")
        menu_bagpos = Session("menu_bagpos")
        menu_id = Session("menu_id")

        If menu_bagpos = "" Then
            Session("error") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("logout.aspx")
        Else
            Session("menu_bagpos") = menu_bagpos
        End If

        If menu_id.ToString() = "" Then
            Session("error") = "Anda tidak memiliki hak akses untuk mengakses menu : " & menu_id
            Response.Redirect("logout.aspx")
        Else
            Session("menu_id") = menu_id
        End If

        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("error") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("logout.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        'If menu_id.ToString() <> "" Then
        '    mlSQL = "SELECT * FROM  menu_akses_pos where id_menu='" & menu_id & "' and kta like '" & loguser & "' and bag like '" & menu_bagpos & "' and pos like '" & mypos & "'"
        '    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        '    If Not mlREADER.HasRows Then
        '        mlREADER.Close()
        '        Session("error") = "Anda tidak memiliki hak akses untuk mengakses menu : " & menu_id
        '        Response.Redirect("error1.aspx")
        '    Else
        '    End If
        '    mlREADER.Close()
        'End If

    End Sub

    Protected Sub PrepareTreeMenu()
        dcpusat = Session("dcpusate")
        mypos = Session("motok")
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        indukmc = Session.Contents("indukmc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("error") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session.Contents("indukmc") = indukmc
        End If

        skritu = Now()
        lanjutken = "F"
        If tupoawal < skritu And tupoakhir > skritu Then
            lanjutken = "T"
        Else
            If Trim(UCase(loguser)) = "HWIHQ" Then
                lanjutken = "T"
            Else
                lanjutken = "F"
            End If
        End If
    End Sub

    Protected Sub TreeMenu()
        Dim mlDTMENU As New DataTable, mlDTSUBMENU As New DataTable

        strTreeMenu = "<ul class='sidebar-menu'>" & vbCrLf
        strTreeMenu += "<li class='header'>MOBILE STOCKIEST MENU</li>" & vbCrLf

        bagian = Session("menu_bagpos")
        flg = "T"

        mlSQL = "SELECT DISTINCT urut,kat FROM  menu_pos where bag like '" & bagian & "' order by urut ASC"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        ' mlREADER.Read()


        mlDTMENU.Load(mlREADER)
        For i As Integer = 0 To mlDTMENU.Rows.Count - 1
            strTreeMenu += "<li class='treeview'>" & vbCrLf

            kat_id = mlDTMENU.Rows(i)("kat").ToString()
            strTreeMenu += "<a href='#'><i class='fa fa-money'></i> <span>" & kat_id & "</span></a>" & vbCrLf


            mlSQL = "SELECT * FROM  menu_pos where kat like '" & kat_id & "' and bag like '" & bagian & "' and flag like '" & flg & "' order by id" & vbCrLf
            mlREADERALL = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If mlREADERALL.HasRows Then
                'mlREADERALL.Read()
                strTreeMenuDetail = ""
                strTreeMenu += "<ul class='treeview-menu'>" & vbCrLf

                'For aaaeqSSSALL = 1 To 55
                mlDTSUBMENU = New DataTable
                mlDTSUBMENU.Load(mlREADERALL)
                For n As Integer = 0 To mlDTSUBMENU.Rows.Count - 1
                    menu_id = CInt(mlDTSUBMENU.Rows(n)("id").ToString())
                    bole = "T"

                    'mlSQL = "SELECT * FROM  menu_akses_pos where id_menu='" & menu_id & "' and kta like '" & loguser & "' and bag like '" & bagian & "' and pos like '" & mypos & "'" & vbCrLf
                    'mlREADERK = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    'If Not mlREADERK.HasRows Then
                    '    mlREADERK.Read()
                    '    bole = "F"
                    'Else
                    '    bole = "T"
                    'End If

                    'If mypos = dcHO Then
                    '    If mlDTSUBMENU.Rows(n)("deskripsi").ToString() = "Pembatalan Penjualan Produk" Or mlDTSUBMENU.Rows(n)("deskripsi").ToString() = "Rekap Pembatalan Penjualan" Then
                    '        bole = "T"
                    '    End If
                    'Else
                    '    bole = bole
                    'End If


                    If mlDTSUBMENU.Rows(n)("deskripsi").ToString() = "Topup" Or mlDTSUBMENU.Rows(n)("deskripsi").ToString() = "Penjualan Upgrade Topup" Then
                        If lanjutken = "T" Then
                            bole = "T"
                        Else
                            bole = "F"
                        End If
                    End If

                    If bole = "T" Then
                        If mlDTSUBMENU.Rows(n)("link").ToString() <> "-" And bole = "T" Then
                            strTreeMenuDetail += " <li><a target='_top' href='" & mlDTSUBMENU.Rows(n)("link").ToString() & "?menu_id=" & mlDTSUBMENU.Rows(n)("id").ToString() & "'><i class='fa fa-circle-o'></i>" & mlDTSUBMENU.Rows(n)("deskripsi").ToString() & "</a></li>" & vbCrLf
                        End If
                        If menu_id = 42 Then
                            If mlDTSUBMENU.Rows(n)("link").ToString() <> "-" And bole = "T" Then
                                strTreeMenuDetail += " <li ><a target='_top' href='sale_stater_new.aspx?menu_id=" & mlDTSUBMENU.Rows(n)("id").ToString() & "'><i class='fa fa-circle-o'></i>Penjualan Paket Pendaftaran Baru</a></li>" & vbCrLf
                            End If
                        End If

                    End If

                Next
                strTreeMenu = strTreeMenu + strTreeMenuDetail
                strTreeMenu += "</ul>" & vbCrLf
            End If
            strTreeMenu += "</li>" & vbCrLf
        Next


        strTreeMenu += "<li class='treeview'>" & vbCrLf
        strTreeMenu += "<a href='#'><i class='fa fa-pencil-square-o'></i> <span>TRANSAKSI MS</span></a>" & vbCrLf
        strTreeMenu += "<ul class='treeview-menu'>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='ms4_perdana.aspx?menu_id=1'><i class='fa fa-circle-o'></i>MS400/200U UPGRADE<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='mb4_perdana.aspx?menu_id=1'><i class='fa fa-circle-o'></i>MS400/200 DAFTAR<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='mc_rekap_order_ms.aspx?menu_id=1'><i class='fa fa-circle-o'></i>Rekap Upgrade MS<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "</ul>" & vbCrLf
        strTreeMenu += "</li>" & vbCrLf

        strTreeMenu += "<li class='treeview'>" & vbCrLf
        strTreeMenu += "<a href='#'>" & vbCrLf
        strTreeMenu += "<i class='fa  fa-info'></i> <span>DOWNLOAD PANDUAN MS</span>" & vbCrLf
        strTreeMenu += "</a>" & vbCrLf
        strTreeMenu += "<ul class='treeview-menu'>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='../File/MobileStockiest/1. Cara Login MS.pdf'><i class='fa fa-circle-o'></i>1. Cara Login MS<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='../File/MobileStockiest/2.Cara Pendaftaran Member Paket Reguler.pdf'><i class='fa fa-circle-o'></i>2. Pendaftaran Reguler<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='../File/MobileStockiest/3.Cara Pendaftaran Member Paket MS.pdf'><i class='fa fa-circle-o'></i>3. Pendaftaran Paket MS<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='../File/MobileStockiest/3.5.Cara Upgrade Paket MS.pdf'><i class='fa fa-circle-o'></i>3.5 Upgrade Paket MS<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='../File/MobileStockiest/4.Cara Cek Posisi Stok.pdf'><i class='fa fa-circle-o'></i>4. Cek Posisi Stok<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "<li><a target='_top' href='../File/MobileStockiest/5.Cara Input Poin.pdf'><i class='fa fa-circle-o'></i>5. Cara Input Poin<i class='fa fa-cart-plus'></i></a></li>" & vbCrLf
        strTreeMenu += "</ul>" & vbCrLf
        strTreeMenu += "</li>" & vbCrLf


        leftmenu.InnerHtml = strTreeMenu
    End Sub

    Protected Sub pg_closing()
        Dim bln As Integer, thn As Integer, strYear As String, tutup1 As String, tutup2 As String, wulpos As String,
            nuhun As String, wulposlalu As String, nuhunlalu As String, wultupo As String, nuhuntupo As String

        Dim strDays As Integer, strDays1 As Integer, blne As Integer, bln1 As Integer, thn1 As Integer,
            wulupdateharian As Integer, nuhunupdateharian As Integer,
            wulupdateharian1 As Integer, nuhunupdateharian1 As Integer, tgltupo_akhir As Integer,
            bulclos As Integer, tahunclos As Integer, wulnow As Integer, nahunnow As Integer,
            gal1 As Integer, gal2 As Integer, gal3 As Integer, tgltupo_awal As Integer, blntupo_awal As Integer,
            thntupo_awal As Integer, blntupo_akhir As Integer, thntupo_akhir As Integer


        Dim dino As Date, tupoawal As Date, tupoakhir As Date


        dino = Now()
        bln = Month(dino)
        thn = Year(dino)
        strYear = Year(dino)


        If bln = 1 Or bln = 3 Or bln = 5 Or bln = 7 Or bln = 8 Or bln = 10 Or bln = 12 Then
            strDays = 31
        Else
            If bln = 4 Or bln = 6 Or bln = 9 Or bln = 11 Then
                strDays = 30
            Else
                If ((CInt(strYear) Mod 4 = 0 And CInt(strYear) Mod 100 <> 0) Or (CInt(strYear) Mod 400 = 0)) Then
                    strDays = 28
                Else
                    strDays = 28
                End If
            End If
        End If

        blne = bln + 1
        If blne = 13 Then
            bln1 = 2
            thn1 = thn + 1
        Else
            bln1 = blne
            thn1 = thn
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' closing date session
        ' ganti parameter ini setiap akhir periode bulanan
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        strDays1 = 1 ' closing date parameter, ganti parameter ini bila tanggal closing diundur
        bulclos = Month(dino) ' closing month parameter GANTI PARAMETER INI TIAP BULAN MAJU TIAP BULAN +1 -----------
        tahunclos = Year(Now.AddYears(-1)) ' closing year parameter

        wulnow = Month(Now.AddMonths(1))  ' BULAN CURRENT OMZET TUTUP POINT GANTI PARAMETER INI TIAP BULAN MAJU TIAP BULAN +1 -----------
        nahunnow = Year(dino) ' GANTI PARAMETER INI TIAP TAHUN

        tutup1 = CStr(strDays) + "/" + Convert.ToString(bln) + "/" + Convert.ToString(thn) + " " + "23:59:59"
        tutup2 = CStr(strDays1) + "/" + Convert.ToString(bln1) + "/" + CStr(thn1) + " " + "00:00:00"

        '''''''''''''''''''''''''''''''
        ' alokbulan session
        '''''''''''''''''''''''''''''''
        gal1 = Day(dino)
        gal2 = Month(dino)
        gal3 = Year(dino)

        If gal1 >= strDays1 And gal2 = bulclos And gal3 = tahunclos Then
            wulpos = Month(dino)
            nuhun = Year(dino)
            wulposlalu = bln - 1
            nuhunlalu = thn
        Else
            wulpos = wulnow
            nuhun = nahunnow
            wulposlalu = 8
            nuhunlalu = 2015
        End If

        '''''''''''''''''''''''''''''''
        ' top up session
        '''''''''''''''''''''''''''''''


        tgltupo_awal = 1
        blntupo_awal = 7 ' GANTI TIAP BULAN (+1 TIAP BULAN) -----------
        thntupo_awal = 2016 ' GANTI TIAP TAHUN

        tgltupo_akhir = 4
        blntupo_akhir = 7 ' GANTI TIAP BULAN (+1 TIAP BULAN) -----------
        thntupo_akhir = 2016 ' GANTI TIAP TAHUN

        wultupo = 6 ' BULAN TOP UP GANTI TIAP BULAN (+1 TIAP BULAN) -----------
        nuhuntupo = 2016 ' GANTI TIAP TAHUN

        wulupdateharian = wultupo ' GANTI SESUAI WULTUPO UNTUK UPDATE PV HARIAN OTOMATIS RUNNING BY SERVER
        nuhunupdateharian = nuhuntupo

        wulupdateharian1 = wulpos ' NGIKUT SESUAI CURRENT PV UNTUK UPDATE PV HARIAN OTOMATIS RUNNING BY SERVER
        nuhunupdateharian1 = nuhun

        tupoawal = CDate(CStr(tgltupo_awal) + "/" + CStr(blntupo_awal) + "/" + CStr(thntupo_awal) + " " + "00:00:00")
        tupoakhir = CDate(CStr(tgltupo_akhir) + "/" + CStr(blntupo_akhir) + "/" + CStr(thntupo_akhir) + " " + "10:59:59")

        Session("tgl1") = tupoawal
        Session("tgl2") = tupoakhir
        Session("wulpos") = wulpos
        Session("nuhun") = nuhun


    End Sub

End Class


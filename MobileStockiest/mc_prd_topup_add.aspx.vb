﻿Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_prd_topup_add
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Dim menu_id, pos_area, mypos, loguser, nosesi, kelasdc, indukdc, indukmc, namatabel, tgl, kode, jumlah, lanjutken, dcHO, lanjutposting, lanjutdodol, ggg1, ggg2, ggg, kode1 As String
    Dim hariakhir, skritu, dino, dinoe, tupoawal, tupoakhir, skr As Date
    Dim jumlahalokakt As Double

    Dim jumlah1, jumakt, jumpaket, jumstok, sisastok, PV, bv, hargabrg, jumlama, pvlama, bvlama, subtotlama, totpv, subtot As Double
    Dim namabrg, akhire, updit, lanj As String
    Dim jumskr As Long

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        nosesi = Session("nosesi")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        indukmc = Session.Contents("indukmc")
        skritu = Now()
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
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session.Contents("indukmc") = indukmc
        End If

        If UCase(mypos) = dcHO Then
            namatabel = "st_barang"
        Else
            namatabel = "st_barang_ms"
        End If

        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        tgl = CDate(Request("tgl"))
        kode = Trim(UCase(Request("kode")))
        jumlah = Request("jumlah")

        If tgl = "" Then
            Session("errorpos") = "Invalid Tanggal Transaski"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            If tgl < dinoe Then
                Session("errorpos") = "Invalid Tanggal Transaski"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            End If
        End If

        If kode = "" Then
            Session("errorpos") = "Anda belum mengisikan kode produk"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        End If

        If IsNumeric(jumlah) = False Then

            Session("errorpos") = "Anda belum mengisikan jumlah produk dibeli"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        End If

        If jumlah = 0 Or jumlah <= 0 Then

            Session("errorpos") = "Anda belum mengisikan jumlah produk dibeli"
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        End If

        CekValidSession()
    End Sub

    Sub CekValidSession()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' CEK VALID SESSION
        ' CLOSE SESSION INPUT HANYA BISA DILAKUKAN MELALUI KANTOR PUSAT
        ' CLOSE SESSION TIAP AKHIR BULAN PADA TANGGAL 30/31 JAM 19:00:00 WIB
        ' BILA ADA TRANSAKSI PADA TANGGAL 30/31 LEWAT CLOSING TIME, MAKA DITOLAK DAN DIMINTA UNTUK MENGHUBUNGI KANTOR PUSAT
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        'lanjutposting = "F"
        'lanjutdodol = "F"
        skr = Now()
        'if tutup1 < skr and tutup2 > skr then
        '	lanjutposting = "F"
        'else
        lanjutposting = "T"
        lanjutdodol = "T"
        'end if
        If lanjutposting = "T" Then
            ''''''''''''''''''''''''''''''''''''''
            ' CEK STOCK ALOKASI UNTUK STARTERKIT
            ''''''''''''''''''''''''''''''''''''''
            ggg = "AKT"
            ggg1 = "UPG"
            ggg2 = "REN"
            jumlahalokakt = 0
            mlSQL = "SELECT kode,jumlah FROM " & namatabel & " where nopos like '" & mypos & "' and (grp like '" & ggg & "' or grp like '" & ggg1 & "' or grp like '" & ggg2 & "')"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If mlREADER.HasRows Then
                mlDATATABLE = New DataTable
                mlDATATABLE.Load(mlREADER)
                For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                    kode1 = mlDATATABLE.Rows(aaaeqSSS)("kode")
                    jumlah1 = mlDATATABLE.Rows(aaaeqSSS)("jumlah")

                    mlSQL2 = "SELECT * FROM st_tipe_paket_jumlah where paket like '" & kode1 & "' and kode like '" & kode & "'"
                    mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                    mlREADER2.Read()
                    If Not mlREADER2.HasRows Then
                        jumakt = 0
                    Else
                        jumakt = mlREADER2("jumlah")
                    End If
                    mlREADER2.Close()
                    jumpaket = (jumlah1 * jumakt)

                    jumlahalokakt = jumlahalokakt + jumpaket
                Next
            End If
            mlREADER2.Close()
            ''''''''''''''''''''''''''''''''''''''
            ' CEK STOK BARANG DI DATABASE
            ''''''''''''''''''''''''''''''''''''''
            mlSQL = "SELECT jumlah,nama,hd1,hd2,hd3,hk1,hk2,hk3,hk4,hd4,hd5,hk5,pv,bv FROM " & namatabel & " where kode like '" & kode & "' and nopos like '" & mypos & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                lanjutdodol = "F"
                Session("errorpos") = "Kode produk tidak terdaftar"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            Else
                jumstok = mlREADER("jumlah")
                sisastok = jumstok - (Int(jumlah) + jumlahalokakt)
                If UCase(mypos) = "B-000" Then
                    If sisastok <= 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                Else
                    sisastok = sisastok
                End If

                If sisastok = 0 Or sisastok >= 0 Then
                    lanjutdodol = "T"
                    namabrg = mlREADER("nama")
                    PV = mlREADER("pv")
                    bv = mlREADER("bv")
                    If pos_area = "1" Then
                        hargabrg = mlREADER("hd1")
                    Else
                        If pos_area = "2" Then
                            hargabrg = mlREADER("hd2")
                        Else
                            If pos_area = "3" Then
                                hargabrg = mlREADER("hd3")
                            Else
                                If pos_area = "4" Then
                                    hargabrg = mlREADER("hd4")
                                Else
                                    If pos_area = "5" Then
                                        hargabrg = mlREADER("hd5")
                                    Else

                                        Session("out") = "Session login anda sudah expired, silahkan login kembali"
                                        Response.Redirect("login.aspx")
                                    End If
                                End If
                            End If
                        End If
                    End If
                Else

                    lanjutdodol = "F"
                    Session("errorpos") = "Sisa stock tidak mencukupi untuk dilakukan transaksi ini"
                    Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                End If
            End If
            mlREADER.Close()

            If lanjutdodol = "T" Then ' jika stock mencukupi
                mlSQL = "SELECT count(id) FROM st_sale_prd_det_tmp where nosesi like '" & nosesi & "' and nopos like '" & mypos & "' group by nosesi"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumskr = 0
                Else
                    jumskr = CLng(mlREADER("count(id)"))
                End If
                mlREADER.Close()

                If jumskr < 7 Then
                    If nosesi = "" Then ' bikin nomor session
                        mlSQL = "SELECT TOP 1 nosesi FROM st_sale_prd_head_tmp where nopos like '" & mypos & "' order by nosesi DESC"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            akhire = 1
                        Else
                            akhire = mlREADER("nosesi") + 1
                        End If
                        mlREADER.Close()
                    Else
                        akhire = nosesi ' gunakan nomor session existing
                    End If
                    Session("nosesi") = akhire

                    ''''''''''''''''''''''''''''''''
                    ' SAVE TO TEMPORARY TABLE DETAIL
                    ''''''''''''''''''''''''''''''''
                    mlSQL = "SELECT * FROM st_sale_prd_det_tmp where nopos like '" & mypos & "' and nosesi like '" & akhire & "' and kode like '" & kode & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        updit = "F"
                        mlSQL2 = "insert into st_sale_prd_det_tmp(nopos,nosesi,kode,nama,jumlah,harga,pv,bv,subtot,dcinduk)values('" & mypos & "','" & akhire & "','" & kode & "','" & namabrg & "','" & jumlah & "'" & vbCrLf
                        mlSQL2 += ",'" & hargabrg & "','" & PV & "','" & bv & "','" & hargabrg * jumlah & "','" & indukdc & "')"
                    Else
                        updit = "T"
                        jumlama = mlREADER("jumlah")
                        pvlama = mlREADER("pv")
                        bvlama = mlREADER("bv")
                        subtotlama = mlREADER("subtot")

                        mlSQL2 = "update st_sale_prd_det_tmp set nama = '" & namabrg & "',jumlah = '" & jumlah & "',harga = '" & hargabrg & "',pv = '" & PV & "',bv = '" & bv & "'" & vbCrLf
                        mlSQL2 += ",subtot = '" & hargabrg * jumlah & "' where nopos like '" & mypos & "' and nosesi like '" & akhire & "' and kode like '" & kode & "'"
                    End If
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                    mlREADER.Close()

                    ''''''''''''''''''''''''''''''''
                    ' SAVE TO TEMPORARY TABLE HEAD
                    ''''''''''''''''''''''''''''''''
                    mlSQL = "SELECT * FROM st_sale_prd_head_tmp where nopos Like '" & mypos & "' and nosesi like '" & akhire & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        mlSQL2 = "insert into st_sale_prd_head_tmp(nopos,kta,nosesi,totpv,totbv,subtot,tgl,dcinduk)values('" & mypos & "','" & loguser & "','" & akhire & "'" & vbCrLf
                        mlSQL2 += ",'" & PV * jumlah & "','" & bv * jumlah & "','" & hargabrg * jumlah & "','" & dino & "','" & indukdc & "')"
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                    Else
                        lanj = "T"
                        If updit = "F" Then
                            totpv = mlREADER("totpv") + (PV * jumlah)
                            subtot = mlREADER("subtot") + (hargabrg * jumlah)
                            'rsALL.update
                            'rsALL("totpv") = rsALL("totpv")+(pv*jumlah)
                            'rsALL("totbv") = rsALL("totbv")+(bv*jumlah)
                            'rsALL("subtot") = rsALL("subtot")+(hargabrg*jumlah)
                            'rsALL.update	
                        Else
                            totpv = (mlREADER("totpv") - (pvlama * jumlama)) + (PV * jumlah)
                            subtot = (mlREADER("subtot") - subtotlama) + (hargabrg * jumlah)
                            'rsALL.update
                            'rsALL("totpv") = (rsALL("totpv")-(pvlama*jumlama))+(pv*jumlah)
                            'rsALL("totbv") = (rsALL("totbv")-(bvlama*jumlama))+(bv*jumlah)
                            'rsALL("subtot") = (rsALL("subtot")-subtotlama)+(hargabrg*jumlah)
                            'rsALL.update							
                        End If
                    End If
                    mlREADER.Close()

                    If lanj = "T" Then
                        Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                        'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

                        mlSQL = "UPDATE st_sale_prd_head_tmp SET totpv = '" & totpv & "', subtot = '" & subtot & "' WHERE (nosesi like '" & akhire & "') and (nopos like '" & mypos & "')"
                        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                        Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                        'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
                    End If


                    Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)

                Else ' akhir maksimal 7 item / invoice


                    Session("errorpos") = "Maksimal 1 invoice terdiri dari 7 item produk, silahkan melakukan chekcout dan membuka invoice baru"
                    Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
                End If

            Else ' akhir cek sisa stok
                Session("errorpos") = "Sisa stock tidak mencukupi untuk dilakukan transaksi ini"
                Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
            End If

        Else
            Dim strDiv As String = ""
            strDiv += "<p style='text-align:center;'>"
            strDiv += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'></p>"
            strDiv += "<p style='text-align:center;font-family:Verdana;'>Maaf saat ini transaksi anda tidak dapat dilakukan karena sudah memasuki<b style='color:#FF0000;'>closing period</b><br>"
            strDiv += "Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup point bulanan <br> maka silahkan hubungi kantor pusat sesegera mungkin.<br>"
            strDiv += "Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian anda.<br>"
            strDiv += "&lt;-- <a href='mc_prd_topup.aspx?menu_id=<%=session('menu_id')%>'>Kembali</a> --&gt;"
            Div_mc_add.InnerHtml = strDiv
        End If
    End Sub
End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_renewal_save
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable
    Dim mlFUNCT As FunctionHWI

    Dim menu_id, dcpusate, pos_area, mypos, loguser, kelasdc, indukdc, indukmc, namatabel, namatabel2, dcHO As String

    Dim dino, dinoe, hariakhir, expir As Date
    Dim noser, paket, harga, l1a, l1, l3, kop, l2, tipe, upe, jeneng, teruskenlah, namakonbaru, l4, l5, lanjutdodol, lanjutposting As String
    Dim PV, bv, tunai, debit, kkredit, bgcek, duite, jumbc, jumpv, jumbv, sisa, sisastok As Double
    Dim lama As Integer

    Dim jumstok As Double
    Dim mypoc As String

    Dim kodeberi1, kodeberi2, kodeberi3, kodeberi4, kodeberi5, kodeberi6, kodeberi7, kodeberi8, kodeberi9, kodeberi10, kodeberi11, kodeberi12 As String
    Dim jumberi1, jumberi2, jumberi3, jumberi4, jumberi5, jumberi6, jumberi7, jumberi8, jumberi9, jumberi10, jumberi11, jumberi12, sisaku, sisastk As Double

    Dim skr As Date
    Dim wulan, nahun As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        menu_id = Session("menu_id")
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
        CekStokPaketPendaftaran()
        CekStokProdukPendukungPaketRenewal()
        CekValidSession()
    End Sub

    Sub PrepareSave()
        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        noser = Trim(Request("direk"))
        paket = Trim(Request("paket"))
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
            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
        Else
            If Len(dinoe) >= 11 Then
                Session("errorpos") = "Tanggal transaksi tidak valid, maksimal 10 karakter"
                l1a = "Mbuh"
                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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
            Session("errorpos") = "Anda belum memilih paket renewal"
            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
        Else
            If Len(paket) >= 12 Then
                Session("errorpos") = "Anda belum memilih paket renewal"
                l3 = "Mbuh"
                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
            Else
                If ((Len(paket) <= 12) And (paket <> "")) Then
                    If UCase(mypos) = dcHO Then
                        mlSQL = "SELECT id,jumbc,kop,pv,bv FROM " & namatabel & " where kode like '" & paket & "'"
                    Else
                        mlSQL = "SELECT id,jumbc,kop,pv,bv FROM " & namatabel & " where kode like '" & paket & "' and nopos like '" & mypos & "'"
                    End If
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorpos") = "Tipe Paket Renewal tidak dikenal"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                    Else
                        l3 = "Ter3"
                        Session("errorpos") = ""
                        jumbc = mlREADER("jumbc")
                        kop = mlREADER("kop")
                        jumpv = mlREADER("pv")
                        jumbv = mlREADER("bv")
                    End If
                    mlREADER.Close()
                End If
            End If
        End If

        If noser = "" Then
            l2 = "Mbuh"
            Session("errorpos") = "Nomor distributor belum diisi"
            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
        Else
            If Len(noser) >= 11 Then
                Session("errorpos") = "Nomor distributor maksimal 10 karakter"
                l2 = "Mbuh"
                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
            Else
                If ((Len(noser) <= 11) And (noser <> "")) Then
                    If IsNumeric(noser) = True Then
                        mlSQL = "SELECT id,tipene_kartu,upme,uid FROM member where asli = '" & noser & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            Session("errorpos") = "Nomor distributor tidak ditemukan"
                            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                        Else
                            upe = mlREADER("upme")
                            tipe = mlREADER("tipene_kartu")
                            jeneng = mlREADER("uid")
                            mlSQL2 = "SELECT * FROM bns_expired_member where kta like '" & noser & "'"
                            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                            mlREADER2.Read()
                            If Not mlREADER2.HasRows Then
                                Session("errorpos") = "Status Expired ke-distributoran anda tidak ditemukan, silahkan hubungi kantor pusat"
                                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                            Else
                                expir = mlREADER2("tglexpired")
                            End If
                            mlREADER2.Close()
                            lama = DateDiff("d", Now(), expir)
                            teruskenlah = "F"
                            If lama <= 0 Then
                                mlSQL2 = "SELECT * FROM member WHERE kta like '" & noser & "'"
                                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                                mlREADER2.Read()
                                If Not mlREADER2.HasRows Then
                                Else
                                    If lama <= 0 And lama > -32 Then
                                        If mlREADER2("sta") = "T" Then
                                            namakonbaru = Right(mlREADER2("uid"), 10)

                                            mlSQL3 = "update member set sta = 'F'" & vbCrLf
                                            If namakonbaru <> " (EXPIRED)" Then
                                                mlSQL3 += ",uid = '" & mlREADER2("uid") + " (EXPIRED)" & "'"
                                            End If
                                            mlSQL3 += "Where kta like '" & noser & "'"
                                            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                                            teruskenlah = "T"
                                        End If
                                    Else
                                        If mlREADER2("sta") = "T" Then
                                            namakonbaru = Right(mlREADER2("uid"), 10)

                                            mlSQL3 = "update member set sta = 'F'" & vbCrLf
                                            If namakonbaru <> " (EXPIRED)" Then
                                                mlSQL3 += ",uid = '" & mlREADER2("uid") + " (EXPIRED)" & "'"
                                            End If
                                            mlSQL3 += "Where kta like '" & noser & "'"
                                            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)

                                            teruskenlah = "F"
                                        End If
                                        Session("errorpos") = "Distributor sudah expired permanent, tidak dapat di renewal"
                                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                                    End If
                                End If
                                mlREADER2.Close()
                            Else
                                teruskenlah = "F"
                                Session("errorpos") = "Distributor tidak dapat direnewal sebelum memasuki masa tenggang !"
                                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                            End If

                        End If
                        mlREADER.Close()
                    Else
                        Session("errorpos") = "Nomor distributor belum diisi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If

        If harga = "" Then
            l4 = "Mbuh"
            Session("errorpos") = "Anda belum memilih paket renewal"
            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(harga) = False Then
                l4 = "Mbuh"
                Session("errorpos") = "Anda belum memilih paket renewal"
                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
            Else
                If ((harga <> "") And (IsNumeric(harga) = False)) Then
                    If harga > 0 Then
                        l4 = "Ter4"
                        Session("errorpos") = ""
                    Else
                        l4 = "Mbuh"
                        Session("errorpos") = "Anda belum memilih paket renewal"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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
            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(duite) = False Then
                l5 = "Mbuh"
                Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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
                            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                        End If
                    Else
                        l5 = "Mbuh"
                        Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If

        lanjutdodol = "F"
        lanjutposting = "F"
        sisastok = 0
    End Sub

    Sub CekStokPaketPendaftaran()
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
                Session("errorpos") = "Paket renewal Tidak Terdaftar"
                Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
            Else
                jumstok = mlREADER("jumlah")
                sisastok = jumstok - 1
                If sisastok = 0 Or sisastok >= 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"

                    Session("errorpos") = "Sisa stock tidak mencukupi untuk dilakukan transaksi ini"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                End If
            End If
            mlREADER.Close()
        Else
            lanjutdodol = "T"
            jumstok = 1
        End If
    End Sub

    Sub CekStokProdukPendukungPaketRenewal()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' cek stok ketersediaan produk pendukung paket renewal
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        mlSQL = "SELECT * FROM st_tipe_paket where kode like '" & paket & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjutdodol = "F"
            Session("errorpos") = "Paket renewal tidak valid !"
            Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi1 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi1
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi1 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi2 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi2
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi2 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi3 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi3
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi3 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi4 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi4
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi4 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi5 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi5
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi5 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi6 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi6
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi6 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi7 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi7
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi7 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi8 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi8
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi8 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi9 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi9
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi9 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                    End If
                End If
                mlREADER.Close()
            End If

            If kodeberi10 <> "" And kodeberi10 <> "-" And IsDBNull(kodeberi10) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi10 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    lanjutdodol = "F"

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi10 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi10
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi10 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi11 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi11
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi11 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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

                    Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi12 & " yang menyertai produk paket renewal"
                    Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
                Else
                    sisaku = mlREADER("jumlah")
                    sisastk = sisaku - jumberi12
                    If sisastk > 0 Or sisastk = 0 Then
                        lanjutdodol = "T"
                    Else
                        lanjutdodol = "F"

                        Session("errorpos") = "Stock kode produk " & kodeberi12 & " yang menyertai produk paket renewal tidak mencukupi"
                        Response.Redirect("sale_renewal.aspx?menu_id=" & menu_id)
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
        wulan = Session("wulpos")
        nahun = Session("nuhun")
        lanjutposting = "T"

        If lanjutposting = "F" Then

            Dim str_LanjutPosting As String = ""

            str_LanjutPosting += "<section class='content'>" & vbCrLf
            str_LanjutPosting += "<div class='box'>" & vbCrLf
            str_LanjutPosting += "<div class='box-header with-border'>" & vbCrLf
            str_LanjutPosting += "<h3 class='box-title'></h3>" & vbCrLf
            str_LanjutPosting += "<div class='box-tools pull-right'>" & vbCrLf
            str_LanjutPosting += "<button type='button' class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
            str_LanjutPosting += "<i class='fa fa-minus'></i></button>" & vbCrLf
            str_LanjutPosting += "<button type='button' class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
            str_LanjutPosting += "<i class='fa fa-times'></i></button>" & vbCrLf
            str_LanjutPosting += "</div>" & vbCrLf
            str_LanjutPosting += "</div>" & vbCrLf
            str_LanjutPosting += "<div class='box-body'>" & vbCrLf
            str_LanjutPosting += "<p align='center'>" & vbCrLf
            str_LanjutPosting += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
            str_LanjutPosting += "<br/>" & vbCrLf
            str_LanjutPosting += "<br/>" & vbCrLf

            str_LanjutPosting += "<p align='center'>" & vbCrLf
            str_LanjutPosting += "Maaf saat ini transaksi anda tidak dapat dilakukan karena sudah memasuki <font color='#FF0000'><b>closing period</b></font><br/>" & vbCrLf
            str_LanjutPosting += "Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup point bulanan<br/>" & vbCrLf
            str_LanjutPosting += "maka silahkan hubungi kantor pusat sesegera mungkin.<br/>" & vbCrLf
            str_LanjutPosting += "Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian anda.<br/>" & vbCrLf
            str_LanjutPosting += "&lt;-- <a href='sale_renewal.asp?menu_id=" & Session("menu_id") & "'>Kembali</a> --&gt;" & vbCrLf
            str_LanjutPosting += "</div>" & vbCrLf
            str_LanjutPosting += "</div>" & vbCrLf
            str_LanjutPosting += "</section>" & vbCrLf

            Div_LanjutPosting.InnerHtml = str_LanjutPosting
        End If
    End Sub
End Class

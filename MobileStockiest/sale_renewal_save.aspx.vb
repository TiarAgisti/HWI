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

    Dim error1, error2, error3, error4, noinvo As String
    Dim bulanskr, tahunskr, noakhir, bulsks, jk, tahskr, nopajak As Integer
    Dim tamb, blne, taun, nipe, kel, masterdc, k1, k2, nourutpjk As String
    Dim cekbg, jumak, awal As Double
    Dim kode_prd1, kode_prd2, kode_prd3, kode_prd4, kode_prd5, kode_prd6, kode_prd7, kode_prd8, kode_prd9, kode_prd10, kode_prd11, kode_prd12 As String
    Dim jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10, jumlah11, jumlah12 As Double
    Dim sapa, direknya, alok, namakon, aloknya As String
    Dim nilaipvnya, nilaibv, brapa, nam As Double
    Dim kiri, kanan As Integer
    Dim direk, aloc, psa As String
    Dim subalo As Double

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
        SimpanTransaksi()
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

    Sub SimpanTransaksi()
        If lanjutposting = "T" And lanjutdodol = "T" Then
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ' simpan transaksi
            ' potong stock
            ' update kartu stock	
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            ' SIMPAN TRANSAKSI
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            dino = Now()
            bulanskr = CInt(Month(dino))
            tahunskr = CInt(Year(dino))
            mlSQL = "SELECT TOP 1 id,urut,tgl FROM st_sale_daftar where nopos like '" & mypos & "' AND month(tgl)='" & bulanskr & "' AND year(tgl) = '" & tahunskr & "' order by urut DESC"
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

            noinvo = mypos + "/" + tamb + nipe + "/REN-" + blne + "/" + taun

            'nahun = year(dino)
            ''''''''''''''''''''''''''''''
            ' bikin nomor invoice pajak
            ''''''''''''''''''''''''''''''
            tahskr = CInt(Year(dino))
            kel = "RET"
            'rs.Open "SELECT * FROM nourut where dcinduk like '"&indukdc&"' AND nopos like '"&mypos&"' and year(tgl)='"&tahskr&"' and kel like '"&kel&"' order by urut desc limit 1",conn	
            'rs.Open "SELECT * FROM nourut where dcinduk like '"&indukdc&"' AND nopos like '"&mypos&"' and year(tgl)='"&tahskr&"' order by urut desc limit 1",conn	
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

            mlSQL = "insert into nourut(urut,nopos,noref,tgl,tipe,kel,dcinduk,nopajak)values('" & nopajak & "','" & mypos & "','" & noinvo & "','" & dino & "','AKT','RET','" & indukdc & "','" & nourutpjk & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)


            ' SIMPAN DATA TRANSAKSI
            mlSQL = "insert into st_sale_daftar(nopos,urut,kta,nama,tgl,noslip,nopajak,noseri,paket,harga,pv,bv,tunai,debit,cc,bg,jumbayar,kembalian,jumbc,suratjalan,alokbulan,aloktahun,dcinduk,direk,idplc,subalo,kaki,pakai,tipe)" & vbCrLf
            mlSQL += "values('" & mypos & "','" & noakhir & "','" & loguser & "','" & jeneng & "','" & dino & "','" & noinvo & "','" & nourutpjk & "','" & noser & "','" & paket & "','" & harga & "','" & jumpv & "'" & vbCrLf
            mlSQL += ",'" & jumbv & "','" & tunai & "','" & debit & "','" & kkredit & "','" & cekbg & "','" & duite & "','" & duite - harga & "','" & jumbc & "','-','" & wulan & "','" & nahun & "','" & indukdc & "'" & vbCrLf
            mlSQL += ",'" & direk & "','" & aloc & "','" & subalo & "','" & psa & "','T','normal')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            ' STOCK AKTUAL Paket Upgrade DC
            If UCase(mypos) <> dcHO Then ' bila DC kantor pusat tidak ada paket pendaftaran
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "Update " & namatabel & " set jumlah = " & mlREADER("jumlah") - 1 & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by kode DESC"
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

            ' KARTU STOCK PAKET PENDAFTARAN
            mlSQL = "Select TOP 3 * FROM " & namatabel2 & " where nopos Like '" & mypos & "' and kode like '" & paket & "' order by tgl DESC, id DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "'" & vbCrLf
                mlSQL2 += ",'" & jumak & "',0,1," & jumak - 1 & ",'" & noinvo & "','Penjualan Renewal')"
            Else
                awal = mlREADER("akhir")
                sisastok = awal - 1
                If sisastok < 0 Then
                    sisastok = 0
                Else
                    sisastok = sisastok
                End If
                mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & paket & "','" & mypos & "','" & dino & "'" & vbCrLf
                mlSQL2 += ",'" & awal & "',0,1," & sisastok & ",'" & noinvo & "','Penjualan Renewal')"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ' UPDATE produk paket renewal UNTUK SEJARAH SAJA
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' UPDATE STOCK AKTUAL DC SESUAI Paket Upgrade PENDUKUNGNYA
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by kode DESC"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    jumak = 0
                Else
                    jumak = mlREADER("jumlah")
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah1 & " where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd1 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah1 & "'," & jumak - jumlah1 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah1
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd1 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah1 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah2 & " where nopos like '" & mypos & "' and kode like '" & kode_prd2 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd2 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah2 & "'," & jumak - jumlah2 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah2
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd2 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah2 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah3 & " where nopos like '" & mypos & "' and kode like '" & kode_prd3 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd3 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah3 & "'," & jumak - jumlah3 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah3
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd3 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah3 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah4 & " where nopos like '" & mypos & "' and kode like '" & kode_prd4 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd4 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah4 & "'," & jumak - jumlah4 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah4
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd4 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah4 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah3 & " where nopos like '" & mypos & "' and kode like '" & kode_prd5 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd5 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah5 & "'," & jumak - jumlah5 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah5
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd5 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah5 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah6 & " where nopos like '" & mypos & "' and kode like '" & kode_prd6 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd6 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah6 & "'," & jumak - jumlah6 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah6
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd6 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah6 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah7 & " where nopos like '" & mypos & "' and kode like '" & kode_prd7 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd7 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah7 & "'," & jumak - jumlah7 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah7
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd7 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah7 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah8 & " where nopos like '" & mypos & "' and kode like '" & kode_prd8 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd8 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah8 & "'," & jumak - jumlah8 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah8
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd8 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah8 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah9 & " where nopos like '" & mypos & "' and kode like '" & kode_prd9 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd9 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah9 & "'," & jumak - jumlah9 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah9
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd9 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah9 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah10 & " where nopos like '" & mypos & "' and kode like '" & kode_prd10 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd10 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah10 & "'," & jumak - jumlah10 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah10
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd10 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah10 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah11 & " where nopos like '" & mypos & "' and kode like '" & kode_prd11 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd11 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah11 & "'," & jumak - jumlah11 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah11
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd11 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah11 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
                    mlSQL2 = "update " & namatabel & " set jumlah = " & mlREADER("jumlah") - jumlah12 & " where nopos like '" & mypos & "' and kode like '" & kode_prd12 & "' order by kode DESC"
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
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd12 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & jumak & "',0,'" & jumlah12 & "'," & jumak - jumlah12 & ",'" & noinvo & "','Produk Penjualan Renewal')"
                Else
                    awal = mlREADER("akhir")
                    sisastok = awal - jumlah12
                    If sisastok < 0 Then
                        sisastok = 0
                    Else
                        sisastok = sisastok
                    End If
                    mlSQL2 = "insert into " & namatabel2 & "(kode,nopos,tgl,awal,masuk,keluar,akhir,referensi,keterangan)values('" & kode_prd12 & "','" & mypos & "','" & dino & "'" & vbCrLf
                    mlSQL2 += ",'" & awal & "',0,'" & jumlah12 & "'," & sisastok & ",'" & noinvo & "','Produk Penjualan Renewal')"
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
            Dim kode1, kode2, kode3, kode4, kode5, kode6, kode7, kode8, kode9, kode10, kode11, kode12 As String
            Dim jum1, jum2, jum3, jum4, jum5, jum6, jum7, jum8, jum9, jum10, jum11, jum12 As Double
            If kode_prd1 <> "" Or kode_prd1 <> "-" Or IsDBNull(kode_prd1) = False Then
                kode1 = kode_prd1
                jum1 = jumlah1
            Else
                kode1 = "-"
                jum1 = 0
            End If
            If kode_prd2 <> "" Or kode_prd2 <> "-" Or IsDBNull(kode_prd2) = False Then
                kode2 = kode_prd2
                jum2 = jumlah2
            Else
                kode2 = "-"
                jum2 = 0
            End If
            If kode_prd3 <> "" Or kode_prd3 <> "-" Or IsDBNull(kode_prd3) = False Then
                kode3 = kode_prd3
                jum3 = jumlah3
            Else
                kode3 = "-"
                jum3 = 0
            End If
            If kode_prd4 <> "" Or kode_prd4 <> "-" Or IsDBNull(kode_prd4) = False Then
                kode4 = kode_prd4
                jum4 = jumlah4
            Else
                kode4 = "-"
                jum4 = 0
            End If
            If kode_prd5 <> "" Or kode_prd5 <> "-" Or IsDBNull(kode_prd5) = False Then
                kode5 = kode_prd5
                jum5 = jumlah5
            Else
                kode5 = "-"
                jum5 = 0
            End If
            If kode_prd6 <> "" Or kode_prd6 <> "-" Or IsDBNull(kode_prd6) = False Then
                kode6 = kode_prd6
                jum6 = jumlah6
            Else
                kode6 = "-"
                jum6 = 0
            End If
            If kode_prd7 <> "" Or kode_prd7 <> "-" Or IsDBNull(kode_prd7) = False Then
                kode7 = kode_prd7
                jum7 = jumlah7
            Else
                kode7 = "-"
                jum7 = 0
            End If
            If kode_prd8 <> "" Or kode_prd8 <> "-" Or IsDBNull(kode_prd8) = False Then
                kode8 = kode_prd8
                jum8 = jumlah8
            Else
                kode8 = "-"
                jum8 = 0
            End If
            If kode_prd9 <> "" Or kode_prd9 <> "-" Or IsDBNull(kode_prd9) = False Then
                kode9 = kode_prd9
                jum9 = jumlah9
            Else
                kode9 = "-"
                jum9 = 0
            End If
            If kode_prd10 <> "" Or kode_prd10 <> "-" Or IsDBNull(kode_prd10) = False Then
                kode10 = kode_prd10
                jum10 = jumlah10
            Else
                kode10 = "-"
                jum10 = 0
            End If
            If kode_prd11 <> "" Or kode_prd11 <> "-" Or IsDBNull(kode_prd11) = False Then
                kode11 = kode_prd11
                jum11 = jumlah11
            Else
                kode11 = "-"
                jum11 = 0
            End If
            If kode_prd12 <> "" Or kode_prd12 <> "-" Or IsDBNull(kode_prd12) = False Then
                kode12 = kode_prd12
                jum12 = jumlah12
            Else
                kode12 = "-"
                jum12 = 0
            End If

            If Not mlREADER.HasRows Then
                mlSQL2 = "insert into st_sale_daftar_prd(noslip,tgl,nopajak,kode1,jumlah1,kode2,jumlah2,kode3,jumlah3,kode4,jumlah4,kode5,jumlah5,kode6,jumlah6,kode7,jumlah7,kode8,jumlah8 " & vbCrLf
                mlSQL2 += ",kode9,jumlah9,kode10,jumlah10,kode11,jumlah11,kode12,jumlah12,dcinduk)values('" & noinvo & "','" & dino & "','" & nourutpjk & "','" & kode1 & "','" & jum1 & "','" & kode2 & "','" & jum2 & "'" & vbCrLf
                mlSQL2 += ",'" & kode3 & "','" & jum3 & "','" & kode4 & "','" & jum4 & "','" & kode5 & "','" & jum5 & "','" & kode6 & "','" & jum6 & "','" & kode7 & "','" & jum7 & "','" & kode8 & "','" & jum8 & "'" & vbCrLf
                mlSQL2 += ",'" & kode9 & "','" & jum9 & "','" & kode10 & "','" & jum10 & "','" & kode11 & "','" & jum11 & "','" & kode12 & "','" & jum12 & "','" & indukdc & "')"
            Else
                mlSQL2 = "Update st_sale_daftar_prd set nopajak = '" & nourutpjk & "',kode1 = '" & kode1 & "',jumlah1 = '" & jum1 & "',kode2 = '" & kode2 & "',jumlah2 = '" & jum2 & "'" & vbCrLf
                mlSQL2 += ",kode3 = '" & kode3 & "',jumlah3 = '" & jum3 & "',kode4 = '" & kode4 & "',jumlah4 = '" & jum4 & "',kode5 = '" & kode5 & "',jumlah5 = '" & jum5 & "'" & vbCrLf
                mlSQL2 += ",kode6 = '" & kode6 & "',jumlah6 = '" & jum6 & "',kode7 = '" & kode7 & "',jumlah7 = '" & jum7 & "',kode8 = '" & kode8 & "',jumlah8 = '" & jum8 & "'" & vbCrLf
                mlSQL2 += ",kode9 = '" & kode9 & "',jumlah9 = '" & jum9 & "',kode10 = '" & kode10 & "',jumlah10 = '" & jum10 & "',kode11 = '" & kode11 & "',jumlah11 = '" & jum11 & "'" & vbCrLf
                mlSQL2 += ",kode12 = '" & kode12 & "',jumlah12 = '" & jum12 & "' where noslip like '" & noinvo & "'"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()


            'if teruskenlah = "T" then	
            sapa = noser
            nilaipvnya = 0
            nilaibv = 0

            mlSQL = "SELECT * FROM member where kta Like '" & sapa & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                nam = Len(mlREADER("uid"))
                brapa = nam - 10
                namakon = Left(mlREADER("uid"), brapa)
                mlSQL2 = "update member set sta = 'T',uid = '" & namakon & "' where kta Like '" & sapa & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                direknya = mlREADER("direk")
                aloknya = mlREADER("alok")
            End If
            mlREADER.Close()

            mlSQL = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and noseri like '" & sapa & "' and noslip like '" & noinvo & "' order by id"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                mlSQL2 = "update st_sale_daftar set nama = '" & namakon & "' where nopos like '" & mypos & "' and noseri like '" & sapa & "' and noslip like '" & noinvo & "' order by id"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            mlSQL = "SELECT TOP 1 * FROM bonpas where kta like '" & sapa & "' order by id desc"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                kiri = 0
                kanan = 0
            Else
                kiri = mlREADER("totkiri")
                kanan = mlREADER("totkanan")
            End If
            mlREADER.Close()

            mlSQL = "SELECT * FROM bns_expired_member where kta like '" & sapa & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "insert into bns_expired_member(kta,last_tupo_bulan,last_tupo_tahun,re_entry,tglexpired,direk,alok,kiri,kanan)values('" & sapa & "','" & wulan & "'" & vbCrLf
                mlSQL2 += ",'" & nahun & "','T'," & Now.AddDays(365) & ",'" & direknya & "','" & aloknya & "','" & kiri & "','" & kanan & "')"
            Else
                mlSQL2 = "update bns_expired_member set last_tupo_bulan = '" & wulan & "',last_tupo_tahun = '" & nahun & "',re_entry = 'T',tglexpired = " & Now.AddDays(365) & "" & vbCrLf
                mlSQL2 += ",direk = '" & direknya & "',alok = '" & aloknya & "',kiri = '" & kiri & "',kanan = '" & kanan & "' where kta like '" & sapa & "'"
            End If
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ' BONUS SPONSOR
            ''''''''''''''''''''''''''''''''''''''''''''''''''

            mlSQL = "SELECT * FROM bns_renewal_sponsor where kta Like '" & direknya & "' and direk like '" & sapa & "' and bulan='" & wulan & "' and tahun='" & nahun & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                mlSQL2 = "insert into bns_renewal_sponsor(kta,bulan,tahun,direk)values('" & direknya & "','" & wulan & "','" & nahun & "','" & sapa & "')"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ' UPDATE BONUS TITIK 6 LEVEL
            ' DIHITUNG PADA SAAT PERHITUNGAN BONUS BULANAN
            ' UNTUK MEMBERI KESEMPATAN UPLINE MELAKUKAN RENEWAL
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            'jutit = 6
            'kedualanjut = aloknya
            'levnya = 1
            'for aaxd = 1 to 1000000
            'rs.Open "SELECT kta,pal1,pal2,alok FROM member WHERE (kta LIKE '"&kedualanjut&"' or pal1 LIKE '"&kedualanjut&"' or pal2 LIKE '"&kedualanjut&"')",conn
            '	if rs.bof then
            '		rs.close  
            '		aaxd = muter+10
            '		exit for
            '	else
            '		if levnya <= jutit then
            '			sopotoyo = rs("kta")
            '			kedualanjut = rs("alok")
            '			rsALL.Open "SELECT * FROM bns_renewal_level order by id desc LIMIT 1",connALL,3,3
            '				rsALL.addnew
            '					rsALL("kta") = sopotoyo
            '					rsALL("direk") = sapa
            '					rsALL("bulan") = wulan
            '					rsALL("tahun") = nahun
            '					rsALL("levke") = levnya
            '					rsALL("bonlev") = 0
            '				rsALL.update
            '			rsALL.close
            '		else
            '			rs.close
            '			aaxd = muter+10
            '			exit for		
            '		end if			
            '	end if	
            'rs.close                                                       
            'aaxd = aaxd+1
            'levnya = levnya+1
            'if aaxd >= muter or levnya > jutit then
            'exit for
            'end if
            'next



            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia		
            Session("noinvo_ren") = noinvo
            Response.Redirect("sale_renewal_inv.aspx?menu_id=" & menu_id)
        Else
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
            str_Lanjutan += "Ada kesalahan dalam proses pendaftaran, silahkan perbaiki kesalahan seperti yang tertulis dibawah ini.<br/>" & vbCrLf
            If error1 <> "" Then
                str_Lanjutan += "" & error1 & " " & vbCrLf
            End If
            If error2 <> "" Then
                str_Lanjutan += "" & error2 & "" & vbCrLf
            End If
            If error3 <> "" Then
                str_Lanjutan += "" & error3 & " " & vbCrLf
            End If
            If error4 <> "" Then
                str_Lanjutan += "" & error4 & "" & vbCrLf
            End If
            str_Lanjutan += "<br/>" & vbCrLf
            str_Lanjutan += "&lt;-- <a href='sale_renewal.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a> " & vbCrLf
            str_Lanjutan += "--&gt;</font>" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "</div>" & vbCrLf
            str_Lanjutan += "</section>" & vbCrLf

            Div_LanjutPostingError.InnerHtml = str_Lanjutan
        End If
    End Sub
End Class

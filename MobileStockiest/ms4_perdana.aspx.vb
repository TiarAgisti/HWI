Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_ms4_perdana
    Inherits System.Web.UI.Page
    Dim mlREADER, mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mlDATATABLE As DataTable

    Public mlOBJGS As New IASClass.ucmGeneralSystem
    Public mpMODULEID As String = "PB"
    Public mlCOMPANYID As String = "ALL"
    Public mlDR, mlDR2 As OleDb.OleDbDataReader
    Public mlDT As DataTable
    Public mlQuery, mlQuery2 As String

    Dim ss1, ss2, satu, lama, aaaqsK As Integer
    Dim goneqSS As Integer = 0
    Dim wkt, skr As Date
    Dim noses As String

    Dim ggg, ste, lanjutdodol, namabrg, nodc, nofax, namadc As String
    Dim tglorder As Date

    'ms4_perdana_add
    Dim dcpusat, tipe, diskon, kemana, babe, gggs, gggs1, kode1s, jumlah1s, updit As String
    Dim jumlah As Integer
    Dim dino As Date

    Dim jumlahalokakt, jumakt, jumpaket, subtot As Double
    Dim diorder, sisa, sta, sts, diorder2, totdiod, jumstok, sisastok, hargabrg As Double

    Dim akhire As Integer
    Dim jumlama, pvlama, subtotlama, totpvlama As Double

    Public sutepe, dcHO, kode, nama, namamu, alamatdis, kotadis, kodeposdis, pp, prop_dc, telpdis, faxdis, emaildis, menu_id, error1 As String
    Public mesej, asal, kti, sort, pos_area, mypos, loguser, kelasdc, indukdc, namatabel, namatabel2, zona_id, area_id, nosesifaxmc_pdn, nokode_mc, namadis_mc As String
    Public totpv, totbv, gtot, pot, neto, newsubtot, newtotpv, gtotnet, jumdisk, jumtotdis, brapadis, disk_mcla, disk_mclama, pvmin, disk_mc, sds, jums, jumdivc, sbt, jumskr As Double
    Public harga1, kusus1, harga2, kusus2, harga3, kusus3, harga4, kusus4, harga5, kusus5, PV, bv, harga, kurangi, jumdis As Decimal
    Public tgl As Date


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        mesej = Session("errorfax")
        Session("errorfax") = ""
        asal = Session("asal")
        Session("asal") = ""
        Session("kti") = "PDN"
        kti = Session("kti")
        Session("nofax") = ""
        Session("nopos") = ""
        If asal = "selesai_order" Then
            Session("menu_id") = Session("menu_id")
        Else
            Session("menu_id") = Request("menu_id")
        End If

        PrepareDisplay()
        ClearNonRealizedBooked()
        OnlineBooked()
        'PaketUpgradeFunction()
        'PopulateData()
    End Sub

    Sub PrepareDisplay()
        Session("noinvo") = ""
        Session("asalnye") = ""
        sort = Request("sort")
        pos_area = Session("pos_area")
        mypos = UCase(Session("motok"))
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        'zona_id = request("zona_id")
        'area_id = request("area")
        sds = 0
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If
        sutepe = "PRD"

        If mypos = dcHO Then
            namatabel = "st_kartustock"
            namatabel2 = "st_barang"
            '	area_id = area_id
            '	pos_area = area_id
            pos_area = Request("area")
            zona_id = Request("zona_id")
            area_id = Request("area")
        Else
            namatabel = "st_kartustock_ms"
            namatabel2 = "st_barang_ms"
            '	area_id = pos_area
            '	pos_area = pos_area
            zona_id = pos_area
            area_id = pos_area
        End If

        If area_id = "" Then
            area_id = 0
        Else
            area_id = CInt(area_id)
        End If

    End Sub
    Protected Sub ClearNonRealizedBooked()
        ss1 = 0
        ss2 = 1
        satu = 2
        wkt = Now()

        mlSQL = "SELECT * FROM fx_order_mc_det where ((status = '" & ss1 & "') or (status = '" & ss2 & "')) and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        'mlREADER.Read()

        If mlREADER.HasRows <> True Then
            mlDATATABLE = New DataTable()
            mlDATATABLE.Load(mlREADER)

            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1

                skr = mlDATATABLE.Rows(aaaeqSSS)("tglorder")
                lama = DateDiff("n", skr, Now())

                If lama >= 10 Then
                    mlSQL = "update fx_order_mc_det" & vbCrLf
                    mlSQL += "Set status = -9," & vbCrLf
                    mlSQL += "    nosesi = 0, " & vbCrLf
                    mlSQL += "where ((status = '" & ss1 & "') or (status = '" & ss2 & "')) and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "'" & vbCrLf
                    mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                    noses = mlREADER("nosesi")
                    mlSQL2 = "SELECT * FROM fax_order_mc_head where nosesi like '" & noses & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
                    mlREADER2 = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER2.Read()

                    If mlREADER2.HasRows Then
                        mlSQL = "update fax_order_mc_head" & vbCrLf
                        mlSQL += "Set status = -9," & vbCrLf 'canceled
                        mlSQL += "    nosesi = 0, " & vbCrLf
                        mlSQL += "where nosesi like '" & noses & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'" & vbCrLf
                        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                    End If
                    mlREADER2.Close()
                End If
            Next
        End If
        mlREADER.Close()
    End Sub
    Sub OnlineBooked()
        nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
        Session("nosesifaxmc_pdn") = nosesifaxmc_pdn

        If nosesifaxmc_pdn <> "" Then
            mlSQL = "SELECT count(id) FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "' and status like '" & sds & "' and kat like '" & kti & "' group by nosesi"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                jumskr = 0
            Else
                jumskr = CLng(mlREADER("count(id)"))
            End If
            mlREADER.Close()

            mlSQL = "SELECT nopos,tgl,nofax,tipe FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "' and status like '" & sds & "' and kat like '" & kti & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()

            If Not mlREADER.HasRows Then
                nodc = ""
                tglorder = ""
                nofax = ""
                sutepe = "PRD"
            Else
                nodc = mlREADER("nopos")
                tglorder = mlREADER("tgl")
                nofax = mlREADER("nofax")
                sutepe = mlREADER("tipe")
                If sutepe = "-" Then
                    sutepe = "PRD"
                Else
                    sutepe = sutepe
                End If
            End If
            mlREADER.Close()

            mlSQL = "SELECT namadc FROM tabdesc_stockist where nopos like '" & nodc & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                namadc = ""
            Else
                namadc = mlREADER("namadc")
            End If
            mlREADER.Close()
        Else
            mlSQL = "SELECT namadc FROM tabdesc_stockist where nopos like '" & mypos & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()

            If Not mlREADER.HasRows Then
                namadc = ""
            Else
                namadc = mlREADER("namadc")
            End If
            mlREADER.Close()
        End If

        namadis_mc = Session("namadis_mc")
        nokode_mc = Session("nokode_mc")
    End Sub

    'Protected Sub Ms4_Perdana_add()
    '    Session("tema") = "home"
    '    Session("menu_id") = Session("menu_id")
    '    menu_id = Session("menu_id")
    '    mypos = UCase(Session("motok"))
    '    nodc = UCase(Session("motok"))
    '    loguser = Session("kowe")
    '    kelasdc = Session.Contents("kelasdc")
    '    indukdc = Session.Contents("indukdc")
    '    kti = Session("kti")
    '    asal = Request("asal")
    '    nofax = ""
    '    sds = 0
    '    Session("dcpusate") = dcpusat
    '    dino = Now()
    '    nosesifaxmc_pdn = Session("nosesifaxmc_pdn")

    '    If Session("motok") = "" Or Session("kowe") = "" Or Session("kti") = "" Then
    '        Session("out") = "Session login anda sudah expired, silahkan login kembali"
    '        Response.Redirect("login.aspx")
    '    Else
    '        Session("motok") = mypos
    '        Session("kowe") = loguser
    '        Session.Contents("kelasdc") = kelasdc
    '        Session.Contents("indukdc") = indukdc
    '    End If

    '    disk_mc = ""
    '    tipe = "PRD"
    '    asal = "PRD"
    '    diskon = disk_mc
    '    If asal = "normal" Then
    '        kemana = "ms_order_produk.aspx?menu_id=" & menu_id
    '    Else
    '        kemana = "ms4_perdana.aspx?menu_id=" & menu_id
    '    End If

    '    mlSQL = "SELECT induk,kelas,area FROM tabdesc_stockist WHERE nopos like '" & mypos & "'"
    '    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
    '    mlREADER.Read()
    '    If Not mlREADER.HasRows Then
    '        mlREADER.Close()
    '        mlREADER = Nothing
    '        Response.Redirect("logout.aspx")
    '    Else
    '        pos_area = mlREADER("area")
    '        indukdc = mlREADER("induk")
    '        kelasdc = mlREADER("kelas")
    '        Session.Contents("kelasdc") = kelasdc
    '        Session.Contents("indukdc") = indukdc
    '        Session("pos_area") = pos_area
    '    End If
    '    mlREADER.Close()

    '    dcHO = ""
    '    If mypos = dcHO Then
    '        namatabel = "st_kartustock"
    '        namatabel2 = "st_barang"
    '    Else
    '        namatabel = "st_kartustock_ms"
    '        namatabel2 = "st_barang_ms"
    '    End If

    '    kode = UCase(Request("kode"))
    '    jumlah = Request("jumlah")

    '    If kode = "" Then
    '        mlREADER2 = Nothing
    '        mlREADER = Nothing
    '        Session("errorfax") = "Anda belum mengisikan kode produk"
    '        Response.Redirect(kemana)
    '    End If

    '    If IsNumeric(jumlah) = False Then
    '        mlREADER2 = Nothing
    '        mlREADER = Nothing
    '        Session("errorfax") = "Anda belum mengisikan jumlah produk diorder"
    '        Response.Redirect(kemana)
    '    End If

    '    If jumlah = 0 Or jumlah <= 0 Then
    '        mlREADER2 = Nothing
    '        mlREADER = Nothing
    '        Session("errorfax") = "Anda belum mengisikan jumlah produk diorder"
    '        Response.Redirect(kemana)
    '    End If

    '    CheckStockAlocationForStarterKit()
    '    CheckStockAvailabel()
    'End Sub
    'Protected Sub CheckStockAlocationForStarterKit()
    '    ''''''''''''''''''''''''''''''''''''''
    '    ' CEK STOCK ALOKASI UNTUK STARTERKIT
    '    ''''''''''''''''''''''''''''''''''''''
    '    gggs = "AKT"
    '    gggs1 = "UPG"
    '    jumlahalokakt = 0
    '    mlSQL = "SELECT kode,jumlah FROM " & namatabel2 & " where nopos like '" & mypos & "' and (grp like '" & gggs & "' or grp like '" & gggs1 & "')"
    '    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
    '    If mlREADER.HasRows <> True Then
    '        For aaaeqSSS = 1 To 44 ' 44 ini apa ya?
    '            If mlREADER.HasRows = True Then Exit For
    '            kode1s = mlREADER("kode")
    '            jumlah1s = mlREADER("jumlah")

    '            mlSQL2 = "SELECT * FROM st_tipe_paket_jumlah where paket like '" & kode1s & "' and kode like '" & kode & "'"
    '            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '            mlREADER2.Read()

    '            If Not mlREADER2.HasRows Then
    '                jumakt = 0
    '            Else
    '                jumakt = mlREADER2("jumlah")
    '            End If
    '            mlREADER2.Close()
    '            jumpaket = (jumlah1s * jumakt)
    '            jumlahalokakt = jumlahalokakt + jumpaket
    '        Next
    '    End If
    '    mlREADER.Close()
    'End Sub
    'Protected Sub CheckStockAvailabel()
    '    ''''''''''''''''''''''''''''''''''''''
    '    ' CEK STOCK AVAILABLE
    '    ' AMBIL HARGA ZONA
    '    ''''''''''''''''''''''''''''''''''''''

    '    diorder = 0
    '    sisa = 0
    '    sta = 1
    '    sts = 0 ' empty not fill
    '    ggg = "PRD"
    '    ste = "T"
    '    lanjutdodol = "F"

    '    If mypos = dcHO Then
    '        mlSQL2 = "SELECT * FROM " & namatabel2 & " where kode like '" & kode & "' and grp like '" & ggg & "' and sta like '" & ste & "'"
    '    Else
    '        mlSQL2 = "SELECT * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode & "'" & vbCrLf
    '        mlSQL2 += "And grp Like '" & ggg & "' and sta like '" & ste & "'"
    '    End If

    '    mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '    mlREADER2.Read()

    '    If Not mlREADER2.HasRows Then
    '        mlREADER2.Close()
    '        mlREADER2 = Nothing
    '        lanjutdodol = "F"
    '        Session("errorfax") = "Kode produk tidak terdaftar"
    '        Response.Redirect(kemana)
    '    Else
    '        diorder2 = 0
    '        totdiod = 0
    '        If mypos = dcHO Then
    '            mlSQL = "SELECT sum(jumlah) FROM fin_sample_det where kode like '" & kode & "'" & vbCrLf
    '            mlSQL += "And dcinduk Like '" & indukdc & "' and (status like '" & sta & "') group by kode"
    '            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
    '            mlREADER.Read()

    '            If Not mlREADER.HasRows Then
    '                diorder2 = 0
    '            Else
    '                diorder2 = CInt(mlREADER("sum(jumlah)"))
    '            End If
    '            mlREADER.Close()
    '        Else
    '            diorder2 = 0
    '        End If

    '        jumstok = mlREADER2("jumlah")
    '        mlSQL = "SELECT sum(jumlah) FROM fx_order_mc_det where kode like '" & kode & "'" & vbCrLf
    '        mlSQL += "And nopos Like '" & mypos & "' and (status like '" & sts & "') and kat like '" & kti & "' group by kode"
    '        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
    '        mlREADER.Read()

    '        If Not mlREADER.HasRows Then
    '            diorder = 0
    '        Else
    '            diorder = CInt(mlREADER("sum(jumlah)"))
    '        End If
    '        mlREADER.Close()
    '        totdiod = diorder + diorder2
    '        sisastok = jumstok - (Int(jumlah) + jumlahalokakt + totdiod)

    '        If mypos = dcHO Then 'HANYA kantor pusat yang bisa jual tanpa memiliki stok ADD BY PETER 26 juli 2013 12:09:11 WIB
    '            lanjutdodol = "T"
    '        Else
    '            If sisastok >= 0 Then
    '                lanjutdodol = "T"
    '            Else
    '                lanjutdodol = "F"
    '            End If
    '        End If

    '        namabrg = mlREADER2("nama")
    '        PV = mlREADER2("pv")
    '        bv = mlREADER2("bv")
    '        If pos_area = "1" Then
    '            hargabrg = mlREADER2("hd1")
    '            kusus1 = mlREADER2("khususmc1")
    '            If kusus1 <> 0 Then
    '                hargabrg = kusus1
    '            Else
    '                hargabrg = hargabrg
    '            End If
    '        Else
    '            If pos_area = "2" Then
    '                hargabrg = mlREADER2("hd2")
    '                kusus2 = mlREADER2("khususmc2")
    '                If kusus2 <> 0 Then
    '                    hargabrg = kusus2
    '                Else
    '                    hargabrg = hargabrg
    '                End If
    '            Else
    '                If pos_area = "3" Then
    '                    hargabrg = mlREADER2("hd3")
    '                    kusus3 = mlREADER2("khususmc3")
    '                    If kusus3 <> 0 Then
    '                        hargabrg = kusus3
    '                    Else
    '                        hargabrg = hargabrg
    '                    End If
    '                Else
    '                    If pos_area = "4" Then
    '                        hargabrg = mlREADER2("hd4")
    '                        kusus4 = mlREADER2("khususmc4")
    '                        If kusus4 <> 0 Then
    '                            hargabrg = kusus4
    '                        Else
    '                            hargabrg = hargabrg
    '                        End If
    '                    Else
    '                        If pos_area = "5" Then
    '                            hargabrg = mlREADER2("hd5")
    '                            kusus5 = mlREADER2("khususmc5")
    '                            If kusus5 <> 0 Then
    '                                hargabrg = kusus5
    '                            Else
    '                                hargabrg = hargabrg
    '                            End If
    '                        Else
    '                            mlREADER2 = Nothing
    '                            Session("out") = "Session login anda sudah expired, silahkan login kembali"
    '                            Response.Redirect("login.aspx")
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    End If
    '    mlREADER2.Close()


    '    'lanjutdodol = "T"
    '    If lanjutdodol = "T" Then ' jika stock mencukupi
    '        mlSQL2 = "SELECT count(id) FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
    '        mlSQL2 += "And nopos Like '" & nodc & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "' group by nosesi"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        mlREADER2.Read()

    '        If Not mlREADER2.HasRows Then
    '            jumskr = 0
    '        Else
    '            jumskr = CLng(mlREADER2("count(id)"))
    '        End If
    '        mlREADER2.Close()

    '        If jumskr < 10 Then
    '            If nosesifaxmc_pdn = "" Then ' bikin nomor session
    '                mlSQL2 = "SELECT top 1 nosesi FROM fax_order_mc_head where nopos like '" & mypos & "' order by nosesi DESC"
    '                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '                mlREADER2.Read()

    '                If Not mlREADER2.HasRows Then
    '                    akhire = 1
    '                Else
    '                    akhire = mlREADER2("nosesi") + 1
    '                End If
    '                mlREADER2.Close()
    '            Else
    '                akhire = nosesifaxmc_pdn ' gunakan nomor session existing
    '            End If
    '            Session("nosesifaxmc_pdn") = akhire
    '            nosesifaxmc_pdn = akhire

    '            ''''''''''''''''''''''''''''''''
    '            ' SAVE TO TEMPORARY TABLE DETAIL
    '            ''''''''''''''''''''''''''''''''
    '            mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
    '            mlSQL2 += "And nopos Like '" & nodc & "' and kode like '" & kode & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '            mlREADER2.Read()

    '            If Not mlREADER2.HasRows Then
    '                updit = "F"
    '                mlSQL = "Insert into fx_order_mc_det(nopos,nosesi,kode,nama,jumlah,harga,pv,subtot,totpv,nofax,status,tglorder,tipe,dcinduk,indukmc,kat)Values" & vbCrLf
    '                mlSQL += "('" & nodc & "','" & nosesifaxmc_pdn & "','" & kode & "','" & namabrg & "','" & jumlah & "','" & hargabrg & "','" & PV & "','" & hargabrg * jumlah & "'" & vbCrLf
    '                mlSQL += ",'" & PV * jumlah & "','-',0,'" & dino & "','PRD','" & indukdc & "','" & nodc & "','" & kti & "')"
    '                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
    '            Else
    '                updit = "T"
    '                jumlama = mlREADER2("jumlah")
    '                pvlama = mlREADER2("pv")
    '                subtotlama = mlREADER2("subtot")
    '                totpvlama = mlREADER2("totpv")
    '                mlSQL = "Update fx_order_mc_det set nama = '" & namabrg & "',jumlah = '" & jumlah & "',harga = '" & harga & "',pv = '" & PV & "',subtot = '" & hargabrg * jumlah & "'" & vbCrLf
    '                mlSQL += ",totpv = '" & PV * jumlah & "',tglorder = '" & dino & "',tipe = 'PRD', kat = '" & kti & "' Where nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
    '                mlSQL += "And nopos Like '" & nodc & "' and kode like '" & kode & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
    '                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
    '            End If
    '            mlREADER2.Close()

    '            ''''''''''''''''''''''''''''''''
    '            ' SAVE TO TEMPORARY TABLE HEAD
    '            ''''''''''''''''''''''''''''''''
    '            mlSQL2 = "SELECT * FROM fax_order_mc_head where nopos Like '" & nodc & "'" & vbCrLf
    '            mlSQL2 += "And nosesi Like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '            mlREADER2.Read()

    '            Dim potongan, status, urut As Integer
    '            Dim noinvo As String

    '            If Not mlREADER2.HasRows Then
    '                nodc = nodc
    '                babe = babe
    '                nosesifaxmc_pdn = nosesifaxmc_pdn
    '                totpv = PV * jumlah
    '                totbv = bv * jumlah
    '                subtot = hargabrg * jumlah
    '                tgl = dino
    '                diskon = diskon
    '                potongan = 0
    '                gtot = 0
    '                status = 0
    '                tipe = "PRD"
    '                urut = 0
    '                noinvo = "-"
    '            Else
    '                If updit = "F" Then
    '                    nodc = nodc
    '                    babe = babe
    '                    nosesifaxmc_pdn = nosesifaxmc_pdn
    '                    nofax = nofax
    '                    totpv = mlREADER2("totpv") + (PV * jumlah)
    '                    subtot = mlREADER2("subtot") + (hargabrg * jumlah)
    '                    tipe = mlREADER2("tipe")
    '                    tgl = dino
    '                    urut = 0
    '                    noinvo = "-"
    '                    diskon = mlREADER2("diskon")
    '                    potongan = mlREADER2("potongan")
    '                    gtot = mlREADER2("gtot")
    '                    status = mlREADER2("status")
    '                Else
    '                    nodc = nodc
    '                    babe = babe
    '                    nosesifaxmc_pdn = nosesifaxmc_pdn
    '                    nofax = nofax
    '                    totpv = (mlREADER2("totpv") - (pvlama * jumlama)) + (PV * jumlah)
    '                    subtot = (mlREADER2("subtot") - subtotlama) + (hargabrg * jumlah)
    '                    tipe = mlREADER2("tipe")
    '                    tgl = dino
    '                    urut = 0
    '                    noinvo = "-"
    '                    diskon = mlREADER2("diskon")
    '                    potongan = mlREADER2("potongan")
    '                    gtot = mlREADER2("gtot")
    '                    status = mlREADER2("status")
    '                End If
    '                'rsALL.delete
    '                'rsALL.update
    '            End If
    '            mlREADER2.Close()


    '            mlSQL2 = "SELECT * FROM fax_order_mc_head where nopos like '" & nodc & "'" & vbCrLf
    '            mlSQL2 += "And nosesi Like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '            mlREADER2.Read()

    '            If Not mlREADER2.HasRows Then
    '                mlSQL = "Insert into fax_order_mc_head(nopos,entry,nosesi,nofax,totpv,subtot,tgl,diskon,potongan,gtot,status,tipe,urut,noinvo,dcinduk,indukmc,kat)" & vbCrLf
    '                mlSQL += "Values('" & nodc & "','" & babe & "','" & nosesifaxmc_pdn & "','" & nofax & "','" & totpv & "','" & subtot & "','" & tgl & "','" & diskon & "'" & vbCrLf
    '                mlSQL += ",'" & potongan & "','" & gtot & "','" & status & "','" & tipe & "','" & urut & "','" & noinvo & "','" & indukdc & "','" & nodc & "','" & kti & "')"
    '                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
    '            End If
    '            mlREADER2.Close()

    '            Session("errorfax") = ""
    '            Response.Redirect(kemana)

    '        Else ' akhir maksimal 10 item / invoice
    '            'mlREADER2 = Nothing

    '            Session("errorfax") = "Maksimal 1 invoice terdiri dari 10 item produk, silahkan melakukan chekcout dan membuka invoice baru"
    '            Response.Redirect(kemana)
    '        End If

    '    Else ' akhir cek sisa stok
    '        Session("errorfax") = "Sisa stock tidak mencukupi untuk dilakukan transaksi ini: " & sisastok & " ."
    '        Response.Redirect(kemana)
    '    End If
    'End Sub

    'Protected Sub ms4_perdana_clear()
    '    Dim nosesifaxmc_akt As String
    '    Session("tema") = "home"
    '    Session("menu_id") = Session("menu_id")
    '    menu_id = Session("menu_id")
    '    pos_area = Session("pos_area")
    '    mypos = UCase(Session("motok"))
    '    loguser = Session("kowe")
    '    kelasdc = Session.Contents("kelasdc")
    '    indukdc = Session.Contents("indukdc")
    '    nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
    '    nosesifaxmc_akt = Session("nosesifaxmc_akt")
    '    nodc = UCase(Session("motok"))
    '    If Session("motok") = "" Or Session("kowe") = "" Then
    '        Session("out") = "Session login anda sudah expired, silahkan login kembali"
    '        Response.Redirect("login.aspx")
    '    Else
    '        Session("motok") = mypos
    '        Session("kowe") = loguser
    '        Session.Contents("kelasdc") = kelasdc
    '        Session.Contents("indukdc") = indukdc
    '    End If

    '    asal = Request("grp")
    '    kti = Session("kti")

    '    If asal = "PRD" Then
    '        kemana = "ms4_perdana.aspx?menu_id=" & menu_id
    '    Else
    '        kemana = "ms_order_register.aspx?menu_id=" & menu_id
    '    End If

    '    ''''''''''''''''''''''''''''''''
    '    ' SAVE TO TEMPORARY TABLE DETAIL
    '    ''''''''''''''''''''''''''''''''
    '    If asal = "PRD" Then
    '        kode = Session("nosesifaxmc_pdn")
    '        If kode = "" Then
    '            Session("errorfax") = "Session fax order sudah expired"
    '            Response.Redirect(kemana)
    '        End If

    '        mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi Like '" & nosesifaxmc_pdn & "'" & vbCrLf
    '        mlSQL2 += "And nopos Like '" & mypos & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        mlREADER2.Read()

    '        mlSQL = "SELECT * FROM fax_order_mc_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
    '        mlSQL += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
    '        mlREADER.Read()
    '        If mlREADER.HasRows Then
    '            mlSQL3 = "Update fax_order_mc_head set nofax = '-',nomc = '-',nopos = '-',totpv = 0, subtot = 0, diskon = 0, potongan = 0, gtot = 0, tipe = '-',status = -1" & vbCrLf
    '            mlSQL3 += "where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        mlREADER.Close()
    '        Session("nosesifaxmc_pdn") = ""
    '    End If
    '    mlREADER2.Close()

    '    If asal = "AKT" Then
    '        kode = Session("nosesifaxmc_akt")
    '        If kode = "" Then
    '            Session("errorfax") = "Session fax order sudah expired"
    '            Response.Redirect(kemana)
    '        End If
    '        ''''''''''''''''''''''''''''''''
    '        ' EDIT TEMPORARY TABLE DETAIL
    '        ''''''''''''''''''''''''''''''''
    '        mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '        mlSQL2 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        'mlREADER2.Read()
    '        If mlREADER2.HasRows Then
    '            mlSQL3 = "Delete FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '            mlSQL3 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        mlREADER2.Close()

    '        mlSQL2 = "SELECT * FROM fax_order_mc_paket_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_akt & "'" & vbCrLf
    '        mlSQL2 += "dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        mlREADER2.Read()
    '        If mlREADER2.HasRows Then
    '            mlSQL3 = "Delete From fax_order_mc_paket_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_akt & "'" & vbCrLf
    '            mlSQL3 += "dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        mlREADER2.Close()

    '        mlSQL2 = "SELECT * FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '        mlSQL2 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        mlREADER2.Read()
    '        If mlREADER2.HasRows Then
    '            mlSQL3 = "Delete From fax_order_mc_head where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '            mlSQL3 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        Session("nosesifaxmc_akt") = ""
    '    End If

    '    Session("pos_area") = ""
    '    Session("errorfax") = ""
    '    Session("namadis_mc") = ""
    '    Session("nokode_mc") = ""
    '    Response.Redirect(kemana)
    'End Sub
End Class

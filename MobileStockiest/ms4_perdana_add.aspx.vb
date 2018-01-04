Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_ms4_perdana_add
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

    Dim menu_id, mypos, nodc, loguser, kelasdc, indukdc, kti, asal, nofax, nosesifaxmc_pdn, dcpusat As String
    Dim sds As Double
    Dim dino As Date

    Dim disk_mc, diskon, pos_area As Double
    Dim tipe, kemana, dcHO, namatabel, namatabel2, kode, jumlah As String

    Dim gggs, gggs1, kode1s As String
    Dim jumlahalokakt, jumlah1s, jumakt, jumpaket As Double

    Dim diorder, sisa, sta, sts, diorder2, totdiod, jumstok, sisastok, PV, bv, hargabrg, kusus1, kusus2, kusus3, kusus4, kusus5, akhire, jumlama, pvlama, subtotlama, totpvlama, harga As Double
    Dim ggg, ste, lanjutdodol, namabrg, updit As String
    Dim jumskr As Long
    Dim potongan, status, urut As Integer
    Dim noinvo As String
    Dim babe As String
    Dim totpv, totbv, subtot, gtot As Double
    Dim tgl As Date


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")
        mypos = UCase(Session("motok"))
        nodc = UCase(Session("motok"))
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        kti = Session("kti")
        asal = Request("asal")
        nofax = ""
        sds = 0
        Session("dcpusate") = dcpusat
        dino = Now()
        nosesifaxmc_pdn = Session("nosesifaxmc_pdn")

        If Session("motok") = "" Or Session("kowe") = "" Or Session("kti") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        PrepareData()
        CheckStockAlocationForStarterKit()
        CheckStockAvailabel()
    End Sub

    Sub PrepareData()
        disk_mc = "0"
        tipe = "PRD"
        asal = "PRD"
        diskon = disk_mc
        If asal = "normal" Then
            kemana = "ms_order_produk.aspx?menu_id=" & menu_id
        Else
            kemana = "ms4_perdana.aspx?menu_id=" & menu_id
        End If

        mlSQL = "SELECT induk,kelas,area FROM tabdesc_stockist WHERE nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlREADER.Close()
            mlREADER = Nothing
            Response.Redirect("logout.aspx")
        Else
            pos_area = mlREADER("area")
            indukdc = mlREADER("induk")
            kelasdc = mlREADER("kelas")
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session("pos_area") = pos_area
        End If
        mlREADER.Close()

        dcHO = ""
        If mypos = dcHO Then
            namatabel = "st_kartustock"
            namatabel2 = "st_barang"
        Else
            namatabel = "st_kartustock_ms"
            namatabel2 = "st_barang_ms"
        End If

        kode = UCase(Request("kode"))
        jumlah = Request("jumlah")

        If kode = "" Then
            mlREADER2 = Nothing
            mlREADER = Nothing
            Session("errorfax") = "Anda belum mengisikan kode produk"
            Response.Redirect(kemana)
        End If

        If IsNumeric(jumlah) = False Then
            mlREADER2 = Nothing
            mlREADER = Nothing
            Session("errorfax") = "Anda belum mengisikan jumlah produk diorder"
            Response.Redirect(kemana)
        End If

        If jumlah = 0 Or jumlah <= 0 Then
            mlREADER2 = Nothing
            mlREADER = Nothing
            Session("errorfax") = "Anda belum mengisikan jumlah produk diorder"
            Response.Redirect(kemana)
        End If
    End Sub

    Sub CheckStockAlocationForStarterKit()
        ''''''''''''''''''''''''''''''''''''''
        ' CEK STOCK ALOKASI UNTUK STARTERKIT
        ''''''''''''''''''''''''''''''''''''''
        gggs = "AKT"
        gggs1 = "UPG"
        jumlahalokakt = 0
        mlSQL = "SELECT kode,jumlah FROM " & namatabel2 & " where nopos like '" & mypos & "' and (grp like '" & gggs & "' or grp like '" & gggs1 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows <> True Then
            For aaaeqSSS = 1 To 44 ' 44 ini apa ya?
                If mlREADER.HasRows = True Then Exit For
                kode1s = mlREADER("kode")
                jumlah1s = mlREADER("jumlah")

                mlSQL2 = "SELECT * FROM st_tipe_paket_jumlah where paket like '" & kode1s & "' and kode like '" & kode & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()

                If Not mlREADER2.HasRows Then
                    jumakt = 0
                Else
                    jumakt = mlREADER2("jumlah")
                End If
                mlREADER2.Close()
                jumpaket = (jumlah1s * jumakt)
                jumlahalokakt = jumlahalokakt + jumpaket
            Next
        End If
        mlREADER.Close()
    End Sub
    Sub CheckStockAvailabel()
        ''''''''''''''''''''''''''''''''''''''
        ' CEK STOCK AVAILABLE
        ' AMBIL HARGA ZONA
        ''''''''''''''''''''''''''''''''''''''
        diorder = 0
        sisa = 0
        sta = 1
        sts = 0 ' empty not fill
        ggg = "PRD"
        ste = "T"
        lanjutdodol = "F"

        If mypos = dcHO Then
            mlSQL2 = "SELECT * FROM " & namatabel2 & " where kode like '" & kode & "' and grp like '" & ggg & "' and sta like '" & ste & "'"
        Else
            mlSQL2 = "SELECT * FROM " & namatabel2 & " where nopos like '" & mypos & "' and kode like '" & kode & "'" & vbCrLf
            mlSQL2 += "And grp Like '" & ggg & "' and sta like '" & ste & "'"
        End If

        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER2.Read()

        If Not mlREADER2.HasRows Then
            mlREADER2.Close()
            mlREADER2 = Nothing
            lanjutdodol = "F"
            Session("errorfax") = "Kode produk tidak terdaftar"
            Response.Redirect(kemana)
        Else
            diorder2 = 0
            totdiod = 0
            If mypos = dcHO Then
                mlSQL = "SELECT sum(jumlah) FROM fin_sample_det where kode like '" & kode & "'" & vbCrLf
                mlSQL += "And dcinduk Like '" & indukdc & "' and (status like '" & sta & "') group by kode"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()

                If Not mlREADER.HasRows Then
                    diorder2 = 0
                Else
                    diorder2 = CInt(mlREADER("sum(jumlah)"))
                End If
                mlREADER.Close()
            Else
                diorder2 = 0
            End If

            jumstok = mlREADER2("jumlah")
            mlSQL = "SELECT sum(jumlah) FROM fx_order_mc_det where kode like '" & kode & "'" & vbCrLf
            mlSQL += "And nopos Like '" & mypos & "' and (status like '" & sts & "') and kat like '" & kti & "' group by kode"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()

            If Not mlREADER.HasRows Then
                diorder = 0
            Else
                diorder = CInt(mlREADER("sum(jumlah)"))
            End If
            mlREADER.Close()
            totdiod = diorder + diorder2
            sisastok = jumstok - (Int(jumlah) + jumlahalokakt + totdiod)

            If mypos = dcHO Then 'HANYA kantor pusat yang bisa jual tanpa memiliki stok ADD BY PETER 26 juli 2013 12:09:11 WIB
                lanjutdodol = "T"
            Else
                If sisastok >= 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                End If
            End If

            namabrg = mlREADER2("nama")
            PV = mlREADER2("pv")
            bv = mlREADER2("bv")
            If pos_area = "1" Then
                hargabrg = mlREADER2("hd1")
                kusus1 = mlREADER2("khususmc1")
                If kusus1 <> 0 Then
                    hargabrg = kusus1
                Else
                    hargabrg = hargabrg
                End If
            Else
                If pos_area = "2" Then
                    hargabrg = mlREADER2("hd2")
                    kusus2 = mlREADER2("khususmc2")
                    If kusus2 <> 0 Then
                        hargabrg = kusus2
                    Else
                        hargabrg = hargabrg
                    End If
                Else
                    If pos_area = "3" Then
                        hargabrg = mlREADER2("hd3")
                        kusus3 = mlREADER2("khususmc3")
                        If kusus3 <> 0 Then
                            hargabrg = kusus3
                        Else
                            hargabrg = hargabrg
                        End If
                    Else
                        If pos_area = "4" Then
                            hargabrg = mlREADER2("hd4")
                            kusus4 = mlREADER2("khususmc4")
                            If kusus4 <> 0 Then
                                hargabrg = kusus4
                            Else
                                hargabrg = hargabrg
                            End If
                        Else
                            If pos_area = "5" Then
                                hargabrg = mlREADER2("hd5")
                                kusus5 = mlREADER2("khususmc5")
                                If kusus5 <> 0 Then
                                    hargabrg = kusus5
                                Else
                                    hargabrg = hargabrg
                                End If
                            Else
                                mlREADER2 = Nothing
                                Session("out") = "Session login anda sudah expired, silahkan login kembali"
                                Response.Redirect("login.aspx")
                            End If
                        End If
                    End If
                End If
            End If
        End If
        mlREADER2.Close()


        'lanjutdodol = "T"
        If lanjutdodol = "T" Then ' jika stock mencukupi
            mlSQL2 = "SELECT count(id) FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
            mlSQL2 += "And nopos Like '" & nodc & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "' group by nosesi"
            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER2.Read()

            If Not mlREADER2.HasRows Then
                jumskr = 0
            Else
                jumskr = CLng(mlREADER2("count(id)"))
            End If
            mlREADER2.Close()

            If jumskr < 10 Then
                If nosesifaxmc_pdn = "" Then ' bikin nomor session
                    mlSQL2 = "SELECT top 1 nosesi FROM fax_order_mc_head where nopos like '" & mypos & "' order by nosesi DESC"
                    mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                    mlREADER2.Read()

                    If Not mlREADER2.HasRows Then
                        akhire = 1
                    Else
                        akhire = mlREADER2("nosesi") + 1
                    End If
                    mlREADER2.Close()
                Else
                    akhire = nosesifaxmc_pdn ' gunakan nomor session existing
                End If
                Session("nosesifaxmc_pdn") = akhire
                nosesifaxmc_pdn = akhire

                ''''''''''''''''''''''''''''''''
                ' SAVE TO TEMPORARY TABLE DETAIL
                ''''''''''''''''''''''''''''''''
                mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
                mlSQL2 += "And nopos Like '" & nodc & "' and kode like '" & kode & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()

                If Not mlREADER2.HasRows Then
                    updit = "F"
                    mlSQL = "Insert into fx_order_mc_det(nopos,nosesi,kode,nama,jumlah,harga,pv,subtot,totpv,nofax,status,tglorder,tipe,dcinduk,indukmc,kat)Values" & vbCrLf
                    mlSQL += "('" & nodc & "','" & nosesifaxmc_pdn & "','" & kode & "','" & namabrg & "','" & jumlah & "','" & hargabrg & "','" & PV & "','" & hargabrg * CDbl(jumlah) & "'" & vbCrLf
                    mlSQL += ",'" & PV * CDbl(jumlah) & "','-',0,'" & dino & "','PRD','" & indukdc & "','" & nodc & "','" & kti & "')"
                    mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                Else
                    updit = "T"
                    jumlama = mlREADER2("jumlah")
                    pvlama = mlREADER2("pv")
                    subtotlama = mlREADER2("subtot")
                    totpvlama = mlREADER2("totpv")
                    mlSQL = "Update fx_order_mc_det set nama = '" & namabrg & "',jumlah = '" & jumlah & "',harga = '" & harga & "',pv = '" & PV & "',subtot = '" & hargabrg * CDbl(jumlah) & "'" & vbCrLf
                    mlSQL += ",totpv = '" & PV * CDbl(jumlah) & "',tglorder = '" & dino & "',tipe = 'PRD', kat = '" & kti & "' Where nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
                    mlSQL += "And nopos Like '" & nodc & "' and kode like '" & kode & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
                    mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER2.Close()

                ''''''''''''''''''''''''''''''''
                ' SAVE TO TEMPORARY TABLE HEAD
                ''''''''''''''''''''''''''''''''
                mlSQL2 = "SELECT * FROM fax_order_mc_head where nopos Like '" & nodc & "'" & vbCrLf
                mlSQL2 += "And nosesi Like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()


                babe = ""
                If Not mlREADER2.HasRows Then
                    nodc = nodc
                    babe = babe
                    nosesifaxmc_pdn = nosesifaxmc_pdn
                    totpv = PV * CDbl(jumlah)
                    totbv = bv * CDbl(jumlah)
                    subtot = hargabrg * CDbl(jumlah)
                    tgl = dino
                    diskon = diskon
                    potongan = 0
                    gtot = 0
                    status = 0
                    tipe = "PRD"
                    urut = 0
                    noinvo = "-"
                Else
                    If updit = "F" Then
                        nodc = nodc
                        babe = babe
                        nosesifaxmc_pdn = nosesifaxmc_pdn
                        nofax = nofax
                        totpv = mlREADER2("totpv") + (PV * CDbl(jumlah))
                        subtot = mlREADER2("subtot") + (hargabrg * CDbl(jumlah))
                        tipe = mlREADER2("tipe")
                        tgl = dino
                        urut = 0
                        noinvo = "-"
                        diskon = mlREADER2("diskon")
                        potongan = mlREADER2("potongan")
                        gtot = mlREADER2("gtot")
                        status = mlREADER2("status")
                    Else
                        nodc = nodc
                        babe = babe
                        nosesifaxmc_pdn = nosesifaxmc_pdn
                        nofax = nofax
                        totpv = (mlREADER2("totpv") - (pvlama * jumlama)) + (PV * CDbl(jumlah))
                        subtot = (mlREADER2("subtot") - subtotlama) + (hargabrg * CDbl(jumlah))
                        tipe = mlREADER2("tipe")
                        tgl = dino
                        urut = 0
                        noinvo = "-"
                        diskon = mlREADER2("diskon")
                        potongan = mlREADER2("potongan")
                        gtot = mlREADER2("gtot")
                        status = mlREADER2("status")
                    End If
                    'rsALL.delete
                    'rsALL.update
                End If
                mlREADER2.Close()


                mlSQL2 = "SELECT * FROM fax_order_mc_head where nopos like '" & nodc & "'" & vbCrLf
                mlSQL2 += "And nosesi Like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()

                If Not mlREADER2.HasRows Then
                    mlSQL = "Insert into fax_order_mc_head(nopos,entry,nosesi,nofax,totpv,subtot,tgl,diskon,potongan,gtot,status,tipe,urut,noinvo,dcinduk,indukmc,kat)" & vbCrLf
                    mlSQL += "Values('" & nodc & "','" & babe & "','" & nosesifaxmc_pdn & "','" & nofax & "','" & totpv & "','" & subtot & "','" & tgl & "','" & diskon & "'" & vbCrLf
                    mlSQL += ",'" & potongan & "','" & gtot & "','" & status & "','" & tipe & "','" & urut & "','" & noinvo & "','" & indukdc & "','" & nodc & "','" & kti & "')"
                    mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                End If
                mlREADER2.Close()

                Session("errorfax") = ""
                Response.Redirect(kemana)

            Else ' akhir maksimal 10 item / invoice
                'mlREADER2 = Nothing

                Session("errorfax") = "Maksimal 1 invoice terdiri dari 10 item produk, silahkan melakukan chekcout dan membuka invoice baru"
                Response.Redirect(kemana)
            End If

        Else ' akhir cek sisa stok
            Session("errorfax") = "Sisa stock tidak mencukupi untuk dilakukan transaksi ini: " & sisastok & " ."
            Response.Redirect(kemana)
        End If
    End Sub
End Class

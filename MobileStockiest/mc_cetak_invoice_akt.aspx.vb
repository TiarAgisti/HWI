Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_cetak_invoice_akt
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Protected pos_area, mypos, loguser, kelasdc, indukdc, indukmc, idstk2, namaperus, alamatperus, kotaperus, kodeposperus, telpperus, noinvo, lanjut As String
    Protected nopos, noslip, nopajak, namakasir, nomc, paket, namapaket, nomce, namamc, namauser, namatabel, namatabel2 As String
    Protected subtot, stot, gtot, PV, bv, tunai, debit, cc, vouc, jumbayar, kembalian, diskon, harga, jumorder, pir, kepiro As Double
    Protected tgl, tglnya As Date

    Protected kode_prd1, kode_prd2, kode_prd3, kode_prd4, kode_prd5, kode_prd6, kode_prd7, kode_prd8, kode_prd9, kode_prd10, kode_prd11, kode_prd12 As String
    Protected jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10, jumlah11, jumlah12 As Double
    Protected nama_prd1, nama_prd2, nama_prd3, nama_prd4, nama_prd5, nama_prd6, nama_prd7, nama_prd8, nama_prd9, nama_prd10, nama_prd11, nama_prd12 As String
    Protected produk1, produk2, produk3, produk4, produk5, produk6, produk7, produk8, produk9, produk10, produk11, produk12 As String
    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, asale As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        indukmc = Session.Contents("indukmc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session.Contents("indukmc") = indukmc
        End If

        PrepareData()
        PrepareDisplay()
    End Sub

    Sub PrepareData()

        idstk2 = indukmc
        mlSQL = "SELECT * FROM tabdesc_stockist where nopos like  '" & idstk2 & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namaperus = ""
            alamatperus = ""
            kotaperus = ""
            Session("pop") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            namaperus = mlREADER("nama")
            alamatperus = mlREADER("alamat")
            kotaperus = mlREADER("kota")
            kodeposperus = mlREADER("kodepos")
            telpperus = mlREADER("telp")
        End If
        mlREADER.Close()

        noinvo = Request("noinvoice")
        mlSQL = "SELECT * FROM fax_order_mc_head where nomc like '" & mypos & "' and noinvo like '" & noinvo & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjut = "F"
        Else
            lanjut = "T"
            nopos = mlREADER("nopos")
            nomc = mlREADER("nomc")
            tgl = mlREADER("tgl")
            noslip = mlREADER("noinvo")
            subtot = mlREADER("subtot")
            stot = mlREADER("subtot")
            gtot = mlREADER("gtot")
            PV = mlREADER("totpv")
            bv = 0
            tunai = mlREADER("tunai")
            debit = mlREADER("debit")
            cc = mlREADER("cc")
            vouc = mlREADER("cek")
            jumbayar = mlREADER("jumbayar")
            kembalian = mlREADER("kembalian")
            namakasir = mlREADER("kta")
            tglnya = mlREADER("tgl")
            nopajak = mlREADER("nopajak")
            diskon = mlREADER("diskon")
        End If
        mlREADER.Close()

        mlSQL = "SELECT * FROM fax_order_mc_paket_head where nomc like '" & mypos & "' and noinvo like '" & noinvo & "' and nomc like '" & nomc & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            paket = mlREADER("paket")
            harga = mlREADER("harga")
            jumorder = mlREADER("jumlah")
            namapaket = mlREADER("namapaket")
        End If
        mlREADER.Close()

        pir = Len(nomc)
        If pir = 10 Then
            nomce = Right(nomc, 7)
        Else
            nomce = Right(nomc, 8)
        End If

        mlSQL = "SELECT uid FROM member where kta like '" & nomce & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            namamc = "-"
        Else
            namamc = mlREADER("uid")
        End If
        mlREADER.Close()

        mlSQL = "SELECT kta FROM tabdesc_stockist_user where nopos like '" & nomc & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows Then
            namauser = "-"
        Else
            namauser = mlREADER("kta")
        End If
        mlREADER.Close()
        kepiro = 0

        namatabel = "st_barang_dc"
        namatabel2 = "st_kartustock_dc"

    End Sub

    Sub PrepareDisplay()
        If lanjut = "T" Then
            'rsALL.Open "SELECT nama FROM "&namatabel&" where nopos like '"&nomc&"' and kode like '"&paket&"' order by id",connALL
            '	if rsALL.bof then
            '	else
            '		namapaket = rsALL("nama")	
            '	end if					
            'rsALL.close
            mlSQL = "SELECT * FROM st_tipe_paket where kode like '" & paket & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                kode_prd1 = "-"
            Else
                kode_prd1 = mlREADER("kode_prd1")
                jumlah1 = mlREADER("jumlah1") * jumorder
                kode_prd2 = mlREADER("kode_prd2")
                jumlah2 = mlREADER("jumlah2") * jumorder
                kode_prd3 = mlREADER("kode_prd3")
                jumlah3 = mlREADER("jumlah3") * jumorder
                kode_prd4 = mlREADER("kode_prd4")
                jumlah4 = mlREADER("jumlah4") * jumorder
                kode_prd5 = mlREADER("kode_prd5")
                jumlah5 = mlREADER("jumlah5") * jumorder
                kode_prd6 = mlREADER("kode_prd6")
                jumlah6 = mlREADER("jumlah6") * jumorder
                kode_prd7 = mlREADER("kode_prd7")
                jumlah7 = mlREADER("jumlah7") * jumorder
                kode_prd8 = mlREADER("kode_prd8")
                jumlah8 = mlREADER("jumlah8") * jumorder
                kode_prd9 = mlREADER("kode_prd9")
                jumlah9 = mlREADER("jumlah9") * jumorder
                kode_prd10 = mlREADER("kode_prd10")
                jumlah10 = mlREADER("jumlah10") * jumorder
                kode_prd11 = mlREADER("kode_prd11")
                jumlah11 = mlREADER("jumlah11") * jumorder
                kode_prd12 = mlREADER("kode_prd12")
                jumlah12 = mlREADER("jumlah12") * jumorder
            End If
            mlREADER.Close()

            If kode_prd1 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd1 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd1 = "-"
                    produk1 = "-"
                Else
                    nama_prd1 = mlREADER("nama")
                    produk1 = CStr(jumlah1) + " " + nama_prd1 + " " + "(" + kode_prd1 + ")"
                End If
                mlREADER.Close()
            Else
                produk1 = "-"
            End If

            If kode_prd2 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd2 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd2 = "-"
                    produk2 = "-"
                Else
                    nama_prd2 = mlREADER("nama")
                    produk2 = CStr(jumlah2) + " " + nama_prd2 + " " + "(" + kode_prd2 + ")"
                End If
                mlREADER.Close()
            Else
                produk2 = "-"
            End If

            If kode_prd3 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd3 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd3 = "-"
                    produk3 = "-"
                Else
                    nama_prd3 = mlREADER("nama")
                    produk3 = CStr(jumlah3) + " " + nama_prd3 + " " + "(" + kode_prd3 + ")"
                End If
                mlREADER.Close()
            Else
                produk3 = "-"
            End If

            If kode_prd4 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd4 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd4 = "-"
                    produk4 = "-"
                Else
                    nama_prd4 = mlREADER("nama")
                    produk4 = CStr(jumlah4) + " " + nama_prd4 + " " + "(" + kode_prd4 + ")"
                End If
                mlREADER.Close()
            Else
                produk4 = "-"
            End If

            If kode_prd5 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd5 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd5 = "-"
                    produk5 = "-"
                Else
                    nama_prd5 = mlREADER("nama")
                    produk5 = CStr(jumlah5) + " " + nama_prd5 + " " + "(" + kode_prd5 + ")"
                End If
                mlREADER.Close()
            Else
                produk5 = "-"
            End If

            If kode_prd6 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd6 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd6 = "-"
                    produk6 = "-"
                Else
                    nama_prd6 = mlREADER("nama")
                    produk6 = CStr(jumlah6) + " " + nama_prd6 + " " + "(" + kode_prd6 + ")"
                End If
                mlREADER.Close()
            Else
                produk6 = "-"
            End If

            If kode_prd7 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd7 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd7 = "-"
                    produk7 = "-"
                Else
                    nama_prd7 = mlREADER("nama")
                    produk7 = CStr(jumlah7) + " " + nama_prd7 + " " + "(" + kode_prd7 + ")"
                End If
                mlREADER.Close()
            Else
                produk7 = "-"
            End If

            If kode_prd8 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd8 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd8 = "-"
                    produk8 = "-"
                Else
                    nama_prd8 = mlREADER("nama")
                    produk8 = CStr(jumlah8) + " " + nama_prd8 + " " + "(" + kode_prd8 + ")"
                End If
                mlREADER.Close()
            Else
                produk8 = "-"
            End If

            If kode_prd9 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd9 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd9 = "-"
                    produk9 = "-"
                Else
                    nama_prd9 = mlREADER("nama")
                    produk9 = CStr(jumlah9) + " " + nama_prd9 + " " + "(" + kode_prd9 + ")"
                End If
                mlREADER.Close()
            Else
                produk9 = "-"
            End If

            If kode_prd10 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd10 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd10 = "-"
                    produk10 = "-"
                Else
                    nama_prd10 = mlREADER("nama")
                    produk10 = CStr(jumlah10) + " " + nama_prd10 + " " + "(" + kode_prd10 + ")"
                End If
                mlREADER.Close()
            Else
                produk10 = "-"
            End If

            If kode_prd11 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd11 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd11 = "-"
                    produk11 = "-"
                Else
                    nama_prd11 = mlREADER("nama")
                    produk11 = CStr(jumlah1) + " " + nama_prd11 + " " + "(" + kode_prd11 + ")"
                End If
                mlREADER.Close()
            Else
                produk11 = "-"
            End If

            If kode_prd12 <> "-" Then
                mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kode_prd12 & "' order by id"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                mlREADER.Read()
                If Not mlREADER.HasRows Then
                    nama_prd12 = "-"
                    produk12 = "-"
                Else
                    nama_prd12 = mlREADER("nama")
                    produk12 = CStr(jumlah1) + " " + nama_prd12 + " " + "(" + kode_prd12 + ")"
                End If
                mlREADER.Close()
            Else
                produk12 = "-"
            End If
        End If
    End Sub
End Class

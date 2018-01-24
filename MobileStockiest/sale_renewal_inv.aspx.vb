Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_renewal_inv
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable

    Protected dinoiki, tgl As Date
    Protected gale1, gale2, gale3 As Integer
    Protected dcpusate, pos_area, mypos, loguser, kelasdc, indukdc, indukmc, namatabel, namatabel2, noinvo, lanjut, dcpusat As String
    Protected nopos, namakon, kta, noslip, noseri, paket, nopajak, email, telp, noktp, nama, kop, direk, alok, pose, upme, pase, namapaket As String
    Protected harga, PV, bv, tunai, debit, cc, vouc, jumbayar, kembalian, alokbulan, aloktahun As Double

    Protected kode_prd1, kode_prd2, kode_prd3, kode_prd4, kode_prd5, kode_prd6, kode_prd7, kode_prd8, kode_prd9, kode_prd10, kode_prd11, kode_prd12 As String
    Protected jumlah1, jumlah2, jumlah3, jumlah4, jumlah5, jumlah6, jumlah7, jumlah8, jumlah9, jumlah10, jumlah11, jumlah12 As Double
    Protected nama_prd1, nama_prd2, nama_prd3, nama_prd4, nama_prd5, nama_prd6, nama_prd7, nama_prd8, nama_prd9, nama_prd10, nama_prd11, nama_prd12 As String
    Protected produk1, produk2, produk3, produk4, produk5, produk6, produk7, produk8, produk9, produk10, produk11, produk12 As String

    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        dinoiki = Now.Date
        gale1 = Day(dinoiki)
        gale2 = Month(dinoiki)
        gale3 = Year(dinoiki)

        If gale2 = 3 And gale3 >= 2011 Then
            If gale1 <= 4 Then
                Response.Redirect("home.aspx")
            End If
        End If

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        dcpusate = Session("dcpusate")

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

        If UCase(mypos) = dcpusat Then
            namatabel = "st_barang"
            namatabel2 = "st_kartustock"
        Else
            namatabel = "st_barang_ms"
            namatabel2 = "st_kartustock_ms"
        End If

        noinvo = Session("noinvo_ren")
        Session("errorpos") = ""
        Session("noinvo_ren") = ""
    End Sub

    Sub PrepareData()
        mlSQL = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjut = "F"
        Else
            lanjut = "T"
            nopos = mlREADER("nopos")
            namakon = mlREADER("nama")
            kta = mlREADER("kta")
            tgl = mlREADER("tgl")
            noslip = mlREADER("noslip")
            noseri = mlREADER("noseri")
            paket = mlREADER("paket")
            harga = mlREADER("harga")
            PV = mlREADER("pv")
            bv = mlREADER("bv")
            tunai = mlREADER("tunai")
            debit = mlREADER("debit")
            cc = mlREADER("cc")
            vouc = mlREADER("bg")
            jumbayar = mlREADER("jumbayar")
            kembalian = mlREADER("kembalian")
            noinvo = mlREADER("noslip")
            nopajak = mlREADER("nopajak")
            alokbulan = mlREADER("alokbulan")
            aloktahun = mlREADER("aloktahun")
        End If
        mlREADER.Close()

        mlSQL = "SELECT emel,kta,telp,ktp,uid,direk,alok,pose,tipene_kartu,upme,thekey FROM member where kta like '" & noseri & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            Response.Redirect("mistake.aspx?message=Session Login anda sudah expired, silahkan melakukan login kembali")
        Else
            email = mlREADER("emel")
            'namakon = rsALL("uid")
            telp = mlREADER("telp")
            noktp = mlREADER("ktp")
            nama = mlREADER("uid")
            kop = mlREADER("tipene_kartu")
            direk = mlREADER("direk")
            alok = mlREADER("alok")
            pose = mlREADER("pose")
            upme = mlREADER("upme")
            pase = mlREADER("thekey")
        End If
        mlREADER.Close()

        'rsALL.Open "SELECT * FROM st_sale_daftar where nopos like '"&mypos&"' and noslip like '"&noinvo&"' order by id",connALL,1,3
        '	if rsALL.bof then
        '	else
        '		rsALL.update
        '			rsALL("nama") = namakon
        '		rsALL.update		
        '	end if					
        'rsALL.close

        If lanjut = "T" Then
            mlSQL = "SELECT nama FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by id"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                namapaket = mlREADER("nama")
            End If
            mlREADER.Close()

            If UCase(paket) = "REN" Then
                namapaket = "Paket Renewal"
            Else
                If UCase(paket) = "PPL" Then
                    namapaket = "Paket Upgrade Platinum"
                Else
                    If UCase(paket) = "PPR" Then
                        namapaket = "Paket Upgrade Premium"
                    End If
                End If
            End If

            mlSQL = "SELECT * FROM st_sale_daftar_prd where noslip like '" & noinvo & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                kode_prd1 = "-"
            Else
                kode_prd1 = mlREADER("kode1")
                jumlah1 = mlREADER("jumlah1")
                kode_prd2 = mlREADER("kode2")
                jumlah2 = mlREADER("jumlah2")
                kode_prd3 = mlREADER("kode3")
                jumlah3 = mlREADER("jumlah3")
                kode_prd4 = mlREADER("kode4")
                jumlah4 = mlREADER("jumlah4")
                kode_prd5 = mlREADER("kode5")
                jumlah5 = mlREADER("jumlah5")
                kode_prd6 = mlREADER("kode6")
                jumlah6 = mlREADER("jumlah6")
                kode_prd7 = mlREADER("kode7")
                jumlah7 = mlREADER("jumlah7")
                kode_prd8 = mlREADER("kode8")
                jumlah8 = mlREADER("jumlah8")
                kode_prd9 = mlREADER("kode9")
                jumlah9 = mlREADER("jumlah9")
                kode_prd10 = mlREADER("kode10")
                jumlah10 = mlREADER("jumlah10")
                kode_prd11 = mlREADER("kode11")
                jumlah11 = mlREADER("jumlah11")
                kode_prd12 = mlREADER("kode12")
                jumlah12 = mlREADER("jumlah12")
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

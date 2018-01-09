Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_stater_save_ms4
    Inherits System.Web.UI.Page

    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable

    Dim mlFUNCT As FunctionHWI

    Dim menu_id, mypos, loguser, pos_area, kelasdc, indukdc, namatabel, namatabel2, dcpusat, jeneng, noser, l1, l1a, l2, l3, l4, l5, lanjutdodol, lanjutposting As String
    Dim hariakhir, dino, dinoe, skr As Date
    Dim paket, harga, pv, bv, tunai, debit, kkredit, bgcek, duite, ket, sisa, sisastok, jumstok, sisaku, sisastk As Double
    Dim kodeberi1, kodeberi2, kodeberi3, kodeberi4, kodeberi5, kodeberi6, kodeberi7, kodeberi8, kodeberi9, kodeberi10, kodeberi11, kodeberi12 As String
    Dim jumberi1, jumberi2, jumberi3, jumberi4, jumberi5, jumberi6, jumberi7, jumberi8, jumberi9, jumberi10, jumberi11, jumberi12 As Double

    Dim wulan, wulpos, nahun, nuhun As Integer

    Dim direk, upline, bcupline, kakiupline, error1, error2, error3, namadirek, notelpdirek, namaupline, notelpupline, aloc, namaalo, notelpalo, psa, uprane, terusane, kedua, nocross, aloce, pose As String
    Dim subalo, muter, aax, bulanskr, tahunskr, bulsks As Integer
    Dim sopokui, error4, tamb, blne, taun, nipe, noinvo As String
    Dim noakhir, jk, cekbg, jumbc As Double



    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")


        mypos = Session("motok")
        loguser = Session("kowe")
        pos_area = Session("pos_area")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        If Session("motok") = "" Or Session("kowe") = "" Then

            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session("pos_area") = pos_area
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        If UCase(mypos) = dcpusat Then
            namatabel = "st_barang"
            namatabel2 = "st_kartustock"
        Else
            namatabel = "st_barang_ms"
            namatabel2 = "st_kartustock_ms"
        End If

        PrepareData()
        CekStokPaketPendaftaran()
        CekStokProdukPendukung()
        SaveTransaksi()
    End Sub

    Sub PrepareData()
        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        jeneng = mlFUNCT.SafeSQL(UCase(Trim(Request("nama"))))
        noser = mlFUNCT.SafeSQL(Trim(Request("noseri")))
        paket = Trim(Request("paket"))
        harga = Trim(Request("harga"))
        PV = Request("pv")
        bv = Request("bv")
        tunai = Request("jumbayarcash")
        debit = Request("jumbayardb")
        kkredit = Request("jumbayarcc")
        bgcek = Request("jumbayarcek")
        duite = Request("jumbayar")
        ket = mlFUNCT.SafeSQL(Request("keterangan"))

        If ket = "" Then
            ket = "-"
        Else
            ket = ket
        End If

        If dinoe = "" Then

            l1a = "Mbuh"
            Session("errorpos") = "Tanggal transaksi tidak valid"
            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
        Else
            If Len(dinoe) >= 11 Then

                Session("errorpos") = "Tanggal transaksi tidak valid, maksimal 10 karakter"
                l1a = "Mbuh"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                If ((Len(dinoe) <= 11) And (dinoe <> "")) Then
                    l1a = "Ter1a"
                    Session("errorpos") = ""
                End If
            End If
        End If

        If jeneng = "" Then

            l1 = "Mbuh"
            Session("errorpos") = "Nama calon distributor belum diisi"
            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
        Else
            If Len(jeneng) >= 51 Then

                Session("errorpos") = "Nama calon distributor maksimal 50 karakter"
                l1 = "Mbuh"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                If ((Len(jeneng) <= 51) And (jeneng <> "")) Then
                    l1 = "Ter1"
                    Session("errorpos") = ""
                End If
            End If
        End If

        If noser = "" Then
            l2 = "Mbuh"

            Session("errorpos") = "Nomor seri formulir pendaftaran belum diisi"
            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
        Else
            '	If Len(noser)>=18 Then 
            '		set rsALL=nothing
            '		ConnALL.Close
            '		set connALL=nothing
            '		
            '		set rs=nothing
            '		Conn.Close
            '		set conn=nothing	
            '		session("errorpos") = "Nomor seri formulir pendaftaran 7 karakter"
            '		l2 = "Mbuh"
            '		response.redirect "sale_stater_ms4.asp?menu_id="&menu_id
            '	else
            '	If ((Len(noser)<=17) and (noser<>"")) Then 
            'if isnumeric(noser) = true then
            '	rsALL.Open "SELECT id FROM member where asli = '"&noser&"'",connALL
            '		if rsALL.bof then
            '			l2 = "Ter2"	
            '			session("errorpos") = ""
            '		else		
            '			rsALL.close
            '			set rsALL=nothing
            '			ConnALL.Close
            '			set connALL=nothing
            '			session("errorpos") = "Nomor seri pendaftaran : "&noser &" sudah terdaftar didalam database temporary, silahkan jalankan menu pembatalan temporary atau hubungi kantor pusat"
            '			response.redirect "sale_stater_ms4.asp?menu_id="&menu_id			
            '		end if						
            '	rsALL.close		

            '	rsALL.Open "SELECT id FROM st_sale_daftar where noseri like '"&noser&"'",connALL ' jika ada, maka dia sudah selesai beli tapi belum didaftarkan
            '		if rsALL.bof then
            l2 = "Ter2"
            Session("errorpos") = ""
            '		else		
            '			rsALL.close
            '			set rsALL=nothing
            '			ConnALL.Close
            '			set connALL=nothing
            '			session("errorpos") = "Nomor seri pendaftaran : "&noser &" sudah terdaftar didalam database temporary, silahkan jalankan menu pembatalan temporary atau hubungi kantor pusat"
            '			response.redirect "sale_stater_ms4.asp?menu_id="&menu_id			
            '		end if						
            '	rsALL.close		
            'else
            '	session("errorpos") = "Nomor seri formulir pendaftaran belum diisi"
            '	response.redirect "sale_stater_ms4.asp?menu_id="&menu_id		
            'end if			
            '	end if	
            '	End If 
        End If

        If paket = "" Then

            l3 = "Mbuh"
            Session("errorpos") = "Anda belum memilih paket pendaftaran"
            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
        Else
            If Len(paket) >= 16 Then

                Session("errorpos") = "Anda belum memilih paket pendaftaran"
                l3 = "Mbuh"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                If ((Len(paket) <= 16) And (paket <> "")) Then
                    mlSQL = "SELECT id,jumbc FROM " & namatabel & " where kode like '" & paket & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorpos") = "Tipe Paket Pendaftaran tidak dikenal"
                        Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
                    Else
                        l3 = "Ter3"
                        Session("errorpos") = ""
                        jumbc = mlREADER("jumbc")
                    End If
                    mlREADER.Close()
                End If
            End If
        End If

        If harga = "" Then
            l4 = "Mbuh"
            Session("errorpos") = "Anda belum memilih paket pendaftaran"
            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(harga) = False Then

                l4 = "Mbuh"
                Session("errorpos") = "Anda belum memilih paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                If ((harga <> "") And (IsNumeric(harga) = False)) Then
                    If harga > 0 Then
                        l4 = "Ter4"
                        Session("errorpos") = ""
                    Else

                        l4 = "Mbuh"
                        Session("errorpos") = "Anda belum memilih paket pendaftaran"
                        Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(duite) = False Then

                l5 = "Mbuh"
                Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
                        End If
                    Else

                        l5 = "Mbuh"
                        Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                        Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
        If UCase(mypos) <> dcpusat Then ' bila DC kantor pusat tidak ada paket pendaftaran
            mlSQL = "SELECT jumlah FROM " & namatabel & " where kode like '" & paket & "' and nopos like '" & mypos & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                lanjutdodol = "F"
                Session("errorpos") = "Paket Pendaftaran Tidak Terdaftar"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                jumstok = mlREADER("jumlah")
                sisastok = jumstok - 1
                If sisastok = 0 Or sisastok >= 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Sisa stock tidak mencukupi untuk dilakukan transaksi ini"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
                End If
            End If
            mlREADER.Close()
        Else
            lanjutdodol = "T"
            jumstok = 1
        End If

    End Sub

    Sub CekStokProdukPendukung()
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' cek stok ketersediaan produk pendukung paket pendaftaran
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        mlSQL = "SELECT * FROM st_tipe_paket where kode like '" & paket & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            lanjutdodol = "F"
            Session("errorpos") = "Paket pendaftaran tidak valid !"
            Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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

        If kodeberi1 <> "" And kodeberi1 <> "-" And IsDBNull(kodeberi1) = False Then
            sisaku = 0
            mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi1 & "' order by kode DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                lanjutdodol = "F"
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi1 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi1
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If

                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"

                    Session("errorpos") = "Stock kode produk " & kodeberi1 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi2 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi2
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi2 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi3 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi3
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"

                    Session("errorpos") = "Stock kode produk " & kodeberi3 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi4 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi4
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"

                    Session("errorpos") = "Stock kode produk " & kodeberi4 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi5 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi5
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi5 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi6 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi6
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"

                    Session("errorpos") = "Stock kode produk " & kodeberi6 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi7 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi7
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi7 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi8 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi8
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi8 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi9 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi9
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi9 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
                End If
            End If
            mlREADER.Close()
        End If

        If kodeberi10 <> "" And kodeberi10 <> "-" And IsDBNull(kodeberi10) = False Then
            sisaku = 0
            mlSQL = "SELECT TOP 1 * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & kodeberi10 & "' order by kode DESC"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                lanjutdodol = "F"
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi10 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi10
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi10 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi11 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi11
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi11 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
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
                Session("errorpos") = "Tidak ditemukan kode produk " & kodeberi12 & " yang menyertai produk paket pendaftaran"
                Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
            Else
                sisaku = mlREADER("jumlah")
                sisastk = sisaku - jumberi12
                If UCase(mypos) = dcpusat Then
                    If sisastk <= 0 Then
                        sisastk = 0
                    Else
                        sisastk = sisastk
                    End If
                Else
                    sisastk = sisastk
                End If
                If sisastk > 0 Or sisastk = 0 Then
                    lanjutdodol = "T"
                Else
                    lanjutdodol = "F"
                    Session("errorpos") = "Stock kode produk " & kodeberi12 & " yang menyertai produk paket pendaftaran tidak mencukupi"
                    Response.Redirect("sale_stater_ms4.aspx?menu_id=" & menu_id)
                End If
            End If
            mlREADER.Close()
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
        wulan = wulpos
        nahun = nuhun
        'if tutup1 < skr and tutup2 > skr then
        '	lanjutposting = "F"
        'else
        lanjutposting = "T"
        'end if

        Dim str_valid As String = ""
        If lanjutposting = "F" Then
            str_Valid += "<section Class='content'>" & vbCrLf
            str_Valid += "<div Class='box'>" & vbCrLf
            str_Valid += "<div Class='box-header with-border'>" & vbCrLf
            str_Valid += "<h3 Class='box-title'></h3>" & vbCrLf
            str_Valid += "<div Class='box-tools pull-right'>" & vbCrLf
            str_Valid += "<Button type = 'button' Class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
            str_Valid += "<i Class='fa fa-minus'></i></button>" & vbCrLf
            str_Valid += "<Button type = 'button' Class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
            str_Valid += "<i Class='fa fa-times'></i></button>" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "<div Class='box-body'>" & vbCrLf
            str_Valid += "<p align = 'center' >" & vbCrLf
            str_Valid += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
            str_Valid += "<br/>" & vbCrLf
            str_Valid += "<br/>" & vbCrLf
            str_Valid += "<p align='center'>" & vbCrLf
            str_Valid += "Maaf saat ini transaksi anda tidak dapat dilakukan karena sudah memasuki <font color='#FF0000'><b>closing period</b></font><br/>" & vbCrLf
            str_Valid += "Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup point bulanan<br/>" & vbCrLf
            str_Valid += "maka silahkan hubungi kantor pusat sesegera mungkin.<br/>" & vbCrLf
            str_Valid += "Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian anda.<br/>" & vbCrLf
            str_Valid += "&lt;-- <a href='sale_reentry.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a> --&gt;" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "</div>" & vbCrLf
            str_Valid += "</section>" & vbCrLf

            Div_Valid.InnerHtml = str_valid
        End If
    End Sub

    Sub SaveTransaksi()
        If lanjutposting = "T" And lanjutdodol = "T" Then
            ''''''''''''''''''''''''''''''''''''''''''''''''''
            ' cek direct sponsor & upline sponsor
            ' simpan transaksi
            ' potong stock
            ' update kartu stock

            direk = mlFUNCT.SafeSQL(Trim(Request("direk")))
            upline = mlFUNCT.SafeSQL(Trim(Request("upline")))
            bcupline = Request("bcupline")
            kakiupline = Request("kakiupline")

            If direk = "" Then
                l1 = "Mbuh"
                error1 = "Mohon isikan nomor id distributor sponsor"
            Else
                If Len(direk) >= 21 Then
                    error1 = "Nomor id distributor sponsor maksimal 20 karakter"
                    l1 = "Mbuh"
                Else
                    If ((Len(direk) <= 21) And (direk <> "")) Then
                        mlSQL = "SELECT kta,uid,telp FROM member WHERE kta LIKE '" & direk & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            error1 = "Nomor id distributor sponsor tidak ditemukan"
                            l1 = "Mbuh"
                            namadirek = ""
                            notelpdirek = ""
                        Else
                            l1 = "Ter1"
                            error1 = ""
                            namadirek = rs("uid")
                            notelpdirek = rs("telp")
                        End If
                        mlREADER.Close()
                    End If
                End If
            End If

            'if noser = direk then
            '	error1 = "Anda tidak dapat mensponsori diri sendiri"
            '	l1 = "Mbuh"
            'else
            '	error1 = error1
            '	l1 = l1	
            'end if

            If kakiupline = "" Then
                l3 = "Mbuh"
                error3 = "Mohon isikan penempatan pada kaki distributor upline"
            Else
                If Len(kakiupline) >= 2 Then
                    error3 = "Mohon isikan penempatan pada kaki distributor upline " & kakiupline
                    l3 = "Mbuh"
                Else
                    If ((Len(kakiupline) <= 2) And (kakiupline <> "")) Then
                        l3 = "Ter3"
                        error3 = ""
                    End If
                End If
            End If

            If upline = "" Then
                l2 = "Mbuh"
                error2 = "Mohon isikan nomor id distributor upline penempatan"
            Else
                If Len(upline) >= 21 Then
                    error2 = "Nomor id distributor upline penempatan maksimal 20 karakter"
                    l2 = "Mbuh"
                Else
                    If ((Len(upline) <= 21) And (upline <> "")) Then
                        mlSQL = "SELECT kta,uid,telp,upme FROM member WHERE kta LIKE '" & upline & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            error2 = "Nomor id distributor upline penempatan tidak ditemukan"
                            l2 = "Mbuh"
                            namaupline = ""
                            notelpupline = ""
                            aloc = ""
                            namaalo = ""
                            notelpalo = ""
                            subalo = ""
                            psa = ""
                            uprane = "F"
                        Else
                            l2 = "Ter2"
                            error2 = ""
                            namaupline = mlREADER("uid")
                            notelpupline = mlREADER("telp")
                            aloc = mlREADER("kta")
                            namaalo = mlREADER("uid")
                            notelpalo = mlREADER("telp")
                            'subalo = bcupline
                            subalo = "1"
                            psa = kakiupline
                            'uprane = rs("upme")		
                            uprane = "F" ' semua dianggap 1 BC, 3 BC ditiadakan			
                        End If
                        mlREADER.Close()
                    End If
                End If
            End If

            '''''''''''''''''''''''''''''''''''''''''''
            ' CEK KETERSEDIAAN BC
            '''''''''''''''''''''''''''''''''''''''''''
            If uprane = "F" Then
                If subalo = "2" Then
                    If psa = "L" Then
                        l2 = "Mbuh"
                        error2 = "Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-2 kaki KIRI upline yang tidak memiliki 3 BC"
                    Else
                        If psa = "R" Then
                            l2 = "Mbuh"
                            error2 = "Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-2 kaki KANAN upline yang tidak memiliki 3 BC"
                        End If
                    End If
                Else
                    If subalo = "3" Then
                        If psa = "L" Then
                            l2 = "Mbuh"
                            error2 = "Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-3 kaki KIRI upline yang tidak memiliki 3 BC"
                        Else
                            If psa = "R" Then
                                l2 = "Mbuh"
                                error2 = "Keanggotaan upline penempatan tidak memilik 3 BC, anda tidak dapat dialokasikan pada BC-3 kaki KANAN upline yang tidak memiliki 3 BC"
                            End If
                        End If
                    Else
                        If subalo = "1" Then
                            error2 = ""
                            l2 = "Ter2"
                        End If
                    End If
                End If
            Else
                If uprane = "T" Then
                    error2 = ""
                    l2 = "Ter2"
                Else
                    error2 = "Kesalahan penempatan"
                    l2 = "Mbuh"
                End If
            End If


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
                mlREADER.Close()
            End If

            If terusane <> "LulusUj1Klinis" Then
                l3 = "Mbuh"
                error3 = "Maaf, sponsor dan upline penempatan tidak berada dalam satu jaringan - (CROSSLINE TIDAK DIIJINKAN)"
            Else
                l3 = "Ter3"
                error3 = ""
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
                l4 = "Mbuh"
                error4 = "Maaf, penempatan yang dituju sudah terisi oleh distributor lain, yaitu nomor id :" & sopokui
            Else
                l4 = "Ter4"
                error4 = ""
            End If

            If l1 = "Ter1" And l2 = "Ter2" And l3 = "Ter3" And l4 = "Ter4" Then
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

                noinvo = mypos + "/" + tamb + nipe + "/AKT-" + blne + "/" + taun

                ' SIMPAN DATA TRANSAKSI

                mlSQL = "insert into st_sale_daftar(nopos,urut,kta,nama,tgl,noslip,noseri,noseri,paket,harga,pv,bv,tunai,debit,cc,bg,jumbayar,kembalian,jumbc,suratjalan,direk,idplc,subalo,kaki,pakai,keterangan,alokbulan,aloktahun,dcinduk)" & vbCrLf
                mlSQL += "values('" & mypos & "','" & noakhir & "','" & loguser & "','" & jeneng & "','" & dino & "','" & noinvo & "','" & noser & "','-','" & paket & "','" & harga & "','" & pv & "','" & bv & "','" & tunai & "'" & vbCrLf
                mlSQL += ",'" & debit & "','" & kkredit & "','" & cekbg & "','" & duite & "'," & duite - harga & ",'" & jumbc & "','-','" & direk & "','" & aloc & "','" & subalo & "',,'" & psa & "','F','" & ket & "'" & vbCrLf
                mlSQL += ",'" & wulan & "','" & nahun & "','" & indukdc & "')"
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                Session("noinvo_akt") = noinvo
                'response.redirect "sale_stater_inv.asp?menu_id="&menu_id
                Response.Redirect("akt_form_ms4.aspx?menu_id=" & menu_id)
            Else
                Dim strResponsive2 As String = ""

                strResponsive2 += " <section Class='content'>" & vbCrLf
                strResponsive2 += "<div Class='box'>" & vbCrLf
                strResponsive2 += "<div Class='box-header with-border'>" & vbCrLf
                strResponsive2 += "<h3 Class='box-title'></h3>" & vbCrLf
                strResponsive2 += "<div Class='box-tools pull-right'>" & vbCrLf
                strResponsive2 += "<Button type='button' Class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
                strResponsive2 += "<i Class='fa fa-minus'></i></button>" & vbCrLf
                strResponsive2 += "<Button type='button' Class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
                strResponsive2 += "<i Class='fa fa-times'></i></button>" & vbCrLf
                strResponsive2 += "</div>" & vbCrLf
                strResponsive2 += "</div>" & vbCrLf
                strResponsive2 += "<div Class='box-body'>" & vbCrLf
                strResponsive2 += "<p align='center'>" & vbCrLf
                strResponsive2 += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
                strResponsive2 += "<br/>" & vbCrLf
                strResponsive2 += "<br/>" & vbCrLf

                strResponsive2 += "<p align='center'>" & vbCrLf
                strResponsive2 += "ada kesalahan dalam proses pendaftaran, silahkan perbaiki kesalahan seperti yang tertulis dibawah ini.<br/>" & vbCrLf
                If error1 <> "" Then
                    strResponsive2 += "" & error1 & " " & vbCrLf
                End If
                If error2 <> "" Then
                    strResponsive2 += "" & error2 & "" & vbCrLf
                End If
                If error3 <> "" Then
                    strResponsive2 += "" & error3 & " " & vbCrLf
                End If
                If error4 <> "" Then
                    strResponsive2 += "" & error4 & " " & vbCrLf
                End If
                strResponsive2 += " < br /> " & vbCrLf
                strResponsive2 += " & lt;-- <a href='sale_reentry.aspx?menu_id=" & Session("menu_id") & "'>Kembali</a> --&gt;</font>" & vbCrLf
                strResponsive2 += "</div>" & vbCrLf
                strResponsive2 += "  </div>" & vbCrLf
                strResponsive2 += "</section>" & vbCrLf

                Div_SaveTransaksi.InnerHtml = strResponsive2
            End If
        End If
    End Sub
End Class

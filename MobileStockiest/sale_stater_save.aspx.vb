Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_stater_save
    Inherits System.Web.UI.Page

    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable
    Dim mlFUNCT As FunctionHWI

    Dim menu_id As Integer
    Dim hariakhir, dino, dinoe As Date
    Dim mypos, loguser, pos_area, kelasdc, indukdc, indukmc, namatabel, namatabel2, jeneng, noser, paket, ket As String
    Dim harga, PV, bv, tunai, debit, kkredit, bgcek, duite As Double


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
        indukmc = Session.Contents("indukmc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session("pos_area") = pos_area
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session.Contents("indukmc") = indukmc
        End If

        namatabel = "st_barang_ms"
        namatabel2 = "st_kartustock_ms"

        dino = Now()
        dinoe = Date.Now
        hariakhir = dino
        jeneng = mlFUNCT.SafeSQL(UCase(Trim(Request("nama"))))
        noser = mlFUNCT.SafeSQL(Trim(Request("noseri")))
        paket = Trim(Request("paket"))
        harga = Request("harga")
        PV = Request("pv")
        bv = Request("bv")
        tunai = Request("jumbayarcash")
        debit = Request("jumbayardb")
        kkredit = Request("jumbayarcc")
        bgcek = Request("jumbayarcek")
        duite = Request("jumbayar")
        ket = Request("keterangan")

        QueryAwal()
    End Sub

    Sub QueryAwal()
        Dim l1a, l1, l2 As String

        If ket = "" Then
            ket = "-"
        Else
            ket = ket
        End If

        If dinoe = "" Then
            l1a = "Mbuh"
            Session("errorpos") = "Tanggal transaksi tidak valid"
            Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
        Else
            If Len(dinoe) >= 11 Then
                Session("errorpos") = "Tanggal transaksi tidak valid, maksimal 10 karakter"
                l1a = "Mbuh"
                Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
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
            Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
        Else
            If Len(jeneng) >= 51 Then
                Session("errorpos") = "Nama calon distributor maksimal 50 karakter"
                l1 = "Mbuh"
                Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
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
            Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
        Else
            l2 = "Ter2"
            Session("errorpos") = ""
        End If


        Dim l3, jumbc, l4, l5 As String
        If paket = "" Then

            l3 = "Mbuh"
            Session("errorpos") = "Anda belum memilih paket pendaftaran"
            Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
        Else
            If Len(paket) >= 16 Then
                Session("errorpos") = "Anda belum memilih paket pendaftaran"
                l3 = "Mbuh"
                Response.Redirect("sale_stater.asp?menu_id=" & menu_id)
            Else
                If ((Len(paket) <= 16) And (paket <> "")) Then
                    mlSQL = "SELECT id,jumbc FROM " & namatabel & " where kode like '" & paket & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        'mlREADER.Close()
                        Session("errorpos") = "Tipe Paket Pendaftaran tidak dikenal"
                        Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
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
            Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(harga) = False Then
                l4 = "Mbuh"
                Session("errorpos") = "Anda belum memilih paket pendaftaran"
                Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
            Else
                If ((harga <> "") And (IsNumeric(harga) = False)) Then
                    If harga > 0 Then
                        l4 = "Ter4"
                        Session("errorpos") = ""
                    Else
                        l4 = "Mbuh"
                        Session("errorpos") = "Anda belum memilih paket pendaftaran"
                        Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
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


        Dim sisa, sisastok As Double
        Dim lanjutdodol, lanjutposting As String
        If duite = "" Then
            l5 = "Mbuh"
            Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
            Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
        Else
            If IsNumeric(duite) = False Then
                l5 = "Mbuh"
                Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
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
                            Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
                        End If
                    Else
                        l5 = "Mbuh"
                        Session("errorpos") = "Anda belum mengisikan jumlah pembayaran"
                        Response.Redirect("sale_stater.aspx?menu_id=" & menu_id)
                    End If
                End If
            End If
        End If

        lanjutdodol = "F"
        lanjutposting = "F"
        sisastok = 0
    End Sub
End Class

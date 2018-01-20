Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_kartustock_cetak
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDT As DataTable
    Protected mlQuery As String
    Protected mlDR As OleDb.OleDbDataReader

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String

    Protected sort, pos_area, mypos, loguser, paket, kelasdc, indukdc, indukmc, namatabel, namatabel2, dcpusat As String
    Protected x, bg, pg, tothal, z, totrec, halskr, tujuan, sisa, lumpat, kemana As Integer
    Protected pgview, pgas, nama, foto, info, lanjut As String
    Protected PV, bv, masuk, awal, keluar, akhir As Double

    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, ket As String
    Protected tgl As Date

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)
        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

        sort = Request("sort")
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        paket = Request("id")
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

        namatabel = "st_kartustock_ms"
        namatabel2 = "st_barang_ms"

        PrepareHalaman()
    End Sub

    Sub PrepareHalaman()
        If paket <> "" And paket <> "--Silahkan Pilih--" Then
            mlSQL = "SELECT count(id) as vid FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                x = 0
            Else
                x = CInt(mlREADER("vid"))
            End If
            mlREADER.Close()

            pgview = Request("pgview")
            bg = 50

            pg = 0
            pgas = Request("page")
            sort = Request("sort")
            If pgas = "" Then
                pg = 0
            Else
                If pgas <> "" Then
                    pg = pgas - 1
                End If
            End If

            If x Mod bg = 0 Then
                tothal = x / bg
            Else
                z = x + (bg - (x Mod bg))
                tothal = z / bg
            End If

            totrec = x
            halskr = pg
            tujuan = pg * bg
            sisa = totrec - tujuan
            If sisa < Int(bg) Then
                lumpat = bg + sisa
            Else
                lumpat = bg
            End If

            If tujuan > totrec Then
                kemana = 0
            Else
                kemana = pg * bg
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' AMBIL DATA INFORMASI PRODUK PADA DATABASE KANTOR PUSAT
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            mlSQL = "SELECT nama,pv,bv,foto,keterangan,adv_page FROM st_barang where nopos like '" & dcpusat & "' and kode like '" & paket & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                nama = ""
                PV = 0
                bv = 0
                foto = "../images/blank.gif"
                info = ""
            Else
                nama = mlREADER("nama")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
                foto = mlREADER("foto")
                info = mlREADER("keterangan")
            End If
            mlREADER.Close()

            lanjut = "T"
        End If
    End Sub
End Class

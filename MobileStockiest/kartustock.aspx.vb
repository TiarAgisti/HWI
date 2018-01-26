Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_kartustock
    Inherits System.Web.UI.Page
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String


    Protected mlQuery As String
    Protected mlDR As OleDb.OleDbDataReader
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDT As DataTable
    Protected mlOBJGS As New IASClass.ucmGeneralSystem

    Protected sort, pos_area, mypos, loguser, paket, kelasdc, indukmc, indukdc, namatabel, namatabel2, pgas, nama, foto, info, lanjut, ket, dcpusat As String
    Protected x, pg, bg, z, tothal, totrec, halskr, tujuan, sisa, lumpat, kemana, pgcunt, pgct, aax, kl As Integer
    Protected bv, pv, minimal, masuk, awal, keluar, akhir As Double
    Protected tgl1, tgl2, tgl As Date

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
        'paket = request("paket")
        paket = Request("id")
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

        namatabel = "st_kartustock_ms"
        namatabel2 = "st_barang_ms"

        PrepareData()
    End Sub

    Function roundup(x As Integer) As Integer
        If x > Int(x) Then
            roundup = Int(x) + 1
        Else
            roundup = x
        End If
        Return roundup
    End Function

    Sub PrepareData()
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

            pg = 0
            bg = 25
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
            If sisa < bg Then
                lumpat = bg + sisa
            Else
                lumpat = bg
            End If

            If tujuan > totrec Then
                kemana = 0
            Else
                kemana = pg * bg
            End If



            pgcunt = x / bg

            If pgcunt < 1 Then
                pgct = 1
            Else
                pgct = roundup(pgcunt)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' AMBIL DATA INFORMASI PRODUK PADA DATABASE KANTOR PUSAT
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            mlSQL = "SELECT nama,pv,bv,foto,keterangan,adv_page FROM st_barang where nopos like '" & dcpusat & "' and kode like '" & paket & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                nama = ""
                pv = 0
                bv = 0
                foto = "../../pos/images/blank.gif"
                info = ""
            Else
                nama = mlREADER("nama")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                foto = mlREADER("foto")
                info = mlREADER("keterangan")
            End If
            mlREADER.Close()

            lanjut = "T"
        End If
    End Sub
End Class

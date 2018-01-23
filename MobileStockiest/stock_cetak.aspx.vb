Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_stock_cetak
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDT, mlDT2 As DataTable
    Protected mlQuery, mlQuery2, mlQuery3 As String
    Protected mlDR, mlDR2, mlDR3 As OleDb.OleDbDataReader

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String

    Protected sort, pos_area, mypos, loguser, namatabel, pgview, bg, pgas, kode, bgcolor, gg, ggg, ggg1, ggg2, ggg3, kode1 As String
    Protected diskon, kelasdc, kurs, totpv, PV, bv, jumlah, jumlahalokakt, jumlah1, jumakt, jumpaket, jumbutuhakt, jumreal, kebrapa, hd, hk, hppku, hpp, pot, disk_mc As Double
    Protected x, pg, totrec, tothal, halskr, tujuan, sisa, lumpat, kemana, z As Integer
    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc As String
    Protected kd1, kd2, kd3, kd4, kd5, kd6, kd7, kd8 As String
    Protected jm1, jm2, jm3, jm4, jm5, jm6, jm7, jm8 As Double
    Protected kusus1, kusus2, kusus3, kusus4, kusus5 As Double

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
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        PrepareData()
    End Sub

    Sub PrepareData()
        mlSQL = "SELECT nopos,area,diskon,kelas FROM tabdesc_stockist WHERE nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            pos_area = 1
            diskon = 9
            kelasdc = "D"
        Else
            Session("pos_area") = mlREADER("area")
            pos_area = mlREADER("area")
            diskon = mlREADER("diskon")
            kelasdc = mlREADER("kelas")
        End If
        mlREADER.Close()


        mlSQL = "SELECT kursbonus FROM bns_kurs"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            kurs = 0
        Else
            kurs = mlREADER("kursbonus")
        End If
        mlREADER.Close()

        namatabel = "st_barang_ms"
        mlSQL = "SELECT count(id) as vid FROM " & namatabel & " where nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            x = 0
        Else
            x = CInt(mlREADER("count(id)"))
        End If
        mlREADER.Close()

        pgview = Request("pgview")
        bg = Request("pgview")

        pg = 0
        pgas = Request("page")
        sort = Request("sort")
        If pgas = "" Then
            pg = 0
        Else
            If pgas <> "" Then
                pg = CInt(pgas) - 1
            End If
        End If

        If x Mod CInt(bg) = 0 Then
            tothal = x / CInt(bg)
        Else
            z = x + (CInt(bg) - (x Mod CInt(bg)))
            tothal = z / CInt(bg)
        End If

        totrec = x
        halskr = pg
        tujuan = pg * CInt(bg)
        sisa = totrec - tujuan
        If sisa < Int(bg) Then
            lumpat = CInt(bg) + sisa
        Else
            lumpat = CInt(bg)
        End If

        If tujuan > totrec Then
            kemana = 0
        Else
            kemana = pg * CInt(bg)
        End If
    End Sub
End Class

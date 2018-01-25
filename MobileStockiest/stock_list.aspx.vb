Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_stock_list
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDR, mlDR2, mlDR3 As OleDb.OleDbDataReader
    Protected mlQuery, mlQuery2, mlQuery3 As String
    Protected mlDT, mlDT2 As DataTable

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String

    Protected sort, pos_area, mypos, loguser, kelasdc, indukdc, indukmc, namatabel, pgview, pgas As String
    Protected diskon, disk_mc, kurs, lumpat, pg, kemana, bg, x, z, tothal, halskr, totrec, tujuan, sisa, sisanya, pgcunt, pgct1, pgct, aax, kl, totpv As Double
    Protected PV, bv, jumlah, jumlahalokakt, jumlah1, jumakt, jumpaket, jumbutuhakt, jumreal, kebrapa, hd, hk, kusus1, hppku, hpp, pot As Double
    Protected kode, gg, bgcolor, ggg, ggg1, ggg2, kode1 As String
    Protected kd1, kd2, kd3, kd4, kd5, kd6, kd7, kd8, kd9, kd10, kd11, kd12 As String
    Protected jm1, jm2, jm3, jm4, jm5, jm6, jm7, jm8, jm9, jm10, jm11, jm12 As Double
    Protected kusus2, kusus3, kusus4, kusus5 As Double

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

        PrepareData()
    End Sub

    Sub PrepareData()
        mlSQL = "SELECT nopos,area,diskon,kelas FROM tabdesc_stockist WHERE nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            pos_area = 1
            diskon = disk_mc
            kelasdc = "M"
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
            x = CInt(mlREADER("vid"))
        End If
        mlREADER.Close()

        lumpat = 0
        pg = 0
        pgview = Request("pgview")
        If pgview = "" Then
            bg = 150
        Else
            bg = CDbl(pgview)
        End If

        pgas = Request("page")
        If pgas = "" Then
            pg = 0
        Else
            If pgas <> "" Then
                pg = CDbl(pgas) - 1
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

        pgcunt = x / bg
        sisanya = x Mod bg
        If pgcunt < 1 Then
            pgct1 = 1
        Else
            pgct1 = Math.Round(pgcunt, 0)
        End If

        If sisanya = 1 Then
            pgct = pgct1 + sisanya
        Else
            pgct = pgct1
        End If
    End Sub
End Class

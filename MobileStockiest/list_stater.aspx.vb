Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_list_stater
    Inherits System.Web.UI.Page
    Public mlOBJGS As New IASClass.ucmGeneralSystem
    Public mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlDATATABLE As DataTable
    Dim mlFUNCT As FunctionHWI

    Public mlCOMPANYID As String = "ALL"
    Public mpMODULEID As String = "PB"
    Public mlDT As DataTable

    Dim pos_area, loguser, kelasdc, indukdc, indukmc, g1b, g2b As String
    Dim g1, g2, g3, g1a, g2a, g3a As Integer
    Dim lumpat, pgview, pgas, tothal, totrec, z, halskr, tujuan, sisa, pgcunt As Integer
    Public gtottunai, gtotkartu, gtotdebit, gtotall, gtotbalik, gtotbg As Double

    Public pg, bg, x, aax, kl, pgct, kemana, StartKemana As Integer
    Public kasir, tgl1, tgl2, pos, mlQuery, mypos, sort, pak, tg1, tg2, tpe, bgcol As String
    Public mlDR As OleDb.OleDbDataReader
    Public totnom, tottunai, totdebit, totcc, totbg As Double

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
        pak = "T"
        If Session("motok") = "" Or Session("kowe") = "" Or indukdc = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session.Contents("indukmc") = indukmc
        End If

        tgl1 = Request("tgl1")
        tgl2 = Request("tgl2")
        kasir = Request("kasir")
        If kasir = "" Then
            kasir = "semua"
        Else
            kasir = kasir
        End If

        If tgl1 = "" Then
            tgl1 = Now.AddDays(-30)
        Else
            tgl1 = tgl1
        End If

        If tgl2 = "" Then
            tgl2 = Now.Date
        Else
            tgl2 = tgl2
        End If


        If tgl1 <> "" And tgl2 <> "" Then
            tgl1 = tgl1
            tgl2 = tgl2

            g1 = Day(tgl1)
            If Len(g1) = 1 Then
                g1 = "0" + CStr(g1)
            Else
                g1 = g1
            End If
            g2 = Month(tgl1)
            If Len(g2) = 1 Then
                g2 = "0" + CStr(g2)
            Else
                g2 = g2
            End If
            g3 = Year(tgl1)
            'tg1 = cdate(cstr(g3)+"-"+cstr(g2)+"-"+cstr(g1))
            tg1 = CStr(g3) + "-" + CStr(g2) + "-" + CStr(g1)

            g1a = Day(tgl2)
            If Len(g1a) = 1 Then
                g1b = "0" + CStr(g1a)
            Else
                g1b = g1a
            End If

            g2a = Month(tgl2)
            If Len(g2a) = 1 Then
                g2b = "0" + CStr(g2a)
            Else
                g2b = g2a
            End If

            g3a = Year(tgl2)
            'tg2 = cdate(cstr(g3a)+"-"+cstr(g2b)+"-"+cstr(g1b))
            tg2 = CStr(g3a) + "-" + CStr(g2b) + "-" + CStr(g1b)
        End If

        Halaman()
        PrepareDisplay()
    End Sub

    Function roundup(x As Integer) As Integer
        If x > Int(x) Then
            roundup = Int(x) + 1
        Else
            roundup = x
        End If
        Return roundup
    End Function

    Sub Halaman()
        'halaman 
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
            mlSQL = "SELECT count(id) as id FROM st_sale_daftar where nopos like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                mlSQL = "SELECT count(id) as id FROM st_sale_daftar where nopos like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
            Else
                mlSQL = "SELECT count(id) as id FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'"
            End If
        End If

        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            x = 0
        Else
            x = CInt(mlREADER("id"))
        End If
        mlREADER.Close()

        lumpat = 0
        pg = 0
        pgview = Request("pgview")
        If pgview = "0" Then
            bg = 30
        Else
            bg = pgview
        End If

        pgas = Request("page")
        If pgas = "0" Then
            pg = 0
        Else
            If pgas <> "0" Then
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



        pgcunt = x / bg

        If pgcunt < 1 Then
            pgct = 1
        Else
            pgct = roundup(pgcunt)
        End If
        'halaman
    End Sub

    Sub PrepareDisplay()
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
            mlSQL = "SELECT isnull(sum(tunai),0) as tunai,isnull(sum(debit),0) as debit,isnull(sum(cc),0) as cc,isnull(sum(bg),0) as bg,isnull(sum(harga),0) as harga,isnull(sum(kembalian),0) as kembalian FROM st_sale_daftar where nopos like '" & mypos & "'" & vbCrLf
            mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                mlSQL = "SELECT isnull(sum(tunai),0) as tunai,isnull(sum(debit),0) as debit,isnull(sum(cc),0) as cc,isnull(sum(bg),0) as bg,isnull(sum(harga),0) as harga,isnull(sum(kembalian),0) as kembalian FROM st_sale_daftar where nopos like '" & mypos & "'" & vbCrLf
                mlSQL += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
            Else
                mlSQL = "SELECT isnull(sum(tunai),0) as tunai,isnull(sum(debit),0) as debit,isnull(sum(cc),0) as cc,isnull(sum(bg),0) as bg,isnull(sum(harga),0) as harga,isnull(sum(kembalian),0) as kembalian" & vbCrLf
                mlSQL += "From st_sale_daftar Where nopos Like '" & mypos & "' and pakai like '" & pak & "'"
            End If
        End If

        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            gtottunai = 0
            gtotkartu = 0
            gtotdebit = 0
            gtotall = 0
            gtotbalik = 0
            gtotbg = 0
        Else
            gtottunai = mlREADER("tunai")
            gtotkartu = mlREADER("cc")
            gtotdebit = mlREADER("debit")
            gtotall = mlREADER("harga")
            gtotbg = mlREADER("bg")
            gtotbalik = mlREADER("kembalian")
        End If
        mlREADER.Close()

        If IsDBNull(gtotbg) = False Then
            gtotbg = gtotbg
        Else
            gtotbg = 0
        End If

        If IsDBNull(gtotkartu) = False Then
            gtotkartu = gtotkartu
        Else
            gtotkartu = 0
        End If

        If IsDBNull(gtotdebit) = False Then
            gtotdebit = gtotdebit
        Else
            gtotdebit = 0
        End If

        If IsDBNull(gtotall) = False Then
            gtotall = gtotall
        Else
            gtotall = 0
        End If

        If IsDBNull(gtotbalik) = False Then
            gtotbalik = gtotbalik
        Else
            gtotbalik = 0
        End If

        If IsDBNull(gtottunai) = False Then
            gtottunai = gtottunai - gtotbalik
        Else
            gtottunai = 0
        End If
    End Sub


End Class

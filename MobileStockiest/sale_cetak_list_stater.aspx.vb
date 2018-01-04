Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_cetak_list_stater
    Inherits System.Web.UI.Page
    Public mlOBJGS As New IASClass.ucmGeneralSystem
    Public mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String

    Dim pos_area, loguser As String

    Dim g1, g1a, g1b, g2, g2a, g2b, g3, g3a As Integer
    Dim pgview, bg, pgas As String
    Dim pg, x, tothal, z, totrec, halskr, tujuan, sisa, kemana As Integer

    Public mlDR As OleDb.OleDbDataReader
    Public mlQuery As String
    Public mlDT As DataTable
    Public mlCOMPANYID As String = "ALL"
    Public mpMODULEID As String = "PB"
    Public perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, tgl1, tgl2, kasir, mypos, pak, tg1, tg2, sort As String
    Public totnom, tottunai, totdebit, totcc, totbg As Double
    Public lumpat As Integer
    Public gtottunai, gtotkartu, gtotdebit, gtotall, gtotbalik, gtotvouc As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        pak = "T"
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        PrepareData()
        Halaman()
        PrepareDisplay()

    End Sub

    Sub PrepareData()
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
    End Sub

    Sub Halaman()
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
            mlSQL = "SELECT count(id) as id FROM st_sale_daftar where nopos like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                mlSQL = "SELECT count(id) as id FROM st_sale_daftar where nopos like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                mlSQL += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
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

        pgview = Request("pgview")
        bg = Request("pgview")

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
    End Sub

    Sub PrepareDisplay()
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
            mlSQL = "SELECT sum(tunai) as tunai,sum(debit) as debit,sum(cc) as cc,sum(bg) as bg,sum(harga) as harga,sum(kembalian) as kembalian FROM st_sale_daftar where nopos like '" & mypos & "'" & vbCrLf
            mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                mlSQL = "SELECT sum(tunai) as tunai,sum(debit) as debit,sum(cc) as cc,sum(bg) as bg,sum(harga) as harga,sum(kembalian) as kembalian FROM st_sale_daftar where nopos like '" & mypos & "'" & vbCrLf
                mlSQL += "And kta Like '" & kasir & "' and (convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and pakai like '" & pak & "'"
            Else
                mlSQL = "SELECT sum(tunai) as tunai,sum(debit) as debit,sum(cc) as cc,sum(bg) as bg,sum(harga) as harga,sum(kembalian) as kembalian FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'"
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
            gtotvouc = 0
        Else
            gtottunai = mlREADER("tunai")
            gtotkartu = mlREADER("cc")
            gtotdebit = mlREADER("debit")
            gtotall = mlREADER("harga")
            gtotvouc = mlREADER("bg")
            gtotbalik = mlREADER("kembalian")
        End If
        mlREADER.Close()

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

        If IsDBNull(gtotvouc) = False Then
            gtotvouc = gtotvouc
        Else
            gtotvouc = 0
        End If

        If IsDBNull(gtottunai) = False Then
            gtottunai = gtottunai - gtotbalik
        Else
            gtottunai = 0
        End If

    End Sub
End Class

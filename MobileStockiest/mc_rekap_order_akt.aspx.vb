Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_rekap_order_akt
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDR, mlDR2 As OleDb.OleDbDataReader
    Protected mlDT As DataTable
    Protected mlQuery, mlQuery2 As String

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlDATATABLE As DataTable

    Protected sort, pos_area, mypos, loguser, kelasdc, indukdc, kti, ktm, indukmc, noinv, paket, sels As String
    Protected tgl1, tgl2, kasir, nomc, tg1, tg2, pgview, pgas, pos, pos2, kondisi As String
    Protected oke, oke2, g1, g2, g3, g1a, g1b, g2a, g2b, g3a, x, lumpat, sisa, kemana, bg, pg, tothal, halskr, z, totrec, tujuan, lim, pgcunt, pgct As Double
    Protected gtottunai, gtotkartu, gtotdebit, gtotall, gtotbalik, gtotbg, aax, kl, totnom, tottunai, totdebit, totcc, totbg As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        sort = Request("sort")
        pos_area = Session("pos_area")
        mypos = UCase(Session("motok"))
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        kti = "AKT"
        ktm = "AKT"
        indukmc = Session.Contents("indukmc")
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

        PrepareData()
        Halaman()
        PrepareDisplay()
    End Sub

    Sub PrepareData()
        tgl1 = Request("tgl1")
        tgl2 = Request("tgl2")
        kasir = Request("kasir")
        nomc = Request("nomc")

        oke = 9
        oke2 = 7
        If kasir = "" Then
            kasir = "semua"
        Else
            kasir = kasir
        End If

        If nomc = "" Then
            nomc = "semua"
        Else
            nomc = nomc
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

            g1 = Day(CDate(tgl1))
            If Len(g1) = 1 Then
                g1 = "0" + CStr(g1)
            Else
                g1 = g1
            End If

            g2 = Month(CDate(tgl1))
            If Len(g2) = 1 Then
                g2 = "0" + CStr(g2)
            Else
                g2 = g2
            End If

            g3 = Year(CDate(tgl1))
            'tg1 = cdate(cstr(g3)+"-"+cstr(g2)+"-"+cstr(g1))
            tg1 = CStr(g3) + "-" + CStr(g2) + "-" + CStr(g1)

            g1a = Day(CDate(tgl2))
            If Len(g1a) = 1 Then
                g1b = "0" + CStr(g1a)
            Else
                g1b = g1a
            End If

            g2a = Month(CDate(tgl2))
            If Len(g2a) = 1 Then
                g2b = "0" + CStr(g2a)
            Else
                g2b = g2a
            End If

            g3a = Year(CDate(tgl2))
            'tg2 = cdate(cstr(g3a)+"-"+cstr(g2b)+"-"+cstr(g1b))
            tg2 = CStr(g3a) + "-" + CStr(g2b) + "-" + CStr(g1b)
        End If
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
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc = "semua" Then
            mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
            mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                mlSQL += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
            Else
                If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                    mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                    mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                Else
                    If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                        mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                        mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                    Else
                        mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and (status = '" & oke & "' or status = '" & oke2 & "')"
                    End If
                End If
            End If
        End If

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
            bg = 34
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
            lim = bg
        Else
            kemana = pg * bg
            If kemana = 0 Then
                lim = bg
            Else
                lim = kemana * 2
            End If
        End If



        pgcunt = x / bg

        If pgcunt < 1 Then
            pgct = 1
        Else
            pgct = roundup(pgcunt)
        End If
    End Sub

    Sub PrepareDisplay()
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc = "semua" Then
            mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
            mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
            mlSQL += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                mlSQL += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
            Else
                If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                    mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                    mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                    mlSQL += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                Else
                    If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                        mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                        mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                    Else
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                        mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and (status = '" & oke & "' or status = '" & oke2 & "')"
                    End If
                End If
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
            gtottunai = mlREADER("vtunai")
            gtotkartu = mlREADER("vcc")
            gtotbg = mlREADER("vcek")
            gtotdebit = mlREADER("vdebit")
            gtotall = mlREADER("vsubtot")
            gtotbalik = mlREADER("vkembalian")
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

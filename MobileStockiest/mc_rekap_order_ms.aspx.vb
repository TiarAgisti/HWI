Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_rekap_order_ms
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDR As OleDb.OleDbDataReader
    Protected mlDT As DataTable
    Protected mlQuery As String

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlDATATABLE As DataTable
    Dim mlFUNCT As FunctionHWI

    Protected sort, pg, bg, pos, pos2, mypos, kondisi As String
    Protected tgl1, tgl2, kasir, nomc, kti, ktm, oke, oke2, lim, sels As String
    Protected aax, kl, pgct As Integer
    Protected totnom, tottunai, totdebit, totcc, totbg As Double
    Protected tg1, tg2 As Date
    Protected gtottunai, gtotkartu, gtotdebit, gtotall, gtotbalik, gtotbg, gtottunai_prd, gtotkartu_prd, gtotdebit_prd, gtotall_prd, gtotbalik_prd, gtotbg_prd As Double
    Protected gtottunai_pdn, gtotkartu_pdn, gtotdebit_pdn, gtotall_pdn, gtotbalik_pdn, gtotbg_pdn As Double

    Dim pos_area, loguser, kelasdc, indukdc, indukmc As String
    Dim g1, g1a, g2, g3, g1b, g2a, g2b, g3a As Integer
    Dim x, lumpat, pgview, pgas, tothal, z, totrec, halskr, tujuan, sisa, kemana, pgcunt As Integer


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
        kti = "PRD"
        ktm = "PDN"
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


        tgl1 = Request("tgl1")
        tgl2 = Request("tgl2")
        kasir = Request("kasir")
        nomc = Request("nomc")

        PrepareData()
        Halaman()
        PrepareGrandTotal()
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
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc = "semua" Then
            mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
            mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
            Else
                If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                    mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                    mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                Else
                    If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                        mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                        mlSQL += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                    Else
                        mlSQL = "SELECT count(id) as vid FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and status = '" & oke & "'"
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
        If pgview = "0" Then
            bg = 34
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
            'pgct = roundup(pgcunt)
        End If
    End Sub

    Sub PrepareGrandTotal()
        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc = "semua" Then
            mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
            mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and (( convert(varchar(10),tgl,121) >= '" & tg1 & "') and ( convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "')" & vbCrLf
                mlSQL += "And nopos Like '" & mypos & "' and kta like '" & kasir & "' and (( convert(varchar(10),tgl,121) >= '" & tg1 & "') and ( convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
            Else
                If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                    mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                    mlSQL += "where (kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and ((date(tgl) >= '" & tg1 & "') and (date(tgl) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                Else
                    If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                        mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                        mlSQL += "And (( convert(varchar(10),tgl,121) >= '" & tg1 & "') and ( convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')"
                    Else
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                        mlSQL += "where(kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and status = '" & oke & "'"
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
            If IsDBNull(mlREADER("vcek")) = False Then
                gtotbg = mlREADER("vcek")
            Else
                gtotbg = 0
            End If

            If IsDBNull(mlREADER("vcc")) = False Then
                gtotkartu = mlREADER("vcc")
            Else
                gtotkartu = 0
            End If

            If IsDBNull(mlREADER("vdebit")) = False Then
                gtotdebit = mlREADER("vdebit")
            Else
                gtotdebit = 0
            End If

            If IsDBNull(mlREADER("vsubtot")) = False Then
                gtotall = mlREADER("vsubtot")
            Else
                gtotall = 0
            End If

            If IsDBNull(mlREADER("vkembalian")) = False Then
                gtotbalik = mlREADER("vkembalian")
            Else
                gtotbalik = 0
            End If

            If IsDBNull(mlREADER("vtunai")) = False Then
                gtottunai = mlREADER("vtunai") - mlREADER("vkembalian")
            Else
                gtottunai = 0
            End If

            'gtottunai = mlREADER("vtunai")
            'gtotkartu = mlREADER("vcc")
            'gtotbg = mlREADER("vcek")
            'gtotdebit = mlREADER("vdebit")
            'gtotall = mlREADER("vsubtot")
            'gtotbalik = mlREADER("vkembalian")
        End If
        mlREADER.Close()



        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc = "semua" Then
            mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head where kat like '" & kti & "'" & vbCrLf
            mlSQL += "And nopos Like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) FROM fax_order_mc_head" & vbCrLf
                mlSQL += "where kat Like '" & kti & "' and nopos like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
            Else
                If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                    mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) FROM fax_order_mc_head where kat like '" & kti & "'" & vbCrLf
                    mlSQL += "And nopos Like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
                Else
                    If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) FROM fax_order_mc_head where kat like '" & kti & "'" & vbCrLf
                        mlSQL += "And nopos Like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
                    Else
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) FROM fax_order_mc_head" & vbCrLf
                        mlSQL += "where kat Like '" & kti & "' and nopos like '" & mypos & "' and status = '" & oke & "'"
                    End If
                End If
            End If
        End If

        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            gtottunai_prd = 0
            gtotkartu_prd = 0
            gtotdebit_prd = 0
            gtotall_prd = 0
            gtotbalik_prd = 0
            gtotbg_prd = 0
        Else
            If IsDBNull(mlREADER("vcek")) = False Then
                gtotbg_prd = mlREADER("vcek")
            Else
                gtotbg_prd = 0
            End If

            If IsDBNull(mlREADER("vcc")) = False Then
                gtotkartu_prd = mlREADER("vcc")
            Else
                gtotkartu_prd = 0
            End If

            If IsDBNull(mlREADER("vdebit")) = False Then
                gtotdebit_prd = mlREADER("vdebit")
            Else
                gtotdebit_prd = 0
            End If

            If IsDBNull(mlREADER("vsubtot")) = False Then
                gtotall_prd = mlREADER("vsubtot")
            Else
                gtotall_prd = 0
            End If

            If IsDBNull(mlREADER("vkembalian")) = False Then
                gtotbalik_prd = mlREADER("vkembalian")
            Else
                gtotbalik_prd = 0
            End If

            If IsDBNull(mlREADER("vtunai")) = False Then
                gtottunai_prd = mlREADER("vtunai") - mlREADER("vkembalian")
            Else
                gtottunai_prd = 0
            End If

            'gtottunai_prd = mlREADER("vtunai")
            'gtotkartu_prd = mlREADER("vcc")
            'gtotbg_prd = mlREADER("vcek")
            'gtotdebit_prd = mlREADER("vdebit")
            'gtotall_prd = mlREADER("vsubtot")
            'gtotbalik_prd = mlREADER("vkembalian")
        End If
        mlREADER.Close()

        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc = "semua" Then
            mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head where kat like '" & ktm & "'" & vbCrLf
            mlSQL += "And nopos Like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head where kat like '" & ktm & "'" & vbCrLf
                mlSQL += "And nopos Like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
            Else
                If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                    mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head where kat like '" & ktm & "'" & vbCrLf
                    mlSQL += "And nopos Like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
                Else
                    If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head where kat like '" & ktm & "'" & vbCrLf
                        mlSQL += "And nopos Like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and status = '" & oke & "'"
                    Else
                        mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM fax_order_mc_head" & vbCrLf
                        mlSQL += "where kat Like '" & ktm & "' and nopos like '" & mypos & "' and status = '" & oke & "'"
                    End If
                End If
            End If
        End If

        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            gtottunai_pdn = 0
            gtotkartu_pdn = 0
            gtotdebit_pdn = 0
            gtotall_pdn = 0
            gtotbalik_pdn = 0
            gtotbg_pdn = 0
        Else
            If IsDBNull(mlREADER("vcek")) = False Then
                gtotbg_pdn = mlREADER("vcek")
            Else
                gtotbg_pdn = 0
            End If

            If IsDBNull(mlREADER("vcc")) = False Then
                gtotkartu_pdn = mlREADER("vcc")
            Else
                gtotkartu_pdn = 0
            End If

            If IsDBNull(mlREADER("vdebit")) = False Then
                gtotdebit_pdn = mlREADER("vdebit")
            Else
                gtotdebit_pdn = 0
            End If

            If IsDBNull(mlREADER("vsubtot")) = False Then
                gtotall_pdn = mlREADER("vsubtot")
            Else
                gtotall_pdn = 0
            End If

            If IsDBNull(mlREADER("vkembalian")) = False Then
                gtotbalik_pdn = mlREADER("vkembalian")
            Else
                gtotbalik_pdn = 0
            End If

            If IsDBNull(mlREADER("vtunai")) = False Then
                gtottunai_pdn = mlREADER("vtunai") - mlREADER("vkembalian")
            Else
                gtottunai_pdn = 0
            End If

            'gtottunai_pdn = mlREADER("vtunai")
            'gtotkartu_pdn = mlREADER("vcc")
            'gtotbg_pdn = mlREADER("vcek")
            'gtotdebit_pdn = mlREADER("vdebit")
            'gtotall_pdn = mlREADER("vsubtot")
            'gtotbalik_pdn = mlREADER("vkembalian")
        End If
        mlREADER.Close()
    End Sub
End Class

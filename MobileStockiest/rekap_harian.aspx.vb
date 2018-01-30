Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_rekap_harian
    Inherits System.Web.UI.Page
    Dim mlREADER, mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mlDATATABLE As DataTable

    Protected mlQuery, mlQuery2 As String
    Protected mlDR, mlDR2 As OleDb.OleDbDataReader
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDT As DataTable
    Protected mlOBJGS As New IASClass.ucmGeneralSystem

    Protected pos_area, mypos, loguser, tipe, itung, sort, kelasdc, indukdc, indukmc, pak, kasir, pgview, pgas As String
    Protected tgl1, tg1, tpe As String
    Protected g1, g2, g3, totjualakt, tottunai, totdebit, totcc, totcek, jumbayarakt, kembaliakt As Double
    Protected totjualprd, tottunaiprd, totdebitprd, totccprd, totcekprd, jumbayarprd, kembaliprd As Double
    Protected xk, x, lumpat, pg, bg, tothal, z, totrec, halskr, tujuan, sisa, kemana, pgcunt, sisanya, pgct1, pgct, totstart, totprod, tottot As Double

    Protected raono, tpe1, tpe2 As String
    Protected gtotdaftar, gtotprd, gtote, gtottunai, gtotdebit, gtotcc, gtoto, gtotvouc, totvouc, totkembali, tunai, totccv, totvoucprd, aax, kl, t1, t2, t3, p1, p2, p3 As Double
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

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        tipe = Request("tipe")
        itung = Request("itung")
        sort = Request("sort")
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
        TotalPenjualanStarterKitHarian()
        TotalPenjualanStarterKitHarianPerKasir()
        RekapPenjualanProdukHarianPerKasir()
    End Sub

    Sub PrepareData()

        tgl1 = Request("tgl1")

        If tgl1 = "" Then
            tgl1 = Now.Date
        Else
            tgl1 = tgl1
        End If

        If tgl1 <> "" Then

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
            tg1 = CStr(g3) + "-" + CStr(g2) + "-" + CStr(g1)

        End If

        mlSQL = "SELECT * FROM rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlSQL2 = "Delete From rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            'For aaaeqkmf = 1 To 15
            '    If rs.eof = True Then Exit For
            '    rs.delete
            '    rs.update
            '    rs.movenext
            'Next
        End If
        mlREADER.Close()

        mlSQL = "SELECT * FROM rekap_harian_kasir where nopos like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlSQL2 = "Delete From FROM rekap_harian_kasir where nopos like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            'For aaaeqkmf = 1 To 15
            '    If rs.eof = True Then Exit For
            '    rs.delete
            '    rs.update
            '    rs.movenext
            'Next
        End If
        mlREADER.Close()
    End Sub

    Sub TotalPenjualanStarterKitHarian()
        '''''''''''''''''''''''''''''''''''''''
        ' TOTAL PENJUALAN STARTER KIT HARIAN
        '''''''''''''''''''''''''''''''''''''''


        pak = "T"
        mlSQL = "SELECT sum(harga) as vharga,sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(bg) as vbg,sum(jumbayar) as vjumbayar,sum(kembalian) as vkembalian FROM st_sale_daftar" & vbCrLf
        mlSQL += "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and pakai like '" & pak & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totjualakt = 0
            tottunai = 0
            totdebit = 0
            totcc = 0
            totcek = 0
            jumbayarakt = 0
            kembaliakt = 0
        Else
            totjualakt = mlREADER("vharga")
            tottunai = mlREADER("vtunai")
            totdebit = mlREADER("vdebit")
            totcc = mlREADER("vcc")
            totcek = mlREADER("vbg")
            jumbayarakt = mlREADER("vjumbayar")
            kembaliakt = mlREADER("vkembalian")
        End If
        mlREADER.Close()

        If IsDBNull(totjualakt) Then
            totjualakt = 0
        Else
            totjualakt = totjualakt
        End If

        If IsDBNull(tottunai) Then
            tottunai = 0
        Else
            tottunai = tottunai
        End If

        If IsDBNull(totdebit) Then
            totdebit = 0
        Else
            totdebit = totdebit
        End If

        If IsDBNull(totcc) Then
            totcc = 0
        Else
            totcc = totcc
        End If

        If IsDBNull(totcek) Then
            totcek = 0
        Else
            totcek = totcek
        End If

        If IsDBNull(jumbayarakt) Then
            jumbayarakt = 0
        Else
            jumbayarakt = jumbayarakt
        End If

        If IsDBNull(kembaliakt) Then
            kembaliakt = 0
        Else
            kembaliakt = kembaliakt
        End If

        tpe = "AKT"
        mlSQL = "SELECT * FROM rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into rekap_harian(nopos,tgl,tipe,totjual,tunai,debit,cc,cek,jumbayar,kembalian)values('" & mypos & "','" & tgl1 & "','AKT','" & totjualakt & "','" & tottunai & "'" & vbCrLf
            mlSQL2 += ",'" & totdebit & "','" & totcc & "','" & totcek & "','" & jumbayarakt & "','" & kembaliakt & "')"
        Else
            mlSQL2 = "update rekap_harian set totjual = '" & totjualakt & "',tunai = '" & tottunai & "',debit = '" & totdebit & "',cc = '" & totcc & "',cek = '" & totcek & "',jumbayar = '" & jumbayarakt & "'" & vbCrLf
            mlSQL2 = ",kembalian = '" & kembaliakt & "' where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()

        '''''''''''''''''''''''''''''''''''''
        ' REKAP PENJUALAN PRODUK HARIAN
        '''''''''''''''''''''''''''''''''''''

        mlSQL = "SELECT sum(subtot) as vsubtot,sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(jumbayar) as vjumbayar,sum(kembalian) as vkembalian FROM st_sale_prd_head" & vbCrLf
        mlSQL += "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totjualprd = 0
            tottunaiprd = 0
            totdebitprd = 0
            totccprd = 0
            totcekprd = 0
            jumbayarprd = 0
            kembaliprd = 0
        Else
            totjualprd = mlREADER("vsubtot")
            tottunaiprd = mlREADER("vtunai")
            totdebitprd = mlREADER("vdebit")
            totccprd = mlREADER("vcc")
            totcekprd = mlREADER("vcek")
            jumbayarprd = mlREADER("vjumbayar")
            kembaliprd = mlREADER("vkembalian")
        End If
        mlREADER.Close()

        If IsDBNull(totjualprd) Then
            totjualprd = 0
        Else
            totjualprd = totjualprd
        End If

        If IsDBNull(tottunaiprd) Then
            tottunaiprd = 0
        Else
            tottunaiprd = tottunaiprd
        End If

        If IsDBNull(totdebitprd) Then
            totdebitprd = 0
        Else
            totdebitprd = totdebitprd
        End If

        If IsDBNull(totccprd) Then
            totccprd = 0
        Else
            totccprd = totccprd
        End If

        If IsDBNull(totcekprd) Then
            totcekprd = 0
        Else
            totcekprd = totcekprd
        End If

        If IsDBNull(jumbayarprd) Then
            jumbayarprd = 0
        Else
            jumbayarprd = jumbayarprd
        End If

        If IsDBNull(kembaliprd) Then
            kembaliprd = 0
        Else
            kembaliprd = kembaliprd
        End If

        tpe = "PRD"
        mlSQL = "SELECT * FROM rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into rekap_harian(nopos,tgl,tipe,totjual,tunai,debit,cc,cek,jumbayar,kembalian)values('" & mypos & "','" & tgl1 & "','PRD','" & totjualprd & "','" & tottunaiprd & "'" & vbCrLf
            mlSQL2 += ",'" & totdebitprd & "','" & totccprd & "','" & totcekprd & "','" & jumbayarprd & "','" & kembaliprd & "')"
        Else
            mlSQL2 = "update rekap_harian set totjual = '" & totjualprd & "',tunai = '" & tottunaiprd & "',debit = '" & totdebitprd & "',cc = '" & totccprd & "',cek = '" & totcekprd & "',jumbayar = '" & jumbayarprd & "'" & vbCrLf
            mlSQL2 = ",kembalian = '" & kembaliprd & "' where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()

        mlSQL = "SELECT * FROM sum_rekap_harian where nopos like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            mlSQL2 = "insert into sum_rekap_harian(nopos,tgl,starter,produk,total)values('" & mypos & "','" & tg1 & "','" & totjualakt & "','" & totjualprd & "','" & totjualakt + totjualprd & "')"
        Else
            mlSQL2 = "update sum_rekap_harian set starter = '" & totjualakt & "',produk = '" & totjualprd & "',total = '" & totjualakt + totjualprd & "'" & vbCrLf
            mlSQL2 = "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        End If
        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        mlREADER.Close()

    End Sub

    Sub TotalPenjualanStarterKitHarianPerKasir()
        ''''''''''''''''''''''''''''''''''''''''''''''''
        ' TOTAL PENJUALAN STARTER KIT HARIAN PER KASIR
        ''''''''''''''''''''''''''''''''''''''''''''''''
        totjualakt = 0
        tottunai = 0
        totdebit = 0
        totcc = 0
        totcek = 0
        jumbayarakt = 0
        kembaliakt = 0
        kasir = "-"
        mlSQL = "SELECT kta,sum(harga) as vharga,sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(bg) as vbg,sum(jumbayar) as vjumbayar,sum(kembalian) as vkembalian FROM st_sale_daftar" & vbCrLf
        mlSQL += "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and pakai like '" & pak & "' GROUP BY kta"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlDATATABLE = New DataTable
            mlDATATABLE.Load(mlREADER)
            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                totjualakt = mlDATATABLE.Rows(aaaeqSSS)("vharga")
                tottunai = mlDATATABLE.Rows(aaaeqSSS)("vtunai")
                totdebit = mlDATATABLE.Rows(aaaeqSSS)("vdebit")
                totcc = mlDATATABLE.Rows(aaaeqSSS)("vcc")
                totcek = mlDATATABLE.Rows(aaaeqSSS)("vbg")
                jumbayarakt = mlDATATABLE.Rows(aaaeqSSS)("vjumbayar")
                kembaliakt = mlDATATABLE.Rows(aaaeqSSS)("vkembalian")
                kasir = mlDATATABLE.Rows(aaaeqSSS)("kta")

                If IsDBNull(totjualakt) Then
                    totjualakt = 0
                Else
                    totjualakt = totjualakt
                End If

                If IsDBNull(tottunai) Then
                    tottunai = 0
                Else
                    tottunai = tottunai
                End If

                If IsDBNull(totdebit) Then
                    totdebit = 0
                Else
                    totdebit = totdebit
                End If

                If IsDBNull(totcc) Then
                    totcc = 0
                Else
                    totcc = totcc
                End If

                If IsDBNull(totcek) Then
                    totcek = 0
                Else
                    totcek = totcek
                End If

                If IsDBNull(jumbayarakt) Then
                    jumbayarakt = 0
                Else
                    jumbayarakt = jumbayarakt
                End If

                If IsDBNull(kembaliakt) Then
                    kembaliakt = 0
                Else
                    kembaliakt = kembaliakt
                End If

                tpe = "AKT"
                mlSQL2 = "SELECT * FROM rekap_harian_kasir where nopos like '" & mypos & "' and tipe like '" & tpe & "'" & vbCrLf
                mlSQL2 += "And (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    mlSQL3 = "insert into rekap_harian_kasir(nopos,tgl,tipe,totjual,tunai,debit,cc,cek,jumbayar,kembalian,kasir)values('" & mypos & "','" & tg1 & "','AKT','" & totjualakt & "'" & vbCrLf
                    mlSQL3 += ",'" & tottunai & "','" & totdebit & "','" & totcc & "','" & totcek & "','" & jumbayarakt & "','" & kembaliakt & "','" & kasir & "')"
                Else
                    mlSQL3 = "update rekap_harian_kasir set totjual = '" & totjualakt & "',tunai = '" & tottunai & "',debit = '" & totdebit & "',cc = '" & totcc & "',cek = '" & totcek & "'" & vbCrLf
                    mlSQL3 += ",jumbayar = '" & jumbayarakt & "',kembalian = '" & kembaliakt & "',kasir = '" & kasir & "' where nopos like '" & mypos & "' and tipe like '" & tpe & "'" & vbCrLf
                    mlSQL3 += "And (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                End If
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                mlREADER2.Close()

                mlSQL2 = "SELECT * FROM sum_rekap_harian_kasir where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    mlSQL3 = "insert into sum_rekap_harian_kasir(nopos,tgl,starter,produk,total,kasir)values('" & mypos & "','" & tg1 & "','" & totjualakt & "',0,'" & totjualakt & "','" & kasir & "')"
                Else
                    mlSQL3 = "update sum_rekap_harian_kasir set starter = '" & totjualakt & "',total = '" & totjualakt & "',kasir = '" & kasir & "'" & vbCrLf
                    mlSQL3 += "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                End If
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                mlREADER2.Close()
            Next
        End If
        mlREADER.Close()
    End Sub

    Sub RekapPenjualanProdukHarianPerKasir()
        ''''''''''''''''''''''''''''''''''''''''''''
        ' REKAP PENJUALAN PRODUK HARIAN PER KASIR
        ''''''''''''''''''''''''''''''''''''''''''''
        mlSQL = "SELECT kta,sum(subtot) as vsubtot,sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(jumbayar) as vjumbayar,sum(kembalian) as vkembalian FROM st_sale_prd_head" & vbCrLf
        mlSQL += "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') GROUP BY kta"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlDATATABLE = New DataTable
            mlDATATABLE.Load(mlREADER)
            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                totjualprd = mlDATATABLE.Rows(aaaeqSSS)("vsubtot")
                tottunaiprd = mlDATATABLE.Rows(aaaeqSSS)("vtunai")
                totdebitprd = mlDATATABLE.Rows(aaaeqSSS)("vdebit")
                totccprd = mlDATATABLE.Rows(aaaeqSSS)("vcc")
                totcekprd = mlDATATABLE.Rows(aaaeqSSS)("vcek")
                jumbayarprd = mlDATATABLE.Rows(aaaeqSSS)("vjumbayar")
                kembaliprd = mlDATATABLE.Rows(aaaeqSSS)("vkembalian")
                kasir = mlDATATABLE.Rows(aaaeqSSS)("kta")

                If IsDBNull(totjualprd) Then
                    totjualprd = 0
                Else
                    totjualprd = totjualprd
                End If

                If IsDBNull(tottunaiprd) Then
                    tottunaiprd = 0
                Else
                    tottunaiprd = tottunaiprd
                End If

                If IsDBNull(totdebitprd) Then
                    totdebitprd = 0
                Else
                    totdebitprd = totdebitprd
                End If

                If IsDBNull(totccprd) Then
                    totccprd = 0
                Else
                    totccprd = totccprd
                End If

                If IsDBNull(totcekprd) Then
                    totcekprd = 0
                Else
                    totcekprd = totcekprd
                End If

                If IsDBNull(jumbayarprd) Then
                    jumbayarprd = 0
                Else
                    jumbayarprd = jumbayarprd
                End If

                If IsDBNull(kembaliprd) Then
                    kembaliprd = 0
                Else
                    kembaliprd = kembaliprd
                End If

                tpe = "PRD"
                mlSQL2 = "SELECT * FROM rekap_harian_kasir where nopos like '" & mypos & "' and tipe like '" & tpe & "'" & vbCrLf
                mlSQL2 += "And (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    mlSQL3 = "insert into rekap_harian_kasir(nopos,tgl,tipe,totjual,tunai,debit,cc,cek,jumbayar,kembalian,kasir)values('" & mypos & "','" & tg1 & "','PRD','" & totjualprd & "'" & vbCrLf
                    mlSQL3 += ",'" & tottunaiprd & "','" & totdebitprd & "','" & totccprd & "','" & totcekprd & "','" & jumbayarprd & "','" & kembaliprd & "','" & kasir & "')"
                Else
                    mlSQL3 = "update rekap_harian_kasir set totjual = '" & totjualprd & "',tunai = '" & tottunaiprd & "',debit = '" & totdebitprd & "',cc = '" & totccprd & "',cek = '" & totcekprd & "'" & vbCrLf
                    mlSQL3 += ",jumbayar = '" & jumbayarprd & "',kembalian = '" & kembaliprd & "',kasir = '" & kasir & "'where nopos like '" & mypos & "' and tipe like '" & tpe & "'" & vbCrLf
                    mlSQL3 += "And (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                End If
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
                mlREADER2.Close()

                mlSQL2 = "SELECT * FROM sum_rekap_harian_kasir where nopos like '" & mypos & "'" & vbCrLf
                mlSQL2 += "And (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                    mlSQL3 = "insert into sum_rekap_harian_kasir(nopos,tgl,starter,produk,total,kasir)values('" & mypos & "','" & tg1 & "',0,'" & totjualprd & "','" & totjualprd & "','" & kasir & "')"
                Else
                    mlSQL3 = "update sum_rekap_harian_kasir set produk = '" & totjualprd & "',total = '" & mlREADER2("total") + totjualprd & "',kasir = '" & kasir & "'" & vbCrLf
                    mlSQL3 += "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                End If
                mlREADER2.Close()
            Next
        End If
        mlREADER.Close()


        mlSQL = "SELECT count(id) as vid FROM sum_rekap_harian_kasir where nopos like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            xk = 0
        Else
            xk = CInt(mlREADER("vid"))
        End If
        mlREADER.Close()

        mlSQL = "SELECT count(id) as vid FROM sum_rekap_harian where nopos like '" & mypos & "'"
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
            bg = 30
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

        mlSQL = "SELECT sum(starter) as vstarter,sum(produk) as vproduk,sum(total) as vtotal FROM sum_rekap_harian where nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totstart = 0
            totprod = 0
            tottot = 0
        Else
            totstart = mlREADER("vstarter")
            totprod = mlREADER("vproduk")
            tottot = mlREADER("vtotal")
        End If
        mlREADER.Close()
    End Sub
End Class

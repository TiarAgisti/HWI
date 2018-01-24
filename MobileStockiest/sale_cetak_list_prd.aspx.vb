Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_cetak_list_prd
    Inherits System.Web.UI.Page
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String

    Protected mlQuery As String
    Protected mlDR As OleDb.OleDbDataReader
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDT As DataTable
    Protected mlOBJGS As New IASClass.ucmGeneralSystem

    Protected pos_area, mypos, loguser, tgl1, tgl2, kasir, tg1, tg2, pgview, bg, pgas, sort, tpe As String
    Protected g1, g2, g3, g1a, g1b, g2a, g2b, g3a, x, pg, tothal, totrec, halskr, tujuan, sisa, lumpat, kemana, z As Integer
    Protected gtottunai, gtotkartu, gtotdebit, gtotall, gtotbalik, gtotvouc As Double

    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, tgl As String
    Protected totnom, tottunai, totdebit, totcc, totbg As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

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

        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
            mlSQL = "SELECT count(id) as vid FROM st_sale_prd_head where nopos like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                mlSQL = "SELECT count(id) as vid FROM st_sale_prd_head where nopos like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))"
            Else
                mlSQL = "SELECT count(id) as vid FROM st_sale_prd_head where nopos like '" & mypos & "'"
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
        If sisa < CInt(bg) Then
            lumpat = CInt(bg) + sisa
        Else
            lumpat = CInt(bg)
        End If

        If tujuan > totrec Then
            kemana = 0
        Else
            kemana = pg * CInt(bg)
        End If


        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
            mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM st_sale_prd_head" & vbCrLf
            mlSQL += "where nopos Like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM st_sale_prd_head" & vbCrLf
                mlSQL += "where nopos Like '" & mypos & "' and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))"
            Else
                mlSQL = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(cek) as vcek,sum(subtot) as vsubtot,sum(kembalian) as vkembalian FROM st_sale_prd_head where nopos like '" & mypos & "'"
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
            gtottunai = mlREADER("vtunai")
            gtotkartu = mlREADER("vcc")
            gtotdebit = mlREADER("vdebit")
            gtotall = mlREADER("vsubtot")
            gtotvouc = mlREADER("vcek")
            gtotbalik = mlREADER("vkembalian")
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

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_saldo_feems
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction
    Dim mlOBJPJ As New FunctionLocal

    Dim mlFHWI As New FunctionHWI

    ' Default Variable
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlKEY As String
    Dim mlKEY2 As String
    Dim mlKEY3 As String
    Dim mlRECORDSTATUS As String
    Dim mlSPTYPE As String
    Dim mlFUNCTIONPARAMETER As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"

    Public sort, tg1, tg2, sss, kel, kele, kelem As String
    Public pos_area, mypos, loguser, tipe, itung, kelasdc, indukdc, indukmc, pgview, pgas As String
    Public pg, x, totproduk, totakt, totaktms, totprodms, totbelanja, totfee, g1, g2, g3, g1a, g1b, g2a, g2b, g3a, lumpat As Integer
    Public tgl1, tgl2 As String
    Public tothal, totrec, halskr, tujuan, sisa, bg, kemana, z, pgcunt, sisanya, pgct1, pgct As Integer

    'Public tgl1, tgl2 As Date
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

        PersiapanAwal()
        PersiapanData()
    End Sub

    Private Sub PersiapanAwal()
        tgl1 = Request("tgl1")
        tgl2 = Request("tgl2")

        If tgl1 <> "" And tgl2 <> "" Then
            tgl1 = tgl1
            tgl2 = tgl2
        Else
            tgl1 = Now.AddDays(-7)
            tgl2 = Today.Date
        End If



        g1 = Today.Day

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


        'halaman
        If tgl1 <> "" And tgl2 <> "" Then
            mlSQL = "SELECT count(id) as id FROM bns_feedcmc where nopos like '" & mypos & "' and tgl >= '" & CDate(tg1) & "' and tgl <= '" & CDate(tg2) & "'"
        Else
            mlSQL = "SELECT count(id) as id FROM bns_feedcmcs where nopos like '" & mypos & "'"
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        mlREADER.Read()
        If Not mlREADER.HasRows Then
            x = 0
        Else
            x = mlREADER("id")
        End If
        mlREADER.Close()


        lumpat = 0
        pg = 0
        pgview = Request("pgview")
        If pgview = "" Then
            bg = 150
        Else
            bg = CInt(pgview)
        End If


        pgas = Request("page")
        If pgas = "" Then
            pg = 0
        Else
            If pgas <> "" Then
                pg = CInt(pgas) - 1
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
        'halaman


        sss = "T"
        kel = "PRD"
        If tgl1 <> "" And tgl2 <> "" Then
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmc where nopos like '" & mypos & "' and tgl >= '" & CDate(tg1) & "' and tgl <= '" & CDate(tg2) & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        Else
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmcs where nopos like '" & mypos & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totproduk = 0
        Else
            totproduk = mlREADER("sum(fee_amt)")
        End If
        mlREADER.Close()

        If IsDBNull(totproduk) = False Then
            totproduk = totproduk
        Else
            totproduk = 0
        End If

        kel = "AKT"
        If tgl1 <> "" And tgl2 <> "" Then
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmc where nopos like '" & mypos & "' and tgl >= '" & CDate(tg1) & "' and tgl <= '" & CDate(tg2) & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        Else
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmcs where nopos like '" & mypos & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totakt = 0
        Else
            mlREADER.Read()
            totakt = mlREADER("sum(fee_amt)")
        End If
        mlREADER.Close()

        If IsDBNull(totakt) = False Then
            totakt = totakt
        Else
            totakt = 0
        End If

        kel = "ORG"
        If tgl1 <> "" And tgl2 <> "" Then
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmc where nopos like '" & mypos & "' and tgl >= '" & tg1 & "' and tgl <= '" & tg2 & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        Else
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmcs where nopos like '" & mypos & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totaktms = 0
        Else
            mlREADER.Read()
            'totaktms = mlREADER("sum(fee_amt)")
            totaktms = 0
        End If
        mlREADER.Close()

        If IsDBNull(totaktms) = False Then
            totaktms = totaktms
        Else
            totaktms = 0
        End If

        kel = "OPD"
        If tgl1 <> "" And tgl2 <> "" Then
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmc where nopos like '" & mypos & "' and tgl >= '" & tg1 & "' and tgl <= '" & tg2 & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        Else
            mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmcs where nopos like '" & mypos & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totprodms = 0
        Else
            mlREADER.Read()
            totprodms = mlREADER("sum(fee_amt)")
        End If
        mlREADER.Close()

        If IsDBNull(totprodms) = False Then
            totprodms = totprodms
        Else
            totprodms = 0
        End If

        totfee = totproduk + totakt + totaktms + totprodms

        ' akumulasi belanja min Rp 1.000.000,- (sebelum potongan) dari produk dan paket registrasi
        If tgl1 <> "" And tgl2 <> "" Then
            mlSQL = "SELECT sum(TOT_amt) FROM bns_feedcmc where nopos like '" & mypos & "' and tgl >= '" & CDate(tg1) & "' and tgl <= '" & CDate(tg2) & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        Else
            mlSQL = "SELECT sum(tot_amt) FROM bns_feedcmcs where nopos like '" & mypos & "' and kel like '" & kel & "' and sta like '" & sss & "' GROUP BY nopos"
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totbelanja = 0
        Else
            mlREADER.Read()
            totbelanja = mlREADER("sum(tot_amt)")
        End If
        mlREADER.Close()

        If IsDBNull(totbelanja) = False Then
            totbelanja = totbelanja
        Else
            totbelanja = 0
        End If
    End Sub

    Private Sub PersiapanData()
        If tgl1 <> "" And tgl2 <> "" Then
            If sort = "Bulan" Then
                mlSQL2 = "SELECT * FROM bns_feedcmc where nopos like '" & mypos & "'  and tgl >= '" & CDate(tg1) & "' and tgl <= '" & CDate(tg2) & "' order by tgl DESC"
            Else
                If sort = "tanggal" Then
                    mlSQL2 = "SELECT * FROM bns_feedcmc where nopos like '" & mypos & "'  and tgl >= '" & CDate(tg1) & "' and tgl <= '" & CDate(tg2) & "' order by tgl DESC"
                Else
                    mlSQL2 = "SELECT * FROM bns_feedcmc where nopos like '" & mypos & "'  and tgl >= '" & CDate(tg1) & "' and tgl <= '" & CDate(tg2) & "' order by tgl DESC"
                End If
            End If
        Else
            If sort = "Bulan" Then
                mlSQL2 = "SELECT * FROM bns_feedcmc where nopos like '" & mypos & "' order by tgl DESC"
            Else
                If sort = "tanggal" Then
                    mlSQL2 = "SELECT * FROM bns_feedcmc where nopos like '" & mypos & "' order by tgl DESC"
                Else
                    mlSQL2 = "SELECT * FROM bns_feedcmc where nopos like '" & mypos & "' order by tgl DESC"
                End If
            End If
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        Dim strTables As String = ""

        strTables += "<tbody>" & vbCrLf
        If Not mlREADER.HasRows Then
            strTables += "<tr>" & vbCrLf
            strTables += "<td width='100%' align='center' height='40'>" & vbCrLf
            strTables += "<u>Tidak ada data</u>" & vbCrLf
            strTables += "</td>" & vbCrLf
            strTables += "</tr>" & vbCrLf
        Else
            While mlREADER.Read
                Dim status, statusDesc As String
                kele = mlREADER("kel")
                status = mlREADER("sta")
                If status = "T" Then
                    statusDesc = "Aktif"
                Else
                    statusDesc = "Cancel"
                End If

                If kele = "PRD" Then
                    kelem = "Produk Distributor"
                Else
                    If kele = "OPD" Then
                        kelem = "MS Order Produk"
                    Else
                        If kele = "ORG" Then
                            kelem = "MS Order Paket Pendaftaran"
                        Else
                            If kele = "AKT" Then
                                kelem = "Registrasi Distributor"
                            Else
                                If kele = "PMS" Then
                                    kelem = "Order Perdana MS"
                                End If
                            End If
                        End If
                    End If
                End If

                strTables += "<tr>" & vbCrLf
                strTables += "<td>&nbsp;" & mlREADER("tgl") & "</td>" & vbCrLf
                strTables += "<td>&nbsp;" & mlREADER("noinvo") & "</td>" & vbCrLf
                strTables += "<td>&nbsp;" & mlREADER("nopajak") & "</td>" & vbCrLf
                strTables += "<td>&nbsp;" & kelem & "</td>" & vbCrLf
                strTables += "<td align='right'>&nbsp;" & FormatNumber(mlREADER("tot_amt"), 0) & "</td>" & vbCrLf
                strTables += "<td align='right'>&nbsp;" & FormatNumber(mlREADER("hargadc"), 0) & "</td>" & vbCrLf
                strTables += "<td align='right'>&nbsp;" & FormatNumber(mlREADER("tot_pv"), 0) & "</td>" & vbCrLf
                strTables += "<td align='right'>&nbsp;" & FormatNumber(mlREADER("fee_amt"), 0) & "</td>" & vbCrLf
                strTables += "<td align='right'>" & statusDesc & "</td>" & vbCrLf
                strTables += "</td>" & vbCrLf
                strTables += "</tr>" & vbCrLf
            End While
        End If
        strTables += "</tbody>" & vbCrLf
        dtSaldo.InnerHtml = strTables

    End Sub
    Protected Sub SaldoFeems_Click(sender As Object, e As EventArgs)
        PersiapanAwal()
        PersiapanData()
    End Sub
End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_ms4_perdana
    Inherits System.Web.UI.Page
    Dim mlREADER, mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mlDATATABLE As DataTable

    Public mlOBJGS As New IASClass.ucmGeneralSystem
    Public mpMODULEID As String = "PB"
    Public mlCOMPANYID As String = "ALL"
    Public mlDR, mlDR2 As OleDb.OleDbDataReader
    Public mlDT As DataTable
    Public mlQuery, mlQuery2 As String

    Dim ss1, ss2, satu, lama, aaaqsK As Integer
    Dim goneqSS As Integer = 0
    Dim wkt, skr As Date
    Dim noses As String

    Dim ggg, ste, lanjutdodol, namabrg, nodc, nofax, namadc As String
    Dim tglorder As Date

    'ms4_perdana_add
    Dim dcpusat, tipe, diskon, kemana, babe, gggs, gggs1, kode1s, jumlah1s, updit As String
    Dim jumlah As Integer
    Dim dino As Date

    Dim jumlahalokakt, jumakt, jumpaket, subtot As Double
    Dim diorder, sisa, sta, sts, diorder2, totdiod, jumstok, sisastok, hargabrg As Double

    Dim akhire As Integer
    Dim jumlama, pvlama, subtotlama, totpvlama As Double

    Public sutepe, dcHO, kode, nama, namamu, alamatdis, kotadis, kodeposdis, pp, prop_dc, telpdis, faxdis, emaildis, menu_id, error1 As String
    Public mesej, asal, kti, sort, pos_area, mypos, loguser, kelasdc, indukdc, namatabel, namatabel2, zona_id, area_id, nosesifaxmc_pdn, nokode_mc, namadis_mc As String
    Public totpv, totbv, gtot, pot, neto, newsubtot, newtotpv, gtotnet, jumdisk, jumtotdis, brapadis, disk_mcla, disk_mclama, pvmin, disk_mc, sds, jums, jumdivc, sbt, jumskr As Double
    Public harga1, kusus1, harga2, kusus2, harga3, kusus3, harga4, kusus4, harga5, kusus5, PV, bv, harga, kurangi, jumdis As Decimal
    Public tgl As Date


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        mesej = Session("errorfax")
        Session("errorfax") = ""
        asal = Session("asal")
        Session("asal") = ""
        Session("kti") = "PDN"
        kti = Session("kti")
        Session("nofax") = ""
        Session("nopos") = ""
        If asal = "selesai_order" Then
            Session("menu_id") = Session("menu_id")
        Else
            Session("menu_id") = Request("menu_id")
        End If

        PrepareDisplay()
        ClearNonRealizedBooked()
        OnlineBooked()
    End Sub

    Sub PrepareDisplay()
        Session("noinvo") = ""
        Session("asalnye") = ""
        sort = Request("sort")
        pos_area = Session("pos_area")
        mypos = UCase(Session("motok"))
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        'zona_id = request("zona_id")
        'area_id = request("area")
        sds = 0
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If
        sutepe = "PRD"

        If mypos = dcHO Then
            namatabel = "st_kartustock"
            namatabel2 = "st_barang"
            '	area_id = area_id
            '	pos_area = area_id
            pos_area = Request("area")
            zona_id = Request("zona_id")
            area_id = Request("area")
        Else
            namatabel = "st_kartustock_ms"
            namatabel2 = "st_barang_ms"
            '	area_id = pos_area
            '	pos_area = pos_area
            zona_id = pos_area
            area_id = pos_area
        End If

        If area_id = "" Then
            area_id = 0
        Else
            area_id = CInt(area_id)
        End If

    End Sub
    Protected Sub ClearNonRealizedBooked()
        ss1 = 0
        ss2 = 1
        satu = 2
        wkt = Now()

        mlSQL = "SELECT * FROM fx_order_mc_det where ((status = '" & ss1 & "') or (status = '" & ss2 & "')) and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        'mlREADER.Read()

        If mlREADER.HasRows <> True Then
            mlDATATABLE = New DataTable()
            mlDATATABLE.Load(mlREADER)

            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1

                skr = mlDATATABLE.Rows(aaaeqSSS)("tglorder")
                lama = DateDiff("n", skr, Now())

                If lama >= 10 Then
                    mlSQL = "update fx_order_mc_det" & vbCrLf
                    mlSQL += "Set status = -9," & vbCrLf
                    mlSQL += "    nosesi = 0, " & vbCrLf
                    mlSQL += "where ((status = '" & ss1 & "') or (status = '" & ss2 & "')) and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "'" & vbCrLf
                    mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                    noses = mlREADER("nosesi")
                    mlSQL2 = "SELECT * FROM fax_order_mc_head where nosesi like '" & noses & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
                    mlREADER2 = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER2.Read()

                    If mlREADER2.HasRows Then
                        mlSQL = "update fax_order_mc_head" & vbCrLf
                        mlSQL += "Set status = -9," & vbCrLf 'canceled
                        mlSQL += "    nosesi = 0, " & vbCrLf
                        mlSQL += "where nosesi like '" & noses & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'" & vbCrLf
                        mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                    End If
                    mlREADER2.Close()
                End If
            Next
        End If
        mlREADER.Close()
    End Sub
    Sub OnlineBooked()
        nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
        Session("nosesifaxmc_pdn") = nosesifaxmc_pdn

        If nosesifaxmc_pdn <> "" Then
            mlSQL = "SELECT count(id) FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "' and status like '" & sds & "' and kat like '" & kti & "' group by nosesi"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                jumskr = 0
            Else
                jumskr = CLng(mlREADER("count(id)"))
            End If
            mlREADER.Close()

            mlSQL = "SELECT nopos,tgl,nofax,tipe FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "' and nopos like '" & mypos & "' and status like '" & sds & "' and kat like '" & kti & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()

            If Not mlREADER.HasRows Then
                nodc = ""
                tglorder = ""
                nofax = ""
                sutepe = "PRD"
            Else
                nodc = mlREADER("nopos")
                tglorder = mlREADER("tgl")
                nofax = mlREADER("nofax")
                sutepe = mlREADER("tipe")
                If sutepe = "-" Then
                    sutepe = "PRD"
                Else
                    sutepe = sutepe
                End If
            End If
            mlREADER.Close()

            mlSQL = "SELECT namadc FROM tabdesc_stockist where nopos like '" & nodc & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                namadc = ""
            Else
                namadc = mlREADER("namadc")
            End If
            mlREADER.Close()
        Else
            mlSQL = "SELECT namadc FROM tabdesc_stockist where nopos like '" & mypos & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()

            If Not mlREADER.HasRows Then
                namadc = ""
            Else
                namadc = mlREADER("namadc")
            End If
            mlREADER.Close()
        End If

        namadis_mc = Session("namadis_mc")
        nokode_mc = Session("nokode_mc")
    End Sub

    'Protected Sub ms4_perdana_clear()
    '    Dim nosesifaxmc_akt As String
    '    Session("tema") = "home"
    '    Session("menu_id") = Session("menu_id")
    '    menu_id = Session("menu_id")
    '    pos_area = Session("pos_area")
    '    mypos = UCase(Session("motok"))
    '    loguser = Session("kowe")
    '    kelasdc = Session.Contents("kelasdc")
    '    indukdc = Session.Contents("indukdc")
    '    nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
    '    nosesifaxmc_akt = Session("nosesifaxmc_akt")
    '    nodc = UCase(Session("motok"))
    '    If Session("motok") = "" Or Session("kowe") = "" Then
    '        Session("out") = "Session login anda sudah expired, silahkan login kembali"
    '        Response.Redirect("login.aspx")
    '    Else
    '        Session("motok") = mypos
    '        Session("kowe") = loguser
    '        Session.Contents("kelasdc") = kelasdc
    '        Session.Contents("indukdc") = indukdc
    '    End If

    '    asal = Request("grp")
    '    kti = Session("kti")

    '    If asal = "PRD" Then
    '        kemana = "ms4_perdana.aspx?menu_id=" & menu_id
    '    Else
    '        kemana = "ms_order_register.aspx?menu_id=" & menu_id
    '    End If

    '    ''''''''''''''''''''''''''''''''
    '    ' SAVE TO TEMPORARY TABLE DETAIL
    '    ''''''''''''''''''''''''''''''''
    '    If asal = "PRD" Then
    '        kode = Session("nosesifaxmc_pdn")
    '        If kode = "" Then
    '            Session("errorfax") = "Session fax order sudah expired"
    '            Response.Redirect(kemana)
    '        End If

    '        mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi Like '" & nosesifaxmc_pdn & "'" & vbCrLf
    '        mlSQL2 += "And nopos Like '" & mypos & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        mlREADER2.Read()

    '        mlSQL = "SELECT * FROM fax_order_mc_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
    '        mlSQL += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
    '        mlREADER.Read()
    '        If mlREADER.HasRows Then
    '            mlSQL3 = "Update fax_order_mc_head set nofax = '-',nomc = '-',nopos = '-',totpv = 0, subtot = 0, diskon = 0, potongan = 0, gtot = 0, tipe = '-',status = -1" & vbCrLf
    '            mlSQL3 += "where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        mlREADER.Close()
    '        Session("nosesifaxmc_pdn") = ""
    '    End If
    '    mlREADER2.Close()

    '    If asal = "AKT" Then
    '        kode = Session("nosesifaxmc_akt")
    '        If kode = "" Then
    '            Session("errorfax") = "Session fax order sudah expired"
    '            Response.Redirect(kemana)
    '        End If
    '        ''''''''''''''''''''''''''''''''
    '        ' EDIT TEMPORARY TABLE DETAIL
    '        ''''''''''''''''''''''''''''''''
    '        mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '        mlSQL2 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        'mlREADER2.Read()
    '        If mlREADER2.HasRows Then
    '            mlSQL3 = "Delete FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '            mlSQL3 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        mlREADER2.Close()

    '        mlSQL2 = "SELECT * FROM fax_order_mc_paket_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_akt & "'" & vbCrLf
    '        mlSQL2 += "dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        mlREADER2.Read()
    '        If mlREADER2.HasRows Then
    '            mlSQL3 = "Delete From fax_order_mc_paket_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_akt & "'" & vbCrLf
    '            mlSQL3 += "dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        mlREADER2.Close()

    '        mlSQL2 = "SELECT * FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '        mlSQL2 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '        mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
    '        mlREADER2.Read()
    '        If mlREADER2.HasRows Then
    '            mlSQL3 = "Delete From fax_order_mc_head where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
    '            mlSQL3 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
    '            mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
    '        End If
    '        Session("nosesifaxmc_akt") = ""
    '    End If

    '    Session("pos_area") = ""
    '    Session("errorfax") = ""
    '    Session("namadis_mc") = ""
    '    Session("nokode_mc") = ""
    '    Response.Redirect(kemana)
    'End Sub
End Class

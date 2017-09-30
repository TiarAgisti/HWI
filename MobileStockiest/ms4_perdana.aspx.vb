
Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_ms4_perdana
    Inherits System.Web.UI.Page

    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlSQL2 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"

    Public mesej, asal, kti, sort, pos_area, mypos, loguser, kelasdc, indukdc, sutepe, namatabel, namatabel2, zona_id, area_id, nosesifaxmc_pdn As String
    Dim dcHO As String = ""
    Dim sds, ss1, ss2, satu, goneqSS, lama, aaaqsK As Integer
    Dim totpv, totbv, gtot, pot, neto, newsubtot, newtotpv, gtotnet, jumdisk, jumtotdis, brapadis, disk_mcla, disk_mc, disk_mclama, pvmin As Integer
    Dim wkt, skr As Date
    Dim noses As String

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

        'PrepareDisplay()
        'ClearNonRealizedBooked()
        'OnlineBooked()
        'PaketUpgradeFunction()
    End Sub

    Protected Sub PrepareDisplay()
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
        mlREADER.Read()

        If mlREADER.HasRows <> True Then

            If goneqSS <> 0 Then
                For aaeeqSS = 1 To goneqSS
                    If mlREADER.HasRows = True Then Exit For
                Next
            Else
            End If

            For aaaeqSSS = 1 To 70
                If mlREADER.HasRows = True Then
                    Exit For
                End If
                mlREADER.Read()
                skr = mlREADER("tglorder")
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

                    If Not mlREADER2.HasRows Then
                    Else
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
        'If mlREADER.HasRows = True Then
        'End If
        mlREADER.Close()
    End Sub
    Protected Sub OnlineBooked()
        Dim nosesifaxmc_pdn, nodc, nofax, namadc, namadis_mc, nokode_mc As String
        Dim jumskr As Long
        Dim tglorder As Date

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
    Protected Sub PaketUpgradeFunction()
        mlSQL = "SELECT kode,nama FROM st_barang_ms WHERE nopos like '" & mypos & "'" & vbCrLf
        mlSQL += "And jumlah > 0 And ( kode Like 'ms400u-14' or kode like 'ms200u-14' or kode like 'ms200au-14'" & vbCrLf
        mlSQL += "Or kode Like 'ms200vus-14' or kode like 'ms200vu-14' or kode like 'ms200bu-14' or kode like 'ms200hu-14'" & vbCrLf
        mlSQL += "Or kode Like 'ms200tg272u-14' or kode like 'ms100tg248u-14' or kode like 'ms200mu-14' or kode like 'ms200ku-14')"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        Dim strHtml As String = ""
        For aaaeqsK = 1 To 30
            If mlREADER.HasRows = True Then
                Exit For
            End If
            strHtml = "<br><a href = 'ms4_perdana_add.aspx?kode=" & UCase(mlREADER("kode")) & "&jumlah=1'<font size = '2'> -Upgrade Paket=" & UCase(mlREADER("kode")) & "</font></a>"
        Next

        paketUpgrade.InnerHtml = strHtml

        If mlREADER.HasRows = True Then
            aaaqsK = 1
        End If
        mlREADER.Close()
    End Sub
    Protected Sub PopulateData()
        totpv = 0
        totbv = 0
        gtot = 0
        pot = 0
        neto = 0
        newsubtot = 0
        newtotpv = 0
        gtotnet = 0
        jumdisk = 0
        jumtotdis = 0
        brapadis = 0
        disk_mcla = disk_mc
        disk_mclama = 0
        pvmin = 0

        mlSQL = "SELECT * FROM fx_order_mc_det where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' and status like '" & sds & "' and kat like '" & kti & "' order by id"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        Dim strTableHtml As String = ""
        strTableHtml = "<tbody>" & vbCrLf
        If Not mlREADER.HasRows Then
            strTableHtml += "<tr>" & vbCrLf
            strTableHtml += "<td>" & vbCrLf
            strTableHtml += "<u>Sesi ini belum ada belanjaan</u>" & vbCrLf
            strTableHtml += "</td>" & vbCrLf
            strTableHtml += "</tr>" & vbCrLf
        Else
        End If

        If mlREADER.HasRows <> True Then

            If goneqSS <> 0 Then
                For aaeeqSS = 1 To goneqSS
                    If mlREADER.HasRows = True Then
                        Exit For
                    End If
                Next
            Else
            End If

            For aaaeqSSS = 1 To 28
                If mlREADER.HasRows = True Then
                    Exit For
                End If

                Dim kode, jums, harga1, kusus1, harga2, kusus2, harga3, kusus3, harga4, kusus4, harga5, kusus5, PV, bv, nama As String
                Dim harga As String = 0
                kode = mlREADER("kode")
                jums = mlREADER("jumlah")

                mlSQL2 = "SELECT * FROM st_barang where kode like '" & kode & "'"
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                Else
                    harga1 = mlREADER2("hd1")
                    kusus1 = mlREADER2("khususmc1")
                    harga2 = mlREADER2("hd2")
                    kusus2 = mlREADER2("khususmc2")
                    harga3 = mlREADER2("hd3")
                    kusus3 = mlREADER2("khususmc3")
                    harga4 = mlREADER2("hd4")
                    kusus4 = mlREADER2("khususmc4")
                    harga5 = mlREADER2("hd5")
                    kusus5 = mlREADER2("khususmc5")
                    PV = mlREADER2("pv")
                    bv = mlREADER2("bv")
                    nama = mlREADER2("nama")


                    If area_id = 1 Then
                        If kusus1 <> 0 Then
                            harga = harga1
                            disk_mc = 0
                        Else
                            harga = harga1
                            disk_mc = disk_mc
                        End If
                    Else
                        If area_id = 2 Then
                            If kusus2 <> 0 Then
                                harga = harga2
                                disk_mc = 0
                            Else
                                harga = harga2
                                disk_mc = disk_mc
                            End If
                        Else
                            If area_id = 3 Then
                                If kusus3 <> 0 Then
                                    harga = harga3
                                    disk_mc = 0
                                Else
                                    harga = harga3
                                    disk_mc = disk_mc
                                End If
                            Else
                                If area_id = 4 Then
                                    If kusus4 <> 0 Then
                                        harga = harga4
                                        disk_mc = 0
                                    Else
                                        harga = harga4
                                        disk_mc = disk_mc
                                    End If
                                Else
                                    If area_id = 5 Then
                                        If kusus5 <> 0 Then
                                            harga = harga5
                                            disk_mc = 0
                                        Else
                                            harga = harga5
                                            disk_mc = disk_mc
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    If disk_mc > 0 Then
                        disk_mclama = disk_mcla
                    End If
                End If
                mlREADER2.Close()


                Dim subTot = harga * jums

                mlSQL = "update fx_order_mc_det" & vbCrLf
                mlSQL += "Set harga = '" & harga & "'" & vbCrLf
                mlSQL += ",subtot = '" & subTot & "'" & vbCrLf
                mlSQL += "nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' and status like '" & sds & "' and kat like '" & kti & "'" & vbCrLf
                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

                newsubtot = newsubtot + mlREADER("subtot")
                newtotpv = newtotpv + (mlREADER("pv") * mlREADER("jumlah"))

                Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia => buat apa???

                disk_mc = disk_mclama

                mlSQL2 = "UPDATE fax_order_mc_head SET totpv = '" & newtotpv & "'" & vbCrLf
                mlSQL2 += ",subtot = '" & newsubtot & "', potongan = 0, gtot = 0, diskon = '" & disk_mc & "'" & vbCrLf
                mlSQL2 += "WHERE nopos Like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)


                Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
                'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia

                'end if

                If area_id <> 0 Then
                    gtot = gtot + mlREADER("subtot")
                    totpv = totpv + (mlREADER("pv") * mlREADER("jumlah"))
                    totbv = 0
                Else
                    gtot = 0
                    totpv = totpv + (mlREADER("pv") * mlREADER("jumlah"))
                    totbv = 0
                End If


            Next


        End If

        strTableHtml += "</tbody>" & vbCrLf

        tbMsUpdgrade.InnerHtml = strTableHtml
    End Sub
End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mb4_perdana
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL, mlSQL2, mlSQL3 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable

    Dim wkt, skr As Date
    Dim lama, noses, sds, jumskr, ss1, ss2, satu As Integer
    Dim namatabel, namatabel2, area_id, zona_id, dcHO, kti, sort, pos_area, mypos, loguser, kelasdc, indukdc, sutepe As String
    Dim mesej, asal, nosesifaxmc_pdn, nodc, tglorder, nofax, namadc, namadis_mc, namae, nokode_mc, nokode_m As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        mesej = Session("errorfax")
        Session("errorfax") = ""
        Session("nofax") = ""
        Session("nopos") = ""
        asal = Session("asal")
        Session("asal") = ""
        If asal = "selesai_order" Then
            Session("menu_id") = Session("menu_id")
        Else
            Session("menu_id") = Request("menu_id")
        End If

        Session("kti") = "PDN"
        kti = Session("kti")
        Session("noinvo") = ""
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

        dcHO = ""
        If mypos = dcHO Then
            namatabel = "st_kartustock"
            namatabel2 = "st_barang"
            area_id = Request("area")
            zona_id = Request("zona_id")
        Else
            namatabel = "st_kartustock_ms"
            namatabel2 = "st_barang_ms"
            area_id = pos_area
            zona_id = ""
        End If

        If area_id = "" Then
            area_id = 0
        Else
            area_id = CInt(area_id)
        End If

        ''''''''''''''''''''''''''''''''''''''''''
        ' clear non realized booked
        ''''''''''''''''''''''''''''''''''''''''''
        'ss1 = 0
        'ss2 = 1
        'satu = 2
        'wkt = Now()
        ''rs.Open "SELECT * FROM fx_order_mc_det where ((status = '"&ss1&"') or (status = '"&ss2&"')) and hour(timediff(now(),tglorder) >= "&satu&") order by id",conn,3,3
        'mlSQL = "SELECT * FROM fx_order_mc_det where ((status = '" & ss1 & "') or (status = '" & ss2 & "'))" & vbCrLf
        'mlSQL += "And dcinduk Like '" & indukdc & "' and nopos like '" & mypos & "' order by id"
        'mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        'If mlREADER.HasRows Then
        '    mlDATATABLE = New DataTable()
        '    mlDATATABLE.Load(mlREADER)

        '    For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
        '        skr = mlDATATABLE.Rows(aaaeqSSS)("tglorder")
        '        lama = DateDiff("n", skr, Now())
        '        If lama >= 10 Then
        '            mlSQL2 = "Update fx_order_mc_det set status = -9,nosesi = 0 Where where ((status = '" & ss1 & "') or (status = '" & ss2 & "'))"
        '            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

        '            noses = mlDATATABLE.Rows(aaaeqSSS)("nosesi")
        '            mlSQL2 = "SELECT * FROM fax_order_mc_head where nosesi like '" & noses & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
        '            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
        '            mlREADER2.Read()
        '            If mlREADER2.HasRows Then
        '                mlSQL3 = "Update fax_order_mc_head set status = -9,nosesi = 0 Where nosesi like '" & noses & "' and nopos like '" & mypos & "' and dcinduk like '" & indukdc & "'"
        '                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
        '            End If
        '            mlREADER2.Close()
        '        End If
        '    Next
        'End If
        'OnlineBooked
    End Sub

    Protected Sub OnlineBooked()
        '''''''''''''''''''''''''''''''''''''
        ' start online booked
        '''''''''''''''''''''''''''''''''''''
        nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
        Session("nosesifaxmc_pdn") = nosesifaxmc_pdn
        If nosesifaxmc_pdn <> "" Then
            mlSQL = "SELECT count(id) FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "'" & vbCrLf
            mlSQL += "And nopos Like '" & mypos & "' and status like '" & sds & "' and kat like '" & kti & "' group by nosesi"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                jumskr = 0
            Else
                jumskr = CLng(mlREADER("count(id)"))
            End If
            mlREADER.Close()

            mlSQL = "SELECT nopos,tgl,nofax,tipe FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_pdn & "' and dcinduk like '" & indukdc & "'" & vbCrLf
            mlSQL += "And nopos Like '" & mypos & "' and status like '" & sds & "' and kat like '" & kti & "'"
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
        namae = Session("nama_m")
        nokode_mc = Session("nokode_mc")
        nokode_m = Session("nokode_m")
    End Sub


End Class

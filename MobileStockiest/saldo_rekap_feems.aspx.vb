Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_saldo_rekap_feems
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlSQL2 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable

    Public totbelanja_reg, totpv_reg, totbelanja_prd, totpv_prd, totpv, fee_amt, totjual_aktivasi, totjual_produk As Double
    Public bulan, wulpos, tahun, nuhun, sss, kel, pos_area, mypos, loguser, tipe, itung, sort, kelasdc, indukdc, indukmc, wultupo, nuhuntupo As String

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

        PrepareDispay()
    End Sub

    Protected Sub PrepareDispay()
        wulpos = ""
        nuhun = ""
        bulan = wulpos
        tahun = nuhun
        sss = "T"
        kel = "ORG"
        mlSQL = "SELECT sum(tot_amt),sum(tot_pv) FROM bns_feedcmc where nopos like '" & mypos & "'" & vbCrLf
        mlSQL += "And bulan = '" & bulan & "' and tahun = '" & tahun & "' and sta like '" & sss & "' and kel like '" & kel & "' GROUP BY nopos"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totbelanja_reg = 0
            totpv_reg = 0
        Else
            totbelanja_reg = mlREADER("sum(tot_amt)")
            totpv_reg = mlREADER("sum(tot_pv)")
        End If
        mlREADER.Close()

        If IsDBNull(totbelanja_reg) = False Then
            totbelanja_reg = totbelanja_reg
        Else
            totbelanja_reg = 0
        End If


        If IsDBNull(totpv_reg) = False Then
            totpv_reg = totpv_reg
        Else
            totpv_reg = 0
        End If

        kel = "OPD"
        mlSQL = "SELECT sum(tot_amt),sum(tot_pv) FROM bns_feedcmc where nopos like '" & mypos & "'" & vbCrLf
        mlSQL += "And bulan = '" & bulan & "' and tahun = '" & tahun & "' and sta like '" & sss & "' and kel like '" & kel & "' GROUP BY nopos"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totbelanja_prd = 0
            totpv_prd = 0
        Else
            totbelanja_prd = mlREADER("sum(tot_amt)")
            totpv_prd = mlREADER("sum(tot_pv)")
        End If
        mlREADER.Close()

        If IsDBNull(totbelanja_prd) = False Then
            totbelanja_prd = totbelanja_prd
        Else
            totbelanja_prd = 0
        End If
        If IsDBNull(totpv_prd) = False Then
            totpv_prd = totpv_prd
        Else
            totpv_prd = 0
        End If
        totpv = totpv_prd + totpv_reg

        mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmc where nopos like '" & mypos & "' and bulan = '" & bulan & "'" & vbCrLf
        mlSQL += "And tahun = '" & tahun & "' and sta like '" & sss & "' GROUP BY nopos"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            fee_amt = 0
        Else
            fee_amt = mlREADER("sum(fee_amt)")
        End If
        mlREADER.Close()
        If IsDBNull(totbelanja_prd) = False Then
            totbelanja_prd = totbelanja_prd
        Else
            totbelanja_prd = 0
        End If

        If (totbelanja_reg + totbelanja_prd) >= 1000000 Then
            fee_amt = fee_amt
        Else
            fee_amt = 0
        End If

        totjual_aktivasi = 0
        totjual_produk = 0
        mlSQL = "SELECT * FROM bns_feems_rekap where nopos like '" & mypos & "' and bulan = '" & bulan & "' and tahun = '" & tahun & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            mlSQL2 = "Insert into bns_feems_rekap(bulan,tahun,nopos,totbelanja_produk,totbelanja_aktivasi,totjual_produk,totjual_aktivasi,totpv,fee_amtstatus)" & vbCrLf
            mlSQL2 += "values('" & bulan & "','" & tahun & "','" & mypos & "','" & totbelanja_prd & "','" & totbelanja_reg & "','" & totjual_produk & "'" & vbCrLf
            mlSQL2 += ",'" & totjual_aktivasi & "','" & totpv & "','" & fee_amt & "','T')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia						
            mlSQL2 = "UPDATE bns_feems_rekap SET fee_amt = '" & fee_amt & "',totpv = '" & totpv & "'" & vbCrLf
            mlSQL2 += ",totjual_produk = '" & totjual_produk & "',totjual_aktivasi = '" & totjual_aktivasi & "'" & vbCrLf
            mlSQL2 += ",totbelanja_produk = '" & totbelanja_prd & "',totbelanja_aktivasi = '" & totbelanja_reg & "'" & vbCrLf
            mlSQL2 += "WHERE((bulan = " & bulan & ") And (tahun = " & tahun & ") And (nopos Like '" & mypos & "'))"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
        End If
        mlREADER.Close()

        wultupo = ""
        nuhuntupo = ""
        bulan = wultupo
        tahun = nuhuntupo
        sss = "T"
        kel = "ORG"
        mlSQL = "SELECT sum(tot_amt),sum(tot_pv) FROM bns_feedcmc where nopos like '" & mypos & "' and bulan = '" & bulan & "'" & vbCrLf
        mlSQL += "And tahun = '" & tahun & "' and sta like '" & sss & "' and kel like '" & kel & "' GROUP BY nopos"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totbelanja_reg = 0
            totpv_reg = 0
        Else
            totbelanja_reg = mlREADER("sum(tot_amt)")
            totpv_reg = mlREADER("sum(tot_pv)")
        End If
        mlREADER.Close()

        If IsDBNull(totbelanja_reg) = False Then
            totbelanja_reg = totbelanja_reg
        Else
            totbelanja_reg = 0
        End If

        If IsDBNull(totpv_reg) = False Then
            totpv_reg = totpv_reg
        Else
            totpv_reg = 0
        End If

        kel = "OPD"
        mlSQL = "SELECT sum(tot_amt),sum(tot_pv) FROM bns_feedcmc where nopos like '" & mypos & "'" & vbCrLf
        mlSQL += "And bulan = '" & bulan & "' and tahun = '" & tahun & "' and sta like '" & sss & "' and kel like '" & kel & "' GROUP BY nopos"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            totbelanja_prd = 0
            totpv_prd = 0
        Else
            totbelanja_prd = mlREADER("sum(tot_amt)")
            totpv_prd = mlREADER("sum(tot_pv)")
        End If
        mlREADER.Close()

        If IsDBNull(totbelanja_prd) = False Then
            totbelanja_prd = totbelanja_prd
        Else
            totbelanja_prd = 0
        End If
        If IsDBNull(totpv_prd) = False Then
            totpv_prd = totpv_prd
        Else
            totpv_prd = 0
        End If
        totpv = totpv_prd + totpv_reg

        mlSQL = "SELECT sum(fee_amt) FROM bns_feedcmc where nopos like '" & mypos & "' and bulan = '" & bulan & "'" & vbCrLf
        mlSQL += "And tahun = '" & tahun & "' and sta like '" & sss & "' GROUP BY nopos"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            fee_amt = 0
        Else
            fee_amt = mlREADER("sum(fee_amt)")
        End If
        mlREADER.Close()

        If IsDBNull(totbelanja_prd) = False Then
            totbelanja_prd = totbelanja_prd
        Else
            totbelanja_prd = 0
        End If

        If (totbelanja_reg + totbelanja_prd) >= 1000000 Then
            fee_amt = fee_amt
        Else
            fee_amt = 0
        End If

        totjual_aktivasi = 0
        totjual_produk = 0
        mlSQL = "SELECT * FROM bns_feems_rekap where nopos like '" & mypos & "' and bulan = '" & bulan & "' and tahun = '" & tahun & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()

        If Not mlREADER.HasRows Then
            mlSQL2 = "Insert into bns_feems_rekap(bulan,tahun,nopos,totbelanja_produk,totbelanja_aktivasi,totjual_produk,totjual_aktivasi,totpv,fee_amtstatus)" & vbCrLf
            mlSQL2 += "values('" & bulan & "','" & tahun & "','" & mypos & "','" & totbelanja_prd & "','" & totbelanja_reg & "','" & totjual_produk & "'" & vbCrLf
            mlSQL2 += ",'" & totjual_aktivasi & "','" & totpv & "','" & fee_amt & "','T')"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
        Else
            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia						
            mlSQL2 = "UPDATE bns_feems_rekap SET fee_amt = '" & fee_amt & "',totpv = '" & totpv & "'" & vbCrLf
            mlSQL2 += ",totjual_produk = '" & totjual_produk & "',totjual_aktivasi = '" & totjual_aktivasi & "'" & vbCrLf
            mlSQL2 += ",totbelanja_produk = '" & totbelanja_prd & "',totbelanja_aktivasi = '" & totbelanja_reg & "'" & vbCrLf
            mlSQL2 += "WHERE((bulan = " & bulan & ") And (tahun = " & tahun & ") And (nopos Like '" & mypos & "'))"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
        End If
        mlREADER.Close()
    End Sub
End Class

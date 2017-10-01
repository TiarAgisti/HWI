Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_list_stater
    Inherits System.Web.UI.Page

    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlSQL2 As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"
    Dim mlDATATABLE As DataTable

    Dim tgl1, tgl2 As Date
    Dim kasir As String
    Dim g1, g2, g3, tg1, g1a, g1b, g2a, g2b, g3a, tg2 As String
    Dim pos_area, mypos, loguser, kelasdc, indukdc, indukmc, pak, pos As String
    Dim gtotall, gtotbalik As Integer

    Public gtottunai, gtotdebi, gtotkartu, gtotbg, gtotdebit As Integer

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
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        indukmc = Session.Contents("indukmc")
        pak = "T"

        If Session("motok") = "" Or Session("kowe") = "" Or indukdc = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
            Session.Contents("indukmc") = indukmc
        End If

        PrepareAwal()
        PopulateKasir()
    End Sub
    Protected Sub PrepareAwal()
        tgl1 = Request("tgl1")
        tgl2 = Request("tgl2")
        kasir = Request("kasir")

        If kasir = "" Then
            kasir = "semua"
        Else
            kasir = kasir
        End If

        If CStr(tgl1) = "" Then
            tgl1 = Date.Now.AddDays(-30).ToShortDateString()
        Else
            tgl1 = tgl1
        End If

        If CStr(tgl2) = "" Then
            tgl2 = Date.Now
        Else
            tgl2 = tgl2
        End If


        If CStr(tgl1) <> "" And CStr(tgl2) <> "" Then
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

        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
            mlSQL = "SELECT sum(tunai),sum(debit),sum(cc),sum(bg),sum(harga),sum(kembalian) FROM st_sale_daftar" & vbCrLf
            mlSQL += "where nopos Like '" & mypos & "' and ((date(tgl) >= '" & tg1 & "') and (date(tgl) <= '" & tg2 & "')) and pakai like '" & pak & "'"
        Else
            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                mlSQL = "SELECT sum(tunai),sum(debit),sum(cc),sum(bg),sum(harga),sum(kembalian) FROM st_sale_daftar" & vbCrLf
                mlSQL += "where nopos Like '" & mypos & "' and kta like '" & kasir & "' and ((date(tgl) >= '" & tg1 & "') and (date(tgl) <= '" & tg2 & "')) and pakai like '" & pak & "'"
            Else
                mlSQL = "SELECT sum(tunai),sum(debit),sum(cc),sum(bg),sum(harga),sum(kembalian) FROM st_sale_daftar where nopos like '" & mypos&"' and pakai like '"&pak&"'"   
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
        End If

        If mlREADER.HasRows Then
            gtottunai = mlREADER("sum(tunai)")
            gtotkartu = mlREADER("sum(cc)")
            gtotdebit = mlREADER("sum(debit)")
            gtotall = mlREADER("sum(harga)")
            gtotbg = mlREADER("sum(bg)")
            gtotbalik = mlREADER("sum(kembalian)")
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

    Protected Sub PopulateKasir()
        pos = "pos"
        mlSQL = "SELECT kta FROM tabdesc_stockist_user where nopos like '" & mypos & "' and kat like '" & pos & "' order by kta"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlDATATABLE = New DataTable()
            mlDATATABLE.Load(mlREADER)
            Dim strOptions As String = ""
            For aaaeqsK = 1 To mlDATATABLE.Rows.Count - 1
                If kasir = UCase(mlDATATABLE.Rows(aaaeqsK)("kta")) Then
                    strOptions = "<option value=" & mlDATATABLE.Rows(aaaeqsK)("kta") & " selected=" & UCase(mlDATATABLE.Rows(aaaeqsK)("kta")) & "></option>"
                Else
                    strOptions = "<option value=" & mlDATATABLE.Rows(aaaeqsK)("kta") & "></option>"
                End If
            Next
            kasirDropdownList.InnerHtml = strOptions
        End If
    End Sub

End Class

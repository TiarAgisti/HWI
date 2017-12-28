Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_prd_dist_clear
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Dim menu_id, pos_area, mypos, loguser, nosesi, kelasdc, indukdc, indukmc, kode, lanjutposting, lanjutdodol As String
    Dim hariakhir, dino, dinoe, skr As Date
    Dim pvlama, bvlama, jumlama, hargalama, subtotlama, totpv, subtot As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        nosesi = Session("nosesi")
        Session("nosesi") = nosesi
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

        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        kode = Session("nosesi")

        If kode = "" Then
            Session("errorpos") = ""
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)
        End If

        CekValidSession()
    End Sub

    Sub CekValidSession()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' CEK VALID SESSION
        ' CLOSE SESSION INPUT HANYA BISA DILAKUKAN MELALUI KANTOR PUSAT
        ' CLOSE SESSION TIAP AKHIR BULAN PADA TANGGAL 30/31 JAM 19:00:00 WIB
        ' BILA ADA TRANSAKSI PADA TANGGAL 30/31 LEWAT CLOSING TIME, MAKA DITOLAK DAN DIMINTA UNTUK MENGHUBUNGI KANTOR PUSAT
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'lanjutposting = "F"
        'lanjutdodol = "F"
        skr = Now()
        'if tutup1 < skr and tutup2 > skr then
        '	lanjutposting = "F"
        'else
        lanjutposting = "T"
        lanjutdodol = "T"
        'end if

        If lanjutposting = "T" Then

            ''''''''''''''''''''''''''''''''
            ' SAVE TO TEMPORARY TABLE DETAIL
            ''''''''''''''''''''''''''''''''
            mlSQL = "SELECT * FROM st_sale_prd_det_tmp where nosesi like '" & kode & "' and nopos like '" & mypos & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                mlDATATABLE = New DataTable
                mlDATATABLE.Load(mlREADER)
                For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                    pvlama = mlREADER("pv")
                    bvlama = mlREADER("bv")
                    jumlama = mlREADER("jumlah")
                    hargalama = mlREADER("harga")
                    subtotlama = jumlama * hargalama
                Next
            End If
            mlSQL2 = "delete from st_sale_prd_det_tmp where nosesi like '" & kode & "' and nopos like '" & mypos & "'"
            mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER.Close()

            mlSQL = "SELECT * FROM st_sale_prd_head_tmp where nopos like '" & mypos & "' and nosesi like '" & nosesi & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                mlSQL2 = "update st_sale_prd_head_tmp set totpv = 0,totbv = 0,subtot = 0 where nopos like '" & mypos & "' and nosesi like '" & nosesi & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()
            Response.Redirect("sale_prd_dist.aspx?menu_id=" & menu_id)

        Else
            Dim str_Utama As String = ""

            str_Utama += "<div Class='box'>" & vbCrLf
            str_Utama += "<div Class='box-header with-border'>" & vbCrLf
            str_Utama += "<h3 Class='box-title'></h3>" & vbCrLf
            str_Utama += "<div Class='box-tools pull-right'>" & vbCrLf
            str_Utama += "<Button type = 'button' Class='btn btn-box-tool' data-widget='collapse' data-toggle='tooltip' title='Collapse'>" & vbCrLf
            str_Utama += "<i Class='fa fa-minus'></i></button>" & vbCrLf
            str_Utama += "<Button type = 'button' Class='btn btn-box-tool' data-widget='remove' data-toggle='tooltip' title='Remove'>" & vbCrLf
            str_Utama += "<i Class='fa fa-times'></i></button>" & vbCrLf
            str_Utama += "</div>" & vbCrLf
            str_Utama += "</div>" & vbCrLf
            str_Utama += "<div Class='box-body'>" & vbCrLf
            str_Utama += "<p align = 'center' >" & vbCrLf
            str_Utama += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'>" & vbCrLf
            str_Utama += "<br/>" & vbCrLf
            str_Utama += "<br/>" & vbCrLf

            str_Utama += "<p align='center'>" & vbCrLf
            str_Utama += "Maaf saat ini transaksi anda tidak dapat dilakukan karena sudah memasuki <font color='#FF0000'><b>closing period</b></font><br/>" & vbCrLf
            str_Utama += "Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup point bulanan<br/>" & vbCrLf
            str_Utama += "maka silahkan hubungi kantor pusat sesegera mungkin.<br/>" & vbCrLf
            str_Utama += "Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian anda.<br/>" & vbCrLf
            str_Utama += "&lt;-- <a href='sale_prd_dist.aspx?menu_id=<%=session(' menu_id')%>'>Kembali</a> --&gt;" & vbCrLf
            str_Utama += "</div>" & vbCrLf
            str_Utama += "</div>" & vbCrLf

            Div_sale_clear.InnerHtml = str_Utama
        End If
    End Sub
End Class

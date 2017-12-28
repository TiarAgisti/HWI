Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_prd_topup_remove
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim menu_id, pos_area, mypos, loguser, nosesi, kelasdc, indukdc, kode, lanjutposting, lanjutdodol As String
    Dim hariakhir, dino, dinoe, skr As Date
    Dim pvlama, bvlama, jumlama, hargalama, subtotlama, totpv, subtot As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")

        pos_area = Session("pos_area")
        mypos = Session("sotok")
        loguser = Session("anda")
        nosesi = Session("nosesi")
        Session("nosesi") = nosesi
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("sotok") = mypos
            Session("anda") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        dino = Now()
        dinoe = Now.Date
        hariakhir = dino
        kode = Request("id")

        If kode = "" Then
            Session("errorpos") = ""
            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)
        End If

        CekValidSession()
    End Sub

    Sub CekValidSession()
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
            ' EDIT TEMPORARY TABLE DETAIL
            ''''''''''''''''''''''''''''''''
            mlSQL = "SELECT * FROM st_sale_prd_det_tmp where id = '" & kode & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                pvlama = mlREADER("pv")
                bvlama = mlREADER("bv")
                jumlama = mlREADER("jumlah")
                hargalama = mlREADER("harga")
                subtotlama = jumlama * hargalama

                mlSQL2 = "delete from st_sale_prd_det_tmp where id = '" & kode & "'"
                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()

            mlSQL = "SELECT * FROM st_sale_prd_head_tmp where nopos like '" & mypos & "' and nosesi like '" & nosesi & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                totpv = 0
                subtot = 0
            Else
                'rsALL.update
                totpv = mlREADER("totpv") - (pvlama * jumlama)
                'rsALL("totbv") = rsALL("totbv")-(bvlama*jumlama)
                subtot = mlREADER("subtot") - subtotlama
                'rsALL.update										
            End If
            mlREADER.Close()



            Session.LCID = 2057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia

            mlSQL = "UPDATE st_sale_prd_head_tmp SET totpv = '" & totpv & "', subtot = '" & subtot & "' WHERE (nosesi like '" & nosesi & "') and (nopos like '" & mypos & "')"
            mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)

            Session.LCID = 1057 ' setting desimal & local setting untuk indonesia 2057 = uk
            'intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia

            Response.Redirect("mc_prd_topup.aspx?menu_id=" & menu_id)

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

            Div_mc_remove.InnerHtml = str_Utama
        End If
    End Sub
End Class

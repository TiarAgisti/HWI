﻿Imports System
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
            Dim strDiv As String = ""
            strDiv += "<p style='text-align:center;'>"
            strDiv += "<img border='0' src='../images/health-wealthlogo.jpg' width='186' height='125'></p>"
            strDiv += "<p style='text-align:center;font-family:Verdana;'>Maaf saat ini transaksi anda tidak dapat dilakukan karena sudah memasuki<b style='color:#FF0000;'>closing period</b><br>"
            strDiv += "Apabila anda membutuhkan transaksi ini untuk dibukukan kedalam tutup point bulanan <br> maka silahkan hubungi kantor pusat sesegera mungkin.<br>"
            strDiv += "Mohon maaf atas ketidaknyamanan ini dan terima kasih atas pengertian anda.<br>"
            strDiv += "&lt;-- <a href='mc_prd_topup.aspx?menu_id=<%=session('menu_id')%>'>Kembali</a> --&gt;"
            Div_mc_remove.InnerHtml = strDiv
        End If
    End Sub
End Class

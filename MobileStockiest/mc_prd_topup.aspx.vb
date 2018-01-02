Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mc_prd_topup
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlREADERFrontEnd As OleDb.OleDbDataReader
    Protected mlSQLFrontEnd As String
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDATATABLE As DataTable
    Dim mlSQL As String
    Dim mlREADER As OleDb.OleDbDataReader

    Protected mesej, lanjutken, mypos, nosesi, nokode, namadistopup, namadis As String
    Protected tgl, tupoawal, tupoakhir, wulane, nahune, wultupo, nuhuntupo As Date
    Protected jumskr As Integer
    Protected totpv, totbv, gtot, gtotnet, jumdisk, jumtotdis, brapadis, kurangi, jumdis, jumdivc As Double

    Dim dcpusate, pos_area, loguser, tipe, kelasdc, indukdc, indukmc As String
    Dim skritu As Date


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        dcpusate = Session("dcpusate")

        wulane = wultupo
        nahune = nuhuntupo

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        tipe = Request("tipe")
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

        tgl = Now.Date
        skritu = Now()
        lanjutken = "F"
        If UCase(loguser) = "HWIHQ" Then
            lanjutken = "T"
        Else
            If tupoawal < skritu And tupoakhir > skritu Then
                lanjutken = "T"
            Else
                lanjutken = "F"
            End If
        End If

        mesej = Session("errorpos")
        Session("errorpos") = ""
        nosesi = Session("nosesi")
        Session("nosesi") = nosesi

        mlSQL = "SELECT count(id) FROM st_sale_prd_det_tmp where nosesi like '" & nosesi & "' and nopos like '" & mypos & "' group by nosesi"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            jumskr = 0
        Else
            jumskr = CInt(mlREADER("count(id)"))
        End If
        mlREADER.Close()

    End Sub
End Class

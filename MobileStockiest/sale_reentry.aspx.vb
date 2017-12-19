﻿Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_reentry
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlREADER As OleDb.OleDbDataReader
    Protected mlSQL As String
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDATATABLE As DataTable

    Dim pos_area, kelasdc, indukdc, indukmc As String
    Protected minimal As Double

    Protected mesej, pp, kds, ddd, loguser, dcpusate, mypos, namatabel, namatabel2 As String
    Protected tgl, hariakhir, tutup1, tutup2 As Date
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        dcpusate = Session("dcpusate")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
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
        mesej = Session("errorpos")
        Session("errorpos") = ""



        namatabel = "st_barang_ms"
        namatabel2 = "st_kartustock_ms"
        minimal = 1
    End Sub

End Class

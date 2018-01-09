Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_stater_ms4
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlREADER As OleDb.OleDbDataReader
    Protected mlSQL As String
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDATATABLE As DataTable

    Dim pos_area, kelasdc, indukdc, namatabel2, dcpusat As String

    Public mesej, pp, ste, mypos, dcpusate, loguser, namatabel, aloc As String
    Public tgl, hariakhir, tutup1, tutup2 As Date
    Public minimal As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        dcpusate = Session("dcpusate")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        tgl = Now()
        mesej = Session("errorpos")
        Session("errorpos") = ""



        If UCase(mypos) = dcpusat Then
            namatabel = "st_barang"
            namatabel2 = "st_kartustock"
            minimal = 0
        Else
            namatabel = "st_barang_ms"
            namatabel2 = "st_kartustock_ms"
            minimal = 1
        End If
    End Sub
End Class

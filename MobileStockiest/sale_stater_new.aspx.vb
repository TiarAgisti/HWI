Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_stater_new
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlREADER As OleDb.OleDbDataReader
    Protected mlREADER2 As OleDb.OleDbDataReader
    Protected mlSQL, mlSQL2, mlSQL3 As String
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDATATABLE As DataTable

    Protected mesej, tgl, aloc, pp, ste, mypos, dcpusate, loguser, namatabel, kode As String
    Protected minimal As Double
    Protected hariakhir, tutup1, tutup2 As Date

    Dim pos_area, kelasdc, indukdc, dcpusat, namatabel2 As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        dcpusate = Session("dcpusate")

        mlOBJGS.Main()
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

        tgl = Now.Date
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

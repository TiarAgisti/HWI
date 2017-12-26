Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_prd_dist
    Inherits System.Web.UI.Page

    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlREADER As OleDb.OleDbDataReader
    Protected mlSQL As String
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDATATABLE As DataTable

    Protected tgl, hariakhir, tutup1, tutup2, skritu, tupoawal, tupoakhir As Date
    Protected mesej, lanjutkens, dcpusate, pos_area, mypos, loguser, tipe, kelasdc, indukdc, indukmc, nosesi, nofax, nokode, namadis As String
    Protected jumskr, wulpos, nuhun As Integer
    Protected totpv, totbv, gtot, gtotnet, jumdisk, jumtotdis, brapadis, kurangi, jumdis, jumdivc As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        dcpusate = Session("dcpusate")

        Session("autoupe") = ""
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

        skritu = Now()
        If skritu >= tupoawal And skritu <= tupoakhir Then
            lanjutkens = "F" ' harusnya F
        Else
            lanjutkens = "T"
        End If


    End Sub
End Class

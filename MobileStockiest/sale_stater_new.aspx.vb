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

    Protected mesej, tgl, aloc, pp, ste, mypos, dcpusate, loguser, namatabel As String
    Protected minimal As Double
    Protected hariakhir, tutup1, tutup2 As Date

    Dim pos_area, kelasdc, indukdc, dcpusat, namatabel2, kode As String

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

        Dim str_option As String = ""
        str_option = "<select class='form-control' name='paket' id='paket' onChange='javascript:cari(this)' onKeyDown='If(Event.keyCode==13) Event.keyCode=9;'>"
        str_option += "<optgroup label='paket pendaftaran'>" & vbCrLf
        str_option += "<option value='--Silahkan Pilih--' selected="">--Silahkan Pilih--</option>"



        pp = "AKT"
        ste = "T"
        minimal = 1
        mlSQL = "SELECT * FROM healthwealthint_com_hwi.st_tipe_paket_new where tipe not like 'upms'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows = True Then
            mlDATATABLE = New DataTable
            mlDATATABLE.Load(mlREADER)
            For aaaeqsK = 1 To mlDATATABLE.Rows.Count - 1
                kode = mlDATATABLE.Rows(aaaeqsK)("kode")
                If mypos <> dcpusate Then
                    mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and jumlah >= '" & minimal & "' and ( kode like '" & kode & "')"
                Else
                    mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and sta like '" & ste & "' and ( kode like '" & kode & "' )"
                End If
                mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
                mlREADER2.Read()
                If Not mlREADER2.HasRows Then
                Else
                    str_option += "<option value='" & UCase(mlDATATABLE.Rows(aaaeqsK)("kode")) & "'>" & mlDATATABLE.Rows(aaaeqsK)("kode") & "</option> " & vbCrLf
                End If
                mlREADER2.Close()
            Next
        End If
        mlREADER.Close()
        str_option += "</optgroup>"
        str_option += "</select>"
        div_pendaftaran.InnerHtml = str_option
    End Sub
End Class

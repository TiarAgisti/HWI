Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_stater
    Inherits System.Web.UI.Page
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected mlREADER As OleDb.OleDbDataReader
    Protected mlSQL As String
    Protected mpMODULEID As String = "PB"
    Protected mlCOMPANYID As String = "ALL"
    Protected mlDATATABLE As DataTable

    Protected mesej, tgl, aloc, pp, ste, mypos, dcpusate, loguser, namatabel As String
    Protected minimal As Double
    Protected hariakhir, tutup1, tutup2 As Date

    Dim pos_area, kelasdc, indukdc, indukmc, namatabel2 As String

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

        tgl = Now()
        mesej = Session("errorpos")
        Session("errorpos") = ""


        namatabel = "st_barang_ms"
        namatabel2 = "st_kartustock_ms"
        minimal = 1

        Dim str_option As String = ""
        str_option = "<select class='form-control' name='paket' id='paket' onChange='javascript:cari(this)' onKeyDown='if(event.keyCode==13) event.keyCode=9;'>"
        str_option += "<optgroup label='paket pendaftaran'>" & vbCrLf
        str_option += "<option value='--Silahkan Pilih--' selected="">--Silahkan Pilih--</option>"
        pp = "AKT"
        ste = "T"
        minimal = 1
        If mypos <> dcpusate Then
            If LCase(loguser) = "kris" Then
                mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "'" & vbCrLf
                mlSQL += "And jumlah >= '" & minimal & "' and kode <> 'ms500' and kode <> 'ms500-14' and kode <> 'ms400-14' and kode <> 'ms200-14'" & vbCrLf
                mlSQL += "And kode Not Like 'ms200%' and kode <> 'ms500V-14'"
            Else
                mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "'" & vbCrLf
                mlSQL += "And jumlah >= '" & minimal & "' and sta like '" & ste & "' and kode <> 'ms500' and kode <> 'ms500-14'" & vbCrLf
                mlSQL += "And kode <> 'ms200-14' and kode not like 'ms200%' and kode <> 'ms400-14' and kode <> 'ms500V-14'"
            End If
        Else
            If LCase(loguser) = "kris" Then
                mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "'" & vbCrLf
                mlSQL += "And kode <> 'ms500' and kode <> 'ms500-14' and kode <> 'ms400-14' and kode <> 'ms200-14' and kode not like 'ms200%'" & vbCrLf
                mlSQL += "And kode <> 'ms500V-14'"
            Else
                mlSQL = "SELECT kode,nama FROM " & namatabel & " WHERE nopos like '" & mypos & "' and grp like '" & pp & "'" & vbCrLf
                mlSQL += "And sta like '" & ste & "' and kode <> 'ms500' and kode <> 'ms500-14' and kode <> 'ms200-14'" & vbCrLf
                mlSQL += "And kode not like 'ms200%' and kode <> 'ms400-14' and kode <> 'ms500V-14'"
            End If
        End If
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If mlREADER.HasRows = True Then
            mlDATATABLE = New Data.DataTable()
            mlDATATABLE.Load(mlREADER)
            For aaaeqSSS = 1 To mlDATATABLE.Rows.Count - 1
                str_option += " <option value=" & mlDATATABLE.Rows(aaaeqSSS)("kode") & ">" & mlDATATABLE.Rows(aaaeqSSS)("nama") & "></option>" & vbCrLf
            Next
        End If
        mlREADER.Close()
        str_option += "</optgroup>"
        str_option += "</select>"
        div_paket.InnerHtml = str_option
    End Sub
End Class

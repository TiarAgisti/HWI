Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_ms4_perdana_clear
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2, mlSQL3 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As DataTable

    Dim menu_id, mypos, nodc, loguser, kelasdc, indukdc, kti, asal, kemana, nosesifaxmc_pdn, kode, pos_area, nosesifaxmc_akt As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")
        pos_area = Session("pos_area")
        mypos = UCase(Session("motok"))
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
        nosesifaxmc_akt = Session("nosesifaxmc_akt")
        nodc = UCase(Session("motok"))
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        asal = Request("grp")
        kti = Session("kti")

        If asal = "PRD" Then
            kemana = "ms4_perdana.aspx?menu_id=" & menu_id
        Else
            kemana = "ms_order_register.aspx?menu_id=" & menu_id
        End If

        ''''''''''''''''''''''''''''''''
        ' SAVE TO TEMPORARY TABLE DETAIL
        ''''''''''''''''''''''''''''''''
        If asal = "PRD" Then
            kode = Session("nosesifaxmc_pdn")
            If kode = "" Then
                Session("errorfax") = "Session fax order sudah expired"
                Response.Redirect(kemana)
            End If

            mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi Like '" & nosesifaxmc_pdn & "'" & vbCrLf
            mlSQL2 += "And nopos Like '" & mypos & "' and dcinduk like '" & indukdc & "' and kat like '" & kti & "'"
            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER2.Read()

            mlSQL = "SELECT * FROM fax_order_mc_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "'" & vbCrLf
            mlSQL += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If mlREADER.HasRows Then
                mlSQL3 = "Update fax_order_mc_head set nofax = '-',nomc = '-',nopos = '-',totpv = 0, subtot = 0, diskon = 0, potongan = 0, gtot = 0, tipe = '-',status = -1" & vbCrLf
                mlSQL3 += "where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_pdn & "' And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER.Close()
            Session("nosesifaxmc_pdn") = ""
        End If
        mlREADER2.Close()

        If asal = "AKT" Then
            kode = Session("nosesifaxmc_akt")
            If kode = "" Then
                Session("errorfax") = "Session fax order sudah expired"
                Response.Redirect(kemana)
            End If
            ''''''''''''''''''''''''''''''''
            ' EDIT TEMPORARY TABLE DETAIL
            ''''''''''''''''''''''''''''''''
            mlSQL2 = "SELECT * FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
            mlSQL2 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
            'mlREADER2.Read()
            If mlREADER2.HasRows Then
                mlSQL3 = "Delete FROM fx_order_mc_det where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
                mlSQL3 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER2.Close()

            mlSQL2 = "SELECT * FROM fax_order_mc_paket_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_akt & "'" & vbCrLf
            mlSQL2 += "dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER2.Read()
            If mlREADER2.HasRows Then
                mlSQL3 = "Delete From fax_order_mc_paket_head where nopos like '" & mypos & "' and nosesi like '" & nosesifaxmc_akt & "'" & vbCrLf
                mlSQL3 += "dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
            End If
            mlREADER2.Close()

            mlSQL2 = "SELECT * FROM fax_order_mc_head where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
            mlSQL2 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
            mlREADER2 = mlOBJGS.DbRecordset(mlSQL2, mpMODULEID, mlCOMPANYID)
            mlREADER2.Read()
            If mlREADER2.HasRows Then
                mlSQL3 = "Delete From fax_order_mc_head where nosesi like '" & nosesifaxmc_akt & "'  and nopos like '" & mypos & "'" & vbCrLf
                mlSQL3 += "And dcinduk Like '" & indukdc & "' and kat like '" & kti & "'"
                mlOBJGS.ExecuteQuery(mlSQL3, mpMODULEID, mlCOMPANYID)
            End If
            Session("nosesifaxmc_akt") = ""
        End If

        Session("pos_area") = ""
        Session("errorfax") = ""
        Session("namadis_mc") = ""
        Session("nokode_mc") = ""
        Response.Redirect(kemana)
    End Sub
End Class

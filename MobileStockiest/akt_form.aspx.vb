Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_akt_form
    Inherits System.Web.UI.Page
    Dim mlOBJGF As New IASClass.ucmGeneralFunction
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"

    Dim sort, pos_area, loguser, psa, l23, l26, l25, ada, uprane As String
    Dim subalo As Double

    Protected mlQuery, mlQuery2 As String
    Protected mlDR, mlDR2 As OleDb.OleDbDataReader
    Protected mlDT As DataTable
    Protected mlOBJGS As New IASClass.ucmGeneralSystem
    Protected noinvo, noser, error1, paket, error2, error3, nama, error6, error7, pp, error8, error9, error10, error11, prop_dc, error12, error13, error14, direk, namadirek As String
    Protected error15, error16, error17, error18, error19, error20, error21, error22, error23, error24, error25, error26, error27, error28, error29, error30, error31, error32, error33 As String
    Protected jumbc As Double
    Protected blnskr, kl, thnskr, minimal As Integer
    Protected telpdirek, kakiku, kaki, alok, aloc, namaalo, notelpalo, mypos, namamu, alamatdis, kotadis, kodeposdis, telpdis, faxdis, emaildis As String

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        noinvo = Session("noinvo_akt")
        If Session("menu_id") <> "" Then
            Session("menu_id") = Session("menu_id")
        Else
            Session("menu_id") = Request("menu_id")
        End If

        sort = Request("sort")
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        PrepareData()
    End Sub

    Sub PrepareData()
        noinvo = Session("noinvo_akt")
        If noinvo <> "" Then
            mlSQL = "SELECT noseri,nama,paket,jumbc,idplc,direk,subalo,kaki FROM st_sale_daftar where nopos like '" & mypos & "' and noslip like '" & noinvo & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                noser = ""
                nama = ""
                paket = "--Silahkan Pilih--"
                jumbc = 0
                alok = ""
                subalo = ""
                psa = ""
                direk = ""
            Else
                noser = mlREADER("noseri")
                nama = mlREADER("nama")
                paket = mlREADER("paket")
                jumbc = mlREADER("jumbc")
                alok = mlREADER("idplc")
                subalo = mlREADER("subalo")
                psa = mlREADER("kaki")
                direk = mlREADER("direk")
            End If
            mlREADER.Close()
        End If


        mlSQL = "SELECT kta,uid,telp,upme FROM member WHERE kta LIKE '" & direk & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            error23 = "Nomor id distributor direct sponsor tidak ditemukan"
            l23 = "Mbuh"
            namadirek = ""
            telpdirek = ""
        Else
            l23 = "Ter23"
            error23 = ""
            namadirek = mlREADER("uid")
            telpdirek = mlREADER("telp")
        End If
        mlREADER.Close()

        mlSQL = "SELECT kta,uid,telp,upme FROM member WHERE kta LIKE '" & alok & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            error26 = "Nomor id distributor upline placement tidak ditemukan"
            l26 = "Mbuh"
            aloc = ""
            namaalo = ""
            notelpalo = ""
            subalo = ""
            psa = ""
            uprane = "F"
            ada = "F"
        Else
            l26 = "Ter26"
            error26 = ""
            aloc = mlREADER("kta")
            namaalo = mlREADER("uid")
            notelpalo = mlREADER("telp")
            error25 = ""
            l25 = "Ter25"
            'uprane = rs("upme")
            uprane = "F"
            ada = "T"
        End If
        mlREADER.Close()

        If psa = "L" Then
            kakiku = "L"
            kaki = "Kiri"
        Else
            kakiku = "R"
            kaki = "Kanan"
        End If
    End Sub
End Class

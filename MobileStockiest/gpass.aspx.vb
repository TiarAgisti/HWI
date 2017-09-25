Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_gpass
    Inherits System.Web.UI.Page

    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction
    Dim mlOBJPJ As New FunctionLocal

    Dim mlFHWI As New FunctionHWI

    ' Default Variable
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlKEY As String
    Dim mlKEY2 As String
    Dim mlKEY3 As String
    Dim mlRECORDSTATUS As String
    Dim mlSPTYPE As String
    Dim mlFUNCTIONPARAMETER As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"

    Public mypos, namauser, loguser, error2, pos_area, tipe, itung, sort, error1, error3 As String
    Dim baru, koni, pase, l1, l2, l3 As String


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")

        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        tipe = Request("tipe")
        itung = Request("itung")
        sort = Request("sort")

        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        error1 = Session("error1")
        error2 = Session("error2")
        error3 = Session("error3")
        Session("error1") = ""
        Session("error2") = ""
        Session("error3") = ""
    End Sub
    Protected Sub GpassAction()
        'mlOBJGS.Main()

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


        baru = Request("baru")
        koni = Request("konfirmasi")
        pase = Request("password")

        If baru = "" Then
            l1 = "Mbuh"
            Session("error1") = "Anda belum mengisi password baru"
            Response.Redirect("gpass.aspx")
        Else
            If Len(baru) >= 31 Then
                Session("error1") = "Password baru maksimal 30 karakter"
                l1 = "Mbuh"
                Response.Redirect("gpass.aspx")
            Else
                If ((Len(baru) <= 31) And (baru <> "")) Then
                    l1 = "Ter1"
                    error1 = ""
                End If
            End If
        End If

        If koni = "" Then
            l2 = "Mbuh"
            Session("error2") = "Anda belum menulis ulang password baru"
            Response.Redirect("gpass.aspx")
        Else
            If Len(koni) >= 31 Then
                Session("error2") = "Tulis ulang password baru maksimal 30 karakter"
                l2 = "Mbuh"
                Response.Redirect("gpass.aspx")
            Else
                If ((Len(koni) <= 31) And (koni <> "")) Then
                    If koni <> baru Then
                        Session("error2") = "Password baru dan tulis ulang password baru tidak sama"
                        l2 = "Mbuh"
                        Response.Redirect("gpass.aspx")
                    Else
                        l2 = "Ter2"
                        error2 = ""
                    End If
                End If
            End If
        End If

        If pase = "" Then
            l3 = "Mbuh"
            Session("error3") = "Anda belum mengisi password login anda saat ini"
            Response.Redirect("gpass.aspx")
        Else
            If Len(pase) >= 31 Then
                Session("error3") = "Password login maksimal 30 karakter"
                l3 = "Mbuh"
                Response.Redirect("gpass.aspx")
            Else
                If ((Len(pase) <= 31) And (pase <> "")) Then
                    l3 = "Ter3"
                    error3 = ""
                End If
            End If
        End If

        Dim mbok As String
        If l1 = "Ter1" And l2 = "Ter2" And l3 = "Ter3" Then
            mlSQL = "SELECT * FROM tabdesc_stockist_user WHERE nopos like '" & mypos & "' and kta like '" & loguser & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If Not mlREADER.HasRows Then
                mlREADER.Close()
                mlREADER = Nothing
                Session("out") = "Session login anda sudah expired, silahkan login kembali"
                Response.Redirect("login.aspx")
            Else
                mlREADER.Read()
                mbok = mlREADER("gembok")
                If mbok = pase Then
                    mlSQL2 = "update tabdesc_stockist_user" & vbCrLf
                    mlSQL2 += "Set gembok = '" & baru & "'" & vbCrLf
                    mlSQL2 += "WHERE nopos='" & mypos & "' and kta='" & loguser & "'" & vbCrLf
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                Else
                    mlREADER.Close()
                    mlREADER = Nothing
                    Session("error3") = "Password login anda salah !"
                    Response.Redirect("gpass.aspx")
                End If
            End If
        End If
    End Sub
    Protected Sub Gpass_Click(sender As Object, e As EventArgs)
        GpassAction()
    End Sub
End Class

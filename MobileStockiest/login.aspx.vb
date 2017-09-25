Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_login
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

    Dim galgale As Date
    Dim error1, error1a, error2, error3, error4, mesej, uid, uname, lanjut1, stadc, lanjut3, lanjut2, bok, kowe, zurinx, z1, z2, z3, z4, z5 As String
    Dim nLength, nNumber As Integer
    Dim tglmukui, blnmukui, thnmukui As Long
    Dim pas, gem, turba, sopo, sopoloe, pasku, nosek, passna As String
    Dim beruk As Object
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        mlOBJGS.Main()



        Response.Buffer = True
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.ExpiresAbsolute = Now.AddDays(-1)

        error1 = Session("error1")
        error1a = Session("error1a")
        error2 = Session("error2")
        error3 = Session("error3")
        error4 = Session("error4")
        mesej = Session("out")
        uid = Session("uid")
        uname = Session("uname")
        Session("error1") = ""
        Session("error1a") = ""
        Session("error2") = ""
        Session("error3") = ""
        Session("error4") = ""
        Session("uid") = ""
        Session("out") = ""

        If Not Page.IsPostBack Then
            pg_turing()
        End If
    End Sub

    Protected Sub pg_turing()

        zurinx = Password_GenPass2(5, "")

        z1 = Mid(zurinx, 1, 1)
        z2 = Mid(zurinx, 2, 1)
        z3 = Mid(zurinx, 3, 1)
        z4 = Mid(zurinx, 4, 1)
        z5 = Mid(zurinx, 5, 1)
        Session("buring") = zurinx

        Dim strTuring As String = ""
        strTuring = "<b>" & vbCrLf
        strTuring += "<font color='#FFD16F' size='5px'>" & z1 & "</font>" & vbCrLf
        strTuring += "<font color='#00FFFF' size='5px'>" & z2 & "</font>" & vbCrLf
        strTuring += "<font color='#ffgg00' size='5px'>" & z3 & "</font>" & vbCrLf
        strTuring += "<font color='#ffcc00' size='5px'>" & z4 & "</font>" & vbCrLf
        strTuring += "<font color='#FF66CC' size='5px'>" & z5 & "</font></b>" & vbCrLf


        div_turing.InnerHtml = strTuring

    End Sub
    Function Password_GenPass2(nNoChars As String, sValidChars As String) As String
        Dim sRet As String = ""

        Const szDefault = "632HJKM91WXYZabcde84pqr75ABGNPQRSTUVfghijkmnstCDEFuvwxyz"

        Randomize() 'init random

        If sValidChars = "" Then
            sValidChars = szDefault
        End If
        nLength = Len(sValidChars)

        For nCount As Integer = 1 To nNoChars
            nNumber = Int((nLength * Rnd()) + 1)
            sRet = sRet & Mid(sValidChars, nNumber, 1)
        Next
        Password_GenPass2 = sRet
    End Function

    Protected Sub Login_Click(sender As Object, e As EventArgs)
        LoginAction()
    End Sub
    Protected Sub LoginAction()
        Response.Buffer = True

        'The following three lines of code are used to ensure that this page is not cached on the client.
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1

        Session.Contents("motok") = ""
        Session.Contents("kowe") = ""
        Session.Contents("menu_bagpos") = ""
        Session.Contents("menu_id") = ""
        Session.Contents("pos_area") = ""
        Session.Contents("indukdc") = ""
        Session.Contents("kelasdc") = ""
        Session.Contents("indukmc") = ""
        Session("error1") = ""
        Session("error1a") = ""
        Session("error2") = ""
        Session("error3") = ""
        Session("asal") = ""
        Session("uid") = ""
        Session("uname") = ""
        Session("out") = ""
        Session("nosesi") = ""
        Session("noinvo") = ""

        galgale = Today
        tglmukui = CLng(Day(galgale))
        blnmukui = CLng(Month(galgale))
        thnmukui = CLng(Year(galgale))

        'uid = Trim(mlFHWI.SafeSQL(UCase(Request("id"))))
        'uname = Trim(mlFHWI.SafeSQL(UCase(Request("username"))))
        'pas = Trim(mlFHWI.SafeSQL(UCase(Request("password"))))
        'Session("uid") = Trim(Request("id"))
        'Session("uname") = Trim(Request("username"))
        'gem = Trim(Request("password"))
        'nosek = mlFHWI.SafeSQL(UCase(Request("turing")))
        'Session("uid") = uid
        'turba = Trim(Request("turing"))
        'beruk = Session("buring")

        uid = Trim(mlFHWI.SafeSQL(UCase(Request("id"))))
        uname = Trim(mlFHWI.SafeSQL(UCase(Request("username"))))
        pas = Trim(mlFHWI.SafeSQL(UCase(Request("password"))))
        Session("uid") = Trim(Request("id"))
        Session("uname") = Trim(Request("username"))
        gem = Trim(Request("password"))
        turba = Trim(Request("turing"))
        beruk = Session("buring")

        If turba = "" Then
            Session("error1") = "Mohon isikan Turing Number"
            Session("error1a") = ""
            Session("error2") = ""
            Session("error3") = ""
            sopo = "-"
            Response.Redirect("login.aspx")
        Else
            If turba <> beruk Then
                Session("error1") = "Turing Number yang anda isi salah"
                Session("error1a") = ""
                Session("error2") = ""
                Session("error3") = ""
                sopo = "-"
                Response.Redirect("login.aspx")
            End If
        End If

        If uid = "" Then
            Session("error1") = "Mohon isikan Mobile Center id. anda"
            Session("error1a") = ""
            Session("error2") = ""
            Session("error3") = ""
            sopo = "-"
            Response.Redirect("login.aspx")
        Else
            sopo = Trim(Request("id"))
        End If

        If uname = "" Then
            Session("error1a") = "Mohon isikan username anda"
            Session("error1") = ""
            Session("error2") = ""
            Session("error3") = ""
            sopoloe = "-"
            Response.Redirect("login.aspx")
        Else
            sopoloe = Trim(Request("username"))
        End If

        If pas = "" Then
            Session("error2") = "Mohon isikan password login anda"
            Session("error1") = ""
            Session("error1a") = ""
            Session("error3") = ""
            pasku = "-"
            Response.Redirect("login.aspx")
        Else
            pasku = Trim(Request("password"))
        End If 'migrasi sampe sini

        lanjut1 = "F"
        stadc = "F"
        lanjut3 = "F"

        mlSQL = "SELECT nopos,induk,kelas,sta,indukmc FROM tabdesc_stockist WHERE nopos like '" & sopo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        If Not mlREADER.HasRows Then
            lanjut1 = "F"
            Session("error1") = "Mobile Center Id. tidak ditemukan"
            Session.Contents("indukdc") = ""
            Session.Contents("kelasdc") = ""
            Session.Contents("indukmc") = ""
            stadc = "F"
        Else
            mlREADER.Read()
            Session.Contents("indukdc") = mlREADER("induk")
            Session.Contents("kelasdc") = mlREADER("kelas")
            Session.Contents("indukmc") = mlREADER("indukmc")
            lanjut1 = "T"
            Session("error1") = ""
            stadc = mlREADER("sta")
            If mlREADER("kelas") = "N" Then
                lanjut3 = "T"
                Session("error1") = ""
            Else
                lanjut3 = "F"
                Session("error1") = "Mobile Center Id. tidak ditemukan"
                Session.Contents("indukdc") = ""
                Session.Contents("kelasdc") = ""
                Session.Contents("indukmc") = ""
            End If
        End If
        mlREADER.Close()

        mlSQL = "SELECT nopos FROM tabdesc_stockist_user WHERE nopos like '" & sopo & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        If Not mlREADER.HasRows Then
            lanjut1 = "F"
            Session("error1") = "Mobile Center Id. tidak ditemukan"
            Session.Contents("indukdc") = ""
            Session.Contents("kelasdc") = ""
            Session.Contents("indukmc") = ""
        Else
            lanjut1 = "T"
            Session("error1") = ""
        End If
        mlREADER.Close()

        If lanjut1 = "T" Then
            mlSQL = "SELECT * FROM tabdesc_stockist_user WHERE nopos like '" & sopo & "' and kta like '" & sopoloe & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

            If Not mlREADER.HasRows Then
                lanjut2 = "F"
                Session("error1a") = "Username tidak ditemukan"
            Else
                mlREADER.Read()
                bok = mlREADER("gembok")
                kowe = UCase(mlREADER("kat"))
                passna = mlREADER("pass")

                If bok = pasku Then
                    If stadc = "T" Then
                        lanjut2 = "T"

                        mlSQL2 = "update  tabdesc_stockist_user " & vbCrLf
                        mlSQL2 += "Set lastip = '" & mlREADER("loginip") & "'," & vbCrLf
                        mlSQL2 += "    lastlog = '" & mlREADER("logindt") & "', " & vbCrLf
                        mlSQL2 += "    loginip = '" & Request.ServerVariables("remote_addr") & "', " & vbCrLf
                        mlSQL2 += "    logindt = '" & Today & "', " & vbCrLf
                        mlSQL2 += "    logke = " & CInt(mlREADER("logke")) + 1 & vbCrLf
                        mlSQL2 += "WHERE nopos Like '" & sopo & "' and kta like '" & sopoloe & "'" & vbCrLf
                        mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                        Session.Contents("motok") = mlREADER("nopos")
                        Session.Contents("kowe") = mlREADER("kta")
                        Session.Contents("menu_bagpos") = "MC"
                        Session.Contents("menu_id") = 1
                        Session.Contents("sotok") = ""
                        Session.Contents("anda") = ""
                    Else
                        If stadc <> "T" Then
                            If kowe = "PST" Then
                                lanjut2 = "T"

                                mlSQL2 = "update  tabdesc_stockist_user " & vbCrLf
                                mlSQL2 += "Set lastip = '" & mlREADER("loginip") & "'," & vbCrLf
                                mlSQL2 += "    lastlog = '" & mlREADER("logindt") & "', " & vbCrLf
                                mlSQL2 += "    loginip = '" & Request.ServerVariables("remote_addr") & "', " & vbCrLf
                                mlSQL2 += "    logindt = '" & Today & "', " & vbCrLf
                                mlSQL2 += "    logke = " & CInt(mlREADER("logke")) + 1
                                mlSQL2 += "WHERE nopos like '" & sopo & "' and kta like '" & sopoloe & "'" & vbCrLf
                                mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)

                                Session.Contents("motok") = mlREADER("nopos")
                                Session.Contents("kowe") = mlREADER("kta")
                                Session.Contents("menu_bagpos") = "MC"
                                Session.Contents("menu_id") = 1
                                Session.Contents("sotok") = ""
                                Session.Contents("anda") = ""
                            Else
                                lanjut2 = "F"
                                Session("error1") = "MOBILE CENTER ACCOUNT SUSPEND, SILAHKAN HUBUNGI KANTOR PUSAT"
                                Session.Contents("motok") = ""
                                Session.Contents("kowe") = ""
                                Session.Contents("menu_bagpos") = ""
                                Session.Contents("menu_id") = ""
                                Session.Contents("indukdc") = ""
                                Session.Contents("kelasdc") = ""
                                Session.Contents("indukmc") = ""
                                Session.Contents("sotok") = ""
                                Session.Contents("anda") = ""
                            End If
                        End If
                    End If 'sampe sini
                Else
                    lanjut2 = "F"
                    Session("error2") = "Password login anda salah !"
                    Session.Contents("motok") = ""
                    Session.Contents("kowe") = ""
                    Session.Contents("menu_bagpos") = ""
                    Session.Contents("menu_id") = ""
                    Session.Contents("indukdc") = ""
                    Session.Contents("kelasdc") = ""
                    Session.Contents("indukmc") = ""
                    Session.Contents("sotok") = ""
                    Session.Contents("anda") = ""
                End If
            End If
        End If
        mlREADER.Close()

        If lanjut1 = "T" And lanjut2 = "T" And lanjut3 = "T" Then
            Session("error1") = ""
            Session("error1a") = ""
            Session("error2") = ""
            Session("error3") = ""
            Session("asal") = ""
            Session("uid") = ""
            Session("uname") = ""
            Session.Contents("sotok") = ""
            Session.Contents("anda") = ""

            If passna = "F" Then
                Session("changepass") = "T"
                Response.Redirect("changepass.aspx")
            Else
                Response.Redirect("home.aspx?menu_id=" & Session("menu_id"))
            End If
        Else
            Response.Redirect("login.aspx")
        End If
    End Sub

End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_bataltemp
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSQL2 As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlDATATABLE As New DataTable
    Dim mlDATATABLEDETAIL As New DataTable
    Public piye As String

    Dim mlKEY As String
    Dim mlRECORDSTATUS As String
    Dim mypos, loguser, kelasdc, indukdc, mbuh, pakai, menu_id, dcHO As String
    Protected tgl As String
    Protected ada, lanjut, noseri, nama, paket, nopos, kasir, hasil, noid As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Session("tema") = "home"
        mypos = Session("motok")
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        Session("menu_id") = Request("menu_id")
        If Session("motok") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If
    End Sub
    Sub SaveData()
        piye = Session("hasil")
        Session("hasil") = ""

        lanjut = "F"
        noid = Trim(txtnoseri.Value)
        If noid = "" Then
            lanjut = "F"
        Else
            lanjut = "T"
            mlSQL = "SELECT * FROM st_sale_daftar WHERE noseri like '" & noid & "' and nopos like '" & mypos & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If Not mlREADER.HasRows Then
                mbuh = "T"
            Else
                mbuh = "F"
                noseri = mlREADER("noseri")
                nama = mlREADER("nama")
                kasir = mlREADER("kta")
                nopos = mlREADER("nopos")
                tgl = mlREADER("tgl")
                paket = mlREADER("paket")
                pakai = mlREADER("pakai")
                Session("hasil") = ""
            End If
            mlREADER.Close()

            'if terusken = "T" then
            mlSQL = "SELECT kta,uid,dc_asal,joindt,tipene_kartu FROM member WHERE kta like '" & noid & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If Not mlREADER.HasRows Then
                If pakai = "T" Or pakai = "F" Then
                    hasil = "Nomor seri / distributor dapat dibatalkan, silahkan lakukan PEMBATALAN PADA TEMPORARY"
                    ada = "F"
                Else
                    If mbuh = "T" Then
                        hasil = "Pembatalan hanya dapat dilakukan oleh DC yang melakukan pendaftaran"
                    Else
                        hasil = "Nomor seri / distributor belum pernah didaftarkan, silahkan lakukan pendaftaran"
                    End If
                    ada = "F"
                    noseri = noid
                    nama = "NOT FOUND"
                    kasir = "NOT FOUND"
                    nopos = "NOT FOUND"
                    tgl = "NOT FOUND"
                    paket = "NOT FOUND"
                    pakai = "NOT FOUND"
                End If
            Else
                ada = "T"
                hasil = "Nomor seri / distributor sudah aktif, proses pembatalan temporary tidak dapat dilakukan !!!"
                noseri = mlREADER("kta")
                nama = mlREADER("uid")
                kasir = mlREADER("kta")
                nopos = mlREADER("dc_asal")
                tgl = mlREADER("joindt")
                paket = ""
            End If
            mlREADER.Close()
            'end if		
        End If
    End Sub
    Sub batalnow()
        Session("tema") = "home"
        mypos = Session("motok")
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        Session("menu_id") = Request("menu_id")
        menu_id = Session("menu_id")
        If Session("motok") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        noid = Trim(Request("noseri"))
        lanjut = "F"
        If noid = "" Then
            lanjut = "F"
            Response.Redirect("bataltemp.aspx?menu_id=" & menu_id)
        Else
            mlSQL = "SELECT kta FROM member WHERE kta like '" & noid & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If Not mlREADER.HasRows Then
                lanjut = "T"
            Else
                lanjut = "F"
                Session("hasil") = "Nomor seri / distributor sudah aktif, proses pembatalan temporary tidak dapat dilakukan !!!"
                Response.Redirect("bataltemp.aspx?menu_id=" & menu_id)
            End If
            mlREADER.Close()

            If lanjut = "T" Then
                If mypos <> dcHO Then
                    mlSQL = "SELECT * FROM st_sale_daftar WHERE noseri like '" & noid & "' and nopos like '" & mypos & "'"
                    mlSQL2 = "Delete From st_sale_daftar WHERE noseri like '" & noid & "' and nopos like '" & mypos & "'"
                Else
                    mlSQL = "SELECT * FROM st_sale_daftar WHERE noseri like '" & noid & "'"
                    mlSQL2 = "Delete From st_sale_daftar WHERE noseri like '" & noid & "'"
                End If
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

                If Not mlREADER.HasRows Then
                    If mypos <> dcHO Then
                        Session("hasil") = "Pembatalan hanya dapat dilakukan oleh DC yang melakukan pendaftaran"
                    Else
                        Session("hasil") = "Tidak ditemukan nomor seri untuk dibatalkan"
                    End If
                Else
                    'rs.delete
                    'rs.update
                    mlOBJGS.ExecuteQuery(mlSQL2, mpMODULEID, mlCOMPANYID)
                    Session("hasil") = "Pembatalan berhasil dilakukan"
                End If
                mlREADER.Close()
                Response.Redirect("bataltemp.aspx?menu_id=" & menu_id)
            End If
        End If
        'MsgBox("batalkan data", MsgBoxStyle.Information, "HWI")
    End Sub
    Protected Sub btntampil_ServerClick(sender As Object, e As EventArgs)
        SaveData()
    End Sub
    Protected Sub btnbatal_ServerClick(sender As Object, e As EventArgs)
        batalnow()
    End Sub
End Class

Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_mb4_perdana_ck
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim menu_id, mypos, loguser, kelasdc, indukdc, piyesetuju, kti, pos_area, nosesifaxmc_pdn, nodc, asale, dcpusat, dc_asal, kdpos, namadis, kemana, kdposna As String
    Dim namamu, alamat, kota, propinsi, kodepos, notelp, nofax, nohape, emel, diskon, zona, jumtot, tunai, debit, kkredit, bgcek, duite, kembalinye, l3a, l1, l4, l5, l6, l7, l8, l9, l10, l11, l12, eml, ggg, area As String
    Dim dino As Date

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Session("menu_id")
        menu_id = Session("menu_id")
        mypos = UCase(Session("motok"))
        loguser = Session("kowe")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")
        piyesetuju = UCase(Request("setuju"))

        kti = Session("kti")
        If Session("motok") = "" Or Session("kowe") = "" Or Session("kti") = "" Then
            Session("out") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("login.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
            Session.Contents("kelasdc") = kelasdc
            Session.Contents("indukdc") = indukdc
        End If

        PrepareData()
    End Sub

    Sub PrepareData()
        If piyesetuju <> "AGREE" Then
            Dim str_Valid As String
            str_Valid = "<p style='text-align:center;'>" & vbCrLf
            str_Valid += "<img border='0' src='../images/logohwi.jpg' width='155' height='100'>" & vbCrLf
            str_Valid += "</p>" & vbCrLf
            str_Valid += "<p style='text-align:center;'>" & vbCrLf
            str_Valid += "<span style='font-family:Verdana;'>Anda belum meng-click perjanjian dan persetujuan kode etik sebagai<br>" & vbCrLf
            str_Valid += " mobile stockiest PT. Health Wealth International<br></span>" & vbCrLf
            str_Valid += " <span style='font-family:Verdana;'><a href ='javascript:history.back()' <> --KEMBALI - -></a></span></p>" & vbCrLf
        End If

        pos_area = Session("pos_area")
        nosesifaxmc_pdn = Session("nosesifaxmc_pdn")
        nodc = UCase(Session("motok"))
        Session("dcpusate") = dcpusat
        asale = Request("asal")
        dino = Now()

        dc_asal = Request("dc_asal")
        kdpos = Request("kdpos")
        namadis = Request("namadis")
        Session("dc_asal") = dc_asal


        If asale = "" Then
            asale = "perdana"
        Else
            asale = asale
        End If

        If asale = "normal" Then
            kemana = "mn_order_produk.aspX?menu_id=" & menu_id
        Else
            kemana = "mb4_perdana.aspX?menu_id=" & menu_id
        End If

        If asale <> "normal" Then
            kdposna = Request("kdpos")
            namamu = Request("nama_user")
            alamat = Request("alamatdis")
            kota = Request("kotadis")
            propinsi = Request("propinsidis")
            kodepos = Request("kodeposdis")
            notelp = Request("telpdis")
            nofax = Request("faxdis")
            nohape = Request("hapedis")
            emel = Request("emaildis")
            diskon = Request("diskondis")
            zona = Request("zona")
            Session("kdposna") = kdposna
            Session("namamu") = namamu
            Session("alamat") = alamat
            Session("kota") = kota
            Session("propinsi") = propinsi
            Session("kodepos") = kodepos
            Session("notelp") = notelp
            Session("nofax") = nofax
            Session("nohape") = nohape
            Session("emel") = emel
            Session("diskon") = diskon
            Session("zona") = zona
        End If

        jumtot = Int(Request("jumtote"))
        tunai = Trim(Request("jumbayarcash"))
        debit = Trim(Request("jumbayardb"))
        kkredit = Trim(Request("jumbayarcc"))
        bgcek = Trim(Request("jumbayarcek"))
        duite = Int(Request("jumbayar"))
        kembalinye = Trim(Request("kembalian"))
        Session("jumtot") = jumtot
        Session("kkredit") = kkredit
        Session("tunai") = tunai
        Session("debit") = debit
        Session("bgcek") = bgcek
        Session("duite") = duite
        Session("kembalinye") = kembalinye


        If asale <> "normal" Then
            If namamu = "" Then
                l3a = "Mbuh"
                Session("errorfax") = "Anda belum mengisikan user name mobile center"
                Response.Redirect(kemana)
            Else
                If Len(namamu) >= 16 Then
                    Session("errorfax") = "User name mobile center 15 karakter"
                    l3a = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(namamu) <= 16) And (namamu <> "")) Then
                        l3a = "Ter3a"
                        Session("errorfax") = ""
                    End If
                End If
            End If
        End If


        If dc_asal = "" Then
            l1 = "Mbuh"
            Session("errorfax") = "Anda belum mengisikan nomor id. DC Asal"
            Response.Redirect(kemana)
        Else
            If Len(dc_asal) >= 16 Then
                Session("errorfax") = "Nomor id. DC asal maksimal 15 karakter"
                l1 = "Mbuh"
                Response.Redirect(kemana)
            Else
                If ((Len(dc_asal) <= 16) And (dc_asal <> "")) Then
                    mlSQL = "SELECT nopos,sta FROM tabdesc_stockist WHERE ucase(nopos) LIKE '" & dc_asal & "'"
                    mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                    mlREADER.Read()
                    If Not mlREADER.HasRows Then
                        Session("errorfax") = "Nomor id. DC asal tidak ditemukan"
                        l1 = "Mbuh"
                        Response.Redirect(kemana)
                    Else
                        If mlREADER("sta") = "T" Then
                            l1 = "Ter1"
                            Session("errorfax") = ""
                        Else
                            Session("errorfax") = "DC asal dalam status disable !"
                            l1 = "Mbuh"
                            Response.Redirect(kemana)
                        End If
                    End If
                    mlREADER.Close()
                End If
            End If
        End If


        If asale <> "normal" Then
            If ((alamat = "") And (alamat <> "-")) Then
                l4 = "Mbuh"
                Session("errorfax") = "Silahkan isikan alamat kontak anda"
                Response.Redirect(kemana)
            Else
                If Len(alamat) >= 221 Then
                    Session("errorfax") = "Alamat kontak maksimal 220 karakter"
                    l4 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(alamat) <= 221) And (alamat <> "")) Then
                        l4 = "Ter4"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If kota = "" Then
                l5 = "Mbuh"
                Session("errorfax") = "Kota alamat belum anda isi"
                Response.Redirect(kemana)
            Else
                If Len(kota) >= 51 Then
                    Session("errorfax") = "Kota alamat maksimal 50 karakter"
                    l5 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(kota) <= 51) And (kota <> "")) Then
                        l5 = "Ter5"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If kodepos = "" Then
                l6 = "Mbuh"
                Session("errorfax") = "Silahkan isikan kodepos anda"
                Response.Redirect(kemana)
            Else
                If Len(kodepos) >= 11 Then
                    Session("errorfax") = "Kodepos maksimal 10 karakter"
                    l6 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(kodepos) <= 11) And (kodepos <> "")) Then
                        l6 = "Ter6"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If propinsi = "" Then
                l7 = "Mbuh"
                Session("errorfax") = "Silahkan pilih propinsi anda"
                Response.Redirect(kemana)
            Else
                If Len(propinsi) >= 81 Then
                    Session("errorfax") = "Propinsi maksimal 80 karakter"
                    l7 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(propinsi) <= 81) And (propinsi <> "")) Then
                        l7 = "Ter7"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If notelp = "" Then
                l8 = "Mbuh"
                Session("errorfax") = "Silahkan isikan nomor telepon"
                Response.Redirect(kemana)
            Else
                If Len(notelp) >= 51 Then
                    Session("errorfax") = "Nomor telepon maksimal 50 karakter"
                    l8 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(notelp) <= 51) And (notelp <> "")) Then
                        l8 = "Ter8"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If nofax = "" Then
                l9 = "Ter9"
                Session("errorfax") = ""
                nofax = "-"
            Else
                If Len(nofax) >= 51 Then
                    Session("errorfax") = "Nomor fax maksimal 50 karakter"
                    l9 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(nofax) <= 51) And (nofax <> "")) Then
                        l9 = "Ter9"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If nohape = "" Then
                l10 = "Ter10"
                Session("errorfax") = ""
            Else
                If Len(nohape) >= 26 Then
                    Session("errorfax") = "Nomor handphone maksimal 25 karakter"
                    l10 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(nohape) <= 26) And (nohape <> "")) Then
                        l10 = "Ter10"
                        Session("errorfax") = ""
                    End If
                End If
            End If

            If emel = "" Then
                l11 = "Ter11"
                Session("errorfax") = ""
                eml = "-"
            Else
                If Len(emel) >= 151 Then
                    Session("errorfax") = "Alamat email maksimal 150 karakter"
                    l11 = "Mbuh"
                    Response.Redirect(kemana)
                    eml = emel
                Else
                    If ((Len(emel) <= 151) And (emel <> "")) Then
                        l11 = "Ter11"
                        Session("errorfax") = ""
                        eml = emel
                    End If
                End If
            End If

            If zona = "" Then
                l12 = "Mbuh"
                Session("errorfax") = "Silahkan pilih zona Mobile Center"
                Response.Redirect(kemana)
            Else
                If Len(zona) >= 151 Then
                    Session("errorfax") = "Zona Mobile Center maksimal 150 karakter"
                    l12 = "Mbuh"
                    Response.Redirect(kemana)
                Else
                    If ((Len(zona) <= 151) And (zona <> "")) Then
                        ggg = "zno"
                        mlSQL = "SELECT * FROM tabdesc WHERE deskripsi LIKE '" & zona & "' and grp like '" & ggg & "'"
                        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                        mlREADER.Read()
                        If Not mlREADER.HasRows Then
                            l12 = "Ter12"
                            Session("errorfax") = ""
                            area = 1
                        Else
                            l12 = "Ter12"
                            Session("errorfax") = ""
                            area = mlREADER("ket")
                        End If
                        mlREADER.Close()
                    End If
                End If
            End If
        End If

        Response.Redirect("sale_stater_ms4.aspx?menu_id=34")
    End Sub
End Class

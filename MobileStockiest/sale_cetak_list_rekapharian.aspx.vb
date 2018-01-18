Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_sale_cetak_list_rekapharian
    Inherits System.Web.UI.Page
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String

    Dim pos_area, loguser, tpe, pgview, bg, pgas As String
    Dim x, pg, tothal, z, totrec, halskr, tujuan, sisa, lumpat, kemana As Double

    Protected totstart1, totprod1, tottot1, totstart, totprod, tottot, totjualakt, totjualprd As Double
    Protected perush_dc, nama_dc, no_dc, alamat_dc, alamat_dc2, telp_dc, emel_dc, web_dc, tgl1, sort, mypos, tgl As String
    Protected mlQuery As String
    Protected mlDR As OleDb.OleDbDataReader
    Protected mlCOMPANYID As String = "ALL"
    Protected mpMODULEID As String = "PB"
    Protected mlDT As DataTable
    Protected mlOBJGS As New IASClass.ucmGeneralSystem


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Session("tema") = "home"
        Session("menu_id") = Request("menu_id")
        pos_area = Session("pos_area")
        mypos = Session("motok")
        loguser = Session("kowe")
        sort = Request("sort")
        If Session("motok") = "" Or Session("kowe") = "" Then
            Session("popout") = "Session login anda sudah expired, silahkan login kembali"
            Response.Redirect("errorpop.aspx")
        Else
            Session("motok") = mypos
            Session("kowe") = loguser
        End If

        PrepareData()
    End Sub

    Sub PrepareData()
        mlSQL = "SELECT count(id) as vid FROM sum_rekap_harian where nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            x = 0
        Else
            x = CInt(mlREADER("vid"))
        End If
        mlREADER.Close()

        pgview = Request("pgview")
        bg = Request("pgview")

        pg = 0
        pgas = Request("page")
        sort = Request("sort")
        If pgas = "" Then
            pg = 0
        Else
            If pgas <> "" Then
                pg = pgas - 1
            End If
        End If

        If x Mod bg = 0 Then
            tothal = x / bg
        Else
            z = x + (bg - (x Mod bg))
            tothal = z / bg
        End If

        totrec = x
        halskr = pg
        tujuan = pg * bg
        sisa = totrec - tujuan
        If sisa < Int(bg) Then
            lumpat = bg + sisa
        Else
            lumpat = bg
        End If

        If tujuan > totrec Then
            kemana = 0
        Else
            kemana = pg * bg
        End If


        mlSQL = "SELECT sum(starter) as vstarter,sum(produk) as vproduk,sum(total) as vtotal FROM sum_rekap_harian where nopos like '" & mypos & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        mlREADER.Read()
        If Not mlREADER.HasRows Then
            totstart1 = 0
            totprod1 = 0
            tottot1 = 0
        Else
            totstart1 = mlREADER("vstarter")
            totprod1 = mlREADER("vproduk")
            tottot1 = mlREADER("vtotal")
        End If
        mlREADER.Close()

        If IsDBNull(totstart) = True Then
            totstart1 = 0
        Else
            totstart1 = totstart1
        End If

        If IsDBNull(totprod) = True Then
            totprod1 = 0
        Else
            totprod1 = totprod1
        End If

        If IsDBNull(tottot) = True Then
            tottot1 = 0
        Else
            tottot1 = tottot1
        End If
    End Sub
End Class

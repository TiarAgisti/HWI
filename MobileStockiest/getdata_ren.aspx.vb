Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_getdata_ren
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"

    Dim kode, pos_area, dcpusate, mypos, loguser, ste, kd As String
    Dim minimal, harga, PV, bv As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Response.ContentType = "text/xml"
        kode = Trim(Request.QueryString.Item(1))
        pos_area = Session("pos_area")
        dcpusate = Session("dcpusate")
        mypos = Session("sotok")
        loguser = Session("anda")

        minimal = 1
        ste = "T"
        kd = "REN"
        If pos_area = "1" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                mlSQL = "SELECT kode,hd1,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and sta like '" & ste & "' and grp like '" & kd & "'"
            Else
                mlSQL = "SELECT kode,hd1,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()

            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd1")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "2" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                mlSQL = "SELECT kode,hd2,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and sta like '" & ste & "' and grp like '" & kd & "'"
            Else
                mlSQL = "SELECT kode,hd2,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd2")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "3" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                mlSQL = "SELECT kode,hd3,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and sta like '" & ste & "' and grp like '" & kd & "'"
            Else
                mlSQL = "SELECT kode,hd3,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd3")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "4" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                mlSQL = "SELECT kode,hd4,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and sta like '" & ste & "' and grp like '" & kd & "'"
            Else
                mlSQL = "SELECT kode,hd4,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd4")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "5" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                mlSQL = "SELECT kode,hd5,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and sta like '" & ste & "' and grp like '" & kd & "'"
            Else
                mlSQL = "SELECT kode,hd5,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd5")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "1" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd1,pv,bv FROM st_barang WHERE kode like '" & kode & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd1")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "2" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd2,pv,bv FROM st_barang WHERE kode like '" & kode & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd2")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "3" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd3,pv,bv FROM st_barang WHERE kode like '" & kode & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd3")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "4" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd4,pv,bv FROM st_barang WHERE kode like '" & kode & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd4")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "5" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd5,pv,bv FROM st_barang WHERE kode like '" & kode & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                PV = 0
                bv = 0
            Else
                harga = mlREADER("hd5")
                PV = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kode & "</data>")
        Response.Write("<data>" & harga & "</data>")
        Response.Write("<data>" & PV & "</data>")
        Response.Write("<data>" & bv & "</data>")
        Response.Write("</xmlresponse>")
    End Sub
End Class

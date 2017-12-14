﻿Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_getdata_new
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlFUNCT As FunctionHWI

    Dim kode, pos_area, dcpusate, mypos, loguser, apani, ste, kd As String
    Dim pv, bv, minimal, harga As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()

        Response.ContentType = "text/xml"

        kode = Trim(UCase(mlFUNCT.SafeSQL((Request.QueryString.Item(1)))))
        pos_area = Session("pos_area")
        dcpusate = Session("dcpusate")
        mypos = Session("motok")
        loguser = Session("kowe")
        apani = UCase(Left(kode, 2))
        ste = "T"

        minimal = 0
        kd = "PRD"
        If pos_area = "1" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                If apani = "FT" Then
                    mlSQL = "SELECT kode,hd1,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
                Else
                    mlSQL = "SELECT kode,hd1,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and sta like '" & ste & "' and grp like '" & kd & "'"
                End If
            Else
                mlSQL = "SELECT kode,hd1,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd1")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "2" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                If apani = "FT" Then
                    mlSQL = "SELECT kode,hd2,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
                Else
                    mlSQL = "SELECT kode,hd2,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and sta like '" & ste & "' and grp like '" & kd & "'"
                End If
            Else
                mlSQL = "SELECT kode,hd2,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()

            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd2")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "3" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                If apani = "FT" Then
                    mlSQL = "SELECT kode,hd3,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
                Else
                    mlSQL = "SELECT kode,hd3,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and sta like '" & ste & "' and grp like '" & kd & "'"
                End If
            Else
                mlSQL = "SELECT kode,hd3,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd3")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "4" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                If apani = "FT" Then
                    mlSQL = "SELECT kode,hd4,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
                Else
                    mlSQL = "SELECT kode,hd4,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and sta like '" & ste & "' and grp like '" & kd & "'"
                End If
            Else
                mlSQL = "SELECT kode,hd4,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd4")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "5" And UCase(mypos) <> dcpusate Then
            If LCase(loguser) <> "kris" Then
                If apani = "FT" Then
                    mlSQL = "SELECT kode,hd5,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
                Else
                    mlSQL = "SELECT kode,hd5,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah > '" & minimal & "' and nopos like '" & mypos & "' and sta like '" & ste & "' and grp like '" & kd & "'"
                End If
            Else
                mlSQL = "SELECT kode,hd5,pv,bv FROM st_barang_ms WHERE kode like '" & kode & "' and jumlah >= '" & minimal & "' and nopos like '" & mypos & "' and grp like '" & kd & "'"
            End If
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd5")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "1" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd1,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & kd & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd1")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "2" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd2,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & kd & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd2")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "3" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd3,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & kd & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd3")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "4" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd4,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & kd & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd4")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        If pos_area = "5" And UCase(mypos) = dcpusate Then
            mlSQL = "SELECT kode,hd5,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & kd & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
            Else
                harga = mlREADER("hd5")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
            End If
            mlREADER.Close()
        End If

        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kode & "</data>")
        Response.Write("<data>" & harga & "</data>")
        Response.Write("<data>" & pv & "</data>")
        Response.Write("<data>" & bv & "</data>")
        Response.Write("</xmlresponse>")
    End Sub

End Class

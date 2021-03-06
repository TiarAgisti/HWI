﻿Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Class MobileStockiest_getdataprd
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlCOMPANYID As String = "ALL"
    Dim mpMODULEID As String = "PB"
    Dim mlFUNCT As FunctionHWI

    Dim kode, pos_area, dcpusate, mypos, sts, dcHO, nama, hhh As String
    Dim pv, bv, minimal, harga As Double

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        mlOBJGS.Main()
        Response.ContentType = "text/xml"
        kode = Trim(UCase(mlFUNCT.SafeSQL((Request.QueryString.Item(1)))))
        pos_area = Session("pos_area")
        mypos = Session("motok")
        dcpusate = Session("dcpusate")
        sts = "T"
        dcHO = "B-000"
        If kode = "MS500U" Or kode = "MS500" Or kode = "MS500U-14" Or kode = "MS200vu-14" Or kode = "MS500VU-14" Or kode = "MS200U-14" Or kode = "MS200vUs-14" Or kode = "MS400U-14" Then
            kode = "tidak boleh bung"
        End If

        hhh = "PRD"
        minimal = 0
        If pos_area = "1" And UCase(mypos) <> dcHO Then
            mlSQL = "SELECT kode,nama,hd1,pv,bv FROM st_barang_ms WHERE nopos like '" & mypos & "' and kode like '" & kode & "' and jumlah > '" & minimal & "' and grp like '" & hhh & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd1")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "2" And UCase(mypos) <> dcHO Then
            mlSQL = "SELECT kode,nama,hd2,pv,bv FROM st_barang_ms WHERE nopos like '" & mypos & "' and kode like '" & kode & "' and jumlah > '" & minimal & "' and grp like '" & hhh & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd2")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "3" And UCase(mypos) <> dcHO Then
            mlSQL = "SELECT kode,nama,hd3,pv,bv FROM st_barang_ms WHERE nopos like '" & mypos & "' and kode like '" & kode & "' and jumlah > '" & minimal & "' and grp like '" & hhh & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd3")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "4" And UCase(mypos) <> dcHO Then
            mlSQL = "SELECT kode,nama,hd4,pv,bv FROM st_barang_ms WHERE nopos like '" & mypos & "' and kode like '" & kode & "' and jumlah > '" & minimal & "' and grp like '" & hhh & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd4")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "5" And UCase(mypos) <> dcHO Then
            mlSQL = "SELECT kode,nama,hd5,pv,bv FROM st_barang_ms WHERE nopos like '" & mypos & "' and kode like '" & kode & "' and jumlah > '" & minimal & "' and grp like '" & hhh & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd5")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "1" And UCase(mypos) = dcHO Then
            'rs.Open "SELECT kode,nama,hd1,pv,bv FROM st_barang WHERE kode like '"&kode&"' and jumlah > '"&minimal&"' and grp like '"&hhh&"'",conn
            mlSQL = "SELECT kode,nama,hd1,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & hhh & "' and sta like '" & sts & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd1")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "2" And UCase(mypos) = dcHO Then
            'rs.Open "SELECT kode,nama,hd2,pv,bv FROM st_barang WHERE kode like '"&kode&"' and jumlah > '"&minimal&"' and grp like '"&hhh&"'",conn
            mlSQL = "SELECT kode,nama,hd2,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & hhh & "' and sta like '" & sts & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd2")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "3" And UCase(mypos) = dcHO Then
            'rs.Open "SELECT kode,nama,hd3,pv,bv FROM st_barang WHERE kode like '"&kode&"' and jumlah > '"&minimal&"' and grp like '"&hhh&"'",conn
            mlSQL = "SELECT kode,nama,hd3,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & hhh & "' and sta like '" & sts & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd3")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "4" And UCase(mypos) = dcHO Then
            'rs.Open "SELECT kode,nama,hd4,pv,bv FROM st_barang WHERE kode like '"&kode&"' and jumlah > '"&minimal&"' and grp like '"&hhh&"'",conn
            mlSQL = "SELECT kode,nama,hd4,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & hhh & "' and sta like '" & sts & "'"
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd4")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If

        If pos_area = "5" And UCase(mypos) = dcHO Then
            'rs.Open "SELECT kode,nama,hd5,pv,bv FROM st_barang WHERE kode like '"&kode&"' and jumlah > '"&minimal&"' and grp like '"&hhh&"'",conn
            mlSQL = "SELECT kode,nama,hd5,pv,bv FROM st_barang WHERE kode like '" & kode & "' and grp like '" & hhh & "' and sta like '" & sts & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            mlREADER.Read()
            If Not mlREADER.HasRows Then
                harga = 0
                pv = 0
                bv = 0
                nama = "NOT FOUND"
            Else
                harga = mlREADER("hd5")
                pv = mlREADER("pv")
                bv = mlREADER("bv")
                nama = mlREADER("nama")
            End If
            mlREADER.Close()
        End If


        Response.Write("<xmlresponse>")
        Response.Write("<data>" & kode & "</data>")
        Response.Write("<data>" & nama & "</data>")
        Response.Write("<data>" & harga & "</data>")
        Response.Write("<data>" & pv & "</data>")
        Response.Write("<data>" & bv & "</data>")
        Response.Write("</xmlresponse>")
    End Sub
End Class

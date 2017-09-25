Imports System
Imports System.Data
Imports System.Data.OleDb

Partial Class MobileStockiest_home
    Inherits System.Web.UI.Page
    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction
    Dim mlOBJPJ As New FunctionLocal

    ' Default Variable
    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlREADER2 As OleDb.OleDbDataReader
    Dim mlSql_2 As String
    Dim mlDATATABLE As DataTable
    Dim mlDATATABLEDETAIL As DataTable

    Dim mlKEY As String
    Dim mlKEY2 As String
    Dim mlKEY3 As String
    Dim mlRECORDSTATUS As String
    Dim mlSPTYPE As String
    Dim mlFUNCTIONPARAMETER As String
    Dim mpMODULEID As String = "PB"
    Dim mlCOMPANYID As String = "ALL"



    Public mypos As String = "", kelasdc As String = "", indukdc As String = "", ktana As String = "", go As String = "",
           kdposna As String = "", sponsor As String = "", kedua As String = ""
    Public bulan As String = "", ent As String = "", upnya As String = "", posloc As String = "",
        spld As String = "", posef As String = "", dowo As String = "", mburi As String = "",
        tipedias As String, upm1 As String = "", a1 As String = "", akhirsa1ki As String = "", akhirsa1ka As String = "",
        upm As String = "", aloksa1ki As String = "", aloksa1ka As String = "", kaki1ka As String = "", kaki1ki As String = "",
        pvkiri2 As String = "0", bvkiri2 As String = "0", pvkanan2 As String = "0", bvkanan2 As String = "0",
        akhirsa1 As String = "", aloksa1 As String = "", kaki1 As String = "", akhirsa2 As String = "",
        a2 As String = "", aloksa2 As String = "", kaki2 As String = "", totkiris2 As String = "", totkanans2 As String = "",
        akhirsa2ki As String = "", aloksa2ki As String = "", kaki2ki As String = "", akhirsa2ka As String = "",
        aloksa2ka As String = "", kaki2ka As String = "", totkiris1 As String = "", totkanans1 As String = "",
        pvpri As String = "0", bvpri As String = "0", pvkiri As String = "0", bvkiri As String = "0", pvkanan As String = "0",
        bvkanan As String = "0", pvkiri3 As String = "0", bvkiri3 As String = "0", pvkanan3 As String = "0", bvkanan3 As String = "0",
        totkirims As String = "", totkananms As String = "", sopoe As String = "", plo1 As String = "", upsa1 As String = "", kaki As String = "",
        upe1 As String = "", upsa2 As String = "", upe2 As String = "", upsa1ki As String = "", upe1ki As String = "", upsa1ka As String = "",
        upe1ka As String = "", upsa2ki As String = "", upe2ki As String = "", upsa2ka As String = "", upe2ka As String = "",
        blnku As String = "", thnku As String = "", direk As String = "", direk2 As String = "", direk3 As String = "",
        pvpri2 As String = "", bvpri2 As String = "", pvpri3 As String = "", bvpri3 As String = "",
        sss As String, bagimu As String, bag As String, pgview As String, pgas As String, bln As String, thn As String,
        updir As String = "", nama As String = "", idne As String = "", upra As String = "", namadir As String = "",
        uploc As String = "", ploc As String = "", namaloc As String = "", pla As String = "",
        menu_id As String, tutup1 As String, cat As String, subct As String, menucode As String,
        srt As String, keyword As String, apa As String, grp As String


    Public levke As Integer = 0, aaxds As Integer = 0, aaxd As Integer = 0, aax As Integer = 0,
        piro As Integer = 0, grdle As Integer = 0, posnow As Integer = 0, x As Integer, lumpat As Integer, pg As Integer,
        bg As Integer, tothal As Integer, z As Integer, totrec As Integer, halskr As Integer, tujuan As Integer,
        sisa As Integer, kemana As Integer, pgcunt As Integer, pgct As Integer,
        x1 As Integer, saatini As Integer, ke As Integer

    Public kembali As Double, y As Double

    Public hariini As Date, tupoawal As Date, tupoakhir As Date


    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        mlOBJGS.Main()



        tupoawal = CDate(Session("tgl1"))
        tupoakhir = CDate(Session("tgl2"))

        If Not IsPostBack Then
            Session("tema") = "home"
            Session("menu_id") = Request("menu_id")

            RetrieveFields()
            DaftarMobileStockies_SudahdiDaftarkan()
            Umumkan()

            'pg_infoac()

        End If

        menu_id = Session("menu_id")

    End Sub

    Protected Sub RetrieveFields()

        mypos = Session("sotoks")
        kelasdc = Session.Contents("kelasdc")
        indukdc = Session.Contents("indukdc")


        'mlSQL = "SELECT top 1 kta FROM tabdesc_stockist WHERE nopos like '" & mypos & "' "
        mlSQL = "SELECT top 1 kta FROM  tabdesc_stockist  "
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlREADER.Read()
            ktana = mlREADER("kta")
        Else
            ktana = "-"
        End If

        mlREADER.Close()

        mlSQL = "SELECT top 1 * FROM zmssponsor where msna like '" & ktana & "' "
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlREADER.Read()
            go = "F"
        Else
            go = "T"
        End If

        mlREADER.Close()

        If go = "T" Then

            kdposna = ktana

            mlSQL = "SELECT direk FROM member WHERE kta LIKE '" & kdposna & "'"
            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
            If mlREADER.HasRows Then
                mlREADER.Read()
                sponsor = mlREADER("direk")
            Else
                sponsor = "-"
            End If
            mlREADER.Close()

            kedua = kdposna
            levke = 0
            bulan = Now()
            For aaxds = 1 To 200000
                mlSQL = "SELECT * FROM  mylevel WHERE kta LIKE '" & kedua & "'"
                mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                If Not mlREADER.HasRows Then
                    aaxd = 200020
                    Exit For
                Else
                    mlREADER.Read()
                    If mlREADER("ktaloc") = "A" Then
                        aax = 200020
                        ent = "F"
                        Exit For
                    Else
                        ent = "F"
                        piro = piro + 1
                        levke = levke + 1
                        kedua = mlREADER("ktaloc")
                        upnya = mlREADER("ktaloc")
                        posloc = mlREADER("posloc")
                        spld = mlREADER("ktaloc")
                        posef = mlREADER("posloc")
                        dowo = Len(spld)
                        mburi = Right(spld, 2)

                        If spld = sponsor Then
                            Dim id As String = ""
                            mlSQL = "SELECT top 1 * FROM  zmssponsor "
                            mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
                            If mlREADER.HasRows Then
                                mlREADER.Read()
                                id = mlREADER("id")

                                If posef = "L" Then
                                    mlSQL = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)" & vbCrLf
                                    mlSQL += "values ('" & spld & "','1','0','" & kdposna & "','" & sponsor & "','" & bulan & "')" & vbCrLf
                                ElseIf posef = "R" Then
                                    mlSQL = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)" & vbCrLf
                                    mlSQL += "values ('" & spld & "','0','1','" & kdposna & "','" & sponsor & "','" & bulan & "')" & vbCrLf
                                End If
                                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                            Else
                                If posef = "L" Then
                                    mlSQL = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)" & vbCrLf
                                    mlSQL += "values ('" & spld & "','1','0','" & kdposna & "','" & sponsor & "','" & bulan & "')" & vbCrLf
                                ElseIf posef = "R" Then
                                    mlSQL = "insert into zmssponsor(kta,kiri,kanan,msna,sponsorna,bulan)" & vbCrLf
                                    mlSQL += "values ('" & spld & "','0','1','" & kdposna & "','" & sponsor & "','" & bulan & "')" & vbCrLf
                                End If
                                mlOBJGS.ExecuteQuery(mlSQL, mpMODULEID, mlCOMPANYID)
                            End If
                        End If
                    End If
                End If

                aaxds = aaxds + 1
                If aaxds > 200000 Then
                    Exit For
                End If
            Next

            mlREADER.Close()

        End If

    End Sub
    Protected Sub DaftarMobileStockies_SudahdiDaftarkan()
        Dim mlDIVStockies As String = ""
        mlSQL = "SELECT nomc FROM  fax_order_mc_head where kat like 'PDN' and nopos like '" & mypos & "' and nomc like 'MS%'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If mlREADER.HasRows Then
            mlREADER.Read()
            While mlREADER.HasRows
                mlDIVStockies = "<div> " & mlREADER("nomc") & "</div> "
            End While
            '/* Next Coding with aspx from Adang*/
        End If
    End Sub

    Protected Sub Umumkan()
        sss = "T"
        bagimu = Request("kategori")
        If bagimu = "" Then
            bag = "DC"
        Else
            bag = bagimu
        End If



        mlSQL = "SELECT count(id) as Jml FROM  berita where sta like '" & sss & "' and tipe like '" & bag & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)

        If Not mlREADER.HasRows Then
            x = 0
        Else
            mlREADER.Read()
            x = CInt(mlREADER("Jml"))
        End If
        mlREADER.Close()

        lumpat = 0
        pg = 0
        pgview = Request("pgview")
        If pgview = "" Then
            bg = 5
        Else
            bg = pgview
        End If

        pgas = Request("page")
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


        pgcunt = x / bg

        If pgcunt < 1 Then
            pgct = 1
        Else
            pgct = roundup(pgcunt)
        End If

        bln = Month(Now())
        thn = Year(Now())


        Dim str_DivClosing As String = ""

        str_DivClosing += "Closing Date untuk bulan ini adalah pada tanggal, jam :<br/>hariakhir = " & Format(Date.Now, "dd/MM/yyyy") & vbCrLf
        str_DivClosing += "<font color='#FF0000'>" & tutup1 & "</font>" & vbCrLf
        str_DivClosing += "<br/>" & vbCrLf
        str_DivClosing += "Periode Top Up dibuka tanggal <b>" & vbCrLf
        str_DivClosing += "" & tupoawal & "</b> sd<b>" & tupoakhir & "</b><br/>" & vbCrLf
        str_DivClosing += "<br/>" & vbCrLf
        str_DivClosing += "Salam sehat luar biasa !" & vbCrLf
        div_closing.InnerHtml = str_DivClosing


        Dim str_ClosingLanjutan As String = ""

        mlSQL = "SELECT * FROM  berita where sta like '" & sss & "' and tipe like '" & bag & "' order by tgl DESC"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, mpMODULEID, mlCOMPANYID)
        If Not mlREADER.HasRows Then
            str_ClosingLanjutan += "<u>Tidak ada berita terbaru</u>" & vbCrLf
        Else
            'rs.move kemana
        End If

        If mlREADER.HasRows Then

            'If goneqSS <> 0 Then
            '    For aaeeqSS = 1 To goneqSS
            '        If rs.eof = True Then Exit For
            '        rs.movenext()
            '    Next
            'Else
            'End If
            mlDATATABLE = New DataTable
            mlDATATABLE.Load(mlREADER)

            For aaaeqSSS = 0 To mlDATATABLE.Rows.Count - 1
                str_ClosingLanjutan += "<b><font size='3' color='#FF0000'>" & vbCrLf
                str_ClosingLanjutan += "ucase(" & mlDATATABLE.Rows(aaaeqSSS)("title") & ")</font></b>" & vbCrLf
                str_ClosingLanjutan += "<br/>" & vbCrLf
                str_ClosingLanjutan += "" & mlDATATABLE.Rows(aaaeqSSS)("isi") & "<br/>" & vbCrLf
                str_ClosingLanjutan += "<i><font size='1' color='#808080'>Added Date : " & FormatDateTime(mlDATATABLE.Rows(aaaeqSSS)("tgl"), 1) & " | Post By : " & mlDATATABLE.Rows(aaaeqSSS)("oleh") & "" & vbCrLf
                str_ClosingLanjutan += "</font></i>" & vbCrLf
                str_ClosingLanjutan += "<br/><br/>" & vbCrLf
            Next
        End If

        mlREADER.Close()
        If x > 0 Then
            str_ClosingLanjutan += "Ditemukan <font color='#FF0000'>" & FormatNumber(x, 0) & "</font> index berita."
            str_ClosingLanjutan += "<br>" & vbCrLf
            str_ClosingLanjutan += "Halaman:" & vbCrLf
            str_ClosingLanjutan += "<nav aria-label='Page navigation'>" & vbCrLf

            x1 = x
            aax = 0


            If x1 Mod bg = 0 Then
                y = x1 / bg
            Else
                z = x1 + (bg - (x1 Mod bg))
                y = z / bg
            End If

            If pg > 0 And pg < 15 Then
                ke = 0
            ElseIf pg > 14 And pg < 30 Then
                ke = 15
            ElseIf pg > 29 And pg < 45 Then
                ke = 30
            ElseIf pg > 44 And pg < 60 Then
                ke = 45
            ElseIf pg > 59 And pg < 75 Then
                ke = 60
            ElseIf pg > 74 And pg < 90 Then
                ke = 75
            ElseIf pg > 89 And pg < 105 Then
                ke = 90
            ElseIf pg > 104 And pg < 120 Then
                ke = 105
            ElseIf pg > 119 And pg < 135 Then
                ke = 120
            ElseIf pg > 134 And pg < 150 Then
                ke = 135
            End If


            kembali = Request("prev")
            If saatini = 0 Then
                saatini = 2
            Else
                saatini = saatini
            End If

            For aax = 1 To 30
                aax = aax + 1
                ke = ke + 1

                If ke = 1 Or ke = 16 Or ke = 31 Or ke = 46 Or ke = 61 Or ke = 76 Or ke = 91 Or ke = 106 Or ke = 121 Or ke = 136 Then
                    str_ClosingLanjutan += "<ul class='pagination'>" & vbCrLf
                    str_ClosingLanjutan += "<li>" & vbCrLf
                    If kembali = 0 Then
                        str_ClosingLanjutan += "<a href='#' aria-label='Previous' disabled='disabled'>" & vbCrLf
                        str_ClosingLanjutan += "<span aria-hidden='true'>&laquo;</span>" & vbCrLf
                        str_ClosingLanjutan += "</a>" & vbCrLf
                    Else
                        str_ClosingLanjutan += "<a href='home.aspx?kategori=" & bagimu & "&category=" & cat & "&subcategory=" & subct & "&page=" & kembali & "&grpid=" & menucode & "&sort=" & srt & "&pgview=" & pgview & "&keyword=" & keyword & "&tampil=" & apa & "&grp=" & grp & "&prev=" & kembali - 1 & "&nexts=" & ke + 1 & "' aria-label='Previous' disabled='disabled'>" & vbCrLf
                        str_ClosingLanjutan += "<span aria-hidden='true'>&laquo;</span>" & vbCrLf
                        str_ClosingLanjutan += "</a>" & vbCrLf
                    End If
                    str_ClosingLanjutan += "</li>" & vbCrLf

                End If

                If ke < y + 1 Then
                    If pg + 1 = ke Then
                        saatini = ke
                        str_ClosingLanjutan += "<li>" & vbCrLf
                        str_ClosingLanjutan += "<a href='home.aspx?kategori=" & bagimu & "&category=" & cat & "&subcategory=" & subct & "&page=" & ke & "&grpid=" & menucode & "&sort=" & srt & "&pgview=" & pgview & "&keyword=" & keyword & "&tampil=" & apa & "&grp=" & grp & "&prev=" & ke - 1 & "&nexts=" & ke + 1 & " > " & vbCrLf
                        str_ClosingLanjutan += "" & FormatNumber(ke, 0) & vbCrLf
                        str_ClosingLanjutan += "</a>" & vbCrLf
                        str_ClosingLanjutan += "</li>" & vbCrLf
                    Else
                        str_ClosingLanjutan += "<li>" & vbCrLf
                        str_ClosingLanjutan += "<a href='home.aspx?kategori=" & bagimu & "&category=" & cat & "&subcategory=" & subct & "&page=" & ke & "&grpid=" & menucode & "&sort=" & srt & "&pgview=" & pgview & "&keyword=" & keyword & "&tampil=" & apa & "&grp=" & grp & "&prev=" & ke - 1 & "&nexts=" & ke + 1 & "  > " & vbCrLf
                        str_ClosingLanjutan += "" & FormatNumber(ke, 0) & vbCrLf
                        str_ClosingLanjutan += "</a>" & vbCrLf
                        str_ClosingLanjutan += "</li>" & vbCrLf

                    End If

                    'If aax = 30 Then
                    '    Exit For
                    'End If
                End If
            Next

            If tothal < saatini Or tothal = saatini Then
                str_ClosingLanjutan += "<li>" & vbCrLf
                str_ClosingLanjutan += "<a href='#' aria-label='Next' disabled='disabled'>" & vbCrLf
                str_ClosingLanjutan += "<span aria-hidden='true'>&raquo;</span>" & vbCrLf
                str_ClosingLanjutan += "</a>" & vbCrLf
                str_ClosingLanjutan += "</li>" & vbCrLf
                str_ClosingLanjutan += "<li>" & vbCrLf

            Else
                str_ClosingLanjutan += "<li>" & vbCrLf
                str_ClosingLanjutan += "<a href='home.aspx?kategori=" & bagimu & "&category=" & cat & "&subcategory=" & subct & "&page=" & saatini + 1 & "&grpid=" & menucode & "&sort=" & srt & "&pgview=" & pgview & "&keyword=" & keyword & "&tampil=" & apa & "&grp=" & grp & "&prev=" & saatini & "&nexts=" & saatini + 1 & "' aria-label='Next' >" & vbCrLf
                str_ClosingLanjutan += "<span aria-hidden='true'>&raquo;</span>" & vbCrLf
                str_ClosingLanjutan += "</a>" & vbCrLf
                str_ClosingLanjutan += "</li>" & vbCrLf

            End If


        Else

        End If
        str_ClosingLanjutan += "</ul>" & vbCrLf
        str_ClosingLanjutan += "</nav>" & vbCrLf

        Div_ClosingLanjutan.InnerHtml = str_ClosingLanjutan



    End Sub
    Function roundup(x As Integer) As Integer
        If x > Int(x) Then
            roundup = Int(x) + 1
        Else
            roundup = x
        End If
        Return roundup
    End Function



    Protected Sub pg_infoac()

        mlSQL = "SELECT pal1,pal2,uid,upme,direk,tipene,kta FROM  member where kta like '" & direk & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            a1 = mlREADER("pal1")
            a2 = mlREADER("pal2")
            nama = mlREADER("uid")
            upm1 = mlREADER("upme")
            upm = mlREADER("upme")
            updir = mlREADER("direk")
            tipedias = mlREADER("tipene")
            idne = mlREADER("kta")
            upra = mlREADER("upme")
        End If

        mlSQL = "SELECT * FROM  jenjang where kta like '" & direk & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        grdle = 1
        posnow = 0
        If mlREADER.HasRows Then
            mlREADER.Read()
            grdle = CType(mlREADER("grdlevel"), Integer)
            posnow = mlREADER("posakhir")
        End If

        mlSQL = "SELECT uid,kta FROM  member where kta like '" & updir & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            namadir = mlREADER("uid")
        End If

        mlSQL = "SELECT kta,ktaloc,posloc FROM  mylevel WHERE kta LIKE '" & direk & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            uploc = mlREADER("ktaloc")
            ploc = mlREADER("posloc")

        End If

        mlSQL = "SELECT pal1,pal2,uid,upme,direk,tipene,kta FROM  member where kta like '" & uploc & "' or pal1 like '" & uploc & "' or pal2 like '" & uploc & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            namaloc = mlREADER("uid")
            pla = mlREADER("kta")
        End If

        pg_infoac2()
        'Dist_BoxBody()
        'BC2_BoxBody()
        'BC1_BoxBody()
        'BC3_BoxBody()

    End Sub
    Protected Sub pg_infoac2()
        mlSQL = "SELECT * FROM  bonpas where ((kta LIKE '" & direk & "') or (kta LIKE '" & a1 & "') or (kta LIKE '" & a2 & "')) order by id desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()

            For aaaeqSSS = 1 To 12
                sopoe = mlREADER("kta")

                totkirims = mlREADER("totkiri")
                totkananms = mlREADER("totkanan")

                If sopoe = a1 Then
                    totkiris1 = mlREADER("totkiri")
                    totkanans1 = mlREADER("totkanan")
                    If upra = "T" Then
                        totkiris1 = totkiris1
                        totkanans1 = totkanans1
                    Else
                        totkiris1 = 0
                        totkanans1 = 0
                    End If
                End If

                If sopoe = a2 Then
                    totkiris2 = mlREADER("totkiri")
                    totkanans2 = mlREADER("totkanan")
                    If upra = "T" Then
                        totkiris2 = totkiris2
                        totkanans2 = totkanans2
                    Else
                        totkiris2 = 0
                        totkanans2 = 0
                    End If
                End If
            Next
        End If

        plo1 = "L"

        mlSQL = "SELECT kta,ktadir,pose FROM  mydistri_power where ((kta like '" & direk & "') and (pose like '" & plo1 & "')) " 'order by joindt desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            akhirsa1 = mlREADER("ktadir")
        End If


        mlSQL = "SELECT kta,alok,direk,pose FROM  member where kta like '" & akhirsa1 & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            aloksa1 = mlREADER("alok")
            upsa1 = mlREADER("direk")
            kaki = mlREADER("pose")
        End If

        mlSQL = "SELECT kta,upme FROM  member where kta like '" & aloksa1 & "' or pal1 like '" & aloksa1 & "' or pal2 like '" & aloksa1 & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        upe1 = "F"
        If mlREADER.HasRows Then
            mlREADER.Read()
            upe1 = mlREADER("upme")
        End If

        If upe1 = "T" Then
            aloksa1 = aloksa1
        Else
            If Len(aloksa1) = 9 Then
                aloksa1 = Left(aloksa1, 7)
            Else
                If Len(aloksa1) = 10 Then
                    aloksa1 = Left(aloksa1, 8)
                Else
                    aloksa1 = aloksa1
                End If
            End If
        End If

        If kaki = "L" Then
            kaki1 = "Kaki Kiri"
        Else
            If kaki = "R" Then
                kaki1 = "Kaki Kanan"
            Else
                kaki1 = ""
            End If
        End If

        plo1 = "R"
        mlSQL = "SELECT kta,ktadir,pose FROM  mydistri_power where ((kta like '" & direk & "') and (pose like '" & plo1 & "')) " 'order by joindt desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            akhirsa2 = mlREADER("ktadir")
        End If

        mlSQL = "SELECT kta,alok,direk,pose FROM  member where kta like '" & akhirsa2 & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            aloksa2 = mlREADER("alok")
            upsa2 = mlREADER("direk")
            kaki = mlREADER("pose")
        End If

        mlSQL = "SELECT kta,upme FROM  member where kta like '" & aloksa2 & "' or pal1 like '" & aloksa2 & "' or pal2 like '" & aloksa2 & "'"
        upe2 = "F"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            upe2 = mlREADER("upme")
        End If


        If upe2 = "T" Then
            aloksa2 = aloksa2
        Else
            If Len(aloksa2) = 9 Then
                aloksa2 = Left(aloksa2, 7)
            Else
                If Len(aloksa2) = 10 Then
                    aloksa2 = Left(aloksa2, 8)
                Else
                    aloksa2 = aloksa2
                End If
            End If
        End If

        If kaki = "L" Then
            kaki2 = "Kaki Kiri"
        Else
            If kaki = "R" Then
                kaki2 = "Kaki Kanan"
            Else
                kaki2 = ""
            End If
        End If

        '''''''''''''''''''''''''''''''''''''''
        ' downline akhir spot-1
        '''''''''''''''''''''''''''''''''''''''
        plo1 = "L"
        mlSQL = "SELECT kta,ktadir,pose FROM  mydistri_power where ((kta like '" & a1 & "') and (pose like '" & plo1 & "')) " 'order by joindt desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            akhirsa1ki = mlREADER("ktadir")
        End If


        mlSQL = "SELECT kta,alok,direk,pose FROM  member where kta like '" & akhirsa1ki & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            aloksa1ki = mlREADER("alok")
            upsa1ki = mlREADER("direk")
            kaki = mlREADER("pose")
        End If


        mlSQL = "SELECT kta,upme FROM  member where kta like '" & aloksa1ki & "' or pal1 like '" & aloksa1ki & "' or pal2 like '" & aloksa1ki & "'"
        upe1ki = "F"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            upe1ki = mlREADER("upme")
        End If


        If upe1ki = "T" Then
            aloksa1ki = aloksa1ki
        Else
            If Len(aloksa1ki) = 9 Then
                aloksa1ki = Left(aloksa1ki, 7)
            Else
                If Len(aloksa1ki) = 10 Then
                    aloksa1ki = Left(aloksa1ki, 8)
                Else
                    aloksa1ki = aloksa1ki
                End If
            End If
        End If

        If kaki = "L" Then
            kaki1ki = "Kaki Kiri"
        Else
            If kaki = "R" Then
                kaki1ki = "Kaki Kanan"
            Else
                kaki1ki = ""
            End If
        End If

        plo1 = "R"
        mlSQL = "SELECT kta,ktadir,pose FROM  mydistri_power where ((kta like '" & a1 & "') and (pose like '" & plo1 & "')) " 'order by joindt desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            akhirsa1ka = mlREADER("ktadir")
        End If

        mlSQL = "SELECT kta,alok,direk,pose FROM  member where kta like '" & akhirsa1ka & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            aloksa1ka = mlREADER("alok")
            upsa1ka = mlREADER("direk")
            kaki = mlREADER("pose")
        End If

        mlSQL = "SELECT kta,upme FROM  member where kta like '" & aloksa1ka & "' or pal1 like '" & aloksa1ka & "' or pal2 like '" & aloksa1ka & "'"
        upe1ka = "F"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            upe1ka = mlREADER("upme")
        End If


        If upe1ka = "T" Then
            aloksa1ka = aloksa1ka
        Else
            If Len(aloksa1ka) = 9 Then
                aloksa1ka = Left(aloksa1ka, 7)
            Else
                If Len(aloksa1ka) = 10 Then
                    aloksa1ka = Left(aloksa1ka, 8)
                Else
                    aloksa1ka = aloksa1ka
                End If
            End If
        End If

        If kaki = "L" Then
            kaki1ka = "Kaki Kiri"
        Else
            If kaki = "R" Then
                kaki1ka = "Kaki Kanan"
            Else
                kaki1ka = ""
            End If
        End If

        '''''''''''''''''''''''''''''''''''''''
        ' downline akhir spot-2
        '''''''''''''''''''''''''''''''''''''''
        plo1 = "L"
        mlSQL = "SELECT kta,ktadir,pose FROM  mydistri_power where ((kta like '" & a2 & "') and (pose like '" & plo1 & "')) " ' order by joindt desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            akhirsa2ki = mlREADER("ktadir")
        End If

        mlSQL = "SELECT kta,alok,direk,pose FROM  member where kta like '" & akhirsa2ki & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            aloksa2ki = mlREADER("alok")
            upsa2ki = mlREADER("direk")
            kaki = mlREADER("pose")
        End If


        mlSQL = "SELECT kta,upme FROM  member where kta like '" & aloksa2ki & "' or pal1 like '" & aloksa2ki & "' or pal2 like '" & aloksa2ki & "'"
        upe2ki = "F"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            upe2ki = mlREADER("upme")
        End If


        If upe2ki = "T" Then
            aloksa2ki = aloksa2ki
        Else
            If Len(aloksa2ki) = 9 Then
                aloksa2ki = Left(aloksa2ki, 7)
            Else
                If Len(aloksa2ki) = 10 Then
                    aloksa2ki = Left(aloksa2ki, 8)
                Else
                    aloksa2ki = aloksa2ki
                End If
            End If
        End If

        If kaki = "L" Then
            kaki2ki = "Kaki Kiri"
        Else
            If kaki = "R" Then
                kaki2ki = "Kaki Kanan"
            Else
                kaki2ki = ""
            End If
        End If

        plo1 = "R"
        mlSQL = "SELECT kta,ktadir,pose FROM  mydistri_power where ((kta like '" & a2 & "') and (pose like '" & plo1 & "')) " 'order by joindt desc"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            akhirsa2ka = mlREADER("ktadir")
        End If

        mlSQL = "SELECT kta,alok,direk,pose FROM  member where kta like '" & akhirsa2ka & "'"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            aloksa2ka = mlREADER("alok")
            upsa2ka = mlREADER("direk")
            kaki = mlREADER("pose")
        End If

        mlSQL = "SELECT kta,upme FROM  member where kta like '" & aloksa2ka & "' or pal1 like '" & aloksa2ka & "' or pal2 like '" & aloksa2ka & "'"
        upe2ka = "F"
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            upe2ka = mlREADER("upme")
        End If


        If upe2ka = "T" Then
            aloksa2ka = aloksa2ka
        Else
            If Len(aloksa2ka) = 9 Then
                aloksa2ka = Left(aloksa2ka, 7)
            Else
                If Len(aloksa2ka) = 10 Then
                    aloksa2ka = Left(aloksa2ka, 8)
                Else
                    aloksa2ka = aloksa2ka
                End If
            End If
        End If

        If kaki = "L" Then
            kaki2ka = "Kaki Kiri"
        Else
            If kaki = "R" Then
                kaki2ka = "Kaki Kanan"
            Else
                kaki2ka = ""
            End If
        End If

        'hariini = date()-30
        hariini = Now
        blnku = Month(hariini)
        thnku = Year(hariini)
        direk2 = direk + "-2"
        direk3 = direk + "-3"
        '''''''''''''''''''''''''''''''''''''''''
        ' ambil pv pribadi bulan ini MASTER BC
        '''''''''''''''''''''''''''''''''''''''''	
        mlSQL = "SELECT pvpribadi,bvpribadi,pvgrupkiri,pvgrupkanan,bvgrupkiri,bvgrupkanan FROM  bns_mypv where kta like '" & direk & "' and bulan = '" & blnku & "' and tahun = '" & thnku & "'"
        pvpri = 0
        bvpri = 0
        pvkiri = 0
        bvkiri = 0
        pvkanan = 0
        bvkanan = 0
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            pvpri = mlREADER("pvpribadi")
            bvpri = mlREADER("bvpribadi")
            pvkiri = mlREADER("pvgrupkiri")
            bvkiri = mlREADER("bvgrupkiri")
            pvkanan = mlREADER("pvgrupkanan")
            bvkanan = mlREADER("bvgrupkanan")
        End If

        '''''''''''''''''''''''''''''''''''''''''
        ' ambil pv pribadi bulan ini BC-2
        '''''''''''''''''''''''''''''''''''''''''	
        mlSQL = "SELECT pvpribadi,bvpribadi,pvgrupkiri,pvgrupkanan,bvgrupkiri,bvgrupkanan FROM  bns_mypv where kta like '" & direk2 & "' and bulan = '" & blnku & "' and tahun = '" & thnku & "'"
        pvpri2 = 0
        bvpri2 = 0
        pvkiri2 = 0
        bvkiri2 = 0
        pvkanan2 = 0
        bvkanan2 = 0
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            pvpri2 = mlREADER("pvpribadi")
            bvpri2 = mlREADER("bvpribadi")
            pvkiri2 = mlREADER("pvgrupkiri")
            bvkiri2 = mlREADER("bvgrupkiri")
            pvkanan2 = mlREADER("pvgrupkanan")
            bvkanan2 = mlREADER("bvgrupkanan")
        End If

        '''''''''''''''''''''''''''''''''''''''''
        ' ambil pv pribadi bulan ini BC-3
        '''''''''''''''''''''''''''''''''''''''''	
        mlSQL = "SELECT pvpribadi,bvpribadi,pvgrupkiri,pvgrupkanan,bvgrupkiri,bvgrupkanan FROM  bns_mypv where kta like '" & direk3 & "' and bulan = '" & blnku & "' and tahun = '" & thnku & "'"
        pvpri3 = 0
        bvpri3 = 0
        pvkiri3 = 0
        bvkiri3 = 0
        pvkanan3 = 0
        bvkanan3 = 0
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then
            mlREADER.Read()
            pvpri3 = mlREADER("pvpribadi")
            bvpri3 = mlREADER("bvpribadi")
            pvkiri3 = mlREADER("pvgrupkiri")
            bvkiri3 = mlREADER("bvgrupkiri")
            pvkanan3 = mlREADER("pvgrupkanan")
            bvkanan3 = mlREADER("bvgrupkanan")
        End If

    End Sub

    ' DISTRIBUTION PANEL 
    'Protected Sub Dist_BoxBody()
    '    Dim StrBoxBody As String = ""

    '    StrBoxBody = "<table class='table table-hover table-striped table-bordered table-responsive table6'> " & vbCrLf
    '    StrBoxBody += "<tr>" & vbCrLf
    '    StrBoxBody += "<td >Distributor ID.</td>" & vbCrLf
    '    StrBoxBody += "<td >:</td>" & vbCrLf
    '    StrBoxBody += "<td >" & direk & "</td>"
    '    StrBoxBody += "</tr>" & vbCrLf
    '    StrBoxBody += "<tr>" & vbCrLf
    '    StrBoxBody += "<td >Nama Distributor</td>" & vbCrLf
    '    StrBoxBody += "<td >:</td>" & vbCrLf
    '    StrBoxBody += "<td >" & Session("nama") & "</td>" & vbCrLf
    '    StrBoxBody += "</tr>" & vbCrLf
    '    StrBoxBody += "<tr>" & vbCrLf
    '    StrBoxBody += "<td >Tipe Distributor</td>" & vbCrLf
    '    StrBoxBody += "<td >:</td>" & vbCrLf
    '    StrBoxBody += "<td >" & vbCrLf
    '    If tipedias = "P" Then
    '        StrBoxBody += "<font color='#008000'><b>PREMIUM</b></font>" & vbCrLf
    '    ElseIf tipedias = "R" Then
    '        StrBoxBody += "<font color='#000000'><b>REGULAR</b></font>" & vbCrLf
    '    End If
    '    StrBoxBody += "</td>" & vbCrLf
    '    StrBoxBody += "</tr>" & vbCrLf
    '    StrBoxBody += "<tr>" & vbCrLf
    '    StrBoxBody += "<td>Business Center-2</td>" & vbCrLf
    '    StrBoxBody += "<td>:</td>" & vbCrLf
    '    StrBoxBody += "<td>" & vbCrLf
    '    If upm1 = "T" Then
    '        StrBoxBody += "<font color='#800080'>Available</font>" & vbCrLf
    '    Else
    '        StrBoxBody += "<font color='#800000'>Not Available</font>" & vbCrLf
    '    End If
    '    StrBoxBody += "</td>" & vbCrLf
    '    StrBoxBody += "</tr>" & vbCrLf
    '    StrBoxBody += "<tr>" & vbCrLf
    '    StrBoxBody += "<td >Business Center-3</td>" & vbCrLf
    '    StrBoxBody += "<td >:</td>" & vbCrLf
    '    StrBoxBody += "<td >" & vbCrLf
    '    If upm1 = "T" Then
    '        StrBoxBody += "<font color='#800080'>Available</font>" & vbCrLf
    '    Else
    '        StrBoxBody += "<font color='#800000'>Not Available</font>" & vbCrLf
    '    End If
    '    StrBoxBody += "</td>" & vbCrLf
    '    StrBoxBody += "</tr>" & vbCrLf
    '    StrBoxBody += "<tr>" & vbCrLf
    '    StrBoxBody += "<td >Ranking</td>" & vbCrLf
    '    StrBoxBody += "<td >:</td>" & vbCrLf
    '    StrBoxBody += "<td >" & Session("pose") & "</td> " & vbCrLf
    '    StrBoxBody += "</tr>" & vbCrLf
    '    StrBoxBody += "<tr>" & vbCrLf
    '    StrBoxBody += "<td >Sponsor Langsung</td>" & vbCrLf
    '    StrBoxBody += "<td >:</td>" & vbCrLf
    '    StrBoxBody += "<td >" & Session("updir") - Session("namadir") & " </td>" & vbCrLf
    '    StrBoxBody += "</tr>" & vbCrLf
    '    StrBoxBody += "</table>" & vbCrLf

    '    ' boxbody_Distribution.InnerHtml = StrBoxBody
    'End Sub
    'Protected Sub BC2_BoxBody()
    '    Dim strBC2Body As String = ""

    '    If upm = "T" Then
    '        strBC2Body = "<table class='table table-hover table-striped table-bordered table-responsive table6'>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td >BC-2</td>" & vbCrLf
    '        strBC2Body += "<td >:</td>" & vbCrLf
    '        strBC2Body += "<td >" & Session("a1") & "</td>" & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td >Kaki Kiri</td>" & vbCrLf
    '        strBC2Body += "<td >:</td>" & vbCrLf
    '        strBC2Body += "<td >" & totkiris1 & " </td>" & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td >Kaki Kanan</td>" & vbCrLf
    '        strBC2Body += "<td >:</td>" & vbCrLf
    '        strBC2Body += "<td >" & totkanans1 & " </td>" & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td >" & vbCrLf
    '        strBC2Body += "D-line Akhir Kiri" & vbCrLf
    '        strBC2Body += "</td>" & vbCrLf
    '        strBC2Body += "<td >:</td>" & vbCrLf
    '        strBC2Body += "<td >" & vbCrLf
    '        If a1 <> akhirsa1ki Then
    '            If Len(akhirsa1ki) = 7 Or Len(akhirsa1ki) = 8 Then
    '                akhirsa1ki = akhirsa1ki
    '            Else
    '                If Len(akhirsa1ki) = 7 Then
    '                    akhirsa1ki = Left(akhirsa1ki, 7)
    '                Else
    '                    If Len(akhirsa1ki) = 8 Then
    '                        akhirsa1ki = Left(akhirsa1ki, 8)
    '                    End If
    '                End If
    '            End If
    '            strBC2Body += "<a href='jaringan.asp?id=" & akhirsa1ki & "'>" & akhirsa1ki & "</a> " & vbCrLf
    '        End If
    '        strBC2Body += "</td>" & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td >Placement</td>" & vbCrLf
    '        strBC2Body += "<td >:</td>" & vbCrLf
    '        strBC2Body += "<td ><a href='jaringan.asp?id=" & aloksa1ki & "'>" & aloksa1ki & "/" & kaki1ki & "</a> </td> " & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td >D-line Akhir Kanan</td>" & vbCrLf
    '        strBC2Body += "<td  >:</td>" & vbCrLf
    '        strBC2Body += "<td >" & vbCrLf
    '        If a1 <> akhirsa1ka Then
    '            If Len(akhirsa1ka) = 7 Or Len(akhirsa1ka) = 8 Then
    '                akhirsa1ka = akhirsa1ka
    '            Else
    '                If Len(akhirsa1ka) = 7 Then
    '                    akhirsa1ka = Left(akhirsa1ka, 7)
    '                Else
    '                    If Len(akhirsa1ka) = 8 Then
    '                        akhirsa1ka = Left(akhirsa1ka, 8)
    '                    End If
    '                End If
    '            End If
    '            strBC2Body += "<a href='jaringan.asp?id=" & akhirsa1ka & "'>" & akhirsa1ka & "</a> " & vbCrLf
    '        End If
    '        strBC2Body += "</td>" & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td >Placement</td>" & vbCrLf
    '        strBC2Body += "<td >:</td>" & vbCrLf
    '        strBC2Body += "<td ><a href='jaringan.asp?id=" & aloksa1ka & "'>" & aloksa1ka & "/" & kaki1ka & "</a> </td> " & vbCrLf
    '        strBC2Body += "</tr>  " & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td><font color='#008000'>PV Grup Kiri</font></td>" & vbCrLf
    '        strBC2Body += "<td><font color='#008000'>:</font></td>" & vbCrLf
    '        strBC2Body += "<td><font color='#008000'>" & FormatNumber(pvkiri2, 2) & "</font></td> " & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td><font color='#008000'>BV Grup Kiri</font></td>" & vbCrLf
    '        strBC2Body += "<td><font color='#008000'>:</font></td>" & vbCrLf
    '        strBC2Body += "<td ><font color='#008000'>" & FormatNumber(bvkiri2, 2) & "</font></td> " & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td><font color='#000080'>PV Grup Kanan</font></td>" & vbCrLf
    '        strBC2Body += "<td><font color='#000080'>:</font></td>" & vbCrLf
    '        strBC2Body += "<td><font color='#000080'>" & FormatNumber(pvkanan2, 2) & "</font></td> " & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td><font color='#000080'>BV Grup Kanan</font></td>" & vbCrLf
    '        strBC2Body += "<td><font color='#000080'>:</font></td>" & vbCrLf
    '        strBC2Body += "<td><font color='#000080'>" & FormatNumber(bvkanan2, 2) & "</font></td> " & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "</table>" & vbCrLf
    '    Else
    '        strBC2Body += "<table class='table table-hover table-striped table-bordered table-responsive table6'>" & vbCrLf
    '        strBC2Body += "<tr>" & vbCrLf
    '        strBC2Body += "<td ><p >BC-2 belum tersedia</p></td>" & vbCrLf
    '        strBC2Body += "</tr>" & vbCrLf
    '        strBC2Body += "</table>" & vbCrLf
    '    End If

    '    ' boxbody_BC2.InnerHtml = strBC2Body

    'End Sub
    'Protected Sub BC1_BoxBody()
    '    Dim strBC1Body As String = ""

    '    strBC1Body = "<table class='table table-hover table-striped table-bordered table-responsive table6'>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td>BC-1</td>" & vbCrLf
    '    strBC1Body += "<td>:</td>" & vbCrLf
    '    strBC1Body += "<td>" & direk & " </td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td>Kaki Kiri</td>" & vbCrLf
    '    strBC1Body += "<td>:</td>" & vbCrLf
    '    strBC1Body += "<td>" & Session("totkirims") & "</td>" & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td>Kaki Kanan</td>" & vbCrLf
    '    strBC1Body += "<td>:</td>" & vbCrLf
    '    strBC1Body += "<td>" & Session("totkananms") & "</td>" & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td>D-line Akhir Kiri" & vbCrLf
    '    strBC1Body += "</td>" & vbCrLf
    '    strBC1Body += "<td>:</td>" & vbCrLf
    '    strBC1Body += "<td>" & vbCrLf
    '    If a1 <> akhirsa1 Then
    '        If Len(akhirsa1) = 7 Or Len(akhirsa1) = 8 Then
    '            akhirsa1 = akhirsa1
    '        Else
    '            If Len(akhirsa1) = 7 Then
    '                akhirsa1 = Left(akhirsa1, 7)
    '            Else
    '                If Len(akhirsa1) = 8 Then
    '                    akhirsa1 = Left(akhirsa1, 8)
    '                End If
    '            End If
    '        End If
    '        strBC1Body += "<a href='jaringan.asp?id=" & akhirsa1 & "'>" & akhirsa1 & "/a>  " & vbCrLf
    '    End If
    '    strBC1Body += "</td>" & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td>Placement</td>" & vbCrLf
    '    strBC1Body += "<td>:</td>" & vbCrLf
    '    strBC1Body += "<td><a href='jaringan.asp?id=" & aloksa1 & "'>" & aloksa1 & "/" & kaki1 & "</a></td>" & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td>D-line Akhir Kanan</td>" & vbCrLf
    '    strBC1Body += "<td>:</td>" & vbCrLf
    '    strBC1Body += "<td>" & vbCrLf
    '    If a2 <> akhirsa2 Then
    '        If Len(akhirsa2) = 7 Or Len(akhirsa2) = 8 Then
    '            akhirsa2 = akhirsa2
    '        Else
    '            If Len(akhirsa2) = 7 Then
    '                akhirsa2 = Left(akhirsa2, 7)
    '            Else
    '                If Len(akhirsa2) = 8 Then
    '                    akhirsa2 = Left(akhirsa2, 8)
    '                End If
    '            End If
    '        End If
    '        strBC1Body += "<a href='jaringan.asp?id=" & akhirsa2 & "'>" & akhirsa2 & "</a> " & vbCrLf
    '    End If
    '    strBC1Body += "</td>" & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td>Placement</td>" & vbCrLf
    '    strBC1Body += "<td>:</td>" & vbCrLf
    '    strBC1Body += "<td><a href='jaringan.asp?id=" & aloksa2 & "'>" & aloksa2 & "/" & kaki2 & "</a></td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td><font color='#FF0000'>PV Pribadi</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#FF0000'>:</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#FF0000'>" & FormatNumber(pvpri, 2) & " </font></td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td><font color='#FF0000'>BV Pribadi</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#FF0000'>:</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#FF0000'>" & FormatNumber(bvpri, 2) & " </font></td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td><font color='#008000'>PV Grup Kiri</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#008000'>:</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#008000'>" & FormatNumber(pvkiri, 2) & " </font></td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td><font color='#008000'>BV Grup Kiri</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#008000'>:</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#008000'>" & FormatNumber(bvkiri, 2) & " </font></td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td><font color='#000080'>PV Grup Kanan</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#000080'>:</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#000080'>" & FormatNumber(pvkanan, 2) & " </font></td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "<tr>" & vbCrLf
    '    strBC1Body += "<td><font color='#000080'>BV Grup Kanan</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#000080'>:</font></td>" & vbCrLf
    '    strBC1Body += "<td><font color='#000080'>" & FormatNumber(bvkanan, 2) & " </font></td> " & vbCrLf
    '    strBC1Body += "</tr>" & vbCrLf
    '    strBC1Body += "</table>" & vbCrLf

    '    '  boxbody_BC1.InnerHtml = strBC1Body
    'End Sub
    'Protected Sub BC3_BoxBody()
    '    Dim strBC3Body As String = ""

    '    If upm = "T" Then
    '        strBC3Body = "<table class='table table-hover table-striped table-bordered table-responsive table6'>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td>BC-3</td>" & vbCrLf
    '        strBC3Body += "<td>:</td>" & vbCrLf
    '        strBC3Body += "<td>" & a2 & "</td>" & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td>Kaki Kiri</td>" & vbCrLf
    '        strBC3Body += "<td>:</td>" & vbCrLf
    '        strBC3Body += "<td>" & totkiris2 & "</td>" & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td>Kaki Kanan</td>" & vbCrLf
    '        strBC3Body += "<td>:</td>" & vbCrLf
    '        strBC3Body += "<td>" & totkanans2 & "</td>" & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td>D-line Akhir Kiri</td>" & vbCrLf
    '        strBC3Body += "<td>:</td>" & vbCrLf
    '        strBC3Body += "<td>" & vbCrLf
    '        If a2 <> akhirsa2ki Then
    '            If Len(akhirsa2ki) = 7 Or Len(akhirsa2ki) = 8 Then
    '                akhirsa2ki = akhirsa2ki
    '            Else
    '                If Len(akhirsa2ki) = 7 Then
    '                    akhirsa2ki = Left(akhirsa2ki, 7)
    '                Else
    '                    If Len(akhirsa2ki) = 8 Then
    '                        akhirsa2ki = Left(akhirsa2ki, 8)
    '                    End If
    '                End If
    '            End If
    '            strBC3Body += "<a href='jaringan.asp?id=" & akhirsa2ki & "'>" & akhirsa2ki & "</a> " & vbCrLf
    '        End If
    '        strBC3Body += "</td>" & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td>Placement</td>" & vbCrLf
    '        strBC3Body += "<td>:</font></td>" & vbCrLf
    '        strBC3Body += "<td><a href='jaringan.asp?id=" & aloksa2ki & "'>" & aloksa2ki & "/" & kaki2ki & "</a></td>" & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td>D-line Akhir Kanan</td>" & vbCrLf
    '        strBC3Body += "<td>:</td>" & vbCrLf
    '        strBC3Body += "<td>" & vbCrLf
    '        If a2 <> akhirsa2ka Then
    '            If Len(akhirsa2ka) = 7 Or Len(akhirsa2ka) = 8 Then
    '                akhirsa2ka = akhirsa2ka
    '            Else
    '                If Len(akhirsa2ka) = 7 Then
    '                    akhirsa2ka = Left(akhirsa2ka, 7)
    '                Else
    '                    If Len(akhirsa2ka) = 8 Then
    '                        akhirsa2ka = Left(akhirsa2ka, 8)
    '                    End If
    '                End If
    '            End If
    '            strBC3Body += "<a href='jaringan.asp?id=" & akhirsa2ka & "'>" & akhirsa2ka & "</a> " & vbCrLf
    '        End If
    '        strBC3Body += "</td>" & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td>Placement</font></td>" & vbCrLf
    '        strBC3Body += "<td>:</td>" & vbCrLf
    '        strBC3Body += "<td><a href='jaringan.asp?id=" & aloksa2ka & "'>" & aloksa2ka & "/" & kaki2ka & "</a></td></tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td><font color='#008000'>PV Grup Kiri</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#008000'>:</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#008000'>" & FormatNumber(pvkiri3, 2) & " </font></td> " & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td><font color='#008000'>BV Grup Kiri</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#008000'>:</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#008000'>" & FormatNumber(bvkiri3, 2) & " </font></td> " & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td><font color='#000080'>PV Grup Kanan</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#000080'>:</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#000080'>" & FormatNumber(pvkanan3, 2) & " </font></td> " & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td><font color='#000080'>BV Grup Kanan</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#000080'>:</font></td>" & vbCrLf
    '        strBC3Body += "<td><font color='#000080'>" & FormatNumber(bvkanan3, 2) & " </font></td> " & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "</table>" & vbCrLf
    '    Else
    '        strBC3Body += "<table class='table table-hover table-striped table-bordered table-responsive table6'>" & vbCrLf
    '        strBC3Body += "<tr>" & vbCrLf
    '        strBC3Body += "<td><p >BC-3 belum tersedia</p></td>" & vbCrLf
    '        strBC3Body += "</tr>" & vbCrLf
    '        strBC3Body += "</table>" & vbCrLf
    '    End If

    '    '  boxbody_BC3.InnerHtml = strBC3Body
    'End Sub
End Class

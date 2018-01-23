<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="stock_cetak.aspx.vb" Inherits="MobileStockiest_stock_cetak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
	    .height {
		    min-height: 200px;
	    }

	    .icon {
		    font-size: 47px;
		    color: #5CB85C;
	    }

	    .table > tfoot > tr > .emptyrow {
		    border-top: none;
	    }

	    .table > tbody > tr > .emptyrow {
		    border-top: none;
	    }

	    .table > thead > tr > .emptyrow {
		    border-bottom: none;
	    }

	    .table > tfoot > tr > .highrow {
		    border-top: 3px solid;
	    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
     <section class="content-header" style="background-color:white;">
         <div class="panel panel-default">
             <div class="panel-body">
                 <div class="row">
		            <div style="padding: 20px 20px 5px 20px" class="col-xs-0">
        	            <div class="col-md-2">
          		            <div class="panel-body"> <img src="../assets/img/logo.jpg" width="143" height="100"></div>
        	            </div>
			            <div class="col-md-1">
				            <strong><%=perush_dc%><br>
							<%=nama_dc%> [<%=no_dc%>]<br>
							<%=alamat_dc%><br>
							<%=alamat_dc2%><br>
							Telp. <%=telp_dc%><br>
							Email: <%=emel_dc%><br>
							<%=web_dc%><br></strong>
			            </div>
        
    		            <div class="col-md-12">
	 			            <div>
					            <h3 class="text-center"><strong>DAFTAR STOCK ITEM PRODUK</strong></h3>
				            </div>
	 			            <div class="row">
        			            <div class="col-md-12">
						            <div class="table-responsive">
							            <table class="table table-condensed">
								            <thead class="table table-bordered">
									            <tr style="background-color:#CCC">
										            <td style="width:5%;" class="table-bordered text-center"><strong>KODE</strong></td>
										            <td class="table-bordered text-center" ><strong>NAMA PRODUK</strong></td>
										            <td class="table-bordered text-center" >ON HAND STOCK</td>
										            <td style="width:15%;" class="table-bordered text-center"><strong>PV</strong></td>
										            <td style="width:15%;" class="table-bordered text-center"><p>TOTAL PV</p></td>
										            <td style="width:15%;" class="table-bordered text-center">HARGA KONSUMEN</td>
										            <td style="width:15%;" class="table-bordered text-center">HARGA DISTRIBUTOR</td>
										            <td style="width:15%;" class="table-bordered text-center">HARGA ORDER</td>
									            </tr>
								            </thead>
								            <tbody class="table table-bordered">
                                                <%
                                                    totpv = 0
                                                    If sort = "nama" Then
                                                        mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by nama"
                                                    Else
                                                        If sort = "kode" Then
                                                            mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by kode"
                                                        Else
                                                            If sort = "jumlah" Then
                                                                mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by jumlah DESC"
                                                            Else
                                                                If sort = "hd" Then
                                                                    mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by hd1 desc, hd2 desc, hd3 desc"
                                                                Else
                                                                    If sort = "hk" Then
                                                                        mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by hk1 desc, hk2 desc, hk3 desc"
                                                                    Else
                                                                        If sort = "PV" Then
                                                                            mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by pv desc"
                                                                        Else
                                                                            If sort = "BV" Then
                                                                                mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by bv desc"
                                                                            Else
                                                                                mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' order by kode"
                                                                            End If
                                                                        End If
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    End If
                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If Not mlDR.HasRows Then
                                                    %>
                                                <tr>
									                <td colspan="8" class="table-bordered text-center">&nbsp;</td>
								                </tr>
                                                <%
                                                    End If

                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)

                                                        For aaaeqSSS = 1 To mlDT.Rows.Count - 1
                                                            PV = mlDT.Rows(aaaeqSSS)("pv")
                                                            bv = mlDT.Rows(aaaeqSSS)("bv")
                                                            jumlah = mlDT.Rows(aaaeqSSS)("jumlah")
                                                            kode = mlDT.Rows(aaaeqSSS)("kode")
                                                            gg = mlDT.Rows(aaaeqSSS)("grp")

                                                            If mlDT.Rows(aaaeqSSS)("jumlah") = 0 Or mlDT.Rows(aaaeqSSS)("jumlah") <= 0 Then
                                                                bgcolor = "#EFDEDE"
                                                            Else
                                                                bgcolor = "#FFFFFF"
                                                            End If

                                                            If gg = "PRD" Then
                                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                                                ' POTONG STOCK YANG DIALOKASIKAN UNTUK STARTER KIT
                                                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                                                ggg = "AKT"
                                                                ggg1 = "UPG"
                                                                ggg2 = "REN"
                                                                jumlahalokakt = 0
                                                                mlQuery2 = "SELECT kode,jumlah FROM " & namatabel & " where nopos like '" & mypos & "' and (grp like '" & ggg & "' or grp like '" & ggg1 & "' or grp like '" & ggg2 & "')"
                                                                mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                                If mlDR2.HasRows Then
                                                                    mlDT2 = New Data.DataTable
                                                                    mlDT2.Load(mlDR2)

                                                                    For aaaeqSSSK = 1 To mlDT2.Rows.Count - 1
                                                                        kode1 = mlDT2.Rows(aaaeqSSS)("kode")
                                                                        jumlah1 = mlDT2.Rows(aaaeqSSS)("jumlah")

                                                                        mlQuery3 = "SELECT * FROM st_tipe_paket_jumlah where paket like '" & kode1 & "' and kode like '" & kode & "'"
                                                                        mlDR3 = mlOBJGS.DbRecordset(mlQuery3, mpMODULEID, mlCOMPANYID)
                                                                        mlDR3.Read()

                                                                        If Not mlDR3.HasRows Then
                                                                            jumakt = 0
                                                                        Else
                                                                            jumakt = mlDR3("jumlah")
                                                                        End If
                                                                        mlDR3.Close()

                                                                        jumpaket = (jumlah1 * jumakt)
                                                                        jumlahalokakt = jumlahalokakt + jumpaket
                                                                    Next
                                                                End If
                                                                mlDR2.Close()

                                                                jumbutuhakt = jumlahalokakt
                                                            Else
                                                                jumbutuhakt = 0
                                                            End If


                                                            kd1 = ""
                                                            jm1 = 0
                                                            kd2 = ""
                                                            jm2 = 0
                                                            kd3 = ""
                                                            jm3 = 0
                                                            kd4 = ""
                                                            jm4 = 0
                                                            kd5 = ""
                                                            jm5 = 0
                                                            kd6 = ""
                                                            jm6 = 0
                                                            kd7 = ""
                                                            jm7 = 0
                                                            'jumreal = 0
                                                            jumreal = jumlah - jumbutuhakt

                                                            If gg = "AKT" Or gg = "UPG" Or gg = "REN" Then
                                                                jumreal = jumlah - jumbutuhakt
                                                                ggg = "AKT"
                                                                kebrapa = 0
                                                                mlQuery2 = "SELECT kode,jumlah FROM st_tipe_paket_jumlah where paket like '" & kode & "'"
                                                                mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                                If mlDR2.HasRows Then
                                                                    mlDT2 = New Data.DataTable
                                                                    mlDT2.Load(mlDR2)
                                                                    For aaaeqSSSK = 1 To mlDT2.Rows.Count - 1
                                                                        If kebrapa = 0 Then
                                                                            kd1 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                            jm1 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                            kd2 = ""
                                                                            jm2 = ""
                                                                            kd3 = ""
                                                                            jm3 = ""
                                                                            kd4 = ""
                                                                            jm4 = ""
                                                                            kd5 = ""
                                                                            jm5 = ""
                                                                            kd6 = ""
                                                                            jm6 = ""
                                                                            kd7 = ""
                                                                            jm7 = ""
                                                                            kd8 = ""
                                                                            jm8 = ""
                                                                        Else
                                                                            If kebrapa = 1 Then
                                                                                kd2 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                jm2 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                kd3 = ""
                                                                                jm3 = ""
                                                                                kd4 = ""
                                                                                jm4 = ""
                                                                                kd5 = ""
                                                                                jm5 = ""
                                                                                kd6 = ""
                                                                                jm6 = ""
                                                                                kd7 = ""
                                                                                jm7 = ""
                                                                                kd8 = ""
                                                                                jm8 = ""
                                                                            Else
                                                                                If kebrapa = 2 Then
                                                                                    kd3 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                    jm3 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                    kd4 = ""
                                                                                    jm4 = ""
                                                                                    kd5 = ""
                                                                                    jm5 = ""
                                                                                    kd6 = ""
                                                                                    jm6 = ""
                                                                                    kd7 = ""
                                                                                    jm7 = ""
                                                                                    kd8 = ""
                                                                                    jm8 = ""
                                                                                Else
                                                                                    If kebrapa = 3 Then
                                                                                        kd4 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                        jm4 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                        kd5 = ""
                                                                                        jm5 = ""
                                                                                        kd6 = ""
                                                                                        jm6 = ""
                                                                                        kd7 = ""
                                                                                        jm7 = ""
                                                                                        kd8 = ""
                                                                                        jm8 = ""
                                                                                    Else
                                                                                        If kebrapa = 4 Then
                                                                                            kd5 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                            jm5 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                            kd6 = ""
                                                                                            jm6 = ""
                                                                                            kd7 = ""
                                                                                            jm7 = ""
                                                                                            kd8 = ""
                                                                                            jm8 = ""
                                                                                        Else
                                                                                            If kebrapa = 5 Then
                                                                                                kd6 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                jm6 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                kd7 = ""
                                                                                                jm7 = ""
                                                                                                kd8 = ""
                                                                                                jm8 = ""
                                                                                            Else
                                                                                                If kebrapa = 6 Then
                                                                                                    kd7 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                    jm7 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                    kd8 = ""
                                                                                                    jm8 = ""
                                                                                                Else
                                                                                                    If kebrapa = 7 Then
                                                                                                        kd8 = mlDT2.Rows(aaaeqSSSK)("kode")
                                                                                                        jm8 = mlDT2.Rows(aaaeqSSSK)("jumlah") * jumreal
                                                                                                    End If
                                                                                                End If
                                                                                            End If
                                                                                        End If
                                                                                    End If
                                                                                End If
                                                                            End If
                                                                        End If
                                                                        kebrapa = kebrapa + 1
                                                                    Next
                                                                End If
                                                                mlDR2.Close()
                                                            End If

                                                            If pos_area = "1" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("jumlah")("hd1")
                                                                hk = mlDT.Rows(aaaeqSSS)("jumlah")("hk1")
                                                                kusus1 = mlDT.Rows(aaaeqSSS)("jumlah")("khususmc1")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus1 <> 0 Then
                                                                    hppku = kusus1
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "2" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("jumlah")("hd2")
                                                                hk = mlDT.Rows(aaaeqSSS)("jumlah")("hk2")
                                                                kusus2 = mlDT.Rows(aaaeqSSS)("jumlah")("khususmc2")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus2 <> 0 Then
                                                                    hppku = kusus2
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "3" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("jumlah")("hd3")
                                                                hk = mlDT.Rows(aaaeqSSS)("jumlah")("hk3")
                                                                kusus3 = mlDT.Rows(aaaeqSSS)("jumlah")("khususmc3")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus3 <> 0 Then
                                                                    hppku = kusus3
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "4" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("jumlah")("hd4")
                                                                hk = mlDT.Rows(aaaeqSSS)("jumlah")("hk4")
                                                                kusus4 = mlDT.Rows(aaaeqSSS)("jumlah")("khususmc4")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus4 <> 0 Then
                                                                    hppku = kusus4
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            If pos_area = "5" Then
                                                                hd = mlDT.Rows(aaaeqSSS)("jumlah")("hd5")
                                                                hk = mlDT.Rows(aaaeqSSS)("jumlah")("hk5")
                                                                kusus5 = mlDT.Rows(aaaeqSSS)("jumlah")("khususmc5")
                                                                hppku = 0
                                                                hpp = 0
                                                                If UCase(kelasdc) = "M" And kusus5 <> 0 Then
                                                                    hppku = kusus5
                                                                Else
                                                                    pot = ((PV * disk_mc) / 100) * kurs
                                                                    hpp = hd - pot
                                                                End If
                                                            End If

                                                            totpv = totpv + (PV * jumreal)
                                                %>
                                                <tr>
									                <td class="table-bordered text-left">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("kode")%></td>
									                <td class="table-bordered text-left">
                                                        &nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("nama")%> 
														<% If kd1<> "" then%>
															<br>&nbsp;&nbsp;Terdiri 
															dari : <br>
															&nbsp;&nbsp;<%=kd1%> = <%=FormatNumber(jm1, 0)%>
														<%end if
														if kd2<>"" then %>
															<br>&nbsp;&nbsp;<%=kd2%> = <%=FormatNumber(jm2, 0)%>
														<%end if
														if kd3<>"" then %>																
															<br>&nbsp;&nbsp;<%=kd3%> = <%=FormatNumber(jm3, 0)%>
														<%end if
														if kd4<>"" then %>																
															<br>&nbsp;&nbsp;<%=kd4%> = <%=FormatNumber(jm4, 0)%>
														<%end if
														if kd5<>"" then %>																
															<br>&nbsp;&nbsp;<%=kd5%> = <%=FormatNumber(jm5, 0)%>
														<%end if
														if kd6<>"" then %>																
															<br>&nbsp;&nbsp;<%=kd6%> = <%=FormatNumber(jm6, 0)%>
														<%end if
														if kd7<>"" then %>																
															<br>&nbsp;&nbsp;<%=kd7%> = <%=FormatNumber(jm7, 0)%>
														<%end if		
														if kd8<>"" then %>																
															<br>&nbsp;&nbsp;<%=kd8%> = <%=FormatNumber(jm8, 0)%>
														<%end if%>	
									                </td>
									                <td class="table-bordered text-right">
                                                        <%if gg = "PRD" then %>
														    <%=FormatNumber(jumlah - jumbutuhakt, 0)%>&nbsp;&nbsp;
														<%else%>
															<%=jumlah%>&nbsp;&nbsp;
														<%end if%>
									                </td>
									                <td class="table-bordered text-right"><%=FormatNumber(PV, 2)%>&nbsp;&nbsp;</td>
									                <td class="table-bordered text-right">
                                                        <%if gg = "PRD" then %>
															<%=FormatNumber(PV * (jumlah - jumbutuhakt), 2)%>&nbsp;&nbsp;
														<%else%>
															<%=FormatNumber(PV * jumlah, 2)%>&nbsp;&nbsp;
														<%end if%>
									                </td>
									                <td class="table-bordered text-right">Rp <%=FormatNumber(hk, 0)%>,-&nbsp;&nbsp;</td>
									                <td class="table-bordered text-right">Rp <%=FormatNumber(hd, 0)%>,-&nbsp;&nbsp;</td>
									                <td class="table-bordered text-right">
                                                        Rp 
														<%if hppku <> 0 then %>
															<%=FormatNumber(hppku, 0)%>
														<%else%>
															<%=FormatNumber(hpp, 0)%>
														<%end if%>
														,-&nbsp;&nbsp;
									                </td>
								                </tr>
                                                <%
                                                        Next
                                                    End If
                                                    mlDR.Close()
                                                %>
                                                <tr>
									                <td colspan="4" class="table-bordered text-right">Total PV</td>
									                <td class="table-bordered text-right"><b><%=FormatNumber(totpv, 2)%></b></td>
									                <td colspan="3" class="table-bordered text-right">&nbsp;</td>
								                </tr>
							                </tbody>
					                    </table>
				                    </div>
        	                    </div>
    	                    </div>
	                    </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-6">
                <label></label>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-6">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>


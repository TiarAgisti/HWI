<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="kartustock_cetak.aspx.vb" Inherits="MobileStockiest_kartustock_cetak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-body">
			    <div class="row">
				    <div style="padding: 10px 20px 0px 20px" class="col-xs-12">
					    <div class="row">
						    <div class="col-md-2">
							    <div class="panel-body">
								    <img src="../assets/img/logo.jpg" width="143" height="100">
							    </div>
						    </div>
						    <div class="col-md-10">
							    <div class="panel-body">
								    <strong><%=perush_dc%><br>
								    <%=nama_dc%> [<%=no_dc%>]<br>
								    <%=alamat_dc%><br>
								    <%=alamat_dc2%><br>
								    Telp. <%=telp_dc%><br>
								    Email: <%=emel_dc%><br>
								    <%=web_dc%><br></strong>
							    </div>
						    </div>
					    </div>
				    </div>
			    </div>
			    <div class="panel panel-default">
				    <div class="panel-heading">
					    <h3 class=" text-center panel-title"><strong>KARTU STOCK</strong></h3>
				    </div>
                    <%'if lanjut = "T" then %>
        		    <div class="panel-body">
					    <form>
						    <div class="row">
        					    <div style="padding: 10px 20px 0px 20px" class="col-xs-12">
            					    <div class="row">
									    <div class="col-md-2">
										    <div class="panel-body">
											    <img src="../<%=foto%>" width="143" height="100">
										    </div>
									    </div>
									    <div class="col-md-10">
										    <div class="panel-body">
											    <strong><%=nama%><br>
											    PV :&nbsp;<%=formatnumber(pv,2)%>&nbsp;&nbsp;-<br>
											    BV :&nbsp;<%=formatnumber(bv,2)%><br>
											    <%=info%><br></strong>
										    </div>
									    </div>
            					    </div>
        					    </div>
    					    </div>
					    </form>
					    <div class="col-md-12" style="padding-top: 20px">
            			    <div class="table-responsive">
							    <table class="table table-condensed table-bordered">
                                    <thead class="table table-bordered">
                                        <tr class="table-bordered">
                                            <th rowspan="2" style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Tanggal</div>
                                            </th>
                                            <th colspan="4" style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Transaksi</div>
                                            </th>
                                            <th rowspan="2" style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Referensi</div>
                                            </th>
                                            <th rowspan="2" style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Keterangan</div>
                                            </th>
                                        </tr>
                                        <tr class="table-bordered">
                                            <th style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Awal</div>
                                            </th>
                                            <th style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Masuk</div>
                                            </th>
                                            <th style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Keluar</div>
                                            </th>
                                            <th style="background-color:#E4E4E4;" class="table-bordered">
                                                <div style="text-align:center;">Akhir</div>
                                            </th>
                                        </tr>
                                    </thead>
							        <tbody class="table table-bordered">
                                        <%
                                            mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by tgl desc, id desc"
                                            mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                            If Not mlDR.HasRows Then
                                        %>
                                         <tr>
                                            <td colspan="11" class="table-bordered text-center">
                                                <u style="color:#000000">Tidak ada transaksi penjualan produk</u>
                                            </td>
                                        </tr>
                                        <%
                End If
                If mlDR.HasRows Then
                    mlDT = New Data.DataTable
                    mlDT.Load(mlDR)
                    For aaaeqSSS = 1 To mlDT.Rows.Count - 1
                        tgl = mlDT.Rows(aaaeqSSS)("tgl")
                        masuk = mlDT.Rows(aaaeqSSS)("masuk")
                        awal = mlDT.Rows(aaaeqSSS)("awal")
                        keluar = mlDT.Rows(aaaeqSSS)("keluar")
                        akhir = mlDT.Rows(aaaeqSSS)("akhir")
                        ket = mlDT.Rows(aaaeqSSS)("keterangan")
                                        %>
                                         <tr class="table-bordered">
                                            <td style="text-align:right;" class="table-bordered">&nbsp;&nbsp;<%=tgl%></td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(awal, 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(masuk, 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(keluar, 0)%>&nbsp;&nbsp</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(akhir, 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:center;" class="table-bordered">
                                                <%if ket = "Order Produk" then %>
												&nbsp;&nbsp;<a href="#">
                                                <span onClick="javascript:window.open('mc_cetak_invoice_perdana.asp?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=session("menu_id")%>&asal=normal', 'HelpWindow','scrollbars=yes, resizable=yes
                                                    , height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
												</a>
												<%else%>
												    <%If ket = "Order Perdana MC" Then %>
													&nbsp;&nbsp;<a href="#">
                                                        <span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>&asal=perdana', 'HelpWindow'
                                                            ,'scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
													<%Else%>
													    <%If Left(ket, 23) = "Order Paket Pendaftaran" Then %>
														&nbsp;&nbsp;<a href="#">
                                                        <span onClick="javascript:window.open('mc_cetak_invoice_akt.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow','scrollbars=yes
                                                            , resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
														<%Else%>
														    <%If ket = "Penjualan Produk" Then %>
																&nbsp;&nbsp;<a href="#">
                                                                    <span onClick="javascript:window.open('sale_cetak_invoice_prd.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow','scrollbars=yes
                                                                        , resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
															<%Else%>
																<%If ket = "Penjualan Pendaftaran" Then %>
																&nbsp;&nbsp;<a href="#">
                                                                    <span onClick="javascript:window.open('sale_cetak_invoice_daftar.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow','scrollbars=yes
                                                                        , resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
																<%Else%>
																    <%If ket = "Penjualan Upgrade" Then %>
																    &nbsp;&nbsp;<a href="#">
                                                                        <span onClick="javascript:window.open('sale_cetak_invoice_upgrade.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow','scrollbars=yes
                                                                            , resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
																    <%Else%>
																        <%If ket = "Produk Penjualan Upgrade" Then %>
																        &nbsp;&nbsp;<a href="#">
                                                                            <span onClick="javascript:window.open('sale_cetak_invoice_upgrade.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow'
                                                                                ,'scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
																        <%Else%>
																            <%If Left(ket, 28) = "Penjualan Produk Deposit PV" Then  %>
																            &nbsp;&nbsp;<a href="#">
                                                                                <span onClick="javascript:window.open('sale_cetak_invoice_prd_autosave.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow'
                                                                                    ,'scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
																            <%Else%>																	
																                <%If ket = "Produk Penjualan Pendaftaran" Then %>
																                &nbsp;&nbsp;<a href="#">
                                                                                    <span onClick="javascript:window.open('sale_cetak_invoice_daftar.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span></a>
																                <%End if%>
																            <%end if%>	
																        <%end if%>
																    <%end if%>															
															    <%end if%>															
														    <%end if%>
													    <%end if%>
												    <%end if%>
											    <%end if%>

                                            </td>
                                            <td style="text-align:right;" class="table-bordered">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("keterangan")%></td>
                                        </tr>
                                        <%
                    Next
                End If
                mlDR.Close()
                                        %>
                                    </tbody>
							    </table>
						    </div>
        			    </div>
				    </div>
			    </div>
		    </div>
        </div>
        <div style="padding: 10px 20px 20px 10px">
            <div class="col-md-3">
                <label></label>
            </div>
        </div> 
    </section>
</asp:Content>


<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_renewal_inv.aspx.vb" Inherits="MobileStockiest_sale_renewal_inv" %>

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
        <div class="panel panel-default" style="margin: 5px">
            <div class="panel-heading">
                <h3 class="text-center panel-title"><strong>INVOICE RENEWAL</strong></h3>
            </div>
            <div class="panel-body">
			    <div class="row">
                    <div class="row">
                        <div style="padding: 20px 20px 5px 20px" class="col-xs-0">
                            <div class="col-md-2">
                                <div class="panel-body"> 
                                    <img src="../assets/img/logo.jpg" width="143" height="100">
                                </div>
                            </div>
                            <%if lanjut = "T" then %>
                            <div class="col-md-1">
                               <strong><%=perush_dc%></strong><br>
						        <%=nama_dc%> [<%=no_dc%>]<br>
						        <%=alamat_dc%><br><br>
						        <%=alamat_dc2%><br>
						        Telp. <%=telp_dc%><br>
						        Email:&nbsp;<%=emel_dc%><br>
						        <%=web_dc%><br>
                            </div>
                            <div class="col-md-5 col-md-offset-4">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <div class="text-center">
                                            <strong>INVOICE PAKET RENEWAL</strong><br/>
                                            Bulan PV : <%=MonthName(alokbulan)%>&nbsp;<%=aloktahun%><br/>
                                        </div>
                                    </div>
                                    <div class="panel-body">
                                        <table border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width:32%;" class="text-left">No. Invoice</td>
                                                    <td style="width:6%;">:&nbsp;</td>
                                                    <td style="width:62%;"><%=nopajak%></td>
                                                </tr>
                                                <tr>
                                                    <td class="text-left">No. Referensi</td>
                                                    <td>:&nbsp;</td>
                                                    <td><%=noinvo%></td>
                                                </tr>
                                                <tr>
                                                    <td class="text-left">Kepada Yth</td>
                                                    <td>:&nbsp;</td>
                                                    <td><%=UCase(namakon)%></td>
                                                </tr>
                                                <tr>
                                                    <td class="text-left">Tanggal</td>
                                                    <td>:&nbsp;</td>
                                                    <td><%=tgl%></td>
                                                </tr>
                                                <tr>
                                                    <td class="text-left">Nama Kasir</td>
                                                    <td>:&nbsp;</td>
                                                    <td><%=UCase(loguser)%></td>
                                                </tr>
                                                <tr>
                                                    <td class="text-left">No. Distributor</td>
                                                    <td>:&nbsp;</td>
                                                    <td><%=noseri%></td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
	            <div class="row">
                    <div class="col-md-12">
			            <div class="table-responsive">
				            <table class="table table-condensed">
					            <thead class="table table-bordered">
                                    <tr>
                                        <td style="width:30%;" rowspan="2" class="table-bordered text-center"><strong>Paket Renewal</strong></td>
                                        <td style="width:15%;" rowspan="2" class="table-bordered text-center"><strong>Jumlah</strong></td>
                                        <td style="width:20%;" rowspan="2" class="table-bordered text-center"><strong>Harga</strong></td>
                                        <td style="width:15%;" rowspan="2" class="table-bordered text-center"><strong>PV</strong></td>
                                        <td style="width:20%;" rowspan="2" class="table-bordered text-center"><strong>Sub Total</strong></td>
                                    </tr>
					            </thead>
					            <tbody class="table table-bordered">
                                    <tr>
                                        <td class="table-bordered text-left">
                                            <table border="1" style="border-collapse: collapse;width:100%;border-color:#808080;border-spacing:2px;">
											    <tr>
												    <td style="width:50%;text-align:center">
														<table border="0" style="padding:0;border-spacing:0;width:98%;">
														    <tr>
															    <td><label style="color:#000000;"><%=namapaket%> (<%=paket%>)</label></td>
														    </tr>
															<tr>
															    <td>
																    <table border="0" style="padding:0;border-spacing:0;width:100%;">
																    <%if produk1 <> "-" then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk1%></label></td>
																	    </tr>
																    <%end if%>	
																    <%if produk2 <> "-" then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk2%></label></td>
																	    </tr>
																    <%end If%>
																    <%if produk3 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk3%></label></td>
																	    </tr>
																    <%end If%>	
																    <%if produk4 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk4%></label></td>
																	    </tr>
																    <%end If%>	
																    <%if produk5 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk5%></label></td>
																	    </tr>
																    <%end If%>	
																    <%if produk6 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk6%></label></td>
																	    </tr>
																    <%end If%>	
																    <%if produk7 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk7%></label></td>
																	    </tr>
																    <%end If%>		
																    <%if produk8 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk8%></label></td>
																	    </tr>
																    <%end If%>	
																    <%if produk9 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk9%></label></td>
																	    </tr>
																    <%end If%>		
																    <%if produk10 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk10%></label></td>
																	    </tr>
																    <%end if%>		
																    <%if produk11 <> "-" then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk11%></label></td>
																	    </tr>
																    <%end If%>	
																    <%if produk12 <> "-" Then %>
																	    <tr>
																		    <td style="width:16%;text-align:center;"><label style="color:#000000;">-</label></td>
																		    <td><label style="color:#000000;"><%=produk12%></label></td>
																	    </tr>
																    <%end if%>																																																																																																																																																																																																				
																    </table>
																</td>
															</tr>
														</table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td class="table-bordered text-right">1 pcs &nbsp;&nbsp;</td>
                                        <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga, 0)%>,-&nbsp;&nbsp;</td>
                                        <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(PV, 2)%>&nbsp;&nbsp;</td>
                                        <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga, 0)%>,-&nbsp;&nbsp;</td>
                                    </tr>
					            </tbody>
					            <tfoot>
                                    <tr>
                                        <td class="highrow"></td>
                                        <td class="highrow"></td>
                                        <td class="highrow"></td>
                                        <td class="table-bordered highrow text-left">Grand Total</td>
                                        <td class="table-bordered highrow text-right" style="color:#000000;">Rp <%=FormatNumber(harga, 0)%>,-&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left"><strong><u>PEMBAYARAN</u></strong></td>
                                        <td class="table-bordered emptyrow text-right"><strong>&nbsp;</strong></td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left">Tunai</td>
                                        <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(tunai, 0)%>,-&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left">Debit Card</td>
                                        <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(debit, 0)%>,-&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left">Kartu Kredit</td>
                                        <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(cc, 0)%>,-&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Voucher</td>
                                        <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(vouc, 0)%>,-&nbsp;&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left"><strong><u>KEMBALIAN</u></strong></td>
                                        <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(kembalian, 0)%>,-&nbsp;&nbsp;</td>
                                    </tr>
					            </tfoot>
				            </table>
			            </div>
                    </div>
                </div>
                <div class="row">
                    <label>Aksi :</label>
                    <label>
                        &nbsp;&nbsp;
                        <a href="#">
                            <span onClick="javascript:window.open('sale_cetak_invoice_renewal.aspx?noinvo=<%=noinvo%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow'
                                ,'scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none">Print Invoice</span>
                        </a>
                    </label>
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


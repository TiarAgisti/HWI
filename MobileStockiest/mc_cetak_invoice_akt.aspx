<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_cetak_invoice_akt.aspx.vb" Inherits="MobileStockiest_mc_cetak_invoice_akt" %>

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
                    <div style="padding: 20px 20px 5px 20px" class="col-xs-12">
                        <div class="row">
                            <div class="col-md-2">
					            <div class="panel-body">
						            <img src="../assets/img/logo.jpg" width="143" height="100">
					            </div>
                            </div>
				            <div class="col-md-6">
					            <div class="panel-body">
						           <strong><%=perush_dc%></strong><br>
						            <%=nama_dc%> [<%=no_dc%>]<br>
						            <%=alamat_dc%><br><br>
						            <%=alamat_dc2%><br>
						            Telp. <%=telp_dc%><br>
						            Email:&nbsp;<%=emel_dc%><br>
						            <%=web_dc%><br>
					            </div>
                            </div>
                            <div class="col-md-4">
                                <div class="panel panel-default height">
                                    <div class="panel-heading"><strong>INVOICE ORDER PAKET PENDAFTARAN</strong></div>
                                    <div class="panel-body">
                                        <strong>No Invoice: <%=nopajak%></strong><br>
							            <strong>No Referensi: <%=noinvo%></strong><br>
							            <strong>Mobile Ceter Id: <%=nomc%> : <%=UCase(namamc)%></strong><br>
                                        <%if asale = "perdana" then %>
							            <strong>Username Login: <%=ucase(namauser)%></strong><br>
                                        <%end if%>	
							            <strong>Tanggal: <%=tgl%></strong><br>
							            <strong>Nama Kasir: <%=UCase(namakasir)%></strong><br>
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
							            <td style="width:25%;" class="table-bordered text-left"><strong>Paket Pendaftaran</strong></td>
							            <td style="width:5%;" class="table-bordered text-center"><strong>Jumlah</strong></td>
							            <td style="width:10%;" class="table-bordered text-center"><strong>Harga</strong></td>
							            <td style="width:10%;" class="table-bordered text-center"><strong>PV</strong></td>
							            <td style="width:15%;" class="table-bordered text-center"><strong>Subtotal</strong></td>
						              </tr>
					            </thead>
					            <tbody class="table table-bordered">
						            <tr>
							            <td class="table-bordered text-left">
                                            <table class="table-bordered text-center" style="width:98%;">
                                                <tr>
                                                    <td><label style="color:#000000;"><%=namapaket%> (<%=paket%>)</label></td>
                                                </tr>
                                                <tr>
                                                    <td class="table-bordered text-center">
                                                        <table style="width:100%;" class="table table-bordered">
											            <%if produk1 <> "-" Then %>
												            <tr>
													            <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk1%></td>
												            </tr>
											            <%end If%>	
											            <%if produk2 <> "-" Then %>
												            <tr>
													            <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk2%></td>
												            </tr>
											            <%end If%>
											            <%if produk3 <> "-" Then %>
												            <tr>
													            <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk3%></td>
												            </tr>
											            <%end If%>	
											            <%if produk4 <> "-" Then %>
												            <tr>
													            <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk4%></td>
												            </tr>
											            <%end If%>	
										                <%if produk5 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk5%></td>
											                </tr>
										                <%end If%>	
										                <%if produk6 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk6%></td>
											                </tr>
										                <%end If%>	
										                <%if produk7 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk7%></td>
											                </tr>
										                <%end If%>		
										                <%if produk8 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk8%></td>
											                </tr>
										                <%end If%>	
										                <%if produk9 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk9%></td>
											                </tr>
										                <%end If%>		
										                <%if produk10 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk10%></td>
											                </tr>
										                <%end If%>		
										                <%if produk11 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk11%></td>
											                </tr>
										                <%end If%>	
										                <%if produk12 <> "-" Then %>
											                <tr>
												                <td style="width:16%;color:#000000;" class="text-center">-</td>
													            <td style="color:#000000;"><%=produk12%></td>
											                </tr>
										                <%end If%>																																																																																																																																																																																																				
										                </table>			
							                        </td>
                                                </tr>
                                            </table>
							            </td>
							            <td class="table-bordered text-right"><label style="color:#000000;"><%=FormatNumber(jumorder, 0)%> pcs</label>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right"><label style="color:#000000;">Rp <%=FormatNumber(harga, 0)%>,-</label>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right"><label style="color:#000000;"><%=FormatNumber(PV, 2)%></label>&nbsp;&nbsp;</td>
                                        <td class="table-bordered text-right"><label style="color:#000000;">Rp <%=FormatNumber(subtot, 0)%>,-</label>&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td colspan="5" class="table-bordered text-right"><strong>Total</strong></td>
							            <td class="table-bordered text-right"><label style="color:#000000;"><b>Rp <%=FormatNumber(stot, 0)%>,-&nbsp;&nbsp;</b></label></td>
						            </tr>
					            </tbody>
					            <tfoot>
                                    <tr>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="table-bordered highrow text-left">Diskon (%)</td>
							            <td class="table-bordered highrow text-right" style="color:#000000;"><%=FormatNumber(diskon, 2)%>%&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left"><strong>Grand Total</strong></td>
							            <td class="table-bordered emptyrow text-right" style="color:#000000;"><b>Rp <%=FormatNumber(gtot, 0)%>,-&nbsp;&nbsp;</b></td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left"><strong>Pembayaran</strong></td>
							            <td class="table-bordered emptyrow text-right">&nbsp;</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Tunai</td>
							            <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(tunai, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Debit Card</td>
							            <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(debit, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Kartu Kredit</td>
							            <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(cc, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Voucher</td>
							            <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(vouc, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">Total Bayar</td>
							            <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(jumbayar, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">Kembalian</td>
							            <td class="table-bordered emptyrow text-right" style="color:#000000;">Rp <%=FormatNumber(kembalian, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
					            </tfoot>
				            </table>
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
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-6">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>


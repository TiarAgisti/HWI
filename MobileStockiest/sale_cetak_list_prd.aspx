<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_list_prd.aspx.vb" Inherits="MobileStockiest_sale_cetak_list_prd" %>

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
                    <div style="padding: 10px 20px 0px 20px" class="col-xs-12">
                        <div class="row">
                            <div class="col-md-2">
					            <div class="panel-body">
						            <img src="../assets/img/logo.jpg" width="143" height="100">
					            </div>
                            </div>
				            <div class="col-md-10">
					            <div class="panel-body">
						            <strong>Nama Perusahaan</strong><br>
						            Nama DC [No. DC]<br>
						            Alamat DC<br>
						            Alamat DC2<br>
						            Telp.<br>
						            Email:<br>
						            Website DC<br>
					            </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3 class="text-center"><strong>DAFTAR INVOICE PENJUALAN PRODUK<br/>s/d</strong></h3>
	            <div class="row">
                    <div class="col-md-12">
			            <div class="table-responsive">
				            <table class="table table-condensed">
					            <thead class="table table-bordered">
						            <tr>
							            <td style="width:7%;" rowspan="2" class="table-bordered text-center"><strong>Tanggal</strong></td>
							            <td style="width:17%;" rowspan="2" class="table-bordered text-center"><strong>Nomor Referensi</strong></td>
							            <td style="width:6%;" rowspan="2" class="table-bordered text-center"><strong>Nomor Invoice</strong></td>
							            <td style="width:11%;" rowspan="2" class="table-bordered text-center"><strong>No Dist.</strong></td>
							            <td style="width:18%;" rowspan="2" class="table-bordered text-center"><strong>Nama Distributor</strong></td>
							            <td style="width:6%;" rowspan="2" class="table-bordered text-center"><strong>PV</strong></td>
							            <td style="width:7%;" rowspan="2" class="table-bordered text-center"><strong>Nominal</strong></td>
							            <td colspan="4" class="table-bordered text-center"><strong>Pembayaran</strong></td>
						            </tr>
						            <tr>
							            <td style="width:5%;" class="table-bordered text-center"><strong>Tunai</strong></td>
							            <td style="width:9%;" class="table-bordered text-center"><strong>Debit Card</strong></td>
							            <td style="width:8%;" class="table-bordered text-center"><strong>Credit Card</strong></td>
							            <td style="width:6%;" class="table-bordered text-center"><strong>Voucher</strong></td>
						            </tr>
					            </thead>
					            <tbody class="table table-bordered">
						            <tr>
							            <td colspan="11" class="table-bordered text-center">Tidak Ada Transaksi Penjualan Produk</td>
						            </tr>
						            <tr>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
						            </tr>
						            <tr>
							            <td colspan="6" class="table-bordered text-right"><strong>Grandtotal</strong></td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
						            </tr>
					            </tbody>
				            </table>
			            </div>
                    </div>
                </div>
	            <div class="row">
		            <div class="col-md-12">
			            <div class="table-responsive">
				            <table style="width:100%;" border="0">
						        <tr>
							        <td colspan="3"><strong>GRAND TOTAL DARI TANGGAL s/d</strong></td>
						        </tr>
						        <tr>
							        <td style="width:10%;">Tunai</td>
							        <td style="width:5%;">:</td>
							        <td style="width:85%;">Rp,-</td>
						        </tr>
						        <tr>
						            <td>Debit Card</td>
						            <td>:</td>
						            <td><span>Rp,-</span></td>
						        </tr>
						        <tr>
						            <td>Credit Card</td>
						            <td>:</td>
						            <td>Rp,-</td>
						        </tr>
						        <tr>
						            <td>Voucher</td>
						            <td>:</td>
						            <td>Rp,-</td>
						        </tr>
						        <tr>
						            <td><strong>TOTAL</strong></td>
						            <td><strong>:</strong></td>
						            <td><strong>Rp,-</strong></td>
						        </tr>
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
    </section>
</asp:Content>


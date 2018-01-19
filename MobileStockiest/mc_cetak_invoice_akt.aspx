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
						            <strong>Nama Perusahaan</strong><br>
						            Nama DC [No. DC]<br>
						            Alamat DC<br>
						            Alamat DC2<br>
						            Telp.<br>
						            Email:<br>
						            Website DC<br>
					            </div>
                            </div>
                            <div class="col-md-4">
                                <div class="panel panel-default height">
                                    <div class="panel-heading"><strong>INVOICE ORDER PAKET PENDAFTARAN</strong></div>
                                    <div class="panel-body">
                                        <strong>No Invoice: </strong><br>
							            <strong>No Referensi: </strong><br>
							            <strong>Mobile Ceter Id: </strong><br>
							            <strong>Username Login: </strong><br>
							            <strong>Tanggal: </strong><br>
							            <strong>Nama Kasir: </strong><br>
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
							            <td style="width:5%;" class="table-bordered text-center"><strong>No.</strong></td>
							            <td style="width:25%;" class="table-bordered text-left"><strong>Paket Pendaftaran</strong></td>
							            <td style="width:5%;" class="table-bordered text-center"><strong>Jumlah</strong></td>
							            <td style="width:10%;" class="table-bordered text-center"><strong>Harga</strong></td>
							            <td style="width:10%;" class="table-bordered text-center"><strong>PV</strong></td>
							            <td style="width:15%;" class="table-bordered text-center"><strong>Subtotal</strong></td>
						              </tr>
					            </thead>
					            <tbody class="table table-bordered">
						            <tr>
							            <td class="table-bordered text-center">1</td>
							            <td class="table-bordered text-left">Nama Produk</td>
							            <td class="table-bordered text-center">100</td>
							            <td class="table-bordered text-right">Rp. 10.000</td>
							            <td class="table-bordered text-right">Rp. 10.000</td>
							            <td class="table-bordered text-right">Rp. 50.000</td>
						            </tr>
						            <tr>
							            <td colspan="5" class="table-bordered text-right"><strong>Total</strong></td>
							            <td class="table-bordered text-right">Rp. 50.000</td>
						            </tr>
					            </tbody>
					            <tfoot>
                                    <tr>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="table-bordered highrow text-left">Diskon (%)</td>
							            <td class="table-bordered highrow text-right">%</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left"><strong>Grandtotal</strong></td>
							            <td class="table-bordered emptyrow text-right">Rp. 500.000</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left"><strong>Pembayaran</strong></td>
							            <td class="table-bordered emptyrow text-right"></td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Tunai</td>
							            <td class="table-bordered emptyrow text-right">Rp. 500.000</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Debit Card</td>
							            <td class="table-bordered emptyrow text-right">Rp. 500.000</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Kartu Kredit</td>
							            <td class="table-bordered emptyrow text-right">Rp. 500.000</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-right">Voucher</td>
							            <td class="table-bordered emptyrow text-right">Rp. 500.000</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">Total Bayar</td>
							            <td class="table-bordered emptyrow text-right">Rp. 500.000</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">Kembalian</td>
							            <td class="table-bordered emptyrow text-right">Rp. 100.000</td>
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


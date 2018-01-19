<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_invoice_prd.aspx.vb" Inherits="MobileStockiest_sale_cetak_invoice_prd" %>

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
                            &nbsp;<br>
                            &nbsp;<br>
                            &nbsp;<br>
                            &nbsp;<br>
                            Telp:<br>
                            Email:<br>
                        </div>
                        <div class="col-md-5 col-md-offset-4">
                            <div class="panel panel-default height">
                                <div class="panel-body">
                                    <table border="0">
                                        <tbody>
                                            <tr>
                                                <td colspan="3" class="text-center">Bulan PV:</td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">No. Invoice</td>
                                                <td style="width:6%;">:</td>
                                                <td style="width:62%;">0</td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">No. Referensi</td>
                                                <td>:</td>
                                                <td>0</td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Kepada Yth</td>
                                                <td>:</td>
                                                <td>0</td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Alokasi Topup</td>
                                                <td>:</td>
                                                <td>0</td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Tanggal</td>
                                                <td>:</td>
                                                <td>0</td>
                                            </tr>
                                            <tr>
                                                <td class="text-left">Nama Kasir</td>
                                                <td>:</td>
                                                <td>0</td>
                                            </tr>
                                        </tbody>
                                    </table>
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
							            <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>No.</strong></td>
							            <td style="width:24%;" rowspan="2" class="table-bordered text-center"><strong>Item Produk</strong></td>
							            <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>Qty.</strong></td>
							            <td colspan="2" class="table-bordered text-center"><strong>PV</strong></td>
							            <td style="width:19%;" rowspan="2" class="table-bordered text-center"><strong>Harga</strong></td>
							            <td style="width:18%;" rowspan="2" class="table-bordered text-center"><strong>Subtotal</strong></td>
					                </tr>
						            <tr>
							            <td style="width:15%;" class="text-center"><strong>Satuan</strong></td>
							            <td style="width:14%;" class="text-center"><strong>Total</strong></td>
						            </tr>
					            </thead>
					            <tbody class="table table-bordered">
						            <tr>
							            <td class="table-bordered text-center">-</td>
							            <td class="table-bordered text-left">-</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td class="table-bordered text-right">&nbsp;</td>
							            <td class="table-bordered text-right">-</td>
							            <td class="table-bordered text-right">-</td>
						            </tr>
						            <tr>
							            <td colspan="2" class="table-bordered text-right"><strong>SUB GRAND TOTAL</strong></td>
							            <td class="table-bordered text-center">&nbsp;</td>
							            <td colspan="2" class="table-bordered text-right">&nbsp;</td>
							            <td class="table-bordered text-right">&nbsp;</td>
							            <td class="table-bordered text-right"><strong>Rp,-</strong></td>
					                </tr>
					            </tbody>
					            <tfoot>
                                    <tr>
				                        <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="table-bordered highrow text-left">&nbsp; &nbsp; &nbsp; Diskon</td>
							            <td class="table-bordered highrow text-right">Rp,-</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Grand Total</td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
                                    <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left"><strong>PEMBAYARAN</strong></td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
                                    <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Tunai</td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Debit Card</td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Kartu Kredi Kredit</td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
                                    <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Voucher</td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
                                    <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left"> Total Pembayaran</td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
						            <tr>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="emptyrow"></td>
							            <td class="table-bordered emptyrow text-left">Kembalian</td>
							            <td class="table-bordered emptyrow text-right">Rp,-</td>
						            </tr>
					            </tfoot>
				            </table>
			            </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="text-center"><strong> ******SELAMAT !!! ANDA MEMPEROLEH AUTO UPGRADE FAST TRACK******</strong></div>

                    <strong>Nomor Undian Tiket 3rd Anniversarry :</strong><br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    <br>
                    <strong>Nomor Undian Anda (TOPG2) :</strong><br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
                    ,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,<br>
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


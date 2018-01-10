<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_cetak_invoice_perdana.aspx.vb" Inherits="MobileStockiest_mc_cetak_invoice_perdana" %>

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
        <div class="container">
            <div class="container">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                 <div class="row">
                                    <div style="padding: 20px 20px 5px 20px" class="col-xs-0">
                                        <div class="col-md-2">
                                            <div class="panel-body">
                                                <img src="../images/logohwi.png" width="143" height="100">
                                            </div>
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
                                                <div class="panel-heading">
                                                    <div style="text-align:center;">
                                                        <strong> INVOICE PENDAFTARAN MOBILE CENTER INVOICE ORDER PRODUK MOBILE CENTER</strong>
                                                    </div>
                                                </div>
                                                <div class="panel-body">
                                                    <table border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width:32%;text-align:left;">No. Invoice</td>
                                                                <td style="width:6%;">&nbsp;:&nbsp;</td>
                                                                <td style="width:62%;"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align:left;">No. Referensi</td>
                                                                <td>&nbsp;:&nbsp;</td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align:left;">Mobile Center Id.</td>
                                                                <td>&nbsp;:&nbsp;</td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align:left;">Username Login</td>
                                                                <td>&nbsp;:&nbsp;</td>
                                                                <td> </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align:left;">Tanggal </td>
                                                                <td>&nbsp;:&nbsp;</td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="text-align:left;">Nama Kasir</td>
                                                                <td>: </td>
                                                                <td> </td>
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
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-md-12">
			                            <div class="table-responsive">
				                            <table class="table table-condensed">
					                            <thead class="table table-bordered">
						                            <tr>
							                            <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>No.</strong></td>
							                            <td style="width:24%;" rowspan="2" class="table-bordered text-left"><strong>Item Produk</strong></td>
							                            <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>Qty.</strong></td>
							                            <td colspan="2" class="table-bordered text-center"><strong>PV</strong></td>
							                            <td style="width:19%;" rowspan="2" class="table-bordered text-right"><strong>Harga</strong></td>
							                            <td style="width:18%;" rowspan="2" class="table-bordered text-right"><strong>Subtotal</strong></td>
						                            </tr>
						                            <tr>
							                            <td style="width:15%;" class="text-center"><strong>Satuan</strong></td>
							                            <td style="width:14%;" class="text-right"><strong>Total</strong></td>
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
							                            <td colspan="2" class="table-bordered text-right"><strong>TOTAL</strong></td>
							                            <td class="table-bordered text-center">&nbsp;</td>
							                            <td colspan="2" class="table-bordered text-right">&nbsp;</td>
							                            <td class="table-bordered text-right">&nbsp;</td>
							                            <td class="table-bordered text-right">&nbsp;</td>
						                              </tr>
						                            <tr>
					                            </tbody>
					                            <tfoot>
                                                    <tr>
							                            <td class="highrow"></td>
							                            <td class="highrow"></td>
							                            <td class="highrow"></td>
							                            <td class="highrow"></td>
							                            <td class="highrow"></td>
							                            <td class="table-bordered highrow text-left">Diskon(%)</td>
							                            <td class="table-bordered highrow text-right">%</td>
						                            </tr>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-left"><strong>GRAND TOTAL</strong></td>
							                            <td class="table-bordered emptyrow text-right"><strong>Rp,-</strong></td>
						                            </tr>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-left"><strong>PEMBAYARAN</strong></td>
							                            <td class="table-bordered emptyrow text-right"><strong>Rp,-</strong></td>
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


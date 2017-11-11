<%@ Page Language="VB" AutoEventWireup="false" CodeFile="sale_cetak_invoice_daftar.aspx.vb" Inherits="MobileStockiest_sale_cetak_invoice_daftar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>sale_cetak_invoice_daftar</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link rel="stylesheet" type="text/css" href="../bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="../font-awesome/css/font-awesome.min.css" />
    <script type="text/javascript" src="../js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../bootstrap/js/bootstrap.min.js"></script>
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
</head>
<body>
    <div class="container">
        <div class="container">
            <div class="row">
                <div style="padding: 20px 20px 5px 20px" class="col-xs-12">
                    <div class="row">
                        <div class="col-md-2">
					        <div class="panel-body">
						        <img src="img/logo.jpg" width="143" height="100" />
					        </div>
                        </div>
				        <div class="col-md-6">
					        <div class="panel-body">
						        <strong>Nama Perusahaan</strong><br/>
						        Nama DC [No. DC]<br/>
						        Alamat DC<br/>
						        Alamat DC2<br/>
						        Telp.<br/>
						        Email:<br/>
						        Website DC<br/>
					        </div>
                        </div>
                        <div class="col-md-4">
                            <div class="panel panel-default height">
                                <div class="panel-heading text-center"><strong>Bulan PV :</strong></div>
                                <div class="panel-body">
                                    <strong>No Invoice: </strong><br/>
							        <strong>No Referensi: </strong><br/>
							        <strong>Kepada Yth:</strong> [ ]<br/>
							        <strong>Tanggal: </strong><br/>
							        <strong>Nama Kasir: </strong><br/>
							        <strong>No. Distributor: </strong><br/>
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
							        <td width="5%" class="table-bordered text-center"><strong>No.</strong></td>
							        <td width="25%" class="table-bordered text-left"><strong>Paket Pendaftaran</strong></td>
							        <td width="20%" class="table-bordered text-center"><strong>Jumlah</strong></td>
							        <td width="20%" class="table-bordered text-center"><strong>Harga</strong></td>
							        <td width="10%" class="table-bordered text-right"><strong>PV</strong></td>
							        <td width="20%" class="table-bordered text-right"><strong>Subtotal</strong></td>
						        </tr>
					        </thead>
					        <tbody class="table table-bordered">
						        <tr>
							        <td class="table-bordered text-center">1</td>
							        <td class="table-bordered text-left">Nama Pendaftaran</td>
							        <td class="table-bordered text-center">100</td>
							        <td class="table-bordered text-center">Rp. 100.000</td>
							        <td class="table-bordered text-right">Rp. 100.000</td>
							        <td class="table-bordered text-right">Rp. 200.000</td>
						        </tr>
						        <tr>
					        </tbody>
					        <tfoot>
                                <tr>
							        <td class="highrow"></td>
							        <td class="highrow"></td>
							        <td class="highrow"></td>
							        <td class="highrow"></td>
							        <td class="table-bordered highrow text-left">Grandtotal</td>
							        <td class="table-bordered highrow text-right"></td>
						        </tr>
						        <tr>
							        <td class="emptyrow"></td>
							        <td class="emptyrow"></td>
							        <td class="emptyrow"></td>
							        <td class="emptyrow"></td>
							        <td class="table-bordered emptyrow text-left"><span style="text-decoration: underline"><strong>Pembayaran</span></strong></td>
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
							        <td class="table-bordered emptyrow text-left"><span style="text-decoration: underline"><strong>Kembalian</span></strong></td>
							        <td class="table-bordered emptyrow text-right">Rp. 100.000</td>
						        </tr>
					        </tfoot>
				        </table>
			        </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>

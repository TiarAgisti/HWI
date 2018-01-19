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
                            <div class="col-md-1">
                                &nbsp;<br>
                                &nbsp;<br>
                                &nbsp;<br>
                                &nbsp;<br>
                                Telp.<br>
                                Email :<br>
                            </div>
                            <div class="col-md-5 col-md-offset-4">
                                <div class="panel panel-default height">
                                    <div class="panel-heading">
                                        <div class="text-center"><strong>INVOICE RE-ENTRY PAKET FAST TRACK</strong><br/>Bulan PV :<br/></div>
                                    </div>
                                    <div class="panel-body">
                                        <table border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="width:32%;" class="text-left">No. Invoice</td>
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
                                                    <td class="text-left">Tanggal</td>
                                                    <td>:</td>
                                                    <td>0</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-left">Nama Kasir</td>
                                                    <td>:</td>
                                                    <td>0</td>
                                                </tr>
                                                <tr>
                                                    <td class="text-left">No. Distributor</td>
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
                </div>
	            <div class="row">
                    <div class="col-md-12">
			            <div class="table-responsive">
				            <table class="table table-condensed">
					            <thead class="table table-bordered">
                                    <tr>
                                        <td style="width:30%;" rowspan="2" class="table-bordered text-center"><strong>Paket Fast Track</strong></td>
                                        <td style="width:15%;" rowspan="2" class="table-bordered text-center"><strong>Jumlah</strong></td>
                                        <td style="width:20%;" rowspan="2" class="table-bordered text-center"><strong>Harga</strong></td>
                                        <td style="width:15%;" rowspan="2" class="table-bordered text-center"><strong>PV</strong></td>
                                        <td style="width:20%;" rowspan="2" class="table-bordered text-center"><strong>Sub Total</strong></td>
                                    </tr>
					            </thead>
					            <tbody class="table table-bordered">
                                    <tr>
                                        <td class="table-bordered text-left">0</td>
                                        <td class="table-bordered text-right">1 pcs</td>
                                        <td class="table-bordered text-right">Rp,-</td>
                                        <td class="table-bordered text-right">&nbsp;</td>
                                        <td class="table-bordered text-right">Rp,-</td>
                                    </tr>
					            </tbody>
					            <tfoot>
                                    <tr>
                                        <td class="highrow"></td>
                                        <td class="highrow"></td>
                                        <td class="highrow"></td>
                                        <td class="table-bordered highrow text-left">Grand Total</td>
                                        <td class="table-bordered highrow text-right">Rp,-</td>
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
                                        <td class="table-bordered emptyrow text-right">Rp,-</td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left">Debit Card</td>
                                        <td class="table-bordered emptyrow text-right">Rp,-</td>
                                    </tr>
                                    <tr>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="emptyrow"></td>
                                        <td class="table-bordered emptyrow text-left">Kartu Kredit</td>
                                        <td class="table-bordered emptyrow text-right">Rp,-</td>
                                    </tr>
                                    <tr>
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
                                        <td class="table-bordered emptyrow text-left"><strong><u>KEMBALIAN</u></strong></td>
                                        <td class="table-bordered emptyrow text-right">Rp,-</td>
                                    </tr>
					            </tfoot>
				            </table>
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


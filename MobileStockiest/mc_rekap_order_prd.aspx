<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_rekap_order_prd.aspx.vb" Inherits="MobileStockiest_mc_rekap_order_prd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default" style="margin: 5px">
             <div class="panel-heading">
                <h3 class="text-center panel-title"><strong>DAFTAR INVOICE PENJUALAN PRODUK KE MOBILE CENTER</strong></h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form>
                            <table>
		                        <tr>
			                        <td><label>Tanggal</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td><input type="text" name="nama" class="form-control" style="width:250px;"></td>
			                        <td><label>&nbsp;s/d&nbsp;</label></td>
			                        <td><input type="text" name="nama" class="form-control" style="width:250px;"></td>
		                        </tr>
		                        <tr>
			                        <td><label>Kasir</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="kasir" style="width:250px;">
					                        <option value="semua">--ALL--</option>
				                        </select>
			                        </td>
		                        </tr>
                                <tr>
                                    <td style="width:84px;text-align:left;">No. Id. MC.&nbsp;</td>
                                    <td><label>&nbsp;:&nbsp;</label></td>
                                    <td style="width:170px;">
                                        <select class="form-control">
                                            <optgroup label="This is a group">
                                                <option value="12" selected="">This is item 1</option>
                                                <option value="13">This is item 2</option>
                                                <option value="14">This is item 3</option>
                                            </optgroup>
                                        </select>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td style="width:190px;">
                                        <button class="btn btn-default" type="button">Tampilkan</button>
                                    </td>
                                    <td>&nbsp;</td>     													
                                </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="acts" method="post">
                            <table>
		                        <tr>
			                        <td><label style="width:120px;">Urut Berdasarkan</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="sort" style="width:250px;">
											<option value="Bulan" selected>Bulan</option>																																												
											<option value="tanggal">Tanggal</option>
				                        </select>
			                        </td>
			                        <td>&nbsp;</td>
			                        <td><input type="submit" name="btsb2" value="OK" class="btn"></td>
		                        </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <p style="text-align:left;">
                            <b style="color:#FF0000">Ditemukan 0 transaksi&nbsp;&nbsp;&nbsp;</b>
                        </p>
                        <form name="view" method="post">
                             <table>
		                        <tr>
			                        <td><label>Tampilkan Halaman</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="page" style="width:250px;">
					                        <option value="Bulan" selected>Bulan</option>
				                        </select>
			                        </td>
			                        <td>&nbsp;</td>
			                        <td><input type="submit" name="btsb1" value="Tampilkan" class="btn"></td>
		                        </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="col-md-12 col-md-offset-0">
                    <p></p>
                </div>
                <div class="col-lg-offset-8 col-md-2">
                    <label>&nbsp;</label>
                    <label>&nbsp;</label>
                </div>
                <div class="col-lg-offset-0 col-md-2">
                    <img src="../pos/images/print_version.gif">
                    <label>
                        <a href="#">
                            <span>
                                Print Report
                            </span>
                        </a>
                    </label>
                </div>
                <div class="col-md-12">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table class="table table-condensed">
                                <thead class="table table-bordered">
                                    <tr class="table-bordered">
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Tanggal</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Nomor Referensi</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Nomor Invoice</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Kasir</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">No. Id Mobile Center</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Tipe</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Nominal</div>
                                        </th>
                                        <th colspan="4" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Pembayaran</div>
                                        </th>
                                    </tr>
                                    <tr class="table-bordered">
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Tunai</div>
                                        </th>
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Debit Card</div>
                                        </th>
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Credit Card</div>
                                        </th>
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Transfer</div>
                                        </th>
                                    </tr>
                                </thead>
                                <tbody class="table table-bordered">
                                    <tr>
                                        <td colspan="11" class="table-bordered">&nbsp;</td>
                                    </tr>
                                    <tr class="table-bordered">
                                        <td style="text-align:right;" class="table-bordered">A</td>
                                        <td style="text-align:right;" class="table-bordered">B</td>
                                        <td style="text-align:right;" class="table-bordered">C</td>
                                        <td style="text-align:right;" class="table-bordered">D</td>
                                        <td style="text-align:right;" class="table-bordered">E</td>
                                        <td style="text-align:center;" class="table-bordered">Produk Perdana</br>UNKNOWN</td>
                                        <td style="text-align:right;" class="table-bordered">G</td>
                                        <td style="text-align:right;" class="table-bordered">H</td>
                                        <td style="text-align:right;" class="table-bordered">I</td>
                                        <td style="text-align:right;" class="table-bordered">J</td>
                                        <td style="text-align:right;" class="table-bordered">K</td>
                                    </tr>

                                    <tr class="table-bordered">
                                        <td colspan="6" style="text-align:right;" class="table-bordered"><strong>Grand Total</strong></td>
                                        <td style="text-align:right;" class="table-bordered">0</td>
                                        <td style="text-align:right;" class="table-bordered">0</td>
                                        <td style="text-align:right;" class="table-bordered">0</td>
                                        <td style="text-align:right;" class="table-bordered">0</td>
                                        <td style="text-align:right;" class="table-bordered">0</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div>
                        <div class="col-md-4">
                            <div>
                                <div class="table-responsive">
                                    <table border="0" class="table">
                                        <tr>
                                            <td>
                                                <table border="0">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="3"><span class="style3">RINGKASAN TANGGAL s/d</span></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="3"><u><span class="style3"><strong>GRAND TOTAL TABUNGAN</strong></span></u></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                            <td style="width:8%;"><span class="style3">:</span></td>
                                                            <td style="width:72%;"><span class="style3">Rp,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3">Debit Card</span></td>
                                                            <td><span class="style3">:</span></td>
                                                            <td><span class="style3">Rp,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3">Kredi Card</span></td>
                                                            <td><span class="style3">:</span></td>
                                                            <td><span class="style3">Rp,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3">Transfer</span></td>
                                                            <td><span class="style3">:</span></td>
                                                            <td><span class="style3">Rp,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                            <td><span class="style3"><strong>:</strong></span></td>
                                                            <td><span class="style3"><strong>Rp,-</strong></span></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="col-md-4">
                        <div>
                            <div class="table-responsive">
                                <table class="table">
                                    <tr>
                                        <td>
                                            <table border="0">
                                                <thead>
                                                    <tr>
                                                        <th colspan="3">&nbsp;</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><span class="style3">
                                                                <strong>GRAND TOTAL PERDANA</strong>
                                                            </span></u>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                        <td style="width:8%;"><span class="style3">:</span></td>
                                                        <td style="width:72%;"><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Debit Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Kredi Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Transfer</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                        <td><span class="style3"><strong>:</strong></span></td>
                                                        <td><span class="style3"><strong>Rp,-</strong></span></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="col-md-4">
                        <div>
                            <div class="table-responsive">
                                <table class="table">
                                    <tr>
                                        <td>
                                            <table border="0">
                                                <thead>
                                                    <tr>
                                                        <th colspan="3">&nbsp;</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><span class="style3">
                                                                <strong>GRAND TOTAL PRODUK</strong>
                                                            </span></u>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                        <td style="width:8%;"><span class="style3">:</span></td>
                                                        <td style="width:72%;"><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Debit Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Kredi Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Transfer</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                        <td><span class="style3"><strong>:</strong></span></td>
                                                        <td><span class="style3"><strong>Rp,-</strong></span></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
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
    </section>
</asp:Content>


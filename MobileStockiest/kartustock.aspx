<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="kartustock.aspx.vb" Inherits="MobileStockiest_kartustock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title text-center">KARTU STOCK</h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <form name="acts" method="post">
                                    <table>
		                                <tr>
			                                <td><label>Silahkan Pilih Produk</label></td>
			                                <td><label>&nbsp;:&nbsp;</label></td>
			                                <td>
				                                <select class="form-control" name="sort" style="width:250px;">
											        <option value="Bulan" selected>Bulan</option>																																												
											        <option value="tanggal">Tanggal</option>
				                                </select>
			                                </td>
			                                <td>&nbsp;</td>
			                                <td><input type="submit" name="btsb2" value="Tampilkan" class="btn"></td>
		                                </tr>	
	                                </table>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <p style="text-align:left;">
                            <b style="color:#FF0000">Ditemukan transaksi pada kartu stock&nbsp;&nbsp;&nbsp;</b>
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
                
                
                <div class="col-md-12">
                    <table style="width:100%;" border="0">
				        <tr>
					        <td><img src="../assets/img/logo.jpg" width="143" height="100" /></td>
					        <td style="width:90%;"><label>PV : - BV :</label></td>
				        </tr>
			        </table>
		        </div>
		        <div class="col-md-6">
			        <label>Aksi : Simpan ke Excel</label>
		        </div>
		       
                <div style="padding-top: 20px" class="col-md-12">
                    <div class="table-responsive">
                        <table class="table table-bordered table-condensed" style="width:100%;" border="1">
					        <tr>
					            <td style="width:11%;" rowspan="2" class="text-center"><strong>Tanggal</strong></td>
					            <td colspan="4" class="text-center"><strong>Transaksi</strong></td>
					            <td style="width:25%;" rowspan="2" class="text-center"><strong>Referensi</strong></td>
					            <td style="width:34%;" rowspan="2" class="text-center"><strong>Keterangan</strong></td>
					        </tr>
					        <tr>
					            <td style="width:7%;" class="text-center"><strong>Awal</strong></td>
					            <td style="width:7%;" class="text-center"><strong>Masuk</strong></td>
					            <td style="width:8%;" class="text-center"><strong>Keluar</strong></td>
					            <td style="width:8%;" class="text-center"><strong>Akhir<</strong></td>
					        </tr>
					        <tr>
					            <td colspan="7">&nbsp;</td>
					        </tr>
					        <tr>
					            <td>&nbsp;</td>
					            <td>&nbsp;</td>
					            <td>&nbsp;</td>
					            <td>&nbsp;</td>
					            <td>&nbsp;</td>
					            <td>&nbsp;</td>
					            <td>&nbsp;</td>
					        </tr>
				        </table>
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


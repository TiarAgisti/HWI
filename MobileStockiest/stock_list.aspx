<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="stock_list.aspx.vb" Inherits="MobileStockiest_stock_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <%-- <script type="text/javascript" src="../assets/js/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../assets/bootstrap/js/bootstrap.min.js"></script>--%>
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
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="text-center panel-title"><strong>DAFTAR STOCK PRODUK</strong></h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="acts" method="post">
                            <table>
		                        <tr>
			                        <td><label style="width:120px;">Urut</label></td>
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
			                        <td><label style="width:120px;">Tampilkan Halaman</label></td>
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
	                <div>
	                    <div class="row">
                            <div class="col-md-12">
			                    <div class="table-responsive">
				                    <table class="table table-condensed">
					                    <thead class="table table-bordered">
						                    <tr style="background-color:#CCC">
						                        <td style="width:5%;" class="table-bordered text-center"><strong>KODE</strong></td>
						                        <td class="table-bordered text-center" ><strong>NAMA PRODUK</strong></td>
						                        <td class="table-bordered text-center" >ON HAND STOCK</td>
						                        <td style="width:15%;" class="table-bordered text-center"><strong>PV</strong></td>
						                        <td style="width:15%;" class="table-bordered text-center"><p>TOTAL PV</p></td>
						                        <td style="width:15%;" class="table-bordered text-center">HARGA KONSUMEN</td>
						                        <td style="width:15%;" class="table-bordered text-center">HARGA DISTRIBUTOR</td>
						                    </tr>
				                        </thead>
					                    <tbody class="table table-bordered">
						                    <tr>
							                    <td colspan="8" class="table-bordered text-center">
                                                    <u style="color:#000000;">Anda belum memiliki stock produk</u>
							                    </td>
						                    </tr>
						                    <tr>
							                    <td class="table-bordered text-left">&nbsp;</td>
							                    <td class="table-bordered text-left"><p>Terdiri Dari :</p>
						                        <p>=</p>
						                        <p>=</p>
						                        <p>=</p>
						                        <p>=</p>
						                        <p>=</p></td>
							                    <td class="table-bordered text-right">&nbsp;</td>
							                    <td class="table-bordered text-right">&nbsp;</td>
							                    <td class="table-bordered text-right">&nbsp;</td>
							                    <td class="table-bordered text-right">Rp,-</td>
							                    <td class="table-bordered text-right">Rp,-</td>
							                    </tr>
						                    <tr>
						                        <td colspan="4" class="table-bordered text-right">Total PV</td>
						                        <td class="table-bordered text-right">&nbsp;</td>
						                        <td colspan="3" class="table-bordered text-right">&nbsp;</td>
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


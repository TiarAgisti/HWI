<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="kartustock_cetak.aspx.vb" Inherits="MobileStockiest_kartustock_cetak" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
								    <strong>Nama Perusahaan<br>
								    Nama DC [No. DC]<br>
								    Alamat DC<br>
								    Alamat DC2<br>
								    Telp.<br>
								    Email:<br>
								    Website DC<br></strong>
							    </div>
						    </div>
					    </div>
				    </div>
			    </div>
			    <div class="panel panel-default">
				    <div class="panel-heading">
					    <h3 class=" text-center panel-title"><strong>KARTU STOCK</strong></h3>
				    </div>
        		    <div class="panel-body">
					    <form>
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
											    <strong>Nama<br>
											    PV<br>
											    BV<br>
											    Info<br></strong>
										    </div>
									    </div>
            					    </div>
        					    </div>
    					    </div>
					    </form>
					    <div class="col-md-12" style="padding-top: 20px">
            			    <div class="table-responsive">
							    <table class="table table-condensed table-bordered">
							        <tr>
								        <td style="width:14%;" rowspan="2" class="text-center"><strong>Tanggal</strong></td>
								        <td colspan="4" class="text-center"><strong>Transaksi</strong></td>
								        <td rowspan="2" class="text-center"><strong>Referensi</strong></td>
								        <td rowspan="2" class="text-center"><strong>Keterangan</strong></td>
							        </tr>
							        <tr>
								        <td style="width:9%;" rowspan="2" class="text-center"><strong>Awal</strong></td>
								        <td style="width:8%;" rowspan="2" class="text-center"><strong>Masuk</strong></td>
								        <td style="width:10%;" rowspan="2" class="text-center"><strong>Keluar</strong></td>
								        <td style="width:10%;" rowspan="2" class="text-center"><strong>Akhir</strong></td>
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
		    </div>
        </div>
        <div style="padding: 10px 20px 20px 10px">
            <div class="col-md-3">
                <label></label>
            </div>
        </div> 
    </section>
</asp:Content>


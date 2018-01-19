<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="stock_cetak.aspx.vb" Inherits="MobileStockiest_stock_cetak" %>

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
        
    		            <div class="col-md-12">
	 			            <div>
					            <h3 class="text-center"><strong>DAFTAR STOCK ITEM PRODUK</strong></h3>
				            </div>
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
										            <td style="width:15%;" class="table-bordered text-center">HARGA ORDER</td>
									            </tr>
								            </thead>
								            <tbody class="table table-bordered">
								                <tr>
									                <td colspan="8" class="table-bordered text-center">&nbsp;</td>
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


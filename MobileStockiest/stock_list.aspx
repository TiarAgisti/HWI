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
        <div class="container">
            <div class="container">
                <div style="background-color: grey">
                    <h3 style="text-align: center; color: white; font-family: Arial;">DAFTAR STOCK PRODUK</h3>
                </div>
				<table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
				    <tr>
					    <td>&nbsp;</td>
				    </tr>
				    <tr>
					    <td>
					    <div style="text-align:center;">
						    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 98%;">
							    <tr>
								    <td style="vertical-align:top;"></td>
							    </tr>
						    </table>
					    </div>
					    </td>
				    </tr>
					<tr>
				        <td>
				            <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">									
					            <tr>
						            <td Style="width:75px;"><strong>Urut</strong></td>
						            <td style="width:122px;">
                                        <select class="form-control">
                                            <optgroup label="Nama">
                                                <option value="12" selected="">--Nama--</option>
                                                <option value="13">Item 1</option>
                                                <option value="14">Item 2</option>
                                            </optgroup>
                                        </select>
						            </td>
									<td>
										<button class="btn btn-default" type="button">Ok</button>
									</td>														
								</tr>
							</table>
						</td>
                    </tr>					
			    </table>
				    <%--</td>
			    </tr>
			    <tr>
				    <td>--%>
				<table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
				    <tr>
						<td>
						    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
								<tr>
									<td style="width:245px;">												
									    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
                                            <tr>
                                                <td>
                                                    <div class="col-lg-offset-8 col-md-2">
       
                                                        <label>Aksi : </label><%--<img>--%>
                                                        <label>Simpan Ke Excel</label>
                                                    </div>
                                                    <div class="col-lg-offset-0 col-md-2"><%--<img>--%>
                                                        <label>Print Report</label>
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
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </section>
</asp:Content>


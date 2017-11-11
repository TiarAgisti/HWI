<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_rekap_order_ms.aspx.vb" Inherits="MobileStockiest_mc_rekap_order_ms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .col-md-4 div {
	        color: #000;
        }
        .style1 {color: #FF0000}
            .DIV1 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header">
        <div class="text-right">
            <label class="text-right"> 
                Kamis,02 November 2017 10:17:03
            </label>
        </div>
        <h3 class="text-center bg-primary">
            DAFTAR INVOICE PENJUALAN PRODUK KE MOBILE CENTER
        </h3>
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
		    <tr>
			    <td>&nbsp;</td>
			</tr>
			<tr>
				<td>
					<div align="center">
						<table border="0" cellpadding="0" cellspacing="0" width="98%">
							<tr>
							    <td valign="top"></td>
							</tr>
						</table>
					</div>
				</td>
			</tr>
			<tr>
				<td>
				    <div align="center">								
						<table border="0" cellpadding="0" cellspacing="0" width="99%">										
						    <tr>
								<td>
									<table border="0" cellpadding="0" cellspacing="0" width="100%">
										<tr>
											<td>
											    <table border="0" cellpadding="0" cellspacing="0" width="100%">
												    <tr>
														<td width="75">Tanggal</td>
														<td width="170">
                                                            <input class="form-control" type="text">
                                                        </td>
														<td width="25">
														    <div align="center">s/d</div>
														</td>
														<td width="170">
															<input class="form-control" type="text">
														</td>
														<td>&nbsp;</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
											    <table border="0" cellpadding="0" cellspacing="0" width="100%">
											        <tr>
													    <td width="75">Kasir</td>
														<td width="170">
                                                            <select class="form-control">
                                                                <optgroup label="This is a group">
                                                                    <option value="12" selected="">This is item 1</option>
                                                                    <option value="13">This is item 2</option>
                                                                    <option value="14">This is item 3</option>
                                                                </optgroup>
                                                            </select>
														</td>
														<td>&nbsp;</td>
													</tr>
													<tr>
														<td width="64">No. Id. MC.&nbsp;</td>
													    <td width="122">
                                                            <select class="form-control">
                                                                <optgroup label="This is a group">
                                                                    <option value="12" selected="">This is item 1</option>
                                                                    <option value="13">This is item 2</option>
                                                                    <option value="14">This is item 3</option>
                                                                </optgroup>
                                                            </select>
													    </td>
													    <td>
														    <button class="btn btn-default" type="button">Tampilkan</button>
													    </td>													
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
											    <table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td>
														    <table border="0" cellpadding="0" cellspacing="0" width="100%">
															    <tr>
															        <td width="245">												
																	    <table border="0" cellpadding="0" cellspacing="0" width="100%">
																            <div></div>
                                                                            <div></div>
                                                                            <div class="col-md-12 col-md-offset-0">
                                                                                <p></p>
                                                                            </div>
                                                                            <div class="col-lg-offset-8 col-md-2">
                                                                                <label>Aksi : </label>
                                                                                <label>Simpan Ke Excel</label>
                                                                            </div>
                                                                            <div class="col-lg-offset-0 col-md-2">
                                                                                <label>Print Report</label>
                                                                            </div>
                                                                            <div class="col-md-12">
                                                                                <div class="col-md-12">
                                                                                    <div class="table-responsive">
          	                                                                            <table class="table table-condensed">
					                                                                        <thead class="table table-bordered">
                                                                                                <tr class="table-bordered">
                                                                                                    <th rowspan="2" bgcolor="#CCCCCC" class="table-bordered"><div align="center">Tanggal</div></th>
                                                                                                    <th rowspan="2" bgcolor="#CCCCCC" class="table-bordered"><div align="center">Nomor Referensi</div></th>
                                                                                                    <th rowspan="2" bgcolor="#CCCCCC" class="table-bordered"><div align="center">Nomor Invoice</div></th>
                                                                                                    <th rowspan="2" bgcolor="#CCCCCC" class="table-bordered"><div align="center">Kasir</div></th>
                                                                                                    <th rowspan="2" bgcolor="#CCCCCC" class="table-bordered"><div align="center">No. Id Mobile Center</div></th>
                                                                                                    <th rowspan="2" bgcolor="#CCCCCC" class="table-bordered"><div align="center">Tipe</div></th>
                                                                                                    <th rowspan="2" bgcolor="#CCCCCC" class="table-bordered"><div align="center">Nominal</div></th>
                                                                                                    <th colspan="4" bgcolor="#CCCCCC" class="table-bordered"><div align="center">Pembayaran</div></th>
                                                                                                </tr>
                                                                                                <tr class="table-bordered" >
                                                                                                  <th bgcolor="#CCCCCC" class="table-bordered"><div align="center">Tunai</div></th>
                                                                                                  <th bgcolor="#CCCCCC" class="table-bordered"><div align="center">Debit Card</div></th>
                                                                                                  <th bgcolor="#CCCCCC" class="table-bordered"><div align="center">Credit Card</div></th>
                                                                                                  <th bgcolor="#CCCCCC" class="table-bordered"><div align="center">Transfer</div></th>
                                                                                                </tr>
                                                                                            </thead>
                                                                                            <tbody class="table table-bordered" >
                                                                                                <tr>
                                                                                                    <td colspan="11" class="table-bordered">&nbsp;</td>
                                                                                                </tr>
                    
                                                                                                <tr class="table-bordered">
                                                                                                  <td colspan="6" align="right" class="table-bordered"><strong>Grand Total</strong></td>
                                                                                                  <td align="right" class="table-bordered">0</td>
                                                                                                  <td align="right"class="table-bordered">0</td>
                                                                                                  <td align="right"class="table-bordered">0</td>
                                                                                                  <td align="right"class="table-bordered">0</td>
                                                                                                  <td align="right"class="table-bordered">0</td>
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
                                                                                                    <table border="0">
                                                                                                        <thead>
                                                                                                            <tr>
                                                                                                                <th colspan="3">
                                                                                                                    RINGKASAN TANGGAL 
                                                                                                                    <span class="style1">3 Oktober 2017</span> s/d<span class="style1"> 02 November 2017</span>
                                                                                                                </th>
                                                                                                            </tr>
                                                                                                        </thead>
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td colspan="3"><u>GRAND TOTAL TABUNGAN</u></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="20%">Tunai</td>
                                                                                                                <td width="8%">:</td>
                                                                                                                <td width="72%">Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Debit Card</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Kredi Card</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Transfer</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>TOTAL</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
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
                                                                                                    <table border="0">
                                                                                                        <thead>
                                                                                                            <tr>
                                                                                                                <th colspan="3">&nbsp;</th>
                                                                                                            </tr>
                                                                                                        </thead>
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td colspan="3"><u>GRAND TOTAL PERDANA</u></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="20%">Tunai</td>
                                                                                                                <td width="8%">:</td>
                                                                                                                <td width="72%">Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Debit Card</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Kredi Card</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Transfer</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>TOTAL</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
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
                                                                                                    <table border="0">
                                                                                                        <thead>
                                                                                                            <tr>
                                                                                                                <th colspan="3">&nbsp;</th>
                                                                                                            </tr>
                                                                                                        </thead>
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td colspan="3"><u>GRAND TOTAL PRODUK</u></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="20%">Tunai</td>
                                                                                                                <td width="8%">:</td>
                                                                                                                <td width="72%">Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Debit Card</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Kredi Card</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>Transfer</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                              <td>TOTAL</td>
                                                                                                              <td>:</td>
                                                                                                              <td>Rp,-</td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </table>
                                                                                            </div>
                                                                                        </div>          
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                </td>
            </tr>
        </table>
    </section>
</asp:Content>


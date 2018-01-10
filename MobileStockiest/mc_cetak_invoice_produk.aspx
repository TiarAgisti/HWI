<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_cetak_invoice_produk.aspx.vb" Inherits="MobileStockiest_mc_cetak_invoice_produk" %>

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
                                    <div style="padding: 20px 20px 5px 20px" class="col-xs-12">
                                        <div class="row">
                                            <div class="col-md-2">
					                            <div class="panel-body">
						                            <img src="../images/logohwi.png" width="143" height="100">
					                            </div>
                                            </div>
				                            <div class="col-md-6">
					                            <div class="panel-body">
						                            <strong><%=perush_dc%></strong><br>
						                            <%=nama_dc%> [<%=no_dc%>]<br>
						                            <%=alamat_dc%><br><br>
						                            <%=alamat_dc2%><br>
						                            Telp. <%=telp_dc%><br>
						                            Email:&nbsp;<%=emel_dc%><br>
						                            <%=web_dc%><br>
					                            </div>
                                            </div>
                                            <div class="col-md-4">
                                                <div class="panel panel-default height">
                                                    <div class="panel-heading" style="text-align:center;">
                                                        <%if asale = "perdana" then %>
                                                        <strong>INVOICE PENDAFTARAN MOBILE STOCKIEST</strong>
                                                        <%else%>
                                                        <strong>INVOICE ORDER PRODUK MOBILE STOCKIEST</strong>
                                                        <%end if%>
                                                    </div>
                                                    <div class="panel-body">
                                                        <strong>No Invoice: </strong><strong><%=nopajak%></strong><br>
							                            <strong>No Referensi: </strong><strong><%=noinvo%></strong><br>
							                            <strong>Mobile Stockiest Id: </strong><strong><%=nomc%> : <%=ucase(namamc)%></strong><br>
                                                        <%if asale = "perdana" then %>
							                            <strong>Username Login: </strong><strong><%=ucase(namauser)%></strong><br>
                                                        <%end if%>
							                            <strong>Tanggal: </strong><strong>><%=tgl%></strong><br>
							                            <strong>Nama Kasir: </strong><strong><%=ucase(namakasir)%></strong><br>
                                                    </div>
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
						                            <%if no1 <> "" then %>
													<tr>
														<td style="width:5%;" class="table-bordered text-center">
															<label style="color:#000000;"><%=no1%></label>
                                                        </td>
														<td style="width:37%" class="table-bordered">
															<label style="color:#000000;">&nbsp;<%=kdbr1%> - <%=namabr1%></label>
                                                        </td>
														<td style="width:5%;" class="table-bordered text-right">
															<label style="color:#000000;"><%=FormatNumber(jumlah1, 0)%>&nbsp;&nbsp;</label>
                                                        </td>																		
														<td style="width:7%;" class="table-bordered text-right">
															<label style="color:#000000;"><%=FormatNumber(pv1, 2)%>&nbsp;&nbsp;</label>
                                                        </td>
														<td style="width:10%;" class="table-bordered text-right">
															<label style="color:#000000;"><%=FormatNumber(totpv1, 2)%>&nbsp;&nbsp;</label>
                                                        </td>
														<td style="width:17%;" class="table-bordered text-right">
															<label style="color:#000000;">Rp <%=FormatNumber(harga1, 0)%>,-&nbsp;&nbsp;</label>
                                                        </td>
														<td style="width:19%;" class="table-bordered text-right">
															<label style="color:#000000;">Rp <%=FormatNumber(subtot1, 0)%>,-&nbsp;&nbsp;</label>
                                                        </td>
													</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>	
													<%if no2 <> "" then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no2%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr2%> - <%=namabr2%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah2, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv2, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv2, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga2, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot2, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no3 <> "" then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no3%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr3%> - <%=namabr3%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah3, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv3, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv3, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga3, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot3, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no4 <> "" then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no4%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr4%> - <%=namabr4%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah4, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv4, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv4, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga4, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot4, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no5 <> "" Then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no5%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr5%> - <%=namabr5%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah5, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv5, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv5, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga5, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot5, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no6 <> "" then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no6%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr6%> - <%=namabr6%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah6, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv6, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv6, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga6, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot6, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no7 <> "" Then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no7%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr7%> - <%=namabr7%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah7, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv7, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv7, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga7, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot7, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no8 <> "" then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no8%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr8%> - <%=namabr8%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah8, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv8, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv8, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga8, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot8, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no9 <> "" then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no9%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr9%> - <%=namabr9%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah9, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv9, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv9, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga9, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot9, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>
													<%if no10 <> "" then %>
														<tr>
															<td style="width:5%;" class="table-bordered text-center">
															    <label style="color:#000000;"><%=no10%></label>
                                                            </td>
														    <td style="width:37%" class="table-bordered">
															    <label style="color:#000000;">&nbsp;<%=kdbr10%> - <%=namabr10%></label>
                                                            </td>
														    <td style="width:5%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(jumlah10, 0)%>&nbsp;&nbsp;</label>
                                                            </td>																		
														    <td style="width:7%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(pv10, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:10%;" class="table-bordered text-right">
															    <label style="color:#000000;"><%=FormatNumber(totpv10, 2)%>&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:17%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(harga10, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														    <td style="width:19%;" class="table-bordered text-right">
															    <label style="color:#000000;">Rp <%=FormatNumber(subtot10, 0)%>,-&nbsp;&nbsp;</label>
                                                            </td>
														</tr>
													<%else%>
														<tr>
															<td style="width:5%;" class="table-bordered text-center"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:37%;"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:5%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>																		
															<td style="width:7%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:10%;" class="table-bordered text-right">&nbsp;</td>
															<td style="width:17%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
															<td style="width:19%;" class="table-bordered text-right"><label style="color:#000000;">&nbsp;</label></td>
														</tr>
													<%end if%>									
						                            <tr>
							                            <td colspan="2" class="table-bordered text-right"><strong>Sub Total</strong></td>
							                            <td class="table-bordered text-center"><%=FormatNumber(totjum, 0)%>&nbsp;&nbsp;</td>
							                            <td colspan="2" class="table-bordered text-right"><%=FormatNumber(totpv, 2)%>&nbsp;&nbsp;</td>
							                            <td class="table-bordered text-right">&nbsp;</td>
							                            <td class="table-bordered text-right">>Rp <%=FormatNumber(stot, 0)%>,-&nbsp;&nbsp;</td>
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
							                            <td class="table-bordered highrow text-left"><strong>Pembayaran</strong></td>
							                            <td class="table-bordered highrow text-right"></td>
						                            </tr>
                                                    <%if tunai > 0 then %>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-right">Tunai</td>
							                            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(tunai, 0)%>,-&nbsp;&nbsp;</td>
						                            </tr>
                                                    <%end If
                                                        If debit > 0 Then %>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-right">Debit Card</td>
							                            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(debit, 0)%>,-&nbsp;&nbsp;</td>
						                            </tr>
                                                    <%end If
                                                        If cc > 0 Then %>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-right">Kartu Kredit</td>
							                            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(cc, 0)%>,-&nbsp;&nbsp;</td>
						                            </tr>
                                                    <%end If
                                                        If vouc > 0 Then %>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-right">Transfer</td>
							                            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(vouc, 0)%>,-&nbsp;&nbsp;</td>
						                            </tr>
                                                    <%end if%>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-left">Tot Bayar</td>
							                            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(jumbayar, 0)%>,-&nbsp;&nbsp;</td>
						                            </tr>
						                            <tr>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="emptyrow"></td>
							                            <td class="table-bordered emptyrow text-left">Kembalian</td>
							                            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(kembalian, 0)%>,-&nbsp;&nbsp;</td>
						                            </tr>
					                            </tfoot>
				                            </table>
			                            </div>
                                    </div>
                                </div>
                            </div>
                        </div> 
                    </div>
                </div><br /><br />
            </div>
        </div>
        <div style="padding: 10px 20px 20px 10px">
            <div class="col-md-3">
                <label></label>
            </div>
        </div>  
    </section>
</asp:Content>


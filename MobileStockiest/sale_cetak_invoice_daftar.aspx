<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_invoice_daftar.aspx.vb" Inherits="MobileStockiest_sale_cetak_invoice_daftar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <%  If lanjut = "T" Then %>
        <div class="container">
            <div class="container">
                <div class="row">
                    <div style="padding: 20px 20px 5px 20px" class="col-xs-12">
                        <div class="row">
                            <div class="col-md-2">
					            <div class="panel-body">
						            <img src="../images/logohwi.png" width="143" height="100" />
					            </div>
                            </div>
				            <div class="col-md-6">
					            <div class="panel-body">
						            <strong><%=perush_dc%></strong><br/>
						            <%=nama_dc%> [<%=no_dc%>]<br/>
						            <%=alamat_dc%><br/>
						            <%=alamat_dc2%><br/>
						            Telp. <%=telp_dc%><br/>
						            Email: <%=emel_dc%><br/>
						            <%=web_dc%><br/>
					            </div>
                            </div>
                            <div class="col-md-4">
                                <div class="panel panel-default height">
                                    <div class="panel-heading text-center"><strong>Bulan PV :&nbsp;</strong><strong><%=MonthName(alokbulan)%>&nbsp;<%=aloktahun%></strong></div>
                                    <div class="panel-body">
                                        <strong>No Invoice:&nbsp;</strong><strong><%=nopajak%></strong><br/>
							            <strong>No Referensi:&nbsp;</strong><strong><%=noinvo%></strong><br/>
							            <strong>Kepada Yth:&nbsp;</strong><strong>[&nbsp;<%=noseri%>&nbsp;]&nbsp;<%=UCase(namakon)%></strong><br/>
							            <strong>Tanggal:&nbsp;</strong><strong><%=tgl%></strong><br/>
							            <strong>Nama Kasir:&nbsp;</strong><strong><%=ucase(loguser)%></strong><br/>
							            <strong>No. Distributor:&nbsp;</strong><strong><%=noseri%></strong><br/>
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
							            <td style="width:25%;" class="table-bordered text-center"><strong>Paket Pendaftaran</strong></td>
							            <td style="width:20%;" class="table-bordered text-center"><strong>Jumlah</strong></td>
							            <td style="width:20%;" class="table-bordered text-center"><strong>Harga</strong></td>
							            <td style="width:10%;" class="table-bordered text-right"><strong>PV</strong></td>
							            <td style="width:20%;" class="table-bordered text-right"><strong>Subtotal</strong></td>
						            </tr>
					            </thead>
					            <tbody class="table table-bordered">
						            <tr>
							            <td class="table-bordered text-left">
                                            <%=namapaket%> (<%=paket%>) <br />
                                            <%if produk1 <> "-" Then %>
                                                <%=produk1%> <br />
                                            <%end If%>
                                            <%if produk2 <> "-" Then %>
                                                <%=produk2%> <br />
                                            <%end If%>
                                            <%if produk3 <> "-" Then %>
                                                <%=produk3%><br />
                                            <%end If%>
                                             <%if produk4 <> "-" Then %>
                                                <%=produk4%><br />
                                            <%end If%>
                                            <%if produk5 <> "-" Then %>
                                                <%=produk5%><br />
                                            <%end If%>
                                            <%if produk6 <> "-" Then %>
                                                <%=produk6%><br />
                                            <%end If%>
                                            <%if produk7 <> "-" Then %>
                                                <%=produk7%><br />
                                            <%end If%>
                                            <%if produk8 <> "-" Then %>
                                                <%=produk8%><br />
                                            <%end If%>
                                            <%if produk9 <> "-" Then %>
                                                <%=produk9%><br />
                                            <%end If%>
							            </td>
							            <td class="table-bordered text-right">1 pcs</td>
							            <td class="table-bordered text-right">Rp <%=FormatNumber(harga, 0)%>,-</td>
							            <td class="table-bordered text-right"><%=FormatNumber(PV, 2)%></td>
							            <td class="table-bordered text-right">Rp <%=FormatNumber(harga, 0)%>,-</td>
						            </tr>
					            </tbody>
					            <tfoot class="table table-bordered">
                                    <tr>
							            <td  colspan="4" class="table-bordered highrow text-right">Grandtotal</td>
							            <td class="table-bordered highrow text-right">Rp <%=FormatNumber(harga, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td colspan="4" class="table-bordered emptyrow text-right"><span style="text-decoration: underline"><strong>Pembayaran</strong></span></td>
							            <td class="table-bordered emptyrow text-right"></td>
						            </tr>
						            <tr>
							            <td colspan="4" class="table-bordered emptyrow text-right">Tunai</td>
							            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(tunai, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td colspan="4" class="table-bordered emptyrow text-right">Debit Card</td>
							            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(debit, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td colspan="4" class="table-bordered emptyrow text-right">Kartu Kredit</td>
							            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(cc, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td colspan="4" class="table-bordered emptyrow text-right">Voucher</td>
							            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(vouc, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
						            <tr>
							            <td colspan="4" class="table-bordered emptyrow text-right"><span style="text-decoration: underline"><strong>Kembalian</strong></span></td>
							            <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(kembalian, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
					            </tfoot>
				            </table>
			            </div>
                    </div>
                </div>
            </div>
        </div>
        <%end if%>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-12">
                <label></label>
            </div>
        </div>
    </section>
</asp:Content>


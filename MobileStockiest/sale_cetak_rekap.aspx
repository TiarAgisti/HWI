<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_rekap.aspx.vb" Inherits="MobileStockiest_sale_cetak_rekap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
	        <div class="panel-body">
		        <div class="col-md-2" style="padding: 10px 10px 10px 10px">
			        <img src="../images/logohwi.png" width="143" height="100">
		        </div>
		        <div class="col-md-10" style="padding: 10px 10px 10px 10px">
			        <strong><%=perush_dc%></strong><br>
			        <%=nama_dc%> [<%=no_dc%>]<br>
			        <%=alamat_dc%><br>
			        <%=alamat_dc2%><br>
			        Telp. <%=telp_dc%><br>
			        Email: <%=emel_dc%><br>
			       <%=web_dc%><br>
		        </div>
		        <div class="col-md-12">
			        <div class="panel panel-default">
				        <div class="panel-heading">
					        <h3 class="text-center panel-title"><strong>REKAP PENJUALAN PAKET PENDAFTARAN</strong></h3>
				        </div>
				        <div class="panel-body">
					        <div class="table-responsive">
						        <table style="width: 100%" border="0">
							        <tr>
								        <td style="width:9%;">Tanggal</td>
								        <td style="width:3%;">:</td>
								        <td style="width:88%;">&nbsp;<%=tgl1%></td>
							        </tr>
							        <tr>
								        <td>Total Penjualan</td>
								        <td>:</td>
								        <td>&nbsp;Rp <%=FormatNumber(totjualakt, 0)%>,-</td>
							        </tr>
							        <tr>
								        <td colspan="3"><label>&nbsp;</label></td>
							        </tr>
							        <tr>
								        <td colspan="3"><u><strong>Pembayaran</strong></u></td>
							        </tr>
							        <tr>
								        <td>Tunai</td>
								        <td>:</td>
								        <td>&nbsp;Rp <%=FormatNumber(tottunai - kembaliakt, 0)%>,-</td>
							        </tr>
							        <tr>
							          <td>Debit Card</td>
							          <td>:</td>
							          <td>&nbsp;Rp <%=FormatNumber(totdebit, 0)%>,-</td>
							        </tr>
							        <tr>
							          <td>Kartu Kredit</td>
							          <td>:</td>
							          <td>&nbsp;Rp <%=FormatNumber(totcc, 0)%>,-</td>
							        </tr>
							        <tr>
							          <td>Voucher</td>
							          <td>:</td>
							          <td>&nbsp;Rp <%=FormatNumber(totvouc, 0)%>,-</td>
							        </tr>
						        </table>
					        </div>
				        </div>
			        </div>
		        </div>

                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="text-center panel-title"><<strong>REKAP PENJUALAN PRODUK</strong></h3>
                        </div>
                        <div class="panel-body">
			                <div class="table-responsive">
				                <table style="width: 100%" border="0">
						            <tr>
							            <td style="width:9%;">Tanggal</td>
							            <td style="width:3%;">:</td>
							            <td style="width:88%;">&nbsp;<%=tgl1%></td>
						            </tr>
						            <tr>
							            <td>Total Penjualan</td>
							            <td>:</td>
							            <td>&nbsp;Rp <%=FormatNumber(totjualprd, 0)%>,-</td>
						            </tr>
						            <tr>
							            <td colspan="3"><label>&nbsp;</label></td>
						            </tr>
						            <tr>
							            <td colspan="3"><u><strong>Pembayaran</strong></u></td>
						            </tr>
						            <tr>
							            <td>Tunai</td>
							            <td>:</td>
							            <td>&nbsp;Rp <%=FormatNumber(tottunaiprd - kembaliprd, 0)%>,-</td>
						            </tr>
						            <tr>
						              <td>Debit Card</td>
						              <td>:</td>
						              <td>&nbsp;Rp <%=FormatNumber(totdebitprd, 0)%>,-</td>
						            </tr>
						            <tr>
						              <td>Kartu Kredit</td>
						              <td>:</td>
						              <td>&nbsp;Rp <%=FormatNumber(totccprd, 0)%>,-</td>
						            </tr>
						            <tr>
						              <td>Voucher</td>
						              <td>:</td>
						              <td>&nbsp;Rp <%=FormatNumber(totvoucprd, 0)%>,-</td>
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


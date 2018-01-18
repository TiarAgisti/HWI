<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_prd_dist_inv.aspx.vb" Inherits="MobileStockiest_sale_prd_dist_inv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default" style="margin: 5px">
            <div class="panel-heading">
                <h3 class="text-center panel-title"><strong>INVOICE PENJUALAN PRODUK</strong></h3>
            </div>
            <div class="panel-body">
			    <div class="row">
                    <div class="row">
                        <div style="padding: 20px 20px 5px 20px" class="col-xs-12">
                            <div class="row">
                                <div class="col-md-2">
					                <div class="panel-body">
						                <img src="../images/logohwi.png" width="143" height="100">
					                </div>
                                </div>
				                <div class="col-md-5">
					                <div class="panel-body">
						                <%=perush_dc%><br>
						                <%=nama_dc%> [<%=no_dc%>]<br>
						                <%=alamat_dc%><br>
						                <%=alamat_dc2%><br>
						                Telp. <%=telp_dc%><br>
						                Email : <%=emel_dc%><br>
                                        <%=web_dc%><br />
					                </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="panel panel-default height">
                                        <div class="panel-heading text-center"><strong>INVOICE PENJUALAN PRODUK TOP UP</strong><br />Bulan PV :<%=MonthName(alokbulan)%>&nbsp;<%=aloktahun%></div>
                                        <div class="panel-body">
                                            No Invoice &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<%=nopajak%><br>
							                No Referensi &nbsp;&nbsp;&nbsp;:<%=noinvo%><br>
							                Kepada Yth &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<%=nokon%> : <%=UCase(namakon)%><br>
							                Alokasi Top Up :<%=noalok%> : <%=UCase(namalok)%><br>
                                            <%if UCase(tpe) = "TOPUP" Then %>
							                Tanggal&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<%=tgl%><br>
                                            <%end if%>
							                Nama Kasir&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:<%=UCase(namakasir)%><br>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
    
	                <div class="row">
                        <div style="padding: 20px 20px 5px 20px" class="col-md-12">
			                <div class="table-responsive">
				                <table class="table table-condensed">
					                <thead class="table table-bordered">
						                <tr>
							                <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>No.</strong></td>
							                <td style="width:24%;"" rowspan="2" class="table-bordered text-center"><strong>Item Produk</strong></td>
							                <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>Qty.</strong></td>
							                <td colspan="2" class="table-bordered text-center"><strong>PV</strong></td>
							                <td style="width:19%;" rowspan="2" class="table-bordered text-center"><strong>Harga</strong></td>
							                <td style="width:18%;" rowspan="2" class="table-bordered text-center"><strong>Subtotal</strong></td>
						                </tr>
						                <tr>
							                <td style="width:9%;" class="table-bordered text-center"><strong>Satuan</strong></td>
							                <td style="width:10%;" class="table-bordered text-center"><strong>Total</strong></td>
						                </tr>
					                </thead>
					                <tbody class="table table-bordered">
                                        <%if no1 <> "" then %>
						                <tr>
							                <td class="table-bordered text-center"><%=no1%></td>
							                <td class="table-bordered text-left">&nbsp;<%=kdbr1%> - <%=namabr1%></td>
							                <td class="table-bordered text-right"><%=FormatNumber(jumlah1, 0)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(pv1, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(totpv1, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(harga1, 0)%>,-&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(subtot1, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%else%>
                                        <tr>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-left">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
						                </tr>
                                        <%end if%>
                                        <%if no2 <> "" Then %>
						                <tr>
							                <td class="table-bordered text-center"><%=no2%></td>
							                <td class="table-bordered text-left">&nbsp;<%=kdbr2%> - <%=namabr2%></td>
							                <td class="table-bordered text-right"><%=FormatNumber(jumlah2, 0)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(pv2, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(totpv2, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(harga2, 0)%>,-&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(subtot2, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%else%>
                                        <tr>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-left">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
						                </tr>
                                        <%end if%>
                                        <%if no3 <> "" Then %>
						                <tr>
							                <td class="table-bordered text-center"><%=no3%></td>
							                <td class="table-bordered text-left">&nbsp;<%=kdbr3%> - <%=namabr3%></td>
							                <td class="table-bordered text-right"><%=FormatNumber(jumlah3, 0)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(pv3, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(totpv3, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(harga3, 0)%>,-&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(subtot3, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%else%>
                                        <tr>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-left">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
						                </tr>
                                        <%end if%>
                                        <%if no4 <> "" Then %>
						                <tr>
							                <td class="table-bordered text-center"><%=no4%></td>
							                <td class="table-bordered text-left">&nbsp;<%=kdbr4%> - <%=namabr4%></td>
							                <td class="table-bordered text-right"><%=FormatNumber(jumlah4, 0)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(pv4, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(totpv4, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(harga4, 0)%>,-&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(subtot4, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%else%>
                                        <tr>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-left">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
						                </tr>
                                        <%end if%>
                                        <%if no5 <> "" Then %>
						                <tr>
							                <td class="table-bordered text-center"><%=no5%></td>
							                <td class="table-bordered text-left">&nbsp;<%=kdbr5%> - <%=namabr5%></td>
							                <td class="table-bordered text-right"><%=FormatNumber(jumlah5, 0)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(pv5, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(totpv5, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(harga5, 0)%>,-&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(subtot5, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%else%>
                                        <tr>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-left">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
						                </tr>
                                        <%end if%>
                                        <%if no6 <> "" Then %>
						                <tr>
							                <td class="table-bordered text-center"><%=no6%></td>
							                <td class="table-bordered text-left">&nbsp;<%=kdbr6%> - <%=namabr6%></td>
							                <td class="table-bordered text-right"><%=FormatNumber(jumlah6, 0)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(pv6, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(totpv6, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(harga6, 0)%>,-&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(subtot6, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%else%>
                                        <tr>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-left">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
						                </tr>
                                        <%end if%>
                                        <%if no7 <> "" Then %>
						                <tr>
							                <td class="table-bordered text-center"><%=no7%></td>
							                <td class="table-bordered text-left">&nbsp;<%=kdbr7%> - <%=namabr7%></td>
							                <td class="table-bordered text-right"><%=FormatNumber(jumlah7, 0)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(pv7, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right"><%=FormatNumber(totpv7, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(harga7, 0)%>,-&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">Rp <%=FormatNumber(subtot7, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%else%>
                                        <tr>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-left">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-center">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
						                </tr>
                                        <%end if%>
						                <tr>
							                <td colspan="2" class="table-bordered text-right"><strong>SUB GRAND TOTAL</strong></td>
							                <td class="table-bordered text-right"><%=FormatNumber(totjum, 0)%>&nbsp;&nbsp;</td>
							                <td colspan="2" class="table-bordered text-right"><%=FormatNumber(totpv + pvmbah, 2)%>&nbsp;&nbsp;</td>
							                <td class="table-bordered text-right">&nbsp;</td>
							                <td class="table-bordered text-right"><strong>Rp <%=FormatNumber(gtot, 0)%>,-&nbsp;&nbsp;</strong></td>
						                </tr>
					                </tbody>
					                <tfoot>
                                        <%if jumdisk > 0 then %>
						                <tr>
							                <td class="highrow"></td>
							                <td class="highrow"></td>
							                <td class="highrow"></td>
							                <td class="highrow"></td>
							                <td class="highrow"></td>
							                <td class="table-bordered highrow text-left">&nbsp; &nbsp; &nbsp; Diskon</td>
							                <td class="table-bordered highrow text-right">Rp <%=FormatNumber(jumdisk, 0)%>,-&nbsp;&nbsp</td>
						                </tr>
						                <tr>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Grand Total</td>
							                <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(subtote, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%end If%>
						                <tr>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="table-bordered emptyrow text-left"><strong>PEMBAYARAN</strong></td>
							                <td class="table-bordered emptyrow text-right">&nbsp;</td>
						                </tr>
                                        <%if tunai > 0 Then %>
						                <tr>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Tunai</td>
							                <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(tunai, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%end If
                                            If debit > 0 Then%>
						                <tr>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Debit Card</td>
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
							                <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Kartu Kredit</td>
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
							                <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Voucher</td>
							                <td class="table-bordered emptyrow text-right">Rp <%=FormatNumber(vouc, 0)%>,-&nbsp;&nbsp;</td>
						                </tr>
                                        <%end if%>
						                <tr>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="emptyrow"></td>
							                <td class="table-bordered emptyrow text-left">Total Pembayaran</td>
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
                    <%if pvmbah>0 then%>
                    <div class="row">
                        <div class="panel-body">
						   <b><%=ketxtra%></b><br><br>
					    </div>
                    </div>
                    <%end if%>
	                <div class="panel panel-default" style="margin: 5px">
                        <div class="panel-heading text-center">
                            <div class="text-center panel-title">
                                <%if autoupgrade = "T" then %> 
                                <strong>******SELAMAT !!! ANDA MEMPEROLEH AUTO UPGRADE FAST TRACK****** </strong>
                                <%end if%>
                            </div>
                        </div>
                        <div class="panel-body">
	                        <div class="row">
                                 <% if adanomor = "T" Then %>
	                            <div style="padding: 0px 10px 0px 10px" class="col-xs-12">
				                    <div class="row">
                                        <div class="col-md-5">
					                        <div class="panel-body">
					                            <b><u>Nomor Undian Tiket 3rd Anniversary :</u></b>
					                        </div>
                                        </div>
				                    </div>
				                    <div class="row">
                                        <div class="col-md-6">
					                        <div class="panel-body">
                                                <%if noundi0<>"" then %>
													<%=noundi0%>	
												<%  End If%>																			
												<%if noundi1<>"" then %>
													, <%=noundi1%>
												<%  End If%>
												<%if noundi2<>"" then %>
                                                    , <%=noundi2%>
                                                <%end If%>			
												<%if noundi3<>"" then %>
                                                    , <%=noundi3%>
                                                <%end If%>	
                                                <%if noundi4<>"" then %>
                                                    , <%=noundi4%>
                                                <%end If%>	
                                                <%if noundi5<>"" then %>
                                                    , <%=noundi5%>
                                                <%end If%>	
                                                <%if noundi6<>"" then %>
                                                    , <%=noundi6%>
                                                <%end If%>																																																																																								
                                                <%if noundi7<>"" then %>
                                                    , <%=noundi7%>
                                                <%end If%>	
                                                <%if noundi8<>"" then %>
                                                    , <%=noundi8%>
                                                <%end If%>	
												<%if noundi9<>"" then %>
                                                    , <%=noundi9%>
                                                <%end If%>			
                                                <%if noundi10<>"" then %>
                                                    , <%=noundi10%>
                                                <%end If%>				
                                                <%if noundi11<>"" then %>
                                                <br><%=noundi11%>
                                                <%end If%>
                                                <%if noundi12<>"" then %>
                                                    , <%=noundi12%>
                                                <%end If%>			
                                                <%if noundi13<>"" then %>
                                                    , <%=noundi13%>
                                                <%end If%>	
												<%if noundi14<>"" then %>
                                                    , <%=noundi14%>
                                                <%end If%>	
                                                <%if noundi15<>"" then %>
                                                    , <%=noundi15%>
                                                <%end If%>	
                                                <%if noundi16<>"" then %>
                                                    , <%=noundi16%>
                                                <%end If%>																																																																																								
                                                <%if noundi17<>"" then %>
                                                    , <%=noundi17%>
                                                <%end If%>	
                                                <%if noundi18<>"" then %>
                                                    , <%=noundi18%>
                                                <%end If%>	
												<%if noundi19<>"" then %>
                                                    , <%=noundi19%>
                                                <%end If%>			
                                                <%if noundi20<>"" then %>
                                                    , <%=noundi20%>
                                                <%end If%>	
                                                <%if noundi21<>"" then %>
                                                <br><%=noundi21%>
                                                <%end If%>
                                                <%if noundi22<>"" then %>
                                                    , <%=noundi22%>
                                                <%end If%>			
                                                <%if noundi23<>"" then %>
                                                    , <%=noundi23%>
                                                <%end If%>	
												<%if noundi24<>"" then %>
                                                    , <%=noundi24%>
                                                <%end If%>	
                                                <%if noundi25<>"" then %>
                                                    , <%=noundi25%>
                                                <%end If%>	
                                                <%if noundi26<>"" then %>
                                                    , <%=noundi26%>
                                                <%end If%>																																																																																								
                                                <%if noundi27<>"" then %>
                                                    , <%=noundi27%>
                                                <%end If%>	
                                                <%if noundi28<>"" then %>
                                                    , <%=noundi28%>
                                                <%end If%>	
												<%if noundi29<>"" then %>
                                                    , <%=noundi29%>
                                                <%end If%>			
                                                <%if noundi30<>"" then %>
                                                    , <%=noundi30%>
                                                <%end If%>	
                                                <%if noundi31<>"" then %>
                                                <br><%=noundi31%>
                                                <%end If%>
                                                <%if noundi32<>"" then %>
                                                    , <%=noundi32%>
                                                <%end If%>			
                                                <%if noundi33<>"" then %>
                                                    , <%=noundi33%>
                                                <%end If%>	
                                                <%if noundi34<>"" then %>
                                                    , <%=noundi34%>
                                                <%end If%>	
												<%if noundi35<>"" then %>
                                                    , <%=noundi35%>
                                                <%end If%>	
                                                <%if noundi36<>"" then %>
                                                    , <%=noundi36%>
                                                <%end If%>																																																																																								
                                                <%if noundi37<>"" then %>
                                                    , <%=noundi37%>
                                                <%end If%>	
                                                <%if noundi38<>"" then %>
                                                    , <%=noundi38%>
                                                <%end If%>	
                                                <%if noundi39<>"" then %>
                                                    , <%=noundi39%>
                                                <%end If%>			
												<%if noundi40<>"" then %>
                                                    , <%=noundi40%>
                                                <%end If%>	
												<%if noundi41<>"" then %>
                                                    <br><%=noundi41%>
                                                <%end If%>
                                                <%if noundi42<>"" then %>
                                                    , <%=noundi42%>
                                                <%end If%>			
                                                <%if noundi43<>"" then %>
                                                    , <%=noundi43%>
                                                <%end If%>	
                                                <%if noundi44<>"" then %>
                                                    , <%=noundi44%>
                                                <%end If%>	
                                                <%if noundi45<>"" then %>
                                                    , <%=noundi45%>
                                                <%end If%>	
                                                <%if noundi46<>"" then %>
                                                    , <%=noundi46%>
                                                <%end If%>																																																																																								
                                                <%if noundi47<>"" then %>
                                                    , <%=noundi47%>
                                                <%end If%>	
                                                <%if noundi48<>"" then %>
                                                    , <%=noundi48%>
                                                <%end If%>	
                                                <%if noundi49<>"" then %>
                                                    , <%=noundi49%>
                                                <%end If%>			
                                                <%if noundi50<>"" then %>
                                                    , <%=noundi50%>
                                                <%end If%>		
                                                <%if noundi51<>"" then %>
                                                <br><%=noundi51%>
                                                <%end If%>
                                                <%if noundi52<>"" then %>
                                                    , <%=noundi52%>
                                                <%end If%>			
                                                <%if noundi53<>"" then %>
                                                    , <%=noundi53%>
                                                <%end If%>	
                                                <%if noundi54<>"" then %>
                                                    , <%=noundi54%>
                                                <%end If%>	
                                                <%if noundi55<>"" then %>
                                                    , <%=noundi55%>
                                                <%end If%>	
                                                <%if noundi56<>"" then %>
                                                    , <%=noundi56%>
                                                <%end If%>																																																																																								
                                                <%if noundi57<>"" then %>
                                                    , <%=noundi57%>
                                                <%end If%>	
                                                <%if noundi58<>"" then %>
                                                    , <%=noundi58%>
                                                <%end If%>	
                                                <%if noundi59<>"" then %>
                                                    , <%=noundi59%>
                                                <%end If%>			
                                                <%if noundi60<>"" then %>
                                                    , <%=noundi60%>
                                                <%end If%>	
                                                <%if noundi61<>"" then %>
                                                    <br><%=noundi61%>
                                                <%end If%>
                                                <%if noundi62<>"" then %>
                                                    , <%=noundi62%>
                                                <%end If%>			
                                                <%if noundi63<>"" then %>
                                                    , <%=noundi63%>
                                                <%end If%>	
                                                <%if noundi64<>"" then %>
                                                    , <%=noundi64%>
                                                <%end If%>	
                                                <%if noundi65<>"" then %>
                                                    , <%=noundi65%>
                                                <%end If%>	
                                                <%if noundi66<>"" then %>
                                                    , <%=noundi66%>
                                                <%end If%>																																																																																								
                                                <%if noundi67<>"" then %>
                                                    , <%=noundi67%>
                                                <%end If%>	
                                                <%if noundi68<>"" then %>
                                                    , <%=noundi68%>
                                                <%end If%>	
                                                <%if noundi69<>"" then %>
                                                    , <%=noundi69%>
                                                <%end If%>			
                                                <%if noundi70<>"" then %>
                                                    , <%=noundi70%>
                                                <%end If%>		
                                                <%if noundi71<>"" then %>
                                                    <br><%=noundi71%>
                                                <%end If%>
                                                <%if noundi72<>"" then %>
                                                    , <%=noundi72%>
                                                <%end If%>			
                                                <%if noundi73<>"" then %>
                                                    , <%=noundi73%>
                                                <%end If%>	
                                                <%if noundi74<>"" then %>
                                                    , <%=noundi74%>
                                                <%end If%>	
                                                <%if noundi75<>"" then %>
                                                    , <%=noundi75%>
                                                <%end If%>	
                                                <%if noundi76<>"" then %>
                                                    , <%=noundi76%>
                                                <%end If%>																																																																																								
                                                <%if noundi77<>"" then %>
                                                    , <%=noundi77%>
                                                <%end If%>	
                                                <%if noundi78<>"" then %>
                                                    , <%=noundi78%>
                                                <%end If%>	
                                                <%if noundi79<>"" then %>
                                                    , <%=noundi79%>
                                                <%end If%>			
                                                <%if noundi80<>"" then %>
                                                    , <%=noundi80%>
                                                <%end If%>				
					                        </div>
                                        </div>
				                    </div>
	                            </div>
                                <%end If%>
                                <% if adanomortg = "T" then %>
	                            <div style="padding: 0px 10px 0px 10px" class="col-xs-12">
				                    <div class="row">
                                        <div class="col-md-5">
					                        <div class="panel-body">
					                            <b><u>Nomor Undian Anda (TOPG2):</u></b>
					                        </div>
                                        </div>
				                    </div>
				                    <div class="row">
                                        <div class="col-md-6">
					                        <div class="panel-body">
                                                <%if tgundi1<>"" then %>
													<%=tgundi1%>
												<%end if%>
												<%if tgundi2<>"" then %>
													, <%=tgundi2%>
												<%end if%>			
												<%if tgundi3<>"" then %>
													, <%=tgundi3%>
												<%end if%>	
												<%if tgundi4<>"" then %>
													, <%=tgundi4%>
												<%end if%>	
												<%if tgundi5<>"" then %>
													, <%=tgundi5%>
												<%end if%>	
												<%if tgundi6<>"" then %>
													, <%=tgundi6%>
												<%end if%>																																																																																								
												<%if tgundi7<>"" then %>
													, <%=tgundi7%>
												<%end if%>	
												<%if tgundi8<>"" then %>
													, <%=tgundi8%>
												<%end if%>	
												<%if tgundi9<>"" then %>
													, <%=tgundi9%>
												<%end if%>			
												<%if tgundi10<>"" then %>
													, <%=tgundi10%>
												<%end if%>				
												<%if tgundi11<>"" then %>
												<br><%=tgundi11%>
												<%end if%>
												<%if tgundi12<>"" then %>
													, <%=tgundi12%>
												<%end if%>			
												<%if tgundi13<>"" then %>
													, <%=tgundi13%>
												<%end if%>	
												<%if tgundi14<>"" then %>
													, <%=tgundi14%>
												<%end if%>	
												<%if tgundi15<>"" then %>
													, <%=tgundi15%>
												<%end if%>	
												<%if tgundi16<>"" then %>
													, <%=tgundi16%>
												<%end if%>																																																																																								
												<%if tgundi17<>"" then %>
													, <%=tgundi17%>
												<%end if%>	
												<%if tgundi18<>"" then %>
													, <%=tgundi18%>
												<%end if%>	
												<%if tgundi19<>"" then %>
													, <%=tgundi19%>
												<%end if%>			
												<%if tgundi20<>"" then %>
													, <%=tgundi20%>
												<%end if%>	
												<%if tgundi21<>"" then %>
												<br><%=tgundi21%>
												<%end if%>
												<%if tgundi22<>"" then %>
													, <%=tgundi22%>
												<%end if%>			
												<%if tgundi23<>"" then %>
													, <%=tgundi23%>
												<%end if%>	
												<%if tgundi24<>"" then %>
													, <%=tgundi24%>
												<%end if%>	
												<%if tgundi25<>"" then %>
													, <%=tgundi25%>
												<%end if%>	
												<%if tgundi26<>"" then %>
													, <%=tgundi26%>
												<%end if%>																																																																																								
												<%if tgundi27<>"" then %>
													, <%=tgundi27%>
												<%end if%>	
												<%if tgundi28<>"" then %>
													, <%=tgundi28%>
												<%end if%>	
												<%if tgundi29<>"" then %>
													, <%=tgundi29%>
												<%end if%>			
												<%if tgundi30<>"" then %>
													, <%=tgundi30%>
												<%end if%>	
												<%if tgundi31<>"" then %>
												<br><%=tgundi31%>
												<%end if%>
												<%if tgundi32<>"" then %>
													, <%=tgundi32%>
												<%end if%>			
												<%if tgundi33<>"" then %>
													, <%=tgundi33%>
												<%end if%>	
												<%if tgundi34<>"" then %>
													, <%=tgundi34%>
												<%end if%>	
												<%if tgundi35<>"" then %>
													, <%=tgundi35%>
												<%end if%>	
												<%if tgundi36<>"" then %>
													, <%=tgundi36%>
												<%end if%>																																																																																								
												<%if tgundi37<>"" then %>
													, <%=tgundi37%>
												<%end if%>	
												<%if tgundi38<>"" then %>
													, <%=tgundi38%>
												<%end if%>	
												<%if tgundi39<>"" then %>
													, <%=tgundi39%>
												<%end if%>			
												<%if tgundi40<>"" then %>
													, <%=tgundi40%>
												<%end if%>	
												<%if tgundi41<>"" then %>
												<br><%=tgundi41%>
												<%end if%>
												<%if tgundi42<>"" then %>
													, <%=tgundi42%>
												<%end if%>			
												<%if tgundi43<>"" then %>
													, <%=tgundi43%>
												<%end if%>	
												<%if tgundi44<>"" then %>
													, <%=tgundi44%>
												<%end if%>	
												<%if tgundi45<>"" then %>
													, <%=tgundi45%>
												<%end if%>	
												<%if tgundi46<>"" then %>
													, <%=tgundi46%>
												<%end if%>																																																																																								
												<%if tgundi47<>"" then %>
													, <%=tgundi47%>
												<%end if%>	
												<%if tgundi48<>"" then %>
													, <%=tgundi48%>
												<%end if%>	
												<%if tgundi49<>"" then %>
													, <%=tgundi49%>
												<%end if%>			
												<%if tgundi50<>"" then %>
													, <%=tgundi50%>
												<%end if%>		
												<%if tgundi51<>"" then %>
												<br><%=tgundi51%>
												<%end if%>
												<%if tgundi52<>"" then %>
													, <%=tgundi52%>
												<%end if%>			
												<%if tgundi53<>"" then %>
													, <%=tgundi53%>
												<%end if%>	
												<%if tgundi54<>"" then %>
													, <%=tgundi54%>
												<%end if%>	
												<%if tgundi55<>"" then %>
													, <%=tgundi55%>
												<%end if%>	
												<%if tgundi56<>"" then %>
													, <%=tgundi56%>
												<%end if%>																																																																																								
												<%if tgundi57<>"" then %>
													, <%=tgundi57%>
												<%end if%>	
												<%if tgundi58<>"" then %>
													, <%=tgundi58%>
												<%end if%>	
												<%if tgundi59<>"" then %>
													, <%=tgundi59%>
												<%end if%>			
												<%if tgundi60<>"" then %>
													, <%=tgundi60%>
												<%end if%>	
												<%if tgundi61<>"" then %>
												<br><%=tgundi61%>
												<%end if%>
												<%if tgundi62<>"" then %>
													, <%=tgundi62%>
												<%end if%>			
												<%if tgundi63<>"" then %>
													, <%=tgundi63%>
												<%end if%>	
												<%if tgundi64<>"" then %>
													, <%=tgundi64%>
												<%end if%>	
												<%if tgundi65<>"" then %>
													, <%=tgundi65%>
												<%end if%>	
												<%if tgundi66<>"" then %>
													, <%=tgundi66%>
												<%end if%>																																																																																								
												<%if tgundi67<>"" then %>
													, <%=tgundi67%>
												<%end if%>	
												<%if tgundi68<>"" then %>
													, <%=tgundi68%>
												<%end if%>	
												<%if tgundi69<>"" then %>
													, <%=tgundi69%>
												<%end if%>			
												<%if tgundi70<>"" then %>
													, <%=tgundi70%>
												<%end if%>		
												<%if tgundi71<>"" then %>
												<br><%=tgundi71%>
												<%end if%>
												<%if tgundi72<>"" then %>
													, <%=tgundi72%>
												<%end if%>			
												<%if tgundi73<>"" then %>
													, <%=tgundi73%>
												<%end if%>	
												<%if tgundi74<>"" then %>
													, <%=tgundi74%>
												<%end if%>	
												<%if tgundi75<>"" then %>
													, <%=tgundi75%>
												<%end if%>	
												<%if tgundi76<>"" then %>
													, <%=tgundi76%>
												<%end if%>																																																																																								
												<%if tgundi77<>"" then %>
													, <%=tgundi77%>
												<%end if%>	
												<%if tgundi78<>"" then %>
													, <%=tgundi78%>
												<%end if%>	
												<%if tgundi79<>"" then %>
													, <%=tgundi79%>
												<%end if%>			
												<%if tgundi80<>"" then %>
													, <%=tgundi80%>
												<%end if%>				
					                        </div>
                                        </div>
				                    </div>
	                            </div>
                                <%end If%>
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


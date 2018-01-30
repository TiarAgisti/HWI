<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_invoice_prd_autosave.aspx.vb" Inherits="MobileStockiest_sale_cetak_invoice_prd_autosave" %>

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
          		            <div class="panel-body"><img src="../assets/img/logo.jpg" width="143" height="100"></div>
        	            </div>
			            <div class="col-md-1">
				            <strong><%=perush_dc%></strong><br/>
						    <%=nama_dc%> [<%=no_dc%>]<br/>
						    <%=alamat_dc%><br/>
						    <%=alamat_dc2%><br/>
						    Telp. <%=telp_dc%><br/>
						    Email: <%=emel_dc%><br/>
						    <%=web_dc%><br/>
			            </div>
        	            <div class="col-md-5 col-md-offset-4">
				            <div class="panel panel-default height">
                                <div class="panel-heading text-center"><strong><%=judul%></strong></div>
					            <div class="panel-body">
						            <table border="0">
                    		            <tbody>
								            <tr>
									            <td style="width:32%;" class="text-left">No. Invoice</td>
									            <td style="width:6%;">:&nbsp;</td>
									            <td style="width:62%;"><%=nopajak%></td>
								            </tr>
								            <tr>
									            <td class="text-left">No. Referensi</td>
									            <td>:&nbsp;</td>
									            <td><%=noinvo%></td>
								            </tr>
								            <tr>
									            <td class="text-left">Kepada Yth</td>
									            <td>:</td>
									            <td><%=nokon%> : <%=ucase(namakon)%></td>
								            </tr>
								            <tr>
									            <td class="text-left">Tanggal</td>
									            <td>:</td>
									            <td><%=tgl%></td>
								            </tr>
								            <tr>
									            <td class="text-left">Nama Kasir</td>
									            <td>:</td>
									            <td><%=UCase(namakasir)%></td>
								            </tr>
								            <tr>
									            <td class="text-left">Periode Deposit</td>
									            <td>:</td>
									            <td><%=periodelama%> bulan</td>
								            </tr>
								            <tr>
									            <td class="text-left">Bulan Efektif</td>
									            <td>:</td>
									            <td><%=UCase(MonthName(efekbulan))%>&nbsp;<%=efektahun%> s/d <%=UCase(MonthName(efekbulan2))%>&nbsp;<%=efektahun2%></td>
								            </tr>
								            <tr>
									            <td class="text-left">PV Bulanan</td>
									            <td>:</td>
									            <td><%=FormatNumber(pvbulanan, 2)%></td>
								            </tr>
                    		            </tbody>
              			            </table>
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
							            <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>No.</strong></td>
							            <td style="width:24%;" rowspan="2" class="table-bordered text-left"><strong>Item Produk</strong></td>
							            <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>Qty.</strong></td>
							            <td colspan="2" class="table-bordered text-center"><strong>PV</strong></td>
							            <td style="width:19%;" rowspan="2" class="table-bordered text-right"><strong>Harga</strong></td>
							            <td style="width:18%;" rowspan="2" class="table-bordered text-right"><strong>Subtotal</strong></td>
					  	            </tr>
						            <tr>
							            <td style="width:15%;" class="table-bordered text-center"><strong>Satuan</strong></td>
							            <td style="width:14%;" class="table-bordered text-right"><strong>Total</strong></td>
						            </tr>
					            </thead>
					            <tbody class="table table-bordered">
                                    <%if no1 <> "" Then %>
						            <tr>
							            <td class="table-bordered text-center" style="color:#000000;"><%=no1%></td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;<%=kdbr1%> - <%=namabr1%></td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(jumlah1, 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(pv1, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(totpv1, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga1, 0)%>,-&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(subtot1, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
                                    <%else%>
                                    <tr>
							            <td class="table-bordered text-center" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
						            </tr>
                                    <%end if%>
                                    <%if no2 <> "" Then %>
						            <tr>
							            <td class="table-bordered text-center" style="color:#000000;"><%=no2%></td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;<%=kdbr2%> - <%=namabr2%></td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(jumlah2, 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(pv2, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(totpv2, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga2, 0)%>,-&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(subtot2, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
                                    <%else%>
                                    <tr>
							            <td class="table-bordered text-center" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
						            </tr>
                                    <%end if%>
                                    <%if no3 <> "" Then %>
						            <tr>
							            <td class="table-bordered text-center" style="color:#000000;"><%=no3%></td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;<%=kdbr3%> - <%=namabr3%></td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(jumlah3, 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(pv3, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(totpv3, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga3, 0)%>,-&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(subtot3, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
                                    <%else%>
                                    <tr>
							            <td class="table-bordered text-center" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
						            </tr>
                                    <%end if%>
                                    <%if no4 <> "" Then %>
						            <tr>
							            <td class="table-bordered text-center" style="color:#000000;"><%=no4%></td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;<%=kdbr4%> - <%=namabr4%></td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(jumlah4, 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(pv4, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(totpv4, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga4, 0)%>,-&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(subtot4, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
                                    <%else%>
                                    <tr>
							            <td class="table-bordered text-center" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
						            </tr>
                                    <%end if%>
                                    <%if no5 <> "" Then %>
						            <tr>
							            <td class="table-bordered text-center" style="color:#000000;"><%=no5%></td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;<%=kdbr5%> - <%=namabr5%></td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(jumlah5, 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(pv5, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(totpv5, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga5, 0)%>,-&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(subtot5, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
                                    <%else%>
                                    <tr>
							            <td class="table-bordered text-center" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
						            </tr>
                                    <%end if%>
                                    <%if no6 <> "" Then %>
						            <tr>
							            <td class="table-bordered text-center" style="color:#000000;"><%=no6%></td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;<%=kdbr6%> - <%=namabr6%></td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(jumlah6, 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(pv6, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(totpv6, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga6, 0)%>,-&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(subtot6, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
                                    <%else%>
                                    <tr>
							            <td class="table-bordered text-center" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
						            </tr>
                                    <%end if%>
                                    <%if no7 <> "" Then %>
						            <tr>
							            <td class="table-bordered text-center" style="color:#000000;"><%=no7%></td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;<%=kdbr7%> - <%=namabr7%></td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(jumlah7, 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(pv7, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;"><%=FormatNumber(totpv7, 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(harga7, 0)%>,-&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">Rp <%=FormatNumber(subtot7, 0)%>,-&nbsp;&nbsp;</td>
						            </tr>
                                    <%else%>
                                    <tr>
							            <td class="table-bordered text-center" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-left" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
							            <td class="table-bordered text-right" style="color:#000000;">&nbsp;</td>
						            </tr>
                                    <%end if%>
						            <tr>
							            <td colspan="2" class="table-bordered text-right"><strong>GRAND TOTAL</strong></td>
							            <td class="table-bordered text-right"><b><label style="color:#000000;"><%=FormatNumber(totjum, 0)%>&nbsp;&nbsp;</label></b></td>
							            <td colspan="2" class="table-bordered text-right"><label style="color:#000000;"><b><%=FormatNumber(totpv, 2)%>&nbsp;&nbsp;</b></label></td>
							            <td class="table-bordered text-right">&nbsp;</td>
							            <td class="table-bordered text-right"><label style="color:#000000;"><b>Rp <%=FormatNumber(gtot, 0)%>,-&nbsp;&nbsp;</b></label></td>
					  	            </tr>
					            </tbody>
					            <tfoot>
						            <tr>
				  			            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="highrow"></td>
							            <td class="table-bordered highrow text-left"><strong>PEMBAYARAN</strong></td>
							            <td class="table-bordered highrow text-right"><strong>Rp,-</strong></td>
						            </tr>
                                    <%if tunai > 0 then %>
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
                                        If debit > 0 Then %>
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
							            <td class="table-bordered emptyrow text-left">&nbsp; &nbsp; &nbsp; Kartu Kredi Kredit</td>
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
							            <td class="table-bordered emptyrow text-left"> Total Pembayaran</td>
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
	            <div class="col-md-8">
                    <%if autoupgrade = "T" then %>
		            <div class="text-center"><strong> ******SELAMAT !!! ANDA MEMPEROLEH AUTO UPGRADE 3BC******</strong></div>
                    <%end if%>

                    <% if adanomor = "T" then %>
		            <strong>Nomor Undian Anda (CMP Varian) :</strong><br>
		            <%if noundi1<>"" then %>
					    <%=noundi1%>
					<%end if%>
					<%if noundi2<>"" then %>
						, <%=noundi2%>
					<%end if%>			
					<%if noundi3<>"" then %>
						, <%=noundi3%>
					<%end if%>	
					<%if noundi4<>"" then %>
						, <%=noundi4%>
					<%end if%>	
					<%if noundi5<>"" then %>
						, <%=noundi5%>
					<%end if%>	
					<%if noundi6<>"" then %>
						, <%=noundi6%>
					<%end if%>																																																																																								
					<%if noundi7<>"" then %>
						, <%=noundi7%>
					<%end if%>	
					<%if noundi8<>"" then %>
						, <%=noundi8%>
					<%end if%>	
					<%if noundi9<>"" then %>
						, <%=noundi9%>
					<%end if%>			
					<%if noundi10<>"" then %>
						, <%=noundi10%>
					<%end if%>				
					<%if noundi11<>"" then %>
					<br><%=noundi11%>
					<%end if%>
					<%if noundi12<>"" then %>
						, <%=noundi12%>
					<%end if%>			
					<%if noundi13<>"" then %>
						, <%=noundi13%>
					<%end if%>	
					<%if noundi14<>"" then %>
						, <%=noundi14%>
					<%end if%>	
					<%if noundi15<>"" then %>
						, <%=noundi15%>
					<%end if%>	
					<%if noundi16<>"" then %>
						, <%=noundi16%>
					<%end if%>																																																																																								
					<%if noundi17<>"" then %>
						, <%=noundi17%>
					<%end if%>	
					<%if noundi18<>"" then %>
						, <%=noundi18%>
					<%end if%>	
					<%if noundi19<>"" then %>
						, <%=noundi19%>
					<%end if%>			
					<%if noundi20<>"" then %>
						, <%=noundi20%>
					<%end if%>	
					<%if noundi21<>"" then %>
					<br><%=noundi21%>
					<%end if%>
					<%if noundi22<>"" then %>
						, <%=noundi22%>
					<%end if%>			
					<%if noundi23<>"" then %>
						, <%=noundi23%>
					<%end if%>	
					<%if noundi24<>"" then %>
						, <%=noundi24%>
					<%end if%>	
					<%if noundi25<>"" then %>
						, <%=noundi25%>
					<%end if%>	
					<%if noundi26<>"" then %>
						, <%=noundi26%>
					<%end if%>																																																																																								
					<%if noundi27<>"" then %>
						, <%=noundi27%>
					<%end if%>	
					<%if noundi28<>"" then %>
						, <%=noundi28%>
					<%end if%>	
					<%if noundi29<>"" then %>
						, <%=noundi29%>
					<%end if%>			
					<%if noundi30<>"" then %>
						, <%=noundi30%>
					<%end if%>	
					<%if noundi31<>"" then %>
					<br><%=noundi31%>
					<%end if%>
					<%if noundi32<>"" then %>
						, <%=noundi32%>
					<%end if%>			
					<%if noundi33<>"" then %>
						, <%=noundi33%>
					<%end if%>	
					<%if noundi34<>"" then %>
						, <%=noundi34%>
					<%end if%>	
					<%if noundi35<>"" then %>
						, <%=noundi35%>
					<%end if%>	
					<%if noundi36<>"" then %>
						, <%=noundi36%>
					<%end if%>																																																																																								
					<%if noundi37<>"" then %>
						, <%=noundi37%>
					<%end if%>	
					<%if noundi38<>"" then %>
						, <%=noundi38%>
					<%end if%>	
					<%if noundi39<>"" then %>
						, <%=noundi39%>
					<%end if%>			
					<%if noundi40<>"" then %>
						, <%=noundi40%>
					<%end if%>	
					<%if noundi41<>"" then %>
					<br><%=noundi41%>
					<%end if%>
					<%if noundi42<>"" then %>
						, <%=noundi42%>
					<%end if%>			
					<%if noundi43<>"" then %>
						, <%=noundi43%>
					<%end if%>	
					<%if noundi44<>"" then %>
						, <%=noundi44%>
					<%end if%>	
					<%if noundi45<>"" then %>
						, <%=noundi45%>
					<%end if%>	
					<%if noundi46<>"" then %>
						, <%=noundi46%>
					<%end if%>																																																																																								
					<%if noundi47<>"" then %>
						, <%=noundi47%>
					<%end if%>	
					<%if noundi48<>"" then %>
						, <%=noundi48%>
					<%end if%>	
					<%if noundi49<>"" then %>
						, <%=noundi49%>
					<%end if%>			
					<%if noundi50<>"" then %>
						, <%=noundi50%>
					<%end if%>		
					<%if noundi51<>"" then %>
					<br><%=noundi51%>
					<%end if%>
					<%if noundi52<>"" then %>
						, <%=noundi52%>
					<%end if%>			
					<%if noundi53<>"" then %>
						, <%=noundi53%>
					<%end if%>	
					<%if noundi54<>"" then %>
						, <%=noundi54%>
					<%end if%>	
					<%if noundi55<>"" then %>
						, <%=noundi55%>
					<%end if%>	
					<%if noundi56<>"" then %>
						, <%=noundi56%>
					<%end if%>																																																																																								
					<%if noundi57<>"" then %>
						, <%=noundi57%>
					<%end if%>	
					<%if noundi58<>"" then %>
						, <%=noundi58%>
					<%end if%>	
					<%if noundi59<>"" then %>
						, <%=noundi59%>
					<%end if%>			
					<%if noundi60<>"" then %>
						, <%=noundi60%>
					<%end if%>	
					<%if noundi61<>"" then %>
					<br><%=noundi61%>
					<%end if%>
					<%if noundi62<>"" then %>
						, <%=noundi62%>
					<%end if%>			
					<%if noundi63<>"" then %>
						, <%=noundi63%>
					<%end if%>	
					<%if noundi64<>"" then %>
						, <%=noundi64%>
					<%end if%>	
					<%if noundi65<>"" then %>
						, <%=noundi65%>
					<%end if%>	
					<%if noundi66<>"" then %>
						, <%=noundi66%>
					<%end if%>																																																																																								
					<%if noundi67<>"" then %>
						, <%=noundi67%>
					<%end if%>	
					<%if noundi68<>"" then %>
						, <%=noundi68%>
					<%end if%>	
					<%if noundi69<>"" then %>
						, <%=noundi69%>
					<%end if%>			
					<%if noundi70<>"" then %>
						, <%=noundi70%>
					<%end if%>		
					<%if noundi71<>"" then %>
					<br><%=noundi71%>
					<%end if%>
					<%if noundi72<>"" then %>
						, <%=noundi72%>
					<%end if%>			
					<%if noundi73<>"" then %>
						, <%=noundi73%>
					<%end if%>	
					<%if noundi74<>"" then %>
						, <%=noundi74%>
					<%end if%>	
					<%if noundi75<>"" then %>
						, <%=noundi75%>
					<%end if%>	
					<%if noundi76<>"" then %>
						, <%=noundi76%>
					<%end if%>																																																																																								
					<%if noundi77<>"" then %>
						, <%=noundi77%>
					<%end if%>	
					<%if noundi78<>"" then %>
						, <%=noundi78%>
					<%end if%>	
					<%if noundi79<>"" then %>
						, <%=noundi79%>
					<%end if%>			
					<%if noundi80<>"" then %>
						, <%=noundi80%>
					<%end if%>				
		            <br>
                    <%end if%>
                    <% if adanomortg = "T" then %>
		            <strong>Nomor Undian Anda (TOPG2) :</strong><br>
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
                    <%end if%>
	            </div>
	            <div class="col-md-4"></div>
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


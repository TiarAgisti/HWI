<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_list_stater.aspx.vb" Inherits="MobileStockiest_sale_cetak_list_stater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
     <section class="content-header" style="background-color:white;">
         <div class="container">
	        <div class="container">
		        <div class="row">
			        <div style="padding: 10px 20px 0px 20px" class="col-xs-12">
				        <div class="row">
					        <div class="col-md-2">
						        <div class="panel-body">
							        <img src="img/logo.jpg" width="143" height="100" />
						        </div>
					        </div>
					        <div class="col-md-10">
						        <div class="panel-body">
							        <strong style="font-size:2px;"><%=perush_dc%></strong><br>
							        <%=nama_dc%> [<%=no_dc%>]<br>
							        <%=alamat_dc%><br>
							        <%=alamat_dc2%><br>
							        Telp.<%=telp_dc%><br>
							        Email:&nbsp;<%=emel_dc%><br>
							        <%=web_dc%><br>
						        </div>
					        </div>
				        </div>
			        </div>
		        </div>
		        <h3 style="text-align:center;">
                    <strong>DAFTAR INVOICE PENJUALAN PAKET PENDAFTARAN</strong><br>
                    <%if tgl1 <> ""  and tgl2 <> "" then %>
			        <strong><%=tgl1%> s/d <%=tgl2%></strong>
                    <%end if%>
		        </h3>
		        <div class="row">
			        <div class="col-md-14">
				        <div class="table-responsive">
					        <table class="table table-condensed">
						        <thead class="table table-bordered">
							        <tr>
								        <td style="width:7%;" rowspan="2" class="table-bordered text-center"><strong>Tanggal</strong></td>
								        <td style="width:17%;" rowspan="2" class="table-bordered text-center"><strong>Nomor Referensi</strong></td>
								        <td style="width:6%;" rowspan="2" class="table-bordered text-center"><strong>Nomor Invoice</strong></td>
								        <td style="width:11%;" rowspan="2" class="table-bordered text-center"><strong>No. Seri</strong></td>
								        <td style="width:18%;" rowspan="2" class="table-bordered text-center"><strong>Nama Konsumen</strong></td>
								        <td style="width:6%;" rowspan="2" class="table-bordered text-center"><strong>Paket</strong></td>
								        <td style="width:7%;" rowspan="2" class="table-bordered text-center"><strong>Nominal</strong></td>
								        <td colspan="4" class="table-bordered text-center"><strong>Pembayaran</strong></td>
							        </tr>
							        <tr>
								        <td style="width:5%;" class="table-bordered text-center"><strong>Tunai</strong></td>
								        <td style="width:9%;" class="table-bordered text-center"><strong>Debit Card</strong></td>
								        <td style="width:8%;" class="table-bordered text-center"><strong>Credit Card</strong></td>
								        <td style="width:6%;" class="table-bordered text-center"><strong>Voucher</strong></td>
							        </tr>
						        </thead>
						        <tbody class="table table-bordered">
                                    <%
                                        totnom = 0
                                        tottunai = 0
                                        totdebit = 0
                                        totcc = 0
                                        totbg = 0
                                        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" Then
                                            If sort = "Bulan" Then
                                                mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'  and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by month(tgl) DESC, year(tgl) DESC"
                                            Else
                                                If sort = "tanggal" Then
                                                    mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'  and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                    mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                Else
                                                    mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'  and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                    mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                End If
                                            End If
                                        Else

                                            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                                                If sort = "Bulan" Then
                                                    mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'  and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                    mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by month(tgl) DESC, year(tgl) DESC"
                                                Else
                                                    If sort = "tanggal" Then
                                                        mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'  and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                        mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                    Else
                                                        mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "'  and kta like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                        mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                    End If
                                                End If
                                            Else
                                                If sort = "Bulan" Then
                                                    mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "' order by month(tgl) DESC, year(tgl) DESC"
                                                Else
                                                    If sort = "tanggal" Then
                                                        mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "' order by tgl DESC"
                                                    Else
                                                        mlQuery = "SELECT * FROM st_sale_daftar where nopos like '" & mypos & "' and pakai like '" & pak & "' order by tgl DESC"
                                                    End If
                                                End If
                                            End If
                                        End If

                                        mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                        If Not mlDR.HasRows Then %>
							        <tr>
								        <td colspan="11" class="table-bordered text-center">
									        <u style="color:#000000;">Tidak ada transaksi penjualan paket pendaftaran</u>
								        </td>
							        </tr>
                                    <% End If %>
                                    <%
                                        If mlDR.HasRows Then
                                            mlDT = New Data.DataTable
                                            mlDT.Load(mlDR)

                                            For aaaeqSSS = 1 To lumpat
                                                totnom = totnom + mlDT.Rows(aaaeqSSS)("harga")
                                                tottunai = tottunai + (mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"))
                                                totdebit = totdebit + mlDT.Rows(aaaeqSSS)("debit")
                                                totcc = totcc + mlDT.Rows(aaaeqSSS)("cc")
                                                totbg = totbg + mlDT.Rows(aaaeqSSS)("bg")
                                    %>
                                    <tr>
								        <td class="table-bordered text-center"><%=mlDT.Rows(aaaeqSSS)("tgl")%></td>
								        <td class="table-bordered text-center">
                                            <%if mlDT.Rows(aaaeqSSS)("paket") <> "UPG" Then %>
                                            <a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_daftar.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("noslip")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none">
                                                    <%=mlDT.Rows(aaaeqSSS)("noslip")%>
                                                </span>
                                            </a>
											<%Else%>
											<a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_upgrade.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("noslip")%>&menu_id=<%=session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none">
                                                    <%=mlDT.Rows(aaaeqSSS)("noslip")%>
                                                </span>
											</a>
											<%End If%>
								        </td>
								        <td class="table-bordered text-center">
                                            <%if mlDT.Rows(aaaeqSSS)("paket") <> "UPG" Then %>
											<a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_daftar.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("noslip")%>&menu_id=<%=Session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none">
                                                    <%=mlDT.Rows(aaaeqSSS)("nopajak")%>
                                                </span>
											</a>
											<%Else%>
											<a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_upgrade.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("noslip")%>&menu_id=<%=session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none">
                                                    <%=mlDT.Rows(aaaeqSSS)("nopajak")%>
                                                </span>
											</a>
											<%End If%>	
								        </td>
								        <td class="table-bordered text-left">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("noseri")%></td>
                                        <td class="table-bordered text-left">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("nama")%></td>
								        <td class="table-bordered text-left">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("paket")%></td>
								        <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("harga"), 0)%></td>
								        <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"), 0)%>&nbsp;&nbsp;</td>
								        <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("debit"), 0)%>&nbsp;&nbsp;</td>
								        <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("cc"), 0)%>&nbsp;&nbsp;</td>
								        <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("bg"), 0)%>&nbsp;&nbsp;</td>
							        </tr>
                                    <%
                                            Next
                                        End If
                                        mlDR.Close()
                                    %>
							        <tr>
								        <td colspan="7" class="table-bordered text-right"><strong>Grandtotal</strong></td>
								        <td class="table-bordered text-right"><%=FormatNumber(tottunai, 0)%>&nbsp;&nbsp;</td>
								        <td class="table-bordered text-right"><%=FormatNumber(totdebit, 0)%>&nbsp;&nbsp;</td>
								        <td class="table-bordered text-right"><%=FormatNumber(totcc, 0)%>&nbsp;&nbsp;</td>
								        <td class="table-bordered text-right"><%=FormatNumber(totbg, 0)%>&nbsp;&nbsp;</td>
							        </tr>
						        </tbody>
					        </table>
				        </div>
			        </div>
		        </div>
		        <div class="row">
			        <div class="col-md-12">
				        <div class="table-responsive">
					        <table style="width:100%;" border="0">
						        <tr>
							        <td colspan="3">
                                        <strong>GRAND TOTAL DARI TANGGAL</strong>
                                        <strong><%=FormatDateTime(tg1, 1)%> s/d <%=FormatDateTime(tg2, 1)%></strong>
							        </td>
						        </tr>
						        <tr>
							        <td style="width:10%;">Tunai</td>
							        <td style="width:5%;">&nbsp;:&nbsp;</td>
							        <td style="width:85%;">
                                        <span>Rp <%=FormatNumber(gtottunai, 0)%>,-</span>
							        </td>
						        </tr>
						        <tr>
						            <td>Debit Card</td>
						            <td>&nbsp;:&nbsp;</td>
						            <td>
                                        <span>Rp <%=FormatNumber(gtotdebit, 0)%>,-</span>
						            </td>
						        </tr>
						        <tr>
						            <td>Credit Card</td>
						            <td>&nbsp;:&nbsp;</td>
						            <td>
                                        <span>Rp <%=FormatNumber(gtotkartu, 0)%>,-</span>
						            </td>
						        </tr>
						        <tr>
						            <td>Voucher</td>
						            <td>&nbsp;:&nbsp;</td>
						            <td>
                                        <span>Rp <%=FormatNumber(gtotvouc, 0)%>,-</span>
						            </td>
						        </tr>
						        <tr>
						            <td><strong>TOTAL</strong></td>
						            <td><strong>&nbsp;:&nbsp;</strong></td>
						            <td><strong>Rp <%=FormatNumber(gtottunai + gtotdebit + gtotkartu + gtotvouc, 0)%>,-</strong></td>
						        </tr>
					        </table>
				        </div>
			        </div>
		        </div>
	        </div>
        </div>
     </section>
</asp:Content>


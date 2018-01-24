<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_list_prd.aspx.vb" Inherits="MobileStockiest_sale_cetak_list_prd" %>

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
                    <div style="padding: 10px 20px 0px 20px" class="col-xs-12">
                        <div class="row">
                            <div class="col-md-2">
					            <div class="panel-body">
						            <img src="../assets/img/logo.jpg" width="143" height="100">
					            </div>
                            </div>
				            <div class="col-md-10">
					            <div class="panel-body">
						             <strong><%=perush_dc%></strong><br>
			                        <%=nama_dc%> [<%=no_dc%>]<br>
			                        <%=alamat_dc%><br>
			                        <%=alamat_dc2%><br>
			                        Telp. <%=telp_dc%><br>
			                        Email: <%=emel_dc%><br>
			                        <%=web_dc%><br>
					            </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3 class="text-center">
                    <strong>DAFTAR INVOICE PENJUALAN PRODUK
                        <%if tgl1 <> ""  and tgl2 <> "" then %>	<br>
                        <%=tgl1%> s/d <%=tgl2%>
                        <%end if%>
                    </strong>
                </h3>
	            <div class="row">
                    <div class="col-md-12">
			            <div class="table-responsive">
				            <table class="table table-condensed">
					            <thead class="table table-bordered">
						            <tr>
							            <td style="width:7%;" rowspan="2" class="table-bordered text-center"><strong>Tanggal</strong></td>
							            <td style="width:17%;" rowspan="2" class="table-bordered text-center"><strong>Nomor Referensi</strong></td>
							            <td style="width:6%;" rowspan="2" class="table-bordered text-center"><strong>Nomor Invoice</strong></td>
							            <td style="width:11%;" rowspan="2" class="table-bordered text-center"><strong>No Dist.</strong></td>
							            <td style="width:18%;" rowspan="2" class="table-bordered text-center"><strong>Nama Distributor</strong></td>
							            <td style="width:6%;" rowspan="2" class="table-bordered text-center"><strong>PV</strong></td>
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
                                                mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by month(tgl) DESC, year(tgl) DESC"
                                            Else
                                                If sort = "tanggal" Then
                                                    mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                    mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                Else
                                                    mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                    mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                End If
                                            End If
                                        Else
                                            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                                                If sort = "Bulan" Then
                                                    mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                                                    mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by month(tgl) DESC, year(tgl) DESC"
                                                Else
                                                    If sort = "tanggal" Then
                                                        mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                                                        mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                    Else
                                                        mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                                                        mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                    End If
                                                End If
                                            Else
                                                If sort = "Bulan" Then
                                                    mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' order by month(tgl) DESC, year(tgl) DESC"
                                                Else
                                                    If sort = "tanggal" Then
                                                        mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' order by tgl DESC"
                                                    Else
                                                        mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "' order by tgl DESC"
                                                    End If
                                                End If
                                            End If
                                        End If

                                        mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                        If Not mlDR.HasRows Then
                                    %>
                                    <tr>
							            <td colspan="11" class="table-bordered text-center">Tidak Ada Transaksi Penjualan Produk</td>
						            </tr>
                                    <%
                    End If
                    If mlDR.HasRows Then
                        mlDT = New Data.DataTable
                        mlDT.Load(mlDR)
                        For aaaeqSSS = 1 To lumpat
                            totnom = totnom + mlDT.Rows(aaaeqSSS)("subtot")
                            tottunai = tottunai + (mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"))
                            totdebit = totdebit + mlDT.Rows(aaaeqSSS)("debit")
                            totcc = totcc + mlDT.Rows(aaaeqSSS)("cc")
                            totbg = totbg + mlDT.Rows(aaaeqSSS)("cek")

                                                %>
                                    <tr>
							            <td class="table-bordered text-center"><%=mlDT.Rows(aaaeqSSS)("tgl")%></td>
							            <td class="table-bordered text-left">
                                            <%if tpe = "DEPOSIT" Then %>
                                            <a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_prd_autosave.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes
                                                , height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("noinvoice")%></span>
                                            </a>
                                            <%else%>
                                            <a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_prd.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes
                                                , height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("noinvoice")%></span>
                                            </a>
                                            <%end If%>
							            </td>
							            <td class="table-bordered text-center">
                                            <%if tpe = "DEPOSIT" Then %>
                                            <a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_prd_autosave.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes
                                                                    , height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("nopajak")%></span>
                                            </a>
                                            <%else%>
                                            <a href="#">
                                                <span onClick="javascript:window.open('sale_cetak_invoice_prd.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>', 'HelpWindow','scrollbars=yes, resizable=yes
                                                                    , height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("nopajak")%></span>
                                            </a>
                                            <%end If%>
                                            &nbsp;
							            </td>
							            <td class="table-bordered text-left">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("nodist")%></td>
							            <td class="table-bordered text-left">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("namadist")%></td>
							            <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("totpv"), 2)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("subtot"), 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"), 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("debit"), 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("cc"), 0)%>&nbsp;&nbsp;</td>
							            <td class="table-bordered text-right"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("cek"), 0)%>&nbsp;&nbsp;</td>
						            </tr>
                                    <%
                        Next
                    End If
                                    %>
						            <tr>
							            <td colspan="6" class="table-bordered text-right"><strong>Grandtotal</strong></td>
							            <td class="table-bordered text-right"><%=FormatNumber(totnom, 0)%>&nbsp;&nbsp;</td>
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
							        <td colspan="3"><strong>GRAND TOTAL DARI TANGGAL <%=FormatDateTime(tg1, 1)%> s/d <%=FormatDateTime(tg2, 1)%></strong></td>
						        </tr>
						        <tr>
							        <td style="width:10%;">Tunai</td>
							        <td style="width:5%;">:&nbsp;</td>
							        <td style="width:85%;">Rp <%=FormatNumber(gtottunai, 0)%>,-</td>
						        </tr>
						        <tr>
						            <td>Debit Card</td>
						            <td>:&nbsp;</td>
						            <td><span>Rp <%=FormatNumber(gtotdebit, 0)%>,-</span></td>
						        </tr>
						        <tr>
						            <td>Credit Card</td>
						            <td>:&nbsp;</td>
						            <td>Rp <%=FormatNumber(gtotkartu, 0)%>,-</td>
						        </tr>
						        <tr>
						            <td>Voucher</td>
						            <td>:&nbsp;</td>
						            <td>Rp <%=FormatNumber(gtotvouc, 0)%>,-</td>
						        </tr>
						        <tr>
						            <td><strong>TOTAL</strong></td>
						            <td><strong>:&nbsp;</strong></td>
						            <td><strong>Rp <%=FormatNumber(gtottunai + gtotdebit + gtotkartu + gtotvouc, 0)%>,-</strong></td>
						        </tr>
				            </table>
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


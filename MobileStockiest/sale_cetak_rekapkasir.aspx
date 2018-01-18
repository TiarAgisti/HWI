<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_rekapkasir.aspx.vb" Inherits="MobileStockiest_sale_cetak_rekapkasir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-heading">
			    <h3 class=" text-center panel-title"><strong>REKAP TRANSAKSI HARIAN KASIR</strong></h3>
		    </div>
            <div class="panel-body">
			    <form>
				    <div class="row">
        			    <div style="padding: 10px 20px 0px 20px" class="col-xs-12">
            			    <div class="row">
							    <div class="col-md-2">
								    <div class="panel-body">
									    <img src="../images/logohwi.png" width="143" height="100">
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
			    </form>
			    <div class="col-md-12" style="padding-top: 20px">
				    <label><strong>Rekap Transaksi Harian pada Tanggal: <%=FormatDateTime(tg1, 1)%></strong></label>
				    <div class="table-responsive">
					    <table class="table table-condensed table-bordered">
						    <tr>
							    <td style="width:14%;" rowspan="2" class="text-center"><strong>Kasir</strong></td>
							    <td colspan="3" class="text-center"><strong>Penjualan</strong></td>
							    <td colspan="5" class="text-center"><strong>Pembayaran</strong></td>
						    </tr>
						    <tr>
							    <td style="width:9%;" class="text-center"><strong>Pendaftaran</strong></td>
							    <td style="width:8%;" class="text-center"><strong>Produk</strong></td>
							    <td style="width:10%;" class="text-center"><strong>Total</strong></td>
							    <td style="width:10%;" class="text-center"><strong>Tunai</strong></td>
							    <td style="width:11%;" class="text-center"><strong>Debit Card</strong></td>
							    <td style="width:11%;" class="text-center"><strong>Credit Card</strong></td>
							    <td style="width:14%;" class="text-center"><strong>Voucher</strong></td>
							    <td style="width:13%;" class="text-center"><strong>Total</strong></td>
						    </tr>
                            <%
                                raono = "-"
                                tpe1 = "PRD"
                                tpe2 = "AKT"
                                gtotdaftar = 0
                                gtotprd = 0
                                gtote = 0
                                gtottunai = 0
                                gtotdebit = 0
                                gtotcc = 0
                                gtoto = 0
                                gtotvouc = 0
                                mlQuery = "SELECT DISTINCT kasir FROM rekap_harian_kasir where nopos like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir <> '" & raono & "' order by kasir"
                                mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                If mlDR.HasRows Then
                                    mlDT = New Data.DataTable
                                    mlDT.Load(mlDR)
                                    For aaaeqSSS = 1 To mlDT.Rows.Count - 1
                                        kasir = mlDT.Rows(aaaeqSSS)("kasir")

                                        mlQuery2 = "SELECT * from rekap_harian_kasir where nopos like '" & mypos & "' and tipe like '" & tpe1 & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                                        mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                        mlDR2.Read()
                                        If Not mlDR2.HasRows Then
                                            totjualprd = 0
                                        Else
                                            totjualprd = mlDR2("totjual")
                                        End If
                                        mlDR2.Close()

                                        mlQuery2 = "SELECT * from rekap_harian_kasir where nopos like '" & mypos & "' and tipe like '" & tpe2 & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                                        mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                        mlDR2.Read()
                                        If Not mlDR2.HasRows Then
                                            totjualakt = 0
                                        Else
                                            totjualakt = mlDR2("totjual")
                                        End If
                                        mlDR2.Close()

                                        mlQuery2 = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(kembalian) as vkembalian,sum(cek) as vcek from rekap_harian_kasir where nopos like '" & mypos & "'" & vbCrLf
                                        mlQuery2 += "And (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "' group by kasir"
                                        mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                        mlDR2.Read()
                                        If Not mlDR2.HasRows Then
                                            tottunai = 0
                                            totdebit = 0
                                            totcc = 0
                                            totvouc = 0
                                        Else
                                            tottunai = mlDR2("vtunai")
                                            totdebit = mlDR2("vdebit")
                                            totcc = mlDR2("vcc")
                                            totvouc = mlDR2("vcek")
                                            totkembali = mlDR2("vkembalian")
                                            tunai = tottunai - totkembali
                                        End If
                                        mlDR2.Close()

                                        gtotdaftar = gtotdaftar + totjualakt
                                        gtotprd = gtotprd + totjualprd
                                        gtote = gtotdaftar + gtotprd
                                        gtottunai = gtottunai + tunai
                                        gtotdebit = gtotdebit + totdebit
                                        gtotcc = gtotcc + totcc
                                        gtotvouc = gtotvouc + totvouc
                                        gtoto = gtottunai + gtotdebit + gtotcc

                            %>
                             <tr>
							    <td style="width:10%;">&nbsp;<%=UCase(kasir)%></td>
								<td style="width:12%;text-align:right;"><%=FormatNumber(totjualakt, 0)%>&nbsp;&nbsp; </td>
								<td style="width:12%;text-align:right;"><%=FormatNumber(totjualprd, 0)%>&nbsp;&nbsp; </td>
								<td style="width:16%;text-align:right;"><%=FormatNumber(totjualakt + totjualprd, 0)%>&nbsp;&nbsp; </td>
								<td style="width:10%;text-align:right;"><%=FormatNumber(tottunai - totkembali, 0)%>&nbsp;&nbsp; </td>
								<td style="width:10%;text-align:right;"><%=FormatNumber(totdebit, 0)%>&nbsp;&nbsp;</td>
								<td style="width:10%;text-align:right;"><%=FormatNumber(totcc, 0)%>&nbsp;&nbsp;</td>
								<td style="width:10%;text-align:right;"><%=FormatNumber(totvouc, 0)%>&nbsp;&nbsp;</td>
								<td style="width:14%;text-align:right;"><%=FormatNumber((tottunai - totkembali) + totdebit + totcc + totvouc, 0)%>&nbsp;&nbsp;</td>
						    </tr>
                            <%
                            Next
                        End If
                        mlDR.Close()
                            %>			
						    <tr>
							    <td class="text-right"><strong>GRAND TOTAL</strong></td>
							    <td style="width:12%;text-align:right;"><%=formatnumber(gtotdaftar,0)%>&nbsp;&nbsp;</td>
								<td style="width:12%;text-align:right;"><%=formatnumber(gtotprd,0)%>&nbsp;&nbsp;</td>
								<td style="width:16%;text-align:right;"><%=formatnumber(gtote,0)%>&nbsp;&nbsp;</td>
								<td style="width:10%;text-align:right;"><%=formatnumber(gtottunai,0)%>&nbsp;&nbsp;</td>
								<td style="width:10%;text-align:right;"><%=formatnumber(gtotdebit,0)%>&nbsp;&nbsp;</td>
								<td style="width:10%;text-align:right;"><%=formatnumber(gtotcc,0)%>&nbsp;&nbsp;</td>
								<td style="width:10%;text-align:right;"><%=formatnumber(gtotvouc,0)%>&nbsp;&nbsp;</td>
								<td style="width:14%;text-align:right;"><%=formatnumber(gtoto,0)%>&nbsp;&nbsp;</td>
						    </tr>
					    </table>
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


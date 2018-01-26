<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="rekap_harian.aspx.vb" Inherits="MobileStockiest_rekap_harian" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class=" text-center panel-title">REKAP TRANSAKSI HARIAN MOBILE CENTER</h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="rekap_harian.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="page" value="<%=pg+1%>">	
							<input type="hidden" name="itung" value="T">
                            <div class="col-md-1">
                                <label>Tanggal</label>
                            </div>
                            <div class="col-md-3">
                                <input class="form-control" type="text" name="tgl1" value="<%=Now.Date%>">
                            </div>
                            <div class="col-md-8">
                                <button class="btn btn-default" type="button">Tampilkan</button>
                            </div>
                        </form>
                       
                        <div class="col-md-12" style="padding-top: 20px">
                            <label>Rekap Transaksi Harian pada Tanggal <%=FormatDateTime(tg1, 1)%></label>
                            <div class="table-responsive">
                                <table class="table table-condensed table-bordered">
                                    <tr>
                                        <td style="background-color:grey;width:14%;" rowspan="2" class="text-center"><strong>Kasir</strong></td>
                                        <td colspan="3" class="text-center"style="background-color:orange;"><strong>Penjualan</strong></td>
                                        <td colspan="5" class="text-center" style="background-color:aqua;"><strong>Pembayaran</strong></td>
                                    </tr>
                                    <tr>
                                        <td class="text-center" style="background-color:orange;width:9%;" "><strong>Pendaftaran</strong></td>
                                        <td class="text-center" style="background-color:orange;width:8%;" "><strong>Produk</strong></td>
                                        <td class="text-center" style="background-color:orange;width:10%;" "><strong>Total</strong></td>
                                        <td class="text-center" style="background-color:aqua;width:10%;" "><strong>Tunai</strong></td>
                                        <td class="text-center" style="background-color:aqua;width:11%;"><strong>Debit Card</strong></td>
                                        <td class="text-center" style="background-color:aqua;width:11%;"><strong>Credit Card</strong></td>
                                        <td class="text-center" style="background-color:aqua;width:14%;"><strong>Voucher</strong></td>
                                        <td class="text-center" style="background-color:aqua;width:13%;"><strong>Total</strong></td>
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
                                        mlQuery = "SELECT DISTINCT kasir FROM rekap_harian_kasir where nopos like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "'" & vbCrLf
                                        mlQuery += "And year(tgl) = '" & g3 & "') and kasir <> '" & raono & "' order by kasir"
                                        mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                        If mlDR.HasRows Then
                                            mlDT = New Data.DataTable
                                            mlDT.Load(mlDR)
                                            For aaaeqSSS = 1 To mlDT.Rows.Count - 1
                                                kasir = mlDT.Rows(aaaeqSSS)("kasir")
                                                mlQuery2 = "SELECT * from rekap_harian_kasir where nopos like '" & mypos & "' and tipe like '" & tpe1 & "' and (day(tgl) = '" & g1 & "'" & vbCrLf
                                                mlQuery2 += "And month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                                                mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                mlDR2.Read()
                                                If Not mlDR2.HasRows Then
                                                    totjualprd = 0
                                                Else
                                                    totjualprd = mlDR2("totjual")
                                                End If
                                                mlDR2.Close()

                                                mlQuery2 = "SELECT * from rekap_harian_kasir where nopos like '" & mypos & "' and tipe like '" & tpe2 & "'" & vbCrLf
                                                mlQuery2 += "And (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "'"
                                                mlDR2 = mlOBJGS.DbRecordset(mlQuery2, mpMODULEID, mlCOMPANYID)
                                                mlDR2.Read()
                                                If Not mlDR2.HasRows Then
                                                    totjualakt = 0
                                                Else
                                                    totjualakt = mlDR2("totjual")
                                                End If
                                                mlDR2.Close()

                                                mlQuery2 = "SELECT sum(tunai) as vtunai,sum(debit) as vdebit,sum(cc) as vcc,sum(kembalian) as vkembalian,sum(cek) as vcek from rekap_harian_kasir" & vbCrLf
                                                mlQuery2 += "where nopos Like '" & mypos & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "') and kasir like '" & kasir & "' group by kasir"
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
                                                gtoto = gtottunai + gtotdebit + gtotcc + gtotvouc
                                    %>
                                    <tr>
                                        <td>
                                            &nbsp;<a href="#">
                                                <span onclick="javascript:window.open('sale_cetak_kasirinv.aspx?kasir=<%=kasir%>&menu_id=<%=session("menu_id")%>&tgl1=<%=tgl1%>&page=<%=pg+1%>&pgview=<%=bg%>'
                                                    , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=890')" style="text-decoration: none"><%=ucase(kasir)%>
                                                </span>
                                            </a>
                                        </td>
                                        <td class="text-right"><%=FormatNumber(totjualakt, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(totjualprd, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(totjualakt + totjualprd, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(tottunai - totkembali, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(totdebit, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(totcc, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(totvouc, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber((tottunai - totkembali) + totdebit + totcc + totvouc, 0)%>&nbsp;&nbsp;</td>
                                    </tr>
                                    <%
                                            Next
                                        End If
                                        mlDR.Close()
                                    %>
                                    <tr>
                                        <td class="text-right"><strong>GRAND TOTAL</strong></td>
                                        <td class="text-right"><%=FormatNumber(gtotdaftar, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(gtotprd, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(gtote, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(gtottunai, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(gtotdebit, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(gtotcc, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(gtotvouc, 0)%>&nbsp;&nbsp;</td>
                                        <td class="text-right"><%=FormatNumber(gtoto, 0)%>&nbsp;&nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                            <div class="col-md-5">
                                <label>Aksi: Simpan Ke Excel</label>
                            </div>
                            <div class="col-md-7">
                                &nbsp;&nbsp;
                                <a href="#">
                                    <span onClick="javascript:window.open('sale_cetak_rekapkasir.aspx?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&tgl1=<%=tgl1%>&page=<%=pg+1%>&pgview=<%=bg%>'
                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=400, width=890')" style="text-decoration: none">Print Report</span>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-md-12" style="padding-top: 20px">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-center">REKAP TOTAL PENJUALAN PAKET PENDAFTARAN</h3>
                                </div>
                                <div class="panel-body">
                                    <%tpe = "AKT"
                                        mlQuery = "SELECT * FROM rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
                                        mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                        mlDR.Read()
                                        If mlDR.HasRows Then
                                            tgl1 = mlDR("tgl")
                                            totjualakt = mlDR("totjual")
                                            tottunai = mlDR("tunai")
                                            totdebit = mlDR("debit")
                                            totccv = mlDR("cc")
                                            totvouc = mlDR("cek")
                                            jumbayarakt = mlDR("jumbayar")
                                            kembaliakt = mlDR("kembalian")
                                        End If
                                        mlDR.Close()
                                    %>			
                                    <div class="col-md-2">
                                        <label>Tanggal</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;<%=tgl1%></label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Total Penjualan</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totjualakt, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-12">
                                        <label><u>Pembayaran</u></label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Tunai</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(tottunai - kembaliakt, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Debit Card</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totdebit, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Kartu Kredit</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totcc, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Voucher</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totvouc, 0)%>,-</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-center">REKAP TOTAL PENJUALAN PRODUK</h3>
                                </div>
                                <div class="panel-body">
                                    <%
                                        tpe = "PRD"
                                        mlQuery = "SELECT * FROM rekap_harian where nopos like '" & mypos & "' and tipe like '" & tpe & "' and (day(tgl) = '" & g1 & "' and month(tgl) = '" & g2 & "' and year(tgl) = '" & g3 & "')"
                                        mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                        mlDR.Read()
                                        If mlDR.HasRows Then
                                            totjualprd = mlDR("totjual")
                                            tottunaiprd = mlDR("tunai")
                                            totdebitprd = mlDR("debit")
                                            totccv = mlDR("cc")
                                            totvoucprd = mlDR("cek")
                                            jumbayarprd = mlDR("jumbayar")
                                            kembaliprd = mlDR("kembalian")
                                        End If
                                        mlDR.Close()
                                    %>																							
                                    <div class="col-md-2">
                                        <label>Tanggal</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;<%=tgl1%></label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Total Penjualan</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totjualprd, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-12">
                                        <label><u>Pembayaran</u></label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Tunai</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(tottunaiprd - kembaliprd, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Debit Card</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totdebitprd, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Kartu Kredit</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totccv, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-2">
                                        <label>Voucher</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-9">
                                        <label>&nbsp;Rp <%=FormatNumber(totvoucprd, 0)%>,-</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <label>Aksi: Simpan Ke Excel</label>
                        </div>
                        <div class="col-md-7">
                            &nbsp;&nbsp;
                            <a href="#">
                                <span onClick="javascript:window.open('sale_cetak_rekap.aspx?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&tgl1=<%=tgl1%>&page=<%=pg+1%>&pgview=<%=bg%>'
                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=800, width=500')" style="text-decoration: none">
                                    Print Report
                                </span>
                            </a>
                        </div>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-center">HISTORY REKAP PENJUALAN HARIAN</h3>
                                </div>
                                <div class="panel-body">
                                    <form name="actws" method="post" action="rekap_harian.aspx">
                                        <input type="hidden" name="menu_id" value="<%=Session("menu_id")%>">
							            <input type="hidden" name="pgview" value="<%=bg%>">	
							            <input type="hidden" name="page" value="<%=pg+1%>">		
							            <input type="hidden" name="tgl1" value="<%=tgl1%>">
                                        <div class="col-md-12" style="padding-bottom: 20px">
                                            <label>Ditemukan<label style="color:#FF0000;"><%=FormatNumber(x, 0)%></label> rekap harian&nbsp;&nbsp;&nbsp;</label>
                                        </div>
                                        <div class="col-md-1">
                                            <label>Urut</label>
                                        </div>
                                        <div class="col-md-2">
                                            <select class="form-control" name="sort">
                                                <optgroup label="Urutkan">
                                                    <%if sort = "total" Then %>	
													<option value="total" selected>Total</option>																																												
													<option value="tanggal">Tanggal</option>
													<option value="starter">Jumlah Starter</option>		
													<option value="produk">Jumlah Produk</option>															
													<%else%>
													    <%if sort = "tanggal" Then %>
														<option value="total">Total</option>																																												
														<option value="tanggal" selected>Tanggal</option>	
														<option value="starter">Jumlah Starter</option>		
														<option value="produk">Jumlah Produk</option>																
														<%else%>
															<%if sort = "starter" then %>
															<option value="total">Jumlah Total</option>																																												
															<option value="tanggal">Tanggal</option>
															<option value="starter" selected>Jumlah Starter</option>		
															<option value="produk">Jumlah Produk</option>
															<%else%>				
															    <%if sort = "produk" then %>
															    <option value="total">Jumlah Total</option>																																												
															    <option value="tanggal">Tanggal</option>
															    <option value="starter">Jumlah Starter</option>		
															    <option value="produk" selected>Jumlah Produk</option>
															    <%else%>																											
															    <option value="total">Total</option>																																												
															    <option value="tanggal" selected>Tanggal</option>
															    <option value="starter">Jumlah Starter</option>		
															    <option value="produk">Jumlah Produk</option>																																												
															    <%end if%>
															<%end if%>
														<%end if%>
													<%end if%>		
                                                </optgroup>
                                            </select>
                                        </div>
                                        <div class="col-md-2">
                                            <input class="btn btn-default" type="submit" name="btsb2" value="Ok">
                                        </div>
                                    </form>
                                    <form name="view" method="post" action="rekap_harian.aspx">
                                        <div class="col-md-1">
                                            <label>Halaman</label>
                                        </div>
                                        <div class="col-md-2">
                                            <select class="form-control">
                                                <optgroup label="Halaman">
                                                    <%
                                                        aax = 1
                                                        kl = 0
                                                        For aax = 1 To pgct * 2
                                                            kl = kl + 1
                                                    %>			
															<% if kl = pg+1 then %>												
															<option value="<%=kl%>" selected><%=kl%></option>
															<%else%>
															<option value="<%=kl%>"><%=kl%></option>
															<%end if%>																																													
                                                    <%
                                                            If aax > pgct * 2 Then
                                                                Exit For
                                                            End If
                                                            aax = aax + 1
                                                        Next
                                                    %>	
                                                </optgroup>
                                            </select>
                                        </div>
                                        <div class="col-md-4">
                                            <input class="btn btn-default" type="submit" name="btsb1" value="Tampilkan">
                                        </div>
                                    </form>
                                    <div class="col-md-12" style="padding-top: 20px">
                                        <div class="table-responsive">
                                            <table class="table table-condensed table-bordered">
                                                <tr>
                                                    <td style="width:22%;background-color:grey;" rowspan="2" class="text-center"><strong>Tanggal</strong></td>
                                                    <td colspan="2" class="text-center" style="background-color:orange;"><strong>Penjualan</strong></td>
                                                    <td style="width:25%;background-color:aqua;" rowspan="2" class="text-center"><strong>Total</strong></td>
                                                </tr>
                                                <tr>
                                                    <td style="width:28%;background-color:orange;" class="text-center"><strong>Pendaftaran</strong></td>
                                                    <td style="width:25%;background-color:orange;" class="text-center"><strong>Produk</strong></td>
                                                </tr>
                                                <%
                                                    if sort = "tanggal" Then
                                                        mlQuery = "SELECT * FROM sum_rekap_harian where nopos like '" & mypos & "' order by tgl DESC"
                                                    Else
                                                        If sort = "total" Then
                                                            mlQuery = "SELECT * FROM sum_rekap_harian where nopos like '" & mypos & "' order by total DESC"
                                                        Else
                                                            If sort = "starter" Then
                                                                mlQuery = "SELECT * FROM sum_rekap_harian where nopos like '" & mypos & "' order by starter DESC"
                                                            Else
                                                                If sort = "produk" Then
                                                                    mlQuery = "SELECT * FROM sum_rekap_harian where nopos like '" & mypos & "' order by produk DESC"
                                                                Else
                                                                    mlQuery = "SELECT * FROM sum_rekap_harian where nopos like '" & mypos & "' order by tgl DESC"
                                                                End If
                                                            End If
                                                        End If
                                                    End If

                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If Not mlDR.HasRows Then
                                                    %>
                                                    <tr>
                                                        <td colspan="4" class="text-center"><u>Tidak Ada Transaksi</u></td>
                                                    </tr>
                                                    <%
                                                        End If

                                                        If mlDR.HasRows Then
                                                            mlDT = New Data.DataTable
                                                            mlDT.Load(mlDR)
                                                            For aaaeqSSS = 1 To lumpat
                                                                tgl = mlDT.Rows(aaaeqSSS)("tgl")
                                                                totjualakt = mlDT.Rows(aaaeqSSS)("starter")
                                                                totjualprd = mlDT.Rows(aaaeqSSS)("produk")
                                                    %>
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;
                                                            <a href="#">
                                                                <span onClick="javascript:window.open('sale_cetak_rekap.aspx?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&tgl1=<%=tgl%>'
                                                                    , 'HelpWindow','scrollbars=yes, resizable=yes, height=800, width=500')" style="text-decoration: none"><%=tgl%></span>
                                                            </a>
                                                        </td>
                                                        <td class="text-right">Rp <%=FormatNumber(totjualakt, 0)%>,-&nbsp;&nbsp;</td>
                                                        <td class="text-right">Rp <%=FormatNumber(totjualprd, 0)%>,-&nbsp;&nbsp;</td>
                                                        <td class="text-right">Rp <%=FormatNumber(totjualprd + totjualakt, 0)%>,-&nbsp;&nbsp;</td>
                                                    </tr>
                                                    <%
                                                            Next
                                                        End If
                                                        mlDR.Close()
                                                    %>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <label>Aksi: Simpan Ke Excel</label>
                                    </div>
                                    <div class="col-md-7">
                                        &nbsp;&nbsp;
                                        <a href="#">
                                            <span onClick="javascript:window.open('sale_cetak_list_rekapharian.aspx?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&page=<%=pg+1%>&pgview=<%=bg%>'
                                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=500, width=700')" style="text-decoration: none">
                                                Print Report
                                            </span>
                                        </a>
                                    </div>
                                    <div class="col-md-12">
                                        <label>Total Penjualan Selama ini</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Pendaftaran</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-10">
                                        <label>Rp <%=FormatNumber(totstart, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Prduk</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-10">
                                        <label>Rp <%=FormatNumber(totprod, 0)%>,-</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>Total</label>
                                    </div>
                                    <div class="col-md-1">
                                        <label>:</label>
                                    </div>
                                    <div class="col-md-10">
                                        <label>Rp <%=FormatNumber(tottot, 0)%>,-</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="panel panel-default">
                    <div  class="panel-body">
                        <div class="col-md-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <h3 class="panel-title text-center">GRAFIK REKAP PENJUALAN</h3>
                                </div>
                                <table border="0" style="border-spacing:0;padding:0;width:100%">
								    <tr>
									    <td style="vertical-align:top;background-color:#E4E4E4;">
                                            <table border="0" style="width:100%;border-collapse: collapse;padding:0;" id="table14">
                                                <%
                                                mlQuery = "SELECT * FROM sum_rekap_harian where nopos like '" & mypos & "' order by tgl DESC"
                                                mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                If Not mlDR.HasRows Then
                                                %>
                                                <tr>
											        <td style="width:100%;text-align:center;"><u>Tidak ada transaksi</u></td>
										        </tr>
                                                <%

                End If
                If mlDR.HasRows Then
                    mlDT = New Data.DataTable
                    mlDT.Load(mlDR)
                    For aaaeqSSS = 1 To lumpat
                        tgl = mlDT.Rows(aaaeqSSS)("tgl")
                        t1 = mlDT.Rows(aaaeqSSS)("starter")
                        t2 = mlDT.Rows(aaaeqSSS)("produk")
                        t3 = mlDT.Rows(aaaeqSSS)("total")

                        p1 = t1 / 500000
                        p2 = t2 / 500000
                        p3 = t3 / 500000

                                                %>
									            <tr>
												    <td style="width:117px;vertical-align:top;">&nbsp;&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("tgl")%></td>
												    <td style="vertical-align:top;">
												        <table border="0" style="padding:0;border-spacing:0;width:100%;">
													        <tr>
														        <td><img border="0" src="../pos/images/boxgreen.gif" width="<%=p1%>" height="10"></td>
													        </tr>
													        <tr>
														        <td><img border="0" src="../pos/images/boxorange.gif" width="<%=p2%>" height="10"></td>
													        </tr>
													        <tr>
														        <td><img border="0" src="../pos/images/boxblue.gif" width="<%=p3%>" height="10"></td>
													        </tr>
													        <tr>
														        <td>&nbsp;</td>
													        </tr>
												        </table>
												    </td>
											    </tr>    
                                                <%  
                    Next
                End If
                mlDR.Close()

                                                %>																							
										    </table>
										</td>
									</tr>
									<tr>
										<td style="vertical-align:top;background-color:#E4E4E4;">&nbsp;</td>
									</tr>
								</table>
                            </div>
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


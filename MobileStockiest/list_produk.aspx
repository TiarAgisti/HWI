<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="list_produk.aspx.vb" Inherits="MobileStockiest_list_produk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default" style="margin: 5px">
            <div class="panel-heading">
                <h3 class="text-center panel-title"><strong>DAFTAR INVOICE PENJUALAN PRODUK</strong></h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="list_produk.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="page" value="<%=pg+1%>">
                            <table>
		                        <tr>
			                        <td><label>Tanggal</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td><input type="text" name="tgl1" class="form-control" style="width:250px;" value="<%=Now.Date%>"></td>
			                        <td><label>&nbsp;s/d&nbsp;</label></td>
			                        <td><input type="text" name="tgl2" class="form-control" style="width:250px;" value="<%=Now.Date%>"></td>
		                        </tr>
		                        <tr>
			                        <td><label>Kasir</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="kasir" style="width:250px;">
					                        <option value="semua">--ALL--</option>
                                            <%
                                                pos = "pos"
                                                mlQuery = "SELECT kta FROM tabdesc_stockist_user where nopos like '" & mypos & "' and kat like '" & pos & "' order by kta"
                                                mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                If mlDR.HasRows Then
                                                    mlDT = New Data.DataTable
                                                    mlDT.Load(mlDR)
                                                    For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                            %>
                                                <%if kasir = UCase(mlDT.Rows(aaaeqsK)("kta")) Then %>
                                                <option value="<%=mlDT.Rows(aaaeqsK)("kta")%>" selected><%=UCase(mlDT.Rows(aaaeqsK)("kta"))%></option>
                                                <%Else%>
                                                <option value="<%=mlDT.Rows(aaaeqsK)("kta")%>"><%=UCase(mlDT.Rows(aaaeqsK)("kta"))%></option>
                                                <%End If%> 
                                            <%
                                                    Next
                                                End If
                                                mlDR.Close()
                                            %>	
				                        </select>
			                        </td>
			                        <td></td>
			                        <td><input type="submit" name="btsb4" value="Tampilkan" class="btn"></td>
		                        </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="acts" method="post" action="list_produk.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="kasir" value="<%=kasir%>">	
							<input type="hidden" name="page" value="<%=pg+1%>">		
							<input type="hidden" name="tgl1" value="<%=tgl1%>">
							<input type="hidden" name="tgl2" value="<%=tgl2%>">
                            <table>
		                        <tr>
			                        <td><label style="width:120px;">Urut Berdasarkan</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="sort" style="width:250px;">
											<%if sort = "bulan" then %>	
											<option value="Bulan" selected>Bulan</option>																																												
											<option value="tanggal">Tanggal</option>
											<%else%>
												<%if sort = "tanggal" then %>
												<option value="Bulan">Bulan</option>																																												
												<option value="tanggal" selected>Tanggal</option>		
												<%else%>
												<option value="Bulan">Bulan</option>																																												
												<option value="tanggal" selected>Tanggal</option>																													
												<%end if%>
											<%end if%>
				                        </select>
			                        </td>
			                        <td>&nbsp;</td>
			                        <td><input type="submit" name="btsb2" value="Ok" class="btn"></td>
		                        </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <p style="text-align:left;">
                            <b style="color:#FF0000">Ditemukan <%=FormatNumber(x, 0)%> transaksi&nbsp;&nbsp;&nbsp;</b>
                        </p>
                        <form name="view" method="post" action="list_produk.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="sort" value="<%=sort%>">	
							<input type="hidden" name="kasir" value="<%=kasir%>">	
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="tgl1" value="<%=tgl1%>">
							<input type="hidden" name="tgl2" value="<%=tgl2%>">
                             <table>
		                        <tr>
			                        <td><label style="width:120px;">Tampilkan Halaman</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="page" style="width:250px;">
					                       <%

                                               aax = 1
                                               kl = 0
                                               for aax = 1 to pgct*2
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
				                        </select>
			                        </td>
			                        <td>&nbsp;</td>
			                        <td><input type="submit" name="btsb1" value="Tampilkan" class="btn"></td>
		                        </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="col-md-12 col-md-offset-0">
                    <p></p>
                </div>
                <div class="col-lg-offset-8 col-md-2">
                    <label>&nbsp;</label>
                    <label>&nbsp;</label>
                </div>
                <div class="col-lg-offset-0 col-md-2">
                    <label>Aksi :</label>
                    <img src="../pos/images/print_version.gif">
                    <label>
                        &nbsp;&nbsp;
                        <a href="#">
                            <span onClick="javascript:window.open('sale_cetak_list_prd.aspx?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&kasir=<%=kasir%>&tgl1=<%=tgl1%>&tgl2=<%=tgl2%>&page=<%=pg+1%>&pgview=<%=bg%>'
                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=980')" style="text-decoration: none">Print Report</span>
                        </a>
                    </label>
                </div>
                <div class="col-md-12">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <table class="table table-condensed">
                                <thead class="table table-bordered">
                                    <tr class="table-bordered">
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Tanggal</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Nomor Referensi</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Nomor Invoice</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">No. Dist.</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Nama Distributor</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">PV</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Nominal</div>
                                        </th>
                                        <th colspan="4" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Pembayaran</div>
                                        </th>
                                    </tr>
                                    <tr class="table-bordered">
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Tunai</div>
                                        </th>
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Debit Card</div>
                                        </th>
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Credit Card</div>
                                        </th>
                                        <th style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Voucher</div>
                                        </th>
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
                                                mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "'  and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by month(tgl) DESC, year(tgl) DESC"
                                            Else
                                                If sort = "tanggal" Then
                                                    mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "'  and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                    mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                Else
                                                    mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "'  and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                    mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by tgl DESC"
                                                End If
                                            End If
                                        Else
                                            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" Then
                                                If sort = "Bulan" Then
                                                    mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "'  and kta like '" & kasir & "'" & vbCrLf
                                                    mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) order by month(tgl) DESC, year(tgl) DESC"
                                                Else
                                                    If sort = "tanggal" Then
                                                        mlQuery = "SELECT * FROM st_sale_prd_head where nopos like '" & mypos & "'  and kta like '" & kasir & "'" & vbCrLf
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
                                            <td colspan="11" class="table-bordered text-center">
                                                <u style="color:#000000">Tidak ada transaksi penjualan produk</u>
                                            </td>
                                        </tr>
                                        <%
                                            End If

                                            If mlDR.HasRows Then
                                                mlDT = New Data.DataTable
                                                mlDT.Load(mlDR)
                                                For aaaeqSSS = 1 To lumpat
                                                    tpe = UCase(mlDT.Rows(aaaeqSSS)("tipe"))
                                                    If tpe = "TOPUP" Then
                                                        bgcol = "#FFEFDF"
                                                    Else
                                                        If tpe = "DEPOSIT" Then
                                                            bgcol = "#FFFFCE"
                                                        Else
                                                            bgcol = "#E1FFE1"
                                                        End If
                                                    End If

                                                    If mlDT.Rows(aaaeqSSS)("nodist") = "1106732" Or mlDT.Rows(aaaeqSSS)("nodist") = "1197691" Or mlDT.Rows(aaaeqSSS)("nodist") = "1197692" Then
                                                        totnom = totnom
                                                        tottunai = tottunai
                                                        totdebit = totdebit
                                                        totcc = totcc
                                                        totbg = totbg
                                                    Else
                                                        totnom = totnom + mlDT.Rows(aaaeqSSS)("subtot")
                                                        tottunai = tottunai + (mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"))
                                                        totdebit = totdebit + mlDT.Rows(aaaeqSSS)("debit")
                                                        totcc = totcc + mlDT.Rows(aaaeqSSS)("cc")
                                                        totbg = totbg + mlDT.Rows(aaaeqSSS)("cek")
                                                    End If

                                                    If mlDT.Rows(aaaeqSSS)("nodist") <> "1106732" And mlDT.Rows(aaaeqSSS)("nodist") <> "1197691" And mlDT.Rows(aaaeqSSS)("nodist") <> "1197692" Then
                                        %>
                                        <tr class="table-bordered">
                                            <td style="text-align:right;" class="table-bordered"><%=mlDT.Rows(aaaeqSSS)("tgl")%></td>
                                            <td style="text-align:right;" class="table-bordered">
                                                <%if tpe = "DEPOSIT" then %>
                                                <a href="#">
                                                    <span onClick="javascript:window.open('sale_cetak_invoice_prd_autosave.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>'
                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("noinvoice")%></span>
                                                </a>
                                                <%else%>
                                                <a href="#">
                                                    <span onClick="javascript:window.open('sale_cetak_invoice_prd.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>'
                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("noinvoice")%></span>
                                                </a>
                                                <%end if%>
                                            </td>
                                            <td style="text-align:right;" class="table-bordered">
                                                <%if tpe = "DEPOSIT" then %>
                                                <a href="#">
                                                    <span onClick="javascript:window.open('sale_cetak_invoice_prd_autosave.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>'
                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("nopajak")%></span>
                                                </a>
                                                <%else%>
                                                <a href="#">
                                                    <span onClick="javascript:window.open('sale_cetak_invoice_prd.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvoice")%>&menu_id=<%=session("menu_id")%>'
                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("nopajak")%></span>
                                                </a>
                                                <%end if%>
                                            </td>
                                            <td style="text-align:right;" class="table-bordered">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("nodist")%></td>
                                            <td style="text-align:right;" class="table-bordered">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("namadist")%></td>
                                            <td style="text-align:center;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("totpv"), 2)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("subtot"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("debit"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("cc"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("cek"), 0)%>&nbsp;&nbsp;</td>
                                        </tr>
                                        <%
                                                    End If
                                                Next
                                            End If
                                            mlDR.Close()
                                        %>
                                        <tr class="table-bordered">
                                            <td colspan="6" style="text-align:right;" class="table-bordered"><strong>Grand Total</strong></td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(totnom, 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(tottunai, 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(totdebit, 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(totcc, 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(totbg, 0)%>&nbsp;&nbsp;</td>
                                        </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <div>
                    <div class="col-md-5">
                        <div>
                            <div class="table-responsive">
                                <table border="0" class="table">
                                    <tr>
                                        <td>
                                            <table border="0">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3"><strong>GRAND TOTAL DARI TANGGAL <%=FormatDateTime(tg1, 1)%> s/d <%=FormatDateTime(tg2, 1)%></strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                        <td style="width:5%;"><span class="style3">:&nbsp;</span></td>
                                                        <td style="width:75%;"><span class="style3">Rp <%=FormatNumber(gtottunai, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Debit Card</span></td>
                                                        <td><span class="style3">:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotdebit, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Credi Card</span></td>
                                                        <td><span class="style3">:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotkartu, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Voucher</span></td>
                                                        <td><span class="style3">:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotbg, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                        <td><span class="style3"><strong>:&nbsp;</strong></span></td>
                                                        <td><span class="style3"><strong><b>Rp <%=FormatNumber(gtottunai + gtotdebit + gtotkartu + gtotbg, 0)%>,-</b></strong></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3"><label></label></span></td>
                                                        <td><span class="style3"></span></td>
                                                        <td><span class="style3"></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color:bisque;"></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Indikator invoice belanja sistem topup</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color:Lightskyblue"></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Indikator invoice belanja sistem quadroplan (split point)</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="background-color:yellow"></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Indikator invoice belanja deposit PV</span></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
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


<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_rekap_order_prd.aspx.vb" Inherits="MobileStockiest_mc_rekap_order_prd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color: white;">
        <div class="panel panel-default" style="margin: 5px">
            <div class="panel-heading">
                <h3 class="text-center panel-title"><strong>DAFTAR INVOICE PENJUALAN PRODUK KE MOBILE CENTER</strong></h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="mc_involist_prd.aspx">
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
					                        <optgroup label="Group Kasir">
                                                <option value="semua">--ALL--</option>
                                                <%
                                                    pos = "pos"
                                                    pos2 = "pst"
                                                    mlQuery = "SELECT kta FROM tabdesc_stockist_user where nopos like '" & mypos & "' and ((kat like '" & pos & "') or (kat like '" & pos2 & "')) order by kta"
                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)
                                                        For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                               %>
                                                        <%if ucase(kasir) = ucase(mlDT.Rows(aaaeqsK)("kta")) Then %>
                                                        <option value="<%=mlDT.Rows(aaaeqsK)("kta")%>" selected><%=UCase(mlDT.Rows(aaaeqsK)("kta"))%></option>
                                                        <%Else%>
                                                        <option value="<%=mlDT.Rows(aaaeqsK)("kta")%>"><%=UCase(mlDT.Rows(aaaeqsK)("kta"))%></option>
                                                        <%End If%>
                                                <%
                                                        Next
                                                    End If
                                                    mlDR.Close()
                                                %>		

                                            </optgroup>
				                        </select>
			                        </td>
		                        </tr>
                                <tr>
                                    <td style="width:84px;text-align:left;">No. Id. MC.&nbsp;</td>
                                    <td><label>&nbsp;:&nbsp;</label></td>
                                    <td style="width:170px;">
                                        <select class="form-control" name="nomc">
                                            <optgroup label="Group Id MC">
                                                <option value="semua">--ALL--</option>
                                                <%
                                                    mlQuery = "SELECT nopos FROM tabdesc_stockist where indukmc like '" & mypos & "' order by nopos"
                                                    mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                    If mlDR.HasRows Then
                                                        mlDT = New Data.DataTable
                                                        mlDT.Load(mlDR)
                                                        For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                %>
                                                        <%if ucase(nomc) = ucase(mlDT.Rows(aaaeqsK)("nopos")) Then %>
                                                        <option value="<%=mlDT.Rows(aaaeqsK)("nopos")%>" selected><%=UCase(mlDT.Rows(aaaeqsK)("nopos"))%></option>
                                                        <%Else%>
                                                        <option value="<%=mlDT.Rows(aaaeqsK)("nopos")%>"><%=UCase(mlDT.Rows(aaaeqsK)("nopos"))%></option>
                                                        <%End If%> 
                                                <%
                                                        Next
                                                    End If
                                                    mlDR.Close()
                                                %>	
                                            </optgroup>
                                        </select>
                                    </td>
                                    <td>&nbsp;</td>
                                    <td style="width:190px;">
                                        <input class="btn btn-default" type="submit" name="btsb4" value="Tampilkan"><%=kondisi%>
                                    </td>
                                    <td>&nbsp;</td>     													
                                </tr>	
	                        </table>
                        </form>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="acts" method="post" action="mc_involist_prd.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="kasir" value="<%=kasir%>">
							<input type="hidden" name="nomc" value="<%=nomc%>">	
							<input type="hidden" name="page" value="<%=pg+1%>">		
							<input type="hidden" name="tgl1" value="<%=tgl1%>">
							<input type="hidden" name="tgl2" value="<%=tgl2%>">
                            <table>
		                        <tr>
			                        <td><label style="width:120px;">Urut Berdasarkan</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="sort" style="width:250px;">
											 <optgroup label="Group urutkan">
                                                <%if sort = "bulan" Then %>	
											        <option value="Bulan" selected>Bulan</option>																																												
											        <option value="tanggal">Tanggal</option>
										        <%else%>
										            <%if sort = "tanggal" Then %>
											            <option value="Bulan">Bulan</option>																																												
											            <option value="tanggal" selected>Tanggal</option>		
										            <%else%>
												        <option value="Bulan">Bulan</option>																																												
												        <option value="tanggal" selected>Tanggal</option>																													
											        <%end if%>
										        <%end if%>
                                            </optgroup>
				                        </select>
			                        </td>
			                        <td>&nbsp;</td>
			                        <td><input type="submit" name="btsb2" value="OK" class="btn"></td>
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
                        <form name="view" method="post" action="mc_involist_prd.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="sort" value="<%=sort%>">	
							<input type="hidden" name="kasir" value="<%=kasir%>">	
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="nomc" value="<%=nomc%>">	
							<input type="hidden" name="tgl1" value="<%=tgl1%>">
							<input type="hidden" name="tgl2" value="<%=tgl2%>">
                             <table>
		                        <tr>
			                        <td><label>Tampilkan Halaman</label></td>
			                        <td><label>&nbsp;:&nbsp;</label></td>
			                        <td>
				                        <select class="form-control" name="page" style="width:250px;">
					                        <optgroup label="Group Halaman">
                                                <option value="0" selected>0</option>
					                    <%
                                            aax = 1
                                            kl = 0
                                            For aax = 1 To pgct * 2
                                                kl = kl + 1
                                        %>
                                                <%if kl = pg + 1 Then %>												
											        <option value="<%=kl%>" selected><%=kl%></option>
												<%  Else%>
													<option value="<%=kl%>"><%=kl%></option>
												<%  End If%>
                                        <%
                                                If aax > pgct * 2 Then
                                                    Exit For
                                                End If
                                                aax = aax + 1
                                            Next
                                        %>	
                                            </optgroup>
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
                    <img src="../pos/images/print_version.gif">
                    <label>
                        &nbsp;&nbsp;
                        <a href="#">
                            <span onClick="javascript:window.open('mc_cetak_list_prd.aspx?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&kasir=<%=kasir%>&tgl1=<%=tgl1%>&tgl2=<%=tgl2%>&page=<%=pg+1%>&pgview=<%=bg%>&nomc=<%=nomc%>'
                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=980')" style="text-decoration: none">
                                Print Report
                            </span>
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
                                            <div style="text-align:center;">Kasir</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">No. Id Mobile Center</div>
                                        </th>
                                        <th rowspan="2" style="background-color:#CCCCCC;" class="table-bordered">
                                            <div style="text-align:center;">Tipe</div>
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
                                            <div style="text-align:center;">Transfer</div>
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
                                        If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc = "semua" Then
                                            If sort = "Bulan" Then
                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "')" & vbCrLf
                                                mlQuery += "And (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by month(tgl) DESC, year(tgl) DESC"
                                            Else
                                                If sort = "tanggal" Then
                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                    mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                Else
                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                    mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and" & vbCrLf
                                                    mlQuery += "(status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                End If
                                            End If
                                        Else
                                            If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                                                If sort = "Bulan" Then
                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                                                    mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                    mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by month(tgl) DESC, year(tgl) DESC"
                                                Else
                                                    If sort = "tanggal" Then
                                                        mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                        mlQuery += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                        mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                    Else
                                                        mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                        mlQuery += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                        mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                    End If
                                                End If
                                            Else
                                                If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                                                    If sort = "Bulan" Then
                                                        mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                        mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                        mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by month(tgl) DESC, year(tgl) DESC"
                                                    Else
                                                        If sort = "tanggal" Then
                                                            mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                            mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                        Else
                                                            mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                            mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                        End If
                                                    End If
                                                Else
                                                    If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                                                        If sort = "Bulan" Then
                                                            mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                            mlQuery += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                            mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by month(tgl) DESC, year(tgl) DESC"
                                                        Else
                                                            If sort = "tanggal" Then
                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                                mlQuery += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                                mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                            Else
                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                                mlQuery += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                                mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                            End If
                                                        End If
                                                    Else
                                                        If sort = "Bulan" Then
                                                            mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                            mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by month(tgl) DESC, year(tgl) DESC"
                                                        Else
                                                            If sort = "tanggal" Then
                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                                mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                            Else
                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nomc like '" & mypos & "'" & vbCrLf
                                                                mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                            End If
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If

                                        mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                        If Not mlDR.HasRows Then
                                        %>
                                        <tr>
                                            <td colspan="11" class="table-bordered"><u>Tidak ada transaksi penjualan produk ke mobile center</u></td>
                                        </tr>
                                        
                                        <%
                                            End If


                                            If mlDR.HasRows Then
                                                For aaaeqSSS = 1 To lumpat
                                                    totnom = totnom + mlDT.Rows(aaaeqSSS)("gtot")
                                                    tottunai = tottunai + (mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"))
                                                    totdebit = totdebit + mlDT.Rows(aaaeqSSS)("debit")
                                                    totcc = totcc + mlDT.Rows(aaaeqSSS)("cc")
                                                    totbg = totbg + mlDT.Rows(aaaeqSSS)("cek")

                                                    If mlDT.Rows(aaaeqSSS)("kat") = "PRD" Then
                                                        sels = "normal"
                                                    Else
                                                        If mlDT.Rows(aaaeqSSS)("kat") = "PDN" Then
                                                            sels = "perdana"
                                                        Else
                                                            sels = ""
                                                        End If
                                                    End If

                                        %>
                                        <tr class="table-bordered">
                                            <td style="text-align:center;" class="table-bordered"><%=mlDT.Rows(aaaeqSSS)("kat")("tgl")%></td>
                                            <td style="text-align:center;" class="table-bordered">
                                               <%if mlDT.Rows(aaaeqSSS)("kat") = "PDN" Then %>
												    <a href="#">
                                                        <span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvo")%>&menu_id=<%=Session("menu_id")%>&asal=<%=sels%>'
                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=900')" style="text-decoration: none">
                                                            <%=mlDT.Rows(aaaeqSSS)("noinvo")%>
                                                        </span>
												    </a>
												<%      Else%>
													<a href="#">
                                                        <span onClick="javascript:window.open('mc_cetak_invoice_produk.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvo")%>&menu_id=<%=session("menu_id")%>&asal=<%=sels%>'
                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none">
                                                            <%=mlDT.Rows(aaaeqSSS)("noinvo")%>
                                                        </span>
													</a>
												<%End If%>
                                            </td>
                                            <td style="text-align:center;" class="table-bordered">
                                                <%if mlDT.Rows(aaaeqSSS)("kat") = "PDN" Then %>
												    <a href="#">
                                                        <span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvo")%>&menu_id=<%=Session("menu_id")%>&asal=<%=sels%>'
                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=900')" style="text-decoration: none">
                                                            <%=mlDT.Rows(aaaeqSSS)("nopajak")%>
                                                        </span>
												    </a>															
												<%Else%>
													<a href="#">
                                                        <span onClick="javascript:window.open('mc_cetak_invoice_produk.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("noinvo")%>&menu_id=<%=session("menu_id")%>&asal=<%=sels%>'
                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none">
                                                            <%=mlDT.Rows(aaaeqSSS)("nopajak")%>
                                                        </span>
													</a>
												<%End If%>
                                            </td>
                                            <td style="text-align:center;" class="table-bordered"><%=UCase(mlDT.Rows(aaaeqSSS)("kta"))%></td>
                                            <td style="text-align:left;" class="table-bordered">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("nomc")%></td>
                                            <td style="text-align:center;" class="table-bordered">
                                                <p style="text-align:center;">
											    <label style="color:#008000;">
												<%If mlDT.Rows(aaaeqSSS)("kat") = "PRD" Then %>
												    Produk
												<%else%>
												    <%If mlDT.Rows(aaaeqSSS)("kat") = "PDN" Then %>
												    </label>
												    <label style="color:#0000FF;">Perdana</label>
												    <%else%>
													<label style="color:#FF0000;">UNKNOWN</label>
													<%end if%>
												<%end if%>
                                            </td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("gtot"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("tunai") - mlDT.Rows(aaaeqSSS)("kembalian"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("debit"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("cc"), 0)%>&nbsp;&nbsp;</td>
                                            <td style="text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqSSS)("cek"), 0)%>&nbsp;&nbsp;</td>
                                        </tr>
                                        <%

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
                <div class="col-md-12">
                    <div>
                        <div class="col-md-4">
                            <div>
                                <div class="table-responsive">
                                    <table border="0" class="table">
                                        <tr>
                                            <td>
                                                <table border="0">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="3"><span class="style3">RINGKASAN TANGGAL<%=FormatDateTime(tg1, 1)%> s/d <%=FormatDateTime(tg2, 1)%></span></th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="3"><u><span class="style3"><strong>GRAND TOTAL TABUNGAN</strong></span></u></td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                            <td style="width:8%;"><span class="style3">:</span></td>
                                                            <td style="width:72%;"><span class="style3">Rp <%=FormatNumber(gtottunai, 0)%>,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3">Debit Card</span></td>
                                                            <td><span class="style3">:</span></td>
                                                            <td><span class="style3">Rp <%=FormatNumber(gtotdebit, 0)%>,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3">Credit Card</span></td>
                                                            <td><span class="style3">:</span></td>
                                                            <td><span class="style3">Rp <%=FormatNumber(gtotkartu, 0)%>,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3">Transfer</span></td>
                                                            <td><span class="style3">:</span></td>
                                                            <td><span class="style3">Rp <%=FormatNumber(gtotbg, 0)%>,-</span></td>
                                                        </tr>
                                                        <tr>
                                                            <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                            <td><span class="style3"><strong>:</strong></span></td>
                                                            <td><span class="style3"><strong><b>Rp <%=FormatNumber(gtottunai + gtotdebit + gtotkartu + gtotbg, 0)%>,-</b></strong></span></td>
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
                <div>
                    <div class="col-md-4">
                        <div>
                            <div class="table-responsive">
                                <table class="table">
                                    <tr>
                                        <td>
                                            <table border="0">
                                                <thead>
                                                    <tr>
                                                        <th colspan="3">&nbsp;</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><span class="style3">
                                                                <strong>GRAND TOTAL PERDANA</strong>
                                                            </span></u>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                        <td style="width:8%;"><span class="style3">:</span></td>
                                                        <td style="width:72%;"><span class="style3">Rp <%=FormatNumber(gtottunai_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Debit Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotdebit_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Credit Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotkartu_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Transfer</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotbg_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                        <td><span class="style3"><strong>:</strong></span></td>
                                                        <td><span class="style3"><strong><b>Rp <%=FormatNumber(gtottunai_pdn + gtotdebit_pdn + gtotkartu_pdn + gtotbg_pdn, 0)%>,-</b></strong></span></td>
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
                <div>
                    <div class="col-md-4">
                        <div>
                            <div class="table-responsive">
                                <table class="table">
                                    <tr>
                                        <td>
                                            <table border="0">
                                                <thead>
                                                    <tr>
                                                        <th colspan="3">&nbsp;</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3">
                                                            <u><span class="style3">
                                                                <strong>GRAND TOTAL PRODUK</strong>
                                                            </span></u>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                        <td style="width:8%;"><span class="style3">:</span></td>
                                                        <td style="width:72%;"><span class="style3">Rp <%=FormatNumber(gtottunai_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Debit Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotdebit_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Credit Card</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotkartu_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Transfer</span></td>
                                                        <td><span class="style3">:</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotbg_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                        <td><span class="style3"><strong>:</strong></span></td>
                                                        <td><span class="style3"><strong><b>Rp <%=FormatNumber(gtottunai_prd + gtotdebit_prd + gtotkartu_prd + gtotbg_prd, 0)%>,-</b></strong></span></td>
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
    </section>
</asp:Content>


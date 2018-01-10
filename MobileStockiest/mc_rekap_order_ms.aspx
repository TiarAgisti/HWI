<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_rekap_order_ms.aspx.vb" Inherits="MobileStockiest_mc_rekap_order_ms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .col-md-4 div {
            color: #000;
        }

        .style1 {
            color: #FF0000;
        }

        .DIV1 {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color:white;">
       <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="text-center panel-title" style="font-family:Arial;">
                    <strong>DAFTAR INVOICE PENJUALAN PRODUK KE MOBILE CENTER</strong>
                </h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <form action="mc_rekap_order_ms.aspx">
                        <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
						<input type="hidden" name="pgview" value="<%=bg%>">	
						<input type="hidden" name="page" value="<%=CDbl(pg) + 1%>">
                        <div class="panel-body">
                            <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
                                <tr>
                                    <td style="width:75px;text-align:left;"><label>Tanggal</label></td>
                                    <td style="width:5px;text-align:left;"><label>&nbsp;:&nbsp;</label></td>
                                    <td style="width:170px;">
                                        <input class="form-control" type="text" name="tgl1" value="<%=Now.Date%>">
                                    <td style="width:25px;">
                                        <div style="text-align:center;"><label>&nbsp;s/d&nbsp;</label></div>
                                    </td>
                                    <td style="width:170px;">
                                        <input class="form-control" type="text" name="tgl2" value="<%=Now.Date%>">
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                            <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
                                <tr>
                                    <td style="width:75px;text-align:left;"><label>Kasir</label></td>
                                    <td style="width:5px;text-align:left;"><label>&nbsp;:&nbsp;</label></td>
                                    <td style="width:170px;">
                                        <select class="form-control" name="kasir">
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
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width:75px;text-align:left;"><label>No. Id. MC.</label></td>
                                     <td style="width:5px;text-align:left;"><label>&nbsp;:&nbsp;</label></td>
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
                                     <td style="width:25px;"></td>
                                    <td style="width:25px;">
                                        <input class="btn btn-default" type="submit" name="btsb4" value="Tampilkan"><%=kondisi%>
                                    </td>
                                    <td style="width:170px;"></td>
                                    <td>&nbsp;</td>												
                                </tr>
                            </table>
                        </div>
                    </form>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <form name="acts" method="post" action="mc_rekap_order_ms.aspx">
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
			                        <td style="width:5px;text-align:left;"><label>&nbsp;:&nbsp;</label></td>
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
                            <b style="color:#FF0000"><%--Ditemukan <%=formatnumber(x, 0)%> transaksi&nbsp;&nbsp;&nbsp;--%></b>
                        </p>
                        <form name="view" method="post" action="mc_rekap_order_ms.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
							<input type="hidden" name="sort" value="<%=sort%>">	
							<input type="hidden" name="kasir" value="<%=kasir%>">	
							<input type="hidden" name="pgview" value="<%=bg%>">	
							<input type="hidden" name="nomc" value="<%=nomc%>">	
							<input type="hidden" name="tgl1" value="<%=tgl1%>">
							<input type="hidden" name="tgl2" value="<%=tgl2%>">
                             <table>
		                        <tr>
			                        <td><label style="width:120px;">Tampilkan Halaman</label></td>
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
                <div class="panel panel-default">
                    <div class="panel-body">
                        <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
                            <tr>
                                <td style="width:245px;">
                                    <div></div>
                                    <div></div>
                                    <div class="col-md-12 col-md-offset-0"><p></p></div>
                                    <div class="col-lg-offset-8 col-md-2">
                                        <label>Aksi : </label><%--<img>--%>
                                        <label>Simpan Ke Excel</label>
                                    </div>
                                    <div class="col-lg-offset-0 col-md-2"><%--<img>--%>
                                        <label>Print Report</label>
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
                                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCancel
                                                                    mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')" & vbCrLf
                                                                    mlQuery += "order by month(tgl) DESC, year(tgl) DESC"
                                                                Else
                                                                    If sort = "tanggal" Then
                                                                        mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                        mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                    Else
                                                                        mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                        mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                    End If
                                                                End If
                                                            Else
                                                                If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc = "semua" Then
                                                                    If sort = "Bulan" Then
                                                                        mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'  and kta like '" & kasir & "'" & vbCrLf
                                                                        mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')" & vbCrLf
                                                                        mlQuery += "order by month(tgl) DESC, year(tgl) DESC"
                                                                    Else
                                                                        If sort = "tanggal" Then
                                                                            mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'  and kta like '" & kasir & "'" & vbCrLf
                                                                            mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                        Else
                                                                            mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'  and kta like '" & kasir & "'" & vbCrLf
                                                                            mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                        End If
                                                                    End If
                                                                Else
                                                                    If tgl1 <> "" And tgl2 <> "" And kasir = "semua" And nomc <> "semua" Then
                                                                        If sort = "Bulan" Then
                                                                            mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                            mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')" & vbCrLf
                                                                            mlQuery += "order by month(tgl) DESC, year(tgl) DESC"
                                                                        Else
                                                                            If sort = "tanggal" Then
                                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                                mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                            Else
                                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                                mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')" & vbCrLf
                                                                                mlQuery += "order by tgl DESC"
                                                                            End If
                                                                        End If
                                                                    Else
                                                                        If tgl1 <> "" And tgl2 <> "" And kasir <> "semua" And nomc <> "semua" Then
                                                                            If sort = "Bulan" Then
                                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "' and kta like '" & kasir & "'" & vbCrLf
                                                                                mlQuery += "And ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "')) and (status = '" & oke & "' or status = '" & oke2 & "')" & vbCrLf
                                                                                mlQuery += "order by month(tgl) DESC, year(tgl) DESC"
                                                                            Else
                                                                                If sort = "tanggal" Then
                                                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat Like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                                    mlQuery += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                                                    mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                                Else
                                                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                                    mlQuery += "And kta Like '" & kasir & "' and ((convert(varchar(10),tgl,121) >= '" & tg1 & "') and (convert(varchar(10),tgl,121) <= '" & tg2 & "'))" & vbCrLf
                                                                                    mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                                End If
                                                                            End If
                                                                        Else
                                                                            If sort = "Bulan" Then
                                                                                mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                                mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by month(tgl) DESC, year(tgl) DESC"
                                                                            Else
                                                                                If sort = "tanggal" Then
                                                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
                                                                                    mlQuery += "And (status = '" & oke & "' or status = '" & oke2 & "') order by tgl DESC"
                                                                                Else
                                                                                    mlQuery = "SELECT TOP " & lim & " * FROM fax_order_mc_head where (kat like '" & kti & "' or kat like '" & ktm & "') and nopos like '" & mypos & "'" & vbCrLf
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
                                                                <td colspan="11" class="table-bordered" style="text-align:center;">Tidak ada transaksi penjualan produk ke mobile center</td>
                                                            </tr>
                                                        <%
                                                            End If
                                                        %>
                                                        <%
                                                            If mlDR.HasRows Then
                                                                mlDT = New Data.DataTable
                                                                mlDT.Load(mlDR)
                                                                For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                        %>
                                                        <tr>
                                                            <td style="width:12%;text-align:center;" class="table-bordered"><%=mlDT.Rows(aaaeqsK)("tgl")%></td>
                                                            <td style="width:13%;text-align:center;" class="table-bordered">
															    <% If mlDT.Rows(aaaeqsK)("kat") = "PDN" Then %>
															        <a href="#">
                                                                    	<span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqsK)("noinvo")%>&menu_id=<%=Session("menu_id")%>&asal=<%=sels%>'
                                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=900')" style="text-decoration: none">
                                                                            <%=mlDT.Rows(aaaeqsK)("noinvo")%>
                                                                        </span>
                                                                     </a>
																<%Else%>
																	<a href="#">
                                                                    	<span onClick="javascript:window.open('mc_cetak_invoice_produk.aspx?noinvoice=<%=mlDT.Rows(aaaeqsK)("noinvo")%>&menu_id=<%=session("menu_id")%>&asal=<%=sels%>'
                                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none">
                                                                            <%=mlDT.Rows(aaaeqsK)("noinvo")%>
                                                                    	</span>
                                                                    </a>
																<%End If%>
                                                            </td>
                                                            <td style="width:7%;text-align:center;" class="table-bordered">
																<%  If mlDT.Rows(aaaeqsK)("kat") = "PDN" Then %>
																	<a href="#">
                                                                    	<span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqsK)("noinvo")%>&menu_id=<%=Session("menu_id")%>&asal=<%=sels%>'
                                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=900')" style="text-decoration: none">
                                                                            <%=mlDT.Rows(aaaeqsK)("nopajak")%>
                                                                    	</span>
                                                                    </a>																
																<%Else%>
																	<a href="#">
                                                                    	<span onClick="javascript:window.open('mc_cetak_invoice_produk.aspx?noinvoice=<%=mlDT.Rows(aaaeqsK)("noinvo")%>&menu_id=<%=session("menu_id")%>&asal=<%=sels%>'
                                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none">
																		    <%=mlDT.Rows(aaaeqsK)("nopajak")%>
                                                                        </span>
                                                                    </a>
																<%End If%>
                                                            </td>	
                                                            <td style="width:9%;text-align:center;" class="table-bordered"><%=UCase(mlDT.Rows(aaaeqsK)("kta"))%></td>
                                                            <td style="width:13%;" class="table-bordered">&nbsp;&nbsp;<%=mlDT.Rows(aaaeqsK)("nomc")%></td>
                                                            <td style="width:6%;text-align:center;" class="table-bordered">
																<p style="text-align:center;">
																	<label style="color:#008000;">
																	<% If mlDT.Rows(aaaeqsK)("kat") = "PRD" Then %>
																		Produk
																	<%else%>
																		<%    If mlDT.Rows(aaaeqsK)("kat") = "PDN" Then %>
																		</label>
																		<label style="color:#0000FF;">Perdana</label>
																		<%else%>
																		<label style="color:#FF0000;">UNKNOWN</label>
																		<%end if%>
																	<%end if%>
                                                                </p>	
															</td>
                                                            <td style="width:8%;text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqsK)("gtot"), 0)%>&nbsp;&nbsp;</td>
                                                            <td style="width:8%;text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqsK)("tunai") - mlDT.Rows(aaaeqsK)("kembalian"), 0)%>&nbsp;&nbsp;</td>
                                                            <td style="width:8%;text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqsK)("debit"), 0)%>&nbsp;&nbsp;</td>
															<td style="width:8%;text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqsK)("cc"), 0)%>&nbsp;&nbsp;</td>
															<td style="width:8%;text-align:right;" class="table-bordered"><%=FormatNumber(mlDT.Rows(aaaeqsK)("cek"), 0)%>&nbsp;&nbsp;</td>
                                                        </tr>
                                                        <%
                                                                Next
                                                            End If
                                                            mlDR.Close()
                                                        %>
                                                        <tr class="table-bordered">
                                                            <td colspan="6" style="text-align:center;" class="table-bordered"><strong>Grand Total</strong></td>
                                                            <td style="text-align:right;width:8%;" class="table-bordered"><%=FormatNumber(totnom, 0)%>&nbsp;&nbsp;</td>
                                                            <td style="text-align:right;width:8%;" class="table-bordered"><%=FormatNumber(tottunai, 0)%>&nbsp;&nbsp;</td>
                                                            <td style="text-align:right;width:8%;" class="table-bordered"><%=FormatNumber(totdebit, 0)%>&nbsp;&nbsp;</td>
                                                            <td style="text-align:right;width:8%;" class="table-bordered"><%=FormatNumber(totcc, 0)%>&nbsp;&nbsp;</td>
                                                            <td style="text-align:right;width:8%;" class="table-bordered"><%=FormatNumber(totbg, 0)%>&nbsp;&nbsp;</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="panel panel-default">
                    <div class="panel-body">
                       <div class="col-md-12">
                            <div>
                                <div class="col-md-4">
                                    <div>
                                        <div class="table-responsive">
							                <table border="0" class="table">
								                <thead>
									                <tr>
										                <th colspan="3"><span class="style3">RINGKASAN TANGGAL <span class="style1"><%=FormatDateTime(tg1, 1)%></span> s/d<span class="style1"><%=FormatDateTime(tg2, 1)%></span></span></th>
									                </tr>
								                </thead>
								                <tbody>
									                <tr>
										                <td colspan="3"><u><span class="style3">GRAND TOTAL GABUNGAN</span></u></td>
									                </tr>
									                <tr>
										                <td style="width:20%;"><span class="style3">Tunai</span></td>
										                <td style="width:8%;"><span class="style3">&nbsp;:&nbsp;</span></td>
										                <td style="width:72%;"><span class="style3">Rp <%=FormatNumber(gtottunai, 0)%>,-</span></td>
									                </tr>
									                <tr>
									                  <td><span class="style3">Debit Card</span></td>
									                  <td><span class="style3">&nbsp;:&nbsp;</span></td>
									                  <td><span class="style3">Rp <%=FormatNumber(gtotdebit, 0)%>,-</span></td>
									                </tr>
									                <tr>
									                  <td><span class="style3">Credi Card</span></td>
									                  <td><span class="style3">&nbsp;:&nbsp;</span></td>
									                  <td><span class="style3">Rp <%=FormatNumber(gtotkartu, 0)%>,-</span></td>
									                </tr>
									                <tr>
									                  <td><span class="style3">Transfer</span></td>
									                  <td><span class="style3">&nbsp;:&nbsp;</span></td>
									                  <td><span class="style3">Rp <%=FormatNumber(gtotbg, 0)%>,-</span></td>
									                </tr>
									                <tr>
									                  <td><span class="style3">TOTAL</span></td>
									                  <td><span class="style3">&nbsp;:&nbsp;</span></td>
									                  <td><span class="style3"><b>Rp <%=FormatNumber(gtottunai + gtotdebit + gtotkartu + gtotbg, 0)%>,-</b></span></td>
									                </tr>
								                </tbody>
							                </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div>
                                <div class="col-md-4">
                                    <div>
                                        <div class="table-responsive">
                                            <table border="0" class="table">
                                                <thead>
                                                    <tr>
                                                        <th colspan="3">&nbsp;</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3"><u><span class="style3">GRAND TOTAL PERDANA</span></u></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                        <td style="width:8%;"><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td style="width:72%;"><span class="style3">Rp <%=FormatNumber(gtottunai_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Debit Card</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotdebit_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Credi Card</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotkartu_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Transfer</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotbg_pdn, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">TOTAL</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3"><b>Rp <%=FormatNumber(gtottunai_pdn + gtotdebit_pdn + gtotkartu_pdn + gtotbg_pdn, 0)%>,-</b></span></td>
                                                    </tr>
                                            </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>	
                            </div>
                            <div>
                                <div class="col-md-4">
                                    <div>
                                        <div class="table-responsive">
                                            <table border="0" class="table">
                                                <thead>
                                                    <tr>
                                                        <th colspan="3">&nbsp;</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td colspan="3"><u><span class="style3">GRAND TOTAL PRODUK</span></u></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                        <td style="width:8%;"><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td style="width:72%;"><span class="style3">Rp <%=FormatNumber(gtottunai_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Debit Card</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotdebit_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Credi Card</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotkartu_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">Transfer</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3">Rp <%=FormatNumber(gtotbg_prd, 0)%>,-</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td><span class="style3">TOTAL</span></td>
                                                        <td><span class="style3">&nbsp;:&nbsp;</span></td>
                                                        <td><span class="style3"><b>Rp <%=FormatNumber(gtottunai_prd + gtotdebit_prd + gtotkartu_prd + gtotbg_prd, 0)%>,-</b></span></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="padding: 20px 20px 20px 20px">
            <div class="col-md-3">
                <label></label>
            </div>
        </div>  
    </section>
</asp:Content>


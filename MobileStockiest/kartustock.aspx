<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="kartustock.aspx.vb" Inherits="MobileStockiest_kartustock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default">
            <div class="panel-heading">
                <h3 class="panel-title text-center">KARTU STOCK</h3>
            </div>
            <div class="panel-body">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <form name="view" method="post" action="kartustock.aspx">
                                    <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
									<input type="hidden" name="sort" value="<%=sort%>">	
									<input type="hidden" name="pgview" value="<%=bg%>">
                                    <table>
		                                <tr>
			                                <td><label>Silahkan Pilih Produk</label></td>
			                                <td><label>&nbsp;:&nbsp;</label></td>
			                                <td>
				                                <select class="form-control" name="id" onChange="javascript:cari(this)" style="width:250px;" onKeyDown="if(event.keyCode==13) event.keyCode=9;">
											        <option value="--Silahkan Pilih--" selected>--Silahkan Pilih--</option>																																												
											        <%

                                                        minimal = 1
                                                        mlQuery = "SELECT * FROM " & namatabel2 & " WHERE nopos like '" & mypos & "' order by kode"
                                                        mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                                        If mlDR.HasRows Then
                                                            mlDT = New Data.DataTable
                                                            mlDT.Load(mlDR)
                                                            For aaaeqsK = 1 To mlDT.Rows.Count - 1
                                                    %>
                                                    <option value="<%=mlDT.Rows(aaaeqsK)("kode")%>"><%=mlDT.Rows(aaaeqsK)("nama")%></option>	  
                                                    <%
                                                            Next
                                                        End If
                                                    %>		
				                                </select>
			                                </td>
			                                <td>&nbsp;</td>
			                                <td><input type="submit" name="btsub" value="Tampilkan" class="btn"></td>
		                                </tr>	
	                                </table>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
                <%if lanjut = "T" then %>
                <div class="panel panel-default">
                    <div class="panel-body">
                        <p style="text-align:left;">
                            <b style="color:#FF0000">Ditemukan transaksi <%=FormatNumber(x, 0)%> pada kartu stock&nbsp;&nbsp;&nbsp;</b>
                        </p>
                        <form name="view0" method="post" action="kartustock.aspx">
                            <input type="hidden" name="menu_id" value="<%=session("menu_id")%>" style="font-weight: 700">
							<input type="hidden" name="sort" value="<%=sort%>" style="font-weight: 700">	
							<input type="hidden" name="pgview" value="<%=bg%>" style="font-weight: 700">	
							<input type="hidden" name="id" value="<%=paket%>" style="font-weight: 700">
                             <table>
		                        <tr>
			                        <td><label>Tampilkan Halaman</label></td>
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
                
                
                <div class="col-md-12">
                    <table style="width:100%;" border="0">
				        <tr>
					        <td><img src="../<%=foto%>" width="143" height="100" /></td>
					        <td style="width:90%;">
                                <b><%=nama%></b><br>
                                <label>
                                    <b>PV :&nbsp;<%=FormatNumber(pv, 2)%>&nbsp;&nbsp;- BV :&nbsp;<%=FormatNumber(bv, 2)%></b><br>
									<b><%=info%></b>
                                </label>
					        </td>
				        </tr>
			        </table>
		        </div>
		        <div class="col-md-6">
			        <label>Aksi :</label>
                    <label>
                        <a href="#">
                            <span onClick="javascript:window.open('kartustock_cetak.aspx?id=<%=paket%>&menu_id=<%=session("menu_id")%>&tgl1=<%=tgl1%>&tgl2=<%=tgl2%>&page=<%=pg+1%>&pgview=<%=bg%>'
                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=600, width=900')" style="text-decoration: none">Print Report</span>
                        </a>
                    </label>
		        </div>
		       
                <div style="padding-top: 20px" class="col-md-12">
                    <div class="table-responsive">
                        <table class="table table-bordered table-condensed" style="width:100%;" border="1">
					        <tr>
					            <td style="width:11%;" rowspan="2" class="text-center"><strong>Tanggal</strong></td>
					            <td colspan="4" class="text-center"><strong>Transaksi</strong></td>
					            <td style="width:25%;" rowspan="2" class="text-center"><strong>Referensi</strong></td>
					            <td style="width:34%;" rowspan="2" class="text-center"><strong>Keterangan</strong></td>
					        </tr>
					        <tr>
					            <td style="width:7%;" class="text-center"><strong>Awal</strong></td>
					            <td style="width:7%;" class="text-center"><strong>Masuk</strong></td>
					            <td style="width:8%;" class="text-center"><strong>Keluar</strong></td>
					            <td style="width:8%;" class="text-center"><strong>Akhir<</strong></td>
					        </tr>
                            <%
                                mlQuery = "SELECT * FROM " & namatabel & " where nopos like '" & mypos & "' and kode like '" & paket & "' order by tgl desc, id desc"
                                mlDR = mlOBJGS.DbRecordset(mlQuery, mpMODULEID, mlCOMPANYID)
                                If Not mlDR.HasRows Then
                            %>
                            <tr>
					            <td colspan="7" class="text-center">Belum Ada Transaksi</td>
					        </tr>
                            <%
                                End If

                                If mlDR.HasRows Then
                                    mlDT = New Data.DataTable
                                    mlDT.Load(mlDR)

                                    For aaaeqSSS = 1 To lumpat
                                        tgl = mlDT.Rows(aaaeqSSS)("tgl")
                                        masuk = mlDT.Rows(aaaeqSSS)("masuk")
                                        awal = mlDT.Rows(aaaeqSSS)("awal")
                                        keluar = mlDT.Rows(aaaeqSSS)("keluar")
                                        akhir = mlDT.Rows(aaaeqSSS)("akhir")
                                        ket = mlDT.Rows(aaaeqSSS)("keterangan")
                            %>
                            <tr>
					            <td>&nbsp;&nbsp;<%=tgl%></td>
					            <td class="text-right"><%=FormatNumber(awal, 0)%>&nbsp;&nbsp;</td>
					            <td class="text-right"><%=FormatNumber(masuk, 0)%>&nbsp;&nbsp;</td>
					            <td class="text-right"><%=FormatNumber(keluar, 0)%>&nbsp;&nbsp;</td>
					            <td class="text-right"><%=FormatNumber(akhir, 0)%>&nbsp;&nbsp;</td>
					            <td>
                                    <%if ket = "Order Produk" Then %>
									&nbsp;&nbsp;
                                    <a href="#">
                                        <span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=session("menu_id")%>&asal=normal'
                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                    </a>
									<%Else%>
									    <%If ket = "Order Perdana MC" Then %>
									        &nbsp;&nbsp;
                                            <a href="#">
                                                <span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>&asal=perdana'
                                                    , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                            </a>
									    <%Else%>
									        <%If Left(ket, 23) = "Order Paket Pendaftaran" Then %>
									            &nbsp;&nbsp;
                                                <a href="#">
                                                    <span onClick="javascript:window.open('mc_cetak_invoice_akt.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                </a>
									        <%Else%>
									            <%If ket = "Penjualan Produk" Then %>
									                &nbsp;&nbsp;
                                                    <a href="#">
                                                        <span onClick="javascript:window.open('sale_cetak_invoice_prd.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                    </a>
									            <%Else%>
									                <%If ket = "Penjualan Pendaftaran" Then %>
									                    &nbsp;&nbsp;
                                                        <a href="#">
                                                            <span onClick="javascript:window.open('sale_cetak_invoice_daftar.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                        </a>
									                <%Else%>
									                    <%If ket = "Penjualan Upgrade" Then %>
									                        &nbsp;&nbsp;
                                                            <a href="#">
                                                                <span onClick="javascript:window.open('sale_cetak_invoice_upgrade.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                                    , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                            </a>
									                    <%Else%>
									                        <%If ket = "Produk Penjualan Upgrade" Then %>
									                            &nbsp;&nbsp;
                                                                <a href="#">
                                                                    <span onClick="javascript:window.open('sale_cetak_invoice_upgrade.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                                        , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                                </a>
									                        <%Else%>
									                            <%If Left(ket, 28) = "Penjualan Produk Deposit PV" Then  %>
									                                &nbsp;&nbsp;
                                                                    <a href="#">
                                                                        <span onClick="javascript:window.open('sale_cetak_invoice_prd_autosave.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                                            , 'HelpWindow','scrollbars=yes, resizable=yes, height=550, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                                    </a>
									                            <%Else%>																	
									                                <%If ket = "Produk Penjualan Pendaftaran" Then %>
									                                    &nbsp;&nbsp;
                                                                        <a href="#">
                                                                            <span onClick="javascript:window.open('sale_cetak_invoice_daftar.aspx?noinvo=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=Session("menu_id")%>'
                                                                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                                        </a>
									                                <%Else%>																
									                                    &nbsp;&nbsp;
                                                                        <a href="#">
                                                                            <span onClick="javascript:window.open('mc_cetak_invoice_perdana.aspx?noinvoice=<%=mlDT.Rows(aaaeqSSS)("referensi")%>&menu_id=<%=session("menu_id")%>&asal=normal'
                                                                                , 'HelpWindow','scrollbars=yes, resizable=yes, height=480, width=900')" style="text-decoration: none"><%=mlDT.Rows(aaaeqSSS)("referensi")%></span>
                                                                        </a>
									                                <%End if%>
									                            <%end if%>	
									                        <%end if%>		
									                    <%end if%>													
									                <%end if%>															
									            <%end if%>
									        <%end if%>
									    <%end if%>
									<%end if%>
					            </td>
					            <td>&nbsp;&nbsp;<%=mlDT.Rows(aaaeqSSS)("keterangan")%></td>
					        </tr>
                            <%
                                    Next
                                End If
                            %>
				        </table>
                    </div>
                </div>
                <%end if%>	
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


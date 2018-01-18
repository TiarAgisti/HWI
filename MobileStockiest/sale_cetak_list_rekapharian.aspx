<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_cetak_list_rekapharian.aspx.vb" Inherits="MobileStockiest_sale_cetak_list_rekapharian" %>

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
                            <div class="panel-body">
                                <img src="../images/logohwi.png" width="143" height="100">
                            </div>
                        </div>
                        <div class="col-md-1">
                            <strong><%=perush_dc%></strong><br>
			                <%=nama_dc%> [<%=no_dc%>]<br>
			                <%=alamat_dc%><br>
			                <%=alamat_dc2%><br>
			                Telp. <%=telp_dc%><br>
			                Email: <%=emel_dc%><br>
			                <%=web_dc%><br>
                        </div>
                        <div class="col-md-12">
                            <div>
                                <h3 class="text-center"><strong>DAFTAR REKAP PENJUALAN HARIAN</strong></h3>
                            </div>
                            <div class="col-md-4">
                                <table style="width:auto" border="0">
                                    <tr>
                                        <td colspan="3"><strong>TOTAL PENJUALAN SELAMA INI</strong></td>
                                    </tr>
                                    <tr>
                                        <td>Pendaftaran</td>
                                        <td>:</td>
                                        <td>&nbsp;Rp <%=FormatNumber(totstart1, 0)%>,-</td>
                                    </tr>
                                    <tr>
                                        <td>Produk </td>
                                        <td>:</td>
                                        <td>&nbsp;Rp <%=FormatNumber(totprod1, 0)%>,-</td>
                                    </tr>
                                    <tr>
                                        <td>Total</td>
                                        <td>:</td>
                                        <td>&nbsp;Rp <%=FormatNumber(tottot1, 0)%>,-</td>
                                    </tr>
                                </table>
                            </div>

	                        <div class="row">
                                <div class="col-md-12">
			                        <div class="table-responsive">
				                        <table class="table table-condensed">
					                        <thead class="table table-bordered">
						                        <tr style="background-color:#CCC">
						                            <td style="width:5%;" rowspan="2" class="table-bordered text-center"><strong>TANGGAL</strong></td>
						                            <td colspan="2" class="table-bordered text-center" ><strong>PENJUALAN</strong></td>
						                            <td style="width:15%;" rowspan="2" class="table-bordered text-center"><strong>TOTAL</strong></td>
					                            </tr>
                                                <tr style="background-color:#CCC" >
                                                    <td style="width:24%;" class="table-bordered text-center"><strong>Pendaftaran</strong></td>
                                                    <td style="width:24%;" class="table-bordered text-center"><strong>Produk</strong></td>
                                                </tr>
				                            </thead>
					                        <tbody class="table table-bordered">
                                                <%
                                                    If sort = "tanggal" Then
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
                                                    <td colspan="4" class="table-bordered text-center">Tidak ada transaksi</td>
                                                </tr>
                                                <% End If %>
                                                <%
                    If mlDR.HasRows Then
                        mlDT = New Data.DataTable
                        mlDT.Load(mlDR)
                        For aaaeqSSS = 1 To mlDT.Rows.Count - 1
                            tgl = mlDT.Rows(aaaeqSSS)("tgl")
                            totjualakt = mlDT.Rows(aaaeqSSS)("starter")
                            totjualprd = mlDT.Rows(aaaeqSSS)("produk")
                                                %>
                                                <tr>
                                                    <td class="table-bordered text-right">
                                                        <a href="#">
                                                            <span onClick="javascript:window.open('sale_cetak_rekap.asp?sort=<%=sort%>&menu_id=<%=session("menu_id")%>&tgl1=<%=tgl%>', 'HelpWindow','scrollbars=yes, resizable=yes, height=800, width=500')" style="text-decoration: none">
                                                                <label style="color:#000000;"><%=tgl%></label>
                                                            </span>
                                                        </a>
                                                    </td>
                                                    <td class="table-bordered text-right">Rp <%=FormatNumber(totjualakt, 0)%>,-&nbsp;&nbsp;</td>
                                                    <td class="table-bordered text-right">Rp <%=FormatNumber(totjualprd, 0)%>,-&nbsp;&nbsp;</td>
                                                    <td class="table-bordered text-right">Rp <%=FormatNumber(totjualprd + totjualakt, 0)%>,-&nbsp;&nbsp;</td>
                                                </tr>
                                                <%
                        Next
                    End If
                    mlDR.Close()
                                                %>
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
        <div style="padding: 10px 20px 20px 10px">
            <div class="col-md-3">
                <label></label>
            </div>
        </div> 
    </section>
</asp:Content>


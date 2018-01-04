<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="saldo_feems.aspx.vb" Inherits="MobileStockiest_saldo_feems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables.css">
    <link rel="stylesheet" type="text/css" href="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/css/jquery.dataTables_themeroller.css">


    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" charset="utf8" src="http://ajax.aspnetcdn.com/ajax/jquery.dataTables/1.9.0/jquery.dataTables.min.js"></script>


    <script type="text/javascript">
        $(document).ready(function () {
            $('#detailTable').DataTable();
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">

    <section class="content-header">
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">BUKU SALDO FEE MOBILE STOCKIEST</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                <div class="row">
                    <div class="col-lg-12">
                        <input type="hidden" name="menu_id" value="<%=session("menu_id")%>">
                        <input type="hidden" name="pgview" value="<%=bg%>">
                        <input type="hidden" name="page" value="<%=pg + 1%>">
                        <div class="form-inline">
                            <div class="form-group">
                                <label>Tanggal</label>
                                <input type="date" class="form-control" name="tgl1">
                            </div>
                            <div class="form-group">
                                <label>s/d</label>
                                <input type="date" class="form-control" name="tgl2">
                            </div>
                            <%--onserverclick="Logout_Click"--%>
                            <button type="submit" name="btsb3" class="btn btn-primary" runat="server" onserverclick="SaldoFeems_Click">Tampilkan</button>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        Ditemukan
                        <label class="text-danger"><%=formatnumber(x, 0)%></label>
                        data transaksi 
                        <%if tgl1 <> "" And tgl2 <> "" Then %>
                        pada tanggal 
                        <label class="text-danger"><%=tgl1%></label>
                        s/d 
                        <label class="text-danger"><%=tgl2%></label>
                        <%end If%>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 form-horizontal">
                        <div class="form-group">
                            <label class="col-lg-4 col-form-label">Total Fee Penjualan Produk ke Distributor</label>
                            <div class="col-lg-8">
                                Rp <%=FormatNumber(totproduk, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-4 col-form-label">Total Fee Penjualan Pendaftaran Distributor Baru</label>
                            <div class="col-lg-8">
                                Rp <%=FormatNumber(totakt, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-4 col-form-label">Total Fee Pembelian Paket Pendaftaran ke DC</label>
                            <div class="col-lg-8">
                                Rp <%=FormatNumber(totaktms, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-4 col-form-label">Total Fee Pembelian Produk ke DC</label>
                            <div class="col-lg-8">
                                Rp <%=FormatNumber(totprodms, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-4 col-form-label">Total Pembelanjaan Produk ke DC</label>
                            <div class="col-lg-8">
                                Rp <%=FormatNumber(totbelanja, 0)%>,- (minmal akumulasi Rp 1.000.000 untuk mencairkan fee M.S)
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-4 col-form-label">Total Fee M.S</label>
                            <div class="col-lg-8">
                                Rp <%=FormatNumber(totfee, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-8">
                                [ <a target="_top" href="saldo_rekap_feems.aspx">Klik Disini Untuk Rekap Fee M.S</a> ]
                            </div>

                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 ">
                        <div class="table-responsive">
                            <input type="hidden" name="menu_id" value="<%=Session("menu_id")%>">
                            <input type="hidden" name="sort" value="<%=sort%>">
                            <input type="hidden" name="pgview" value="<%=bg%>">
                            <input type="hidden" name="tgl1" value="<%=tgl1%>">
                            <input type="hidden" name="tgl2" value="<%=tgl2%>">

                            <table class="table table-bordered" id="detailTable">
                                <thead>
                                    <tr class='info'>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Tanggal</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">No. Referensi</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">No. Pajak</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Tipe</th>
                                        <th colspan='2' style="text-align: center; vertical-align: middle">Total Amount</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Total PV</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Fee M.S</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Status</th>
                                    </tr>
                                    <tr>
                                        <th>Harga Distributor</th>
                                        <th>Harga M.S</th>
                                    </tr>
                                </thead>
                                <tbody id="dtSaldo" runat="server">

                                </tbody>
                                <%--<tbody>
                                    <tr>
                                        <td>16/09/2017 14:37:49</td>
                                        <td>B-001/0002/AMC-9/17</td>
                                        <td>00000004</td>
                                        <td>MS Order Paket Pendaftaran</td>
                                        <td>340.000</td>
                                        <td>335.000</td>
                                        <td>0.000</td>
                                        <td>5.000</td>
                                        <td>Aktif</td>
                                    </tr>
                                </tbody>--%>
                                <tfoot>
                                    <tr>
                                        <th colspan="7" class="text-right">Grand Total</th>
                                        <th colspan="2">0</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>

                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="alert alert-warning" style="color:black;">
                            <u><b style="color:black;">Catatan :</b></u>
                            <ol type="1" style="color:black;">
                                <li>Fee MS diperhitungan berdasarkan bulan kalender bukan bulan periode, dimulai dari tanggal 1 tiap bulan dan ditutup pada tanggal akhir bulan.
                                </li>
                                <li>Fee MS akan dibayarkan bersamaan dengan transfer bonus bulanan dengan pemotongan pajak PPH progressif.
                                </li>
                                <li>Fee MS yang diperoleh dari potongan pembelian ke D.C bersifat "gantung", dimana apabila pada saat closing bulanan Fee MS, anda sebagai MS tidak memiliki pembelanjaan ke DC minimal akumulasi Rp 1.000.000,- (boleh berasal dari beberapa DC/gabungan DC), maka fee yang menjadi hak MS sepenuhnya dialihkan menjadi hak masing-masing DC yang bersangkutan. Akumulasi Rp 1.000.000,- sebelum potongan (pembelanjaan produk dan paket registrasi).
                                </li>
                                <li>Fee MS tetap dibayarkan meskipun distributor yang menjadi MS tersebut tidak melakukan tutup point pada bulan periode.
                                </li>
                            </ol>
                        </div>

                    </div>
                </div>



            </div>
        </div>
    </section>

    <script>
        $(document).ready(function () {
            $('#example').DataTable();
        });

    </script>
</asp:Content>


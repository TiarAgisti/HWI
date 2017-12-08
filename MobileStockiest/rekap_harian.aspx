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
                <div class="col-md-1">
                    <label>Tanggal</label>
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text">
                </div>
                <div class="col-md-8">
                    <button class="btn btn-default" type="button">Tampilkan</button>
                </div>
                <div class="col-md-12" style="padding-top: 20px">
                    <label>Rekap Transaksi Harian pada Tanggal</label>
                    <div class="table-responsive">
                        <table class="table table-condensed table-bordered">
                            <tr>
                                <td bgcolor="grey" width="14%" rowspan="2" class="text-center"><strong>Kasir</strong></td>
                                <td colspan="3" class="text-center" bgcolor="orange"><strong>Penjualan</strong></td>
                                <td colspan="5" class="text-center" bgcolor="aqua"><strong>Pembayaran</strong></td>
                            </tr>
                            <tr>
                                <td width="9%" class="text-center" bgcolor="orange"><strong>Pendaftaran</strong></td>
                                <td width="8%" class="text-center" bgcolor="orange"><strong>Produk</strong></td>
                                <td width="10%" class="text-center" bgcolor="orange"><strong>Total</strong></td>
                                <td width="10%" class="text-center" bgcolor="aqua"><strong>Tunai</strong></td>
                                <td width="11%" class="text-center" bgcolor="aqua"><strong>Debit Card</strong></td>
                                <td width="11%" class="text-center" bgcolor="aqua"><strong>Credit Card</strong></td>
                                <td width="14%" class="text-center" bgcolor="aqua"><strong>Voucher</strong></td>
                                <td width="13%" class="text-center" bgcolor="aqua"><strong>Total</strong></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="text-right"><strong>GRAND TOTAL</strong></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                    <div class="col-md-5">
                        <label>Aksi: Simpan Ke Excel</label>
                    </div>
                    <div class="col-md-7">
                        <label>
                            Print Report<label>
                    </div>
                </div>
                <div class="col-md-12" style="padding-top: 20px">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">REKAP TOTAL PENJUALAN PAKET PENDAFTARAN</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-2">
                                <label>Tanggal</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>13 November 2017</label>
                            </div>
                            <div class="col-md-2">
                                <label>Total Penjualan</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
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
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-2">
                                <label>Debit Card</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-2">
                                <label>Credit Card</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-2">
                                <label>Voucher</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
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
                            <div class="col-md-2">
                                <label>Tanggal</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>13 November 2017</label>
                            </div>
                            <div class="col-md-2">
                                <label>Total Penjualan</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
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
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-2">
                                <label>Debit Card</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-2">
                                <label>Credit Card</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-2">
                                <label>Voucher</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-9">
                                <label>Rp,-</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">HISTORY REKAP PENJUALAN HARIAN</h3>
                        </div>
                        <div class="panel-body">
                            <div class="col-md-12" style="padding-bottom: 20px">
                                <label>Rekap Harian Ditemukan</label>
                            </div>
                            <div class="col-md-1">
                                <label>Urut</label>
                            </div>
                            <div class="col-md-2">
                                <select class="form-control">
                                    <optgroup label="This is a group">
                                        <option value="12" selected>This is item 1</option>
                                        <option value="13">This is item 2</option>
                                        <option value="14">This is item 3</option>
                                    </optgroup>
                                </select>
                            </div>
                            <div class="col-md-2">
                                <button class="btn btn-default" type="button">Ok</button>
                            </div>
                            <div class="col-md-1">
                                <label>Halaman</label>
                            </div>
                            <div class="col-md-2">
                                <select class="form-control">
                                    <optgroup label="This is a group">
                                        <option value="12" selected>This is item 1</option>
                                        <option value="13">This is item 2</option>
                                        <option value="14">This is item 3</option>
                                    </optgroup>
                                </select>
                            </div>
                            <div class="col-md-4">
                                <button class="btn btn-default" type="button">Tampilkan</button>
                            </div>
                            <div class="col-md-12" style="padding-top: 20px">
                                <div class="table-responsive">
                                    <table class="table table-condensed table-bordered">
                                        <tr>
                                            <td width="22%" rowspan="2" class="text-center" bgcolor="grey"><strong>Tanggal</strong></td>
                                            <td colspan="2" class="text-center" bgcolor="orange"><strong>Penjualan</strong></td>
                                            <td width="25%" rowspan="2" class="text-center" bgcolor="aqua"><strong>Total</strong></td>
                                        </tr>
                                        <tr>
                                            <td width="28%" class="text-center" bgcolor="orange"><strong>Pendaftaran</strong></td>
                                            <td width="25%" class="text-center" bgcolor="orange"><strong>Produk</strong></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" class="text-center"><u>Tidak Ada Transaksi</u></td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="col-md-5">
                                <label>Aksi: Simpan Ke Excel</label>
                            </div>
                            <div class="col-md-7">
                                <label>
                                    Print Report<label>
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
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-1">
                                <label>Prduk</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-10">
                                <label>Rp,-</label>
                            </div>
                            <div class="col-md-1">
                                <label>Total</label>
                            </div>
                            <div class="col-md-1">
                                <label>:</label>
                            </div>
                            <div class="col-md-10">
                                <label>Rp,-</label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title text-center">GRAFIK REKAP PENJUALAN</h3>
                        </div>
                        <div class="panel-body text-center"><u>Tidak Ada Transaksi</u></div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


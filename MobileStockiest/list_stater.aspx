<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="list_stater.aspx.vb" Inherits="MobileStockiest_list_stater" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">

    <section class="content-header">
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">DAFTAR INVOICE PENJUALAN PAKET PENDAFTARAN</h3>
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
                        <div class="form-inline">
                            <div class="form-group">
                                <label>Tanggal</label>
                                <input type="date" class="form-control" name="tgl1">
                            </div>
                            <div class="form-group">
                                <label>s/d</label>
                                <input type="date" class="form-control" name="tgl2">
                            </div>
                            <div class="form-group">
                                <label>Kasir</label>
                                <select class="form-control" name="kasir" id="kasirDropdownList" runat="server">
                                    <option value="semua">--ALL--</option>
                                </select>
                                <%--onserverclick="Logout_Click"--%>
                                <button type="submit" name="btsb3" class="btn btn-primary" runat="server">Tampilkan</button>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="table-responsive">
                            <table class="table table-bordered">
                                <thead>
                                    <tr>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Tanggal</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Nomor Referensi</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Nomor Invoice</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">No. Seri</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Nama Konsumen</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Paket</th>
                                        <th rowspan='2' style="text-align: center; vertical-align: middle">Nominal</th>
                                        <th colspan='4' style="text-align: center; vertical-align: middle">Pembayaran</th>

                                    </tr>
                                    <tr>
                                        <th>Tunai</th>
                                        <th>Debit Card </th>
                                        <th>Credit Card</th>
                                        <th>Voucher </th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                        <td>1</td>
                                    </tr>
                                </tbody>
                                <tfoot>
                                    <tr>
                                        <th colspan="7" class="text-right">Grand Total</th>
                                        <th>0</th>
                                        <th>0</th>
                                        <th>0</th>
                                        <th>0</th>
                                    </tr>
                                </tfoot>
                            </table>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12  form-horizontal">
                        GRAND TOTAL DARI TANGGAL 22 Agustus 2017 s/d 21 September 2017
                        <br />
                        <div class="form-group">
                            <label class="col-lg-2 col-form-label">Tunai</label>
                            <div class="col-lg-10">
                                Rp <%=FormatNumber(gtottunai, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 col-form-label">Debit Card</label>
                            <div class="col-lg-10">
                                Rp <%=FormatNumber(gtotdebit, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 col-form-label">Credit Card</label>
                            <div class="col-lg-10">
                                Rp <%=FormatNumber(gtotkartu, 0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 col-form-label">Voucher</label>
                            <div class="col-lg-10">
                                Rp <%=formatnumber(gtotbg,0)%>,-
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 col-form-label">TOTAL</label>
                            <div class="col-lg-10">
                                Rp <%=formatnumber(gtottunai+gtotdebit+gtotkartu+gtotbg,0)%>,-
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>


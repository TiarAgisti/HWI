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
        <div class="text-right">
            <label class="text-right">
                Kamis,02 November 2017 10:17:03
            </label>
        </div>
        <div style="background-color:gray">
            <h3 style="text-align:center;color:white;font-family:Arial;">DAFTAR INVOICE PENJUALAN PRODUK KE MOBILE CENTER</h3>
        </div>

        <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <div style="text-align:center;">
                        <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:98%">
                            <tr>
                                <td style="vertical-align:top;"></td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <div style="text-align:center;">
                        <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:99%">
                            <tr>
                                <td>
                                    <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
                                        <tr>
                                            <td>
                                                <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
                                                    <tr>
                                                        <td style="width:75px;text-align:left;">Tanggal</td>
                                                        <td style="width:170px;">
                                                            <input class="form-control" type="text">
                                                        <td style="width:25px;">
                                                            <div style="text-align:center;">s/d</div>
                                                        </td>
                                                        <td style="width:170px;">
                                                            <input class="form-control" type="text"></td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
                                                    <tr>
                                                        <td style="width:75px;text-align:left;">Kasir</td>
                                                        <td style="width:170px;">
                                                            <select class="form-control">
                                                                <optgroup label="This is a group">
                                                                    <option value="12" selected="">This is item 1</option>
                                                                    <option value="13">This is item 2</option>
                                                                    <option value="14">This is item 3</option>
                                                                </optgroup>
                                                            </select>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:75px;text-align:left;">No. Id. MC.</td>
                                                        <td style="width:170px;">
                                                            <select class="form-control">
                                                                <optgroup label="This is a group">
                                                                    <option value="12" selected="">This is item 1</option>
                                                                    <option value="13">This is item 2</option>
                                                                    <option value="14">This is item 3</option>
                                                                </optgroup>
                                                            </select>
                                                        </td>
                                                        <td style="width:25px;">
                                                             <button class="btn btn-default" type="button">Tampilkan</button>
                                                        </td>
                                                        <td style="width:170px;"></td>
                                                        <td>&nbsp;</td>												
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" style="border-spacing:0;border-collapse:collapse;padding:0;width:100%">
                                        <tr>
                                            <td>
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
                                                                                    <tr>
                                                                                        <td colspan="11" class="table-bordered">&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr class="table-bordered">
                                                                                        <td colspan="6" style="text-align:center;" class="table-bordered"><strong>Grand Total</strong></td>
                                                                                        <td style="text-align:right;" class="table-bordered">0</td>
                                                                                        <td style="text-align:right;" class="table-bordered">0</td>
                                                                                        <td style="text-align:right;" class="table-bordered">0</td>
                                                                                        <td style="text-align:right;" class="table-bordered">0</td>
                                                                                        <td style="text-align:right;" class="table-bordered">0</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                         </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
    </section>
</asp:Content>


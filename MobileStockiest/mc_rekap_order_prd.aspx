﻿<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="mc_rekap_order_prd.aspx.vb" Inherits="MobileStockiest_mc_rekap_order_prd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color: white;">
        <div style="background-color: grey">
            <h3 style="text-align:center;color:white;font-family:Arial;">DAFTAR INVOICE PENJUALAN PRODUK KE MOBILE CENTER</h3>
        </div>
        <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <div style="text-align:center;">
                        <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 98%;">
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
                        <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 99%;">
                            <tr>
                                <td>
                                    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
                                        <tr>
                                            <td>
                                                <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
                                                    <tr>
                                                        <td style="width:75px;">Tanggal</td>
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
                                                <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
                                                    <tr>
                                                        <td style="width:75px;">Kasir</td>
                                                        <td style="width:170px;">
                                                            <select class="form-control">
                                                                <optgroup label="This is a group">
                                                                    <option value="12" selected="">This is item 1</option>
                                                                    <option value="13">This is item 2</option>
                                                                    <option value="14">This is item 3</option>
                                                                </optgroup>
                                                            </select>
                                                        </td>
                                                        <td>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:64px;">No. Id. MC.&nbsp;</td>
                                                        <td style="width:122px;">
                                                            <select class="form-control">
                                                                <optgroup label="This is a group">
                                                                    <option value="12" selected="">This is item 1</option>
                                                                    <option value="13">This is item 2</option>
                                                                    <option value="14">This is item 3</option>
                                                                </optgroup>
                                                            </select></td>
                                                        <td>
                                                            <button class="btn btn-default" type="button">Tampilkan</button>
                                                        </td>														
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
                                        <tr>
                                            <td>
                                                <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
                                                    <tr>
                                                        <td style="width:245px;">
                                                            <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
                                                                <tr>
                                                                    <td>
                                                                        <div></div>
                                                                        <div></div>
                                                                        <div class="col-md-12 col-md-offset-0"><p></p></div>
                                                                        <div class="col-lg-offset-8 col-md-2">
                                                                            <label>Aksi : </label><%--<img>--%>
                                                                            <label>Simpan Ke Excel</label>
                                                                        </div>
                                                                        <div class="col-lg-offset-0 col-md-2">
                                                                            <%--<img>--%>
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
                                                                                                <td style="text-align:right;" class="table-bordered">A</td>
                                                                                                <td style="text-align:right;" class="table-bordered">B</td>
                                                                                                <td style="text-align:right;" class="table-bordered">C</td>
                                                                                                <td style="text-align:right;" class="table-bordered">D</td>
                                                                                                <td style="text-align:right;" class="table-bordered">E</td>
                                                                                                <td style="text-align:center;" class="table-bordered">Produk Perdana</br>UNKNOWN</td>
                                                                                                <td style="text-align:right;" class="table-bordered">G</td>
                                                                                                <td style="text-align:right;" class="table-bordered">H</td>
                                                                                                <td style="text-align:right;" class="table-bordered">I</td>
                                                                                                <td style="text-align:right;" class="table-bordered">J</td>
                                                                                                <td style="text-align:right;" class="table-bordered">K</td>
                                                                                            </tr>

                                                                                            <tr class="table-bordered">
                                                                                                <td colspan="6" style="text-align:right;" class="table-bordered"><strong>Grand Total</strong></td>
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
                                                                                                                    <th colspan="3"><span class="style3">RINGKASAN TANGGAL s/d</span></th>
                                                                                                                </tr>
                                                                                                            </thead>
                                                                                                            <tbody>
                                                                                                                <tr>
                                                                                                                    <td colspan="3"><u><span class="style3"><strong>GRAND TOTAL TABUNGAN</strong></span></u></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td style="width:20%;"><span class="style3">Tunai</span></td>
                                                                                                                    <td style="width:8%;"><span class="style3">:</span></td>
                                                                                                                    <td style="width:72%;"><span class="style3">Rp,-</span></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td><span class="style3">Debit Card</span></td>
                                                                                                                    <td><span class="style3">:</span></td>
                                                                                                                    <td><span class="style3">Rp,-</span></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td><span class="style3">Kredi Card</span></td>
                                                                                                                    <td><span class="style3">:</span></td>
                                                                                                                    <td><span class="style3">Rp,-</span></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td><span class="style3">Transfer</span></td>
                                                                                                                    <td><span class="style3">:</span></td>
                                                                                                                    <td><span class="style3">Rp,-</span></td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                                                                                    <td><span class="style3"><strong>:</strong></span></td>
                                                                                                                    <td><span class="style3"><strong>Rp,-</strong></span></td>
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
                                                                                                                <td style="width:72%;"><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3">Debit Card</span></td>
                                                                                                                <td><span class="style3">:</span></td>
                                                                                                                <td><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3">Kredi Card</span></td>
                                                                                                                <td><span class="style3">:</span></td>
                                                                                                                <td><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3">Transfer</span></td>
                                                                                                                <td><span class="style3">:</span></td>
                                                                                                                <td><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                                                                                <td><span class="style3"><strong>:</strong></span></td>
                                                                                                                <td><span class="style3"><strong>Rp,-</strong></span></td>
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
                                                                                                                <td style="width:72%;"><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3">Debit Card</span></td>
                                                                                                                <td><span class="style3">:</span></td>
                                                                                                                <td><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3">Kredi Card</span></td>
                                                                                                                <td><span class="style3">:</span></td>
                                                                                                                <td><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3">Transfer</span></td>
                                                                                                                <td><span class="style3">:</span></td>
                                                                                                                <td><span class="style3">Rp,-</span></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td><span class="style3"><strong>TOTAL</strong></span></td>
                                                                                                                <td><span class="style3"><strong>:</strong></span></td>
                                                                                                                <td><span class="style3"><strong>Rp,-</strong></span></td>
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
                                                                    </td>
                                                                </tr>
                                                            </table>
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


<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="saldo_rekap_feems.aspx.vb" Inherits="MobileStockiest_saldo_rekap_feems" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <body topmargin="0" leftmargin="0" background="../pos/images/bg.gif" onload="goforit()" oncontextmenu="return false" ondragstart="return false">
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top" width="82%">
                    <div align="center">
                        <div align="center">
                            <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td valign="top">
                                        <table border="1" cellspacing="1" width="100%" style="border-collapse: collapse" bordercolor="#DBDBDB">
                                            <tr>
                                                <td valign="top">
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td bgcolor="#808080" height="20">
                                                                <p align="center">
                                                                    <font size="3" color="#FFFFFF">
                                                                        <b>REKAP SALDO FEE MOBILE STOCKIEST</b>
                                                                    </font>
                                                                </p>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td valign="top">
                                                                <div align="center">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="99%">
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <table border="0" cellpadding="4" style="border-collapse: collapse" width="100%" bgcolor="#FEF4DA">
                                                                                                <tr>
                                                                                                    <td valign="top">
                                                                                                        <u><b>
                                                                                                            <font color="#000000">Catatan :</font>
                                                                                                        </b></u>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td valign="top">
                                                                                                        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
                                                                                                            <tr>
                                                                                                                <td width="23" align="center" valign="top">
                                                                                                                    <font color="#000000">
																1.</font></td>
                                                                                                                <td valign="top">
                                                                                                                    <font color="#000000">
																Fee MS 
																diperhitungan 
																berdasarkan 
																bulan kalender 
																bukan bulan 
																periode, dimulai 
																dari tanggal 1 
																tiap bulan dan 
																ditutup pada 
																tanggal akhir 
																bulan.</font></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="23" align="center" valign="top">
                                                                                                                    <font color="#000000">
																2.</font></td>
                                                                                                                <td valign="top">
                                                                                                                    <font color="#000000">
																Fee MS akan 
																dibayarkan 
																bersamaan dengan 
																transfer bonus 
																bulanan dengan 
																pemotongan pajak 
																PPH progressif.</font></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="23" align="center" valign="top">
                                                                                                                    <font color="#000000">
																3.</font></td>
                                                                                                                <td valign="top">
                                                                                                                    <font color="#000000">
																Fee MS yang 
																diperoleh dari 
																potongan 
																pembelian ke D.C 
																bersifat 
																&quot;gantung&quot;, 
																dimana apabila 
																pada saat 
																closing bulanan 
																Fee MS, anda 
																sebagai MS tidak 
																memiliki 
																pembelanjaan ke 
																DC minimal 
																akumulasi Rp 
																1.000.000,- 
																(boleh berasal 
																dari beberapa 
																DC/gabungan DC), 
																maka fee yang 
																menjadi hak MS 
																sepenuhnya 
																dialihkan 
																menjadi hak 
																masing-masing DC 
																yang 
																bersangkutan. 
																Akumulasi Rp 
																1.000.000,- 
																sebelum potongan 
																(pembelanjaan 
																produk dan paket 
																registrasi).</font></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="23" align="center" valign="top">
                                                                                                                    <font color="#000000">
																4.</font></td>
                                                                                                                <td valign="top">
                                                                                                                    <font color="#000000">
																Fee MS tetap 
																dibayarkan 
																meskipun 
																distributor yang 
																menjadi MS 
																tersebut tidak 
																melakukan tutup 
																point pada bulan 
																periode.</font></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top">&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <table border="1" cellspacing="1" width="60%" bordercolor="#808080" style="border-collapse: collapse">
                                                                                                <tr>
                                                                                                    <td width="20%" align="center" rowspan="2" bgcolor="#DBDBDB">
                                                                                                        <font color="#000000">
																<b>PERIODE 
																TRANSAKSI</b></font></td>
                                                                                                    <td width="35%" align="center" colspan="3" bgcolor="#DBDBDB">
                                                                                                        <font color="#000000">
																<b>PEMBELANJAAN 
																KE D.C</b></font></td>
                                                                                                    <td width="15%" align="center" rowspan="2" bgcolor="#DBDBDB">
                                                                                                        <font color="#000000">
																<b>FEE M.S</b></font></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td width="20%" align="center" bgcolor="#DBDBDB">
                                                                                                        <font color="#000000">
																<b>PRODUK</b></font></td>
                                                                                                    <td width="20%" align="center" bgcolor="#DBDBDB">
                                                                                                        <font color="#000000">
																<b>PAKET 
																REGISTRASI</b></font></td>
                                                                                                    <td width="20%" align="center" bgcolor="#DBDBDB">
                                                                                                        <b>
                                                                                                            <font color="#000000">
																TOTAL 
																PEMBELANJAAN</font></b></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table border="0" style="border-collapse: collapse" width="60%" bordercolor="#808080" cellpadding="0">
                                                                                                <tr>
                                                                                                   <%-- <td valign="top">
                                                                                                        <%
                                                                                                            rs.Open "SELECT * FROM bns_feems_rekap where nopos like '" & mypos&"' order by tahun DESC, bulan desc", conn
If rs.bof Then %>

                                                                                                        <table border="1" cellspacing="1" width="100%" id="table14" style="border-collapse: collapse" bordercolor="#808080">
                                                                                                            <tr>
                                                                                                                <td width="100%" align="center" height="60">
                                                                                                                    <u><font color="#000000">
													Anda belum memperoleh fee 
													M.S</font></td>
                                                                                                            </tr>

                                                                                                            <%
                                                                                                                else
                                                                                                                end if

                                                                                                                if rs.eof <> True then

                                                                                                                    if goneqSS <> 0 then
                                                                                                                        for aaeeqSS = 1 to goneqSS
                                                                                                                            if rs.eof = True then exit for
                                                                                                                            rs.movenext
                                                                                                                        next
                                                                                                                    else
                                                                                                                    end if
                                                                                                            %>
                                                                                                            <table border="1" style="border-collapse: collapse" width="100%" bordercolor="#808080" cellspacing="1">
                                                                                                                <%
                                                                                                                    for aaaeqSSS = 1 to 90
                                                                                                                        if rs.eof = True then exit for

                                                                                                                        if clng((rs("totbelanja_produk") + rs("totbelanja_aktivasi")) >= 1000000 then
                                                                                                                            feems = rs("fee_amt")
                                                                                                                        else
                                                                                                                            feems = 0
                                                                                                                        end if
                                                                                                                %>
                                                                                                                <tr>
                                                                                                                    <td width="20%">
                                                                                                                        <font color="#000000">
																		&nbsp;<%=monthname(rs("bulan"))%>&nbsp;<%=rs("tahun")%></font></td>
                                                                                                                    <td width="20%" align="right">
                                                                                                                        <font color="#000000">
																		Rp&nbsp;<%=formatnumber(rs("totbelanja_produk"),0)%>,-&nbsp;&nbsp;
																		</font>
                                                                                                                    </td>
                                                                                                                    <td width="20%" align="right">
                                                                                                                        <font color="#000000">
																		Rp&nbsp;<%=formatnumber(rs("totbelanja_aktivasi"),0)%>,-&nbsp;&nbsp;
																		</font>
                                                                                                                    </td>
                                                                                                                    <td width="20%" align="right">
                                                                                                                        <font color="#000000">
																		Rp&nbsp;<%=formatnumber((rs("totbelanja_produk")+rs("totbelanja_aktivasi")),0)%>,-&nbsp;&nbsp;&nbsp;
																		</font>
                                                                                                                    </td>
                                                                                                                    <td width="15%" align="right">
                                                                                                                        <font color="#000000">
																		Rp&nbsp;<%=formatnumber(feems,0)%>,-&nbsp;&nbsp;
																		</font>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <%  
                                                                                                                            rs.movenext
                                                                                                                        next
                                                                                                                    end if
                                                                                                                    if rs.eof = True then
                                                                                                                    end if
                                                                                                                    rs.Close
                                                                                                                %>
                                                                                                            </table>
                                                                                                    </td>--%>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top">&nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">&nbsp;</td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </body>
</asp:Content>


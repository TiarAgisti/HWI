<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="akt_ready.aspx.vb" Inherits="MobileStockiest_akt_ready" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default" style="margin: 10px 10px 10px 10px">
            <div class="panel-body">
                <table border="0" style="width:100%;">
						<tr>
							<td>
							    <p style="text-align:center;">
							        <img border="0" src="../images/logohwi.png" width="186" height="125">
                                </p>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td>
							    <div style="text-align:center;">
								    <table border="0" style="width:90%;">
									    <tr>
                                            <td style="width:100%;">
                                                <p style="text-align:center;">
                                                    <label>
                                                        <b>Nomor Seri Pendaftaran atau nomor distributor yang anda isikan sudah digunakan oleh distributor lain sebagaimana dibawah ini.</b><br>
                                                    </label>
                                                    <label>
                                                        <b>
                                                            Apabila dibawah ini benar merupakan detail keanggotaan anda, <br>
		                                                    maka hal ini berarti keanggotaan anda sudah aktif, <br>
		                                                    namun apabila bukan merupakan keanggotaan anda, <br>
		                                                    silahkan menghubungi DC/Stockist dimana anda mendaftar atau kantor pusat.
                                                        </b>
                                                    </label>
                                                </p>
                                            </td>
  									    </tr>
									<tr>
                                        <td style="width:100%;">
                                          <hr style="color:#808080;">
                                        </td>
  									</tr>
									<tr>
                                        <td style="width:100%;">
                                            <p style="text-align:center;">
                                                <label>Berikut ini adalah informasi singkat mengenai akun anda :</label>
                                            </p>
                                        </td>
  									</tr>
									<tr>
                                        <td style="width:100%;">
                                            <div style="text-align:center;">
                                                <table border="0" style="width:75%;">
                                                    <tr>
                                                        <td style="width:100%;vertical-align:top;">
                                                            <table border="0" style="width:100%;">
                                                                <tr>
                                                                    <td style="width:26%;height:14px;"></td>
                                                                    <td style="width:4%;height:14px;text-align:center;"></td>
                                                                    <td style="width:70%;height:14px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:26%;"><b><label>Distributor ID.</label></b></td>
                                                                    <td style="width:4%;text-align:center;"><b><label>:</label></b></td>
                                                                    <td style="width:70%;"><label><%=manuk%></label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:26%;"><b><label>Nama Anda</label></b></td>
                                                                    <td style="width:4%;text-align:center;"><b><label>:</label></b></td>
                                                                    <td style="width:70%;"><label><%=nma%></label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:26%;"><b><label>Nomor Telepon</label></b></td>
                                                                    <td style="width:4%;text-align:center;"><b><label>:</label></b></td>
                                                                    <td style="width:70%;"><label><%=telp%></label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:26%;"><b><label>Nomor KTP</label></b></td>
                                                                    <td style="width:4%;text-align:center;"><b><label>:</label></b></td>
                                                                    <td style="width:70%;"><label><%=noktp%></label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:26%;">&nbsp;</td>
                                                                    <td style="width:4%;text-align:center;">&nbsp;</td>
                                                                    <td style="width:70%;">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:26%;">&nbsp;</td>
                                                                    <td style="width:4%;text-align:center;">&nbsp;</td>
                                                                    <td style="width:70%;">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width:26%;">&nbsp;</td>
                                                                    <td style="width:4%;text-align:center;">&nbsp;</td>
                                                                    <td style="width:70%;">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
  									</tr>
									<tr>
                                        <td style="width:100%;"></td>
  									</tr>
								</table>
							</div>
						</td>
					</tr>
					<tr>
					    <td>&nbsp;</td>
					</tr>
				</table>
            </div>
        </div>
    </section>
</asp:Content>


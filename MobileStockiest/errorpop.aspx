<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="errorpop.aspx.vb" Inherits="MobileStockiest_errorpop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
	    <tr>
		    <td>
		        <p style="text-align:center;">
		        <img border="0" src="../images/health-wealthlogo.jpg" width="186" height="125">
            </td>
	    </tr>
    </table>
    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
	    <tr>
		    <td>&nbsp;</td>
	    </tr>
    </table>
    <table border="0" style="border-spacing: 0; border-collapse: collapse; padding: 0; width: 100%;">
	    <tr>
		    <td>
		        <p style="text-align:center;font-family:Verdana;font-size:2px;">
                    Maaf sistem kami mendeteksi terjadinya kesalahan seperti yang tertera dibawah ini.<br>
		            <b style="color:#FF0000"><%=mesej%></b><br>
		            Silahkan perbaiki kesalahan tersebut dan ulang lagi.<br>Terima kasih
                </p>
            </td>
	    </tr>
    </table>
</asp:Content>


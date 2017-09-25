<head>
<meta http-equiv="Content-Language" content="id">
</head>

<SCRIPT LANGUAGE=JAVASCRIPT>
<!-- Start of scroller script
var scrollCounter = 0;
var scrollText= "PT. Health Wealth International :: Not just a business - Together we grow - ONE VISION ONE SPIRIT";
var scrollDelay= 70;
var i = 0;
while (i ++ < 140)
scrollText = " " + scrollText;
function Scroller()


{
window.status = scrollText.substring(scrollCounter++,
scrollText.length);
if (scrollCounter == scrollText.length)
scrollCounter = 0;
setTimeout("Scroller()", scrollDelay);
}
Scroller();
// End of scroller script -->
</SCRIPT>
<%
rs.Open "SELECT * FROM totdata",conn	
	if rs.bof then
		kunjungan = 0
		mulainya = now()
	else
		kunjungan = rs("hits")
		mulainya = rs("mulai")
	end if
rs.Close
set rs=nothing
Conn.Close
set conn=nothing
%>

<div style="
	padding: 10px;
	background:#191919;
	">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td><table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td width="20%" valign="top">
								<font color="#CCCCCC"><b>Health Wealth</b> <br>
								<font color="#FFFFFF">- </font>
								<a target="_top" href="default.asp"><font color="#FFFFFF">Home</font></a><font color="#FFFFFF"> <br>
								- <a target="_top" href="cpanel/default.asp"><font color="#FFFFFF">Distributor Control Panel</font></a><font color="#FFFFFF"> <br>
								-
								<a target="_top" href="pos/default.asp">
								<font color="#FFFFFF">Distributor Center Control Panel</font></a><font color="#FFFFFF"> <br>
								-
								<a target="_top" href="mobile/default.asp">
								<font color="#FFFFFF">Mobile Center Control Panel</font></a><font color="#FFFFFF"><br></td>
								<td width="20%" valign="top">
								<font color="#CCCCCC"><b>Company</b> <br>
								<font color="#FFFFFF">- </font> 
								<a target="_top" href="profile.asp">
								<font color="#FFFFFF">Profile Perusahaan</font></a> <br> 
								<font color="#FFFFFF">- </font> 
								<a target="_top" href="quadroplan.asp">
							<font color="#FFFFFF">Quadro 
								Plan</font></a> <br> <font color="#333333">
								<font color="#FFFFFF">- </font>
								<a target="_top" href="produk.asp">
								<font color="#FFFFFF">Daftar Produk dan 
								Testimonial</font></a></font> <br> 
								</td>
								<td width="20%" valign="top">
								<font color="#CCCCCC"><b>Hot News !</b> <br>
								<font color="#FFFFFF">- </font>
								<a target="_top" href="contact.asp">
								<font color="#FFFFFF">Kontak Kami</font></a><br>
								<font color="#FFFFFF">- </font>
								<a target="_top" href="kesandanpesan.asp">
								<font color="#FFFFFF">Kesan dan Harapan</font></a> <br> 
								<font color="#FFFFFF">- </font> 
								<a target="_top" href="baca_liputan.asp">
								<font color="#FFFFFF">Liputan Kegiatan</font></a> 
								<br> <font color="#FFFFFF">- </font> <a target="_top" href="promo_events.asp">
								<font color="#FFFFFF">Promo dan Campaign</font></a> </td>
								<td width="20%" valign="top">
								<font color="#CCCCCC"><b>Distributor</b> <br>
								<font color="#FFFFFF">- </font> <a target="_top" href="hall_of_fame.asp">
								<font color="#FFFFFF">Hall of Fame</font></a></font><br>
</td>
								<td width="20%" valign="top">
								<font color="#CCCCCC"><b>Coming Soon</b> <br>

								
								-

								
								Komunitas 
								Online <br> - HWI Leader Clubs <br> - Streaming Index <br> 
								- Marketing Tool's</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>
													
								</td>
							</tr>
						</table>
						<hr>
<table width="522"><tr><td><font size="1" color="#808080">Situs ini telah 
						dikunjungi sebanyak </font>								
						<font size="1" color="#FFFFFF"> <%=formatnumber(kunjungan,0)%></font><font size="1" color="#808080"> kunjungan sejak <%=formatdatetime(mulainya,1)%></i><br>
						Site Design copyright @2013 - <b>I.T Department</b> PT. Health Wealth International	
	<br>
	Kuasa hukum HWI, <a target="_blank" href="http://www.joanandpartners.com">
	<font color="#FFFFFF">Joan and partner</font></a></font><br>
	<br>
	</td></tr></table>						
 </td>
	</tr>
	<tr>
		<td><% ' HAPUS DULU %>
		 <a href="https://www.hwiverified.com/showme.asp?idtype=B-000&ccid=23456878768773&secid=0172809XXIE902KK0D2112&lcid=PSTHO03992JKT03901" target="_blank"><img border="0" src="https://www.hwiverified.com/verified/hwiseal.jpg" width="150" height="87"></a>
<% %>
</td>
	</tr>
</table>
</div>
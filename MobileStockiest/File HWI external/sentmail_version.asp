<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******
' Application: HEALTH WEALTH INTERNATIONAL WEBSITE
' Author: Peter Sindoro
' Coding : Septmber 2009
' Revised : -
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******     

mesej = session("kirimngawur")
session("kirimngawur") = ""
manuk = Session.Contents("manuk")
sss = "T"
aman = "F"
rs.Open "SELECT uid,kta,hp,emel FROM member WHERE kta like '"&manuk&"' and sta like '"&sss&"'",conn
	if rs.bof then
		aman = "F"
		Session.Contents("manuk") = ""
		nama_anggota = ""
		emel_anggota = ""
		hape_anggota = ""
	else
		aman = "T"
		Session.Contents("manuk") = rs("kta")
		nama_anggota = rs("uid")
		emel_anggota = rs("emel")
		hape_anggota = rs("hp")	
	end if
rs.Close

idprod = request("prod_id")
rs.Open "SELECT kode,nama,keterangan,foto_besar,pv,hd1,hd2,hd3,hk1,hk2,hk3 FROM st_barang WHERE sta like '"&sss&"' and kode like '"&idprod&"'",conn
	if rs.bof then
		ada = "F"
	else
		ada = "T"
		prd_desk = rs("keterangan")
		namaprd = rs("nama")
		fotoprd = rs("foto_besar")
		pv = rs("pv")
		hd1 = rs("hd1")
		hd2 = rs("hd2")
		hd3 = rs("hd3")
		hk1 = rs("hk1")
		hk2 = rs("hk2")
		hk3 = rs("hk3")
		kode = rs("kode")
	end if	
rs.close 
prddesk = prd_desk

rs.Open "SELECT count(id) FROM testi_prod WHERE prod_id like '"&idprod&"' and sta like '"&sss&"' group by sta",conn,1,3
	if rs.bof then
		voteman = 0
	else		
		voteman = cint(rs("count(id)"))
	end if						
rs.close

if isnull(voteman) = true then
	voteman = 0
else
	voteman = voteman
end if
		
rs.Open "SELECT sum(nilai) FROM testi_prod WHERE prod_id = '"&idprod&"' and sta like '"&sss&"' group by sta",conn,1,3
	if rs.bof then
		nilai = 0
	else		
		nilai = cint(rs("sum(nilai)"))
	end if						
rs.close

ggg = "zno"
ke = 1
rs.Open "SELECT deskripsi FROM tabdesc WHERE grp like '"&ggg&"' and ket like '"&ke&"'",conn
	if rs.bof then
		area1 = ""
	else		
		area1 = rs("deskripsi")
	end if						
rs.close

ke = 2
rs.Open "SELECT deskripsi FROM tabdesc WHERE grp like '"&ggg&"' and ket like '"&ke&"'",conn
	if rs.bof then
		area2 = ""
	else		
		area2 = rs("deskripsi")
	end if						
rs.close

ke = 3
rs.Open "SELECT deskripsi FROM tabdesc WHERE grp like '"&ggg&"' and ket like '"&ke&"'",conn
	if rs.bof then
		area3 = ""
	else		
		area3 = rs("deskripsi")
	end if						
rs.close
set rs=nothing
Conn.Close
set conn=nothing

if isnull(nilai) = true then
	nilai = 0
else
	nilai = nilai
end if

if nilai = 0 and voteman = 0 then
	testiprod_nil = 0
else
	testiprod_nil = nilai/voteman
end if



sumber = "http://www.healthwealthint.com/detail.asp?kode="&idprod
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: <%=namaprd%></TITLE>
<link rel="shortcut icon" href="<%=myico%>" />
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=windows-1252">
<style type="text/css">
<!--
td {
	font-family:Tahoma;
	font-size:11px;
	color:#4F4F4F;
}
a {
	text-decoration: none;
	color:#31509F;
}
a.1 {
	text-decoration: none;
	color:#BD1818;
}
a.2 {
	text-decoration: underline;
	color:#ffffff;
}
a.3 {
	text-decoration: underline;
	color:#FFD16F;
}
a.4 {
	text-decoration: none;
	color:#FFFFFF;
}
a.5 {
	text-decoration: underline;
	color:#BD1818;
}
.t11 {
	font-family: Tahoma;
	font-size: 11px;
	font-style: normal;
}
.t10 {
	font-family: Tahoma;
	font-size: 10px;
	font-style: normal;
}
.style1 {color: #FFFFFF}
.style2 {color: #616161}
.style3 {color: #31509F}
.style4 {color: #ffffff}

-->
</style>
<style fprolloverstyle>A:hover {font-size: 11px; color: #FF9966; font-family: Tahoma; text-decoration: underline}
</style>

<body>

				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="19" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b1.gif" width="19" height="14"></td>
										<td background="images/b2.gif" width="100%" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b2.gif" width="18" height="14"></td>
										<td width="21" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b3.gif" width="21" height="14"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b4.gif" width="10" height="16"></td>
										<td valign="top" width="100%" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">										
										<div align="center">
										<table border="0" cellpadding="0" cellspacing="0" width="99%">
											<tr>
												<td valign="middle" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" bgcolor="#DDDDDD" height="20">
												<p align="center"><b>
												<font size="2">MENGIRIM EMAIL 
												INFORMASI PRODUK KE TEMAN</font></b></td>
											</tr>
											<tr>
												<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td width="552" valign="top">
		<div align="center">
			<table border="0" cellpadding="0" cellspacing="0" width="99%">
				<tr>
					<td valign="top">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td height="5"></td>
						</tr>
						<tr>
							<td bgcolor="#FFFFCE">
							<table border="0" cellpadding="4" cellspacing="4" width="100%">
								<tr>
									<td>Anda dilarang keras mengirimkan 
									informasi dibawah ini kepada orang yang 
									tidak anda kenal dan tidak menginginkan 
									informasi ini, anda dilarang keras melakukan 
									tindakan yang dapat disebut sebagai SPAM. 
									Informasi produk yang akan anda kirimkan 
									adalah, informasi produk <b><%=namaprd%></b><br>
&nbsp;</td>
								</tr>
							</table>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
						</tr>
					</table>
					</td>
				</tr>
				<tr>
					<td valign="top">
					<form name="theform" method="post" action="sentmail_info.asp" onsubmit="return formCheck(this)">
					<input type="hidden" name="source" value="<%=asal%>">
					<input type="hidden" name="kode" value="<%=kode%>">						
					<table border="0" cellspacing="1" width="100%">
						<tr>
							<td width="113">Nama Anda</td>
							<td width="15">:</td>
							<td>
							<table border="0" cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td width="145">
							<input type="text" name="nama" readonly="T" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="19" value="<%=nama_anggota%>"></td>
									<td>
									<%if aman = "T" then %>
									<%else%>
									<font color="#FF0000"><i>* silahkan 
									login terlebih dulu</i></font>
									<%end if%>
									</td>
								</tr>
							</table>
							</td>
						</tr>
						<tr>
							<td width="113">Alamat E-Mail</td>
							<td width="15">:</td>
							<td>
							<input type="text" name="email" readonly="T" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="41" value="<%=emel_anggota%>"></td>
						</tr>
						<tr>
							<td width="113">Nomor Handphone</td>
							<td width="15">:</td>
							<td>
							<input type="text" name="nohandphone" readonly="T" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="23" value="<%=hape_anggota%>"></td>
						</tr>
						<tr>
							<td width="113">E-mail Penerima - 1</td>
							<td width="15">:</td>
							<td>
							<input type="text" name="email1" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="39"></td>
						</tr>
						<tr>
							<td width="113">E-mail Penerima - 2</td>
							<td width="15">:</td>
							<td>
							<input type="text" name="email2" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="39"></td>
						</tr>
						<tr>
							<td width="113">E-mail Penerima - 3</td>
							<td width="15">:</td>
							<td>
							<input type="text" name="email3" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="39"></td>
						</tr>
						<tr>
							<td width="113">E-mail Penerima - 4</td>
							<td width="15">:</td>
							<td>
							<input type="text" name="email4" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="39"></td>
						</tr>
						<tr>
							<td width="113">E-mail Penerima - 5</td>
							<td width="15">:</td>
							<td>
							<input type="text" name="email5" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="39"></td>
						</tr>																								
						<tr>
							<td width="113" valign="top">
							&nbsp;</td>
							<td width="15" valign="top">
							&nbsp;</td>
							<td valign="top">
							<%if aman = "T" then %>
							<input type="submit" name="btsub" value="Kirimkan Email" style="font-size: 8pt; font-family: Verdana">
							<%end if%>
							</td>
							</form>
						</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td valign="top">&nbsp;</td>
				</tr>
				<%if mesej <> "" then %>
				<tr>
					<td valign="top">
					<p align="center"><font color="#FF0000"><%=mesej%></font></td>
				</tr>
				<tr>
					<td valign="top">&nbsp;</td>
				</tr>
				<%end if%>
				</table>
		</div>
																					</td>
																					<td valign="middle"><img border="0" src="images/nospam.gif" width="185" height="200"></td>
																				</tr>
																			</table>
																			</td>
											</tr>
											<tr>
												<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
												&nbsp;</td>
											</tr>
											</table>
										</div>
										</td>
										<td valign="top" background="images/b5.gif" width="9" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b5.gif" width="9" height="16"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="22" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b6.gif" width="22" height="14"></td>
										<td background="images/b7.gif" width="100%" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b7.gif" width="21" height="14"></td>
										<td width="18" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b8.gif" width="20" height="14"></td>
									</tr>
								</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
						&nbsp;</td>
					</tr>
					</table>
				
</body>

</html>
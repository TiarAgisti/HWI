<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
<!--#Include File=dbcon/opendbALL.asp-->
<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******
' Application: HEALTH WEALTH INTERNATIONAL WEBSITE
' Author: Peter Sindoro
' Coding : Septmber 2009
' Revised : -
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******     
dim refername
dim tmpname
tmpname = Session.Contents("ReferName")
Session.Contents("ReferName")= tmpname
session("menus") = "others"
noid = cint(request("id"))
manuk = Session.Contents("manuk")
sss = "T"
sss2 = "C"
pasku = "n94chok0enM45"
aman = "F"
rs.Open "SELECT kta,uid,emel,hp FROM member where kta like '"&manuk&"' and sta like '"&sss&"'",conn	
	if rs.bof then
		nama_anggota = ""
		emel_anggota = ""
		uid = ""
		telp_anggota = ""
		aman = "F"
	else
		aman = "T"
		uid = rs("kta")
		nama_anggota = rs("uid")
		emel_anggota = rs("emel")
		telp_anggota = rs("hp")
	end if
rs.Close
		
rs.Open "SELECT count(id) FROM new_konsul_produk_head where (sta like '"&sss&"' or sta like '"&sss&"')",conn	
	if rs.bof then
		x = 0
	else
		x = cint(rs("count(id)"))
	end if
rs.Close

pgview = request("pgview")
if pgview = "" then
	bg = 15
else
	bg = pgview
end if

pg = 0
pgas = request("page")
sort = request("sort")
if pgas = "" then
	pg = 0
else
if pgas<>"" then
	pg = pgas-1
end if		
end if

if x mod bg = 0 then
	tothal = x / bg
else	
	z = x+(bg-(x mod bg))
	tothal = z / bg
end if

totrec = x
halskr = pg
tujuan = pg*bg
sisa = totrec - tujuan
if sisa < bg then	
	lumpat = bg+sisa
else
	lumpat = bg
end if	

if tujuan > totrec then
	kemana = 0
else
	kemana = pg*bg
end if	

function roundup(x)
If x > Int(x) then
roundup = Int(x) + 1
Else
roundup = x
End If
End Function

pgcunt = x / bg

if pgcunt < 1 then
	pgct = 1
else
	pgct = roundup(pgcunt)
end if

session("asal") = "helpdesk.asp?session=&nabar=&id="&noid&"&page="&pg+1

if noid <> "" then
	rs.Open "SELECT * FROM new_konsul_produk_head where (sta like '"&sss&"' or sta like '"&sss2&"') and id = '"&noid&"'",conn	
		if rs.bof then
			ada = "F"
		else
			ada = "T"
			kodeprd = rs("kode")
			author = rs("kta")
			tgl = rs("tgl")
			subyek = rs("subyek")
			detil = rs("masalah")
			stakon = rs("sta")
		end if
	rs.Close
	if ada = "T" then
		rs.Open "SELECT kta,uid FROM member where kta like '"&author&"'",conn	
			if rs.bof then
			else
				namaauthor = rs("uid")
			end if
		rs.Close
		rs.Open "SELECT nama,foto FROM st_barang where kode like '"&kodeprd&"'",conn	
			if rs.bof then
			else
				namaprd = rs("nama")
				fotoprd = rs("foto")
			end if
		rs.Close	
	end if
end if
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Form Bantuan Online Health Wealth International">
   <meta name="keywords" content="helpdesk,bantuan,support,dukungan,online,health wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Bantuan Online</TITLE>
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

<script language="JavaScript">
<!--
function formCheck(form) {
if (form.uid.value == "")
{
 alert("Mohon login terlebih dulu sebagai distributor HWI");
return false;}

if (form.uid.value.length >= 8)
{
 alert("Id. distributor maksimal 8 karakter");
return false;}

if (form.nama.value == "")
{
 alert("Mohon login terlebih dulu sebagai distributor HWI");
return false;}

if (form.subyek.value == "")
{
 alert("Mohon pilih subyek / topik yang anda butuhkan");
return false;}

if (form.subyek.value == "Pilih Subyek")
{
 alert("Mohon pilih subyek / topik yang anda butuhkan");
return false;}

if (form.deskripsi.value == "")
{
 alert("Mohon isikan detail pertanyaan anda");
return false;}

if (form.password.value == "")
{
 alert("Mohon isikan password login anda");
return false;}

if (confirm("Silahkan cek apakah data yang anda isikan sudah benar ? \n\nNo. Id Distributor : " + form.uid.value +".\nNama Distributor : "+ form.nama.value+".\nSubyek : "+ form.subyek.value+"\nDetail Pertanyaan : "+ form.deskripsi.value+"\n")) {
    return true;}
    else {
    return false;}
}
// -->
</script>

<style type="text/css">
body
{
background-image:
url("<%=bgimage%>");
background-repeat:no-repeat;
background-attachment:fixed;
background-position:center;
}
</style>

</head>
<body>
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
	<tr>
		<td><!--#Include File=pg_header.asp--></td>
	</tr>
</table>
<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
	<tr>
		<td width="50%">&nbsp;</td>
		<td width="953">
		<table bgcolor="#FFFFFF"  border="0" cellpadding="0" style="border:2px solid #FFF;" width="983">
        <tr><td><table>
        <tr><td valign="top" width="663" bgcolor="#FFFFFF">
        
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td valign="top">
												<!--#Include File=slide4.asp--></td>
											</tr>
											<tr>
												<td valign="top">&nbsp;</td>
											</tr>
											<tr>
												<td valign="top" style="padding:5px;">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="19">
										&nbsp;</td>
										<td background="images/b2.gif" width="100%">
										&nbsp;</td>
										<td width="21">
										&nbsp;</td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10">
										&nbsp;</td>
										<td valign="top" width="100%">										
										<div align="center">
										<table border="0" cellpadding="0" cellspacing="0" width="99%">
											<tr>
												<td valign="top" background="images/bg_text.gif">
												<img border="0" src="images/text_helpdesk.gif" width="471" height="63"></td>
											</tr>
											<tr>
												<td valign="top">
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td bgcolor="#FFFFCE">
														<table border="0" cellpadding="4" cellspacing="4" width="100%" style="text-align: justify">
															<tr>
																<td>Anda 
																memiliki 
																pertanyaan 
																mengenai 
																pemahaman sistem 
																quadro plan atau 
																mungkin anda 
																ingin menanyakan 
																mengenai 
																transfer bonus, 
																atau kontrol 
																panel 
																distributor 
																login anda, 
																melaporkan 
																adanya 
																pelanggaran-pelanggaran 
																kode etik atau 
																bahkan ingin 
																memberikan 
																laporan ke pusat 
																mengenai 
																kualitas 
																pelayanan DC, 
																leader atau YESS 
																Support system ? 
																Silahkan isi 
																form dibawah ini, 
																departemen 
																terkait akan 
																segera 
																memberikan 
																tanggapan 
																melalui form ini 
																atau langsung 
																menghubungi anda 
																melalui telepon.
																<font color="#FF0000">
																Untuk segala 
																jenis pertanyaan 
																yang berkaitan 
																dengan produk, 
																mohon gunakan 
																form konsultasi 
																produk</font>. 
																Anda harus login 
																sebagai 
																distributor HWI 
																terlebih dulu 
																untuk dapat 
																mengirimkan 
																tiket bantuan 
																online ini. HWI 
																akan selalu 
																memperhatikan 
																aspirasi anda 
																dan berusaha 
																memberikan jalan 
																keluar yang 
																terbaik sesuai 
																motto &quot;together 
																we grow&quot; .....
																Terima kasih.</td>
															</tr>
														</table>
														</td>
													</tr>
												</table>
												</td>
											</tr>
											<tr>
												<td valign="top" height="3">
												</td>
											</tr>
											<tr>
												<td valign="top">
												<div align="center">
													<table border="0" cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td valign="top">
												<form name="form1" method="post" action="sent_bantuanonline.asp" onSubmit="return formCheck(this)">															
															<table border="0" cellspacing="1" width="100%">
																<tr>
																	<td width="111" bgcolor="#808080">
																	<font color="#FFFFFF">&nbsp; No. 
																	Id. 
																	Distributor</font></td>
																	<td width="8" bgcolor="#808080">
																	<font color="#FFFFFF">:</font></td>
																	<td bgcolor="#EFEFEF"><input type="text" name="uid" value="<%=manuk%>" readonly="T" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="11"></td>
																</tr>
																<tr>
																	<td width="111" bgcolor="#808080">
																	<font color="#FFFFFF">&nbsp; Nama 
																	Lengkap</font></td>
																	<td width="8" bgcolor="#808080">
																	<font color="#FFFFFF">:</font></td>
																	<td bgcolor="#EFEFEF">
																	<input type="text" name="nama" value="<%=nama_anggota%>" readonly="T" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="26"></td>
																</tr>
																<tr>
																	<td width="111" bgcolor="#808080">
																	<font color="#FFFFFF">&nbsp; 
																	Alamat 
																	E-mail</font></td>
																	<td width="8" bgcolor="#808080">
																	<font color="#FFFFFF">:</font></td>
																	<td bgcolor="#EFEFEF">
																	<input type="text" name="email" value="<%=emel_anggota%>" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="32"></td>
																</tr>
																<tr>
																	<td width="111" bgcolor="#808080">
																	<font color="#FFFFFF">&nbsp; Nomor 
																	Telepon</font></td>
																	<td width="8" bgcolor="#808080">
																	<font color="#FFFFFF">:</font></td>
																	<td bgcolor="#EFEFEF">
																	<input type="text" name="notelp" value="<%=telp_anggota%>" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="30"></td>
																</tr>
																<tr>
																	<td width="111" bgcolor="#808080">
																	<font color="#FFFFFF">&nbsp; 
																	Subyek</font></td>
																	<td width="8" bgcolor="#808080">
																	<font color="#FFFFFF">:</font></td>
																	<td bgcolor="#EFEFEF">
															<select size="1" name="subyek" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080">		
               													<option value="Pilih Subyek">
																--Pilih Subyek Anda--</option>
               													<option value="Transfer Bonus">
																Seputar 
																Permasalahan 
																Bonus</option>
               													<option value="Permasalahan Jaringan">
																Seputar 
																Permasalahan 
																Jaringan, Upline, Downline, Leader</option>
               													<option value="Pelayanan DC/MC">
																Berkaitan dengan 
																Pelayanan DC / 
																MC</option>
               													<option value="Quadro Plan">
																Pemahaman Mengenai Quadro Plan</option>																
               													<option value="Information Technology">
																Seputar Information 
																Technology</option>
               													<option value="Keanggotaan">
																Mengenai Account Distributor Anda</option>																
               													<option value="Support System">
																Berhubungan 
																dengan YESS 
																Support System</option>
															</select></td>
																</tr>
																<tr>
																	<td width="111" valign="top" bgcolor="#808080">
																	<font color="#FFFFFF">&nbsp; 
																	Detail 
																	Permasalahan</font></td>
																	<td width="8" valign="top" bgcolor="#808080">
																	<font color="#FFFFFF">:</font></td>
																	<td bgcolor="#EFEFEF">
																<textarea rows="12" name="deskripsi" cols="79" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080"></textarea></td>
																</tr>
																<tr>
																	<td width="111" bgcolor="#808080">
																	<font color="#FFFFFF">&nbsp; 
																	Password 
																	Login</font></td>
																	<td width="8" bgcolor="#808080">
																	<font color="#FFFFFF">:</font></td>
																	<td bgcolor="#EFEFEF">
															<input type="password" name="password" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="20"></td>
																</tr>
																<tr>
																	<td width="111" bgcolor="#808080">&nbsp;
																	</td>
																	<td width="8" bgcolor="#808080">&nbsp;
																	</td>
																	<td bgcolor="#EFEFEF">
															<font face="Verdana" size="1">
															<%if aman="T" and session("manuk") <> "" then %>
														<input type="submit" name="btkirim" value="Kirimkan" style="font-size: 8pt; font-family: Verdana"></font>
														<%else%>
														<i><font color="#FF0000">Silahkan login terlebih dulu</font></i>
														<%end if%>
														</td>
														</form>
																</tr>
															</table>
															</td>
														</tr>
													</table>
												</div>
												</td>
											</tr>
											</table>
										</div>
										</td>
										<td valign="top" background="images/b5.gif" width="9">
										&nbsp;</td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="22">
										&nbsp;</td>
										<td background="images/b7.gif" width="100%">
										&nbsp;</td>
										<td width="18">
										&nbsp;</td>
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
						<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="19">
										&nbsp;</td>
										<td background="images/b2.gif" width="100%">
										&nbsp;</td>
										<td width="21">
										&nbsp;</td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10">
										&nbsp;</td>
										<td valign="top" width="100%">										
										<div align="center">
										<table border="0" cellpadding="0" cellspacing="0" width="99%">
											<tr>
												<td valign="top" background="images/bg_text.gif">
												<img border="0" src="images/text_helpdesk_arsip.gif" width="471" height="63"></td>
											</tr>
											<tr>
												<td valign="top">&nbsp;
												</td>
											</tr>
											<tr>
												<td valign="top">
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td valign="top" align="center" width="25%">
														bonus</td>
														<td valign="top" align="center" width="25%">
														dc/mc</td>
														<td valign="top" align="center" width="25%">
														it</td>
														<td valign="top" align="center" width="25%">
														quadro plan</td>
													</tr>
													<tr>
														<td valign="top" align="center" width="25%">&nbsp;</td>
														<td valign="top" align="center" width="25%">&nbsp;</td>
														<td valign="top" align="center" width="25%">&nbsp;</td>
														<td valign="top" align="center" width="25%">&nbsp;</td>
													</tr>
													<tr>
														<td valign="top" align="center" width="25%">
														jaringan</td>
														<td valign="top" align="center" width="25%">
														akun</td>
														<td valign="top" align="center" width="25%">
														yess</td>
														<td valign="top" align="center" width="25%">
														jaringan</td>
													</tr>
												</table>
												</td>
											</tr>
											<tr>
												<td valign="top">&nbsp;
												</td>
											</tr>
											</table>
										</div>
										</td>
										<td valign="top" background="images/b5.gif" width="9">
										&nbsp;</td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="22">
										&nbsp;</td>
										<td background="images/b7.gif" width="100%">
										&nbsp;</td>
										<td width="18">
										&nbsp;</td>
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
						<td valign="top">&nbsp;
						</td>
					</tr>
					</table>
						</td>
					</tr>
					</table>
				</td></tr></table>
        
</td>



<td valign="top" height="100" width="320" bgcolor="#EEEEEE">
      
<!--#Include File=calendar.asp-->

<!--#Include File=pg_testimonial.asp-->

<!--#Include File=pg_konsul.asp-->

</td>
</tr>
</table>
        </td></tr>
        <tr><td bgcolor="#191919">
        
        <!--#Include File=pg_footer.asp-->

        
        </td></tr></table>
        </td>
		<td width="50%">&nbsp;</td>
	</tr>
</table></body>

</html>
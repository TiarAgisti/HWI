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
session("menus") = "produk"
'noid = trim(request("id"))
'kode = trim(request("kode"))
'tipe = request("asal")

noid = SafeSQL(ucase(request("id")))
kode = SafeSQL(ucase(request("kode")))
tipe = SafeSQL(ucase(request("asal")))

mesej = session("pesankomen")
session("pesankomen") = ""

asal = session("asal")

manuk = Session.Contents("manuk")
sss = "T"
aman = "F"
rs.Open "SELECT uid,kta FROM member WHERE kta like '"&manuk&"' and sta like '"&sss&"'",conn
	if rs.bof then
		aman = "F"
		Session.Contents("manuk") = ""
		nama_log = ""
	else
		aman = "T"
		Session.Contents("manuk") = rs("kta")
		nama_log = rs("uid")		
	end if
rs.Close

	if tipe = "PRODUK" then
		rs.Open "SELECT * FROM testi_prod WHERE prod_id like '"&kode&"' and sta like '"&sss&"' order by tgl desc limit 1",conn,1,3	
	else
		rs.Open "SELECT * FROM testi_prod WHERE id like '"&noid&"' and sta like '"&sss&"'",conn,1,3	
	end if
	
		if rs.bof then
			rs.close
			set rs=nothing
			Conn.Close
			set conn=nothing	
			response.redirect asal1
		else
			tgl_testi = rs("tgl")
			isi_testi = rs("isi")
			sapa = rs("kta")
			kirim = rs("dikirim")
			img_testi1 = rs("foto")
			nile_testi = rs("nilai")
			kode_prd = rs("prod_id")
			kode = rs("prod_id")
			uraian_testi = rs("uraian")
			id_testi = rs("id")
		end if
	rs.Close

	rs.Open "SELECT nama FROM st_barang WHERE kode like '"&kode_prd&"'",conn
		if rs.bof then
			nama_prd = ""
		else
			nama_prd = ucase(rs("nama"))
		end if	
	rs.close 

	if sapa <> "-" then
		rs.Open "SELECT kta,uid, kota FROM member WHERE kta like '"&sapa&"'",conn
			if rs.bof then
				dikirim_testi = "Anonymous"
			else
				dikirim_nama = ucase(rs("uid"))
				dikirim_kota = ucase(rs("kota"))			
				if isnull(dikirim_kota) = false then
					dikirim_testi = cstr(dikirim_nama)+" - "+cstr(dikirim_kota)
				else
					dikirim_testi = cstr(dikirim_nama)
				end if	
			end if
		rs.Close
	else	
	if kirim <> "-" then
		dikirim_testi = kirim
	end if	
	end if


	rs.Open "SELECT count(id) FROM testi_prod WHERE prod_id like '"&kode&"' and sta like '"&sss&"'",conn
		if rs.bof then
			xas = 0
		else
			xas = clng(rs("count(id)"))
		end if	
	rs.close 

	pgview = request("pgview")
	pgview = SafeSQL(ucase(request("pgview")))
	if pgview = "" then
		bg = 10
	else
		bg = pgview
	end if

	pg = 0
	'pgas = request("page")
	'sort = request("sort")
	pgas = SafeSQL(ucase(request("page")))
	sort = SafeSQL(ucase(request("sort")))
	if pgas = "" then
		pg = 0
	else
	if pgas<>"" then
		pg = pgas-1
	end if		
	end if

	if xas mod bg = 0 then
		tothal = xas / bg
	else	
		z = xas+(bg-(xas mod bg))
		tothal = z / bg
	end if
	
	totrec = xas
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
		lim = bg
	else
		kemana = pg*bg
		if kemana = 0 then
			lim = bg
		else
			lim = kemana*2
		end if		
	end if	
	
	function roundup(xas)
	If x > Int(xas) then
	roundup = Int(xas) + 1
	Else
	roundup = xas
	End If
	End Function
	
	pgcunt = xas / bg
	
	if pgcunt < 1 then
		pgct = 1
	else
		pgct = roundup(pgcunt)
	end if

session("asal") = "baca_testimonial_produk.asp?session=&nabar=&id="&id_testi&"&asal="&tipe&"&sort="&sort&"&page="&pg+1&"&keyword="&txtcari
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Testimonial Produk Health Wealth International">
   <meta name="keywords" content="testimonial,kesaksian,produk,health wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Testimonial Produk</TITLE>
<link rel="shortcut icon" href="<%=myico%>" />
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=windows-1252">
<link href="csstsyle.css" type="text/css" rel="stylesheet">
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

<style type="text/css">
.pagination{
padding: 2px;
}

.pagination ul{
margin: 0;
padding: 0;
text-align: left; /*Set to "right" to right align pagination interface*/
font-size: 11px;
}

.pagination li{
list-style-type: none;
display: inline;
padding-bottom: 1px;
}

.pagination a, .pagination a:visited{
padding: 0 5px;
border: 1px solid #9aafe5;
text-decoration: none; 
color: #2e6ab1;
}

.pagination a:hover, .pagination a:active{
border: 1px solid #2b66a5;
color: #000;
background-color: #FFFF80;
}

.pagination a.currentpage{
background-color: #2e6ab1;
color: #FFF !important;
border-color: #2b66a5;
font-weight: bold;
cursor: default;
}

.pagination a.disablelink, .pagination a.disablelink:hover{
background-color: white;
cursor: default;
color: #929292;
border-color: #929292;
font-weight: normal !important;
}

.pagination a.prevnext{
font-weight: bold;
}
</style>

<SCRIPT language="JavaScript1.2" src="gen_validation.js"></SCRIPT>

<style type="text/css">
#chromemenu{
width: 100%;
font-weight: bold;
font-size: 100%;
}

#chromemenu:after{ /*Add margin between menu and rest of content in Firefox*/
content: "."; 
display: block; 
height: 0; 
clear: both; 
visibility: hidden;
}

#chromemenu ul{
border: 1px solid #BBB;
width: 100%;
background: url(images/chromebg.gif) center center repeat-x;
padding: 5px 0;
margin: 0;
text-align: left; /*set value to "right" for example to align menu to the left of page*/
}

#chromemenu ul li{
display: inline;
}

#chromemenu ul li a{
color: #494949;
padding: 5px;
margin: 0;
text-decoration: none;
border-right: 1px solid #DADADA;
}

#chromemenu ul li a:hover{
background: url(images/chromebg2.gif) center center repeat-x;
}
</style>

<script language="javascript">
<!--

function HitungKar(juma) {
	var Hit_juma = juma.value.length;
	if ( Hit_juma > 2500 ) {
		juma.value = juma.value.substring(0,2500);
	} else {
		document.theform.sisas.value = "" + (2500-Hit_juma);
	}
}
//-->
</script>

<script language="JavaScript">
<!-- Begin
var submitcount=0;

function formCheck(form) {
if (form.kode.value == "")
{
 alert("Mohon pilih produk terlebih dulu");
return false;}

if (form.membid.value == "")
{
 alert("Mohon isikan nomor id distributor anda");
return false;}

if (form.nama.value == "")
{
 alert("Mohon isikan nama lengkap anda");
return false;}

if (form.nilai.value == "")
{
 alert("Mohon pilih penilaian anda");
return false;}

if (form.deskripsi.value == "")
{
 alert("Mohon isikan komentar anda");
return false;}

if (confirm("Silahkan cek ulang apa yang telah anda isikan \n\nNo. Id. Distributor : " + form.membid.value +".\nNama Anda : "+ form.nama.value+"\nKomentar : "+ form.deskripsi.value+"\n")) {
    return true;}   
	else 
	   {
	   if (submitcount == 0)
	      {
	      submitcount++;
	      return false;
	      }
	   else 
	      {
	      alert("Testimonial sedang disimpan kedalam database, silahkan tunggu hingga proses penyimpanan data selesai dilakukan. Silahkan tutup pesan ini untuk melanjutkan proses.");
	      return false;
	      }
	   }        
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
										<img border="0" src="images/b1.gif" width="19" height="14"></td>
										<td background="images/b2.gif" width="100%">
										<img border="0" src="images/b2.gif" width="18" height="14"></td>
										<td width="21">
										<img border="0" src="images/b3.gif" width="21" height="14"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10">
										<img border="0" src="images/b4.gif" width="10" height="16"></td>
										<td valign="top" width="100%">										
										<div align="center">
										<table border="0" cellpadding="0" cellspacing="0" width="98%">
											<tr>
												<td valign="top" bgcolor="#EFEFEF">
													<table border="0" cellpadding="4" cellspacing="4" width="100%">
													<tr>
														<td valign="top">
												<p align="center"><b>
												<font size="3">TESTIMONIAL PRODUK <%=nama_prd%>
												</font></b>																												
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
												<div align="center">
												<table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: justify">
													<tr>
													<%if img_testi1 <> "-" then %>
														<td width="170" valign="top"><img border="1" src="<%=img_testi1%>"></td>
													<%else%>
														<td width="1" valign="top"></td>
													<%end if%>
													<%if img_testi1 <> "-" then %>	
													<td valign="top">
													<%else%>
													<td valign="top" width="100%" >
													<%end if%>
												<b>Dikirim oleh :</b> <%=dikirim_testi%><br>
												<%=formatdatetime(tgl_testi,1)%><br><br>														
														<%=isi_testi%>
														<br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td width="74">
																Nilai Diberikan</td>
																<td width="10">:</td>
																<td>
									<%
									session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
									%>																															
									<img border="0" src="images/starimages/<%=formatnumber(nile_testi,1)%>.gif" width="64" height="12">
									<%
									session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
									%>																
																</td>
															</tr>
														</table>
														<% if uraian_testi <> "-" then %>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>&nbsp;</td>
															</tr>
															<tr>
																<td>
																<table border="0" cellpadding="0" cellspacing="0" width="100%">
																	<tr>
																		<td>
																		<table border="1" cellspacing="1" width="99%" style="border-collapse: collapse" bordercolor="#808080">
																			<tr>
																				<td valign="top">
																				<table border="0" cellpadding="0" cellspacing="0" width="100%">
																					<tr>
																						<td bgcolor="#2B66A5" height="25">
																						<p align="center"><font color="#FFFFFF"><b>ULASAN DAN CATATAN</b></font></td>
																					</tr>
																				</table>
																				<table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="#E1FFE1">
																					<tr>
																						<td valign="top">
																						<table border="0" cellpadding="5" cellspacing="5" width="100%">
																							<tr>
																								<td><i><%=uraian_testi%></i></td>
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
																</td>
															</tr>
														</table>
														<%end if%>
														</td>
													</tr>
													<tr>
														<td width="170" valign="top">&nbsp;</td>
														<td valign="top">&nbsp;</td>
													</tr>													
												</table>
												</div>
												</td>
											</tr>
											</table>
										</td>
										<td valign="top" background="images/b5.gif" width="9">
										<img border="0" src="images/b5.gif" width="9" height="16"></td>
									</tr>
								</table>
										</div>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="22">
										<img border="0" src="images/b6.gif" width="22" height="14"></td>
										<td background="images/b7.gif" width="100%">
										<img border="0" src="images/b7.gif" width="21" height="14"></td>
										<td width="18">
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
						<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<%if mesej <> "" then %>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>
								<table border="0" cellpadding="4" cellspacing="4" width="100%" bgcolor="#FFEFDF">
									<tr>
										<td>
										<p align="center"><font color="#FF0000">
										<b><%=mesej%></b></font></td>
									</tr>
								</table>
								</td>
							</tr>
							<%end if%>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
						</td>
					</tr>
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
								<div align="right">
									<table border="0" cellpadding="0" cellspacing="0" width="99%">
										<tr>
											<td valign="top">
											<img border="0" src="images/text_testi_arsip.gif" width="371" height="63"><table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td>Ditemukan <b>
													<font color="#FF0000"><%=formatnumber(xas,0)%></font></b> 
													testimonial lainnya untuk produk
													<font color="#FF0000"><b>
													<%=nama_prd%></b></font></td>
												</tr>
											</table>
											</td>
										</tr>
										<tr>
											<td valign="top">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
														<td valign="top">
<%
intHowManyCharw = 200
rs.Open "SELECT * FROM testi_prod WHERE prod_id like '"&kode&"' and sta like '"&sss&"' order by tgl desc limit "&lim&"",conn
if rs.bof then %>

									<table border="0" cellspacing="1" width="100%" id="table14" style="border-collapse: collapse" bordercolor="#808080">
										<tr>
											<td width="100%" align="center" valign="middle" height="40" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
													<font face="Verdana" size="2">
													<u>Belum ada arsip testimonial untuk produk <%=nama_prd%></u></font></td>
										</tr>									

<%
else
	rs.move kemana
end if	

	if rs.eof<>True then

	if goneqSS <> 0 then
		 for aaeeqSS = 1 to goneqSS
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if
%>														
														<div align="center">
														<table border="0" cellpadding="0" cellspacing="0" width="98%">
															<tr>
																<td bgcolor="#FFFFCE">&nbsp;</td>
															</tr>
														</table>
														<table border="0" cellpadding="0" cellspacing="0" width="98%">
<%
for aaaeqSSS = 1 to lumpat
if rs.eof = True then exit for
sdesk_testi = rs("isi")
sapa = rs("kta")
kirim = rs("dikirim")

if sapa <> "-" then
	rsALL.Open "SELECT kta,uid, kota FROM member WHERE kta like '"&sapa&"'",connALL
		if rsALL.bof then
			dikirim_testi = "Anonymous"
		else
			dikirim_nama = ucase(rsALL("uid"))
			dikirim_kota = ucase(rsALL("kota"))			
			if isnull(dikirim_kota) = false then
				dikirim_testis = cstr(dikirim_nama)+" - "+cstr(dikirim_kota)
			else
				dikirim_testis = cstr(dikirim_nama)
			end if	
		end if
	rsALL.Close
else	
if kirim <> "-" then
	dikirim_testis = kirim
end if	
end if

If len(sdesk_testi) > intHowManyCharw then
	singkat_testi = left(decodeString(sdesk_testi),intHowManyCharw) & "  ...........&nbsp;"
else
	singkat_testi= sdesk_testi
End If
%>														
															<tr>
																<td width="21" valign="top" bgcolor="#FFFFCE">
																<p align="right">
																<img border="0" src="images/bul_green.gif" width="10" height="11"></td>
																<td valign="top" bgcolor="#FFFFCE">
																<table border="0" cellpadding="0" cellspacing="0" width="96%">
																	<tr>
																		<td valign="top">
																			<b><a target="_top" href="baca_testimonial_produk.asp?id=<%=rs("id")%>&asal=kesaksian">
																			<font color="#000000"><%=dikirim_testis%></font></a></b>, <%=singkat_testi%>																		
																		</td>
																	</tr>
																</table>
																</td>
															</tr>
<%  
rs.movenext
next
end if
if rs.eof = True then
end if
rs.Close

set rsall=nothing
ConnALL.Close
set connALL=nothing
%>																
															<tr>
																<td width="21" valign="top" bgcolor="#FFFFCE">&nbsp;
																</td>
																<td valign="top" bgcolor="#FFFFCE">&nbsp;</td>
															</tr>
														</table>
														</div>
														</td>
													</tr>
												<tr>
														<td valign="top">&nbsp;
</td>
													</tr>
											</table>
											</td>
										</tr>
<% if xas > 0 then %>										
										<tr>
											<td valign="top">
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
											<div class="pagination">											
<%
	x1 = xas
	aax = 0
	dim saatini
	if x1 mod bg = 0 then
		y = x1 / bg
	else	
		z = x1+(bg-(x1 mod bg))
		y = z / bg
	end if		
	
	if pg > 0 and pg < 15 then
		ke = 0
	else
	if pg > 14 and pg < 30 then
		ke = 15
	else
	if pg > 29 and pg < 45 then
		ke = 30
	else
	if pg > 44 and pg < 60 then	
		ke = 45
	else
	if pg > 59 and pg < 75 then	
		ke = 60
	else
	if pg > 74 and pg < 90 then	
		ke = 75
	else
	if pg > 89 and pg < 105 then	
		ke = 90
	else
	if pg > 104 and pg < 120 then	
		ke = 105
	else
	if pg > 119 and pg < 135 then	
		ke = 120
	else
	if pg > 134 and pg < 150 then	
		ke = 135
	end if		
	end if		
	end if		
	end if		
	end if		
	end if		
	end if	
	end if		
	end if
	end if		

	kembali = request("prev")
	if saatini = 0 then
		saatini = 2
	else
		saatini = saatini
	end if

	for aax = 1 to 30
	aax = aax+1
	ke = ke + 1
	%>
	<% if ke = 1 or ke = 16 or ke = 31 or ke = 46 or ke = 61 or ke = 76 or ke = 91 or ke = 106 or ke = 121 or ke = 136 then %>
	<ul style="text-align: left; font-size: 11px; margin: 0; padding: 0">
		<li style="list-style-type: none; display: inline; padding-bottom: 1px">
	<% if kembali = 0 then %>
	<a href="#" class="prevnext disablelink">
	<%else%>
	<a href="baca_testimonial_produk.asp?id=<%=noid%>&kode=<%=kode%>&asal=<%=tipe%>&sort=<%=sort%>&page=<%=kembali%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=kembali-1%>&nexts=<%=ke+1%>" class="prevnext">
	<%end if%>
		« previous</a></li>	
	<% 
	end if
	if ke < y+1 then		
	if pg+1 = ke then 
	saatini = ke
	%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="baca_testimonial_produk.asp?id=<%=noid%>&kode=<%=kode%>&asal=<%=tipe%>sort=<%=sort%>&page=<%=ke%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" class="currentpage"><%=formatnumber(ke,0)%></a></li>
	<%else%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px">
	<a href="baca_testimonial_produk.asp?id=<%=noid%>&kode=<%=kode%>&asal=<%=tipe%>&sort=<%=sort%>&page=<%=ke%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" style="text-decoration: none; color: #2e6ab1; border: 1px solid #9aafe5; padding-left: 5px; padding-right: 5px; padding-top: 0; padding-bottom: 0"><%=formatnumber(ke,0)%></a></li>
	<%    
	end if
	if aax = 30 then
	exit for
	end if
	end if
	next
	%>	
	<% if tothal < saatini or tothal = saatini then %>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="#" class="prevnext disablelink">
	next »</a></li>
	<%else%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="baca_testimonial_produk.asp?id=<%=noid%>&kode=<%=kode%>&asal=<%=tipe%>&sort=<%=sort%>&page=<%=saatini+1%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=saatini%>&nexts=<%=saatini+1%>" class="prevnext">
	next »</a></li>
	<%end if%>
	</ul>
	</div>			
		</td>
	</tr>
</table>
											</td>
										</tr>
<%end if%>										
										<tr>
											<td valign="top">&nbsp;</td>
										</tr>
										</table>
								</div>
								</td>
								<td width="243" valign="top">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top">
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td width="22">
												<img border="0" src="images/b1_komen.gif" width="22" height="11"></td>
												<td background="images/b2_komen.gif" width="100%">
												<img border="0" src="images/b2_komen.gif" width="19" height="11"></td>
												<td width="25">
												<img border="0" src="images/b3_komen.gif" width="25" height="11"></td>
											</tr>
										</table>
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td valign="top" width="16" background="images/b4_komen.gif">
												<img border="0" src="images/b4_komen.gif" width="16" height="13"></td>
												<td valign="top" bgcolor="#FFFFFF" width="100%">
												
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td valign="top">
<form name="theform" method="post" action="add_mykomen.asp" onSubmit="return formCheck(this)">
<input type="hidden" name="kode" value="<%=kode%>">	
<input type="hidden" name="tipe" value="testimonial_produk">	
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td valign="top" bgcolor="#EFEFEF">
				<table border="0" cellpadding="4" cellspacing="4" width="100%" style="text-align: justify">
					<tr>
						<td valign="top">Apabila anda ingin memberikan 
						testimonial mengenai pengalaman anda dengan mengkonsumsi 
						produk <font color="#FF0000"><%=nama_prd%></font> diatas, silahkan isi form dibawah ini. Anda
						<b>harus login terlebih dulu</b> sebagai distributor HWI.</td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td valign="top">&nbsp;</td>
			</tr>
			<tr>
				<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td>Distributor Id.</td>
						<td width="10" align="center">:</td>
						<td width="125">
							<font size="1">
							<input type="text" name="membid" readonly="T" onKeyDown="if(event.keyCode==13) event.keyCode=9;" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt" size="10" value="<%=manuk%>"></font></td>
					</tr>
					<tr>
						<td>Nama Lengkap</td>
						<td width="10" align="center">:</td>
						<td width="125">
							<font size="1">
							<input type="text" name="nama" readonly="T" onKeyDown="if(event.keyCode==13) event.keyCode=9;" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt" size="17" value="<%=nama_log%>"></font></td>
					</tr>
					<tr>
						<td>Penilaian</td>
						<td width="10" align="center">:</td>
						<td width="125">
							<select size="1" name="nilai" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080">
							<option value="1">Biasa</option>
							<option value="2">Lumayan</option>
							<option value="3">Bagus</option>
							<option value="4">Memuaskan</option>
							<option value="5">Luar Biasa !!!</option>
							</select>
						</td>
					</tr>					
					<tr>
						<td valign="top">Komentar</td>
						<td width="10" align="center" valign="top">:</td>
						<td width="125">
							<font size="1">
							<textarea rows="21" name="deskripsi" onKeyDown=HitungKar(this.form.deskripsi) onKeyUp=HitungKar(this.form.deskripsi) cols="17" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt"></textarea></font></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td width="10" align="center">&nbsp;</td>
						<td width="125">
													<table border="0" cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td width="82" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
															<font color="#FF0000" face="Verdana" size="1">
															<i>Mak 2500 char</i></font></td>
															<td width="4" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
															<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
														<font size="1">
														<input type="text" readony="T" name="sisas" readonly="T" style="font-family: Verdana; border: 1px solid #808080; color:#FF0000; font-size:8pt" size="3" value="2500"></font></td>
														</tr>
													</table>
															</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td width="10" align="center">&nbsp;</td>
						<td width="125"><font size="1">
						<%if Session.Contents("manuk") <> "" and aman = "T" and nama_log <> "" then %>
							<input type="submit" name="btsub0" value="Submit" style="font-family: Verdana; font-size:8pt"></font>
						<%end if%>	
							</td>
						</form>	
					</tr>
				</table>
				</td>
			</tr>
			</table>
		
														</td>
													</tr>
												</table>
												</td>
												<td valign="top" background="images/b5_komen.gif" width="17">
												<img border="0" src="images/b5_komen.gif" width="17" height="13"></td>
											</tr>
										</table>
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td width="33">
												<img border="0" src="images/b6_komen.gif" width="33" height="65"></td>
												<td background="images/b7_komen.gif" width="100%">
												<img border="0" src="images/b5_komenliputan_text.gif" width="73" height="65"></td>
												<td width="22">
												<img border="0" src="images/b8_komen.gif" width="22" height="65"></td>
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
						</td>
					</tr>
					<tr>
						<td valign="top">&nbsp;</td>
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
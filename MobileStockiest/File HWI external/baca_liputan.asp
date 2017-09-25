<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
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
asal = session("asal")
mesej = session("pesankomen")
session("pesankomen") = ""
'tipe = request("asal")
tipe = SafeSQL(ucase(request("asal")))
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

noid = SafeSQL(ucase(request("id")))
if noid = "" then
	rs.Open "SELECT * FROM liputan WHERE sta like '"&sss&"' order by tgl DESC LIMIT 1",conn,1,3	
else
	rs.Open "SELECT * FROM liputan WHERE id = '"&noid&"' and sta like '"&sss&"'",conn,1,3	
end if

	if rs.bof then
		rs.close
		set rs=nothing
		Conn.Close
		set conn=nothing	
		response.redirect asal
	else
		rs.update
			rs("hits") = rs("hits")+1
		rs.update
		idnyaku = rs("id")
		judul_liputan = rs("judul")
		tgl_liputan = rs("tgl")
		isi_liputan = rs("deskripsi")
		dikirim_liputan = rs("oleh")
		img_liputan1 = rs("gambar1")
		img_liputan2 = rs("gambar2")
		img_liputan3 = rs("gambar3")
		noid = rs("id")
	end if
rs.Close

rs.Open "SELECT count(id) FROM liputan WHERE sta like '"&sss&"' and id <> '"&noid&"'",conn
	if rs.bof then
		xas = 0
	else
		xas = clng(rs("count(id)"))
	end if	
rs.close 

pgview = request("pgview")
pgview = SafeSQL(ucase(request("pgview")))
if pgview = "" then
	bg = 15
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
session("asal") = "baca_liputan.asp?session=&nabar=&id="&noid&"&asal="&tipe&"&sort="&sort&"&page="&pg+1&"&keyword="&txtcari

session("okehberita") = 5
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Liputan Kegiatan Health Wealth International">
   <meta name="keywords" content="kegiatan,liputan,healt wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Liputan Kegiatan</TITLE>
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
	if ( Hit_juma > 250 ) {
		juma.value = juma.value.substring(0,250);
	} else {
		document.theform.sisas.value = "" + (250-Hit_juma);
	}
}
//-->
</script>

<script language="JavaScript">
<!-- Begin
var submitcount=0;

function formCheck(form) {
if (form.id.value == "")
{
 alert("Mohon pilih liputan terlebih dulu");
return false;}

if (form.membid.value == "")
{
 alert("Mohon isikan nomor id distributor anda");
return false;}

if (form.nama.value == "")
{
 alert("Mohon isikan nama lengkap anda");
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
	      alert("Komentar sedang disimpan kedalam database, silahkan tunggu hingga proses penyimpanan data selesai dilakukan. Silahkan tutup pesan ini untuk melanjutkan proses.");
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
										&nbsp;</td>
										<td background="images/b2.gif" width="100%">
										&nbsp;</td>
										<td width="21">
										&nbsp;</td>
									</tr>
								</table>
								<%
banyak = session("okehberita")
if banyak = "" then
	banyak = 4
else
	banyak = banyak
end if

akt = "T"
intHowManyCharw = 300
rs.Open "SELECT * FROM berita WHERE sta like '"&akt&"' order by tgl desc limit "&banyak&"",conn

	if rs.eof<>True then

	if goneqSS <> 0 then
		 for aaeeqSS = 1 to goneqSS
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if
%>				<%
for aaaeqSSS = 1 to banyak
if rs.eof = True then exit for
judul_berita = rs("title")
tgl_berita = rs("tgl")
desk_berita = rs("isi")

if len(desk_berita) > intHowManyCharw then
	d_berita = left(decodeString(desk_berita),intHowManyCharw) & "  ...........&nbsp;"
else
	d_berita = desk_berita
End If
%>		<%  
rs.movenext
next
end if
if rs.eof = True then
end if
rs.Close
%>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10">
										&nbsp;</td>
										<td valign="top" width="100%">										
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td valign="top" bgcolor="#EFEFEF">
													<table border="0" cellpadding="4" cellspacing="4" width="100%">
													<tr>
														<td valign="top">
												<p align="center"><b>
												<font size="3" color="#31509F"><%=ucase(judul_liputan)%><br>
												</font></b><%=formatdatetime(tgl_liputan,1)%><br>
												Dikirim oleh : <%=dikirim_liputan%>														
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
												<table border="0" cellpadding="0" cellspacing="0" width="98%" style="text-align: justify">
													<tr>
														<td width="192" valign="top">
														<%if img_liputan1 <> "-" then %>
														<img border="1" src="<%=img_liputan1%>" width="177" height="115">
														<%end if%>
														<%if img_liputan2 <> "-" then %>
														<br><br>
														<img border="1" src="<%=img_liputan2%>" width="177">
														<%end if%>														
														<%if img_liputan3 <> "-" then %>
														<br><br>
														<img border="1" src="<%=img_liputan3%>" width="177">
														<%end if%>															
														</td>
														<td valign="top"><%=isi_liputan%>
														<%if idnyaku = 55 then %>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/genting_big1.jpg"></td>
															</tr>
														</table>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/genting_big2.jpg"></td>
															</tr>
														</table>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/genting_big3.jpg"></td>
															</tr>
														</table>													
														<%end if%>														
														<%if idnyaku = 49 then %>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/eld_big1.jpg"></td>
															</tr>
														</table>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/eld_big3.jpg"></td>
															</tr>
														</table>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/eld_big2.jpg"></td>
															</tr>
														</table>													
														<%end if%>														
														<%if idnyaku = 37 then %>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/promo_bali_big1.jpg"></td>
															</tr>
														</table>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/promo_bali_big2.jpg"></td>
															</tr>
														</table>
														<br><br>
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
																<p align="center">
																<img border="1" src="images/berita/promo_bali_big3.jpg"></td>
															</tr>
														</table>													
														<%end if%>
														</td>
													</tr>
													<tr>
														<td width="192">&nbsp;</td>
														<td valign="top">&nbsp;</td>
													</tr>													
												</table>
												</div>
												</td>
											</tr>
											</table>
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
							<tr>
								<td>&nbsp;</td>
							</tr>
							<%end if%>
							<tr>
								<td>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td>
										<div align="center">
											<table border="0" cellpadding="0" cellspacing="0" width="99%" bgcolor="#EFEFEF">
												<tr>
													<td>
											<table border="0" cellpadding="4" cellspacing="4" width="100%">
												<tr>
													<td>Apabila DC anda atau 
													leader mengadakan suatu 
													kegiatan, anda dapat 
													mengirimkan liputannya ke 
													redaksi HWI untuk dapat 
													ditayangkan di web HWI. 
													Silahkan kirimkan liputan 
													anda ke
													<a href="mailto:redaksi@healthwealthint.com">
													redaksi@healthwealthint.com</a> 
													dengan dilampiri beberapa 
													foto liputan.<br>
													Terima kasih.</td>
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
						<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top">
								<div align="right">
									<table border="0" cellpadding="0" cellspacing="0" width="99%">
										<tr>
											<td valign="top">
											<table><tr><td valign="top">
											
											
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
										<td valign="top">
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td width="22">
												&nbsp;</td>
												<td background="images/b2_komen.gif" width="100%">
												&nbsp;</td>
												<td width="25">
												&nbsp;</td>
											</tr>
										</table>
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td valign="top" width="16" background="images/b4_komen.gif">
												&nbsp;</td>
												<td valign="top" bgcolor="#FFFFFF" width="100%">
												
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td valign="top">
<form name="theform" method="post" action="add_mykomen.asp" onSubmit="return formCheck(this)">
<input type="hidden" name="id" value="<%=noid%>">	
<input type="hidden" name="tipe" value="liputan">
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td valign="top" bgcolor="#FFFFCE">
				<table border="0" cellpadding="4" cellspacing="4" width="100%" style="text-align: justify">
					<tr>
						<td valign="top">Apabila anda ingin memberikan komentar 
						mengenai kegiatan atau acara diatas, silahkan isi form 
						dibawah ini. Anda
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
				<table border="0" cellpadding="0" cellspacing="0" width="100%" height="226">
					<tr>
						<td>Distributor Id.</td>
						<td width="13" align="center">:</td>
						<td width="270">
							<font size="1">
							<input type="text" name="membid" readonly="T" onKeyDown="if(event.keyCode==13) event.keyCode=9;" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt" size="10" value="<%=manuk%>"></font></td>
					</tr>
					<tr>
						<td height="28">Nama Lengkap</td>
						<td width="13" align="center" height="28">:</td>
						<td width="270" height="28">
							<font size="1">
							<input type="text" name="nama" readonly="T" onKeyDown="if(event.keyCode==13) event.keyCode=9;" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt" size="17" value="<%=nama_log%>"></font></td>
					</tr>
					<tr>
						<td valign="top">Komentar</td>
						<td width="13" align="center" valign="top">:</td>
						<td width="270">
							<font size="1">
							<textarea rows="8" name="deskripsi" onKeyDown=HitungKar(this.form.deskripsi) onKeyUp=HitungKar(this.form.deskripsi) cols="30" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt"></textarea></font></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td width="13" align="center">&nbsp;</td>
						<td width="270">
													<table border="0" cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td width="82" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
															<font color="#FF0000" face="Verdana" size="1">
															<i>Mak 250 char</i></font></td>
															<td width="4" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
															<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
														<font size="1">
														<input type="text" readony="T" name="sisas" readonly="T" style="font-family: Verdana; border: 1px solid #808080; color:#FF0000; font-size:8pt" size="3" value="250"></font></td>
														</tr>
													</table>
															</td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td width="13" align="center">&nbsp;</td>
						<td width="270"><font size="1">
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
												&nbsp;</td>
											</tr>
										</table>
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td width="33">
												&nbsp;</td>
												<td background="images/b7_komen.gif" width="100%">
												&nbsp;</td>
												<td width="22">
												&nbsp;</td>
											</tr>
										</table>
										</td>
												</tr>
												
											</table>
											</td><td width="250"><table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top">
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td width="22">
												&nbsp;</td>
												<td background="images/b2_komen.gif" width="100%">
												&nbsp;</td>
												<td width="25">
												&nbsp;</td>
											</tr>
										</table>
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td valign="top" width="16" background="images/b4_komen.gif">
												&nbsp;</td>
												<td valign="top" bgcolor="#FFFFFF" width="100%">
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td height="25" bgcolor="#D5EAFF">
														<p align="center">
														<font color="#FF0000"><b>
														KOMENTAR PEMBACA</b></font></td>
													</tr>
													<tr>
														<td valign="top">
		<iframe id="datamain" src="pg_view_komen_liputan.asp?id=<%=noid%>&page=<%=pg+1%>&sort=<%=sort%>&pgview=<%=bg%>&tipe_sumber=liputan" width="100%" height="265" marginheight="0" hspace="0" vspace="0" frameborder="0" scrolling="yes" name="I1"></iframe>
		
														</td>
													</tr>
												</table>
												</td>
												<td valign="top" background="images/b5_komen.gif" width="17">
												&nbsp;</td>
											</tr>
										</table>
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td width="33">
												&nbsp;</td>
												<td background="images/b7_komen.gif" width="100%">
												&nbsp;</td>
												<td width="22">
												&nbsp;</td>
											</tr>
										</table>
										</td>
									</tr>
									<tr>
										<td valign="top">&nbsp;</td>
									</tr>
									</table></td></tr></table>
											
											
											</td>
												<tr>
													<td>&nbsp;Ditemukan <b>
													<font color="#FF0000"><%=formatnumber(xas,0)%></font></b> 
													liputan kegiatan lainnya<b>
													</td>
												</tr>											
										</tr>
										<tr>
											<td valign="top">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
														<td valign="top">
<%
intHowManyCharw = 40
rs.Open "SELECT * FROM liputan WHERE sta like '"&akt&"' and id <> '"&noid&"' order by tgl desc limit "&lim&"",conn
if rs.bof then %>

									<table border="0" cellspacing="1" width="100%" id="table14" style="border-collapse: collapse" bordercolor="#808080">
										<tr>
											<td width="100%" align="center" valign="middle" height="40" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
													<font face="Verdana" size="2">
													<u>Belum ada arsip liputan kegiatan</u></font></td>
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
sdesk_liputan = rs("deskripsi")
If len(sdesk_liputan) > intHowManyCharw then
	singkat_liputan = left(decodeString(sdesk_liputan),intHowManyCharw) & "  ...........&nbsp;"
else
	singkat_liputan = sdesk_liputan
End If
%>														
															<tr>
																<td width="21" align="center" valign="top" bgcolor="#FFFFCE">
																<img border="0" src="images/bul_green.gif" width="10" height="11"></td>
																<td valign="top" bgcolor="#FFFFCE">
																<table border="0" cellpadding="0" cellspacing="0" width="96%">
																	<tr>
																		<td valign="top">
																			<b><a target="_top" href="baca_liputan.asp?id=<%=rs("id")%>"><font color="#000000"><%=rs("judul")%></font></a></b>, <%=singkat_liputan%>																		
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
	<a href="baca_liputan.asp?id=<%=noid%>&sort=<%=sort%>&page=<%=kembali%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=kembali-1%>&nexts=<%=ke+1%>" class="prevnext">
	<%end if%>
		« previous</a></li>	
	<% 
	end if
	if ke < y+1 then		
	if pg+1 = ke then 
	saatini = ke
	%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="baca_liputan.asp?id=<%=noid%>&sort=<%=sort%>&page=<%=ke%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" class="currentpage"><%=formatnumber(ke,0)%></a></li>
	<%else%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px">
	<a href="baca_liputan.asp?id=<%=noid%>&sort=<%=sort%>&page=<%=ke%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" style="text-decoration: none; color: #2e6ab1; border: 1px solid #9aafe5; padding-left: 5px; padding-right: 5px; padding-top: 0; padding-bottom: 0"><%=formatnumber(ke,0)%></a></li>
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
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="baca_liputan.asp?id=<%=noid%>&sort=<%=sort%>&page=<%=saatini+1%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=saatini%>&nexts=<%=saatini+1%>" class="prevnext">
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
</table>
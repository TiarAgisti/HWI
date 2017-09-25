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
session("asal") = "kodeetik.asp"
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Kode Etik dan Peraturan Perusahaan PT. Health Wealth International">
   <meta name="keywords" content="kode etik,peraturan,rule,agreement,health wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Kode Etik dan Peraturan Perusahaan</TITLE>
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
        
        <table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
	<tr>
															<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
															<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<p align="center">
																	<b>
																	<font size="6" color="#000000">
																	CROWN 
																	AMBASSADOR</font></b></td>
																</tr>
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
																		<tr>
																			<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<p align="center">
																			&nbsp;<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/01%20Crown%20Ambasador/Yudhisgita%20William%20Purnomo.JPG" width="234" height="239"></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F"><img border="0" src="images/peringkat/01%20Crown%20Ambasador/Ferdinand.JPG" width="234" height="239"></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<font color="#000000" size="2">
																	<b>YUDISGITA 
																	WILLIAM 
																	PURNOMO</b></font></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<font color="#000000" size="2">
																	<b>FERDINAND</b></font></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" height="240" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/peringkat/01%20Crown%20Ambasador/Michel%20Krisnawan.JPG" width="234" height="239"></td>
																					<td width="50%" valign="top" align="center" height="240" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/peringkat/01%20Crown%20Ambasador/David%20Budiarto%20Laydrus.JPG" width="234" height="239"></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000" size="2">
																			MICHEL CHRISNAWAN</font></b></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000" size="2">
																			DAVID 
																			BUDIHARTO 
																			LAYDRUS</font></b></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/peringkat/01%20Crown%20Ambasador/Mardian.JPG" width="234" height="239"></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/peringkat/01%20Crown%20Ambasador/Indah%20Carolina.JPG" width="234" height="239"></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<font color="#000000" size="2">
																	<b>MARDIAN</b></font></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<b>
																	<font size="2" color="#000000">
																	INDAH 
																	CAROLINA 
																	TJAHYADI</font></b></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/peringkat/01%20Crown%20Ambasador/Thomas%20Chandra.JPG" width="234" height="239"></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/peringkat/01%20Crown%20Ambasador/Natanael.JPG" width="234" height="239"></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<b>
																	<font size="2" color="#000000">
																	THOMAS 
																	CHANDRA</font></b></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<b>
																	<font color="#000000" size="2">
																	NATANAEL 
																	LEONO</font></b></td>
																				</tr>
																			<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/HARRIS CHANDRA LIMINDRA - DOUBLE DIAMOND.JPG" width="234" height="239"></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/hall_of_fame/crown_erna.jpg" width="234" height="239"></td>
																				</tr>
																				<tr>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			HARIS
																			CHANDRA LIMINDRA</b></font></td>
																					<td width="50%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			ERNAWATI 
																			NINGSIH</font></b></td>
																				</tr>
																			</table>
																			</td>
																		</tr>
																		<tr>
																			<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<p align="center">
																	&nbsp;</td>
																		</tr>
																	</table>
																	</td>
																</tr>
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																</tr>
															</table>
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<p align="center">
																	<b>
																	<font size="6" color="#000000">
																	CROWN</font></b></td>
																</tr>
															</table>
															<table border="0" cellspacing="1" width="100%">
																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/03%20Double%20Diamond/Samsuto.JPG" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/hall_of_fame/c_heru.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/hall_of_fame/c_danielp.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/hall_of_fame/c_porfi.jpg" width="150" height="139"></td>
																</tr>
																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			SAMSUTO</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			HERU 
																			WIBISONO</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			DANIEL 
																			PANTJADJJA</font></b></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">PORFIRIUS 
																			PELA</font></b>&nbsp;&nbsp;</td>
																</tr>
																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<img border="0" src="images/hall_of_fame/c_agusbudi.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/c_julianto.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/IRWAN AKTAVIANUS.JPG" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/Heny Purnawaty.jpg" width="150" height="139"></td>
																</tr>
																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			AGUS 
																			BUDI 
																			MAISANTO</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			YULIANTO</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			IRWAN 
																			AKTAVIANUS</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			HENY 
																			PURNAWATY</b></font></td>
																</tr>
																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/aldo.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/03%20Double%20Diamond/Hendra.JPG" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Tommy%20Liputra.JPG" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/Nurunnu Lestari - diamond - 1096113.JPG" width="150" height="139"></td>
																</tr>
																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">ALDO 
																			PRATAMA 
																			PURNOMO</font></b></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			HENDRA</font></b></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			TOMMY 
																			LIPUTRA</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			NURANNA 
																			LESTARI</b></font></td>
																</tr>

																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																</tr>
															<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/chenny lim 1896119 diamond.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/stevanus.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/wisnu setiadi aryanto  diamond.jpg" width="150" height="139"></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																</tr>
																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			CHENNY LIM</font></b></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			STEVANUS 
																			ARYANTO</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			WISNU 
																			SETIADI 
																			WIJAYA</b></font></td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																</tr>

																<tr>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																	<td valign="top" align="center" width="200" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	&nbsp;</td>
																</tr>

																
															</table>
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																</tr>
															</table>
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<p align="center">
																	<b>
																	<font size="5" color="#000000">
																	DOUBLE 
																	DIAMOND</font></b></td>
																</tr>
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<table border="0" cellspacing="1" width="100%">
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/dd_eta.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/03%20Double%20Diamond/Lie%20Daniel%20Andries.JPG" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/9. Diamond Ana Farida.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/SUWARNO-AMD-(DOUBLE-DIAMOND.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/Nena Puspita Sari 1108384 DOUBLEDIAMOND.jpg" width="125" height="127"></td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			MARIESTA EUNIKE</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			LIE 
																			DANIEL 
																			ANDRIES</font></b></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			ANA 
																			FARIDA</font></b></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			SUWARNO</font></b></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			NENA PUSPITA SARI</b></font></td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																		</tr>																		
																		<tr>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			<img border="0" src="images/hall_of_fame/1123460 saraswaty dhian utami Double diamond.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			<img border="0" src="images/hall_of_fame/dd_yulianty.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			<img border="0" src="images/peringkat/03%20Double%20Diamond/Muh%20Alfitrah%20Alpriandi.JPG" width="125" height="127"></td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			<img border="0" src="images/hall_of_fame/dd_rachael.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			<img border="0" src="images/hall_of_fame/Dewi Kurnia Sari.jpg" width="125" height="127"></td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			SARASWATY 
																			DHIAN 
																			UTAMI </b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			YULIANTY</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			MUH 
																			ALFITRAH 
																			APRIANDI</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			RACHAEL</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			DEWI 
																			KURNIA 
																			SARI</b></font></td>
																		</tr>	
																		<tr>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			&nbsp;</td>
																			<td width="20%" valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F" align="center">
																			&nbsp;</td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/03%20Double%20Diamond/Bobby%20Surya%20Winardi.JPG" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/CHRISTIN%20NATALIA%20-%20DIAMOND.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/Diamond Ummul Husna 1138612.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/Naufal - Diamond.JPG" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/CHARLIANTO  1897229  DIAMOND.jpg" width="125" height="127"></td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			BOBBY 
																			SURYA
																			<br>
																			WINARDI</font></b></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			CHRISTIN 
																			NATALIA</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			UMMUL 
																			HUSNA</b></font>&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			NAUFAL 
																			ADI<br>
																			NUGRAHA</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			CHARLIANTO</b></font></td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/nitra.JPG" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/Siti Musyarofah.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/HERLIANA MAITA RAKHMAN   1904279   DIAMOND.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/Diamond Siska Andriani.jpg" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/Fenisya.JPG" width="125" height="127"></td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			NITRA 
																			TRIYOGI</b></font>&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			SITI MUSYAROFAH</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			HERLIANA MAITA RAKHMAN</font></b></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			SISKA 
																			ANDRIANI</font></b></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			FENISYA</font></b></td>
																		</tr>
																		
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/tati.JPG" width="125" height="127"></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																		</tr>
																		<tr>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			TATI 
																			NINGSIH</b></font></td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="20%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																		</tr>
																		
																		</table>
																	</td>
																</tr>
																
															</table>
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<p align="center">
																	<b>
																	<font size="4" color="#000000">
																	DIAMOND</font></b></td>
																</tr>
																<tr>
																	<td style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																	<table border="0" cellpadding="0" cellspacing="0" width="100%">
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Muchlisin.JPG" width="100" height="96"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/JAMALUDIN.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/d_adekoswara.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/10. Diamond  Murni Hati Dalimunte.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Erwin.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Wibowo%20H.JPG" width="100" height="100"></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			MUCHLISIN<br>
&nbsp;</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			JAMALUDIN</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			ADE 
																			KOESWARA</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;<b><font color="#000000">MURNI 
																			HATI 
																			DALIMUNTE</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			ERWIN</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			WIBOWO 
																			H</b></font></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top"25lign="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/dini ferlia.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Wahyu%20Indra%20H.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/FITRIA%20KUSUMA%20WARDANI%20-%20DIAMOND.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/Willy%20Bosandy%20-%20Diamond%20-%201096966.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/Endra Saputra - Diamond.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/Alvian Ciptono - Diamond.JPG" width="100" height="100"></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;<font color="#000000"><b>DINI 
																			FERLIA</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			WAHYU 
																			INDRA 
																			H</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			FITRIA 
																			KUSUMA 
																			WARDANI</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			WILLY 
																			GOSANDY</b></font>&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			ENDRA 
																			SAPUTRA</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			ALVIAN 
																			CIPTONO</b></font></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/1148917STEVENHALIM.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/Hani Lasmanawati DIAMOND 1160701.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/Retty Destari.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/1079866 vendra gunawan.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Stehanie%20Christin.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/QAMARUZZAMAN DIAMOND.jpg" width="100" height="100"></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			STEVEN 
																			HALIM</b></font></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			HANI 
																			LASMANAWATI</b></font></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			RETTY 
																			DESTARY</font></b></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			VENDRA 
																			GUNAWAN</b></font></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			STEPHANIE<br>
																			CHRISTINE</b></font></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			QAMARUZZAMAN</b></font></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">&nbsp;</td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Deddy%20Supriyono.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Steven.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Fandi.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/hall_of_fame/d-meliyanti.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/12. Diamond Septi Nur Azizah.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/04%20Diamond/Melly%20V.JPG" width="100" height="100"></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			DEDDY
																			<br>
																			SUPRIYONO</b></font></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			STEVEN</b></font>&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			FANDI</b></font>&nbsp;</td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			MELIYANTI</font></b></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			SEPTI 
																			NUR 
																			AZIZAH</font></b><font color="#000000"><b>&nbsp;</b></font></td>
																			<td width="16%" valign="top" align="center" height="20" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			MELLY 
																			V</b></font></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/peringkat/Andy Tanjaya 1102037  diamond.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/idham arifa nugraha.JPG" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/SUCI NOVI HANDAYANI.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/15. Diamond Lita Sari Fitriani.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/14. Diamond Yusfi Kurniawati.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/CHRISTOPHER.jpg" width="100" height="100"></td>
																		</tr>

																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			ANDY 
																			TANJAYA</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			IDHAM 
																			ARIF 
																			NUGRAHA</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			SUCI 
																			NOVI 
																			HANDAYANI</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			LITA 
																			SARI 
																			FRITRIANI</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			YUSFI 
																			KURNIAWATI</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			CHRISTOPHER</font></b></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/8. Diamond Miwa Hari Nurani.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/wenda.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/6. Diamond Deby Elda.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/5. Diamond Yudhi Permana.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/marcel.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/warman.jpg" width="100" height="100"></td>
																		</tr>

																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			MIWA 
																			HARI 
																			NURANI</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			WENDA 
																			SUHARTI 
																			BUDIONO</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			DEBY 
																			ELDA</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<b>
																			<font color="#000000">
																			YUDHI 
																			PERMANA</font></b></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			MARCEL 
																			FERLENDI</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			WARMAN</b></font></td>
																		</tr>
																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/vivian.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<img border="0" src="images/foto/indraliani.jpg" width="100" height="100"></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																		</tr>

																		<tr>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			VIVIA 
																			MARCELLA</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			<font color="#000000">
																			<b>
																			INDRALIANI DJOHAN</b></font></td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																			<td width="16%" valign="top" align="center" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			&nbsp;</td>
																		</tr>																		
																		
																</table>
															</td>
														</tr>
	<tr>
															<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
															&nbsp;</td>
														</tr>
	<tr>
		<td>&nbsp;</td>
	</tr>
</table>

										</td>
										<td valign="top" background="images/b5.gif" width="9">
										&nbsp;</td>
									</tr>
								</table>
        
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
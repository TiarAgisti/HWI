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
session("menus") = "quadroplan"
session("asal") = "pointreward.asp"
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Point Reward Health Wealth International">
   <meta name="keywords" content="point reward, reward,umroh, onh plus, haji,ibadah haji, wisata religi, umrah,health wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Point Reward</TITLE>
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
												<img border="0" src="images/text_pointreward.gif" width="471" height="63"></td>
											</tr>
											<tr>
												<td valign="top">
												<table border="0" cellpadding="6" cellspacing="4" width="100%">
													<tr>
														<td bgcolor="#FFEFDF">
														<p align="center">Satu 
														lagi persembahan dari 
														HWI sebagai bukti 
														langkah nyata komitmen 
														kami kepada seluruh 
														distributor HWI dalam 
														memberikan penghargaan 
														kepada setiap 
														distributor HWI yang 
														serius menjalankan 
														bisnis HWI, </td>
													</tr>
												</table>
												</td>
											</tr>
											<tr>
												<td valign="top">&nbsp;
												</td>
											</tr>
											<tr>
												<td valign="top">
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td valign="top">
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td><u><b>
																BAGAIMANA 
																MEMPEROLEH POINT 
																REWARD ?</b></u></td>
															</tr>
															<tr>
																<td>
																<table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: justify">
																	<tr>
																		<td width="26" valign="top" align="center">
																		1.</td>
																		<td valign="top">
																		Setiap 
																		mensponsori 
																		distributor 
																		baru 
																		dengan 
																		paket 
																		pendaftaran 
																		Fast 
																		Track 
																		akan 
																		mendapatkan 
																		1 point 
																		reward.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		2.</td>
																		<td valign="top">
																		Setiap 
																		distributor 
																		didalam 
																		jaringan 
																		anda 
																		yang 
																		tutup 
																		point 
																		(200 PV) 
																		maka 
																		anda 
																		mendapatkan 
																		1 point 
																		reward 
																		berlaku 
																		kelipatan 
																		untuk 
																		setiap 
																		penambahan 
																		200 PV.</td>
																	</tr>
																	</table>
																</td>
															</tr>
															<tr>
																<td>&nbsp;</td>
															</tr>
															<tr>
																<td><u><b>
																KETENTUAN DAN 
																SYARAT</b></u></td>
															</tr>
															<tr>
																<td>
																<table border="0" cellpadding="0" cellspacing="0" width="100%" style="text-align: justify">
																	<tr>
																		<td width="26" valign="top" align="center">
																		1.</td>
																		<td valign="top">
																		Setiap 
																		tahun 
																		akan 
																		dilakukan 
																		evaluasi 
																		untuk 
																		hadiah 
																		dan 
																		program 
																		point 
																		reward 
																		yang 
																		dijalankan.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		2.</td>
																		<td valign="top">
																		Apabila 
																		anda 
																		tidak 
																		melakukan 
																		tutup 
																		point, 
																		maka 
																		point 
																		reward 
																		yang 
																		anda 
																		peroleh 
																		pada 
																		bulan 
																		terhitung 
																		akan 
																		hangus.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		3.</td>
																		<td valign="top">
																		Apabila 
																		anda 
																		tidak 
																		melakukan 
																		tutup 
																		point 3 
																		(tiga) 
																		bulan 
																		berturut-turut, 
																		dan atau 
																		account 
																		suspend, 
																		maka 
																		seluruh 
																		point 
																		reward 
																		anda 
																		akan 
																		hangus.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		4.</td>
																		<td valign="top">
																		Anda 
																		tidak 
																		memperoleh 
																		point 
																		reward 
																		dari 
																		tutup 
																		point 
																		pribadi, 
																		point 
																		reward 
																		berasal 
																		dari 
																		tutup 
																		point 
																		jaringan 
																		anda 
																		atau new 
																		distributor 
																		(fast 
																		track) 
																		didalam 
																		jaringan 
																		anda.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		5.</td>
																		<td valign="top">
																		Point 
																		reward 
																		yang 
																		diklaim 
																		tidak 
																		memberikan 
																		sisa 
																		(flush 
																		out). 
																		Mengulang 
																		dari nol 
																		(0) 
																		untuk 
																		mengklaim 
																		hadiah 
																		point 
																		reward 
																		lainnya.<br>
																		Sebagai 
																		contoh :<br>
																		Saat ini 
																		anda 
																		memiliki 
																		300 
																		point 
																		kiri dan 
																		270 
																		point 
																		kanan 
																		dan anda 
																		melakukan 
																		klaim 
																		notebook. 
																		Maka 
																		anda 
																		tidak 
																		akan 
																		memiliki 
																		sisa 
																		point 
																		kiri 300 
																		- 250 = 
																		50 point 
																		dan sisa 
																		point 
																		kanan 
																		270-250 
																		point = 
																		20 
																		point, 
																		namun 
																		point 
																		kiri dan 
																		kanan 
																		anda 
																		menjadi 
																		0 (tidak 
																		bersisa). 
																		Hal ini 
																		untuk 
																		menyehatkan 
																		sistem 
																		dan 
																		pengaman.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		6.</td>
																		<td valign="top">
																		Hadiah 
																		point 
																		reward 
																		tidak 
																		dapat 
																		diuangkan.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		7.</td>
																		<td valign="top">
																		Klaim 
																		reward 
																		tidak 
																		dapat 
																		dilakukan 
																		selama 
																		point 
																		reward 
																		masih 
																		belum 
																		mencukupi. 
																		Tidak 
																		ada 
																		penambahan 
																		dalam 
																		bentuk 
																		uang 
																		untuk 
																		menutup 
																		kekurangan 
																		point 
																		reward 
																		yang 
																		diklaim.<br>
																		Sebagai 
																		contoh :<br>
																		Saat ini 
																		anda 
																		memiliki 
																		300 
																		point 
																		kiri dan 
																		240 
																		point 
																		kanan 
																		dan anda 
																		ingin 
																		melakukan 
																		klaim 
																		notebook. 
																		Berhubung 
																		point 
																		kanan 
																		anda 
																		kurang 
																		10 
																		point, 
																		maka 
																		anda 
																		berencana 
																		untuk 
																		mengklaim 
																		notebook 
																		dan 
																		menambah 
																		uang 
																		tunai 
																		untuk 
																		memperoleh 
																		notebook. 
																		Hal 
																		seperti 
																		itu 
																		tidak 
																		diperkenankan.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		8.</td>
																		<td valign="top">
																		Berlaku 
																		untuk 
																		seluruh 
																		tipe 
																		distributor 
																		(regular 
																		maupun 
																		premium, 
																		fast 
																		track).</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">
																		9.</td>
																		<td valign="top">
																		Daftar 
																		point 
																		reward 
																		anda 
																		dapat 
																		anda 
																		simak di 
																		control 
																		panel 
																		distributor 
																		dan 
																		diupdate 
																		setiap 
																		kali 
																		selesai 
																		closing 
																		periode.</td>
																	</tr>
																	<tr>
																		<td width="26" valign="top" align="center">&nbsp;
																		</td>
																		<td valign="top">&nbsp;</td>
																	</tr>
																</table>
																</td>
															</tr>
															<tr>
																<td>&nbsp;</td>
															</tr>
														</table>
														</td>
														<td width="290" valign="top">
														<div align="right">
															<table border="0" cellpadding="0" cellspacing="0" width="98%">
																<tr>
																	<td valign="top">
																	<table border="0" cellpadding="0" cellspacing="0" width="100%">
																		<tr>
																			<td valign="top">
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td>
																					<p align="center">&nbsp;</td>
																				</tr>
																				<tr>
																					<td><img border="0" src="images/ICO_btc.gif" width="101" height="110"></td>
																				</tr>
																			</table>
																			</td>
																			<td width="163" valign="top">
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td><font color="#FF0000"><b>SEMINAR BTC</b></font></td>
																				</tr>
																				<tr>
																					<td>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="45">Kiri</td>
																							<td width="10">:</td>
																							<td>80 point</td>
																						</tr>
																						<tr>
																							<td width="45">Kanan</td>
																							<td width="10">:</td>
																							<td>80 point</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																					</table>
																					</td>
																				</tr>
																			</table>
																			</td>
																		</tr>
																		<tr>
																			<td valign="top">&nbsp;
																			</td>
																			<td width="163" valign="top">&nbsp;
																			</td>
																		</tr>
																		<tr>
																			<td valign="top">&nbsp;
																			</td>
																			<td width="163" valign="top">
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td><font color="#FF0000"><b>TOUR KE MALAYSIA</b></font></td>
																				</tr>
																				<tr>
																					<td>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="45">Kiri</td>
																							<td width="10">:</td>
																							<td>500 point</td>
																						</tr>
																						<tr>
																							<td width="45">Kanan</td>
																							<td width="10">:</td>
																							<td>500 point</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																					</table>
																					</td>
																				</tr>
																			</table>
																			</td>
																		</tr>
																		<tr>
																			<td valign="top">&nbsp;
																			</td>
																			<td width="163" valign="top">&nbsp;
																			</td>
																		</tr>
																		<tr>
																			<td valign="top">&nbsp;
																			</td>
																			<td width="163" valign="top">
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td><font color="#FF0000"><b>UMROH / TOUR KOREA</b></font></td>
																				</tr>
																				<tr>
																					<td>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="45">Kiri</td>
																							<td width="10">:</td>
																							<td>2.500 point</td>
																						</tr>
																						<tr>
																							<td width="45">Kanan</td>
																							<td width="10">:</td>
																							<td>2.500 point</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																					</table>
																					</td>
																				</tr>
																			</table>
																			</td>
																		</tr>
																		<tr>
																			<td valign="top">&nbsp;
																			</td>
																			<td width="163" valign="top">&nbsp;
																			</td>
																		</tr>
																		<tr>
																			<td valign="top">&nbsp;
																			</td>
																			<td width="163" valign="top">
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td><font color="#FF0000"><b>LOGAM MULIA</b></font></td>
																				</tr>
																				<tr>
																					<td>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="45">Kiri</td>
																							<td width="10">:</td>
																							<td>10.000 point</td>
																						</tr>
																						<tr>
																							<td width="45">Kanan</td>
																							<td width="10">:</td>
																							<td>10.000 point</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																						<tr>
																							<td width="45">&nbsp;</td>
																							<td width="10">&nbsp;</td>
																							<td>&nbsp;</td>
																						</tr>
																					</table>
																					</td>
																				</tr>
																			</table>
																			</td>
																		</tr>
																		<tr>
																			<td valign="top">&nbsp;
																			</td>
																			<td width="163" valign="top">&nbsp;
																			</td>
																		</tr>
																	</table>
																	</td>
																</tr>
																<tr>
																	<td valign="top">
																	<i>* gambar 
																	hanya 
																	sebagai 
																	ilustrasi</i></td>
																</tr>
															</table>
														</div>
														</td>
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
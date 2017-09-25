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
session("menus") = "home"

error1 = session("errorrem1")
error2 = session("errorrem2")
mesej = session("mesejrem")
error2 = session("errorrem2")
mesejs = session("mesejrems")

session("errorrem1") = ""
session("errorrem2") = ""
session("mesejrem") = ""
session("mesejrems") = ""
session("asal") = "password_reminder.asp"
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
<TITLE>Health Wealth International</TITLE>
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
function formChek(form) {
if (form.noid.value == "")
{
 alert("Anda belum mengisikan nomor Id. Distributor anda");
return false;}
}
// -->
</script>

<script language="JavaScript">
<!--
function formCheck(form) {
if (form.uid.value == "")
{
 alert("Mohon isikan nomor id distributor anda");
return false;}

if (form.nama.value.length == "")
{
 alert("Mohon isikan nama anda sesuai data dalam informasi kedistributor-an anda");
return false;}

if (form.noktp.value == "")
{
 alert("Mohon isikan nomor identitas pengenal diri anda sesuai data dalam informasi kedistributor-an anda");
return false;}

if (form.sponsor.value == "")
{
 alert("Mohon isikan nomor id distributor sponsor anda");
return false;}

if (form.notelp.value.length == "")
{
 alert("Mohon isikan nomor telepon anda untuk dapat kami hubungi");
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
												<div align="center">
													<table border="0" cellpadding="0" cellspacing="0" width="99%">
														<tr>
															<td>
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
																	<td valign="top" width="10" background="images/b4.gif">
																	&nbsp;</td>
																	<td valign="top" width="100%">
																	<table border="0" cellpadding="0" cellspacing="0" width="100%">
																		<tr>
																			<td valign="top">
<div align="center">
	<table border="0" cellpadding="0" cellspacing="0" width="98%">
		<tr>
			<td valign="middle" bgcolor="#616161" height="20">
			<p align="center"><b><font color="#FFFFFF" size="2">SISTEM PENGINGAT 
			PASSWORD MELALUI EMAIL</font></b></td>
		</tr>
		<tr>
			<td valign="top" bgcolor="#FFFFCE">
			<table border="0" cellpadding="4" cellspacing="4" width="100%">
				<tr>
					<td>Apabila anda lupa password login anda, apabila anda 
					sudah mengisikan alamat email anda yang valid didalam 
					informasi distributor anda, maka anda dapat meminta 
					pengiriman password login anda melalui proses dibawah ini. 
					Sistem kami akan mengirimkan password login anda ke alamat email 
					yang ada pada informasi distributor anda. <br>
					<br>
					Apabila anda tidak memiliki alamat email yang valid atau tidak 
					dapat menyebutkan nomor id distributor anda, anda dapat 
					mencoba form permintaan password ke kantor pusat dibawah.</td>
				</tr>
			</table>
			</td>
		</tr>
		<tr>
			<td valign="top">&nbsp;</td>
		</tr>
		<tr>
			<td valign="top">
			<table border="1" cellspacing="1" width="100%" style="border-collapse: collapse" bordercolor="#DDDDDD">
				<tr>
					<td>
					<div align="center">
						<table border="0" cellpadding="0" cellspacing="0" width="98%">
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>
								<form name="form1" method="post" action="sentpassword.asp" onSubmit="return formChek(this)">		
								<table border="0" cellspacing="1" width="100%">
									<tr>
										<td width="135" valign="top">
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td>No. Id. Distributor</td>
											</tr>
											<tr>
												<td></td>
											</tr>
										</table>
										</td>
										<td valign="top">
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td>
										<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="9" --><input type="text" name="noid" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="12" maxlength="9"></td>
											</tr>
											<tr>
												<td><font color="#FF0000"><%=error1%></font></td>
											</tr>
										</table>
										</td>
									</tr>
									<tr>
										<td width="135">&nbsp;</td>
										<td>
										<input type="submit" name="btremind" value="Kirim Password Sekarang" style="font-size: 8pt; font-family: Verdana"></td>
										</form>
									</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
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
		<%if mesej <> "" then %>
		<tr>
			<td valign="top">
			<p align="center"><font color="#FF0000"><b><%=mesej%></b></font></td>
		</tr>
		<tr>
			<td valign="top">&nbsp;</td>
		</tr>
		<%end if%>
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
																	<td width="20">
																	&nbsp;</td>
																</tr>
															</table>
															</td>
														</tr>
													</table>
												</div>
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
												<div align="center">
													<table border="0" cellpadding="0" cellspacing="0" width="99%">
														<tr>
															<td>
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
																	<td valign="top" width="10" background="images/b4.gif">
																	&nbsp;</td>
																	<td valign="top" width="100%">
																	<table border="0" cellpadding="0" cellspacing="0" width="100%">
																		<tr>
																			<td valign="top">
<div align="center">
	<table border="0" cellpadding="0" cellspacing="0" width="98%">
		<tr>
			<td valign="middle" bgcolor="#616161" height="20">
			<p align="center"><font size="2" color="#FFFFFF"><b>FORM PERMINTAAN 
			PASSWORD KE KANTOR PUSAT</b></font></td>
		</tr>
		<tr>
			<td valign="top" bgcolor="#D5EAFF">
			<table border="0" cellpadding="4" cellspacing="4" width="100%">
				<tr>
					<td>Anda dapat mengisi form dibawah ini untuk meminta kantor 
					pusat agar mengirimkan password login kepada anda. Anda 
					harus memasukan dengan benar <font color="#FF0000"><b>nomor 
					id distributor</b></font>, <b><font color="#FF0000">nama 
					lengkap, nomor identitas diri anda</font></b> dan <b>
					<font color="#FF0000">sponsor anda</font></b> sebagai 
					verifikasi untuk membuka data. Staff kantor pusat akan 
					segera menghubungi anda untuk memberi tahukan informasi 
					mengenai password login anda, untuk itu mohon isikan nomor 
					telepon atau alamat email anda yang dapat dihubungi.<br>
					<br>
					Sebelum anda dapat memverifikasi data anda melalui form 
					dibawah ini, maka sistem tidak akan mengirimkan permintaan 
					anda ke kantor pusat.</td>
				</tr>
			</table>
			</td>
		</tr>
		<tr>
			<td valign="top">&nbsp;</td>
		</tr>
		<tr>
			<td valign="top">
			<table border="1" cellspacing="1" width="100%" style="border-collapse: collapse" bordercolor="#DDDDDD">
				<tr>
					<td>
					<div align="center">
						<table border="0" cellpadding="0" cellspacing="0" width="98%">
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td valign="top">
								<form name="form2" method="post" action="requestpassword.asp" onSubmit="return formCheck(this)">		
								<table border="0" cellspacing="1" width="100%">
									<tr>
										<td width="122">No. Id. Distributor *</td>
										<td width="10">:</td>
										<td>
										&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="9" --><input type="text" name="uid" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="12" maxlength="9"></td>
									</tr>
									<tr>
										<td width="122">Nama Lengkap *</td>
										<td width="10">:</td>
										<td>
										&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="45" --><input type="text" name="nama" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="24" maxlength="45"></td>
									</tr>
									<tr>
										<td width="122">No. Identitas Diri *</td>
										<td width="10">:</td>
										<td>
										&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="50" --><input type="text" name="noktp" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="24" maxlength="50"></td>
									</tr>
									<tr>
										<td width="122">Sponsor Anda *</td>
										<td width="10">:</td>
										<td>
										&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="9" --><input type="text" name="sponsor" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="12" maxlength="9"></td>
									</tr>
									<tr>
										<td width="122">No. Telepon Kontak</td>
										<td width="10">:</td>
										<td>
										&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="25" --><input type="text" name="notelp" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="20" maxlength="25"></td>
									</tr>
									<tr>
										<td width="122">Alamat E-Mail</td>
										<td width="10">:</td>
										<td>
										&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="25" --><input type="text" name="email" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="34" maxlength="25"></td>
									</tr>
									<tr>
										<td width="122">&nbsp;</td>
										<td width="10">&nbsp;</td>
										<td>
										<input type="submit" name="btremind0" value="Kirim Password Sekarang" style="font-size: 8pt; font-family: Verdana"></td>
									</form>	
									</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
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
		<%if mesejs <> "" then %>
		<tr>
			<td valign="top">
			<p align="center"><font color="#FF0000"><b><%=mesejs%></b></font></td>
		</tr>
		<tr>
			<td valign="top">&nbsp;</td>
		</tr>
		<%end if%>
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
																	<td width="20">
																	&nbsp;</td>
																</tr>
															</table>
															</td>
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
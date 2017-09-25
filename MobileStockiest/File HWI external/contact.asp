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

session("asal") = "contact.asp"
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

<script language="JavaScript">
<!-- Begin
var submitcount=0;

function formCheck(form) {
if (form.namadis.value == "")
{
 alert("Mohon isikan nama lengkap anda");
return false;}

if (form.notelp.value == "")
{
 alert("Mohon isikan nomor telepon kontak anda");
return false;}

if (form.email.value == "")
{
 alert("Mohon isikan alamat e-mail anda");
return false;}

if (form.subyek.value == "")
{
 alert("Mohon isikan subyek kontak anda");
return false;}

if (form.detail.value == "")
{
 alert("Mohon isikan detail pesan kontak anda");
return false;}


if (confirm("Silahkan cek ulang apa yang telah anda isikan \n\nNo. Id. Distributor : " + form.kdpos.value +".\nNama Anda : "+ form.namadis.value+"\nNo. Telepon : "+ form.notelp.value+"\nEmail : "+ form.email.value+"\nSubyek : "+ form.subyek.value+"\nDetail Pesan : "+ form.detail.value+"\n")) {
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
			<td valign="top">
			<table border="0" cellpadding="0" cellspacing="0" width="100%">
				<tr>
					<td valign="top">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td valign="top"><font color="#000000"><b>
							<font size="3">PT. HEALTH WEALTH INTERNATIONAL</font></b><br>
							<b><font size="2">GRAHA HWI</font></b><br>
							Jl. Tanjung Duren Raya no. 542<br>
							Jakarta Barat - DKI. Jakarta - Indonesia<br>
							Telp. 021-56969998, 56962999<br>
							Facs. 021-56969108<br>
							HotLine : 085211218685<br>
							</font><a href="mailto:support@healthwealthint.com">
							support</a><font color="#000000"><a href="mailto:support@healthwealthint.com">@healthwealthint.com</a><br>
							<a href="http://www.healthwealthint.com">
							http://www.healthwealthint.com</a> <br>
							</font>Kuasa hukum HWI, <a target="_blank" href="http://www.joanandpartners.com">Joan and partner</a></font>							
							</td>
						</tr>
						<tr>
							<td valign="top">&nbsp;</td>
						</tr>
						<tr>
							<td valign="top">&nbsp;</td>
						</tr>
						<tr>
							<td valign="top"><!--#Include File=pg_online_support.asp--></td>
						</tr>
						<tr>
							<td valign="top">&nbsp;</td>
						</tr>
					</table>
					</td>
					<td width="327" valign="top">
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
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
																	<img border="0" src="images/b1.gif" width="19" height="14"></td>
																	<td background="images/b2.gif" width="100%">
																	<img border="0" src="images/b2.gif" width="18" height="14"></td>
																	<td width="21">
																	<img border="0" src="images/b3.gif" width="21" height="14"></td>
																</tr>
															</table>
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr>
																	<td valign="top" width="10" background="images/b4.gif">
																	<img border="0" src="images/b4.gif" width="10" height="16"></td>
																	<td valign="top" width="100%">
																	<table border="0" cellpadding="0" cellspacing="0" width="100%">
																		<tr>
																			<td valign="top">
<div align="center">
	<table border="0" cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td bgcolor="#2E6AB1" height="20">
			<p align="center"><font color="#FFFFFF"><b>WEBMAIL CONTACT FORM</b></font></td>
		</tr>
		<tr>
			<td valign="top">&nbsp;</td>
		</tr>
		<tr>
			<td valign="top">
			<div align="center">
<form name="theform" method="post" action="sentmail.asp" onsubmit="return formCheck(this)">				
				<table border="0" cellspacing="1" width="98%">
					<tr>
						<td width="103">No. Id. Distributor</td>
						<td width="9">:</td>
						<td>					
						<input type="text" name="kdpos" id="kdpos" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080; " size="13" onKeyDown="if(event.keyCode==13) event.keyCode=9;" size="24" value="<%=manuk%>"/></td>
					</tr>
					<tr>
						<td width="103">Nama Anda</td>
						<td width="9">:</td>
						<td>
						<input type="text" name="namadis" id="namadis" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080; " size="25" value="<%=namalog%>"></td>
					</tr>
					<tr>
						<td width="103">No. Telepon</td>
						<td width="9">:</td>
						<td>
														<input type="text" name="notelp" onchange=quadratic1(this.form) size="16" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080; "></td>
					</tr>
					<tr>
						<td width="103">Alamat E-mail</td>
						<td width="9">:</td>
						<td>
														<input type="text" name="email" onchange=quadratic1(this.form) size="26" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080; "></td>
					</tr>
					<tr>
						<td width="103">Subyek</td>
						<td width="9">:</td>
						<td>
														<input type="text" name="subyek" onchange=quadratic1(this.form) size="26" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080; "></td>
					</tr>
					<tr>
						<td width="103">Department Tujuan</td>
						<td width="9">:</td>
						<td>
							<select size="1" name="tujuan" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080">
							<option value="info@healthwealthint.com">General Info
							</option>
							<option value="kris@healthwealthint.com">Operational
							</option>
							<option value="kris@healthwealthint.com">Marketing
							</option>
							<option value="wiyanto_oen@healthwealth.com">Distributor Relation
							</option>
							<option value="adnan@healthwealthint.com">Finance Accounting
							</option>
							</select>
						</td>
					</tr>
					<tr>
						<td width="103">Detail Kontak</td>
						<td width="9">:</td>
						<td>
																	<textarea rows="12" name="detail" cols="26" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080"></textarea></td>
					</tr>
					<tr>
						<td width="103" height="5"></td>
						<td width="9" height="5"></td>
						<td height="5"></td>
					</tr>
					<tr>
						<td width="103">&nbsp;</td>
						<td width="9">&nbsp;</td>
						<td>
																<input type="submit" name="btsub" value="Kirim" style="font-size: 8pt; font-family: Verdana"></td>
					</tr>
				</table>
			</div>
			</td>
		</tr>
		<tr>
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
															<table border="0" cellpadding="0" cellspacing="0" width="100%">
																<tr>
																	<td width="22">
																	<img border="0" src="images/b6.gif" width="22" height="14"></td>
																	<td background="images/b7.gif" width="100%">
																	<img border="0" src="images/b7.gif" width="21" height="14"></td>
																	<td width="20">
																	<img border="0" src="images/b8.gif" width="20" height="14"></td>
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
							</td>
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
		<tr>
			<td valign="top">&nbsp;</td>
		</tr>
	</table>
</div>
																			</td>
																		</tr>
																	</table>
																	</td>
																	<td valign="top" width="9">
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
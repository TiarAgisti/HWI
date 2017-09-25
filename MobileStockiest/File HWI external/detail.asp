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
mesej = session("pesankomen")
session("pesankomen") = ""

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

'idprod = request("kode")
idprod = SafeSQL(ucase(request("kode")))

rs.Open "SELECT kode,nama,keterangan,foto_besar,pv,hd1,hd2,hd3,hk1,hk2,hk3,hk4,brosur1,brosur2 FROM st_barang WHERE sta like '"&sss&"' and kode like '"&idprod&"'",conn
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
		hk4 = rs("hk4")
		brosur1 = rs("brosur1")
		brosur2 = rs("brosur2")
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
if isnull(nilai) = true then
	nilai = 0
else
	nilai = nilai
end if

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

ke = 4
rs.Open "SELECT deskripsi FROM tabdesc WHERE grp like '"&ggg&"' and ket like '"&ke&"'",conn
	if rs.bof then
		area4 = ""
	else		
		area4 = rs("deskripsi")
	end if						
rs.close

if isnull(nilai) = true then
	nilai = 0
else
	nilai = nilai
end if

if nilai = 0 or voteman = 0 then
	testiprod_nil = 0
else
	testiprod_nil = nilai/voteman
end if

session("asal") = "detail.asp?kode="&idprod
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
<TITLE>Health Wealth International :: Detail Produk</TITLE>
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
												<img border="0" src="images/text_detail.gif" width="471" height="63"></td>
											</tr>
											<tr>
												<td valign="top">
																			
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td width="256" valign="top">
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td valign="top">
																							<p align="center"></td>
																						</tr>
																						<tr>
																							<td>
																							<p align="center"><img border="0" src="<%=fotoprd%>"></td>
																						</tr>
																						<tr>
																							<td>&nbsp;
																							</td>
																						</tr>
																						<tr>
																							<td>
																							<table border="0" cellpadding="0" cellspacing="0" width="100%">
																								<tr>
																									<td>
																							<div align="center">
																							<table border="0" cellpadding="0" cellspacing="0" width="60%">
																								<tr>
																									<td width="30%">
																									<p align="center">
																									<%if brosur1 <> "-" or brosur2 <> "-" then %> 
																									<a href="download_version.asp?kode=<%=idprod%>" onClick="NewWindow(this.href,'name','600','780','yes');return false" style="text-decoration: none; color: #31509F"><img border="0" src="images/ico_download_version.gif" width="20" height="20"></a>
																									<%else%>
																									<img border="0" src="images/ico_download_version.gif" width="20" height="20">
																									<%end if%>
																									</td>
																									<td width="30%">
																									<p align="center"><a href="print_version.asp?prod_id=<%=idprod%>" onClick="NewWindow(this.href,'name','780','550','yes');return false" style="text-decoration: none; color: #31509F"><img border="0" src="images/ico_print_version.gif" width="20" height="20"></a></td>
																									<td width="40%">
																									<p align="center"><a href="sentmail_version.asp?prod_id=<%=idprod%>" onClick="NewWindow(this.href,'name','750','450','yes');return false" style="text-decoration: none; color: #31509F"><img border="0" src="images/ico_mail_version.gif" width="20" height="20"></a></td>
																								</tr>
																								<tr>
																									<td width="30%">
																									<%if brosur1 <> "-" or brosur2 <> "-" then %>
																									<a href="download_version.asp?kode=<%=idprod%>" onClick="NewWindow(this.href,'name','600','780','yes');return false" style="text-decoration: none; color: #31509F">Download</a>
																									<%else%>
																									Download
																									<%end if%>
																									</td>
																									<td width="30%">
																									<p align="center"><a href="print_version.asp?prod_id=<%=idprod%>" onClick="NewWindow(this.href,'name','780','550','yes');return false" style="text-decoration: none; color: #31509F">Print</a></td>
																									<td width="40%">
																									<p align="center"><a href="sentmail_version.asp?prod_id=<%=idprod%>" onClick="NewWindow(this.href,'name','750','450','yes');return false" style="text-decoration: none; color: #31509F">Kirim E-mail</a></td>
																								</tr>
																							</table>
																									</div>
																									</td>
																								</tr>
																							</table>
																							</td>
																						</tr>
																					</table>
																					<p align="center"><br></td>
																					<td valign="top"><b><font size="4" color="#3399FF">
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="100%"><b><font size="4" color="#3399FF"><%=namaprd%>&nbsp;( <%=idprod%> )</font></b></i><br>
																					<i><font color="#FF0000" size="2">
																					<b>pv : <%=formatnumber(pv,2)%></b></font></i><br></td>
																						</tr>
																					</table>
																					<br>
																					<table border="0" cellpadding="3" cellspacing="3" width="100%" bgcolor="#FFFFCE">
																						<tr>
																							<td><%=prddesk%></td>
																						</tr>
																					</table>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="86">Customer Star</td>
																							<td width="9">:</td>
																							<td>
									<%
									session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
									%>																															
									<img border="0" src="images/starimages/<%=formatnumber(testiprod_nil,1)%>.gif" width="64" height="12">
									<%
									session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
									%>																								
																							</td>
																						</tr>
																						<tr>
																							<td width="86">Testimonial Vote</td>
																							<td width="9">:</td>
																							<td>
																							<%if voteman > 0 then %>
																							<a href="baca_testimonial_produk.asp?kode=<%=idprod%>&asal=produk"><%=formatnumber(voteman,0)%> testimonial</a>
																							<%else%>
																							0 Testimonial
																							<%end if%>																							
																							</td>
																						</tr>
																						<tr>
																							<td width="86">&nbsp;</td>
																							<td width="9">&nbsp;</td>
																							<td>&nbsp;
																							</td>
																						</tr>
																					</table>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td>&nbsp;
																							</td>
																						</tr>
																					</table>
																					</font></b>
																					</td>																					
																				</tr>
																			</table>
																			</td>
											</tr>
											<tr>
												<td valign="top" background="images/bar_vert_2.gif">&nbsp;
												</td>
											</tr>
											<%if mesej <> "" then %>
											<tr>
												<td valign="top">
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td>
														<p align="center">
														<font color="#FF0000">
														<b><%=mesej%></b></font></td>
													</tr>
													<tr>
														<td>&nbsp;</td>
													</tr>
												</table>
												</td>
											</tr>
											<%end if%>
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
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>																						
																				</tr>
																			</table>
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td valign="top">
																					<div align="center">
<form name="theform" method="post" action="add_mykomen.asp" onSubmit="return formCheck(this)">
<input type="hidden" name="kode" value="<%=idprod%>">	
<input type="hidden" name="tipe" value="testimonial_produk">																						
																						<table border="0" cellpadding="0" cellspacing="0" width="99%">
																							<tr>
				<td valign="top">
				<table border="0" cellpadding="4" cellspacing="4" width="100%" style="text-align: justify" bgcolor="#FFFFCE">
					<tr>
						<td valign="top">
						<p style="text-align: center"><b>
						<font size="3" color="#FF0000">MENULIS TESTIMONIAL</font></b><br>
						Apabila anda ingin memberikan 
						testimonial mengenai pengalaman anda dengan mengkonsumsi 
						produk <font color="#FF0000"><%=nama_prd%></font> diatas, silahkan isi form dibawah ini. Anda
						<b>harus login terlebih dulu</b> sebagai distributor HWI.</td>
					</tr>
				</table>
				</td>
																							</tr>
																							<tr>
				<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td>&nbsp; Distributor Id.</td>
						<td width="17" align="center">:</td>
						<td width="471">
							<font size="1">
							<input type="text" name="membid" readonly="T" onKeyDown="if(event.keyCode==13) event.keyCode=9;" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt" size="10" value="<%=manuk%>"></font></td>
					</tr>
					<tr>
						<td>&nbsp; Nama Lengkap</td>
						<td width="17" align="center">:</td>
						<td width="471">
							<font size="1">
							<input type="text" name="nama" readonly="T" onKeyDown="if(event.keyCode==13) event.keyCode=9;" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt" size="17" value="<%=nama_log%>"></font></td>
					</tr>
					<tr>
						<td>&nbsp; Penilaian</td>
						<td width="17" align="center">:</td>
						<td width="471">
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
						<td valign="top">&nbsp; Komentar</td>
						<td width="17" align="center" valign="top">:</td>
						<td width="471">
							<font size="1">
							<textarea rows="15" name="deskripsi" onKeyDown=HitungKar(this.form.deskripsi) onKeyUp=HitungKar(this.form.deskripsi) cols="56" style="font-family: Verdana; border: 1px solid #808080; font-size:8pt"></textarea></font></td>
					</tr>
					<tr>
						<td>&nbsp;</td>
						<td width="17" align="center">&nbsp;</td>
						<td width="471">
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
						<td width="17" align="center">&nbsp;</td>
						<td width="471"><font size="1">
						<%if Session.Contents("manuk") <> "" and aman = "T" and nama_log <> "" then %>
							<input type="submit" name="btsub0" value="Submit" style="font-family: Verdana; font-size:8pt"></font>
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
																						</table>
																					</div>
																					</td>
																				</tr>
																			</table>
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
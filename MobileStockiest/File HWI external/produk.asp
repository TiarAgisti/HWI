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

'kate = ucase(request("category"))
'sort = request("sort")

kate = SafeSQL(ucase(request("category")))
sort = SafeSQL(ucase(request("sort")))

akt = "T"
kel = "T"
if kate = "SEMUA" then
	kate = ""
else
	kate = kate
end if
		
if kate <> "" then
	rs.Open "SELECT count(id) FROM st_barang WHERE kategori like '"&kate&"' and sta like '"&akt&"' and prd like '"&kel&"'",conn
else
	rs.Open "SELECT count(id) FROM st_barang WHERE sta like '"&akt&"' and prd like '"&kel&"'",conn
end if

	if rs.bof then
		xas = 0
	else
		xas = clng(rs("count(id)"))
	end if	
rs.close 

'pgview = request("pgview")
pgview = SafeSQL(ucase(request("pgview")))
if pgview = "" then
	bg = 4
else
	bg = pgview
end if

pg = 0
'pgas = request("page")
pgas = SafeSQL(ucase(request("page")))
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
	'xas = 1
else
	pgct = roundup(pgcunt)
	'xas = roundup(pgcunt)
end if

session("asal") = "produk.asp?session=&nabar=&category="&kate&"&subcategory="&subkat&"&sort="&sort&"&page="&pg+1&"&keyword="&txtcari&"&tipe="&gom
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Daftar Produk Health Wealth International">
   <meta name="keywords" content="qq, pupuk, alkali, ion water,macca,chlorophyl,health wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Daftar Produk</TITLE>
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
									
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										
										<td valign="top" width="100%">										
										
										<table border="0" cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td valign="top" background="images/bg_text.gif">
												<img border="0" src="images/text_produk.gif" width="471" height="63"></td>
											</tr>
											<tr>
												<td valign="top">
												<table border="0" cellpadding="0" cellspacing="0" width="100%">
													<tr>
														<td style="padding:5px;">
Ditemukan <font color="#FF0000"><b><%=formatnumber(xas,0)%></b></font> produk 
<%if kate <> "" then %>
dalam kategori <b><i><%=ucase(kate)%></i></b>
<%end if%>
</td>
														<td width="309" style="padding:5px;">
														<form name="viewproduk" method="post" action="produk.asp">
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td width="62">
																<p align="right">
																<b>Kategori&nbsp;&nbsp;&nbsp;
																</b>
																</td>
																<td>
																	<p align="center">
<select size="1" name="category" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080">		
<option value="semua" selected>--ALL--</option>
<%
rs.Open "SELECT distinct kategori FROM st_barang where sta like '"&akt&"' and isnull(kategori)=false order by kategori", conn			
	if rs.eof<>True then
	
	if goneqsK <> 0 then
		 for aaeeqsK = 1 to goneqsK
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if

for aaaeqsK = 1 to 50
if rs.eof = True then exit for	
%>		

				<%if kate = ucase(rs("kategori")) then %>
               <option value="<%=rs("kategori")%>" selected><%=ucase(rs("kategori"))%></option>
               <%else%>
               <option value="<%=rs("kategori")%>"><%=ucase(rs("kategori"))%></option>
               <%end if%>     
<%
rs.movenext
next
end if
if rs.eof = True then
aaaqsK = 1
end if
rs.Close
%>	 																																											
															</select>
																	</td>
																<td width="94">
																<input type="submit" name="btsubmit" value="Tampilkan" style="font-size: 8pt; font-family: Verdana"></td>
																</form>
															</tr>
														</table>
														</td>
													</tr>
												</table>
												</td>
											</tr>
											
											<tr>
												<td valign="top">
												<div align="center">
													<table border="0" cellpadding="0" cellspacing="0" width="100%">
														<tr>
															<td align="center" width="558">
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
	<a href="produk.asp?category=<%=kate%>&sort=<%=sort%>&page=<%=kembali%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=kembali-1%>&nexts=<%=ke+1%>" class="prevnext">
	<%end if%>
		« previous</a></li>	
	<% 
	end if
	if ke < y+1 then		
	if pg+1 = ke then 
	saatini = ke
	%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="produk.asp?category=<%=kate%>&sort=<%=sort%>&page=<%=ke%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" class="currentpage"><%=formatnumber(ke,0)%></a></li>
	<%else%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px">
	<a href="produk.asp?category=<%=kate%>&sort=<%=sort%>&page=<%=ke%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" style="text-decoration: none; color: #2e6ab1; border: 1px solid #9aafe5; padding-left: 5px; padding-right: 5px; padding-top: 0; padding-bottom: 0"><%=formatnumber(ke,0)%></a></li>
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
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="produk.asp?category=<%=kate%>&sort=<%=sort%>&page=<%=saatini+1%>&grpid=<%=menucode%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=saatini%>&nexts=<%=saatini+1%>" class="prevnext">
	next »</a></li>
	<%end if%>
	</ul>
	</div>																
															</td>
															<td align="center">
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
<%
intHowManyCharw = 690
kep = 0
sss  = "T"
if kate <> "" then
	rs.Open "SELECT * FROM st_barang WHERE kategori like '"&kate&"' and sta like '"&akt&"' and prd like '"&kel&"' order by urut limit "&lim&"",conn
else
	rs.Open "SELECT * FROM st_barang WHERE sta like '"&akt&"' and prd like '"&kel&"' order by urut limit "&lim&"",conn
end if
if rs.bof then %>

									<table border="0" cellspacing="1" width="100%" id="table14" style="border-collapse: collapse" bordercolor="#808080">
										<tr>
											<td width="100%" align="center" valign="middle" height="40" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
													<font face="Verdana" size="2">
													<u>Belum ada produk pada kategori <%=kate%></u></font></td>
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
																			
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
<%
for aaaeqSSS = 1 to lumpat
if rs.eof = True then exit for
kep = kep + 1
prd_desk = rs("keterangan")
idprod = rs("kode")

If len(prd_desk) > intHowManyCharw then
	prddesk = left(decodeString(prd_desk),intHowManyCharw) & "  ...........&nbsp;"
else
	prddesk = prd_desk
End If

rsALL.Open "SELECT count(id) FROM testi_prod WHERE prod_id like '"&idprod&"' and sta like '"&sss&"' group by sta",connALL,1,3
	if rsALL.bof then
		voteman = 0
	else		
		voteman = cint(rsALL("count(id)"))
	end if						
rsALL.close

if isnull(voteman) = true then
	voteman = 0
else
	voteman = voteman
end if
		
rsALL.Open "SELECT sum(nilai) FROM testi_prod WHERE prod_id = '"&idprod&"' and sta like '"&sss&"' group by sta",connALL,1,3
	if rsALL.bof then
		nilai = 0
	else		
		nilai = cint(rsALL("sum(nilai)"))
	end if						
rsALL.close

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
%>																			
																				<tr>
																					<td width="129" valign="top"><img border="0" src="<%=rs("foto")%>"><br><br></td>
																					<td valign="top"><b><a href="detail.asp?kode=<%=rs("kode")%>"><font size="4" color="#3399FF"><%=rs("nama")%></font></a></b><br>
																					<i><b>Kode : <%=rs("kode")%></b></i><br>
																					<table border="0" cellpadding="3" cellspacing="3" width="100%" bgcolor="#FFFFCE">
																						<tr>
																							<td><%=prddesk%> [ <a href="detail.asp?kode=<%=rs("kode")%>">Lebih Detail</a> ]</td>
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
																							<a href="baca_testimonial_produk.asp?kode=<%=rs("kode")%>&asal=produk"><%=formatnumber(voteman,0)%> testimonial</a>
																							<%else%>
																							<a href="detail.asp?kode=<%=rs("kode")%>">Menulis Testimonial</a>
																							<%end if%></td>
																						</tr>
																						<tr>
																							<td width="86">&nbsp;</td>
																							<td width="9">&nbsp;</td>
																							<td>
																							<table border="0" cellpadding="0" cellspacing="0" width="32%">
																								<tr>
																									<td width="30%">
																									<p align="center">
																									<%if rs("brosur1") <> "-" or rs("brosur2") <> "-" then %> 
																									<a href="download_version.asp?kode=<%=rs("kode")%>" onClick="NewWindow(this.href,'name','600','780','yes');return false" style="text-decoration: none; color: #31509F"><img border="0" src="images/ico_download_version.gif" width="20" height="20"></a>
																									<%else%>
																									<img border="0" src="images/ico_download_version.gif" width="20" height="20">
																									<%end if%>
																									</td>
																									<td width="30%">
																									<p align="center"><a href="print_version.asp?prod_id=<%=rs("kode")%>" onClick="NewWindow(this.href,'name','780','550','yes');return false" style="text-decoration: none; color: #31509F"><img border="0" src="images/ico_print_version.gif" width="20" height="20"></a></td>
																									<td width="40%">
																									<p align="center"><a href="sentmail_version.asp?prod_id=<%=rs("kode")%>" onClick="NewWindow(this.href,'name','750','450','yes');return false" style="text-decoration: none; color: #31509F"><img border="0" src="images/ico_mail_version.gif" width="20" height="20"></a></td>
																								</tr>
																								<tr>
																									<td width="30%">
																									<%if rs("brosur1") <> "-" or rs("brosur2") <> "-" then %>
																									<a href="download_version.asp?kode=<%=rs("kode")%>" onClick="NewWindow(this.href,'name','600','780','yes');return false" style="text-decoration: none; color: #31509F">Download</a>
																									<%else%>
																									Download
																									<%end if%>
																									</td>
																									<td width="30%">
																									<p align="center"><a href="print_version.asp?prod_id=<%=rs("kode")%>" onClick="NewWindow(this.href,'name','780','550','yes');return false" style="text-decoration: none; color: #31509F">Print</a></td>
																									<td width="40%">
																									<p align="center"><a href="sentmail_version.asp?prod_id=<%=rs("kode")%>" onClick="NewWindow(this.href,'name','750','450','yes');return false" style="text-decoration: none; color: #31509F">Kirim E-mail</a></td>
																								</tr>
																							</table>
																							</td>
																						</tr>
																					</table>
																					<p><br>
																					<br>
																					<br>
																					</td>
<%  
rs.movenext
next
end if
if rs.eof = True then
end if
rs.Close

set rsALL=nothing
ConnALL.Close
set connALL=nothing
%>																						
																				</tr>
																			</table>
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td>&nbsp;</td>
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
												
												</td>
											</tr>
											<tr>
												<td valign="top">&nbsp;
												</td>
											</tr>
											</table>
										</div>
										</td>
										
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									
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
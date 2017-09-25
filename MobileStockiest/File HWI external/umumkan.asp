<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ****** ' 
'Application: HEALTH WEALTH INTERNATIONAL
'Author: Ir. Peter Sindoro
'Coding : August 2009
'Revised : - 
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ****** 
%>
<!--#Include File=dbcon/opendb.asp-->
<%
sss = "T"
bagimu = request("kategori")
if bagimu = "" then
	bag = "DC"
else
	bag = bagimu
end if
		
rs.Open "SELECT count(id) FROM berita where sta like '"&sss&"' and tipe like '"&bag&"'",conn	
	if rs.bof then
		x = 0
	else
		x = cint(rs("count(id)"))
	end if
rs.Close

lumpat = 0
pg = 0
pgview = request("pgview")
if pgview = "" then
	bg = 5
else
	bg = pgview
end if

pgas = request("page")
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
if sisa < int(bg) then	
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

bln = month(now())
thn = year(now())
%>

<style type="text/css">

/*Credits: Dynamic Drive CSS Library */
/*URL: http://www.dynamicdrive.com/style/ */

.indentmenu{
font: bold 13px Arial;
width: 100%; /*leave this value as is in most cases*/
overflow: hidden;
}

.indentmenu ul{
margin: 0;
padding: 0;
float: left;
width: 100%; /*width of menu*/
border: 1px solid #564c66; /*dark purple border*/
border-width: 1px 0;
background: black url(../images/indentbg.gif) center center repeat-x;
}

.indentmenu ul li{
display: inline;
}

.indentmenu ul li a{
float: left;
color: white; /*text color*/
padding: 5px 11px;
text-decoration: none;
border-right: 1px solid #564c66; /*dark purple divider between menu items*/
}

.indentmenu ul li a:visited{
color: white;
}

.indentmenu ul li a:hover, .indentmenu ul li .current{
color: white !important; /*text color of selected and active item*/
padding-top: 6px; /*shift text down 1px for selected and active item*/
padding-bottom: 4px; /*shift text down 1px for selected and active item*/
background: black url(../images/indentbg2.gif) center center repeat-x;
}

 table.MsoNormalTable
	{mso-style-parent:"";
	font-size:10.0pt;
	font-family:"Calibri","sans-serif"}
</style>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="98%">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="4" cellspacing="4" width="100%" bgcolor="#FFFFD2">
							<tr>
								<td>
												<font size="4" color="#FF0000">
												<b>
												PENGUMUMAN CLOSING PERIODE<br>
												</b>
												</font>
												Closing Date untuk bulan ini adalah pada tanggal, jam :<br><% hariakhir = date()%>
												<font color="#FF0000"><%=tutup1%></font>												
												<br>
												Periode Top Up dibuka tanggal <b>
												<%=tupoawal%></b> sd<b> <%=tupoakhir%></b><br>
												<br>
												Salam sehat luar biasa !</td>
							</tr>
						</table>
						</td>
					</tr>	
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
									<tr>
										<td>&nbsp;</td>
									</tr>
									</table>

						<table border="0" cellpadding="4" cellspacing="4" width="100%" bgcolor="#FFFFD2">
							<tr>
								<td>
												<font size="4" color="#FF0000">
												<b>
												PENGUMUMAN MAINTENANCE SERVER<br><br>
												</b>
												</font>Akan dilakukan 
												Maintenance Server Full pada 
												tanggal 7 dan 8 februari 2016 <br>
												untuk pembaharuan Software dan Hardware Server.
												<br>
												<br>
												Salam sehat luar biasa !</td>
							</tr>
						</table>
						</td>
					</tr>		
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td>
								<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
									<tr>
										<td>&nbsp;</td>
									</tr>
									</table>
								</td>
							</tr>
							
							
							<tr>
								<td bgcolor="#DBFFDB" valign="top">
								<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
									<tr>
										<td valign="top">
										<table border="0" cellpadding="4" style="border-collapse: collapse" width="100%" cellspacing="4">
											<tr>
												<td>
												<b>
												<font size="4" color="#FF0000">
												KETENTUAN STOCK PENDING MOBILE 
												STOCKIEST (MS)</font></b><br>
												<br>
												Setiap Mobile Stockiest (MS) 
												hanya diperbolehkan menyimpan 
												point pending maksimal 750 PV 
												(diluar pv paket pendaftaran 
												distributor baru). <br>
												<br>
												Pada setiap bulan setelah topup 
												berakhir, pukul 00:00:01 WIB 
												sistem akan melakukan cek stock 
												MS (hanya produk / invoice yang 
												diorder pada pv bulan sebelumnya). <br>
												<br>
												<u>Contoh :</u><br>
												Tanggal proses automaintenance 
												setelah topup berakhir, misalnya 
												04-11-2013, maka yang dihitung 
												maksimal 750PV adalah stock yang 
												diorder pada bulan 10 kebawah, 
												stock yang diorder pada bulan 11 
												tidak dihitung.<br>
												<br>
												Semua stock MS yang diatas 750 
												PV akan dikenai automaintenance.
												<br>
												<br>
												Maksimal 200 PV akan diposting 
												sebagai pv pribadi pemilik MS 
												(productivity berlaku) pada 
												bulan periode berjalan (bukan 
												bulan topup) dan sisanya 
												disimpan kedalam saldo 
												automaintenance yang akan 
												diposting maksimal per 200PV 
												tiap bulan hingga habis.<br>
												<br>
												Dengan demikian setelah proses 
												automaintenance selesai 
												dilakukan, pemilik MS yang 
												dikenai automaintenance atau 
												memiliki saldo automaintenance 
												yang di posting oleh sistem 
												otomatis sudah langsung tutup 
												point 200PV pada awal bulan.<br>
												----------------------------------------------------------------------------<br>
												<font size="4" color="#FF0000">
												<b>PEMBEKUAN SEMENTARA PENJUALAN 
												PRODUK DISTRIBUTOR PADA MASA 
												TOPUP</b></font><b><font size="4" color="#FF0000"><br>
												<br>
												</font></b>Pada setiap bulan 
												saat masa topup berlangsung, 
												penjualan produk distributor 
												(posting pv pada periode bulan 
												berjalan) sementara di bekukan. 
												DC, MC dan MS tidak dapat 
												melakukan penjualan produk 
												distributor, namun tetap dapat 
												melakukan PENJUALAN PRODUK TOPUP 
												dan PENDAFTARAN DISTRIBUTOR 
												BARU, UPGRADE FAST TRACK dan 
												RENEWAL<b><font size="4" color="#FF0000"><br>
												</font></b>----------------------------------------------------------------------------<br>
												<br>
												<b>
												<font size="4" color="#FF0000">
												STOCK PENDING DISTRIBUTION 
												CENTER</font></b><br>
												<br>
												Per 05 Desember 2013 
												diberlakukan ketentuan maksimal 
												point pending DC sebesar 20.000 
												PV. <br>
												<br>
												DC <u>hanya dapat melakukan order 
												ke kantor pusat bila stock 
												pending dibawah 20.000 PV</u> 
												(diluar paket pendaftaran 
												distributor baru)<br>
												<br>
												Jumlah PV yang diorder maksimal 
												total 30.000 PV (termasuk pv 
												pending diluar paket pendaftaran 
												distributor baru).<br>
												<br>
												Rumus maksimal order = <br>
												30.000 - stock pending DC (stock 
												pending DC harus dibawah 20.000 
												PV untuk dapat melakukan order 
												ke kantor pusat)<br>
												<br>
												Contoh :<br>
												1. DC AAA memiliki PV yang belum 
												dipointkan (diluar paket 
												pendaftaran distributor baru) 
												sebesar 13.000 PV, maka DC AAA 
												hanya dapat melakukan order ke 
												kantor pusat maksimal 17.000 PV 
												(diluar paket pendaftaran 
												distributor).<br>
												<br>
												2. DC AAA memiliki PV yang belum 
												dipointkan (diluar paket 
												pendaftaran distributor baru) 
												sebesar 19.000 PV, maka DC AAA 
												hanya dapat melakukan order ke 
												kantor pusat maksimal 11.000 PV 
												(diluar paket pendaftaran 
												distributor).<br>
												<br>
												3. DC AAA memiliki PV yang belum 
												dipointkan (diluar paket 
												pendaftaran distributor baru) 
												sebesar 23.000 PV, maka DC tidak 
												dapat melakukan order ke kantor 
												pusat karena maksimal PV pending 
												diatas 20.000 PV<br>
												<br>
												<br>
&nbsp;</td>
											</tr>
										</table>
										</td>
									</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
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
								<td>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td width="2" background="../images/a1.jpg" valign="top">
		<img border="0" src="../images/a1.jpg" width="2" height="8"></td>
		<td width="100%">
<div class="indentmenu">
<ul>
<li><a href="cp_home.asp?menu_id=<%=menu_id%>&kategori=">Berita Terbaru</a></li>
<li><a href="cp_home.asp?menu_id=<%=menu_id%>&kategori=promosi">Event Promosi</a></li>
<li><a href="cp_home.asp?menu_id=<%=menu_id%>&kategori=campaign">Campaign</a></li>
<li><a href="cp_home.asp?menu_id=<%=menu_id%>&kategori=jadwal">Marketing Tools</a></li>
</ul>
</div>		
		</td>
		<td width="2" background="../images/a2.jpg" valign="top">
		<img border="0" src="../images/a2.jpg" width="2" height="8"></td>
	</tr>
</table>

								
								</td>
							</tr>
							<tr>
								<td valign="top">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td background="../images/a1.jpg" width="2" valign="top">
										<img border="0" src="../images/a1.jpg" width="2" height="8"></td>
										<td width="100%" valign="top">
										<div align="center">
											<table border="0" cellpadding="0" cellspacing="0" width="99%">
												<tr>
													<td valign="top">&nbsp;</td>
												</tr>
					<tr>
						<td valign="top">
						<div align="center">
<%
rs.Open "SELECT * FROM berita where sta like '"&sss&"' and tipe like '"&bag&"' order by tgl DESC",conn	
if rs.bof then %>

									<table border="0" cellspacing="1" width="100%" id="table14" bordercolor="#808080">
										<tr>
											<td width="100%" align="center" height="40" bgcolor="#FFFFFF">
													<u>Tidak ada berita terbaru 
													</td>
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
							<table border="0" cellpadding="0" cellspacing="0" width="98%">
<%
for aaaeqSSS = 1 to lumpat
if rs.eof = True then exit for 
%>									
								<tr>
									<td valign="top">
									<b><font size="3" color="#FF0000">
									<%=ucase(rs("title"))%></font></b>
									<br>
									<%=rs("isi")%><br>
									<i><font size="1" color="#808080">Added Date : <%=formatdatetime(rs("tgl"),1)%> | Post By : <%=rs("oleh")%>
									</font></i>
									<br><br>
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
							</table>
						</div>
						</td>
					</tr>
												<tr>
													<td valign="top">&nbsp;</td>
												</tr>
												<tr>
						<td valign="top">
						<div align="center">
							<table border="0" cellpadding="0" cellspacing="0" width="98%">
<% if x > 0 then %>						
								<tr>
									<td>								
<div class="pagination">
Ditemukan <font color="#FF0000"><%=formatnumber(x,0)%></font> index berita.
<br> 
Halaman ::
<%
	x1 = x
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
	<a href="cp_home.asp?kategori=<%=bagimu%>&category=<%=cat%>&subcategory=<%=subct%>&page=<%=kembali%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=kembali-1%>&nexts=<%=ke+1%>" class="prevnext">
	<%end if%>
		« previous</a></li>	
	<% 
	end if
	if ke < y+1 then		
	if pg+1 = ke then 
	saatini = ke
	%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="cp_home.asp?kategori=<%=bagimu%>&category=<%=cat%>&subcategory=<%=subct%>&page=<%=ke%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" class="currentpage"><%=formatnumber(ke,0)%></a></li>
	<%else%>
	<li style="list-style-type: none; display: inline; padding-bottom: 1px">
	<a href="cp_home.asp?kategori=<%=bagimu%>&category=<%=cat%>&subcategory=<%=subct%>&page=<%=ke%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" style="text-decoration: none; color: #2e6ab1; border: 1px solid #9aafe5; padding-left: 5px; padding-right: 5px; padding-top: 0; padding-bottom: 0"><%=formatnumber(ke,0)%></a></li>
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
	<li style="list-style-type: none; display: inline; padding-bottom: 1px"><a href="cp_home.asp?kategori=<%=bagimu%>&category=<%=cat%>&subcategory=<%=subct%>&page=<%=saatini+1%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=saatini%>&nexts=<%=saatini+1%>" class="prevnext">
	next »</a></li>
	<%end if%>
	</ul>
	</div>	
<% else%><font color="#FF0000">
									</td>
								</tr>
<%end if%>								
							</table>
						</div>
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
										<td background="../images/a2.jpg" width="2" valign="top">
										<img border="0" src="../images/a2.jpg" width="2" height="15"></td>
									</tr>
								</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
					<tr>
						<td valign="top" background="../images/a3.jpg">
						<img border="0" src="../images/a3.jpg" width="43" height="3"></td>
					</tr>
					</table>
				</td>
				<td width="316" valign="top">
				&nbsp;</td>
			</tr>
		</table>
		</td>
	</tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>
												&nbsp;</td>
	</tr>
	<tr>
		<td>
												&nbsp;</td>
	</tr>
	<tr>
		<td>
												&nbsp;</td>
	</tr>
	</table>
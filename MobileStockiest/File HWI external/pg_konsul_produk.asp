<!--#Include File=dbcon/opendb.asp-->
<!--#Include File=dbcon/opendbALL.asp-->
<%
sss = "T"
sss2 = "C"
noid = cint(request("id"))
rs.Open "SELECT sta FROM new_konsul_produk_head where id like '"&noid&"'",conn	
	if rs.bof then
		sfd = "F"
	else
		sfd = rs("sta")
	end if
rs.Close

rs.Open "SELECT count(id) FROM new_konsul_produk_det where noid like '"&noid&"' and (sta like '"&sss&"' OR sta like '"&sss2&"')",conn	
	if rs.bof then
		xss = 0
	else
		xss = cint(rs("count(id)"))
	end if
rs.Close

pgview = request("pgview")
if pgview = "" then
	bg = 30
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

if xss mod bg = 0 then
	tothal = xss / bg
else	
	z = xss+(bg-(xss mod bg))
	tothal = z / bg
end if

totrec = xss
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
%>
<head>
<meta http-equiv="Content-Language" content="id">
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

<script language="JavaScript">
<!--
function formCheck(form) {
if (form.noid.value == "")
{
 alert("Mohon pilih dahulu topik konsultasi yang akan anda reply");
return false;}

if (form.userid.value == "")
{
 alert("Mohon isikan nomor id distributor anda");
return false;}

if (form.userid.value.length >= 8)
{
 alert("Id. distributor maksimal 8 karakter");
return false;}

if (form.password.value == "")
{
 alert("Mohon password distributor login anda");
return false;}

if (form.deskripsi.value == "")
{
 alert("Mohon tuliskan balasan anda");
return false;}

if (confirm("Silahkan cek apakah data yang anda isikan sudah benar ? \n\nNo. Id Distributor : " + form.userid.value +".\nBalasan : "+ form.deskripsi.value+"\n")) {
    return true;}
    else {
    return false;}
}
// -->
</script>

</head>

<table border="1" cellspacing="1" width="100%" style="border-collapse: collapse" bordercolor="#DDDDDD">
<%if xss > 0 then%>
	<tr>
		<td valign="top">
		<div align="center">
			<table border="0" cellpadding="0" cellspacing="0" width="99%">
				<tr>
					<td valign="top"></td>
				</tr>
				<tr>
					<td valign="top">&nbsp;</td>
				</tr>
				<tr>
					<td valign="top">
<%
rs.Open "SELECT * FROM new_konsul_produk_det where (sta like '"&sss&"' or sta like '"&sss2&"') and noid like '"&noid&"' order by tgl desc limit "&lim&"",conn	
if rs.bof then %>
															<table border="0" cellspacing="0" width="100%" bordercolor="#808080" cellpadding="0">
																<tr>
																	<td width="100%" height="50">
																	<p align="center">Belum ada tulisan balasan															
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
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
<%
for aaaeqSSS = 1 to lumpat
if rs.eof = True then exit for 
sapa = rs("author")
stf = rs("staff")

isi = rs("isi")
rsALL.Open "SELECT uid FROM member where kta like '"&sapa&"'",connALL	
	if rsALL.bof then
		namasapa = "-"
	else
		namasapa = rsALL("uid")
	end if
rsALL.Close
%>					
						<tr>
							<td>
							<b><font color="#FF9900"><%=rs("tgl")%></font></b><br>
							<%if sapa <> "" and stf = "" then %>
							Oleh : <%=sapa%> : <%=namasapa%><br>
							<%else
							if sapa <> "" and stf <> "" then %>
							<font color="#008000">Oleh : <%=stf%></font><br>
							<%else
							if sapa = "" and stf <> "" then %>
							<font color="#008000">Oleh : <%=stf%></font><br>
							<%
							else%>
							<font color="#800000">Oleh : <%=namasapa%> (<%=sapa%>)</font><br>							
							<%end if
							end if
							end if%><br>
							<i><%=isi%></i><br>
							<table border="0" cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td><hr color="#C0C0C0" size="1"></td>
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

'set rs=nothing
'Conn.Close
'set conn=nothing

'set rsALL=nothing
'ConnALL.Close
'set connALL=nothing
%>							
					</table>
					</td>
				</tr>
				<tr>
					<td valign="top">
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
<% if xss > 0 then %>	
<div class="pagination">								
Ditemukan <b><%=formatnumber(xss,0)%></b> reply<br>
Halaman :: 
<%
	x1 = xss
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
	<ul><li>
	<% if kembali = 0 then %>
	<a href="#" class="prevnext disablelink">
	<%else%>
	<a href="pg_konsul_produk.asp?id=<%=noid%>&page=<%=kembali%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=kembali-1%>&nexts=<%=ke+1%>" class="prevnext" target="_self">
	<%end if%>
		« previous</a></li>	
	<% 
	end if
	if ke < y+1 then		
	if pg+1 = ke then 
	saatini = ke
	%>
	<li><a href="pg_konsul_produk.asp?id=<%=noid%>&page=<%=ke%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" class="currentpage" target="_self"><%=formatnumber(ke,0)%></a></li>
	<%else%>
	<li>
	<a href="pg_konsul_produk.asp?id=<%=noid%>&page=<%=ke%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>"  target="_self" style="text-decoration: none; color: #2e6ab1; border: 1px solid #9aafe5; padding-left: 5px; padding-right: 5px; padding-top: 0; padding-bottom: 0"><%=formatnumber(ke,0)%></a></li>
	<%    
	end if
	if aax = 30 then
	exit for
	end if
	end if
	next
	%>	
	<% if tothal < saatini or tothal = saatini then %>
	<li><a href="#" class="prevnext disablelink">
	next »</a></li>
	<%else%>
	<li><a href="pg_konsul_produk.asp?id=<%=noid%>&page=<%=saatini+1%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=saatini%>&nexts=<%=saatini+1%>" class="prevnext" target="_self">
	next »</a></li>
	<%end if%>
	</ul>
	</div>					
<%end if%>																	
																</td>
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
	<%end if%>
	<tr>
		<td bgcolor="#FFFFCE"><b>&nbsp;QUICK REPLY FORM</b></td>
	</tr>
	<tr>
		<td valign="top">
		<div align="center">
		<form name="form1" method="post" action="sent_reply_produk_konsul.asp" onsubmit="return formCheck(this)">
		<input type="hidden" name="noid" value="<%=noid%>">
			<table border="0" cellspacing="1" width="99%">
				<tr>
					<td width="91">&nbsp;</td>
					<td width="11">&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td width="91">Distributor Id.</td>
					<td width="11">:</td>
					<td>
					<input type="text" name="userid" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="12"></td>
				</tr>
				<tr>
					<td width="91">Password Login</td>
					<td width="11">:</td>
					<td>
					<input type="password" name="password" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="12"></td>
				</tr>
				<tr>
					<td width="91" valign="top">Tulisan Balasan</td>
					<td width="11" valign="top">:</td>
					<td>
																<textarea rows="9" name="deskripsi" cols="40" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080"></textarea></td>
				</tr>
				<tr>
					<td width="91" height="3"></td>
					<td width="11" height="3"></td>
					<td height="3"></td>
				</tr>
				<tr>
					<td width="91">&nbsp;</td>
					<td width="11">&nbsp;</td>
					<td>
					<% if sfd = "T" then %>
					<input type="submit" name="btreply" value="Submit" style="font-size: 8pt; font-family: Verdana">
					<%else%>
					<font color="#FF0000"><i>Topik konsultasi ini sudah ditutup.</i></font>
					<%end if%>
					</td>
					</form>
				</tr>
			</table>
		</div>
		</td>
	</tr>
</table>
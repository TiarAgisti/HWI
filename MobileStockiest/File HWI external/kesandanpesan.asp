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

tolak1 = "1000088"
tolak2 = "1010253"
sss = "T"
rs.Open "SELECT count(id) FROM new_kesan where sta like '"&sss&"'",conn	
	if rs.bof then
		x = 0
	else
		x = cint(rs("count(id)"))
	end if
rs.Close

pgview = request("pgview")
if pgview = "" then
	bg = 10
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
if sisa < bg then	
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

session("asal") = "kesandanpesan.asp?page="&pg+1
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
   <meta name="description" content="Kesan, Pesan dan Harapan dari Distributor Health Wealth International">
   <meta name="keywords" content="kesan dan pesan, harapan,health wealth international,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: Kesan, Pesan dan Harapan dari Distributor</TITLE>
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
												<img src="images/text_kesan.gif">
														<table border="0" cellpadding="0" cellspacing="0" width="100%">
															<tr>
																<td>
<% if x > 0 then %>	
<div class="pagination">								
Ditemukan <b><%=formatnumber(x,0)%></b> kesan, pesan dan harapan Distributor<br>
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
	<ul><li>
	<% if kembali = 0 then %>
	<a href="#" class="prevnext disablelink">
	<%else%>
	<a href="kesandanpesan.asp?menu_id=<%=session("menu_id")%>&page=<%=kembali%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=kembali-1%>&nexts=<%=ke+1%>" class="prevnext">
	<%end if%>
		« previous</a></li>	
	<% 
	end if
	if ke < y+1 then		
	if pg+1 = ke then 
	saatini = ke
	%>
	<li><a href="kesandanpesan.asp?menu_id=<%=session("menu_id")%>&page=<%=ke%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>" class="currentpage"><%=formatnumber(ke,0)%></a></li>
	<%else%>
	<li><a href="kesandanpesan.asp?menu_id=<%=session("menu_id")%>&page=<%=ke%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=ke-1%>&nexts=<%=ke+1%>"><%=formatnumber(ke,0)%></a></li>
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
	<li><a href="kesandanpesan.asp?menu_id=<%=session("menu_id")%>&page=<%=saatini+1%>&grpid=<%=menucode%>&sort=<%=srt%>&pgview=<%=pgview%>&keyword=<%=keyword%>&tampil=<%=apa%>&grp=<%=grp%>&prev=<%=saatini%>&nexts=<%=saatini+1%>" class="prevnext">
	next »</a></li>
	<%end if%>
	</ul>
	</div>					
<%end if%>																	
																</td>
																<td width="221">&nbsp;</td>
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
					<tr><td width="10"></td>
						<td valign="top">
<%
rs.Open "SELECT * FROM new_kesan where sta like '"&sss&"' and kta <> '"&tolak&"' and kta <> '"&tolak2&"' order by tgl DESC",conn	
if rs.bof then %>
															<table border="1" cellspacing="1" width="100%" style="border-collapse: collapse" bordercolor="#808080">
																<tr>
																	<td width="100%" height="50">
																	<p align="center">Belum ada yang memberikan kesan, pesan dan harapan
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
isi_kesanku = rs("deskripsi")
id_kesanku = rs("kta")

rsALL.Open "SELECT uid,foto FROM member WHERE kta like '"&id_kesanku&"'",connALL
	if rsALL.bof then
	else
		nama_kesanku = ucase(rsALL("uid"))
		foto_kesanku = rsALL("foto")
	end if
rsALL.Close 

if id_kesanku <> tolak1 and id_kesanku <> tolak2 then
%>						
							<tr>
								<td width="100" valign="top">
								<img border="1" src="<%=foto_kesanku%>" width="90"><br><br></td>
								<td valign="top">
								<b>Oleh :<font color="#0066FF"> <%=ucase(nama_kesanku)%></font></b><br><%=isi_kesanku%><br>
								<br></td>
							</tr>
<%  
end if
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
						</table>
						</td>
						<td width="10"></td>
					</tr>
				</table>
				</td>
													</tr>
													<tr>
				<td valign="top">&nbsp;
				</td>
													</tr>
													<tr>
				<td valign="top" style="padding:10px;">
				<table border="0" bgcolor="#F5F5F5" cellpadding="4" cellspacing="4" width="100%" >
					<tr>
						<td>
						<p align="center">Apabila anda berminat untuk 
						mengutarakan kesan, pesan dan harapan anda kepada PT. 
						Health Wealth International, silahkan login ke dalam 
						control panel distributor anda dan silahkan isi form 
						kesan kepada manajemen. Terima kasih</td>
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
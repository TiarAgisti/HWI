<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->

<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******
' Application: HEALTH WEALTH INTERNATIONAL WEBSITE
' Author: Peter Sindoro
' Coding : Septmber 2009
' Revised : -
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******     

idprod = request("kode")
kepada1 = trim(request("email1"))
kepada2 = trim(request("email2"))
kepada3 = trim(request("email3"))
kepada4 = trim(request("email4"))
kepada5 = trim(request("email5"))

manuk = Session.Contents("manuk")
sss = "T"
aman = "F"
rs.Open "SELECT uid,kta,hp,emel FROM member WHERE kta like '"&manuk&"' and sta like '"&sss&"'",conn
	if rs.bof then
		aman = "F"
		Session.Contents("manuk") = ""
		nama_anggota = ""
		emel_anggota = ""
		hape_anggota = ""
	else
		aman = "T"
		Session.Contents("manuk") = rs("kta")
		nama_anggota = rs("uid")
		emel_anggota = rs("emel")
		hape_anggota = rs("hp")	
	end if
rs.Close


if aman = "T" then
rs.Open "SELECT kode,nama,keterangan,foto_besar,pv,hd1,hd2,hd3,hk1,hk2,hk3 FROM st_barang WHERE sta like '"&sss&"' and kode like '"&idprod&"'",conn
	if rs.bof then
		ada = "F"
	else
		ada = "T"
		prd_desk = rs("keterangan")
		namaprd = rs("nama")
		fotoprd = rs("foto_besar")
		pv = rs("pv")
		dis1 = formatnumber(rs("hd1"),0)
		dis2 = formatnumber(rs("hd2"),0)
		dis3 = formatnumber(rs("hd3"),0)
		hkon1 = formatnumber(rs("hk1"),0)
		hkon2 = formatnumber(rs("hk2"),0)
		hkon3 = formatnumber(rs("hk3"),0)
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
set rs=nothing
Conn.Close
set conn=nothing

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

sumber = "http://www.healthwealthint.com/detail.asp?kode="&idprod

session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
	nil = formatnumber(testiprod_nil,1)																														
	gbr_rating = "images/starimages/"&nil&".gif"							
session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia

'Set the variables
Dim CurrentTime
Dim strGMorning
Dim strGAfterNoon
Dim strGEvening
Dim strGNight
CurrentTime = hour(time)
strGMorning = "Selamat pagi"
strGAfterNoon = "Selamat siang"
strGEvening = "Selamat sore"
strGNight = "Selamat malam"

If CurrentTime < 9 Then
greeting = strGMorning

ElseIf CurrentTime >= 9 And CurrentTime <= 14 Then
greeting =  strGAfterNoon

ElseIf CurrentTime > 14 And CurrentTime <= 19 Then
greeting = strGEvening

ElseIf CurrentTime > 19 And CurrentTime <=24 Then
greeting = strGNight

Else
greeting = strGMorning
End If

'''''''''''''''''''''''''''''''''''''
' sent mail
'''''''''''''''''''''''''''''''''''''
gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = emel_anggota
mail.FromName = "Berbagi Info Produk"
if kepada1 <> "-" then
	mail.AddRecipient kepada1
end if
if kepada2 <> "-" then
	mail.AddRecipient kepada2
end if
if kepada3 <> "-" then
	mail.AddRecipient kepada3
end if
if kepada4 <> "-" then
	mail.AddRecipient kepada4
end if
if kepada5 <> "-" then
	mail.AddRecipient kepada5
end if	

mail.Subject = "Informasi produk : "&namaprd
strBody = strBody + "<table border=1 cellspacing=1 width=800 style=border-collapse: collapse bordercolor=#0066FF><tr><td><table border=0 cellpadding=0 cellspacing=0 width=800><tr><td width=10></td>"
strBody = strBody + "<td width=780><table border=0 cellpadding=0 cellspacing=0 width=780><tr><td></td></tr><tr><td>"
strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=780><tr>"
strBody = strBody + "<td width=140 valign=top><img border=0 src=http://www.healthwealthint.com/images/logohwi.jpg width=132 height=84></td>"
strBody = strBody + "<td valign=top width=640><font face=Verdana size=2><b>PT. HEALTH WEALTH INTERNATIONAL</b></font><br>"
strBody = strBody + "</font><font face=Verdana size=1>Komplek Mangga Dua Square Blok F no. 35<br>"
strBody = strBody + "Jl. Gunung Sahari no. 1 Jakarta Pusat - Indonesia<br></font>"
strBody = strBody + "<font color=#000000 face=Verdana size=1>Telp. 021-62317900 - Facsimile 021-62317886</font><font face=Verdana size=1><br>"
strBody = strBody + "info@healthwealthint.com</a><br>http://www.healthwealthint.com</a> </font></td></tr></table></td></tr><tr><td></td></tr><tr><td><hr color=#C0C0C0 size=1></td>"
strBody = strBody + "</tr><tr><td><font face=Tahoma size=2>Selamat "&greeting&""&", teman anda bernama <b>"&nama_anggota&" "&"</b>mengirim informasi produk yang "
strBody = strBody + "mungkin dapat bermanfaat bagi anda, berikut ini adalah informasi produk yang dikirimkannya.</font></td></tr><tr><td></td></tr><tr><td>"
strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=256><tr><td width=256 valign=top>"
strBody = strBody + "<img border=1 src=http://www.healthwealthint.com/"&fotoprd&" "&"></td><td valign=top width=524><b><font size=4 color=#3399FF>"
strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=524><tr>"
strBody = strBody + "<td width=524 style=font-family: Tahoma; font-size: 11px; color: #4F4F4F><b><font size=4 color=#3399FF><b>"&nama_prd&""&"</b>( <b>"&idprod&""&"</b> )</font></b></i><br>"
strBody = strBody + "<i><font color=#FF0000 size=2><br></td></tr></table><br><table border=0 cellpadding=3 cellspacing=3 width=524 bgcolor=#FFFFCE>"
strBody = strBody + "<tr><td style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>"&prd_desk&""&"</td></tr></table><table border=0 cellpadding=0 cellspacing=0 width=524>"
strBody = strBody + "<tr><td width=86 style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>Customer Star</td>"
strBody = strBody + "<td width=9 style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>:</td>"
strBody = strBody + "<td style=font-family: Tahoma; font-size: 11px; color: #4F4F4F width=429>"
strBody = strBody + "<img border=0 src=http://www.healthwealthint.com/images/starimages/"&testiprod_nil&""&".gif width=64 height=12></td></tr>"
strBody = strBody + "<tr><td width=86 style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>Testimonial Vote</td>"
strBody = strBody + "<td width=9 style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>:</td>"
strBody = strBody + "<td style=font-family: Tahoma; font-size: 11px; color: #4F4F4F width=429>"
strBody = strBody + "<a href=baca_testimonial.asp?kode="&idprod&""&">"&voteman&""&" testimonial</a>"
strBody = strBody + "</td></tr><tr><td width=86 style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>&nbsp;</td>"
strBody = strBody + "<td width=9 style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>&nbsp;</td><td style=font-family: Tahoma; font-size: 11px; color: #4F4F4F width=429>"
strBody = strBody + "</td></tr></table><table border=0 cellpadding=0 cellspacing=0 width=524><tr><td style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>"
strBody = strBody + "<table border=1 cellspacing=1 width=524 style=border-collapse: collapse bordercolor=#808080>"
strBody = strBody + "</table></td></tr></table></font></b><font size=4 color=#3399FF><b><table border=0 cellpadding=0 cellspacing=0 width=524>"
strBody = strBody + "<tr><td valign=bottom style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>&nbsp;</td>"
strBody = strBody + "</tr><tr><td valign=bottom style=font-family: Tahoma; font-size: 11px; color: #4F4F4F>Sumber : <a href="&sumber&""&">"&sumber&""&"</a></td>"
strBody = strBody + "</tr></table></td></tr></table></td></tr></table><table border=0 cellpadding=0 cellspacing=0 width=780>"
strBody = strBody + "<tr><td></td></tr></table></td><td width=10></td></tr></table><table border=0 cellpadding=0 cellspacing=0 width=800><tr>"
strBody = strBody + "<td bgcolor=#0066FF height=20><p align=center><b><font face=Verdana size=2 color=#FFFFFF>PT. HEALTH WEALTH INTERNATIONAL</font></b></td>"
strBody = strBody + "</tr></table>"
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("kirimngawur") = "Informasi produk sudah terkirim"
	response.redirect "sentmail_version.asp?prod_id="&idprd		
else
	session("kirimngawur") = "Informasi produk sudah terkirim"
	response.redirect "sentmail_version.asp?prod_id="&idprd	
end if	

end if
%>
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
'refername = Trim(Request.QueryString("ref"))
refername = SafeSQL(ucase(request("ref")))
if refername = "" then
	tmpname = Session.Contents("ReferName")
else
	Session.Contents("ReferName")= refername
	tmpname = Session.Contents("ReferName")
end if	

session("menus") = "home"
rs.Open "SELECT * FROM totdata",conn,1,3	
	if rs.bof then
	else
		rs.update
			rs("hits") = rs("hits")+1
		rs.update
	end if
rs.Close

bulek = clng(month(date()))
session("asal") = "default.asp"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

   <meta name="description" content="Health Wealth International">
   <meta name="keywords" content="health wealth international,macca,alkali,chlorophly,oli,nano,marketing,multilevel,network,mlm,international,health,food,supplement,hwi">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International</TITLE>
<link rel="shortcut icon" href="<%=myico%>" />
<!--[if IE 6]>
<style>
body {behavior: url("csshover3.htc");}
#menu li .drop {background:url("images/drop.gif") no-repeat right 8px; 
</style>
<![endif]-->

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
												<td valign="top"></td>
											</tr>	
											
											
											<tr>
												<td valign="top" style="padding:5px;">
<%
akt = "T"
intHowManyCharw = 320
rs.Open "SELECT * FROM liputan WHERE sta like '"&akt&"' order by tgl desc limit 2",conn

	if rs.eof<>True then

	if goneqSS <> 0 then
		 for aaeeqSS = 1 to goneqSS
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if
%>
												<div align="center">
												<table border="0" cellpadding="0" cellspacing="0" width="98%" style="text-align: justify">
<%
for aaaeqSSS = 1 to 2
if rs.eof = True then exit for
judul_liputan = rs("judul")
tgl_liputan = rs("tgl")
desk_liputan = rs("deskripsi")

foto1 = rs("gambar1")
foto2 = rs("gambar2")
foto3 = rs("gambar3")

if foto1 <> "-" then
	img_liputan = foto1
else
if foto1 = "-" and foto2 <> "-" then
	img_liputan = foto2
else
if foto1 = "-" and foto2 = "-"  and foto3 <> "-" then
	img_liputan = foto3
else
if foto1 = "-" and foto2 = "-"  and foto3 = "-" then
	img_liputan = "images/berita/blank.jpg"
end if	
end if
end if
end if	
	

If len(desk_liputan) > intHowManyCharw then
	d_liputan = left(decodeString(desk_liputan),intHowManyCharw) & "  ...........&nbsp;"
else
	d_liputan = desk_liputan
End If
%>												
													<tr>
														<td width="300" valign="top">
														
														<img border="1" src="<%=img_liputan%>" width="285" height="200"></td>
														<td valign="top"><b>
														<font size="2" color="#3399FF"><%=ucase(judul_liputan)%></font></b><br>
														<i><b><%=formatdatetime(tgl_liputan,1)%></b></i><br>
														Dilaporkan oleh : <%=rs("oleh")%>
														<br><br>
														<%=d_liputan%> [ 
														<a target="_top" href="baca_liputan.asp?id=<%=rs("id")%>">Baca Lebih Lanjut</a> ]</td>
													</tr>
													<tr>
														<td width="184">&nbsp;</td>
														<td valign="top">&nbsp;</td>
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
												<td valign="top" style="padding:5px;">
<%
akt = "T"
tidakbisa = "1000088"
tidakbisa2 = "1010253"
tidakbisa3 = "1018030"
intHowManyChar = 500
rs.Open "SELECT * FROM new_kesan WHERE sta like '"&akt&"' and kta <> '"&tidak&"' and kta <> '"&tidakbisa&"' and kta <> '"&tidakbisa2&"' and kta <> '"&tidakbisa3&"' order by rand() limit 1",conn
	if rs.bof then
	else
		isi_kesan1 = rs("deskripsi")
		id_kesan1 = rs("kta")
	end if
rs.Close
rs.Open "SELECT uid,foto FROM member WHERE kta like '"&id_kesan1&"'",conn
	if rs.bof then
	else
		nama_kesan1 = ucase(rs("uid"))
		foto_kesan1 = rs("foto")
	end if
rs.Close   
If len(isi_kesan1) > intHowManyChar then
	isi_kesan1 = left(decodeString(isi_kesan1),intHowManyChar) & "  ...........&nbsp;"
else
	isi_kesan1 = isi_kesan1
End If

   
rs.Open "SELECT * FROM new_kesan WHERE sta like '"&akt&"' and kta <> '"&id_kesan1&"' and kta <> '"&tidak&"' and kta <> '"&tidakbisa&"' and kta <> '"&tidakbisa2&"' and kta <> '"&tidakbisa3&"' order by rand() limit 1",conn
	if rs.bof then
	else
		isi_kesan2 = rs("deskripsi")
		id_kesan2 = rs("kta")
	end if
rs.Close
rs.Open "SELECT uid,foto FROM member WHERE kta like '"&id_kesan2&"'",conn
	if rs.bof then
	else
		nama_kesan2 = ucase(rs("uid"))
		foto_kesan2 = rs("foto")
	end if
rs.Close 
If len(isi_kesan2) > intHowManyChar then
	isi_kesan2 = left(decodeString(isi_kesan2),intHowManyChar) & "  ...........&nbsp;"
else
	isi_kesan2 = isi_kesan2
End If

rs.Open "SELECT * FROM new_kesan WHERE sta like '"&akt&"' and kta <> '"&id_kesan1&"' and kta <> '"&id_kesan2&"' and kta <> '"&tidak&"' and kta <> '"&tidakbisa&"' and kta <> '"&tidakbisa2&"' and kta <> '"&tidakbisa3&"' order by rand() limit 1",conn
	if rs.bof then
	else
		isi_kesan3 = rs("deskripsi")
		id_kesan3 = rs("kta")
	end if
rs.Close
rs.Open "SELECT uid,foto FROM member WHERE kta like '"&id_kesan3&"'",conn
	if rs.bof then
	else
		nama_kesan3 = ucase(rs("uid"))
		foto_kesan3 = rs("foto")
	end if
rs.Close
If len(isi_kesan3) > intHowManyChar then
	isi_kesan3 = left(decodeString(isi_kesan3),intHowManyChar) & "  ...........&nbsp;"
else
	isi_kesan3 = isi_kesan3
End If

rs.Open "SELECT * FROM new_kesan WHERE sta like '"&akt&"' and kta <> '"&id_kesan1&"' and kta <> '"&id_kesan2&"' and kta <> '"&id_kesan3&"' and kta <> '"&tidak&"' and kta <> '"&tidakbisa&"' and kta <> '"&tidakbisa2&"' and kta <> '"&tidakbisa3&"' order by rand() limit 1",conn
	if rs.bof then
	else
		isi_kesan4 = rs("deskripsi")
		id_kesan4 = rs("kta")
	end if
rs.Close
rs.Open "SELECT uid,foto FROM member WHERE kta like '"&id_kesan4&"'",conn
	if rs.bof then
	else
		nama_kesan4 = ucase(rs("uid"))
		foto_kesan4 = rs("foto")
	end if
rs.Close
If len(isi_kesan4) > intHowManyChar then
	isi_kesan4 = left(decodeString(isi_kesan4),intHowManyChar) & "  ...........&nbsp;"
else
	isi_kesan4 = isi_kesan4
End If

rs.Open "SELECT * FROM new_kesan WHERE sta like '"&akt&"' and kta <> '"&id_kesan1&"' and kta <> '"&id_kesan2&"' and kta <> '"&id_kesan3&"' and kta <> '"&id_kesan4&"' and kta <> '"&tidak&"' and kta <> '"&tidakbisa&"' and kta <> '"&tidakbisa2&"' and kta <> '"&tidakbisa3&"' order by rand() limit 1",conn
	if rs.bof then
	else
		isi_kesan5 = rs("deskripsi")
		id_kesan5 = rs("kta")
	end if
rs.Close
rs.Open "SELECT uid,foto FROM member WHERE kta like '"&id_kesan5&"'",conn
	if rs.bof then
	else
		nama_kesan5 = ucase(rs("uid"))
		foto_kesan5 = rs("foto")
	end if
rs.Close
If len(isi_kesan5) > intHowManyChar then
	isi_kesan5 = left(decodeString(isi_kesan5),intHowManyChar) & "  ...........&nbsp;"
else
	isi_kesan5 = isi_kesan5
End If
%>

<div style="padding:1px">
<font style="font:bold 20px verdana;color:#3399FF;"><b> Kesan dan Harapan Distributor </b></font>
<br>
<table cellpadding="0" cellspacing="0" style="padding:5px;border:2px solid #DDDDDD;">
		<tr bgcolor="#EEEEEE">
		<td align="center" valign="top" width="190" style="padding:10px;"><img border="2" src="<%=foto_kesan1%>" height="120"></td>
		<td width="5" bgcolor="#FFFFFF"></td>
		<td align="center" valign="top" width="190" style="padding:10px;"><img border="2" src="<%=foto_kesan2%>" height="120"></td>
		<td width="5" bgcolor="#FFFFFF"></td>
		<td align="center" valign="top" width="190" style="padding:10px;"><img border="2" src="<%=foto_kesan3%>" height="120"></td>
		</tr >
		<tr><td height="5"></td><td></td><td></td><td></td><td></td></tr>
		<tr bgcolor="#EEEEEE">
		<td valign="top" width="190" style="padding:10px;"><b><font color="#9900CC"><%=nama_kesan1%></font></b><br><%=isi_kesan1%></td>
		<td width="5" bgcolor="#FFFFFF"></td>
		<td valign="top" width="190" style="padding:10px;"><b><font color="#9900CC"><%=nama_kesan2%></font></b><br><%=isi_kesan2%></td>
		<td width="5" bgcolor="#FFFFFF"></td>
		<td valign="top" width="190" style="padding:10px;"><b><font color="#9900CC"><%=nama_kesan3%></font></b><br><%=isi_kesan3%></td>
		</tr>
</table>
</div>        
<br>
<img src="images/LUXcar.jpg">	
	
	
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
</table>

</body>

</html>
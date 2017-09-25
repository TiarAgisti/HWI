<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
<!--#Include File=dbcon/opendbALL.asp-->
<html>

<head>
<meta http-equiv="Content-Language" content="id">
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
</head>

<body>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td>&nbsp;</td>
	</tr>
</table>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
		<td valign="top">
<%
kepirok = 0
apa = request("tipe_sumber")
id = request("id")
intHowManyCharw = 250
sss = "T"
akt = "T"
if apa = "motivasi" then
	rs.Open "SELECT * FROM new_komen_motiv WHERE sta like '"&akt&"' and noid like '"&id&"' order by tgl desc limit 500",conn
else
if apa = "liputan" then
	rs.Open "SELECT * FROM new_komen_liputan WHERE sta like '"&akt&"' and noid like '"&id&"' order by tgl desc limit 500",conn
else
if apa = "berita" then
	rs.Open "SELECT * FROM new_komen_berita WHERE sta like '"&akt&"' and noid like '"&id&"' order by tgl desc limit 500",conn
end if	
end if
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
for aaaeqSSS = 1 to 500
if rs.eof = True then exit for
kepirok = kepirok + 1
sdesk_komen = rs("deskripsi")
If len(sdesk_komen) > intHowManyCharw then
	singkat_komen = left(decodeString(sdesk_komen),intHowManyCharw) & "  ...........&nbsp;"
else
	singkat_komen = sdesk_komen
End If

sapa = rs("kta")
rsALL.Open "SELECT uid,kta,foto FROM member WHERE kta like '"&sapa&"' and sta like '"&sss&"'",connALL
	if rsALL.bof then
		oleh = "Anonymouse"
		foto_komen = "-"
	else
		oleh = rsALL("uid")		
		foto_komen = rsALL("foto")
	end if
rsALL.Close
if foto_komen = "-" or isnull(foto_komen) = true then
	foto_komen = "-"
else
	foto_komen = foto_komen
end if		

if kepirok mod 2 = 0 then
	bg = "#FFFFCE"
else
	bg = "#E1FFE1"
end if		
%>			
			<tr>
				<td valign="top">
				<%if foto_komen <> "-" then %>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td width="60" valign="top" bgcolor="<%=bg%>">
						<img border="1" src="<%=foto_komen%>" width="52" height="63"></td>
						<td valign="top" bgcolor="<%=bg%>"><%=singkat_komen%><br>
						<i><b>(<%=ucase(oleh)%>)</b></i></td>
					</tr>
				</table>
				<%else%>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top" bgcolor="<%=bg%>">
						<%=singkat_komen%><br>
						<i><b>(<%=ucase(oleh)%>)</b></i>					
						</td>
					</tr>
				</table>
				<%end if%>
				</td>
			</tr>
		</table>
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td><hr color="#C0C0C0" size="1"></td>
			</tr>
		</table>
	</td>
<%  
rs.movenext
next
end if
if rs.eof = True then
end if
rs.Close
set rs=nothing
Conn.Close
set conn=nothing

set rsALL=nothing
ConnALL.Close
set connALL=nothing
%>		
	</tr>		
</table>
</body>

</html>
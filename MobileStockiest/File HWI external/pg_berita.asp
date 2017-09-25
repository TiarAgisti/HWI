<table border="0" cellpadding="0" cellspacing="0" width="100%"
style="
	
	background:#9C0;
	-moz-border-radius:10px;
    border-radius:10px;">
	<tr>
				<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td>
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td style="padding:10px;">
								<strong><font size="4" color="#FFFFFF">UPDATE BERITA </font></strong><hr /></td>
							</tr>
						</table>
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td>
								
								<div align="center">
<%
banyak = session("okehberita")
if banyak = "" then
	banyak = 4
else
	banyak = banyak
end if

akt = "T"
intHowManyCharw = 300
rs.Open "SELECT * FROM berita WHERE sta like '"&akt&"' order by tgl desc limit "&banyak&"",conn

	if rs.eof<>True then

	if goneqSS <> 0 then
		 for aaeeqSS = 1 to goneqSS
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if
%>								
									<table style="background:#FFC;padding:5px;-moz-border-radius:5px;
    border-radius:5px;"" border="0" cellpadding="0" cellspacing="0" width="92%">
<%
for aaaeqSSS = 1 to banyak
if rs.eof = True then exit for
judul_berita = rs("title")
tgl_berita = rs("tgl")
desk_berita = rs("isi")

if len(desk_berita) > intHowManyCharw then
	d_berita = left(decodeString(desk_berita),intHowManyCharw) & "  ...........&nbsp;"
else
	d_berita = desk_berita
End If
%>										
										<tr>
											<td valign="top">
											<font color="red"><%=formatdatetime(tgl_berita,1)%></font><a href="baca_berita.asp?id=<%=rs("id")%>" target="_top"><font color="#000000"><br>
											</font><font color="#030"><b><%=ucase(judul_berita)%></b></font></a><font color="#000000"><br><br><%=d_berita%><br>[ 
											<a href="baca_berita.asp?id=<%=rs("id")%>" target="_top">
											Baca Lebih Lanjut</a> ]<br><br>
											</font></td>
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
						</table>
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td height="20" valign="middle">&nbsp;
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
</table>

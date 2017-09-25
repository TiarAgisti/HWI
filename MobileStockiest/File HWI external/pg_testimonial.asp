<%
akt = "T"
intHowManyCharw = 1500
balik = 200
kurang = 7
for dr = 1 to balik
kosong = "-"
rs.Open "SELECT * FROM testi_prod WHERE sta like '"&akt&"' and foto <> '"&kosong&"' and tgl > '2013-03-01' order by rand() LIMIT 1",conn
if rs.bof then
else
	desk_testi_prod = rs("isi")
	if len(desk_testi_prod) < kurang then
		desk_testi_prod = ""
	else
		tgl_testi_prod = rs("tgl")
		sapas = rs("kta")
		ulasan_testi_prod = rs("uraian")
		id_testi = rs("id")
		kirims  = rs("dikirim")
		nile_testis = rs("nilai")
		fotot = rs("foto")
		rs.Close
		exit for
	End If
end if
rs.Close
dr = dr + 1
if dr > balik then
exit for
end if 
next

if len(desk_testi_prod) > intHowManyCharw then
	d_testi_prod = left(decodeString(desk_testi_prod),intHowManyCharw) & "  ...........&nbsp;"
else
	d_testi_prod = desk_testi_prod
End If

if sapas <> "-" then
	rs.Open "SELECT kta,uid, kota FROM member WHERE kta like '"&sapas&"'",conn
		if rs.bof then
			dikirim_testi = "Anonymous"
		else
			dikirim_namas = ucase(rs("uid"))
			dikirim_kotas = ucase(rs("kota"))			
			if isnull(dikirim_kotas) = false then
				dikirim_testi = cstr(dikirim_namas)+" - "+cstr(dikirim_kotas)
			else
				dikirim_testi = cstr(dikirim_namas)
			end if	
		end if
	rs.Close
else	
if kirims <> "-" then
	dikirim_testi = kirims
end if	
end if
%>	
<style>
img.left {
	float: left;
	margin: 7px 7px 7px 7px;
}
</style>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tr>
				<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td>
						
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td><table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td style="padding:10px;">
								<strong><font size="4" color="#0099FF">TESTIMONIAL </font></strong><hr /></td>
							</tr>
						</table>
								</td>
									</tr>
								</table></td></tr>
							<tr>
								<td>	<div align="center">					
									<table border="0" cellpadding="0" cellspacing="0" width="92%">							
										<tr align="left">
											<td valign="top" style="background:#DDDDDD;padding:10px;">																					
											<font color="#003300"><%=formatdatetime(tgl_testi_prod,1)%></font><font color="#000000"><br>
											<img border="2" class="left" src="<%=fotot%>" width="90" height="110"><%=d_testi_prod%>
											
											<font color="#000000">[ 
											<a href="baca_testimonial_produk.asp?id=<%=id_testi%>&asal=kesaksian" target="_top">
											Baca Lebih Lanjut</a> ]<br>
											</font>											
											<b>Dikirim oleh : </b><%=dikirim_testi%> 
											</font><br>
									<%
									session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
									%>																															
									<img border="0" src="images/starimages/<%=formatnumber(nile_testis,1)%>.gif" width="64" height="12">
									<%
									session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
									%>												
											<br>												
											<br>
											<%if ulasan_testi_prod <> "-" then %>
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td valign="top">
													<div align="center">
																<table border="0" cellpadding="0" cellspacing="0" width="93%">
																	<tr>
																		<td></td>
																	</tr>
																	<tr>
																		<td><i>
																		<%=ulasan_testi_prod%></i></td>
																	</tr>
																	<tr>
																		<td></td>
																	</tr>
																</table>
															</div>
													
													
													</td>
												</tr>
											</table>
											<%end if%>
											</td>
										</tr>											
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


<!--#Include File=dbcon/opendbALL.asp-->
<!--#Include File=dbcon/opendb.asp-->

<head>
<meta http-equiv="Content-Language" content="id">
</head>

<%
galinis = date()
blna = month(galinis)
thun = year(galinis)

''''''''''''''''''''''''''''''''''''''''''''''''
' ambil data sponsoring FT
''''''''''''''''''''''''''''''''''''''''''''''''
pkd = "T"
paketnya = "FT" ' paket FT pointnya 5
rs.Open "SELECT direk,count(id) FROM st_sale_daftar where pakai like '"&pkd&"' and month(tgl)='"&blna&"' and year(tgl)='"&thun&"' and paket like '%"&paketnya&"%' group by direk order by count(id) desc limit 100",conn	
	if rs.eof<>True then

	if goneqSS <> 0 then
		 for aaeeqSS = 1 to goneqSS
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if
for aaaeqSSS = 1 to 200
if rs.eof = True then exit for 
	sapa = rs("direk")
	jumpaket = clng(rs("count(id)"))*5

	rsALL.Open "SELECT uid,kota FROM member where kta like '"&sapa&"'",connALL
		if rsALL.bof then
			namaspone = ""
			kotaspone = "JAKARTA PUSAT"
		else
			namaspone = ucase(rsALL("uid"))
			kotaspone = ucase(rsALL("kota"))
		end if	
	rsALL.close
	
	if kotaspone = "-" or kotaspone = "" then
		kotaspone = "XXX"
	end if	
		
	rsALL.Open "SELECT * FROM tabbintangsponsor where kta like '"&sapa&"' and bulan='"&blna&"' and tahun='"&thun&"'",connALL,3,3	
		if rsALL.bof then
			rsALL.addnew
				rsALL("bulan") = blna
				rsALL("tahun") = thun
				rsALL("kta") = sapa
				rsALL("ft") = jumpaket
				rsALL("reg") = 0
				rsALL("total") = jumpaket 
				rsALL("nama") = namaspone
				rsALL("kota") = kotaspone
			rsALL.update
		else
			rsALL.update
				rsALL("ft") = jumpaket
				rsALL("total") = jumpaket
				rsALL("nama") = namaspone
				rsALL("kota") = kotaspone
			rsALL.update
		end if	
	rsALL.close

rs.movenext
next
end if
if rs.eof = True then
end if
rs.Close



''''''''''''''''''''''''''''''''''''''''''''''''
' ambil data sponsoring REG
''''''''''''''''''''''''''''''''''''''''''''''''
pkd = "T"
paketnya = "NPR"
rs.Open "SELECT direk,count(id) FROM st_sale_daftar where pakai like '"&pkd&"' and month(tgl)='"&blna&"' and year(tgl)='"&thun&"' and paket like '%"&paketnya&"%' group by direk order by count(id) desc limit 100",conn	
	if rs.eof<>True then

	if goneqSS <> 0 then
		 for aaeeqSS = 1 to goneqSS
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if
for aaaeqSSS = 1 to 200
if rs.eof = True then exit for 
	sapa = rs("direk")
	jumpaket = clng(rs("count(id)"))
	rsALL.Open "SELECT uid,kota FROM member where kta like '"&sapa&"'",connALL
		if rsALL.bof then
			namaspone = ""
			kotaspone = "JAKARTA PUSAT"
		else
			namaspone = ucase(rsALL("uid"))
			kotaspone = ucase(rsALL("kota"))
		end if	
	rsALL.close

	
	if kotaspone = "-" or kotaspone = "" then
		kotaspone = "XXX"
	end if	
		
	rsALL.Open "SELECT * FROM tabbintangsponsor where kta like '"&sapa&"' and bulan='"&blna&"' and tahun='"&thun&"'",connALL,3,3	
		if rsALL.bof then
			rsALL.addnew
				rsALL("bulan") = blna
				rsALL("tahun") = thun
				rsALL("kta") = sapa
				rsALL("ft") = 0
				rsALL("reg") = jumpaket
				rsALL("total") = jumpaket 
				rsALL("nama") = namaspone
				rsALL("kota") = kotaspone				 
			rsALL.update
		else
			rsALL.update
				rsALL("reg") = jumpaket
				rsALL("total") = clng(rsALL("ft"))+jumpaket
				rsALL("nama") = namaspone
				rsALL("kota") = kotaspone				
			rsALL.update
		end if	
	rsALL.close

rs.movenext
next
end if
if rs.eof = True then
end if
rs.Close
%><div align="center">
	<table border="1" cellpadding="8" style="border-collapse: collapse" width="97%" cellspacing="5" bgcolor="#FFFFEA" bordercolor="#808080">
		<tr>
			<td valign="top">
			<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
				<tr>
					<td>
					<p align="center"><b><font size="4">PAPAN KOMPETISI BINTANG 
					SPONSORING<br>
					Periode bulan<font color="#FF0000" size="3"> <%=monthname(blna)%>&nbsp;<%=thun%></font></font></b></td>
				</tr>
				<tr>
					<td>
					<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
						<tr>
							<td valign="top">
							<table border="1" style="border-collapse: collapse" width="100%" cellspacing="1" bordercolor="#808080">
								<tr>
									<td width="15%" align="center" bgcolor="#800000" height="20">
									<font color="#FFFFFF"><b>RATING STAR</b></font></td>
									<td width="50%" align="center" bgcolor="#800000" height="20">
									<font color="#FFFFFF"><b>DISTRIBUTOR</b></font></td>
									<td width="35%" align="center" bgcolor="#800000" height="20">
									<font color="#FFFFFF"><b>KOTA</b></font></td>
								</tr>
							</table>
							<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
								<tr>
									<td valign="top">
<%
orak = "XXX"
rs.Open "SELECT * FROM tabbintangsponsor where bulan='"&blna&"' and tahun='"&thun&"' and kota <> '"&orak&"' order by total DESC limit 10",conn	

	if rs.eof<>True then

	if goneqSS <> 0 then
		 for aaeeqSS = 1 to goneqSS
  		 if rs.eof=True then exit for
  		 rs.movenext
  		 next
  		 else
   end if
%>								
									<table border="1" style="border-collapse: collapse" width="100%" cellspacing="1" bordercolor="#808080">
<%
for aaaeqSSS = 1 to 20
if rs.eof = True then exit for 

totemu = clng(rs("total"))

if totemu >= 0 and totemu <=20 then
	imgbint = "images/1_BS.jpg"
else
if totemu >= 21 and totemu <=50 then
	imgbint = "images/2_BS.jpg"
else
if totemu >= 51 and totemu <=100 then
	imgbint = "images/3_BS.jpg"
else
if totemu >= 101 and totemu <=200 then
	imgbint = "images/4_BS.jpg"
else
if totemu >= 201 then
	imgbint = "images/5_BS.jpg"
end if
end if
end if	
end if
end if	
%>									
										<tr>
											<td width="15%">
											<img border="0" src="<%=imgbint%>" width="67" height="16"></td>
											<td width="50%">&nbsp;[ <%=rs("kta")%> ] <%=rs("nama")%></td>
											<td width="35%">&nbsp;<%=rs("kota")%></td>
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
									</td>
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
					<td>Pastikan nama anda tercantum pada papan kompetisi 
					bintang sponsoring ini. <b>( 3 BESAR BULAN LALU )</b></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>

				<TR><TD>
<%
orak = "XXX"
blnalu = blna - 1
thunlu = thun
if blnalu = 0 then
blnalu = 12
thunlu = thunlu - 1
end if

rs.Open "SELECT * FROM tabbintangsponsor where bulan='"&blnalu&"' and tahun='"&thunlu&"' and kota <> '"&orak&"' order by total DESC limit 3",conn	
%><table border="1" style="border-collapse: collapse" width="100%" cellspacing="1" bordercolor="#808080">
<%
for aaaeqSSS = 1 to 20
if rs.eof = True then 
exit for 
end if
totemu = clng(rs("total"))

if totemu >= 0 and totemu <=20 then
	imgbint = "images/1_BS.jpg"
else
if totemu >= 21 and totemu <=50 then
	imgbint = "images/2_BS.jpg"
else
if totemu >= 51 and totemu <=100 then
	imgbint = "images/3_BS.jpg"
else
if totemu >= 101 and totemu <=200 then
	imgbint = "images/4_BS.jpg"
else
if totemu >= 201 then
	imgbint = "images/5_BS.jpg"
end if
end if
end if	
end if
end if	
%>									
										<tr>
											<td width="15%">
											<img border="0" src="<%=imgbint%>" width="67" height="16"></td>
											<td width="50%">&nbsp;[ <%=rs("kta")%> ] <%=rs("nama")%></td>
											<td width="35%">&nbsp;<%=rs("kota")%></td>
										</tr>
<%  
rs.movenext
next

rs.Close
%>											
									</table>

</TD></TR>
			</table>
			</td>
		</tr>
	</table>
</div>

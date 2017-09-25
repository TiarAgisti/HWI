<%
distributor = request("ranking")
totpv = clng(request("totpv"))

if distributor = "" then
	distributor = "Distributor"
else
	distributor = distributor
end if

if totpv = "" then
	totpv = 200
else
	if isnumeric(totpv)=true then
		if totpv < 200 then
			totpv = totpv
		else
			totpv = totpv
		end if
	else
		totpv = 200
	end if	
end if			

if totpv >= 200 then
	if distributor = "Distributor" then
		potong = 150
	else
		potong = 200
	end if		

	y = totpv - potong
	x = y / 2
	bonus = x * 1000
else
	potong = 0
	x = 0
	y = 0
	bonus = 0
end if
%>

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
<table border="0" cellpadding="0" cellspacing="0" width="270">
	<tr>
		<td>Silahkan masukan nilai-nilai anda untuk memperoleh hasil simulasi 
		perhitungan bonus productivity anda.</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td valign="top">
		<form name="simulasi_prod" method="post" action="pg_simulasi_prod.asp" target="_self">
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td width="87">Ranking Anda</td>
				<td width="14" align="center">:</td>
				<td>
					<select size="1" name="ranking" style="font-size: 8pt; font-family: Verdana">
					<option selected value="Distributor">Distributor</option>
					<option value="Sapphier">Sapphier</option>
					<option value="Ruby">Ruby</option>
					<option value="Pearl">Pearl</option>
					<option value="Emerald">Emerald</option>
					<option value="Diamond">Diamond</option>
					<option value="Double Diamond">Double Diamond</option>
					<option value="Crown">Crown</option>
					<option value="Crown Ambassador">Crown Ambassador</option>
					</select>
				</td>
			</tr>
			<tr>
				<td width="87">Total PV belanja</td>
				<td width="14" align="center">:</td>
				<td>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td width="37">
				<input type="text" name="totpv" size="3" value="200" style="font-size: 8pt; font-family: Verdana"></td>
						<td><i>desimal pakai , (koma)</i></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td width="87">&nbsp;</td>
				<td width="14" align="center">&nbsp;</td>
				<td>
				<input type="submit" name="btsub" value="Hitung Bonus" style="font-size: 8pt; font-family: Verdana"></td>
				</form>
			</tr>
			</table>
		</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td><b>HASIL PERHITUNGAN</b></td>
	</tr>
	<tr>
		<td valign="top">
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td width="86">Ranking Anda</td>
				<td width="14" align="center">:</td>
				<td><%=distributor%></td>
			</tr>
			<tr>
				<td width="86">Total PV belanja</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(totpv,2)%></td>
			</tr>
			<tr>
				<td width="86">Faktor Pemotong</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(potong,0)%></td>
			</tr>
			<tr>
				<td width="86">Nilai Y</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(y,2)%></td>
			</tr>
			<tr>
				<td width="86">Nilai X</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(x,2)%></td>
			</tr>			
			<tr>
				<td width="86">Productivity Point</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(x,2)%></td>
			</tr>
			<tr>
				<td width="86">Quadro Plan Point</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(x+potong,2)%></td>
			</tr>
			<tr>
				<td width="86">Jumlah Bonus</td>
				<td width="14" align="center">:</td>
				<td>Rp <%=formatnumber(bonus,0)%></td>
			</tr>
			<tr>
				<td width="86">PV Pribadi</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(totpv,2)%></td>
			</tr>
		</table>
		</td>
	</tr>
	</table>
<table border="0" cellpadding="0" cellspacing="0" width="270">
	<tr>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td>
		<p align="center"> 
																<font color="#FF0000" size="3">
		Belanja 
																top up tidak 
																menghasilkan 
																productivity 
																bonus !</font></td>
	</tr>
</table>


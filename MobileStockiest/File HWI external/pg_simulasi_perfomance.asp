<%
kiri = request("kiri")
carry_kiri = request("kiri_carry")
kanan = request("kanan")
carry_kanan = request("kanan_carry")
n = request("nfaktor")

if n = "" then
	n = 0.950
else
	if isnumeric(n)=true then
		if n < 0 then
			n = 0.950
		else
		if n > 1 then
			n = 0.950
		else
			n = n	
		end if
		end if
	else
		n = 0.950
	end if	
end if

if kiri = "" then
	kiri = 20000
else
	if isnumeric(kiri)=true then
		if kiri < 0 then
			kiri = 20000
		else
			kiri = kiri
		end if
	else
		kiri = 20000
	end if	
end if
if carry_kiri = "" then
	carry_kiri = 0
else
	if isnumeric(carry_kiri)=true then
		if carry_kiri < 0 then
			carry_kiri = 0
		else
			carry_kiri = carry_kiri
		end if
	else
		carry_kiri = 0
	end if	
end if

if kanan = "" then
	kanan = 20000
else
	if isnumeric(kanan)=true then
		if kanan < 0 then
			kanan = 20000
		else
			kanan = kanan
		end if
	else
		kanan = 20000
	end if	
end if
if carry_kanan = "" then
	carry_kanan = 0
else
	if isnumeric(carry_kanan)=true then
		if carry_kanan < 0 then
			carry_kanan = 0
		else
			carry_kanan = carry_kanan
		end if
	else
		carry_kanan = 0
	end if	
end if

if carry_kiri > 0 and carry_kanan > 0 then
	carry_kiri = 0
	carry_kanan = 0
else
	carry_kiri = carry_kiri
	carry_kanan = carry_kanan
end if		

totpvkiri = kiri + carry_kiri
totpvkanan = kanan+carry_kanan

if totpvkanan > totpvkiri then
	kakikecil = totpvkiri
	kakinya = "Kaki Kiri"
	carrynya = totpvkanan - totpvkiri
	kakicarry = "Kaki Kanan"
else
if totpvkiri > totpvkanan then
	kakikecil = totpvkanan
	kakinya = "Kaki Kanan"
	carrynya = totpvkiri - totpvkanan
	kakicarry = "Kaki Kiri"
else
if totpvkiri = totpvkanan then
	kakikecil = totpvkanan
	kakinya = "Kaki Kanan"
	carrynya = 0
	kakicarry = ""
end if
end if		
end if	

x = (kakikecil * 10)/100	
bonus = ((x*2000)*n)
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
		perhitungan bonus performance anda <i>(isikan dengan tanda koma untuk 
		desimal)</i>.</td>
	</tr>
	<tr>
		<td>&nbsp;</td>
	</tr>
	<tr>
		<td valign="top">
		<form name="simulasi_perfo" method="post" action="pg_simulasi_perfomance.asp" target="_self">
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td width="87">Pv Kaki Kiri</td>
				<td width="14" align="center">:</td>
				<td>
					<table border="0" cellpadding="0" cellspacing="0" width="100%">
						<tr>
							<td width="32">
				<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="9" -->
				<input type="text" name="kiri" size="3" value="20000" style="font-size: 8pt; font-family: Verdana" maxlength="9"></td>
							<td width="80">
							<p align="right">Carry Forward&nbsp; </td>
							<td width="8" align="center">:</td>
							<td>
				<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="9" -->
				<input type="text" name="kiri_carry" size="3" value="0" style="font-size: 8pt; font-family: Verdana" maxlength="9"></td>
						</tr>
					</table>
				</td>
			</tr>
			<tr>
				<td width="87">PV Kaki Kanan</td>
				<td width="14" align="center">:</td>
				<td>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td width="32">
				<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="9" -->
				<input type="text" name="kanan" size="3" value="24000" style="font-size: 8pt; font-family: Verdana" maxlength="9"></td>
						<td width="80">
						<p align="right">Carry Forward&nbsp; </td>
						<td width="8" align="center">:</td>
						<td>
				<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="9" -->
				<input type="text" name="kanan_carry" size="3" value="0" style="font-size: 8pt; font-family: Verdana" maxlength="9"></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td width="87">n Faktor (asumsi)</td>
				<td width="14" align="center">:</td>
				<td>
				<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="1" i-maximum-length="5" --><input type="text" name="nfaktor" size="3" value="0,95" style="font-size: 8pt; font-family: Verdana" maxlength="5"></td>
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
				<td width="86">PV Kaki Kiri</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(kiri,2)%></td>
			</tr>
			<tr>
				<td width="86">Carry Forward</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(carry_kiri,2)%></td>
			</tr>
			<tr>
				<td width="86">Total PV kiri</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(totpvkiri,2)%></td>
			</tr>
			<tr>
				<td width="86">&nbsp;</td>
				<td width="14" align="center">&nbsp;</td>
				<td>&nbsp;</td>
			</tr>			
			<tr>
				<td width="86">PV Kaki Kanan</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(kanan,2)%></td>
			</tr>
			<tr>
				<td width="86">Carry Forward</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(carry_kanan,2)%></td>
			</tr>			
			<tr>
				<td width="86">Total pv kanan</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(totpvkanan,2)%></td>
			</tr>
			<tr>
				<td width="86">&nbsp;</td>
				<td width="14" align="center">&nbsp;</td>
				<td>&nbsp;</td>
			</tr>				
			<tr>
				<td width="86">Omzet Kaki Kecil</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(kakikecil,2)%>&nbsp;(Pada <%=kakinya%>)</td>
			</tr>
			<tr>
				<td width="86">Carry Forward</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(carrynya,2)%>&nbsp;(Pada <%=kakicarry%>)</td>
			</tr>
			<tr>
				<td width="86">&nbsp;</td>
				<td width="14" align="center">&nbsp;</td>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td width="86">Nilai x</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(x,2)%></td>
			</tr>
			<tr>
				<td width="86">Nilai n faktor</td>
				<td width="14" align="center">:</td>
				<td><%=formatnumber(n,2)%></td>
			</tr>			
			<tr>
				<td width="86">Jumlah Bonus</td>
				<td width="14" align="center">:</td>
				<td>Rp <%=formatnumber(bonus,2)%>,-</td>
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
		<td><u><b>Catatan</b></u></td>
	</tr>
	<tr>
		<td valign="top">
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td width="17" valign="top">1.</td>
				<td valign="top">Carry forward business center-1 akan hangus 
				apabila anda tidak melakukan tutup point sebesar 200 pv bagi 
				pemilik 1 BC.</td>
			</tr>
			<tr>
				<td width="17" valign="top">2.</td>
				<td valign="top">Carry forward pada business center-2 dan 
				business center-3 akan hangus apabila anda tidak tutup point 
				sebesar 300 pv bagi pemilik 3 BC.</td>
			</tr>
			<tr>
				<td width="17" valign="top">3.</td>
				<td valign="top">Carry forward hanya diperhitungkan pada bonus 
				performance saja dan tidak mempengaruhi kenaikan ranking dan 
				kualifikasi.</td>
			</tr>
		</table>
		</td>
	</tr>
</table>


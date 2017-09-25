
<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ****** ' 
'Application: HEALTH WEALTH INTERNATIONAL
'Author: Ir. Peter Sindoro
'Coding : August 2009
'Revised : - 
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ****** 
%>
<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/openDB.asp-->
<%
session("tema") = "home"
kode = request("kode")
rs.Open "SELECT * FROM st_barang where kode like '"&kode&"'",conn,3,3
	if rs.bof then			
	else
		rs.update
			rs("brosurdownload1") = rs("brosurdownload1")+1
			rs("brosurdownload2") = rs("brosurdownload2")+1	
		rs.update
		kodeprd = rs("kode")
		namaprd = rs("nama")
		info = rs("keterangan")
		brosur1 = rs("bthmb1")
		brosur2 = rs("bthmb2")
		size1 = rs("brosursize1")
		size2 = rs("brosursize2")
		brosurdon1 = rs("brosur1")
		brosurdon2 = rs("brosur2")
	end if
rs.Close
set rs=nothing
Conn.Close
set conn=nothing
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

</head>
<table border="1" cellpadding="2" width="100%" style="border-collapse: collapse" bordercolor="#808080">
	<tr>
		<td valign="top">
		<table border="0" cellpadding="0" cellspacing="0" width="100%" height="20" bgcolor="#6CB6FF">
			<tr>
				<td height="35">
				<p align="center"><b><font size="3" color="#FFFF00">DOWNLOAD BROSUR</font></b></td>
			</tr>
		</table>
		<table border="0" cellpadding="0" cellspacing="0" width="100%">
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>
				<p align="center"><b><font size="3"><%=namaprd%><br>
				</font></b><i><%=info%></i></td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td valign="top">
				<div align="center">
					<table border="0" cellpadding="0" cellspacing="0">
						<tr>
							<td valign="top">
							<img border="0" src="../<%=brosur1%>" width="289" height="400"></td>
							<td valign="top">
							<img border="0" src="../<%=brosur2%>" width="289" height="400"></td>
						</tr>
						<tr>
							<td valign="top">
							<p align="center">
							<a target="_blank" href="../<%=brosurdon1%>">Download 
							Sekarang</a><br>
							File Size : <font color="#FF0000"><b><%=formatnumber(size1,0)%></b></font> KB</td>
							<td valign="top">
							<p align="center">
							<a target="_blank" href="../<%=brosurdon2%>">Download 
							Sekarang</a><br>
							File Size : <font color="#FF0000"><b><%=formatnumber(size2,0)%></b></font> KB</td>
						</tr>
					</table>
				</div>
				</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td>&nbsp;</td>
			</tr>
		</table>
		</td>
	</tr>
</table>
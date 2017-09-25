<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->

<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******
' Application: HEALTH WEALTH INTERNATIONAL WEBSITE
' Author: Peter Sindoro
' Coding : Septmber 2009
' Revised : -
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ******     

idprod = request("prod_id")
sss = "T"
rs.Open "SELECT kode,nama,keterangan,foto_besar,pv,hd1,hd2,hd3,hk1,hk2,hk3 FROM st_barang WHERE sta like '"&sss&"' and kode like '"&idprod&"'",conn
	if rs.bof then
		ada = "F"
	else
		ada = "T"
		prd_desk = rs("keterangan")
		namaprd = rs("nama")
		fotoprd = rs("foto_besar")
		pv = rs("pv")
		hd1 = rs("hd1")
		hd2 = rs("hd2")
		hd3 = rs("hd3")
		hk1 = rs("hk1")
		hk2 = rs("hk2")
		hk3 = rs("hk3")
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

sumber = "http://www.healthwealthint.com/detail.asp?prod_id="&idprod
%>

<html>
<head>
<meta http-equiv="Content-Language" content="en-us">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<meta name="revisit-after" content="15 days">
<meta name="robots" content="index,follow">
<meta name="language" content="en-us">
<meta name="rating" content="General">
<meta name="resource-type" content="document">
<meta name="distribution" content="Global">
<TITLE>Health Wealth International :: <%=namaprd%></TITLE>
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

<body>

				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
						<table border="0" cellpadding="0" cellspacing="0" width="100%">
							<tr>
								<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="19" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b1.gif" width="19" height="14"></td>
										<td background="images/b2.gif" width="100%" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b2.gif" width="18" height="14"></td>
										<td width="21" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b3.gif" width="21" height="14"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td valign="top" background="images/b4.gif" width="10" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b4.gif" width="10" height="16"></td>
										<td valign="top" width="100%" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">										
										<div align="center">
										<table border="0" cellpadding="0" cellspacing="0" width="99%">
											<tr>
												<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
												&nbsp;</td>
											</tr>
											<tr>
												<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
																			
																			<table border="0" cellpadding="0" cellspacing="0" width="100%">
																				<tr>
																					<td width="256" valign="top">
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td valign="top">
																							<p align="center"></td>
																						</tr>
																						<tr>
																							<td>
																							<p align="center"><img border="0" src="<%=fotoprd%>"></td>
																						</tr>
																						<tr>
																							<td>
																							&nbsp;</td>
																						</tr>
																						<tr>
																							<td>
<form>
	<p align="center"><input type="button" value=" Print this page "
onclick="window.print();return false;" /></p>
</form> 																							
																							</td>
																						</tr>
																					</table>
																					<p align="center"><br></td>
																					<td valign="top"><b><font size="4" color="#3399FF">
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="100%"><b><font size="4" color="#3399FF"><%=namaprd%>&nbsp;( <%=idprod%> )</font></b></i><br>
																					<i><font color="#FF0000" size="2">
																					<b>pv : <%=formatnumber(pv,2)%></b></font></i><br></td>
																						</tr>
																					</table>
																					<br>
																					<table border="0" cellpadding="3" cellspacing="3" width="100%" bgcolor="#FFFFCE">
																						<tr>
																							<td><%=prddesk%></td>
																						</tr>
																					</table>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="86">Customer Star</td>
																							<td width="9">:</td>
																							<td>
									<%
									session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
									%>																															
									<img border="0" src="images/starimages/<%=formatnumber(testiprod_nil,1)%>.gif" width="64" height="12">
									<%
									session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
									intLocale = SetLocale(1057) ' setting desimal & local setting untuk indonesia
									%>																								
																							</td>
																						</tr>
																						<tr>
																							<td width="86">Testimonial Vote</td>
																							<td width="9">:</td>
																							<td>
																							<%=formatnumber(voteman,0)%> testimonial
																							</td>
																						</tr>
																						<tr>
																							<td width="86">&nbsp;</td>
																							<td width="9">&nbsp;</td>
																							<td>
																							&nbsp;</td>
																						</tr>
																					</table>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td>
																							&nbsp;</td>
																						</tr>
																					</table>
																					</font></b><font size="4" color="#3399FF">
																					<b>
																					<table border="0" cellpadding="0" cellspacing="0" width="100%">
																						<tr>
																							<td width="86">
																							<table border="0" cellpadding="0" cellspacing="0" width="100%">
																								<tr>
																									<td>&nbsp;</td>
																								</tr>
																							</table>
																							<b><font size="4" color="#3399FF">
																							<img border="0" src="images/logohwi.jpg" width="72" height="52" align="left"></td>
																							<td valign="bottom"><font size="1" color="#000000"><i>Source : <%=sumber%></i></font></td>
																						</tr>
																					</table>
																					</td>																					
																				</tr>
																			</table>
																			</td>
											</tr>
											<tr>
												<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
												&nbsp;</td>
											</tr>
											</table>
										</div>
										</td>
										<td valign="top" background="images/b5.gif" width="9" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b5.gif" width="9" height="16"></td>
									</tr>
								</table>
								<table border="0" cellpadding="0" cellspacing="0" width="100%">
									<tr>
										<td width="22" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b6.gif" width="22" height="14"></td>
										<td background="images/b7.gif" width="100%" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b7.gif" width="21" height="14"></td>
										<td width="18" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
										<img border="0" src="images/b8.gif" width="20" height="14"></td>
									</tr>
								</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td valign="top" style="font-family: Tahoma; font-size: 11px; color: #4F4F4F">
						&nbsp;</td>
					</tr>
					</table>
				
</body>

</html>
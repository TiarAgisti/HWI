<%
'***** START WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ****** ' 
'Application: HEALTH WEALTH INTERNATIONAL
'Author: Ir. Peter Sindoro
'Coding : August 2009
'Revised : - 
'***** END WARNING - REMOVAL OR MODIFICATION OF THIS CODE WILL VIOLATE THE LICENSE AGREEMENT ****** 
%>
<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
<!--#Include File=dbcon/opendbALL.asp-->
<%


%>
<html><body>
&nbsp;
<table border="1">
<tr><td>
Id</td><td>
Nama</td><td>
Jumlah</td><td>
Noinvoice</td></tr>
<%
'''Lihat DC'''''''

rs.Open "SELECT * FROM healthwealthint_com_hwi.st_sale_prd_det where kode like 'PRQQGPB' and tgl like '2013-07%' ",conn,3,3
muterku = 20000
for a = 1 to muterku
if rs.eof = True then 
	exit for 
	a = a + 1
end if
noinvoice = rs("noinvoice")
jumlah = rs("jumlah")

rsALL.Open "SELECT nodist,namadist FROM healthwealthint_com_hwi.st_sale_prd_head where noinvoice like '"&noinvoice&"' ",connALL,3,3
	if rsALL.bof then
	else
	nama = rsALL("namadist")
	no = rsALL("nodist")
	end if
rsALL.close
%>
<tr><td>
<%=no%></td><td>
<%=nama%></td><td>
<%=jumlah%></td><td>
<%=noinvoice%></td></tr>

<%

rs.movenext
if a > muterku then
exit for
end if
next 
rs.close 



set rs=nothing
		Conn.Close
		set conn=nothing
set rsALL=nothing
		ConnALL.Close
		set connALL=nothing
%></table>
</body></html>
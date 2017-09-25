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
bul = 10
tahun = year(date)
rs.Open "SELECT * FROM temp_mstour where kta not like '%-%' and bulan = "&bul&" and tahun = "&tahun&" ",conn,3,3
%>
<html><body>

<%
muterku = 20000
for a = 1 to muterku
if rs.eof = True then 
	exit for 
	a = a + 1
end if
kta = rs("kta")
kiri = rs("kiri")
kanan = rs("kanan")
rsALL.Open "SELECT kta,nama FROM tabdesc_stockist where (nama like 'PT. HEALTH WEALTH INTERNATIONAL' or nama like 'PT. HEALTH WEALTH INTERNATIONAL MS') and sta like 'T' and kta like '"&kta&"'",connALL,3,3
	if rsALL.bof then
	rs.update
	rs("kiri") = 0
	rs("kanan") = 0
	rs.update
	else
	end if
rsALL.close

rs.movenext
if a > muterku then
exit for
end if
next 
rs.close 
%>
go arrad go......
<%
set rs=nothing
		Conn.Close
		set conn=nothing
%>
</body></html>
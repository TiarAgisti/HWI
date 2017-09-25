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
&nbsp;<%
'''Lihat DC'''''''
rs.Open "SELECT subtot FROM healthwealthint_com_hwi.fax_order_dc_head where tgl like '2013-07%' and status = 9",conn,3,3
muterku = 20000
for a = 1 to muterku
if rs.eof = True then 
	exit for 
	a = a + 1
end if
subtot = rs("subtot")
if subtot < 1000000 then
jum = 0.2
end if
if subtot > 1000000 and subtot <= 5000000 then
jum = 1
end if
if subtot > 5000000 then
jum = subtot / 5000000
jum = int(jum)+1
end if
jum = jum * 5
%>
jum
<%=jum%>
<br><br>
<%
go = go +jum
rs.movenext
if a > muterku then
exit for
end if
next 
rs.close 


%>
<%
'''Lihat MC'''''''
rs.Open "SELECT * FROM healthwealthint_com_hwi.fax_order_mc_head where tgl like '2013-07%' and status = 9 and nopos like 'b-000'",conn,3,3
muterku = 20000
for a = 1 to muterku
if rs.eof = True then 
	exit for 
	a = a + 1
end if
subtot = rs("subtot")
if subtot < 1000000 then
jum = 0.2
end if
if subtot > 1000000 and subtot <= 5000000 then
jum = 1
end if
if subtot > 5000000 then
jum = subtot / 5000000
jum = int(jum)+1
end if
jum = jum * 5
%>
jum
<%=jum%>
<br><br>
<%
go = go +jum
rs.movenext
if a > muterku then
exit for
end if
next 
rs.close 


%>
<%
'''Lihat MC'''''''
rs.Open "SELECT * FROM healthwealthint_com_hwi.st_sale_prd_head where tgl like '2013-07%' and nopos like 'b-000'",conn,3,3
muterku = 20000
for a = 1 to muterku
if rs.eof = True then 
	exit for 
	a = a + 1
end if
subtot = rs("subtot")
if subtot < 1000000 then
jum = 0.2
end if
if subtot > 1000000 and subtot <= 5000000 then
jum = 1
end if
if subtot > 5000000 then
jum = subtot / 5000000
jum = int(jum)+1
end if
jum = jum * 5
%>
jum
<%=jum%>
<br><br>
<%
go = go +jum
rs.movenext
if a > muterku then
exit for
end if
next 
rs.close 


%>

go = <%=go%> 
<%
set rs=nothing
		Conn.Close
		set conn=nothing
set rsALL=nothing
		ConnALL.Close
		set connALL=nothing
%>
</body></html>
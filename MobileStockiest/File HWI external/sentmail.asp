<%
noid = request("kdpos")
nama = request("namadis")
notelp = request("notelp")
emel = request("email")
tema = request("subyek")
penerima = request("tujuan")
isi = request("detail")

if noid = "" then
	noid = "-"
else
	noid = noid
end if
		
if emel = "" then
	eml = nama
	emel = "-"
else
	eml = emel
	emel = emel
end if
		
if nama = "" then
%>
<script language="javascript">
<!--
window.alert ("Anda belum mengisikan nama lengkap anda, silahkan isikan terlebih dahulu.");  
window.location = "contact.asp" ;
//-->
</script>
<%
end if

if notelp = "" then
%>
<script language="javascript">
<!--
window.alert ("Anda belum mengisikan nomor telepon anda yang dapat dihubungi, silahkan isikan terlebih dahulu.");  
window.location = "contact.asp" ;
//-->
</script>
<%
end if

if isi = "" then
%>
<script language="javascript">
<!--
window.alert ("Anda belum menuliskan isi pesan kontak anda, silahkan isikan terlebih dahulu.");  
window.location = "contact.asp" ;
//-->
</script>
<%
end if
%>

<%
gabung = now()
regips = request.servervariables("remote_addr")
strBodyA1As1 = ""
set mailA1As1 = Server.CreateOBject( "JMail.Message" )
mailA1As1.Logging = true
mailA1As1.silent = true
mailA1As1.From = emel
mailA1As1.FromName = "Contact from webmail : "&nama
mailA1As1.Subject = tema
mailA1As1.AddRecipient "support@healthwealthint.com"
mailA1As1.Subject = topek
strBodyA1As1 = strBodyA1As1 + "<b><font face=Arial size=5><a href=http://www.healthwealthint.com><font color=#FF0000>HEALTH WEALTH INTERNATIONAL</font></a></font></b><br><br>"
strBodyA1As1 = strBodyA1As1 + "<font face=Arial size=2>Berikut ini adalah email yang dikirimkan dari contact webmail form :<br> "
strBodyA1As1 = strBodyA1As1 + "</font><br>" 
strBodyA1As1 = strBodyA1As1 + "<table border=0 cellpadding=1 cellspacing=1 width=780>"
strBodyA1As1 = strBodyA1As1 + "<tr><td width=161><font face=Arial size=2>Id. Distributor</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=17><font face=Arial size=2>:</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=602><font face=Arial size=2> "&noid&""
strBodyA1As1 = strBodyA1As1 + "</td></font></tr>"		
strBodyA1As1 = strBodyA1As1 + "<tr><td width=161><font face=Arial size=2>Nama Lengkap</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=17><font face=Arial size=2>:</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=602><font face=Arial size=2> "&nama&""
strBodyA1As1 = strBodyA1As1 + "</td></font></tr>"	
strBodyA1As1 = strBodyA1As1 + "<tr><td width=161><font face=Arial size=2>Email</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=17><font face=Arial size=2>:</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=602><font face=Arial size=2> "&emel&""
strBodyA1As1 = strBodyA1As1 + "</td></font></tr>"	
strBodyA1As1 = strBodyA1As1 + "<tr><td width=161><font face=Arial size=2>No. Telepon</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=17><font face=Arial size=2>:</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=602><font face=Arial size=2> "&notelp&""
strBodyA1As1 = strBodyA1As1 + "</td></font></tr>"	
strBodyA1As1 = strBodyA1As1 + "<tr><td width=161><font face=Arial size=2>Isi berita</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=17><font face=Arial size=2>:</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=602><font face=Arial size=2> "&isi&""
strBodyA1As1 = strBodyA1As1 + "</td></font></tr>"	
strBodyA1As1 = strBodyA1As1 + "<tr><td width=161><font face=Arial size=2>Tanggal</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=17><font face=Arial size=2>:</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=602><font face=Arial size=2> "&gabung&""
strBodyA1As1 = strBodyA1As1 + "</td></font></tr>"	
strBodyA1As1 = strBodyA1As1 + "<tr><td width=161><font face=Arial size=2>IP. Address</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=17><font face=Arial size=2>:</td></font>"	
strBodyA1As1 = strBodyA1As1 + "<td width=602><font face=Arial size=2> "&regips&""
strBodyA1As1 = strBodyA1As1 + "</td></font></tr>"
strBodyA1As1 = strBodyA1As1 + "</table>"		
mailA1As1.HTMLBody = strBodyA1As1

if not mailA1As1.Send("mail.healthwealthint.com" ) then
%>
<script language="javascript">
<!--
window.alert ("Sedang ada gangguan dalam mail server kami.");  
window.location = "contact.asp" ;
//-->
</script>
<%
else
%>
<script language="javascript">
<!--
window.alert ("Kontak anda sudah terkirim ke mail server kami, kami akan berusaha untuk segera memberikan tanggapan, terima kasih.");  
window.location = "contact.asp" ;
//-->
</script>
<%
end if
%>













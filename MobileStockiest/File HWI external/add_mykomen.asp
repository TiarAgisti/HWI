<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
<%
tpe = request("tipe")
manuk = Session.Contents("manuk")
sss = "T"
aman = "F"
asal = session("asal")
rs.Open "SELECT uid,kta,emel,hp FROM member WHERE kta like '"&manuk&"' and sta like '"&sss&"'",conn
	if rs.bof then
		aman = "F"
		rs.Close
		set rs=nothing
		Conn.Close
		set conn=nothing			
		Session.Contents("manuk") = ""
		session("pesankomen") = "Anda belum login sebagai distributor HWI"
		response.redirect asal
	else
		aman = "T"
		session("pesankomen") = ""
		Session.Contents("manuk") = rs("kta")
		anggota = rs("uid")
		emel = rs("emel")
		telp_anggota = rs("hp")
	end if
rs.Close

if emel = "-" or isnull(emel) then
	emel = "donotreply@healthwealthint.com"
else
	emel = emel
end if

if tpe = "liputan" then 

noid = trim(request("id"))
deskripsi = SafeSQL(ucase(request("deskripsi")))
deskripsi_asli = trim(request("deskripsi"))

if deskripsi ="" then
	l1 = "Mbuh"
	rs.Close
	set rs=nothing
	Conn.Close
	set conn=nothing		
	session("pesankomen") = "Anda belum mengisikan komentar / testimonial anda"
	response.redirect asal
else
	If Len(deskripsi)>250 Then 
		rs.Close
		set rs=nothing
		Conn.Close
		set conn=nothing	
		session("pesankomen") = "Komentar anda maksimal 250 karakter"
		l1 = "Mbuh"
		response.redirect asal
	else
	If ((Len(deskripsi)<250) and (deskripsi<>"")) Then 
		l1 = "Ter1"	
		session("pesankomen") = ""	
	end if	
	End If 
end if

rs.Open "SELECT * FROM liputan where sta like '"&sss&"' and id = '"&noid&"'",conn,1,3
	if rs.bof then
		set rs=nothing
		Conn.Close
		set conn=nothing		
		ada = "F"
		session("pesankomen") = "Tidak ditemukan liputan yang diinginkan ......."
		response.redirect asal
	else
		ada = "T"
		judul_liputan = rs("judul")
		session("pesankomen") = ""
	end if
rs.Close
	
if l1 = "Ter1" and aman="T" and manuk <> "" and ada = "T" then
Function Password_GenPass( nNoChars, sValidChars )
Const szDefault = "ABCDEFGHIJKLMNOPQRSTUVWXYZ8093751abcdefghijklmnopqrstuvwxyz246"
Dim nCount
Dim sRet
Dim nNumber
Dim nLength

Randomize 'init random

If sValidChars = "" Then
sValidChars = szDefault
End If
nLength = Len( sValidChars )

For nCount = 1 To nNoChars
nNumber = Int((nLength * Rnd) + 1)
sRet = sRet & Mid( sValidChars, nNumber, 1 )
Next
Password_GenPass = sRet
End Function

sesino = Password_GenPass(15, "" )
seno = Password_GenPass(30, "" )

	
	rs.Open "SELECT id FROM new_komen_liputan order by id desc limit 1", conn
		if rs.bof then
			nokomen = 1	
		else
			nokomen = rs("id")+1
		end if
	rs.Close	

	rs.Open "SELECT * FROM new_komen_liputan order by id desc limit 1",conn,1,3
		rs.addnew
			rs("id") = nokomen
			rs("noid") = noid
			rs("kta") = manuk
			rs("sta") = "F"
			rs("tgl") = now()
			rs("deskripsi") = deskripsi_asli
			rs("kodesesi") = sesino	
		rs.update
	rs.close		
set rs=nothing
Conn.Close
set conn=nothing		
	
aktlink = "http://www.healthwealthint.com/cgi-bin/activation_komentar.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino
declink = "http://www.healthwealthint.com/cgi-bin/deactivation_komentar.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino

gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = "donotreply@healthwealthint.com"
mail.FromName = "Komentar Liputan Kegiatan : "&judul_liputan
mail.AddRecipient "wiyanto_oen@healthwealthint.com"
mail.AddRecipient "info@healthwealthint.com"
mail.AddRecipient "kris@healthwealthint.com"
mail.AddRecipient "adnan@healthwealthint.com"
mail.Subject = "Komentar Liputan Kegiatan dari : "&anggota
strBody = strBody + "<b><font face=Arial size=5><a href=http://www.healthwealthint.com><font color=#FF0000>HEALTH WEALTH INTERNATIONAL</font></a></font></b><br><br>"
strBody = strBody + "<font face=Arial size=2>Seseorang telah memberikan komentar mengenai liputan kegiatan, berikut ini adalah isi komentarnya "
strBody = strBody + "</font><br>" 
strBody = strBody + "<table border=0 cellpadding=1 cellspacing=1 width=780>"
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&manuk&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Nama Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&anggota&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Telepon</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&telp_anggota&""
strBody = strBody + "</td></font></tr>"			
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Email Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&emel&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Liputan</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&noid&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Judul Liputan</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&judul_liputan&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Komentar</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&deskripsi&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Tanggal</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&gabung&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>IP. Address</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&regips&""
strBody = strBody + "</td></font></tr>"
strBody = strBody + "</table>"
strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800><tr><td><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menampilkan komentar tersebut, silahkan klik link berikut ini : <a href="&aktlink&""&">"&aktlink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menyembunyikan komentar tersebut, silahkan klik link berikut ini : <a href="&declink&""&">"&declink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Terima kasih dan salam sukses luar biasa !!!</font><br>"
strBody = strBody + "<font face=Arial size=2>AUTO RESPONSE SYSTEM I.T HWI</font><br>"
strBody = strBody + "</td></tr>"
strBody = strBody + "</table>"		
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
else
	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
end if

	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
end if
end if

''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' MOTIVASI
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
if tpe = "motivasi" then
noid = trim(request("id"))
deskripsi = SafeSQL(ucase(request("deskripsi")))
deskripsi_asli = trim(request("deskripsi"))

if deskripsi ="" then
	l1 = "Mbuh"
	rs.Close
	set rs=nothing
	Conn.Close
	set conn=nothing		
	session("pesankomen") = "Anda belum mengisikan komentar anda"
	response.redirect asal
else
	If Len(deskripsi)>250 Then 
		rs.Close
		set rs=nothing
		Conn.Close
		set conn=nothing	
		session("pesankomen") = "Komentar anda maksimal 250 karakter"
		l1 = "Mbuh"
		response.redirect asal
	else
	If ((Len(deskripsi)<250) and (deskripsi<>"")) Then 
		l1 = "Ter1"	
		session("pesankomen") = ""	
	end if	
	End If 
end if

rs.Open "SELECT * FROM new_motiv where sta like '"&sss&"' and id = '"&noid&"'",conn,1,3
	if rs.bof then
		set rs=nothing
		Conn.Close
		set conn=nothing		
		ada = "F"
		session("pesankomen") = "Tidak ditemukan tulisan motivasi yang diinginkan ......."
		response.redirect asal
	else
		ada = "T"
		judul_motiv = rs("judul")
		session("pesankomen") = ""
	end if
rs.Close
	
if l1 = "Ter1" and aman="T" and manuk <> "" and ada = "T" then
Function Password_GenPass( nNoChars, sValidChars )
Const szDefault = "ABCDEFGHIJKLMNOPQRSTUVWXYZ8093751abcdefghijklmnopqrstuvwxyz246"
Dim nCount
Dim sRet
Dim nNumber
Dim nLength

Randomize 'init random

If sValidChars = "" Then
sValidChars = szDefault
End If
nLength = Len( sValidChars )

For nCount = 1 To nNoChars
nNumber = Int((nLength * Rnd) + 1)
sRet = sRet & Mid( sValidChars, nNumber, 1 )
Next
Password_GenPass = sRet
End Function

sesino = Password_GenPass(15, "" )
seno = Password_GenPass(30, "" )

	
	rs.Open "SELECT id FROM new_komen_motiv order by id desc limit 1", conn
		if rs.bof then
			nokomen = 1	
		else
			nokomen = rs("id")+1
		end if
	rs.Close	

	rs.Open "SELECT * FROM new_komen_motiv order by id desc limit 1",conn,1,3
		rs.addnew
			rs("id") = nokomen
			rs("noid") = noid
			rs("kta") = manuk
			rs("sta") = "F"
			rs("tgl") = now()
			rs("deskripsi") = deskripsi_asli
			rs("kodesesi") = sesino	
		rs.update
	rs.close		
set rs=nothing
Conn.Close
set conn=nothing		
	
aktlink = "http://www.healthwealthint.com/cgi-bin/activation_komenmotiv.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino
declink = "http://www.healthwealthint.com/cgi-bin/deactivation_komenmotiv.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino

gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = "donotreply@healthwealthint.com"
mail.FromName = "Komentar Tulisan Motivasi : "&judul_motiv
mail.AddRecipient "wiyanto_oen@healthwealthint.com"
mail.AddRecipient "info@healthwealthint.com"
mail.AddRecipient "happystjandra@healthwealthint.com"
mail.Subject = "Komentar Tulisan motivasi dari : "&anggota
strBody = strBody + "<b><font face=Arial size=5><a href=http://www.healthwealthint.com><font color=#FF0000>HEALTH WEALTH INTERNATIONAL</font></a></font></b><br><br>"
strBody = strBody + "<font face=Arial size=2>Seseorang telah memberikan komentar mengenai tulisan motivasi dan kisah inspirasi, berikut ini adalah isi komentarnya "
strBody = strBody + "</font><br>" 
strBody = strBody + "<table border=0 cellpadding=1 cellspacing=1 width=780>"
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&manuk&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Nama Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&anggota&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Telepon</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&telp_anggota&""
strBody = strBody + "</td></font></tr>"			
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Email Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&emel&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Tulisan</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&noid&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Judul Tulisan</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&judul_motiv&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Komentar</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&deskripsi&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Tanggal</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&gabung&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>IP. Address</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&regips&""
strBody = strBody + "</td></font></tr>"
strBody = strBody + "</table>"
strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800><tr><td><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menampilkan komentar tersebut, silahkan klik link berikut ini : <a href="&aktlink&""&">"&aktlink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menyembunyikan komentar tersebut, silahkan klik link berikut ini : <a href="&declink&""&">"&declink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Terima kasih dan salam sukses luar biasa !!!</font><br>"
strBody = strBody + "<font face=Arial size=2>AUTO RESPONSE SYSTEM I.T HWI</font><br>"
strBody = strBody + "</td></tr>"
strBody = strBody + "</table>"		
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
else
	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
end if

	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
end if
end if


''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' TESTIMONIAL PODUK
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
if tpe = "testimonial_produk" then
noid = trim(request("kode"))
deskripsi = SafeSQL(ucase(request("deskripsi")))
deskripsi_asli = trim(request("deskripsi"))
nile = request("nilai")
asal = session("asal")
sss = "T"

if deskripsi ="" then
	l1 = "Mbuh"
	rs.Close
	set rs=nothing
	Conn.Close
	set conn=nothing		
	session("pesankomen") = "Anda belum mengisikan testimonial anda"
	response.redirect asal
else
	If Len(deskripsi)>2500 Then 
		rs.Close
		set rs=nothing
		Conn.Close
		set conn=nothing	
		session("pesankomen") = "Tulisan testimonial anda maksimal 2500 karakter"
		l1 = "Mbuh"
		response.redirect asal
	else
	If ((Len(deskripsi)<2500) and (deskripsi<>"")) Then 
		l1 = "Ter1"	
		session("pesankomen") = ""	
	end if	
	End If 
end if

if nile <> "" then
	if isnumeric(nile) = false then
		l2 = "Mbuh"
		session("pesankomen") = "Nilai testimonial anda tidak valid"
		response.redirect asal		
	else
		nile = int(nile)
		if nile >= 1 and nile <= 5 then
			nilaine = nile
			l2 = "Ter2"
			session("pesankomen") = ""
		else
			l2 = "Mbuh"
			session("pesankomen") = "Nilai testimonial anda tidak valid"
			response.redirect asal					
		end if
	end if
else
	l2 = "Mbuh"	
	session("pesankomen") = "Nilai testimonial anda tidak valid"
	response.redirect asal			
end if	

rs.Open "SELECT kode FROM st_barang where kode like '"&noid&"' and sta like '"&sss&"'",conn
	if rs.bof then
		set rs=nothing
		Conn.Close
		set conn=nothing		
		ada = "F"
		session("pesankomen") = "Tidak ditemukan kode produk yang akan diberi testimonial ......."
		response.redirect asal
	else
		ada = "T"
		session("pesankomen") = ""
	end if
rs.Close		

if l1 = "Ter1" and aman="T" and manuk <> "" and ada = "T" and l2 = "Ter2" then
Function Password_GenPass( nNoChars, sValidChars )
Const szDefault = "ABCDEFGHIJKLMNOPQRSTUVWXYZ8093751abcdefghijklmnopqrstuvwxyz246"
Dim nCount
Dim sRet
Dim nNumber
Dim nLength

Randomize 'init random

If sValidChars = "" Then
sValidChars = szDefault
End If
nLength = Len( sValidChars )

For nCount = 1 To nNoChars
nNumber = Int((nLength * Rnd) + 1)
sRet = sRet & Mid( sValidChars, nNumber, 1 )
Next
Password_GenPass = sRet
End Function

sesino = Password_GenPass(15, "" )
seno = Password_GenPass(30, "" )

	
	rs.Open "SELECT id FROM testi_prod order by id desc limit 1", conn
		if rs.bof then
			nokomen = 1	
		else
			nokomen = rs("id")+1
		end if
	rs.Close	

	rs.Open "SELECT * FROM testi_prod order by id desc limit 1",conn,1,3
		rs.addnew
			rs("id") = nokomen
			rs("prod_id") = noid
			rs("kta") = manuk
			rs("sta") = "F"
			rs("tgl") = now()
			rs("isi") = deskripsi_asli
			rs("kodesesi") = sesino	
			rs("nilai") = nilaine
			rs("foto") = "-"
			rs("uraian") = "-"
			rs("dikirim") = "-"
		rs.update
	rs.close		
set rs=nothing
Conn.Close
set conn=nothing		
	
aktlink = "http://www.healthwealthint.com/cgi-bin/activation_testiprod.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino
declink = "http://www.healthwealthint.com/cgi-bin/deactivation_testiprod.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino

gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = "donotreply@healthwealthint.com"
mail.FromName = "Testimonial Produk : "&noid
mail.AddRecipient "wiyanto_oen@healthwealthint.com"
mail.AddRecipient "info@healthwealthint.com"
mail.AddRecipient "gadis@healthwealthint.com"
mail.AddRecipient "yanti@healthwealthint.com"
mail.Subject = "Testimonial produk dari : "&anggota
strBody = strBody + "<b><font face=Arial size=5><a href=http://www.healthwealthint.com><font color=#FF0000>HEALTH WEALTH INTERNATIONAL</font></a></font></b><br><br>"
strBody = strBody + "<font face=Arial size=2>Seseorang telah memberikan testimonial produk, berikut ini adalah isi komentarnya "
strBody = strBody + "</font><br>" 
strBody = strBody + "<table border=0 cellpadding=1 cellspacing=1 width=780>"
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&manuk&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Nama Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&anggota&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Telepon</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&telp_anggota&""
strBody = strBody + "</td></font></tr>"			
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Email Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&emel&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Tulisan</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&noid&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Kode Produk</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&noid&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Penilaian</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&nilaine&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Testimonial</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&deskripsi&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Tanggal</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&gabung&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>IP. Address</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&regips&""
strBody = strBody + "</td></font></tr>"
strBody = strBody + "</table>"
strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800><tr><td><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menampilkan testimonial tersebut, silahkan klik link berikut ini : <a href="&aktlink&""&">"&aktlink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menyembunyikan testimonial tersebut, silahkan klik link berikut ini : <a href="&declink&""&">"&declink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Terima kasih dan salam sukses luar biasa !!!</font><br>"
strBody = strBody + "<font face=Arial size=2>AUTO RESPONSE SYSTEM I.T HWI</font><br>"
strBody = strBody + "</td></tr>"
strBody = strBody + "</table>"		
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("pesankomen") = "Testimonial anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan testimonial."	
	response.redirect asal
else
	session("pesankomen") = "Testimonial anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan testimonial."	
	response.redirect asal
end if

	session("pesankomen") = "Testimonial anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan testimonial."	
	response.redirect asal
end if
end if


''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'UPDATE BERITA
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
if tpe = "berita" then
noid = trim(request("id"))
deskripsi = SafeSQL(ucase(request("deskripsi")))
deskripsi_asli = trim(request("deskripsi"))

if deskripsi ="" then
	l1 = "Mbuh"
	rs.Close
	set rs=nothing
	Conn.Close
	set conn=nothing		
	session("pesankomen") = "Anda belum mengisikan komentar anda"
	response.redirect asal
else
	If Len(deskripsi)>250 Then 
		rs.Close
		set rs=nothing
		Conn.Close
		set conn=nothing	
		session("pesankomen") = "Komentar anda maksimal 250 karakter"
		l1 = "Mbuh"
		response.redirect asal
	else
	If ((Len(deskripsi)<250) and (deskripsi<>"")) Then 
		l1 = "Ter1"	
		session("pesankomen") = ""	
	end if	
	End If 
end if

rs.Open "SELECT title FROM berita where sta like '"&sss&"' and id = '"&noid&"'",conn,1,3
	if rs.bof then
		set rs=nothing
		Conn.Close
		set conn=nothing		
		ada = "F"
		session("pesankomen") = "Tidak ditemukan berita yang diinginkan ......."
		response.redirect asal
	else
		ada = "T"
		judul_motiv = rs("title")
		session("pesankomen") = ""
	end if
rs.Close
	
if l1 = "Ter1" and aman="T" and manuk <> "" and ada = "T" then
Function Password_GenPass( nNoChars, sValidChars )
Const szDefault = "ABCDEFGHIJKLMNOPQRSTUVWXYZ8093751abcdefghijklmnopqrstuvwxyz246"
Dim nCount
Dim sRet
Dim nNumber
Dim nLength

Randomize 'init random

If sValidChars = "" Then
sValidChars = szDefault
End If
nLength = Len( sValidChars )

For nCount = 1 To nNoChars
nNumber = Int((nLength * Rnd) + 1)
sRet = sRet & Mid( sValidChars, nNumber, 1 )
Next
Password_GenPass = sRet
End Function

sesino = Password_GenPass(15, "" )
seno = Password_GenPass(30, "" )

	
	rs.Open "SELECT id FROM new_komen_berita order by id desc limit 1", conn
		if rs.bof then
			nokomen = 1	
		else
			nokomen = rs("id")+1
		end if
	rs.Close	

	rs.Open "SELECT * FROM new_komen_berita order by id desc limit 1",conn,1,3
		rs.addnew
			rs("id") = nokomen
			rs("noid") = noid
			rs("kta") = manuk
			rs("sta") = "F"
			rs("tgl") = now()
			rs("deskripsi") = deskripsi_asli
			rs("kodesesi") = sesino	
		rs.update
	rs.close		
set rs=nothing
Conn.Close
set conn=nothing		
	
aktlink = "http://www.healthwealthint.com/cgi-bin/activation_komenberita.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino
declink = "http://www.healthwealthint.com/cgi-bin/deactivation_komenberita.asp?session=&komentar=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino

gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = "donotreply@healthwealthint.com"
mail.FromName = "Komentar Update Berita : "&judul_motiv
mail.AddRecipient "wiyanto_oen@healthwealthint.com"
mail.AddRecipient "info@healthwealthint.com"
mail.AddRecipient "kris@healthwealthint.com"
mail.AddRecipient "adnan@healthwealthint.com"
mail.Subject = "Komentar Update berita dari : "&anggota
strBody = strBody + "<b><font face=Arial size=5><a href=http://www.healthwealthint.com><font color=#FF0000>HEALTH WEALTH INTERNATIONAL</font></a></font></b><br><br>"
strBody = strBody + "<font face=Arial size=2>Seseorang telah memberikan komentar mengenai update berita, berikut ini adalah isi komentarnya "
strBody = strBody + "</font><br>" 
strBody = strBody + "<table border=0 cellpadding=1 cellspacing=1 width=780>"
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&manuk&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Nama Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&anggota&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Telepon</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&telp_anggota&""
strBody = strBody + "</td></font></tr>"			
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Email Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&emel&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Tulisan</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&noid&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Judul Berita</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&judul_motiv&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Komentar</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&deskripsi&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Tanggal</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&gabung&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>IP. Address</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&regips&""
strBody = strBody + "</td></font></tr>"
strBody = strBody + "</table>"
strBody = strBody + "<table border=0 cellpadding=0 cellspacing=0 width=800><tr><td><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menampilkan komentar berita tersebut, silahkan klik link berikut ini : <a href="&aktlink&""&">"&aktlink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menyembunyikan komentar berita tersebut, silahkan klik link berikut ini : <a href="&declink&""&">"&declink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Terima kasih dan salam sukses luar biasa !!!</font><br>"
strBody = strBody + "<font face=Arial size=2>AUTO RESPONSE SYSTEM I.T HWI</font><br>"
strBody = strBody + "</td></tr>"
strBody = strBody + "</table>"		
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
else
	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
end if

	session("pesankomen") = "Komentar anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan komentar."	
	response.redirect asal
end if
end if

%>
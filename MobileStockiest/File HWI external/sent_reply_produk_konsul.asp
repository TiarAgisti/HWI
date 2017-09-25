<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->

<%
asal = session("asal")
noid = trim(ucase(request("noid")))
nodist_asli = trim(request("userid"))
pase_asli = request("password")
deskripsi_asli = trim(request("deskripsi"))

nodist = SafeSQL(ucase(trim(request("userid"))))
pase = SafeSQL(ucase(trim(request("password"))))
deskripsi = SafeSQL(ucase(trim(request("deskripsi"))))

sss = "T"
if noid ="" then
	l1 = "Mbuh"		
	session("pesankonsulreply") = "Anda belum memilih topik konsultasi yang akan anda beri tulisan balasan"
	response.redirect asal
else
	If Len(noid)>5 Then 
		session("pesankonsulreply") = "Kode konsultasi maksimal 5 karakter"
		l1 = "Mbuh"
		response.redirect asal
	else
	If ((Len(noid)<5) and (noid<>"")) Then 
		rs.Open "SELECT kode FROM new_konsul_produk_head where sta like '"&sss&"' and id like '"&noid&"'",conn
			if rs.bof then
				set rs=nothing
				Conn.Close
				set conn=nothing		
				ada = "F"
				l1 = "Mbuh"
				session("pesankonsulreply") = "Tidak ditemukan id topik konsultasi"
				response.redirect asal
			else
				l1 = "Ter1"	
				session("pesankonsulreply") = ""
			end if
		rs.Close	
	end if	
	End If 
end if

if nodist ="" then
	l2 = "Mbuh"	
	session("pesankonsulreply") = "Anda belum mengisikan distributor id anda"
	response.redirect asal
else
	If Len(nodist)>15 Then 
		session("pesankonsulreply") = "Distributor id maksimal 15 karakter"
		l1 = "Mbuh"
		response.redirect asal
	else
	If ((Len(nodist)<15) and (nodist<>"")) Then 
		rs.Open "SELECT uid,thekey,telp,hp,emel,kota FROM member where sta like '"&sss&"' and ucase(kta) like '"&nodist_asli&"'",conn
			if rs.bof then
				set rs=nothing
				Conn.Close
				set conn=nothing		
				ada = "F"
				l2 = "Mbuh"
				session("pesankonsulreply") = "Distributor id tidak ditemukan"
				response.redirect asal
			else
				if rs("thekey") = pase_asli then
					l2 = "Ter2"	
					session("pesankonsul") = ""
					anggota = rs("uid")
					notelp = rs("telp")+" / "+rs("hp")
					emel = rs("emel")
					kota = rs("kota")
				else
					set rs=nothing
					Conn.Close
					set conn=nothing		
					ada = "F"
					l2 = "Mbuh"
					session("pesankonsulreply") = "Password login anda salah"
					response.redirect asal				
				end if
			end if
		rs.Close	
	end if	
	End If 
end if

if deskripsi ="" then
	l3 = "Mbuh"		
	session("pesankonsulreply") = "Anda belum mengisikan tulisan balasan anda"
	response.redirect asal
else
	If Len(deskripsi)>4250 Then 	
		session("pesankonsulreply") = "Tulisan balasan anda maksimal 4250 karakter"
		l3 = "Mbuh"
		response.redirect asal
	else
	If ((Len(deskripsi)<4250) and (deskripsi<>"")) Then 
		l3 = "Ter3"	
		session("pesankonsulreply") = ""	
	end if	
	End If 
end if


if l1 = "Ter1" and l2 = "Ter2" and l3="Ter3" then
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
	rs.Open "SELECT id,subyek FROM new_konsul_produk_head where id like '"&noid&"'", conn
		if rs.bof then
			subyek_asli = "-"
		else
			subyek_asli = rs("subyek")
		end if
	rs.Close
	
	rs.Open "SELECT id FROM new_konsul_produk_det order by id desc limit 1", conn
		if rs.bof then
			nokomen = 1	
		else
			nokomen = rs("id")+1
		end if
	rs.Close	

	rs.Open "SELECT * FROM new_konsul_produk_det order by id desc limit 1",conn,1,3
		rs.addnew
			rs("id") = nokomen
			rs("noid") = noid
			rs("author") = nodist_asli
			rs("sta") = "F"
			rs("tgl") = now()
			rs("isi") = deskripsi_asli
			rs("kodesesi") = sesino	
		rs.update
	rs.close		
set rs=nothing
Conn.Close
set conn=nothing
aktlink = "http://www.healthwealthint.com/cgi-bin/activation_replykonsul.asp?session=&replykonsulprod=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino
declink = "http://www.healthwealthint.com/cgi-bin/deactivation_replykonsul.asp?session=&replykonsulprod=&kode_akses="&seno&"&id="&nokomen&"&session_state="&sesino

if emel = "-" or isnull(emel) then
	emel = "donotreply@healthwealthint.com"
else
	emel = emel
end if
		
gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = emel
mail.FromName = "Tulisan balasan konsultasi Produk : "&subyek_asli
mail.AddRecipient "wiyanto_oen@healthwealthint.com"
mail.AddRecipient "info@healthwealthint.com"
mail.AddRecipient "gadis@healthwealthint.com"
mail.Subject = "Tulisan balasan konsultasi produk dari : "&anggota
strBody = strBody + "<b><font face=Arial size=5><a href=http://www.healthwealthint.com><font color=#FF0000>HEALTH WEALTH INTERNATIONAL</font></a></font></b><br><br>"
strBody = strBody + "<font face=Arial size=2>Seseorang telah mengisi form balasan konsultasi produk online, berikut ini adalah isi balasannya "
strBody = strBody + "</font><br>" 
strBody = strBody + "<table border=0 cellpadding=1 cellspacing=1 width=780>"
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&nodist_asli&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Nama Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&anggota&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Telepon</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&notelp&""
strBody = strBody + "</td></font></tr>"			
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Email Anggota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&emel&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Kota</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&kota&""
strBody = strBody + "</td></font></tr>"		
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id. Konsultasi</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&noid&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Subyek Konsultasi</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&subyek_asli&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Tulisan Balasan</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&deskripsi_asli&""
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
strBody = strBody + "<font face=Arial size=2>Untuk menampilkan tulisan balasan konsultasi produk tersebut, silahkan klik link berikut ini : <a href="&aktlink&""&">"&aktlink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Untuk menyembunyikan tulisan balasan konsultasi produk tersebut, silahkan klik link berikut ini : <a href="&declink&""&">"&declink&""&"</a></font><br><br>"
strBody = strBody + "<font face=Arial size=2>Terima kasih dan salam sukses luar biasa !!!</font><br>"
strBody = strBody + "<font face=Arial size=2>AUTO RESPONSE SYSTEM I.T HWI</font><br>"
strBody = strBody + "</td></tr>"
strBody = strBody + "</table>"		
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("pesankonsul") = "Tulisan balasan anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan reply pada konsultasi produk."	
	response.redirect asal
else
	session("pesankonsul") = "Tulisan balasan anda telah terkirim ke redaksi HWI untuk dimoderasi sebelum ditayangkan, terima kasih atas kesediaan anda memberikan reply pada konsultasi produk."	
	response.redirect asal
end if


else
response.redirect asal
end if
%>
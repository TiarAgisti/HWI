<!--#Include File=pg_config.asp-->
<!--#Include File=dbcon/opendb.asp-->
<%
manuk = Session.Contents("manuk")
sss = "T"
aman = "F"
rs.Open "SELECT kta,uid,emel,hp,thekey FROM member where kta like '"&manuk&"' and sta like '"&sss&"'",conn	
	if rs.bof then
		nama_anggota = ""
		emel_anggota = ""
		uid = ""
		telp_anggota = ""
		aman = "F"
		pase = "n94coek03nr4genah"
	else
		aman = "T"
		uid = rs("kta")
		nama_anggota = rs("uid")
		emel_anggota = rs("emel")
		telp_anggota = rs("hp")
		pase = rs("thekey")
	end if
rs.Close
		
noid = trim(request("uid"))
nama = SafeSQL(ucase(request("nama")))
nama_asli = trim(request("nama"))
emel = SafeSQL(ucase(request("email")))
emel_asli = trim(request("email"))
notelp = SafeSQL(ucase(request("notelp")))
notelp_asli = trim(request("notelp"))
subyek = SafeSQL(ucase(request("subyek")))
subyek_asli = trim(request("subyek"))
deskripsi = SafeSQL(ucase(request("deskripsi")))
deskripsi_asli = trim(request("deskripsi"))
password = SafeSQL(ucase(request("password")))
password_asli = trim(request("password"))

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













%>

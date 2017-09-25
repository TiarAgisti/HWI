<%
Function SafeSQL(sInput)
  TempString = sInput
  sBadChars=array("SELECT", "HAVING", "ALTER", "DROP", "ORDER", "GROUP BY", "INSERT", "@@VERSION", "VERSION()", "AND 1", "INFORMATION_SCHEMA.TABLES","GROUP_CONCAT", "DELETE", "CONCAT_WS", ";", "--", "*", "xp_", "#", "%", "&", "'", "(", ")", "/", "\", ":", ";", "<", ">", "=", "[", "]", "?", "`", "|") 
  For iCounter = 0 to uBound(sBadChars)
    TempString = replace(TempString,sBadChars(iCounter),"")
  Next
  SafeSQL = TempString
End function
%>
<!--#Include File=dbcon/opendb.asp-->
<%
asal = "password_reminder.asp"
uid = trim(SafeSQL(ucase(request("uid"))))
nama = trim(SafeSQL(ucase(request("nama"))))
noktp = trim(SafeSQL(ucase(request("noktp"))))
sponsor = trim(SafeSQL(ucase(request("sponsor"))))
notelp = trim(SafeSQL(ucase(request("notelp"))))
emel = trim(SafeSQL(ucase(request("email"))))


	if uid = "" then
		session("mesejrems") = "Mohon isikan nomor id distributor anda"
		response.redirect "password_reminder.asp"
	else	
		sopo = trim(request("uid"))
	end if
	if nama = "" then
		session("mesejrems") = "Mohon isikan nama lengkap anda"
		response.redirect "password_reminder.asp"
	else	
		namae = ucase(trim(request("nama")))
	end if	
	if noktp = "" then
		session("mesejrems") = "Mohon isikan nomor identitas diri anda"
		response.redirect "password_reminder.asp"
	else	
		nktp = ucase(trim(request("noktp")))
	end if	
	if sponsor = "" then
		session("mesejrems") = "Mohon isikan nomor id. distributor sponsor anda"
		response.redirect "password_reminder.asp"
	else	
		direk = trim(request("sponsor"))
	end if		

	rs.Open "SELECT kta,uid,emel,direk,ktp FROM member WHERE kta like '"&sopo&"'",conn
		if rs.bof then
			lanjut = "F"
			rs.close
			set rs=nothing
			Conn.Close
			set conn=nothing			
			session("mesejrems") = "No. id distributor tidak ditemukan"
			response.redirect asal
		else		
			namanya = ucase(trim(rs("uid")))
			spon = trim(rs("direk"))
			ktp = ucase(trim(rs("ktp")))
			emel = rs("emel")
			
			if namanya = namae then
				session("mesejrems") = ""
			else
				rs.close
				set rs=nothing
				Conn.Close
				set conn=nothing				
				session("mesejrems") = "Nama distributor tidak sesuai dengan data verifikasi kami, silahkan ulangi kembali."
				response.redirect asal					
			end if

			if ktp = nktp then
				session("mesejrems") = ""
			else
				rs.close
				set rs=nothing
				Conn.Close
				set conn=nothing				
				session("mesejrems") = "Nomor identitas pengenal diri anda tidak sesuai dengan data verifikasi kami, silahkan ulangi kembali"
				response.redirect asal					
			end if
						
			if spon = direk then
				session("mesejrems") = ""
				namanya = rs("uid")
			else
				rs.close
				set rs=nothing
				Conn.Close
				set conn=nothing				
				session("mesejrems") = "No. id distributor sponsor anda tidak sesuai dengan data verifikasi kami, silahkan ulangi kembali."
				response.redirect asal					
			end if				

		end if						
	rs.close
	set rs=nothing
	Conn.Close
	set conn=nothing

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
mail.FromName = "Permintaan Password Untuk : "&namanya
mail.AddRecipient "support@healthwealthint.com"
mail.Subject = "Permintaan Password : "&noid
strBody = strBody + "<b><font face=Arial size=5><a href=http://www.healthwealthint.com><font color=#FF0000>HEALTHWEALTHINT.COM</font></a></font></b><br><br>"
strBody = strBody + "<font size=2 face=Arial>Seseorang meminta password login melalui form request password<br>" 
strBody = strBody + "<font face=Arial size=2>Berikut ini adalah data distributor yang melakukan request password :<br> "
strBody = strBody + "</font><br>" 
strBody = strBody + "<table border=0 cellpadding=1 cellspacing=1 width=780>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. Id</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&sopo&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Nama Lengkap</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&namanya&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>No. KTP</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&nktp&""
strBody = strBody + "</td></font></tr>"
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Sponsor</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&spon&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Phone No.</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&notelp&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Email</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&emel&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>Date</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&gabung&""
strBody = strBody + "</td></font></tr>"	
strBody = strBody + "<tr><td width=161><font face=Arial size=2>IP. Address</td></font>"	
strBody = strBody + "<td width=17><font face=Arial size=2>:</td></font>"	
strBody = strBody + "<td width=602><font face=Arial size=2> "&regips&""
strBody = strBody + "</td></font></tr>"
strBody = strBody + "</table>"	
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("mesejrem") = "Maaf .... mail server dalam status maintenance, mohon tunggu beberapa saat kemudian atau silahkan hubung kantor pusat dengan departemen Distributor Relation"	
	response.redirect asal
else
	session("mesejrem") = "Request anda sudah terkirim ke departemen Distribution Relation, kami akan berusaha memberikan respon sesegera mungkin. Terima kasih"	
	response.redirect asal
end if

%>
		
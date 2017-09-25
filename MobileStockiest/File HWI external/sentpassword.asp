<%
Function SafeSQL(sInput)
  TempString = sInput
  sBadChars=array("SELECT", "HAVING", "*", "ALTER", "DROP", ";", "--", "INSERT", "DELETE", "xp_", "#", "%", "&", "'", "(", ")", "/", "\", ":", ";", "<", ">", "=", "[", "]", "?", "`", "|") 
  For iCounter = 0 to uBound(sBadChars)
    TempString = replace(TempString,sBadChars(iCounter),"")
  Next
  SafeSQL = TempString
End function
%>
<!--#Include File=dbcon/opendb.asp-->
<%
asal = "password_reminder.asp"
uid = trim(SafeSQL(ucase(request("noid"))))

	if uid = "" then
		session("errorrem1") = "Mohon isikan nomor id distributor anda"
		response.redirect "password_reminder.asp"
	else	
		sopo = trim(request("noid"))
	end if
	
	sss = "T"	
	rs.Open "SELECT kta,uid,emel,thekey,sta FROM member WHERE kta like '"&sopo&"' and sta like '"&sss&"'",conn
		if rs.bof then
			lanjut = "F"
			rs.close
			set rs=nothing
			Conn.Close
			set conn=nothing			
			session("errorrem1") = "No. id distributor tidak ditemukan"
			response.redirect asal
		else		
			if ucase(rs("sta")) = "T" then
				session("errorrem1") = ""
				bok = rs("thekey")
				nama = rs("uid")
				emel = rs("emel")
			else
				lanjut = "F"
				emel = ""			
				session("errorrem1") = "No. id distributor SUSPEND, email tidak dapat dikirimkan"
				response.redirect asal				
			end if	
		end if						
	rs.close
	set rs=nothing
	Conn.Close
	set conn=nothing

if emel <> "" then 	
gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = "donotreply@healthwealthint.com"
mail.mailServerPassword = "petersin0172"
mail.FromName = "Pengingat Password Untuk : "&nama
mail.AddRecipient emel
mail.Subject = "Pengingat Password : "&noid
strBody = strBody + "<table border=1 cellspacing=1 width=780 style=border-collapse: collapse bordercolor=#808080><tr>"
strBody = strBody + "<td valign=top><table border=0 cellpadding=0 cellspacing=0 width=780><tr><td width=780 height=20></td>"
strBody = strBody + "</tr></table><table border=0 cellpadding=0 cellspacing=0 width=780>"
strBody = strBody + "<tr><td width=780 valign=top><p align=center><img border=0 src=http://www.healthwealthint.com/images/logohwi.jpg width=155 height=100></td>"
strBody = strBody + "</tr></table><table border=0 cellpadding=0 cellspacing=0 width=780><tr>"
strBody = strBody + "<td width=780 height=20></td></tr></table><table border=0 cellpadding=0 cellspacing=0 width=780><tr><td>"
strBody = strBody + "<p align=center><font face=Verdana size=2>Anda atau seseorang dengan menggunakan nomor id distributor anda telah </font><br>"
strBody = strBody + "<font face=Verdana size=2>menjalankan sistem pengingat password</font><br>"
strBody = strBody + "<font face=Verdana size=2>di web site healthwealthint.com untuk mendapatkan informasi mengenai password login anda.</font><br>"
strBody = strBody + "<font face=Verdana size=2>Dibawah ini adalah nomor id distributor dan password login anda.</font><br>"
strBody = strBody + "<b>Distributor Id. : <font color=#FF0000> "&sopo&""
strBody = strBody + "</font><br><font face=Verdana size=2>Password Login : <font color=#FF0000> "&bok&""
strBody = strBody + "</font></b><br><font face=Verdana size=2>Abaikan apabila anda merasa tidak pernah menjalankan sistem pengingat password ini.</font><br>"
strBody = strBody + "<font face=Verdana size=2>Terima kasih dan semoga bermanfaat</font><br>"
strBody = strBody + "<font face=Verdana size=2>Salam Luar Biasa</font></td></tr><tr><td width=780 height=20></td></tr></table></td></tr></table>"
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
	session("mesejrem") = "Maaf .... password anda belum dapat dikirimkan, mail server dalam status maintenance, mohon tunggu beberapa saat kemudian."	
	response.redirect asal
else
	session("mesejrem") = "Password login anda sudah terkirim ke mailbox : "&emel	
	response.redirect asal
end if

else
	session("mesejrem") = "Anda tidak memiliki informasi alamat email didalam data ke distributoran anda. Pengiriman password tidak dapat dilakukan."
	response.redirect asal
end if
%>
		
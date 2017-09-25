<%@LANGUAGE="VBSCRIPT" %>
<%
gabung = now()
regips = request.servervariables("remote_addr")
strBody = ""
set mail = Server.CreateOBject( "JMail.Message" )
mail.Logging = true
mail.silent = true
mail.From = "donotreply@healthwealthint.com"
mail.mailServerPassword = "petersin0172"
mail.FromName = "Kelengkapan dokumen verifikasi : "&nourut
mail.AddRecipient "peter@petersindoro.com"
mail.Subject = "Kelengkapan dokumen verifikasi : "&nourut
mail.AddAttachment ("d:\domains\hwi\cpanel\surat_permohonan.pdf")
mail.AddAttachment ("d:\domains\hwi\cpanel\Term and Condition.pdf")
strBody = strBody + "<table border=1 cellspacing=1 width=780 style=border-collapse: collapse bordercolor=#808080><tr>"
strBody = strBody + "<td valign=top><table border=0 cellpadding=0 cellspacing=0 width=780><tr><td width=780 height=20></td>"
strBody = strBody + "</tr></table><table border=0 cellpadding=0 cellspacing=0 width=780>"
strBody = strBody + "<tr><td width=780 valign=top><p align=center><img border=0 src=http://www.healthwealthint.com/images/logohwi.jpg width=155 height=100></td>"
strBody = strBody + "</tr></table><table border=0 cellpadding=0 cellspacing=0 width=780><tr>"
strBody = strBody + "<td width=780 height=20></td></tr></table><table border=0 cellpadding=0 cellspacing=0 width=780><tr><td>"
strBody = strBody + "<font face=Verdana size=2>Anda atau seseorang dengan menggunakan nomor id distributor anda telah mendaftar untuk dilakukan verifikasi data distributor.</font><br>"
strBody = strBody + "<font face=Verdana size=2>Untuk memperlancar proses verifikasi ke-distributoran anda, maka segera lengkapi dokumen yang diperlukan, yaitu :</font><br>"
strBody = strBody + "<font face=Verdana size=2>1. Scan / Copy K.T.P yang masih berlaku</font><br>"
strBody = strBody + "<font face=Verdana size=2>2. Scan / Copy N.P.W.P (bila ada)</font><br>"
strBody = strBody + "<font face=Verdana size=2>3. Scan / Print out surat permohonan verifikasi yang sudah anda tanda tangani diatas meterai</font><br>"
strBody = strBody + "<font face=Verdana size=2>4. Scan / Print out surat perjanjian persetujuan yang sudah anda tanda tangani diatas meterai</font><br><br>"
strBody = strBody + "<font face=Verdana size=2>Kirimkan segera dokumen diatas dengan salah satu cara dibawah ini :</font><br>"
strBody = strBody + "<font face=Verdana size=2>1. POS/Titipan kilat ke kantor pusat PT. Health Wealth International dengan kode VERIFICATION REQUEST pada sudut kanan atas amplop anda.</font><br>"
strBody = strBody + "<font face=Verdana size=2>2. Kirimkan ke email verification@hwiverified.com dengan subyek email VERIFICATION REQUEST</font><br><br>"
strBody = strBody + "<font face=Verdana size=2>Status verifikasi anda akan diupdate dan tampil di website HTTPS://WWW.HWIVERIFIED.COM apabila hardcopy dokumen pelengkap diatas sudah kami terima.<br><br>"
strBody = strBody + "<font face=Verdana size=2>Terima kasih dan salam sehat luar biasa</font><br>"
strBody = strBody + "<font face=Verdana size=2>Tim Verifikasi PT. Health Wealth International</font></td></tr><tr><td width=780 height=20></td></tr></table></td></tr></table>"
mail.HTMLBody = strBody
if not mail.Send("mail.healthwealthint.com" ) then
else
end if
%>

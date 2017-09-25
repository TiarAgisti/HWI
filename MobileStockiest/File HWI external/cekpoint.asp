<%
Response.Buffer=True
Response.CacheControl = "no-cache"
Response.AddHeader "Pragma", "no-cache"
Response.Expires = -1
Response.ExpiresAbsolute = Now()-1
errorcek1 = session("errorcek1")
errorcek2 = session("errorcek2")
errorcek3 = session("errorcek3")
lanjut2 = "F"
%>
<!--#Include File=pos/pg_closing.asp-->
<!--#Include File=dbcon/opendbALL.asp-->
<!--#Include File=dbcon/opendbA.asp-->
<!--#Include File=dbcon/opendb.asp-->
<!--#Include File=dbcon/calldbG.asp-->
<%
Function SafeSQL(sInput)
  TempString = sInput
  sBadChars=array("SELECT", "HAVING", "*", "ALTER", "DROP", ";", "--", "INSERT", "DELETE", "xp_", "#", "%", "&", "'", "(", ")", "/", "\", ":", ";", "<", ">", "=", "[", "]", "?", "`", "|") 
  For iCounter = 0 to uBound(sBadChars)
    TempString = replace(TempString,sBadChars(iCounter),"")
  Next
  SafeSQL = TempString
End function

cek = safesql(ucase(trim(request("mode"))))

if cek = "PROSES" then

lanjut2 = "F"
uid = SafeSQL(ucase(request("userid")))
pas = SafeSQL(ucase(request("password")))
nosek = SafeSQL(ucase(request("turing")))
turba = SafeSQL(trim(request("turing")))
beruk = session("buring")

if trim(beruk) <> trim(turba) then
	session("errorcek3") = "Turing number yang anda isikan salah !"
	session("errorcek1") = ""
	session("errorcek2") = ""
	response.redirect "cekpoint.asp"
end if	

if uid = "" then
	session("errorcek1") = "Mohon isikan Nomor id distributor anda"
	userid = "-"
	response.redirect "cekpoint.asp"
else	
	userid = request("userid")
end if
			
if pas = "" then
	session("errorcek2") = "Mohon isikan password login anda"
	mypas = "-"
	response.redirect "cekpoint.asp"
else	
	mypas = request("password")	
end if
	
	sopo = userid
	''''''''''''''''''''''''''''''''''''''''''
	' CEK AUTO SUSPEND
	''''''''''''''''''''''''''''''''''''''''''
	lanjutken = "F"
	rs.Open "SELECT * FROM bonpas where kta like '"&sopo&"' order by id desc limit 1",conn
		if rs.bof then
			kiri = 0
			kanan = 0 
		else	
			kiri = rs("totkiri")	
			kanan = rs("totkanan")
		end if	
	rs.Close
	rs.Open "SELECT direk,alok FROM member WHERE kta like '"&sopo&"'",conn
		if rs.bof then
			direk = "-"
			alok = "-"
		else		
			direk = rs("direk")
			alok = rs("alok")				
		end if							
	rs.close	
		
	rs.Open "SELECT * FROM bns_expired_member where kta like '"&sopo&"' order by tglexpired desc limit 1",conn,1,3
		if rs.bof then
			lanjut2 = "F"
			lanjutken = "F"
			session("errorcek1") = "Status Expired ke-distributoran anda tidak ditemukan, silahkan hubungi kantor pusat"
			response.redirect "cekpoint.asp"	
		else	
			expir = rs("tglexpired")
			rs.update
				rs("kiri") = kiri
				rs("kanan") = kanan
				rs("direk") = direk
				rs("alok") = alok					
			rs.update
		end if	
	rs.Close
	lama = datediff("d",now(),expir)
	
	if lama < 0 then
		lanjutken = "F"
		lanjut2 = "F"
		rs.Open "SELECT * FROM member WHERE kta like '"&sopo&"'",conn,1,3
			if rs.bof then
			else	
				if lama < 0 and lama > -30 then
					if rs("sta") = "T" then
 						rs.update
 							rs("sta") = "F"
 							rs("uid") = rs("uid")+" (EXPIRED)"
 						rs.update	
 						lanjut2 = "F"	
 					end if
 					session("errorlog1") = "Status Ke-distributoran anda sudah expired dan ke-distributoran anda dalam status SUSPEND"			
					response.redirect "cekpoint.asp"					
				else
					if rs("sta") = "T" then
 						rs.update
 							rs("sta") = "F"
 							rs("uid") = rs("uid")+" (EXPIRED)"
 						rs.update	
 						lanjut2 = "F"
 					end if			
					session("errorlog1") = "Status Ke-distributoran anda sudah expired dan ke-distributoran anda dalam status SUSPEND"	
					response.redirect "cekpoint.asp"
				end if					
			end if							
		rs.close			
	else
		lanjutken = "T"
	end if	
	
		stene = "F"	
		if lanjutken = "T" then	
			rs.Open "SELECT uid,kta,lastip,lastlog,loginip,logindt,thekey,sta,logke FROM member WHERE kta like '"&sopo&"'",conn,3,3
				if rs.bof then
					lanjut2 = "F"
					session("errorcek1") = "Nomor id. Distributor tidak ditemukan."
					manuk = ""
				else		
					bok = rs("thekey")
					stene = ucase(rs("sta"))
					if stene = "T" then
						if bok = mypas then
							lanjut2 = "T"
		   	    	   	  	manuk = rs("kta")
						else
							lanjut2 = "F"	
							tglmu = date()	   	       	  	
							tgliki = day(tglmu)
							blniki = month(tglmu)
							thniki = year(tglmu)
							rsALL.Open "SELECT * FROM log_salahpass order by id desc limit 1",connALL,3,3
								rsALL.addnew
									rsALL("kta") = sopo
									rsALL("tgl") = tglmu
									rsALL("ip") = request.servervariables("remote_addr")
								rsALL.update
							rsALL.Close
							
			   	       	  	session("errorcek2") = "Password login anda salah !"
			   	       	  	manuk = ""				   	       	  	
						end if		
					else
						lanjut2 = "F"
						session("errorcek1") = "Account Suspend"
			   	       	manuk = ""
			   	    end if   	  									
				end if							
			rs.close		
		end if
	
	if lanjut2 = "T" then
		session("errorcek1") = ""
		session("errorcek2") = ""
		session("errorcek3") = ""
	else
		response.redirect "cekpoint.asp"
	end if

if lanjut2 = "T" then

mintupo = 200
rs.Open "SELECT pal1,pal2,uid,upme,direk,tipene,kta,uid FROM member where kta like '"&manuk&"'",conn
	if rs.bof then
		session("errorlog1") = "Session login anda sudah expired, silahkan login kembali"
		response.redirect "default.asp"
	else	
		sopoto = ucase(rs("uid"))
		ma = rs("kta")
		ma2 = rs("pal1")
		ma3 = rs("pal2")
		nama = rs("uid")
		upm1 = ucase(rs("upme"))
		upm = ucase(rs("upme"))
		updir = rs("direk")
		tipedias = ucase(rs("tipene"))	
		idne = rs("kta")			
	    upra = rs("upme")
	end if
rs.Close

skr = date()
bln = clng(month(skr))
thn = clng(year(skr))

jumtupolalu = 0
jumtupoku = 0
proddepo = 0
pvprod = 0
pvdepo = 0
pvpri = 0
bvpri = 0
prodreg = 0
pvreg = 0
pvku = 0
jummurni = 0
rs.Open "SELECT * FROM bns_depositrelease where ((kta like '"&manuk&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"'))",conn
	if rs.bof then
		proddepo = 0
		pvdepo = 0
	else
		proddepo = rs("pvprod")
		pvdepo = rs("pvpri")
	end if		
rs.close

rs.Open "SELECT sum(produp) FROM bns_mypv_prod_reg where ((kta like '"&manuk&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"'))",conn
	if rs.bof then
		prodreg = 0
	else
		prodreg = rs("sum(produp)")
	end if		
rs.close
if isnull(prodreg) = false then
	prodreg = prodreg
else
	prodreg = 0	
end if	
		
rs.Open "SELECT sum(produp),sum(postingup) FROM st_sale_prd_head where ((nodist like '"&manuk&"') and (alokbulan = '"&bln&"') and (aloktahun = '"&thn&"'))",conn
	if rs.bof then
		pvprod = 0	
		pvku = 0
	else
		pvprod = rs("sum(produp)")	
		pvku = rs("sum(postingup)")
	end if
rs.close
if isnull(pvprod) = false then
	pvprod = pvprod+prodreg+proddepo
else
	pvprod = prodreg+proddepo
end if		

rs.Open "SELECT sum(pvpri) FROM st_sale_daftar where ((noseri like '"&manuk&"') and (alokbulan = '"&bln&"') and (aloktahun = '"&thn&"'))",conn
	if rs.bof then
		pvreg = 0
	else
		pvreg = rs("sum(pvpri)")
	end if		
rs.close
if isnull(pvreg) = false then
	pvreg = pvreg
else
	pvreg = 0
end if	

if isnull(pvku) = false then
	pvku = pvku+pvreg+pvdepo
else
	pvku = pvreg+pvdepo
end if
jummurni = pvku + pvprod

p1 = "L"
rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
	if rsA.bof then
		lanjutmanuk = "F"
		pvkirikuiki = 0	
		pvfullkiri = 0
	else
		piro = clng(rsA("count(id)"))
		pvkirikuiki = 0	
		pvfullkiri = 0
	end if
rsA.close
if isnull(piro) = false then
	if piro > 0 then
		lanjutmanuk = "T"
	else
		lanjutmanuk = "F"
	end if		
else
	lanjutmanuk = "F"	
end if

if lanjutmanuk = "T" then	
	rs.Open "SELECT pose,sum(postingup),sum(pvfull) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",conn
		if rs.bof then
			pvkirikuiki = 0
			pvfullkiri = 0
		else
			pvkirikuiki = rs("sum(postingup)")
			pvfullkiri = rs("sum(pvfull)")
		end if
	rs.close
	if isnull(pvkirikuiki) = false then
		pvkirikuiki = pvkirikuiki
	else
		pvkirikuiki = 0
	end if
	
	if isnull(pvfullkiri) = false then
		pvfullkiri = pvfullkiri
	else
		pvfullkiri = 0
	end if	
end if

p1 = "R"
rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
	if rsA.bof then
		lanjutmanuk = "F"
		pvkanankuiki = 0	
		pvfullkanan = 0
	else
		piro = clng(rsA("count(id)"))
		pvkanankuiki = 0	
		pvfullkanan = 0
	end if
rsA.close
if isnull(piro) = false then
	if piro > 0 then
		lanjutmanuk = "T"
	else
		lanjutmanuk = "F"
	end if		
else
	lanjutmanuk = "F"	
end if

if lanjutmanuk = "T" then
	rs.Open "SELECT pose,sum(postingup),sum(pvfull) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",conn
		if rs.bof then
			pvkanankuiki = 0
			pvfullkanan = 0
		else
			pvkanankuiki = rs("sum(postingup)")
			pvfullkanan = rs("sum(pvfull)")
		end if
	rs.close
	if isnull(pvkanankuiki) = false then
		pvkanankuiki = pvkanankuiki
	else
		pvkanankuiki = 0
	end if
	
	if isnull(pvfullkanan) = false then
		pvfullkanan = pvfullkanan
	else
		pvfullkanan = 0
	end if	
end if


	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&manuk&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"'))",conn,3,3
		if rs.bof then
			rs.addnew
				rs("kta") = manuk
				rs("bulan") = bln
				rs("tahun") = thn
				rs("pvpribadi") = pvku
				rs("produp") = pvprod
				rs("pvmurni") = jummurni
				rs("pvgrupkiri") = pvkirikuiki
				rs("pvgrupkanan") = pvkanankuiki
				rs("pvfull_kiri") = pvfullkiri
				rs("pvfull_kanan") = pvfullkanan
			rs.update	
		else
			session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
				Call OpenDBG()
				strSQLG = "UPDATE bns_mypv_current SET pvfull_kanan="&pvfullkanan&",pvfull_kiri="&pvfullkiri&",pvgrupkiri="&pvkirikuiki&",pvgrupkanan="&pvkanankuiki&",pvpribadi="&pvku&",produp="&pvprod&",pvmurni="&jummurni&" WHERE kta like '"&manuk&"' and bulan='"&bln&"' and tahun='"&thn&"'"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
			session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia	
		end if
	rs.close 
	pvkirima = pvkirikuiki
	pvkananma = pvkanankuiki
	jumtupoku = pvku + pvprod
				
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' SUB AGENCY
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
if upm = "TT" then

'	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&ma2&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"'))",conn,3,3
'		if rs.bof then
'			pvkananma2 = 0
'			pvkirima2 = 0
'		else
'			pvkirima2 = rs("pvgrupkiri")
'			pvkananma2 = rs("pvgrupkanan")
'		end if
'	rs.close 
	
'	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&ma3&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"'))",conn,3,3
'		if rs.bof then
'			pvkananma3 = 0
'			pvkirima3 = 0
'		else
'			pvkirima3 = rs("pvgrupkiri")
'			pvkananma3 = rs("pvgrupkanan")
'		end if
'	rs.close 	

	p1 = "L"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma2 = "F"
			pvkirikuikima2 = 0
		else
			piro = clng(rsA("count(id)"))
			pvkirikuikima2 = 0
		end if
	rsA.close
	if isnull(piro) = false then
		if piro > 0 then
			lanjutma2 = "T"
		else
			lanjutma2 = "F"
		end if		
	else
		lanjutma2 = "F"	
	end if
	
	if lanjutma2 = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkirikuikima2 = 0
			else
				pvkirikuikima2 = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkirikuikima2) = false then
			pvkirikuikima2 = pvkirikuikima2
		else
			pvkirikuikima2 = 0
		end if
	end if
		
	p1 = "R"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma2 = "F"
			pvkanankuikima2 = 0
		else
			piro = clng(rsA("count(id)"))
			pvkanankuikima2 = 0
		end if
	rsA.close
	if isnull(piro) = false then
		if piro > 0 then
			lanjutma2 = "T"
		else
			lanjutma2 = "F"
		end if		
	else
		lanjutma2 = "F"	
	end if
	
	if lanjutma2 = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkanankuikima2 = 0
			else
				pvkanankuikima2 = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkanankuikima2) = false then
			pvkanankuikima2 = pvkanankuikima2
		else
			pvkanankuikima2 = 0
		end if
	end if
	
	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&ma2&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"'))",conn,3,3
		if rs.bof then
			rs.addnew
				rs("kta") = ma2
				rs("bulan") = bln
				rs("tahun") = thn
				rs("pvpribadi") = 0
				rs("produp") = 0
				rs("pvmurni") = 0
				rs("pvgrupkiri") = pvkirikuikima2
				rs("pvgrupkanan") = pvkanankuikima2
			rs.update
		else
			session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
				Call OpenDBG()
				strSQLG = "UPDATE bns_mypv_current SET pvgrupkiri="&pvkirikuikima2&",pvgrupkanan="&pvkanankuikima2&" WHERE kta like '"&ma2&"' and bulan='"&bln&"' and tahun='"&thn&"'"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
			session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
			'rs.update
			'	rs("pvgrupkiri") = pvkirikuikima2
			'	rs("pvgrupkanan") = pvkanankuikima2
			'rs.update
		end if
	rs.close 
	pvkirima2 = pvkirikuikima2
	pvkananma2 = pvkanankuikima2



	p1 = "L"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma3 = "F"
			pvkirikuikima3 = 0
		else
			piro = clng(rsA("count(id)"))
			pvkirikuikima3 = 0
		end if
	rsA.close
	if isnull(piro) = false then
		if piro > 0 then
			lanjutma3 = "T"
		else
			lanjutma3 = "F"
		end if		
	else
		lanjutma3 = "F"	
	end if
	
	if lanjutma3 = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkirikuikima3 = 0
			else
				pvkirikuikima3 = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkirikuikima3) = false then
			pvkirikuikima3 = pvkirikuikima3
		else
			pvkirikuikima3 = 0
		end if
	end if
		
	p1 = "R"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma3 = "F"
			pvkanankuikima3 = 0
		else
			piro = clng(rsA("count(id)"))
			pvkanankuikima3 = 0
		end if
	rsA.close
	if isnull(piro) = false then
		if piro > 0 then
			lanjutma3 = "T"
		else
			lanjutma3 = "F"
		end if		
	else
		lanjutma3 = "F"	
	end if
	
	if lanjutma3 = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkanankuikima3 = 0
			else
				pvkanankuikima3 = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkanankuikima3) = false then
			pvkanankuikima3 = pvkanankuikima3
		else
			pvkanankuikima3 = 0
		end if
	end if
	
	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&ma3&"') and (bulan = '"&bln&"') and (tahun = '"&thn&"'))",conn,3,3
		if rs.bof then
			rs.addnew
				rs("kta") = ma3
				rs("bulan") = bln
				rs("tahun") = thn
				rs("pvpribadi") = 0
				rs("produp") = 0
				rs("pvmurni") = 0
				rs("pvgrupkiri") = pvkirikuikima3
				rs("pvgrupkanan") = pvkanankuikima3
			rs.update
		else
			session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
				Call OpenDBG()
				strSQLG = "UPDATE bns_mypv_current SET pvgrupkiri="&pvkirikuikima3&",pvgrupkanan="&pvkanankuikima3&" WHERE kta like '"&ma3&"' and bulan='"&bln&"' and tahun='"&thn&"'"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
			session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
			'rs.update
			'	rs("pvgrupkiri") = pvkirikuikima3
			'	rs("pvgrupkanan") = pvkanankuikima3
			'rs.update
		end if
	rs.close 
	pvkirima3 = pvkirikuikima3
	pvkananma3 = pvkanankuikima3

end if 'akhir upme sub agency (bulan berjalan)

if jumtupoku < mintupo then
	pvkirima = 0
	pvkananma = 0
	pvkirima2 = 0
	pvkananma2 = 0
	pvkirima3 = 0
	pvkananma3 = 0
else
	pvkirima = pvkirikuiki
	pvkananma = pvkanankuiki
	pvkirima2 = pvkirikuikima2
	pvkananma2 = pvkanankuikima2
	pvkirima3 = pvkirikuikima3
	pvkananma3 = pvkanankuikima3	
end if


''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' menentukan masa topup atau tdak
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
ikidino = skr
bulanskr = clng(month(ikidino))
tahunskr = clng(year(ikidino))

if bln = 1 then
	blnlalu = 12
	thnlalu = thn-1
else
	blnlalu = bln-1
	thnlalu = thn
end if	

if bulanskr = 1 then
	bulanku = 12
	tahunku = tahunskr-1
else
	bulanku = bulanskr-1
	tahunku = tahunskr
end if		
	
	rs.Open "SELECT * FROM tab_closing WHERE bulantupo = '"&bulanku&"' and tahuntupo = '"&tahunku&"'",conn
		if rs.bof then
			tgltupo_awal = now()
			tgltupo_akhir = now()
			bulantupo = month(now())
			tahuntupo = year(now())			
		else
			tglklosing = rs("tglclosing")
			tglbaru = rs("tglnewseasson")
			bulantupo = clng(rs("bulantupo"))
			tahuntupo = clng(rs("tahuntupo"))
		end if	
	rs.close
	
	tglklosing1 = int(day(tglklosing))
	blnklosing1 = int(month(tglklosing))
	thnklosing1 = int(year(tglklosing))	
	
	tglbaru1 = int(day(tglbaru))
	blnbaru1 = int(month(tglbaru))
	thnbaru1 = int(year(tglbaru))		

tupoawal1 = cdate(cstr(tglklosing1)+"/"+cstr(blnklosing1)+"/"+cstr(thnklosing1)+" "+"00:00:00")
tupoakhir1 = cdate(cstr(tglbaru1)+"/"+cstr(blnbaru1)+"/"+cstr(thnbaru1)+" "+"00:00:00")

if tupoawal1 <= ikidino and tupoakhir1 => ikidino then
	keterangan = "TOP UP SESSION"
	masatopup = "T"
else
	masatopup = "F"
end if	


if masatopup = "T" then 'update dari mydistri waktu masih masuk masa top up

proddepolalu = 0
pvprodlalu = 0
pvdepolalu = 0
pvprilalu = 0
bvprilalu = 0
prodreglalu = 0
pvreglalu = 0
pvkulalu = 0
jummurnilalu = 0
rs.Open "SELECT * FROM bns_depositrelease where ((kta like '"&manuk&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"'))",conn
	if rs.bof then
		proddepolalu = 0
		pvdepolalu = 0
	else
		proddepolalu = rs("pvprod")
		pvdepolalu = rs("pvpri")
	end if		
rs.close

rs.Open "SELECT sum(produp) FROM bns_mypv_prod_reg where ((kta like '"&manuk&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"'))",conn
	if rs.bof then
		prodreglalu = 0
	else
		prodreglalu = rs("sum(produp)")
	end if		
rs.close
if isnull(prodreglalu) = false then
	prodreglalu = prodreglalu
else
	prodreglalu = 0	
end if	
		
rs.Open "SELECT sum(produp),sum(postingup) FROM st_sale_prd_head where ((nodist like '"&manuk&"') and (alokbulan = '"&blnlalu&"') and (aloktahun = '"&thnlalu&"'))",conn
	if rs.bof then
		pvprodlalu = 0	
		pvkulalu = 0
	else
		pvprodlalu = rs("sum(produp)")	
		pvkulalu = rs("sum(postingup)")
	end if
rs.close
if isnull(pvprodlalu) = false then
	pvprodlalu = pvprodlalu+prodreglalu+proddepolalu
else
	pvprodlalu = prodreglalu+proddepolalu
end if	

if isnull(pvprodlalu) = false then
	pvprodlalu = pvprodlalu
else
	pvprodlalu = 0
end if			

rs.Open "SELECT sum(pvpri) FROM st_sale_daftar where ((noseri like '"&manuk&"') and (alokbulan = '"&blnlalu&"') and (aloktahun = '"&thnlalu&"'))",conn
	if rs.bof then
		pvreglalu = 0
	else
		pvreglalu = rs("sum(pvpri)")
	end if		
rs.close
if isnull(pvreglalu) = false then
	pvreglalu = pvreglalu
else
	pvreglalu = 0
end if	

if isnull(pvkulalu) = false then
	pvkulalu = pvkulalu+pvreglalu+pvdepolalu
else
	pvkulalu = pvreglalu+pvdepolalu
end if

jummurnilalu = pvkulalu + pvprodlalu
if isnull(jummurnilalu) = false then
	jummurnilalu = jummurnilalu
else
	jummurnilalu = 0
end if

if isnull(pvkulalu) = false then
	pvkulalu = pvkulalu
else
	pvkulalu = 0
end if		
	
			
p1 = "L"
rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
	if rsA.bof then
		lanjutmanuklalu = "F"
		pvkirikuikilalu = 0	
		pvfullkirilalu = 0
	else
		pirolalu = clng(rsA("count(id)"))
		pvkirikuikilalu = 0	
		pvfullkirilalu = 0
	end if
rsA.close
if isnull(pirolalu) = false then
	if pirolalu > 0 then
		lanjutmanuklalu = "T"
	else
		lanjutmanuklalu = "F"
	end if		
else
	lanjutmanuklalu = "F"	
end if

if lanjutmanuklalu = "T" then	
	rs.Open "SELECT pose,sum(postingup),sum(pvfull) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",conn
		if rs.bof then
			pvkirikuikilalu = 0
			pvfullkirilalu = 0
		else
			pvkirikuikilalu = rs("sum(postingup)")
			pvfullkirilalu = rs("sum(pvfull)")
		end if
	rs.close
	if isnull(pvkirikuikilalu) = false then
		pvkirikuikilalu = pvkirikuikilalu
	else
		pvkirikuikilalu = 0
	end if
	
	if isnull(pvfullkirilalu) = false then
		pvfullkirilalu = pvfullkirilalu
	else
		pvfullkirilalu = 0
	end if	
end if

p1 = "R"
rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
	if rsA.bof then
		lanjutmanuklalu = "F"
		pvkanankuikilalu = 0
		pvfullkananlalu = 0	
	else
		pirolalu = clng(rsA("count(id)"))
		pvkanankuikilalu = 0	
		pvfullkananlalu = 0
	end if
rsA.close
if isnull(pirolalu) = false then
	if pirolalu > 0 then
		lanjutmanuklalu = "T"
	else
		lanjutmanuklalu = "F"
	end if		
else
	lanjutmanuklalu = "F"	
end if

if lanjutmanuklalu = "T" then
	rs.Open "SELECT pose,sum(postingup),sum(pvfull) FROM temp_all_trans where ((upnya like '"&manuk&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",conn
		if rs.bof then
			pvkanankuikilalu = 0
			pvfullkananlalu = 0
		else
			pvkanankuikilalu = rs("sum(postingup)")
			pvfullkananlalu = rs("sum(pvfull)")
		end if
	rs.close
	if isnull(pvkanankuikilalu) = false then
		pvkanankuikilalu = pvkanankuikilalu
	else
		pvkanankuikilalu = 0
	end if
	
	if isnull(pvfullkananlalu) = false then
		pvfullkananlalu = pvfullkananlalu
	else
		pvfullkananlalu = 0
	end if	
end if

	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&manuk&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"'))",conn,3,3
		if rs.bof then
			rs.addnew
				rs("kta") = manuk
				rs("bulan") = blnlalu
				rs("tahun") = thnlalu
				rs("pvpribadi") = pvkulalu
				rs("produp") = pvprodlalu
				rs("pvmurni") = jummurnilalu
				rs("pvgrupkiri") = pvkirikuikilalu
				rs("pvgrupkanan") = pvkanankuikilalu
				rs("pvfull_kiri") = pvfullkirilalu
				rs("pvfull_kanan") = pvfullkananlalu
			rs.update			
		else
			session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
				Call OpenDBG()
				strSQLG = "UPDATE bns_mypv_current SET pvfull_kanan="&pvfullkananlalu&",pvfull_kiri="&pvfullkirilalu&",pvgrupkiri="&pvkirikuikilalu&",pvgrupkanan="&pvkanankuikilalu&",pvpribadi="&pvkulalu&",produp="&pvprodlalu&",pvmurni="&jummurnilalu&"  WHERE kta like '"&manuk&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
			session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia	
		end if
	rs.close 
	pvkirimalalu = pvkirikuikilalu
	pvkananmalalu = pvkanankuikilalu
	
	jumtupolalu = pvkulalu+pvprodlalu	
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' SUB AGENCY
''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
if upm = "TT" then	


	p1 = "L"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma2lalu = "F"
			pvkirikuikima2lalu = 0
		else
			pirolalu = clng(rsA("count(id)"))
			pvkirikuikima2lalu = 0
		end if
	rsA.close
	if isnull(pirolalu) = false then
		if pirolalu > 0 then
			lanjutma2lalu = "T"
		else
			lanjutma2lalu = "F"
		end if		
	else
		lanjutma2lalu = "F"	
	end if
	
	if lanjutma2lalu = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkirikuikima2lalu = 0
			else
				pvkirikuikima2lalu = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkirikuikima2lalu) = false then
			pvkirikuikima2lalu = pvkirikuikima2lalu
		else
			pvkirikuikima2lalu = 0
		end if
	end if
		
	p1 = "R"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma2lalu = "F"
			pvkanankuikima2lalu = 0
		else
			pirolalu = clng(rsA("count(id)"))
			pvkanankuikima2lalu = 0
		end if
	rsA.close
	if isnull(pirolalu) = false then
		if pirolalu > 0 then
			lanjutma2lalu = "T"
		else
			lanjutma2lalu = "F"
		end if		
	else
		lanjutma2lalu = "F"	
	end if
	
	if lanjutma2lalu = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma2&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkanankuikima2lalu = 0
			else
				pvkanankuikima2lalu = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkanankuikima2lalu) = false then
			pvkanankuikima2lalu = pvkanankuikima2lalu
		else
			pvkanankuikima2lalu = 0
		end if
	end if
	
	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&ma2&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"'))",conn,3,3
		if rs.bof then
			rs.addnew
				rs("kta") = ma2
				rs("bulan") = blnlalu
				rs("tahun") = thnlalu
				rs("pvpribadi") = 0
				rs("produp") = 0
				rs("pvmurni") = 0
				rs("pvgrupkiri") = pvkirikuikima2lalu
				rs("pvgrupkanan") = pvkanankuikima2lalu
			rs.update
		else
			session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
				Call OpenDBG()
				strSQLG = "UPDATE bns_mypv_current SET pvgrupkiri="&pvkirikuikima2lalu&",pvgrupkanan="&pvkanankuikima2lalu&" WHERE kta like '"&ma2&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
			session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
			'rs.update
			'	rs("pvgrupkiri") = pvkirikuikima2
			'	rs("pvgrupkanan") = pvkanankuikima2
			'rs.update
		end if
	rs.close 
	pvkirima2lalu = pvkirikuikima2lalu
	pvkananma2lalu = pvkanankuikima2lalu

	p1 = "L"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma3lalu = "F"
			pvkirikuikima3lalu = 0
		else
			pirolalu = clng(rsA("count(id)"))
			pvkirikuikima3lalu = 0
		end if
	rsA.close
	if isnull(pirolalu) = false then
		if pirolalu > 0 then
			lanjutma3lalu = "T"
		else
			lanjutma3lalu = "F"
		end if		
	else
		lanjutma3lalu = "F"	
	end if
	
	if lanjutma3lalu = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkirikuikima3lalu = 0
			else
				pvkirikuikima3lalu = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkirikuikima3lalu) = false then
			pvkirikuikima3lalu = pvkirikuikima3lalu
		else
			pvkirikuikima3lalu = 0
		end if
	end if
		
	p1 = "R"
	rsA.Open "SELECT count(id) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
		if rsA.bof then
			lanjutma3lalu = "F"
			pvkanankuikima3lalu = 0
		else
			pirolalu = clng(rsA("count(id)"))
			pvkanankuikima3lalu = 0
		end if
	rsA.close
	if isnull(pirolalu) = false then
		if pirolalu > 0 then
			lanjutma3lalu = "T"
		else
			lanjutma3lalu = "F"
		end if		
	else
		lanjutma3lalu = "F"	
	end if
	
	if lanjutma3lalu = "T" then
		rsA.Open "SELECT pose,sum(postingup) FROM temp_all_trans where ((upnya like '"&ma3&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"') and (pose like '"&p1&"'))",connA
			if rsA.bof then
				pvkanankuikima3lalu = 0
			else
				pvkanankuikima3lalu = rsA("sum(postingup)")
			end if
		rsA.close
		if isnull(pvkanankuikima3lalu) = false then
			pvkanankuikima3lalu = pvkanankuikima3lalu
		else
			pvkanankuikima3lalu = 0
		end if
	end if
	
	rs.Open "SELECT * FROM bns_mypv_current where ((kta like '"&ma3&"') and (bulan = '"&blnlalu&"') and (tahun = '"&thnlalu&"'))",conn,3,3
		if rs.bof then
			rs.addnew
				rs("kta") = ma3
				rs("bulan") = blnlalu
				rs("tahun") = thnlalu
				rs("pvpribadi") = 0
				rs("produp") = 0
				rs("pvmurni") = 0
				rs("pvgrupkiri") = pvkirikuikima3lalu
				rs("pvgrupkanan") = pvkanankuikima3lalu
			rs.update
		else
			session.lcid=2057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
				Call OpenDBG()
				strSQLG = "UPDATE bns_mypv_current SET pvgrupkiri="&pvkirikuikima3lalu&",pvgrupkanan="&pvkanankuikima3lalu&" WHERE kta like '"&ma3&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'"
				Set rsG =  dBConnG.Execute(strSQLG)
				Call CloseDBG()
			session.lcid=1057 ' setting desimal & local setting untuk indonesia 2057 = uk
			intLocale = SetLocale(2057) ' setting desimal & local setting untuk indonesia
			'rs.update
			'	rs("pvgrupkiri") = pvkirikuikima3
			'	rs("pvgrupkanan") = pvkanankuikima3
			'rs.update
		end if
	rs.close 
	pvkirima3lalu = pvkirikuikima3lalu
	pvkananma3lalu = pvkanankuikima3lalu

end if 'akhir upme sub agency (bulan berjalan)

 

else
	''''''''''''''''''''''''''''''''''''''''''''
	' AMBIL PV BULAN LALU
	''''''''''''''''''''''''''''''''''''''''''''
	pvkirimalalu = 0
	pvkananmalalu = 0
	pvkirima2lalu = 0
	pvkananma2lalu = 0
	pvkirima3lalu = 0
	pvkananma3lalu = 0
	
	rs.Open "SELECT pvgrupkiri,pvgrupkanan,pvpribadi,produp FROM bns_mypv where kta like '"&manuk&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'",conn
		if rs.bof then
			oke = 1
		else
			oke = 2
		end if		
	rs.close
	
	if oke = 1 then			
		rs.Open "SELECT pvgrupkiri,pvgrupkanan,pvpribadi,produp FROM bns_mypv_current where kta like '"&manuk&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'",conn
	else
		rs.Open "SELECT pvgrupkiri,pvgrupkanan,pvpribadi,produp FROM bns_mypv where kta like '"&manuk&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'",conn
	end if
	
		if rs.bof then
			pvkulalu = 0
			pvprodlalu = 0
			pvkirikuikilalu = 0
			pvkanankuikilalu = 0
		else
			pvkulalu = rs("pvpribadi")
			pvprodlalu = rs("produp")
			pvkirikuikilalu = rs("pvgrupkiri")
			pvkanankuikilalu = rs("pvgrupkanan")
		end if
	rs.close
	jumtupolalu =  pvkulalu+pvprodlalu
	
	if upm = "T" then
		if oke = 1 then
			rs.Open "SELECT pvgrupkiri,pvgrupkanan FROM bns_mypv_current where kta like '"&ma2&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'",conn
		else
			rs.Open "SELECT pvgrupkiri,pvgrupkanan FROM bns_mypv where kta like '"&ma2&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'",conn
		end if
			if rs.bof then
				pvkirikuikima2lalu = 0
				pvkanankuikima2lalu = 0
			else
				pvkirikuikima2lalu = rs("pvgrupkiri")
				pvkanankuikima2lalu = rs("pvgrupkanan")
			end if
		rs.close
	
		if oke = 1 then
			rs.Open "SELECT pvgrupkiri,pvgrupkanan FROM bns_mypv_current where kta like '"&ma3&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'",conn
		else
			rs.Open "SELECT pvgrupkiri,pvgrupkanan FROM bns_mypv where kta like '"&ma3&"' and bulan='"&blnlalu&"' and tahun='"&thnlalu&"'",conn
		end if
			if rs.bof then
				pvkirikuikima3lalu = 0
				pvkanankuikima3lalu = 0
			else
				pvkirikuikima3lalu = rs("pvgrupkiri")
				pvkanankuikima3lalu = rs("pvgrupkanan")
			end if
		rs.close
	end if
end if


if jumtupolalu < mintupo then
	pvkirimalalu = 0
	pvkananamalalu = 0
	pvkirima2lalu = 0
	pvkananma2lalu = 0	
	pvkirima3lalu = 0
	pvkananma3lalu = 0
else
	pvkirimalalu = pvkirikuikilalu
	pvkananamalalu = pvkanankuikilalu
	pvkirima2lalu = pvkirikuikima2lalu
	pvkananma2lalu = pvkanankuikima2lalu	
	pvkirima3lalu = pvkirikuikima3lalu
	pvkananma3lalu = pvkanankuikima3lalu	
end if

rs.Open "SELECT grdlevel FROM jenjang where kta like '"&manuk&"'",conn
	if rs.bof then
		rnk = 1
	else	
		rnk = clng(rs("grdlevel"))
	end if
rs.Close

renk = "rnk"
rs.Open "SELECT deskripsi FROM tabdesc where grp like '"&renk&"' and ket = '"&rnk&"'",conn
	if rs.bof then
		rankdown = "DISTRIBUTOR"
	else	
		rankdown = ucase(rs("deskripsi"))
	end if
rs.Close

end if
end if

set rs=nothing
Conn.Close
set conn=nothing

set rsA=nothing
ConnA.Close
set connA=nothing

set rsALL=nothing
ConnALL.Close
set connALL=nothing


%>

<html>

<head>
<meta http-equiv="Content-Language" content="id">
<meta http-equiv="Content-Type" content="text/html; charset=windows-1252">
<title>PT. HWI >> Cek Point</title>

<style type="text/css">
<!--
td {
	font-family:Tahoma;
	font-size:11px;
	color:#4F4F4F;
}
a {
	text-decoration: none;
	color:#31509F;
}
a.1 {
	text-decoration: none;
	color:#BD1818;
}
a.2 {
	text-decoration: underline;
	color:#ffffff;
}
a.3 {
	text-decoration: underline;
	color:#FFD16F;
}
a.4 {
	text-decoration: none;
	color:#FFFFFF;
}
a.5 {
	text-decoration: underline;
	color:#BD1818;
}
.t11 {
	font-family: Tahoma;
	font-size: 11px;
	font-style: normal;
}
.t10 {
	font-family: Tahoma;
	font-size: 10px;
	font-style: normal;
}
.style1 {color: #FFFFFF}
.style2 {color: #616161}
.style3 {color: #31509F}
.style4 {color: #ffffff}

-->
</style>
<style fprolloverstyle>A:hover {font-size: 11px; color: #FF9966; font-family: Tahoma; text-decoration: underline}
</style>

<!--#Include File=pg_turing.asp-->
<script language="JavaScript">
<!--
function formCheck(form) {
if (form.userid.value == "")
{
 alert("Mohon isikan nomor id distributor anda");
return false;}

if (form.password.value == "")
{
 alert("Mohon isikan password login anda");
return false;}

if (form.turing.value == "")
{
 alert("Mohon isikan turing number yang ada pada kolom dibawah text password login");
return false;}
}
// -->
</script>
</head>

<body bgcolor="#FFFFFF">

<table border="1" cellpadding="8" style="border-collapse: collapse" width="100%" cellspacing="1" bordercolor="#808080" bgcolor="#FFFFD2">
	<tr>
		<td valign="top">
		<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%" bgcolor="#FFFFD3">
			<tr>
				<td valign="top">
				<img border="0" src="images/logo_login_cekpoint.jpg" width="189" height="100"></td>
			</tr>
			<tr>
				<td valign="top">
				<table border="1" cellpadding="4" style="border-collapse: collapse" width="100%" cellspacing="1" bordercolor="#808080" bgcolor="#FFFFFF">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
							<tr>
								<td valign="top" bgcolor="#E1F0FF">
								<table border="0" cellpadding="6" style="border-collapse: collapse" width="100%">
									<tr>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td>
												<b>
												<font size="4" color="#000080">
												CLOSING PERIODE</font><font size="4" color="#FF0000"><br>
												</font>
												</b>
												<font color="#000000" size="2">Closing Date untuk bulan ini adalah pada tanggal, jam : </font>
												<% hariakhir = date()%><font color="#000000" size="2">
												<b><font color="#FF0000" size="2"><%=tutup1%></b></font>												
												<br>
												Periode Top Up dibuka tanggal <b>
												<%=tupoawal%></b> sd<b> <%=tupoakhir%></b></font></td>
											</tr>
										</table>
										</td>
									</tr>
								</table>
								</td>
							</tr>
							<tr>
								<td>
								<form name="theform" method="post" action="cekpoint.asp" onSubmit="return formCheck(this)">
								<input type="hidden" name="mode" value="PROSES">
								<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
									<tr>
										<td>&nbsp;</td>
									</tr>
								</table>
								<table border="0" style="border-collapse: collapse" width="100%" cellspacing="1">
									<tr>
										<td width="99" valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">Distributor Id.</font></td>
											</tr>
											<tr>
												<td></td>
											</tr>
										</table>
										</td>
										<td width="9" valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td></td>
											</tr>
										</table>
										</td>
										<td valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td>
												&nbsp;<!--webbot bot="Validation" s-data-type="Number" s-number-separators="x," b-value-required="TRUE" i-minimum-length="7" i-maximum-length="7" --><input type="text" name="userid" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="12" maxlength="7"></td>
											</tr>
											<tr>
												<td><font color="#FF0000">
												<%=errorcek1%></font></td>
											</tr>
										</table>
										</td>
									</tr>
									<tr>
										<td width="99" valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">Password Login</font></td>
											</tr>
											<tr>
												<td></td>
											</tr>
										</table>
										</td>
										<td width="9" valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td></td>
											</tr>
										</table>
										</td>
										<td valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td>
												&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="3" i-maximum-length="30" --><input type="password" name="password" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="20" maxlength="30"></td>
											</tr>
											<tr>
												<td><font color="#FF0000">
												<%=errorcek2%></font></td>
											</tr>
										</table>
										</td>
									</tr>
									<tr>
										<td width="99" valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">Turing Number</font></td>
											</tr>
											<tr>
												<td></td>
											</tr>
										</table>
										</td>
										<td width="9" valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td></td>
											</tr>
										</table>
										</td>
										<td valign="top">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td>
												&nbsp;<!--webbot bot="Validation" b-value-required="TRUE" i-minimum-length="5" i-maximum-length="5" --><input type="text" name="turing" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080" size="10" maxlength="5"></td>
											</tr>
											<tr>
												<td><font color="#FF0000">
												<%=errorcek3%></font></td>
											</tr>
										</table>
										</td>
									</tr>
									<tr>
										<td width="99">
														<table border="2" width="90%" style="border-collapse: collapse" bordercolor="#000000" cellspacing="1" height="25" cellpadding="2">
															<tr>
																<td bgcolor="#000000">
																<p align="center">
																<font size="3">
																<b>
																<font color="#FF0000">
																<%=z1%></font>
																<font color="#FFFF00">
																<%=z2%></font>
																<font color="#00FF00">
																<%=z3%></font><font color="#FFFFFF"> 
																<%=z4%></font></b>
																<b> 
																<font color="#FFFF00"> 
																<%=z5%></font></b></font>																																
																</td>
															</tr>
														</table>										
										</td>
										<td width="9">&nbsp;</td>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td width="93">
										<input type="submit" name="btsub" value="Tampilkan Data" style="font-size: 8pt; font-family: Verdana; border: 1px solid #808080"></td>
												<td>&nbsp;<font color="#FF0000">[
												<a target="_top" href="cekpointclear.asp">
												<font color="#FF0000">Clear 
												Session</font></a> ]</font></td>
											</tr>
										</table>
										</td>
									</form>	
									</tr>
								</table>
								</td>
							</tr>
							</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
			<%if lanjut2 = "T" then %>
			<tr>
				<td valign="top">&nbsp;</td>
			</tr>
			<tr>
				<td valign="top">
				<table border="1" cellpadding="5" style="border-collapse: collapse" width="100%" cellspacing="1" bgcolor="#FFFFFF" bordercolor="#808080">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
							<tr>
								<td valign="top">
		<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
			<tr>
				<td bgcolor="#000080" height="20" valign="middle">
				<p align="center"><font color="#FFFFFF" size="2"><b>INFORMASI 
				OMZET JARINGAN</b></font></td>
			</tr>
			<tr>
				<td>
				<table border="0" cellpadding="5" style="border-collapse: collapse" width="100%" bgcolor="#E6E6E6">
					<tr>
						<td><font color="#000000"><u><b>Anda harus sudah melakukan tutup point 
						</b></u>untuk dapat 
						mendapatkan informasi realtime mengenai posisi omzet 
						jaringan anda. Akan secara otomatis menghitung ulang 
						ketika ada penambahan / perubahan omzet pada salah satu 
						group anda.<br>
						Dibawah ini adalah posisi omset group </font>
						<font color="#FF0000"> <b><blink><%=sopoto%></blink> [ <%=rankdown%> ]</b></font><font color="#000000"> secara 
						realtime hingga <%=now()%></font></td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td bgcolor="#FFFCEE">
				<table border="0" cellpadding="6" style="border-collapse: collapse" width="100%">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
							<tr>
								<td><font color="#000000"><b>PV OMZET GROUP 
								PERIODE BULAN BERJALAN </b></font></td>
							</tr>
							<tr>
								<td>
								<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
									<tr>
										<td width="121"><font color="#000000">
										Periode Omzet</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=monthname(bln)%>&nbsp;<%=thn%></font></td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										PV Tupo</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=formatnumber(pvku+pvprod,2)%> PV</font></td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										PV Pribadi</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=formatnumber(pvku,2)%> PV</font></td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										PV Productivity</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=formatnumber(pvprod,2)%> PV</font></td>
									</tr>																		
									<tr>
										<td width="121"><font color="#000000">
										BUSINESS CENTER (<%=ma%>)</font></td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kiri</font></td>
											</tr>
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kanan</font></td>
											</tr>
										</table>
										</td>
										<td width="14">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
										</table>
										</td>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkirima,2)%> PV</font></td>
											</tr>
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkananma,2)%> PV</font></td>
											</tr>
										</table>
										</td>
									</tr>
									<% if upm = "TT" then %>
									<tr>
										<td width="121">&nbsp;</td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										BUSINESS CENTER-2 (<%=ma2%>)</font></td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kiri</font></td>
											</tr>
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kanan</font></td>
											</tr>
										</table>
										</td>
										<td width="14">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
										</table>
										</td>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkirima2,2)%> PV</font></td>
											</tr>
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkananma2,2)%> PV</font></td>
											</tr>
										</table>
										</td>
									</tr>
									<tr>
										<td width="121">&nbsp;</td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										BUSINESS CENTER-3 (<%=ma3%>)</font></td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kiri</font></td>
											</tr>
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kanan</font></td>
											</tr>
										</table>
										</td>
										<td width="14">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
										</table>
										</td>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkirima3,2)%> PV</font></td>
											</tr>
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkananma3,2)%> PV</font></td>
											</tr>
										</table>
										</td>
									</tr>
									<%end if%>
									</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
			<tr>
				<td bgcolor="#DFFFDF">
				<table border="0" cellpadding="6" style="border-collapse: collapse" width="100%">
					<tr>
						<td valign="top">
						<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
							<tr>
								<td><b><font color="#000000">PV OMZET GROUP 
								PERIODE BULAN LALU<br>
								</font><font color="#FF0000"><%=keterangantup%></font></b></td>
							</tr>
							<tr>
								<td>
								<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
									<tr>
										<td width="121"><font color="#000000">
										Periode Omzet</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=monthname(blnlalu)%>&nbsp;<%=thnlalu%></font></td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										PV Tupo</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=formatnumber(pvkulalu+pvprodlalu,2)%> PV</font></td>
									</tr>									
									<tr>
										<td width="121"><font color="#000000">
										PV Pribadi</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=formatnumber(pvkulalu,2)%> PV</font></td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										PV Productivity</font></td>
										<td width="14"><font color="#000000">:</font></td>
										<td><font color="#000000"><%=formatnumber(pvprodlalu,2)%> PV</font></td>
									</tr>																		
									<tr>
										<td width="121"><font color="#000000">
										BUSINESS CENTER (<%=ma%>)</font></td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kiri</font></td>
											</tr>
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kanan</font></td>
											</tr>
										</table>
										</td>
										<td width="14">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
										</table>
										</td>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkirimalalu,2)%> PV</font></td>
											</tr>
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkananamalalu,2)%> PV</font></td>
											</tr>
										</table>
										</td>
									</tr>
									<% if upm = "TT" then %>
									<tr>
										<td width="121">&nbsp;</td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										BUSINESS CENTER-2 (<%=ma2%>)</font></td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kiri</font></td>
											</tr>
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kanan</font></td>
											</tr>
										</table>
										</td>
										<td width="14">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
										</table>
										</td>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkirima2lalu,2)%> PV</font></td>
											</tr>
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkananma2lalu,2)%> PV</font></td>
											</tr>
										</table>
										</td>
									</tr>
									<tr>
										<td width="121">&nbsp;</td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121"><font color="#000000">
										BUSINESS CENTER-3 (<%=ma3%>)</font></td>
										<td width="14">&nbsp;</td>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td width="121">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kiri</font></td>
											</tr>
											<tr>
												<td width="23">&nbsp;</td>
												<td><font color="#000000">PV 
												Group Kanan</font></td>
											</tr>
										</table>
										</td>
										<td width="14">
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
											<tr>
												<td><font color="#000000">:</font></td>
											</tr>
										</table>
										</td>
										<td>
										<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkirima3lalu,2)%> PV</font></td>
											</tr>
											<tr>
												<td><font color="#000000">
												<%=formatnumber(pvkananma3lalu,2)%> PV</font></td>
											</tr>
										</table>
										</td>
									</tr>
									<%end if%>
									</table>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
			</table>
								</td>
							</tr>
						</table>
						</td>
					</tr>
				</table>
				</td>
			</tr>
			<%end if%>
			<tr>
				<td valign="top">&nbsp;</td>
			</tr>
		</table>
		</td>
	</tr>
</table>

<table border="0" cellpadding="0" style="border-collapse: collapse" width="100%">
	<tr>
		<td><font color="#808080"><i>hak cipta IT. PT. Health Wealth 
		International<br>
		@2013</i></font></td>
	</tr>
</table>

</body>

</html>
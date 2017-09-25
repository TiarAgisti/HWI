<%
dino = now()
bln = month(dino)
thn = year(dino)
strYear = year(dino)
dim tutup1
dim tutup2
dim wulpos
dim nuhun
dim wulposlalu
dim nuhunlalu
dim wultupo
dim nuhuntupo

if bln=1 or bln=3 or bln=5 or bln=7 or bln=8 or bln=10 or bln=12 then
	strDays = 31
else	
if bln=4 or bln=6 or bln=9 or bln=11 then
	strDays = 30
else
	if  ((cint(strYear) mod 4 = 0  and cint(strYear) mod 100 <> 0) or ( cint(strYear) mod 400 = 0)) then
	  strDays = 28
	else
	  strDays = 28
	end if	
end if
end if

blne = bln+1
if blne = 13 then
	bln1 = 2
	thn1 = thn+1
else
	bln1 = blne
	thn1 = thn
end if		

'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
' closing date session
' ganti parameter ini setiap akhir periode bulanan
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
strDays1 = 1 ' closing date parameter, ganti parameter ini bila tanggal closing diundur
bulclos = 6 ' closing month parameter GANTI PARAMETER INI TIAP BULAN MAJU TIAP BULAN +1 -----------
tahunclos = 2016 ' closing year parameter

wulnow = 7 ' BULAN CURRENT OMZET TUTUP POINT GANTI PARAMETER INI TIAP BULAN MAJU TIAP BULAN +1 -----------
nahunnow = 2016 ' GANTI PARAMETER INI TIAP TAHUN

tutup1 = cdate(cstr(strdays)+"/"+cstr(bln)+"/"+cstr(thn)+" "+"23:59:59")
tutup2 = cdate(cstr(strdays1)+"/"+cstr(bln1)+"/"+cstr(thn1)+" "+"00:00:00")

'''''''''''''''''''''''''''''''
' alokbulan session
'''''''''''''''''''''''''''''''
gal1 = day(dino)
gal2 = month(dino)
gal3 = year(dino)

if gal1 >= strdays1 and gal2 = bulclos and gal3 = tahunclos then
	wulpos = month(dino)
	nuhun = year(dino)
	wulposlalu = bln-1
	nuhunlalu = thn
else
   	wulpos = wulnow
   	nuhun = nahunnow
	wulposlalu = 8
	nuhunlalu = 2015	
end if

'''''''''''''''''''''''''''''''
' top up session
'''''''''''''''''''''''''''''''
dim tupoawal
dim tupoakhir
dim wulupdateharian
dim nuhunupdateharian
dim wulupdateharian1
dim nuhunupdateharian1
dim tgltupo_akhir

tgltupo_awal = 1 
blntupo_awal = 7 ' GANTI TIAP BULAN (+1 TIAP BULAN) -----------
thntupo_awal = 2016 ' GANTI TIAP TAHUN

tgltupo_akhir = 4
blntupo_akhir = 7 ' GANTI TIAP BULAN (+1 TIAP BULAN) -----------
thntupo_akhir = 2016 ' GANTI TIAP TAHUN

wultupo = 6 ' BULAN TOP UP GANTI TIAP BULAN (+1 TIAP BULAN) -----------
nuhuntupo = 2016 ' GANTI TIAP TAHUN

wulupdateharian = wultupo ' GANTI SESUAI WULTUPO UNTUK UPDATE PV HARIAN OTOMATIS RUNNING BY SERVER
nuhunupdateharian = nuhuntupo

wulupdateharian1 = wulpos ' NGIKUT SESUAI CURRENT PV UNTUK UPDATE PV HARIAN OTOMATIS RUNNING BY SERVER
nuhunupdateharian1 = nuhun

tupoawal = cdate(cstr(tgltupo_awal)+"/"+cstr(blntupo_awal)+"/"+cstr(thntupo_awal)+" "+"00:00:00")
tupoakhir = cdate(cstr(tgltupo_akhir)+"/"+cstr(blntupo_akhir)+"/"+cstr(thntupo_akhir)+" "+"10:59:59")
%>

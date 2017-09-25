<%
dim sesidagang
DinoTutup = WeekDay(date())
gabung = now()

x1 = cdate((cstr(year(date()))+"-"+cstr(month(date()))+"-"+cstr(day(date()))+" ")+cstr("05:00:00"))
if DinoTutup = 7 then ' batas akhir order online pada hari sabtu
	x2 = cdate((cstr(year(date()))+"-"+cstr(month(date()))+"-"+cstr(day(date()))+" ")+cstr("23:00:00"))
else
	x2 = cdate((cstr(year(date()))+"-"+cstr(month(date()))+"-"+cstr(day(date()))+" ")+cstr("23:00:00"))
end if

if DinoTutup = 1 then ' hari minggu tidak ada online order
	sesidagang = "F"
else
	if gabung >= x1 and gabung <= x2 then
		sesidagang = "T"
	else	
		sesidagang = "F"
	end if
end if

sesidagang = "T"
%>
<%
'if fromto = "" then
'	pathasal = "maintenance.asp"
'else
	pathasal = "../maintenance.asp"
'end if
		
'''''''''''''''''''''''''''''''''''''
' sistem down 
'''''''''''''''''''''''''''''''''''''
tglsistem = date()
harisistem = day(tglsistem)
bulansistem = month(tglsistem)
tahunsistem = year(tglsistem)

'if harisistem >= 6 and bulansistem = 8 and tahunsistem = 2011 then
'	session("alasandown") = "Update patch security dan backup database"
'	response.redirect pathasal
'else
'	session("alasandown") = ""	
'end if
%>

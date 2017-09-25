<!--#Include File=dbcon/opendb.asp-->
<%
dim posenye
bbb = "rnk"
rs.Open "SELECT * FROM tabdesc where ket like '"&grdle&"' and grp like '"&bbb&"'",conn	
	if rs.bof then
		posenye = "Distributor"
	else
		posenye = ucase(rs("deskripsi"))
	end if
rs.Close
%>

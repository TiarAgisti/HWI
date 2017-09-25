<% Response.contentType="text/xml"%>
<%
 dim kode
 kode =trim(Request.QueryString.Item(1))
%>

<!--#Include File=dbcon/opendb.asp-->
<%
rs.Open "SELECT kta,uid FROM member WHERE kta like '"&kode&"'",conn
	if rs.bof then
		namab = "NOT FOUND"
	else
		namab = ucase(rs("uid"))
	end if	
rs.close                                                       
set conn=nothing		
 
response.write "<xmlresponse>"
response.write "<data>" & namab & "</data>"
response.write "</xmlresponse>"
%>

<%
Response.Buffer=True
Response.CacheControl = "no-cache"
Response.AddHeader "Pragma", "no-cache"
Response.Expires = -1
Response.ExpiresAbsolute = Now()-1
session("errorcek1") = ""
session("errorcek2") = ""
session("errorcek3") = ""
manuk = ""
lanjut2 = ""
response.redirect "cekpoint.asp"
%>
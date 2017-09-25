<%
Response.Buffer=True

'The following three lines of code are used to ensure that this page is not cached on the client.
Response.CacheControl = "no-cache"
Response.AddHeader "Pragma", "no-cache"
Response.Expires = -1

'Set the session variable to an empty string and also destroy the session to make
'to complete the user session.
	Session.Contents("manuk")= ""	
Session.Abandon
Response.Redirect "default.asp"
Response.End
%>

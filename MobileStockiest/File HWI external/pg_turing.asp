<%
Function Password_GenPass2( nNoChars, sValidChars )
Const szDefault = "632918475ABCDEFGHIJKLMNPQRSTUVWXYZabcdefghijklmnpqrstuvwxyz"
dim z1
dim z2
dim z3
dim z4
dim z5

Randomize 'init random

If sValidChars = "" Then
sValidChars = szDefault
End If
nLength = Len( sValidChars )

For nCount = 1 To nNoChars
nNumber = Int((nLength * Rnd) + 1)
sRet = sRet & Mid( sValidChars, nNumber, 1 )
Next
Password_GenPass2 = sRet
End Function

zurinx = Password_GenPass2(5, "" )

z1 = mid(zurinx,1,1)
z2 = mid(zurinx,2,1)
z3 = mid(zurinx,3,1)
z4 = mid(zurinx,4,1)
z5 = mid(zurinx,5,1)
session("buring") = zurinx
%>

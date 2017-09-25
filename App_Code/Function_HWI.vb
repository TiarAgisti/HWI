'*****************************************************************************************************
'Program Name      : GeneralFunction.bas
'Program Function  : General Function related to Logical process only
'Created by        : Sugianto
'Last Modification : 01 Agustus 2004
'*****************************************************************************************************

Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.ODBC
Imports Microsoft.VisualBasic
Imports System.Security.Cryptography



Public Class FunctionHWI
    Dim objMGF As New IASClass.ucmGeneralFunction
    Dim objMGS As New IASClass.ucmGeneralSystem



    Function SafeSQL(ByVal sInput) As String
        Dim TempString As String
        Dim iCounter As Integer

        TempString = sInput
        Dim sBadChars() As String = {"SELECT", "HAVING", "*", "ALTER", "DROP", ";", "--", "INSERT", "DELETE", "xp_", "#", "%", "&", "'", "(", ")", "/", "\", ":", ";", "<", ">", "=", "[", "]", "?", "`", "|"}
        For iCounter = 0 To UBound(sBadChars)
            TempString = Replace(TempString, sBadChars(iCounter), "")
        Next
        SafeSQL = TempString



    End Function

    Function decodeString(ByVal strInputEntry As String) As String

        'Decode HTML character entities

        strInputEntry = Replace(strInputEntry, "&#097;", "a", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#098;", "b", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#099;", "c", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#100;", "d", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#101;", "e", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#102;", "f", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#103;", "g", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#104;", "h", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#105;", "i", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#106;", "j", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#107;", "k", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#108;", "l", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#109;", "m", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#110;", "n", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#111;", "o", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#112;", "p", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#113;", "q", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#114;", "r", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#115;", "s", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#116;", "t", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#117;", "u", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#118;", "v", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#119;", "w", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#120;", "x", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#121;", "y", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#122;", "z", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#065;", "A", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#066;", "B", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#067;", "C", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#068;", "D", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#069;", "E", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#070;", "F", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#071;", "G", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#072;", "H", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#073;", "I", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#074;", "J", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#075;", "K", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#076;", "L", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#077;", "M", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#078;", "N", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#079;", "O", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#080;", "P", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#081;", "Q", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#082;", "R", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#083;", "S", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#084;", "T", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#085;", "U", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#086;", "V", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#087;", "W", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#088;", "X", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#089;", "Y", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#090;", "Z", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#048;", "0", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#049;", "1", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#050;", "2", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#051;", "3", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#052;", "4", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#053;", "5", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#054;", "6", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#055;", "7", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#056;", "8", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#057;", "9", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#061;", "=", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&lt;", "<", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&gt;", ">", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&amp;", "&", 1, -1, 0)
        strInputEntry = Replace(strInputEntry, "&#146;", "'", 1, -1, 1)

        'Return
        decodeString = strInputEntry
    End Function
End Class

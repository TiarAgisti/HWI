Imports System
Imports System.Data
Imports System.Data.OleDb

Partial Class pagesetting_MsPageMainMenu
    Inherits System.Web.UI.MasterPage

    Dim mlOBJGS As New IASClass.ucmGeneralSystem
    Dim mlOBJGF As New IASClass.ucmGeneralFunction

    Dim mlREADER As OleDb.OleDbDataReader
    Dim mlSQL As String
    Dim mlENCRYPTCODE As String
    Dim mlIPADDRINFO As String
    Dim mpP1 As String
    Dim mpP2 As String
    Dim mpTYPE As String

    Dim strTreeMenu As String
    Dim mlDATATABLE As DataTable

    Protected Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load


        mlOBJGS.Main()

        strTreeMenu = "<ul class=sidebar-menu>" & vbCrLf
        strTreeMenu += "<li class=header>MAIN MENU" & vbCrLf
        strTreeMenu += "</li>" & vbCrLf
        strTreeMenu += "<li class=active treeview>" & vbCrLf
        'strTreeMenu += "<ul class=treeview-menu>" & vbCrLf

        mlSQL = "SELECT [entity_id],[menu_id],[menu_parent_id],[menu_name],[menu_path],[menu_level],[menu_transtype]" & vbCrLf
        mlSQL += "     ,[menu_sysid],[menu_status],[menu_flag],[menu_param],[create_user],[create_date],[update_user],[update_date]" & vbCrLf
        mlSQL += "FROM [ADM_HWI].[dbo].[AD_APPMENU]" & vbCrLf
        mlREADER = mlOBJGS.DbRecordset(mlSQL, "AD", "AD")
        If mlREADER.HasRows Then

            'mlDATATABLE = New DataTable()
            'mlDATATABLE.Load(mlREADER)
            'For i As Integer = 0 To mlDATATABLE.Rows.Count - 1
            '    mlDATATABLE.Select("MsMenuItem_Id_0 = " + mlDATATABLE.Rows(i)("MsMenuItem_Id").ToString())
            '    String UnOrderLsit = GenerateUL(parentMenus, dtMenu, sb)

            'Next


            While mlREADER.Read()
                'strTreeMenu += "<li>" & vbCrLf
                If mlREADER("menu_path") = "#" Then
                    strTreeMenu += "<a href=" & mlREADER("menu_path").ToString() & "><i class='fa fa-circle-o'></i> " & mlREADER("menu_name").ToString() & "</a>" & vbCrLf
                Else
                    strTreeMenu += "<a href=" & mlREADER("menu_path").ToString() & "><i class='fa fa-circle-o'></i> " & mlREADER("menu_name").ToString() & "</a>" & vbCrLf
                    strTreeMenu += "<ul class=treeview-menu>" & vbCrLf
                    strTreeMenu += "<li>" & vbCrLf
                    strTreeMenu += "<a href=" & mlREADER("menu_path").ToString() & "><i class='fa fa-circle-o'></i> " & mlREADER("menu_name").ToString() & "</a>" & vbCrLf
                    strTreeMenu += "</li>" & vbCrLf
                    strTreeMenu += "</ul>" & vbCrLf
                End If


                'Else
                'strTreeMenu += "<a href=" & mlREADER("menu_path").ToString() & "><i class='fa fa-circle-o'></i> " & mlREADER("menu_name").ToString() & "</a>" & vbCrLf
                'End If


                'strTreeMenu += "</li>" & vbCrLf
            End While

        End If
        'strTreeMenu += "</ul>" & vbCrLf
        strTreeMenu += "</li>" & vbCrLf
        strTreeMenu += "</ul>" & vbCrLf

        'TreeMenu.InnerHtml = strTreeMenu
    End Sub

    '  Function GenerateUL(menu As DataRow[] , table As DataTable , sb As StringBuilder )  As String 

    '	    sb.AppendLine("<ul>");
    '        If Len(menu) > 0 Then
    '            For Each dr As DataRow In menu

    '            Next

    '        End If

    '{
    '		    foreach (DataRow dr in menu) {
    '			    //Dim handler As String = dr("Handler").ToString()
    '			    string menuText = dr["title"].ToString();
    '                string url = dr["url"].ToString();
    '                string target = "";
    '                if(url != "#" )
    '                {
    '                    target = "ContentFrame";
    '                }
    '			    //string line = String.Format("<li><a href="#">{0}</a>", menuText);
    '                string line = String.Format("<li><div class='menu_body'><a href=" + url + " target =" + target + ">{0}</a></div>", menuText);  
    '			    sb.Append(line);

    '                string pid = dr["MsMenuItem_Id"].ToString();

    '                DataRow[] subMenu = table.Select(String.Format("MsMenuItem_Id_0 = {0}", pid));
    '			    if (subMenu.Length > 0) {
    '				    dynamic subMenuBuilder = new StringBuilder();
    '				    sb.Append(GenerateUL(subMenu, table, subMenuBuilder));
    '			    }
    '			    sb.Append("</li>");
    '		    }
    '	    }
    '	    sb.Append("</ul>");
    '	    return sb.ToString();


    '    End Function


End Class


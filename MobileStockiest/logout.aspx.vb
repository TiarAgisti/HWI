
Partial Class MobileStockiest_logout
    Inherits System.Web.UI.Page
    Dim sopokiesingposting As String
    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        sopokiesingposting = Session.Contents("motok")
        Response.Buffer = True

        'The following three lines of code are used to ensure that this page is not cached on the client.
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1

        'Set the session variable to an empty string and also destroy the session to make
        'to complete the user session.
        Session.Contents("motok") = ""
        Session.Contents("kowe") = ""
        Session.Contents("menu_bagpos") = ""
        Session.Contents("menu_id") = ""
        Session.Contents("pos_area") = ""
        Session.Contents("indukdc") = ""
        Session.Contents("kelasdc") = ""
        Session.Contents("indukmc") = ""
        Session("error1") = ""
        Session("error1a") = ""
        Session("error2") = ""
        Session("error3") = ""
        Session("asal") = ""
        Session("uid") = ""
        Session("uname") = ""
        Session("out") = ""
        Session("nosesi") = ""
        Session("noinvo") = ""
        Session("lanjutkanterus") = "F"
        Session.Abandon()
        Response.Redirect("login.aspx")
        'session("sopokiesingposting") = sopokiesingposting
        'Response.Redirect "../page_posting_temp.asp"
        Response.End()
    End Sub
End Class

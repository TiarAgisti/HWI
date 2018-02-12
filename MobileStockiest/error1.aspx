<%@ Page Language="VB" AutoEventWireup="false" CodeFile="error1.aspx.vb" Inherits="MobileStockiest_error1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p style="text-align:center">
                Sistem tidak dapat melanjutkan rikues anda yang terakhir<br />
			    Silahkan perbaiki kesalahan seperti yang tertulis dibawah ini.<br />
			    Apabila kesalahan masih berlanjut, silahkan menghubungi kantor pusat.<br />
            </p>
        </div>
        <div>
            <p style="text-align:center;color:#FF0000;font-size:large;">
                <b>
                    <%=error1%>
                </b>
            </p>
        </div>
    </form>
</body>
</html>

<%@ Page Language="VB" AutoEventWireup="false" CodeFile="login.aspx.vb" Inherits="MobileStockiest_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport" />
    <link rel="stylesheet" href="../Scripts/Bootstrap/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../Scripts/Bootstrap/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../Scripts/Bootstrap/dist/css/AdminLTE.min.css" />
    <link rel="stylesheet" href="../Scripts/Bootstrap/dist/css/skins/_all-skins.min.css" />
</head>
<body class="hold-transition login-page">

    <div class="login-box">

        <!-- /.login-logo -->
        <div class="login-box-body">
            <div class="login-logo">
                <img src='../images/logohwi.png' style="height:120px;" alt='' title='#slider-direction-1' />
            </div>
            <div style="text-align:center;">
                PT. HEALTH WEALTH INTERNATIONAL
		MOBILE STOCKIEST LOGIN 2.0
            </div>
            <form name="login" method="post" onsubmit="return formCheck(this)" runat="server">
                 <div class="form-group has-feedback">
                    <input type="text" name='id' class="form-control" placeholder="Mobile Stockiest Id" value="MS-1007100" />
                    <span class="fa fa-briefcase form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <input type="text" name='username' class="form-control" placeholder="User Name" value="jasinta" />
                    <span class="fa fa-users form-control-feedback"></span>
                </div>
                <div class="form-group has-feedback">
                    <input type="password" name='password' class="form-control" placeholder="Password Login" value="pass" />
                    <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                </div>
                <div class="row">
                    <div class='col-xs-6 col-sm-4 col-md-5'>
                        <button type="button" class="btn  btn-lg navbar-inverse">
                            <div id="div_turing" runat="server" class="input-group">
                            </div>
                        </button>
                    </div>
                    <div class='col-xs-6 col-sm-8 col-md-7'>
                        <input type="text" name='turing' class="form-control" placeholder="Turing Number" autofocus="autofocus" />
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-xs-12">
                        <button type="submit" name="btsb" class="btn btn-info btn-block btn-flat" runat="server" onserverclick="Login_Click">Login</button>
                    </div>
                </div>
            </form>


            <!-- /.social-auth-links -->

        </div>
        <!-- /.login-box-body -->
    </div>
    <script lang="JavaScript">
<!--
    function formCheck(form) {
        if (form.id.value == "") {
            alert("Mohon isikan nomor id Distributor Center");
            return false;
        }

        if (form.username.value == "") {
            alert("Mohon isikan user name Distributor Center");
            return false;
        }

        if (form.password.value == "") {
            alert("Mohon isikan password login anda");
            return false;
        }

        if (form.turing.value == "") {
            alert("Mohon isikan turing number");
            return false;
        }
    }
    // -->
    </script>

    <script src="../Scripts/Bootstrap/plugins/jQuery/jQuery-2.2.0.min.js"></script>
    <script src="../Scripts/Bootstrap/bootstrap/js/bootstrap.min.js"></script>
    <script src="../Scripts/Bootstrap/dist/js/app.min.js"></script>
    <script type="text/javascript">
    $('#infodcModal').modal('show');
    </script>
</body>

</html>

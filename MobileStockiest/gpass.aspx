<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="gpass.aspx.vb" Inherits="MobileStockiest_gpass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script type="text/javascript">
<!--
    function formCheck(form) {
        if (form.baru.value == "") {
            alert("Anda belum menulis password login baru anda");
            return false;
        }

        if (form.konfirmasi.value == "") {
            alert("Anda belum menulis ulang password login baru anda");
            return false;
        }

        if (form.password.value == "") {
            alert("Anda belum memasukan password login anda saat ini");
            return false;
        }

        if (form.baru.value != form.konfirmasi.value) {
            alert("Password baru dan tulis ulangnya tidak sama");
            return false;
        }

    }
// -->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header">
        <h1>
            <small>&nbsp;</small>
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
            <li><a href="#">Examples</a></li>
            <li class="active">Pace page</li>
        </ol>
    </section>
    <section class="content-header">
        <div class="box">
            <div class="box-header with-border">
                <h3 class="box-title">Mengganti Password Login</h3>
                <div class="box-tools pull-right">
                    <button type="button" class="btn btn-box-tool" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                        <i class="fa fa-minus"></i>
                    </button>
                    <button type="button" class="btn btn-box-tool" data-widget="remove" data-toggle="tooltip" title="Remove">
                        <i class="fa fa-times"></i>
                    </button>
                </div>
            </div>
            <div class="box-body">
                <%--<form name="theform" method="post" action="gpass.aspx" onsubmit="return formCheck(this)">

               </form>--%>

                <div class="row">
                    <div class="col-lg-12 form-horizontal">
                        <div class="form-group">
                            <label class="col-lg-2 col-form-label">MS. Id.</label>
                            <div class="col-lg-10">
                                <%=mypos%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 col-form-label">Nama User</label>
                            <div class="col-lg-10">
                                <%=namauser%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 col-form-label">Nama Login</label>
                            <div class="col-sm-10">
                                <%=loguser%>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 col-form-label">Password Login</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" name="baru" placeholder="password baru">
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 col-form-label">Tulis Ulang Password</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" name="konfirmasi" placeholder="konfirmasi">
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 col-form-label">Password Saat Ini</label>
                            <div class="col-sm-10">
                                <input type="password" class="form-control" name="password" placeholder="password">
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 col-form-label text-danger"></label>
                            <div class="col-sm-10">
                                <button type="submit" name="bts" class="btn btn-primary" runat="server" onserverclick="Gpass_Click">Submit</button>
                            </div>

                        </div>

                        <div class="form-group">
                            <label class="col-sm-2 col-form-label text-danger"></label>
                            <div class="col-sm-10">
                                <label class="col-form-label text-danger"><%=error2%></label>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
            <div class="box-footer">
            </div>
        </div>
    </section>
</asp:Content>


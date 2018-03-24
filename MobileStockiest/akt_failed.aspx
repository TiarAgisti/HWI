<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="akt_failed.aspx.vb" Inherits="MobileStockiest_akt_failed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" Runat="Server">
    <section class="content-header" style="background-color:white;">
        <div class="panel panel-default" style="margin: 10px 10px 10px 10px">
            <div class="panel-heading">
                <h3 class="text-center panel-title">REGISTRATION ERROR</h3>
            </div>
            <div class="panel-body">
                <p style="text-align:center;">
                                Maaf sistem kami mendeteksi terjadinya kesalahan dalam 
		            proses pendaftaran, silahkan ulangi proses pendaftaran dari awal dengan 
		            memperbaiki kesalahan seperti yang tertulis dibawah ini. Apabila 
		            kesalahan masih berlanjut dan berulang, silahkan menghubungi kantor 
		            pusat.
                </p>
                <p style="text-align:center;"><label style="color:#FF0000;"><b><%=error1%></b></label>
            </div>
        </div>
    </section>
</asp:Content>


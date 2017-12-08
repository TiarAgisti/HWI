<%@ Page Title="" Language="VB" MasterPageFile="~/pagesetting/MsPageMS.master" AutoEventWireup="false" CodeFile="sale_renewal.aspx.vb" Inherits="MobileStockiest_sale_renewal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type='text/javascript'>
        function createRequestObject() {
            var ro;
            var browser = navigator.appName;
            if (browser == "Microsoft Internet Explorer") {
                ro = new ActiveXObject("Microsoft.XMLHTTP");
            } else {
                ro = new XMLHttpRequest();
            }
            return ro;
        }
        var xmlhttp = createRequestObject();
        function cari(teks) {
            var kode = teks.value;
            if (!kode) return;
            xmlhttp.open('get', 'getdata_ren.asp?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("harga").value = r[1].firstChild.data;
                    document.getElementById("pv").value = r[2].firstChild.data;
                    document.getElementById("bv").value = r[3].firstChild.data;
                }
                return false;
            }
            xmlhttp.send(null);
        }

        function cari2(teks) {
            var kode = teks.value;
            if (!kode) return;
            xmlhttp.open('get', 'getdataup.asp?kode=' + kode, true);
            xmlhttp.onreadystatechange = function () {
                if ((xmlhttp.readyState == 4) && (xmlhttp.status == 200)) {
                    var r = xmlhttp.responseXML.getElementsByTagName('data');
                    document.getElementById("namadirek").value = r[1].firstChild.data;
                    document.getElementById("upme").value = r[2].firstChild.data;
                    document.getElementById("tipene").value = r[3].firstChild.data;
                }
                return false;
            }
            xmlhttp.send(null);
        }

    </script>


    <script type='text/javascript'>
<!--
    function formCheck(form) {
        if (form.direk.value == "") {
            alert("Silahkan tulis nomor id distributor yang akan direnewal");
            return false;
        }
        if (form.namadirek.value == "NOT FOUND") {
            alert("Silahkan tulis nomor id distributor yang akan direnewal");
            return false;
        }
        if (form.namadirek.value == "") {
            alert("Silahkan tulis nomor id distributor yang akan direnewal");
            return false;
        }
        if (form.paket.value == "") {
            alert("Silahkan pilih paket renewal anda");
            return false;
        }
        if (form.paket.value == "--Silahkan Pilih--") {
            alert("Silahkan pilih paket renewal anda");
            return false;
        }
        if (form.harga.value == 0) {
            alert("Mohon pilih paket renewal anda");
            return false;
        }
        if (form.jumbayar.value == 0) {
            alert("Mohon isikan jumlah pembayaran");
            return false;
        }
        if (confirm("Cek sekali lagi, apakah data yang Anda isi SUDAH BENAR semuanya ? Transaksi yang sudah dibukukan tidak dapat dibatalkan, mohon periksa sekali lagi sebelum check out : \n\nNomor Id. Distributor : " + form.direk.value + ".\nNama Distributor : " + form.namadirek.value + "\nPaket Renewal : " + form.paket.value + "\nHarga : " + form.harga.value + "\nPembayaran : " + form.jumbayar.value + "\n")) {
            return true;
        }
        else {
            return false;
        }
    }
    // -->
    </script>

    <script type='text/javascript'>
        function quadratic1(form1) {
            var tunai = eval(form1.jumbayarcash.value);
            var cc = eval(form1.jumbayarcc.value);
            var db = eval(form1.jumbayardb.value);
            var cek = eval(form1.jumbayarcek.value);
            var jto = eval(form1.harga.value);
            {
                form1.jumbayar.value = tunai + cc + db + cek;
                form1.kembalian.value = (tunai + cc + db + cek) - jto;
            }
        }
    </script>


    <script type='text/javascript'>

    var submitcount = 0;

    function reset() {
        document.theform1.direk.value = "";
        document.theform1.namadirek.value = "";
    }

    function checkFields() {                       // field validation -
        if ((document.theform1.direk.value == "") ||   // checks if fields are blank.
             (document.theform1.namadirek.value == "") ||   // More validation scripts at
             (document.theform1.namadirek.value == "NOT FOUND") ||   // More validation scripts at   
             (document.theform1.paket.value == "") ||   // More validation scripts at     
             (document.theform1.paket.value == "--Silahkan Pilih--") ||   // More validation scripts at            
             (document.theform1.harga.value == "") ||   // More validation scripts at       
             (document.theform1.harga.value == 0) ||   // More validation scripts at   
             (document.theform1.jumbayar.value == "") ||   // More validation scripts at 
             (document.theform1.kembalian.value == "") ||   // More validation scripts at           
             (document.theform1.jumbayar.value == "NaN") ||   // More validation scripts at   
             (document.theform1.kembalian.value == "NaN") ||   // More validation scripts at             
             (document.theform1.jumbayar.value == 0) ||   // More validation scripts at           
             (document.theform1.kembalian.value < 0)) // forms.javascriptsource.com
        {
            alert("Mohon lengkapi form renewal terlebih dulu");
            return false;
        }
        else {
            if (submitcount == 0) {
                submitcount++;
                return true;
            }
            else {
                alert("Form sedang diproses, silahkan tunggu hingga proses posting renewal selesai dilakukan dengan munculnya invoice. Silahkan tutup pesan ini untuk melanjutkan proses renewal.");
                return false;
            }
        }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mpCONTENT" runat="Server">
    <section class="content-header" style="background-color:white;">
        <div style="background-color: grey">
            <h3 style="text-align:center;color:white;font-family:Arial;">PEMBELIAN PAKET RENEWAL</h3>
        </div><br />
        <div class="col-md-12" style="padding: 10px 10px 10px 10px">
            <div style="border-style: solid">
                <div style="padding: 10px 10px 10px 10px; background-color: ">
                    <div style="background-color: #990000">
                        <h4 style="text-align:center;color:white;font-family:Arial;">PERHATIAN</h4>
                    </div>
                    <ol>
                        <li>Paket renewal hanya dapat digunakan oleh distributor yang memasuki masa tenggang, yaitu masa dimana seseorang distributor sudah expired hingga 30 hari kedepan.<br>
                            Sebagai contoh :<br>
                            Si A expired pada tanggal 01 Oktober 2010, maka si A memiliki masa tenggang, yaitu masa dimana si A berkesempatan untuk melakukan renewal hingga maksimal 01 November 2010</li>
                        <li>Apabila si A melewatkan masa tenggang dan tidak melakukan renewal, maka si A akan di suspend permanen secara otomatis oleh sistem.</li>

                        <li>Paket renewal ini memberikan bonus kepada upline 6 level.</li>
                        <li>Paket renewal tidak ber PV.&nbsp;</li>
                    </ol>
                </div>
            </div>
            <div style="padding-top: 10px">
                <div class="alert alert-warning text-center" role="alert">
                    <span class="text-uppercase"><span style="text-decoration: underline; font-weight: bold">ERROR MESSAGE</span></span>
                </div>
            </div>
            <div style="padding: 10px 10px 10px 10px">
                <div style="padding: 10px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Tanggal Transaksi</label>
                    </div>
                    <div class="col-md-8">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Nomer Id. Distributor </label>
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text">
                    </div>
                    <div class="col-md-4">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Keterangan</label>
                    </div>
                    <div class="col-md-8">
                        <label>
                            <textarea readonly class="form-control n-resize"></textarea>
                        </label>
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Harga </label>
                    </div>
                    <div class="col-md-8">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 10px 5px 10px 5px">
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>PV</label>
                    </div>
                    <div class="col-md-2">
                        <input class="form-control" type="text">
                    </div>
                    <div class="col-md-4">
                        <label>BV</label>
                    </div>
                    <div class="col-md-2">
                        <input class="form-control" type="text">
                    </div>
                </div>
                <div style="padding: 20px 5px 20px 5px">
                    <div class="col-md-4">
                        <label>Cara Pembayaran </label>
                    </div>
                    <div class="col-md-8">
                        <table style="width:200px;" border="0">
                            <tr>
                                <td>Tunai</td>
                                <td>:</td>
                                <td>
                                    <input class="form-control" type="text">
                                </td>
                            </tr>
                            <tr>
                                <td>Debit Card </td>
                                <td>:</td>
                                <td>
                                    <input class="form-control" type="text">
                                </td>
                            </tr>
                            <tr>
                                <td>Kredit Card </td>
                                <td>:</td>
                                <td>
                                    <input class="form-control" type="text">
                                </td>
                            </tr>
                            <tr>
                                <td>BG/Cheque</td>
                                <td>:</td>
                                <td>
                                    <input class="form-control" type="text">
                                </td>
                            </tr>
                        </table>
                        <div style="padding: 10px 5px 10px 5px"></div>
                    </div>
                </div>
                <div class="col-md-4">
                    <label>Jumlah Bayar</label>
                </div>
                <div class="col-md-8">
                    <input class="form-control" type="text">
                </div>
                <div style="padding: 20px 5px 20px 5px"></div>
                <div class="col-md-4">
                    <label>Jumlah Kembalian</label>
                </div>
                <div class="col-md-8">
                    <input class="form-control" type="text">
                </div>
                <div class="col-md-4">
                    <label></label>
                </div>
                <div class="col-md-8">
                    <button class="btn btn-default" type="button">Check Out</button>
                    <p><br>
                        <span style="color: red; font-weight: bold">Klik sekali saja dan tunggu hingga keluar invoice</span>
                    </p>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

